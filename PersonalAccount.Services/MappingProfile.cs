using AutoMapper;
using PersonalAccountMicroservice.PersonalAccount.Repository.Entities;
using Shop.Infrastructure.DTO;

namespace PersonalAccountMicroservice.PersonalAccount.Services
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
