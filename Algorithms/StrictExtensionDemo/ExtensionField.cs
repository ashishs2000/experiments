using System;
using System.Linq;
using Algorithms.EntityFrameworkPivot;

namespace Algorithms.StrictExtensionDemo
{
    public class ExtensionFieldHandler
    {
        private MyContext _db;
        public ExtensionFieldHandler()
        {
            this._db = new MyContext();
        }

        public void Demo()
        {
            try
            {
                //AddExtensionFields(1470, EntityType.Employee, "Social", "EyeColor");
                GenerateData();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void GenerateData()
        {
            var employees = _db.Set<Employee>().ToList();
            foreach (var employee in employees)
            {
                _db.Set<ExtensionField>().Add(new ExtensionField
                {
                    EntityTypeId = EntityType.Employee,
                    EmployerId = 1470,
                    EntityId = employee.Id,
                    Field1 = Guid.NewGuid().ToString(),
                    Field2 = Randomizer.GetRandom("Black","Blue","Red","Orange","Pink")
                });
            }
            
            _db.SaveChanges();
        }


        private void AddExtensionFields(int employerId,
            EntityType type,
            string field1Label = null,
            string field2Label = null,
            string field3Label = null,
            string field4Label = null,
            string field5Label = null)
        {
            _db.Set<ExtensionFieldLabel>().Add(new ExtensionFieldLabel
            {
                EntityTypeId = type,
                EmployerId = employerId,
                Field1Label = field1Label,
                Field2Label = field2Label,
                Field3Label = field3Label,
                Field4Label = field4Label,
                Field5Label = field5Label
            });
            _db.SaveChanges();
        }
    }

    public class ExtensionField
    {
        public int Id { get; set; }
        public int EmployerId { get; set; }
        public EntityType  EntityTypeId { get; set; }
        public int EntityId { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public string Field5 { get; set; }
    }

    public class ExtensionFieldLabel
    {
        public int Id { get; set; }
        public int EmployerId { get; set; }
        public EntityType EntityTypeId { get; set; }
        public string Field1Label { get; set; }
        public string Field2Label { get; set; }
        public string Field3Label { get; set; }
        public string Field4Label { get; set; }
        public string Field5Label { get; set; }
    }
}