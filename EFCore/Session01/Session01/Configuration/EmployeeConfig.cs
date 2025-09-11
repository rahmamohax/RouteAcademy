using EFCore01.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore01.Configuration
{
    internal class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            //builder.HasKey(e => new {e.EmpId, e.Name});  // Composite PK

            builder.Property(e => e.Name).IsRequired()
                .HasDefaultValue("User")
                .HasMaxLength(50);

            builder.Property(e => e.Age).IsRequired(false);

            builder.Property(e => e.Salary).HasColumnType("money");

            builder.Property(e => e.DateOfCreation).HasDefaultValue(new DateTime(2025, 1, 1));
            //builder.Property(e => e.DateOfCreation).HasDefaultValueSql("GETDATE()");

            builder.OwnsOne(e => e.EmpAddress, Address => Address.WithOwner());
        }
    }
}
