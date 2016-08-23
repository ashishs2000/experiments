using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Algorithms.EntityFrameworkPivot
{
    public class DatabaseQuery
    {
        private readonly MyContext _db;
        public DatabaseQuery()
        {
            this._db = new MyContext();
        }

        public void Query()
        {
            try
            {
                var emps = from emp in _db.Set<CustomFieldData>()
                    group emp by emp.EntityId
                    into empGroup
                    select new PivotRow<int, int, string>()
                    {
                        ObjectId = empGroup.Key,
                        Attributes = empGroup.Select(p=>p.FieldId),
                        Values = empGroup.Select(p=>p.Data)
                    };

                var fields = from f in _db.Set<CustomField>()
                             where f.EntityTypeId == EntityType.Employee
                             select f.Id;

                using (var pivotTable = PivotRow<int, int, string>.GetPivotTable(fields.ToList(), emps.ToList()))
                {
                    
                }


                InsertSampleDataForEmployee();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void InsertSampleDataForEmployee()
        {
            var employees = _db.Set<Employee>().ToList();
            var fields = _db.Set<CustomField>().ToList();

            foreach (var employee in employees)
            {
                foreach (var field in fields)
                {
                    string data = null;
                    switch (field.FieldName)
                    {
                        case "Social":
                            data = Guid.NewGuid().ToString();
                            break;
                        case "EyeColor":
                            data = Randomizer.GetRandom(new List<string> { "Blue", "Red", "Black", "Brown" }.ToArray());
                            break;
                    }
                    AddSampleData(1470, field.Id, employee.Id, data);
                }
            }
        }

        private void AddSampleData(int employerId, int fieldId, int entityId, string value)
        {
            var data = _db.Set<CustomFieldData>().FirstOrDefault(p => p.EmployerId == employerId
                                                                   && p.FieldId == fieldId
                                                                   && p.EntityId == entityId);

            if (data != null)
            {
                data.Data = value;
            }
            else
            {
                _db.Set<CustomFieldData>().Add(new CustomFieldData
                {
                    EmployerId = 1470,
                    FieldId = fieldId,
                    EntityId = entityId,
                    Data = value
                });
            }
            _db.SaveChanges();
        }

    }
}