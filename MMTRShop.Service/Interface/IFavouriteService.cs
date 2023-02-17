using MMTRShop.DTO.DTO;
using MMTRShop.Model.HelperModels;
using MMTRShop.Model.Models;
using MMTRShop.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Interface
{
    public interface IFavouriteService
    {
        Task<IEnumerable<FavouriteDTO>> GetFavouritesByClientId(Guid clientId);
        Task<IEnumerable<FavouriteDTO>> GetFavourites(FilterByClient filter);
        Task<FavouriteDTO> GetFavourite(Guid favouriteId);
        Task RemoveFavourite(Guid id);
        Task AddFavourite(FavouriteDTO favourite);
        Task Update(FavouriteDTO favourite);
        Task Save();
    }
}
