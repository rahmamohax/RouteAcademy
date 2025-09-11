using EFCore01.Configuration;
using EFCore01.Data.Entities;
using EFCore01.Data.Entities.M2M;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore01.Contexts
{
    public class CompanyDbContext  : DbContext    //Microsoft.EntityFrameworkCore
    {

        //public CompanyDbContext() : base() { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCource> StudentsCources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Creating Employee Entity
            //modelBuilder.Entity<Employee>(e =>
            //{
            //    e.HasKey(e => e.EmpId);

            //    e.Property(e => e.Name).IsRequired()
            //        .HasDefaultValue("User")
            //        .HasMaxLength(50);

            //    e.Property(e => e.Age).IsRequired(false);

            //    e.Property(e => e.Salary).HasColumnType("money");

            //    e.Property(e => e.DateOfCreation).HasDefaultValue(DateTime.Now);
            //    e.Property(e => e.DateOfCreation).HasDefaultValueSql("GETDATE()");
            //}); 
            #endregion

            modelBuilder.ApplyConfiguration(new EmployeeConfig());

            modelBuilder.Entity<Department>().HasOne(d => d.Manager)
                                             .WithOne(e => e.ManagesDepartment)
                                             .HasForeignKey<Department>(e => e.ManagerId);

            #region Work Relation (1 to M)

            //modelBuilder.Entity<Employee>().HasOne(e => e.WorkDepartment)
            //                .WithMany(/*d => d.Employees*/)
            //                .IsRequired()
            //                .HasForeignKey(e => e.WorkDepartmentId)
            //                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Department>().HasMany(e => e.Employees)
                            .WithOne(d => d.WorkDepartment)
                            .IsRequired(false)
                            .HasForeignKey(e => e.WorkDepartmentId)
                            .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Manager Relation (1 to 1)
            //Manager 1 to 1
            modelBuilder.Entity<Employee>().HasOne(e => e.ManagesDepartment)
                            .WithOne(d => d.Manager)
                            .IsRequired(false)
                            .HasForeignKey<Department>(d => d.ManagerId)
                            .OnDelete(DeleteBehavior.NoAction);
            #endregion

            modelBuilder.Entity<StudentCource>().HasKey(x => new { x.CourseId, x.StudentId })
                ;

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=RAHMA\\SQLEXPRESS;Database=Company;Trusted_Connection=True;TrustServerCertificate=True");


        }
    }
}
