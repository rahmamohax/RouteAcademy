using GymMangDAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GymMangDAL.Data.Contexts
{
    public class GymDbContext : IdentityDbContext<ApplicationUser>
    {
        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options) { }

        //public DbSet<ApplicationUser> Users { get; set; }
        //public DbSet<IdentityRole> Roles { get; set; }
        //public DbSet<IdentityUserRole<string>> UserRoles { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<HealthRecord> HealthRecords { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<MemberShip> MemberShips { get; set; }
        public DbSet<MemberSession> MemberSessions { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=RAHMA\\SQLEXPRESS; Database=GymManagement; Trusted_Connection=True; TrustServerCertificate=True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ApplicationUser>()
                .Property(x => x.FirstName).HasColumnType("varchar").HasMaxLength(50);

            modelBuilder.Entity<ApplicationUser>()
                .Property(x => x.LastName).HasColumnType("varchar").HasMaxLength(50);
        }
    }
}
