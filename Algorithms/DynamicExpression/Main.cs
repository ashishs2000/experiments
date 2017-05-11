using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Algorithms.DynamicExpression
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StandardId { get; set; }
        public virtual Standard Standard { get; set; }
    }

    public class Standard
    {
        public int StandardId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }

    public class DemoContext : DbContext
    {
        public DemoContext() : base("testdb")
        {
            Database.SetInitializer<DemoContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                    .HasRequired<Standard>(s => s.Standard) 
                    .WithMany(s => s.Students);

            base.OnModelCreating(modelBuilder);
        }
    }

    public class DemoMain
    {
        public void Run()
        {
            try
            {
                Expression<Func<Student, bool>> con = c => c.StudentName == "Name B";
                Expression<Func<Standard, bool>> con2 = q => q.Students.Any(c => con.Compile().Invoke(c));
                var d = new DemoContext();
                var a = d.Set<Standard>().Where(con2).ToList();
                //var a = d.Set<Standard>().Where(p=>p.Students.Any(con)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}