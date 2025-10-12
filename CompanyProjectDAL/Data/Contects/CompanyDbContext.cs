

using CompanyProjectDAL.Data.Configurations;
using System.Reflection;

namespace CompanyProjectDAL.Data.Contects
{
    public class CompanyDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Department> Departments { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration<Department>(new DepartmentConfig());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
