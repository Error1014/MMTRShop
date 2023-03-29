using AutoMapper;
using BankCards.Repository;
using Shop.Infrastructure.DTO;

namespace BankCards.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<BankCard, BankCardDTO>();
            CreateMap<BankCard, BankCardDTO>().ReverseMap();
        }
    }
}
