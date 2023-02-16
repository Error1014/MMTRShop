using AutoMapper;
using MMTRShop.DTO.DTO;
using MMTRShop.Model.Models;

namespace MMTRShop.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>(); 
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Brand, BrandDTO>();
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<BankCard, BankCardDTO>();
            CreateMap<BankCard, BankCardDTO>().ReverseMap();
            CreateMap<User, UserDTO>();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Client, ClientDTO>();
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Cart, CartDTO>();
            CreateMap<Cart, CartDTO>().ReverseMap();
        }
    }
}
