using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Algorithms.EntityFrameworkPivot;

namespace Algorithms.DynamicDemo
{
    public class DynamicDbContext : DbContext
    {
        public DynamicDbContext()
            : base("name=DynamicDbContext")
        {
            //Database.SetInitializer(new NullDatabaseInitializer<DynamicDbContext>());
        }

        public void AddTable(Type type)
        {
            _tables.Add(type.Name, type);
        }

        private readonly Dictionary<string, Type> _tables = new Dictionary<string, Type>();

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeMapping());

            var entityMethod = modelBuilder.GetType().GetMethod("Entity");

            foreach (var table in _tables)
            {
                entityMethod.MakeGenericMethod(table.Value).Invoke(modelBuilder, new object[] { });
                foreach (var pi in (table.Value).GetProperties())
                {
                    if (pi.Name == "Id")
                    {
                        modelBuilder.Entity(table.Value).HasKey(typeof(int), "Id");
                        continue;
                    }
                    switch (pi.PropertyType.Name)
                    {
                        case "String":
                            modelBuilder.Entity(table.Value).StringProperty(pi.Name);
                            break;
                        default:
                            modelBuilder.Entity(table.Value).PrimitiveProperty(pi.PropertyType,pi.Name);
                            break;
                    }
                }
            }

            base.OnModelCreating(modelBuilder);
        }
    }

    
}