using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Shared.OrderDtos
{
    public record OrderToReturnDto(Guid Id, string UserEmail, ICollection<OrderItemDto> Items, AddressDto Address,
        string DeliveryMethod, string OrderStatus, DateTimeOffset OrderDate, decimal SubTotal, decimal Total);
}
