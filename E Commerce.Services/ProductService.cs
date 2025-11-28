using AutoMapper;
using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities.ProductModule;
using E_Commerce.Service_Abstraction;
using E_Commerce.Services.Exceptions;
using E_Commerce.Services.Specifications;
using E_Commerce.Shared;
using E_Commerce.Shared.CommonResult;
using E_Commerce.Shared.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<IEnumerable<BrandDTO>> GetAllBrandsAsync()
        {
            var brands  = await _unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();

            return _mapper.Map<IEnumerable<BrandDTO>>(brands);
        }

        public async Task<PaginatedResult<ProductDTO>> GetAllProductsAsync(ProductQueryParams queryParams)
        {
            //Specification -> Get all products with brand and type
            //and filter with brand id or type id if needed

            var repo = _unitOfWork.GetRepository<Product, int>();
            var spec = new AllProductSpecifications(queryParams);
            var products = await repo.GetAllAsync(spec);

            var data =  _mapper.Map<IEnumerable<ProductDTO>>(products);
            var dataCount = data.Count();

            var countSpec = new ProductCountSpecification(queryParams);
            var totaProducts = await repo.CountAsync(countSpec);

            return new PaginatedResult<ProductDTO>(queryParams.PageIndex, dataCount, totaProducts, data);
        }

        public async Task<IEnumerable<TypeDTO>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();

            return _mapper.Map<IEnumerable<TypeDTO>>(types);
        }

        public async Task<Result<ProductDTO>> GetProductByIdAsync(int id)
        {
            // Specification - > Get Product Id including [Brand and Type]
            var spec = new AllProductSpecifications(id);
            var product = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(spec);
            if (product == null)
                return Error.NotFound("Product.NotFound", $"Product with Id {id} is not found");

            return _mapper.Map<ProductDTO>(product);
            //implocit casting to Result<ProductDTO>.Ok();
        }
    }
}
