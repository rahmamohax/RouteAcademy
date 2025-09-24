using MappingInheritance.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingInheritance.Contexts
{
    internal class CompanyContext : DbContext
    {
        #region TPCT [Table Per Concrete Type]
        //public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }
        //public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }

        #endregion

        #region TPH [Table Per Hierarchy]
        //public DbSet<Employee> Employees { get; set; }
        ////public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }
        ////public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }
        #endregion

        #region TPT [Table Per Type]
        public DbSet<Employee> Employees { get; set; }
        public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }
        public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region TPH [Table Per Hierarchy]
            //modelBuilder.Entity<FullTimeEmployee>().HasBaseType(typeof(Employee));
            //modelBuilder.Entity<PartTimeEmployee>().HasBaseType(typeof(Employee));

            //modelBuilder.Entity<Employee>().HasDiscriminator<string>("EmpType")
            //                                .HasValue<FullTimeEmployee>("FT")
            //                                .HasValue<PartTimeEmployee>("PT");

            #endregion

            #region TPT [Table Per Type]
            modelBuilder.Entity<FullTimeEmployee>().ToTable("FullTimeEmployee");
            modelBuilder.Entity<PartTimeEmployee>().ToTable("PartTimeEmployee");

            #endregion

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=RAHMA\\SQLEXPRESS; Database=InheritanceCompany; Trusted_Connection=True; TrustServerCertificate=True");
        }
    }
}
