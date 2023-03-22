using AutoMapper;
using PersonalAccount.Repository.Entities;
using Shop.Infrastructure.DTO;

namespace PersonalAccount.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDTO>();
            CreateMap<Client, ClientDTO>().ReverseMap();
        }
    }
}
