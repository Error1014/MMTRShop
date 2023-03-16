using AuthorizationMicroservice.Authorization.Repository.Entities;
using AutoMapper;
using Shop.Infrastructure.DTO;

namespace AuthorizationMicroservice.Authorization.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Client, ClientDTO>();
            CreateMap<Client, ClientDTO>().ReverseMap();
        }
    }
}
