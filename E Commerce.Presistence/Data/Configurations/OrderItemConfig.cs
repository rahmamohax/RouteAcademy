using E_Commerce.Domain.Entities.OrderModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace E_Commerce.Presistence.Data.Configurations
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(x => x.Price).HasPrecision(8, 2);
            builder.OwnsOne(x => x.Product, OwnEnt =>
            {
                OwnEnt.Property(x => x.ProductName).HasMaxLength(100);
                OwnEnt.Property(x => x.PictureUrl).HasMaxLength(200);
            });
        }
    }
}
