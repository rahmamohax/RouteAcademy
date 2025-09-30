using System;
using System.Collections.Generic;
using DatabaseFirst.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirst.Context;

public partial class InheritanceCompanyContext : DbContext
{
    public InheritanceCompanyContext()
    {
    }

    public InheritanceCompanyContext(DbContextOptions<InheritanceCompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }

    public virtual DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=InheritanceCompany;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FullTimeEmployee>(entity =>
        {
            entity.ToTable("FullTimeEmployee");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.FullTimeEmployee).HasForeignKey<FullTimeEmployee>(d => d.Id);
        });

        modelBuilder.Entity<PartTimeEmployee>(entity =>
        {
            entity.ToTable("PartTimeEmployee");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.HourRate).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.PartTimeEmployee).HasForeignKey<PartTimeEmployee>(d => d.Id);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
