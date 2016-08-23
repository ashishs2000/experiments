using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Dynamic;

namespace Algorithms.DynamicDemo
{
    public class BaseDynamicEntity : DynamicObject
    {
        [Key]
        public int Id { get; set; }

        public int EmployerId { get; set; }
    }
    
   public static class DynamicMapperConfigurator
    {
        public static EntityTypeConfigurationWrapper Entity(this DbModelBuilder builder, Type entityType)
        {
            var config = builder.GetType()
                .GetMethod("Entity")
                .MakeGenericMethod(entityType)
                .Invoke(builder, null);
            return new EntityTypeConfigurationWrapper(config);
        }
    }

}