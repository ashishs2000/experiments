using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CypherConverter.Generated;

namespace CypherConverter.ImportTool
{

    public class Tester
    {
        private DummyGenerator _gen;
        public void Start()
        {
            try
            {
                _gen = new DummyGenerator(12, 1040);
                var departments = _gen.GetDepartment(50000);
                
                var context = new DataTableDbContext("Coredata");
                var copier = new EntityBulkCopier<StagedDepartment>(context);
                copier.WriteToServer(departments);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void UsingEntityFramework()
        {
            try
            {
                using (var context = new CoreDataDbContext())
                {
                    var lastTransactionId = context.Set<StagedDepartment>().Any() ? context.Set<StagedDepartment>().Max(p => p.TransactionId) : 0;
                    var nextTransactionId = lastTransactionId + 10;
                    _gen = new DummyGenerator(nextTransactionId, 1040);

                    //INSERT DEPARTMENT
                    var departments = _gen.GetDepartment(10);
                    context.Set<StagedDepartment>().AddRange(departments);
                    context.SaveChanges();

                    //INSERT CLASS  SPECIFICATION
                    var classSpecs = _gen.GetClassSpec(10);
                    context.Set<StagedClassSpec>().AddRange(classSpecs);
                    context.SaveChanges();
                    var csMin = classSpecs.Min(q => q.Id);
                    var csMax = classSpecs.Max(q => q.Id);

                    //INSERT DIVISION
                    var depMin = departments.Min(q => q.Id);
                    var depMax = departments.Max(q => q.Id);
                    var divisions = _gen.GetDivision(Convert.ToInt32(depMin), Convert.ToInt32(depMax), 10);
                    context.Set<StagedDivision>().AddRange(divisions);
                    context.SaveChanges();
                    var divMin = divisions.Min(q => q.Id);
                    var divMax = divisions.Max(q => q.Id);

                    //INSERT POSITION
                    var positions = _gen.GetPositions(depMin, depMax, divMin, divMax, csMin, csMax, 10);
                    context.Set<StagedPosition>().AddRange(positions);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }

    public class DummyGenerator
    {
        private readonly long _transactionId;
        private readonly int _employerId;
        private readonly Random _rnd = new Random();
        private readonly NumberGenerator _next = new NumberGenerator();

        private readonly Dictionary<long,StagedDepartment> _departments = new Dictionary<long, StagedDepartment>(); 

        public DummyGenerator(long transactionId, int employerId)
        {
            _transactionId = transactionId;
            _employerId = employerId;
        }


        public IList<StagedDivision> GetDivision(int minDepartmentId, int maxDepartmentId, int total)
        {
            var items = new List<StagedDivision>();
            for (var i = 0; i < total; i++)
            {
                var id = i + _next.Next;
                items.Add(new StagedDivision
                {
                    TransactionId = _transactionId,
                    EmployerId = _employerId,
                    IU_DepartmentId = _rnd.Next(minDepartmentId,maxDepartmentId),
                    DivisionCode = $"DivC {i + id}",
                    DivisionTitle = $"DivTitle {i + id}"
                });
            }
            return items;
        }

        public IList<StagedClassSpec> GetClassSpec(int total)
        {
            var items = new List<StagedClassSpec>();
            for (var i = 0; i < total; i++)
            {
                var id = i + _next.Next;
                items.Add(new StagedClassSpec
                {
                    TransactionId = _transactionId,
                    EmployerId = _employerId,
                    ClassSpecificationCode = $"CSCode {i + id}",
                    ClassSpecificationTitle = $"CSTitle {i + id}"
                });
            }
            return items;
        }

        public IList<StagedDepartment> GetDepartment(int total)
        {
            var items = new List<StagedDepartment>();
            for (var i = 0; i < total; i++)
            {
                var id = i + _next.Next;
                items.Add(new StagedDepartment
                {
                    TransactionId = _transactionId,
                    EmployerId = _employerId,
                    DepartmentCode = $"DC {i + id}",
                    DepartmentTitle = $"DTitle {i + id}"
                });
            }
            return items;
        }

        public IList<StagedPosition> GetPositions(long minDep, long maxDep, long minDiv, long maxDiv, long minCs, long maxCs, int total)
        {
            var items = new List<StagedPosition>();
            for (var i = 0; i < total; i++)
            {
                var id = i + _next.Next;
                items.Add(new StagedPosition
                {
                    TransactionId = _transactionId,
                    EmployerId = _employerId,
                    PositionCode = $"PCode {i + id}",
                    PositionTitle = $"PTitle {i + id}",
                    IU_DepartmentId = _rnd.Next(Convert.ToInt32(minDep), Convert.ToInt32(maxDep)),
                    IU_DivisionId = _rnd.Next(Convert.ToInt32(minDiv), Convert.ToInt32(maxDiv)),
                    IU_ClassSpecId = _rnd.Next(Convert.ToInt32(minCs), Convert.ToInt32(maxCs))
                });
            }
            return items;
        } 
    }

    public class NumberGenerator
    {
        private long _next;
        public long Next => _next = _next + 1;
    }



    public class CoreDataDbContext : DbContext
    {
        public CoreDataDbContext(string connectionStringOrName = "Coredata")
            : base(connectionStringOrName)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new StagedEmployeeMap());
            modelBuilder.Configurations.Add(new StagedPositionMap());
            modelBuilder.Configurations.Add(new StagedDepartmentMap());
            modelBuilder.Configurations.Add(new StagedDivisionMap());
            modelBuilder.Configurations.Add(new StagedClassSpecMap());
        }
    }

    #region Entity Mapping

    public abstract class ImportableEntity
    {
        public long Id { get; set; }
        public int EmployerId { get; set; }
        public long TransactionId { get; set; }

        public bool IsValid { get; set; } = false;
        public int ImportMode { get; set; } = 1;
        public int Status { get; set; } = 1;
    }

    public class StagedEmployee : ImportableEntity
    {
        public string EmployeeNumber { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StartDate { get; set; }
        public string SeparationDate { get; set; }

        public string PositionCode { get; set; }
        public string PositionTitle { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentTitle { get; set; }
        public string DivisionTitle { get; set; }
        public string DivisionCode { get; set; }
        public string ClassSpecificationTitle { get; set; }
        public string ClassSpecificationCode { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string IsActive { get; set; }

        public long IU_PositionId { get; set; }
    }

    public class StagedDepartment : ImportableEntity
    {
        public string DepartmentCode { get; set; }
        public string DepartmentTitle { get; set; }
    }

    public class StagedDivision : ImportableEntity
    {
        public string DepartmentCode { get; set; }
        public string DepartmentTitle { get; set; }
        public string DivisionTitle { get; set; }
        public string DivisionCode { get; set; }

        public long IU_DepartmentId { get; set; }
    }

    public class StagedClassSpec : ImportableEntity
    {
        public string ClassSpecificationTitle { get; set; }
        public string ClassSpecificationCode { get; set; }
    }

    public class StagedPosition : ImportableEntity
    {
        public string PositionCode { get; set; }
        public string PositionTitle { get; set; }

        public string DepartmentCode { get; set; }
        public string DepartmentTitle { get; set; }
        public string DivisionTitle { get; set; }
        public string DivisionCode { get; set; }

        public string ClassSpecificationTitle { get; set; }
        public string ClassSpecificationCode { get; set; }

        public long IU_DepartmentId { get; set; }
        public long IU_DivisionId { get; set; }
        public long IU_ClassSpecId { get; set; }
    }

    public static class Extensions
    {
        public static T To<T>(this T config, Func<T, T> action) //where T : PropertyMappingConfiguration
        {
            return action(config);
        }
    }

    public class StagedEmployeeMap : EntityTypeConfiguration<StagedEmployee>
    {
        public StagedEmployeeMap()
        {
            ToTable(CoredataDb.import_StagedEmployee.TableName, CoredataDb.import_StagedEmployee.SchemaName);

            HasKey(e => e.Id);

            Property(e => e.Id).To(CoredataDb.import_StagedEmployee.Id);
            Property(e => e.EmployerId).To(CoredataDb.import_StagedEmployee.EmployerId);
            Property(e => e.TransactionId).To(CoredataDb.import_StagedEmployee.EntityTransactionId);
            Property(e => e.IU_PositionId).To(CoredataDb.import_StagedEmployee.StagedPositionId);

            Property(e => e.EmployeeNumber).To(CoredataDb.import_StagedEmployee.EmployeeNumber);
            Property(e => e.Email).To(CoredataDb.import_StagedEmployee.Email);
            Property(e => e.FirstName).To(CoredataDb.import_StagedEmployee.FirstName);
            Property(e => e.LastName).To(CoredataDb.import_StagedEmployee.LastName);
            Property(e => e.StartDate).To(CoredataDb.import_StagedEmployee.StartDate);
            Property(e => e.SeparationDate).To(CoredataDb.import_StagedEmployee.SeperationDate);
            Property(e => e.Address).To(CoredataDb.import_StagedEmployee.Address);
            Property(e => e.City).To(CoredataDb.import_StagedEmployee.City);
            Property(e => e.State).To(CoredataDb.import_StagedEmployee.State);
            Property(e => e.ZipCode).To(CoredataDb.import_StagedEmployee.ZipCode);
            Property(e => e.Phone).To(CoredataDb.import_StagedEmployee.Phone);
            Property(e => e.IsActive).To(CoredataDb.import_StagedEmployee.IsActive);

            Property(e => e.IsValid).To(CoredataDb.import_StagedEmployee.IsValid);
            Property(e => e.Status).To(CoredataDb.import_StagedEmployee.Status);

            Ignore(p => p.PositionCode);
            Ignore(p => p.PositionTitle);
            Ignore(p => p.DepartmentCode);
            Ignore(p => p.DepartmentTitle);
            Ignore(p => p.DivisionCode);
            Ignore(p => p.DivisionTitle);
            Ignore(p => p.ClassSpecificationCode);
            Ignore(p => p.ClassSpecificationTitle);
        }
    }

    public class StagedPositionMap : EntityTypeConfiguration<StagedPosition>
    {
        public StagedPositionMap()
        {
            ToTable(CoredataDb.import_StagedPosition.TableName, CoredataDb.import_StagedPosition.SchemaName);

            HasKey(e => e.Id);

            Property(e => e.Id).To(CoredataDb.import_StagedPosition.Id);
            Property(e => e.EmployerId).To(CoredataDb.import_StagedPosition.EmployerId);
            Property(e => e.TransactionId).To(CoredataDb.import_StagedPosition.EntityTransactionId);
            Property(e => e.IU_DepartmentId).To(CoredataDb.import_StagedPosition.StagedDepartmentId);
            Property(e => e.IU_DivisionId).To(CoredataDb.import_StagedPosition.StagedDivisionId);
            Property(e => e.IU_ClassSpecId).To(CoredataDb.import_StagedPosition.StagedClassSpecId);

            Property(e => e.PositionTitle).To(CoredataDb.import_StagedPosition.PositionTitle);
            Property(e => e.PositionCode).To(CoredataDb.import_StagedPosition.PositionCode);

            Property(e => e.IsValid).To(CoredataDb.import_StagedPosition.IsValid);
            Property(e => e.Status).To(CoredataDb.import_StagedPosition.Status);

            Ignore(p => p.DepartmentCode);
            Ignore(p => p.DepartmentTitle);
            Ignore(p => p.DivisionCode);
            Ignore(p => p.DivisionTitle);
            Ignore(p => p.ClassSpecificationCode);
            Ignore(p => p.ClassSpecificationTitle);
        }
    }

    public class StagedDivisionMap : EntityTypeConfiguration<StagedDivision>
    {
        public StagedDivisionMap()
        {
            ToTable(CoredataDb.import_StagedDivision.TableName, CoredataDb.import_StagedDivision.SchemaName);

            HasKey(e => e.Id);

            Property(e => e.Id).To(CoredataDb.import_StagedDivision.Id);
            Property(e => e.EmployerId).To(CoredataDb.import_StagedDivision.EmployerId);
            Property(e => e.TransactionId).To(CoredataDb.import_StagedDivision.EntityTransactionId);
            Property(e => e.IU_DepartmentId).To(CoredataDb.import_StagedDivision.StagedDepartmentId);

            Property(e => e.DivisionCode).To(CoredataDb.import_StagedDivision.DivisionCode);
            Property(e => e.DivisionTitle).To(CoredataDb.import_StagedDivision.DivisionTitle);

            Property(e => e.IsValid).To(CoredataDb.import_StagedDivision.IsValid);
            Property(e => e.Status).To(CoredataDb.import_StagedDivision.Status);

            Ignore(p => p.DepartmentCode);
            Ignore(p => p.DepartmentTitle);
        }
    }

    public class StagedDepartmentMap : EntityTypeConfiguration<StagedDepartment>
    {
        public StagedDepartmentMap()
        {
            ToTable(CoredataDb.import_StagedDepartment.TableName, CoredataDb.import_StagedDepartment.SchemaName);

            HasKey(e => e.Id);

            Property(e => e.Id).To(CoredataDb.import_StagedDepartment.Id);
            Property(e => e.EmployerId).To(CoredataDb.import_StagedDepartment.EmployerId);
            Property(e => e.TransactionId).To(CoredataDb.import_StagedDepartment.EntityTransactionId);

            Property(e => e.DepartmentTitle).To(CoredataDb.import_StagedDepartment.DepartmentTitle);
            Property(e => e.DepartmentCode).To(CoredataDb.import_StagedDepartment.DepartmentCode);

            Property(e => e.IsValid).To(CoredataDb.import_StagedDepartment.IsValid);
            Property(e => e.Status).To(CoredataDb.import_StagedDepartment.Status);
        }
    }

    public class StagedClassSpecMap : EntityTypeConfiguration<StagedClassSpec>
    {
        public StagedClassSpecMap()
        {
            ToTable(CoredataDb.import_StagedClassSpec.TableName, CoredataDb.import_StagedClassSpec.SchemaName);

            HasKey(e => e.Id);

            Property(e => e.Id).To(CoredataDb.import_StagedClassSpec.Id);
            Property(e => e.EmployerId).To(CoredataDb.import_StagedClassSpec.EmployerId);
            Property(e => e.TransactionId).To(CoredataDb.import_StagedClassSpec.EntityTransactionId);

            Property(e => e.ClassSpecificationCode).To(CoredataDb.import_StagedClassSpec.ClassSpecCode);
            Property(e => e.ClassSpecificationTitle).To(CoredataDb.import_StagedClassSpec.ClassSpecTitle);

            Property(e => e.IsValid).To(CoredataDb.import_StagedClassSpec.IsValid);
            Property(e => e.Status).To(CoredataDb.import_StagedClassSpec.Status);
        }
    }

    #endregion


    public class CoreBulkCopier
    {
        public void Load(IList<StagedEmployee> employees)
        {
            var table = new DataTable($"{CoredataDb.import_StagedEmployee.SchemaName}.{CoredataDb.import_StagedEmployee.TableName}");

            var col1 = new DataColumn(CoredataDb.import_StagedEmployee.EmployerId(), typeof(int));

            foreach (var stagedEmployee in employees)
            {
                var row = table.NewRow();
                row[col1] = stagedEmployee.EmployerId;
            }
        }
    }
}