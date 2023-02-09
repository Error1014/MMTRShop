using AutoMapper;
using MMTRShop.DTO.DTO;
using MMTRShop.Model.Models;

namespace MMTRShopAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>(); 
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
