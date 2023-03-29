using AutoMapper;
using Orders.Repository.Entities;
using Shop.Infrastructure.DTO;

namespace Orders.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Order, OrderDTO>();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderContent, OrderContentDTO>();
            CreateMap<OrderContent, OrderContentDTO>().ReverseMap();
        }
    }
}
