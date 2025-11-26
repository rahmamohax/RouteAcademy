using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services.Exceptions
{
    public abstract class NotFoundException(string message) : Exception(message)
    {
    }

    public sealed class ProductNotFoundException(int id) : NotFoundException($"Product with Id {id} was Not Found");

    public sealed class BasketNotFoundException(string id) : NotFoundException($"Basket with Id {id} was Not Found");
}
