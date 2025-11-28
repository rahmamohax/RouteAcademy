using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities.OrderModule
{
    public class Order : BaseEntity<Guid>
    {
        public string UserEmail { get; set; } = default!;
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public OrderAddress Address { get; set; } = default!;
        public int DeliveryMethodId { get; set; } //FK
        public DeliveryMethod DeliveryMethod { get; set; } = default!;
        public ICollection<OrderItem> Items { get; set; } = [];
        public decimal SubTotal { get; set; } //total of items
        //public decimal Total { get; set; } //subtotal + deleviry cost
        public decimal GetTotal() => SubTotal + DeliveryMethod.Price;

    }
}
