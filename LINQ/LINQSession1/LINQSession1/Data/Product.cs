using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQSession1.Data
{
    public class Product02 : Product
    {
        public int SerialNumber { get; set; }
        public override string ToString()
        {
            return base.ToString() + $", Serial Number : {SerialNumber}";
            ;
        }
    }

    public class Product : IComparable<Product>, IEquatable<Product?>
    {
        public long ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }

        public int CompareTo(Product? other)
        {
            if (other is null) return 1;
            if (ReferenceEquals(other, this)) return 0;
            return decimal.Compare(this.UnitPrice, other.UnitPrice);

        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Product);
        }

        public bool Equals(Product? other)
        {
            return other is not null &&
                   ProductID == other.ProductID &&
                   ProductName == other.ProductName &&
                   Category == other.Category &&
                   UnitPrice == other.UnitPrice &&
                   UnitsInStock == other.UnitsInStock;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductID, ProductName, Category, UnitPrice, UnitsInStock);
        }

        public override string ToString()
            => $"ProductID: {ProductID}, ProductName: {ProductName}, Category: {Category}, UnitPrice: {UnitPrice:c}, UnitsInStock: {UnitsInStock}";

    }
}
