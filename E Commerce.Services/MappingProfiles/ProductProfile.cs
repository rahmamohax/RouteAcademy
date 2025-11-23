using AutoMapper;
using E_Commerce.Domain.Entities.ProductModule;
using E_Commerce.Shared.DTOs.ProductDTOs;


namespace E_Commerce.Services.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductBrand, BrandDTO>();

            CreateMap<Product, ProductDTO>()
                .ForMember(x => x.ProductBrand, opt => opt.MapFrom(src => src.ProductBrand.Name))
                .ForMember(x => x.ProductType, opt => opt.MapFrom(src => src.ProductType.Name))
                .ForMember(x => x.PictureUrl, opt => opt.MapFrom<ProductPictureUrlResolver>());



            CreateMap<ProductType, TypeDTO>();
        }
    }
}
