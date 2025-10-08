using GymMangDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangDAL.Data.Configurations
{
    internal class PlanConfig : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(50).HasColumnType("varchar");

            builder.Property(p => p.Description).HasMaxLength(100).HasColumnType("varchar");

            builder.Property(p => p.Price).HasPrecision(10, 2);

            builder.ToTable(t =>
            {
                t.HasCheckConstraint("DurationCheck", "DurationDays between 1 and 365");
            });
        }
    }
}
