using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.ModelConfiguration;
using System.Reflection.Emit;
using Algorithms.StrictExtensionDemo;

namespace Algorithms.EntityFrameworkPivot
{
    public class MyContext : DbContext
    {
        public MyContext():base("TestConnectionString")
        {
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeMapping());
            modelBuilder.Configurations.Add(new CustomFieldMapping());
            modelBuilder.Configurations.Add(new CustomFieldDataMapping());
            modelBuilder.Configurations.Add(new ExtensionFieldMapping());
            modelBuilder.Configurations.Add(new ExtensionFieldLabelMapping());

            base.OnModelCreating(modelBuilder);
        }
    }

    public class EmployeeMapping : EntityTypeConfiguration<Employee>
    {
        public EmployeeMapping()
        {
            ToTable("Employee");
            HasKey(p => p.Id);

            Property(e => e.Id).HasColumnName("Id");
            Property(e => e.EmployerId).HasColumnName("EmployerId");
            Property(e => e.Name).HasColumnName("Name");
        }
    }

    public class CustomFieldMapping : EntityTypeConfiguration<CustomField>
    {
        public CustomFieldMapping()
        {
            ToTable("CustomField");
            HasKey(p => p.Id);

            Property(e => e.Id).HasColumnName("Id");
            Property(e => e.EmployerId).HasColumnName("EmployerId");
            Property(e => e.EntityTypeId).HasColumnName("EntityTypeId");
            Property(e => e.DataType).HasColumnName("DataType");
            Property(e => e.FieldName).HasColumnName("FieldName");
        }
    }

    public class CustomFieldDataMapping : EntityTypeConfiguration<CustomFieldData>
    {
        public CustomFieldDataMapping()
        {
            ToTable("CustomFieldData");
            HasKey(p => p.Id);

            Property(e => e.Id).HasColumnName("Id");
            Property(e => e.EmployerId).HasColumnName("EmployerId");
            Property(e => e.FieldId).HasColumnName("FieldId");
            Property(e => e.EntityId).HasColumnName("EntityId");
            Property(e => e.Data).HasColumnName("Value");
        }
    }

    public class ExtensionFieldMapping : EntityTypeConfiguration<ExtensionField>
    {
        public ExtensionFieldMapping()
        {
            ToTable("ExtensionField");
            HasKey(p => p.Id);

            Property(e => e.Id).HasColumnName("Id");
            Property(e => e.EmployerId).HasColumnName("EmployerId");
            Property(e => e.EntityTypeId).HasColumnName("EntityTypeId");
            Property(e => e.EntityId).HasColumnName("EntityId");
            Property(e => e.Field1).HasColumnName("Field1Value");
            Property(e => e.Field2).HasColumnName("Field2Value");
            Property(e => e.Field3).HasColumnName("Field3Value");
            Property(e => e.Field4).HasColumnName("Field4Value");
            Property(e => e.Field5).HasColumnName("Field5Value");
        }
    }

    public class ExtensionFieldLabelMapping : EntityTypeConfiguration<ExtensionFieldLabel>
    {
        public ExtensionFieldLabelMapping()
        {
            ToTable("ExtensionFieldLabel");
            HasKey(p => p.Id);

            Property(e => e.Id).HasColumnName("Id");
            Property(e => e.EmployerId).HasColumnName("EmployerId");
            
            Property(e => e.Field1Label).HasColumnName("Field1Label");
            Property(e => e.Field2Label).HasColumnName("Field2Label");
            Property(e => e.Field3Label).HasColumnName("Field3Label");
            Property(e => e.Field4Label).HasColumnName("Field4Label");
            Property(e => e.Field5Label).HasColumnName("Field5Label");
        }
    }
}