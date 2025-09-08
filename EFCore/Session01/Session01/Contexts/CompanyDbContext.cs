using EFCore01.Configuration;
using EFCore01.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore01.Contexts
{
    internal class CompanyDbContext  : DbContext    //Microsoft.EntityFrameworkCore
    {

        public CompanyDbContext() : base() { }

        public DbSet<Employee> Employees { get; set; }

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

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=RAHMA\\SQLEXPRESS;Database=Company;Trusted_Connection=True;TrustServerCertificate=True");


        }
    }
}
