using Algorithms.DynamicDemo;

namespace Algorithms.EntityFrameworkPivot
{
    public enum EntityType : int
    {
        Employee = 1,
        Position = 2
    }

    public enum DataType : int
    {
        String = 0,
        Int = 1,
        Decimal = 2
    }

    public class Employee 
    {
        public int Id { get; set; }
        public int EmployerId { get; set; }
        public string Name { get; set; }
    }

    public class CustomField
    {
        public int Id { get; set; }
        public int EmployerId { get; set; }
        public EntityType EntityTypeId { get; set; }
        public DataType DataType { get; set; }
        public string FieldName { get; set; }
    }

    public class CustomFieldData
    {
        public int Id { get; set; }
        public int EmployerId { get; set; }
        public int FieldId { get; set; }
        public int EntityId { get; set; }
        public string Data { get; set; }
    }

    public class EmployeeView
    {
        public Employee Employee { get; set; }
        public BaseDynamicEntity Extension { get; set; }
    }
}