using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProjectDAL.Data.Configurations
{
    internal class BaseEntityConfig<T> : IEntityTypeConfiguration<T> where T : BaseEntity, new()
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.CreatedOn).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.LastModifiedOn).HasComputedColumnSql("GETDATE()");
        }
    }
}
