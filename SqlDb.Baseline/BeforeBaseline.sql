IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'Migrations' AND TABLE_NAME = 'Baseline')
BEGIN
	CREATE TABLE Migrations.Baseline(
	   Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	   TableName INT NOT NULL UNIQUE,
	   IsCompleted bit NOT NULL default(0),
	   Error varchar(max) NULL,
	   CreatedOn datetime default(getdate())
	)
END

DECLARE @EmployerIds table (EmployerId int)



