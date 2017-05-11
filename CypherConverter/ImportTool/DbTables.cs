using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using CypherConverter.Generated;
using Dep = CypherConverter.Generated.CoredataDb.import_StagedDepartment;

namespace CypherConverter.ImportTool
{
    public abstract class PropertyColumn
    {
        public bool IsKey { get; protected set; }
        public Type PropertyType { get; protected set; }
        public string PropertyName { get; protected set; }
        public string ColumnName { get; protected set; }
    }

    public class PropertyColumnMap<TEntity, TProperty> : PropertyColumn
    {
        public Action<PropertyColumnMap<TEntity, TProperty>> OnColumnMapped;

        public PropertyColumnMap(Expression<Func<TEntity, TProperty>> property)
        {
            var member = property.Body as MemberExpression;
            var propInfo = member.Member as PropertyInfo;

            PropertyName = propInfo.Name;
            PropertyType = propInfo.PropertyType;
        }

        public PropertyColumnMap<TEntity, TProperty> Map(string columnName, bool isKey = false)
        {
            ColumnName = columnName;
            IsKey = isKey;
            OnColumnMapped?.Invoke(this);
            return this;
        }
    }

    public abstract class DataTableMapper<TEntity> where TEntity : class 
    {
        private readonly IEnumerable<PropertyInfo> _properties;
        private readonly IDictionary<string, PropertyColumn> _propertyToColumnMaps = new Dictionary<string, PropertyColumn>(); 

        public DataTable DataTable { get; private set; }
        protected DataTableMapper()
        {
            _properties = typeof(TEntity)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(ø => ø.CanRead && ø.CanWrite);
        }

        public void AddRow(TEntity employee)
        {
            var row = DataTable.NewRow();
            foreach (var property in _properties)
            {
                if (!_propertyToColumnMaps.ContainsKey(property.Name)) continue;
                row[_propertyToColumnMaps[property.Name].ColumnName] = property.GetValue(employee);
            }

            DataTable.Rows.Add(row);
        }

        public void ReadOnlyProperty(string columnName, Type type)
        {
            var column = new DataColumn(columnName, type);
            DataTable.Columns.Add(column);
        }

        protected void MapToTable(string tableName, string schema = "dbo")
        {
            DataTable = new DataTable($"{schema}.{tableName}");
        }
        
        protected PropertyColumnMap<TEntity, TProperty> Property<TProperty>(Expression<Func<TEntity, TProperty>> property)
        {
            var prop = new PropertyColumnMap<TEntity, TProperty>(property);
            prop.OnColumnMapped += AddColumn;
            return prop;
        }
        
        private void AddColumn<TProperty>(PropertyColumnMap<TEntity, TProperty> property)
        {
            var column = new DataColumn(property.ColumnName, property.PropertyType);
            DataTable.Columns.Add(column); 
            //if (property.IsKey)
            //    AddKey(column);

            _propertyToColumnMaps.Add(property.PropertyName, property);
        }

        private void AddKey(DataColumn dataColumn)
        {
            if (DataTable.PrimaryKey.Length == 0)
                DataTable.PrimaryKey = (new List<DataColumn>()).ToArray();
            
            var index = DataTable.PrimaryKey.Length;
            DataTable.PrimaryKey[index] = dataColumn;
        }
    }

    public class EmployeeDataTable : DataTableMapper<StagedEmployee>
    {
        public EmployeeDataTable()
        {
            MapToTable(CoredataDb.import_StagedEmployee.TableName, CoredataDb.import_StagedEmployee.SchemaName);

            Property(p => p.Id).Map(CoredataDb.import_StagedEmployee.Id(), true);
            Property(p => p.EmployerId).Map(CoredataDb.import_StagedEmployee.EmployerId());
            Property(p => p.EmployeeNumber).Map(CoredataDb.import_StagedEmployee.EmployeeNumber());
        }
    }

    public class DepartmentDataTable : DataTableMapper<StagedDepartment>
    {
        public DepartmentDataTable()
        {
            MapToTable(Dep.TableName, Dep.SchemaName);

            Property(p => p.Id).Map(Dep.Id(), true);
            Property(p => p.EmployerId).Map(Dep.EmployerId());
            Property(p => p.TransactionId).Map(Dep.EntityTransactionId());
            Property(p => p.ImportMode).Map(Dep.ImportMode());
            Property(p => p.DepartmentCode).Map(Dep.DepartmentCode());
            Property(p => p.DepartmentTitle).Map(Dep.DepartmentTitle());
            Property(p => p.IsValid).Map(Dep.IsValid());
            Property(p => p.Status).Map(Dep.Status());

            //ReadOnlyProperty(Dep.DepartmentHash(), typeof (string));
        }
    }
}