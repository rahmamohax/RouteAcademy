using ItiProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItiProject.Configurations
{
    internal class InstructorConfig : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.Property(i => i.Name).IsRequired().HasMaxLength(50);
            builder.Property(i => i.Salary).HasColumnType("decimal(10,2)");
            builder.Property(i => i.Bonus).HasColumnType("decimal(10,2)");
            builder.Property(i => i.HourRate).HasColumnType("decimal(10,2)");
            builder.Property(i => i.Address).HasMaxLength(100);


        }
    }
}
