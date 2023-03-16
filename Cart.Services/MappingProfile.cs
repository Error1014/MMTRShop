using AutoMapper;
using CartMicroservice.Carts.Repository.Entities;
using Shop.Infrastructure.DTO;

namespace CartMicroservice.Carts.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CartItem, CartItemDTO>();
            CreateMap<CartItem, CartItemDTO>().ReverseMap();
        }
    }
}
