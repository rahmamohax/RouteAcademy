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

    public class Product
    {
        public long ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }

        public override string ToString()
            => $"ProductID: {ProductID}, ProductName: {ProductName}, Category: {Category}, UnitPrice: {UnitPrice:c}, UnitsInStock: {UnitsInStock}";

    }
}
