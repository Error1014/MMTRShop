using Authorization.Repository.Entities;
using AutoMapper;
using Shop.Infrastructure.DTO;

namespace Authorization.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
