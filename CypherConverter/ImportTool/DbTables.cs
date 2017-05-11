using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Dep = CypherConverter.Generated.CoredataDb.import_StagedDepartment;

namespace CypherConverter.ImportTool
{
    public interface IPropertyColumnMap
    {
        Type PropertyType { get; }
        string PropertyName { get; }
        string ColumnName { get; }
    }

    public class PropertyColumnMap<TEntity, TProperty> : IPropertyColumnMap
    {
        public Type PropertyType { get; protected set; }
        public string PropertyName { get; protected set; }
        public string ColumnName { get; protected set; }

        public PropertyColumnMap(Expression<Func<TEntity, TProperty>> property, string columnName)
        {
            var member = property.Body as MemberExpression;
            var propInfo = member.Member as PropertyInfo;

            if (propInfo == null) return;

            ColumnName = columnName;
            PropertyName = propInfo.Name;
            PropertyType = propInfo.PropertyType;
        }
    }

    public class EntityBulkCopier<TEntity> where TEntity : class
    {
        private readonly DataTableDbContext _context;
        public EntityBulkCopier(DataTableDbContext context)
        {
            _context = context;
        }

        public void WriteToServer(IList<TEntity> entities)
        {
            var table = _context.GetDataTable(typeof (TEntity));
            var mapper = _context.GetTableMapper(typeof (TEntity));
            foreach (var entity in entities)
            {
                var row = table.NewRow();
                mapper.AddDataToRow(row, entity);
                table.Rows.Add(row);
            }
            WriteToServer(table, mapper);
        }

        private void WriteToServer(DataTable dataTable, IDataTableMapper mapper)
        {
            using (var connection = new  SqlConnection(_context.DbConnectionSetting.ConnectionString))
            {
                using (var sqlBulkCopy = new SqlBulkCopy(connection))
                {
                    try
                    {
                        sqlBulkCopy.DestinationTableName = mapper.TableName;

                        ConfigureBulkCopier(sqlBulkCopy, dataTable, mapper);
                        connection.Open();

                        sqlBulkCopy.WriteToServer(dataTable);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
        }

        private void ConfigureBulkCopier(SqlBulkCopy sqlBulkCopy, DataTable dataTable, IDataTableMapper mapper)
        {
            foreach (DataColumn column in dataTable.Columns)
            {
                if (mapper.CanIgnore(column.ColumnName))
                    continue;
                sqlBulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
            }
        }
    }

    public class DataTableDbContext
    {
        public ConnectionStringSettings DbConnectionSetting { get; }
        private readonly IDictionary<Type, IDataTableMapper> _mappers = new Dictionary<Type, IDataTableMapper>();
        private static readonly IDictionary<Type, DataTable> _tables = new Dictionary<Type, DataTable>();

        public DataTableDbContext(string connectionString)
        {
            DbConnectionSetting = ConfigurationManager.ConnectionStrings[connectionString];
            AddMapper(new DepartmentDataTable());
        }

        public IDataTableMapper GetTableMapper(Type type)
        {
            return _mappers.ContainsKey(type) ? _mappers[type] : null;
        }

        public DataTable GetDataTable(Type type)
        {
            return _tables.ContainsKey(type) ? _tables[type] : null;
        }

        private void AddMapper(IDataTableMapper mapper)
        {
            _mappers.Add(mapper.MapperType, mapper);

            RegisterTableMetadata(mapper);
        }

        private void RegisterTableMetadata(IDataTableMapper mapper)
        {
            if (_tables.ContainsKey(mapper.MapperType))
                return;

            using (var connection = new SqlConnection(DbConnectionSetting.ConnectionString))
            {
                connection.Open();

                var dataTable = new DataTable(mapper.TableName);
                var cmd = $"SELECT TOP 1 * FROM {mapper.TableName} WHERE 1=0";

                var da = new SqlDataAdapter(cmd, connection);
                da.Fill(dataTable);

                _tables.Add(mapper.MapperType, dataTable);
            }
        }
    }

    public interface IDataTableMapper
    {
        Type MapperType { get; }
        string TableName { get; }
        IDictionary<string, IPropertyColumnMap> PropertyToColumnMaps { get; }

        void AddDataToRow(DataRow row, object entity);
        bool CanIgnore(string columnName);
    }

    public abstract class DataTableMapper<TEntity> : IDataTableMapper where TEntity : class 
    {
        private readonly IList<string> _skippedColumns = new List<string>();
        private readonly IEnumerable<PropertyInfo> _properties;

        public Type MapperType => typeof(TEntity);
        public IDictionary<string, IPropertyColumnMap> PropertyToColumnMaps { get; } = new Dictionary<string, IPropertyColumnMap>();
        public string TableName { get; private set; }

        protected DataTableMapper()
        {
            _properties = typeof(TEntity).GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(ø => ø.CanRead && ø.CanWrite);
        }

        public void AddDataToRow(DataRow row, object entity)
        {
            foreach (var property in _properties)
            {
                if (!PropertyToColumnMaps.ContainsKey(property.Name))
                    continue;

                row[PropertyToColumnMaps[property.Name].ColumnName] = property.GetValue(entity);
            }
        }

        public bool CanIgnore(string columnName)
        {
            return _skippedColumns.Any(p => p == columnName);
        }

        protected void MapToTable(string tableName, string schema = "dbo")
        {
            TableName = $"{schema}.{tableName}";
        }
        
        protected void Property<TProperty>(Expression<Func<TEntity, TProperty>> property, string columnName)
        {
            var map = new PropertyColumnMap<TEntity, TProperty>(property, columnName);
            PropertyToColumnMaps.Add(map.PropertyName, map);
        }

        public void Ignore(string columnName)
        {
            _skippedColumns.Add(columnName);
        }
    }
    
    public class DepartmentDataTable : DataTableMapper<StagedDepartment>
    {
        public DepartmentDataTable()
        {
            MapToTable(Dep.TableName, Dep.SchemaName);

            Property(p => p.Id,Dep.Id());
            Property(p => p.EmployerId,Dep.EmployerId());
            Property(p => p.TransactionId,Dep.EntityTransactionId());
            Property(p => p.ImportMode,Dep.ImportMode());
            Property(p => p.DepartmentCode,Dep.DepartmentCode());
            Property(p => p.DepartmentTitle,Dep.DepartmentTitle());
            Property(p => p.IsValid,Dep.IsValid());
            Property(p => p.Status,Dep.Status());

            Ignore(Dep.DepartmentHash());
        }
    }
}