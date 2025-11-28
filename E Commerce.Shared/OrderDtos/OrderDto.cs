using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Shared.OrderDtos
{
    public record OrderDto(string BasketId, int DeliveryMethodId, AddressDto Address);
    
}
