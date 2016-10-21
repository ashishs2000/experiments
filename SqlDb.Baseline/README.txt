
####################################
## Gj_mainsite
####################################
1. For Lookup Tables

		WITH Lookups (Name)
		AS
		(
			SELECT SCHEMA_NAME(A.schema_id) + '.' + A.Name as Name
			FROM sys.objects A
			INNER JOIN sys.partitions B ON A.object_id = B.object_id
			WHERE A.type = 'U'
			GROUP BY A.schema_id, A.Name
			HAVING SUM(B.rows) <= 400

			UNION ALL

			SELECT TABLE_SCHEMA + '.' + TABLE_NAME as Name 
			FROM INFORMATION_SCHEMA.TABLES 
			WHERE (TABLE_NAME like '%def' OR TABLE_NAME like '%delete%')
			 AND  TABLE_TYPE = 'table'
		)
		Select '        <add table="' + Name + '" />' 
		from Lookups
		where Name NOT LIKE '%log'
		   OR Name NOT like '%deleted%'

2. For Table to ignore 

		;WITH UnUsedTables (Name) 
		AS ( 
			SELECT SCHEMA_NAME(DBTable.schema_id) + '.' + DBTable.Name as Name
			FROM sys.all_objects  DBTable 
			JOIN sys.dm_db_partition_stats PS ON OBJECT_NAME(PS.object_id)=DBTable.name
			WHERE DBTable.type ='U' 
			AND NOT EXISTS (SELECT OBJECT_ID  
								FROM sys.dm_db_index_usage_stats
								WHERE OBJECT_ID = DBTable.object_id )
			AND DATEDIFF(MONTH, DBTable.modify_date, GETDATE()) > 12 --Older than 12 months

			UNION ALL

			SELECT TABLE_SCHEMA + '.' + TABLE_NAME as Name 
			FROM INFORMATION_SCHEMA.TABLES 
			WHERE TABLE_NAME like '%Log' 
			 AND  TABLE_TYPE = 'table'
		)
		SELECT '        <add table="' + Name + '" />'
		FROM UnUsedTables