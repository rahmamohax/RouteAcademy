using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Shared
{
    public enum ProductSortingOptions
    {
        NameAsc =1,
        PriceAsc ,
        NameDesc,
        PriceDesc
    }
    public class ProductQueryParams
    {
        public int? TypeId { get; set; }
        public int? BrandId { get; set; }
        public string? Search { get; set; }
        public ProductSortingOptions? Sort { get; set; }

        private int pageIndex = 1;
        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = (value<=0) ? 1: value; }
        }

        private const int DefaultPageSize = 5;
        private const int MaxPageSize = 10;
        private int pageSize = DefaultPageSize;

        public int PageSize
        {
            get { return pageSize; }
            set {
                if (value <= 0)
                    pageSize = DefaultPageSize;
                else if (value > MaxPageSize)
                    pageSize = MaxPageSize;
                pageSize = value;
            }
        }


        //public int? PageIndex { get; set; }
    }
}
