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
    internal class TrainerConfig : GymUserConfig<Trainer>, IEntityTypeConfiguration<Trainer>
    {
        public new void Configure(EntityTypeBuilder<Trainer> builder)
        {
            base.Configure(builder);
            builder.Property(m => m.CreatedAt).HasColumnName("HireDate").HasDefaultValueSql("GETDATE()");

        }
    }
}
