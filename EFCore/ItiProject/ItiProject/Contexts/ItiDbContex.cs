using ItiProject.Configurations;
using ItiProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItiProject.Contexts
{
    internal class ItiDbContex : DbContext
    {

        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<Course_Inst> Course_Insts { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfig());
            modelBuilder.ApplyConfiguration(new InstructorConfig());

            modelBuilder.Entity<Course_Inst>().HasKey( c => new {c.CourseId, c.InstId});
            modelBuilder.Entity<StudentCourse>().HasKey( c => new { c.StudentId, c.CourseId });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=RAHMA\\SQLEXPRESS;Database=ITI;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
