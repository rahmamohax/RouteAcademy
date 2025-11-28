using E_Commerce.Domain.Entities.OrderModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace E_Commerce.Presistence.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.SubTotal).HasPrecision(8, 2);
            builder.OwnsOne(x => x.Address, add =>
            {
                add.Property(x => x.FirstName).HasMaxLength(50);
                add.Property(x => x.LastName).HasMaxLength(50);
                add.Property(x => x.Street).HasMaxLength(50);
                add.Property(x => x.City).HasMaxLength(50);
                add.Property(x => x.Country).HasMaxLength(50);
            });
        }
    }
}
