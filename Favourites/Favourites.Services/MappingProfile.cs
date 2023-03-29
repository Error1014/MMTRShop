using AutoMapper;
using Favourites.Repository;
using Shop.Infrastructure.DTO;

namespace Favourites.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Favourite, FavouriteDTO>();
            CreateMap<Favourite, FavouriteDTO>().ReverseMap();
        }
    }
}
