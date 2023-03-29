using AutoMapper;
using Products.Repository.Entities;
using Shop.Infrastructure.DTO;

namespace Products.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Brand, BrandDTO>();
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
