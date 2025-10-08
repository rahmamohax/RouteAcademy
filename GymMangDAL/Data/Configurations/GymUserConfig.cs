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
    internal class GymUserConfig<T> : IEntityTypeConfiguration<T> where T : GymUser
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(g => g.Name).HasColumnType("varchar").HasMaxLength(50);

            builder.Property(g => g.Email).HasColumnType("varchar").HasMaxLength(100);

            builder.Property(g => g.Phone).HasColumnType("varchar").HasMaxLength(11);

            builder.ToTable(tb =>
            {
                tb.HasCheckConstraint("ValidEmail", "Email like '_%@_%._%'");
                tb.HasCheckConstraint("ValidPhone", "Phone like '01%' and Phone Not like '%[^0-9]%' ");
            });

            builder.HasIndex(g => g.Email).IsUnique();
            builder.HasIndex(g => g.Phone).IsUnique();

            builder.OwnsOne(x => x.Address, AddressBld =>
            {
                AddressBld.Property(a => a.Street).HasColumnName("Street").HasColumnType("varchar").HasMaxLength(30);
                AddressBld.Property(a => a.City).HasColumnName("City").HasColumnType("varchar").HasMaxLength(30);
                AddressBld.Property(a => a.BuldingNumber).HasColumnName("BuldingNumber");
            });
        }
    }
}
