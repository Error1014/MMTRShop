using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;

namespace Favourites.Services
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
