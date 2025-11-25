using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Shared.DTOs.BasketDTOs
{
    public record BasketItemDto(
        string Id, 
        string ProductName, 
        string PictureUrl,

        [Range(1, 5000)]
        decimal Price,

        [Range(1, 100)]
        int Quantity
        );
}
