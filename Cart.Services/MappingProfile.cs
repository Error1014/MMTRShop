using AutoMapper;
using Carts.Repository.Entities;
using Shop.Infrastructure.DTO;

namespace Carts.Services
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
