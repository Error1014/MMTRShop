using AutoMapper;
using MMTRShop.Model.Models;

namespace MMTRShop.Service
{
    public class MappingProfile<TEntity,DTO> : Profile
    {
        public MappingProfile()
        {
            CreateMap<TEntity, DTO>(); 
            CreateMap<TEntity, DTO>().ReverseMap();
        }
    }
}
