using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Algorithms.EntityFrameworkPivot;

namespace Algorithms.DynamicDemo
{
    public class DynamicMain
    {
        public static DynamicMain Instance => new DynamicMain();
        public void Run()
        {
            var types = new Dictionary<string, Type>
            {
                {"HairColor", typeof (string)},
                {"Age", typeof (int)}
            };

            var values = new Dictionary<string, object>
            {
                {"HairColor", "Black"},
                {"Age", 30}
            };

            var dynamicType = CreateType(1470, "EmployeeExtension", types);
            using (var context = new DynamicDbContext())
            {
                context.AddTable(dynamicType);

                //var instance = CreateInstance(1470, 1, dynamicType, values);
                //context.Set(dynamicType).Add(instance);
                //context.SaveChanges();

                var emp = context.Set<Employee>();
                var extensions = new EmployeeExtension(context);
                var method = typeof(EmployeeExtension).GetMethod("Strategy1");
                var generic = method.MakeGenericMethod(dynamicType);
                generic.Invoke(extensions, new object[] { emp });
            }
        }

        public Type CreateType(int employerId, string entityName, Dictionary<string,Type> properties)
        {
            var factory = new DynamicClassFactory();
            var dynamicType = factory.CreateDynamicType<BaseDynamicEntity>($"{entityName}_{employerId}", properties);
            return dynamicType;
        }

        public BaseDynamicEntity CreateInstance(int employerId, int employeeId, Type type, Dictionary<string, object> propertyValues)
        {
            var instance = Activator.CreateInstance(type, null, null) as BaseDynamicEntity;
            instance.Id = employeeId;
            instance.EmployerId = employerId;

            foreach (var propertyValue in propertyValues)
            {
                var property = type.GetProperty(propertyValue.Key);
                property.SetValue(instance, Convert.ChangeType(propertyValue.Value, property.PropertyType), null);
            }
            
            return instance;
        }
    }
    

    public class EmployeeExtension
    {
        private readonly DynamicDbContext _context;
        public EmployeeExtension(DynamicDbContext context)
        {
            _context = context;
        }

        public void Strategy1<T>(IQueryable<Employee> employees) where T : BaseDynamicEntity
        {
            var query = from s in _context.Set<T>()
                        join e in employees on s.Id equals e.Id
                        select new EmployeeView
                        {
                            Employee = e,
                            Extension = s
                        };

            var result = query.ToList();
        }

        public void Strategy2<T>(Type type, IQueryable<Employee> employees) where T : BaseDynamicEntity
        {
            //var prop = type.GetProperty("HairColor");
            //var lhsParam = Expression.Parameter(type, "i");
            //var lhs = Expression.Property(lhsParam, prop);
            //var rhs = Expression.Constant(Convert.ChangeType(1, prop.PropertyType));

            //var operation = Expression.MakeBinary(ExpressionType.Equal, lhs, rhs);
            //dynamic lamda = Expression.Lambda(operation, lhsParam);
            //var r = lamda.ToString();

            //var e = s.Set(created).Where("Papa = @0",1);

            //var a1 = Expression.Parameter(type, "a");
            //dynamic l1 = Expression.Lambda(Expression.Property(a1, "Id"), a1);

            //var a2 = Expression.Parameter(typeof(Employee), "b");
            //dynamic l2 = Expression.Lambda(Expression.Property(a2, "Id"), a2);

            //var q22 = _context.Set<T>()
            //    .Join(_context.Set<Employee>().AsQueryable(), p => p.Id, q11 => q11.Id, (x, y) => x)
            //    .Select(w=>w.EmployerId)
            //var q = _context.Set<T>().Join(_context.Set<Employee>(), l1, l2, (x, y) => lamda);
        }

    }
}