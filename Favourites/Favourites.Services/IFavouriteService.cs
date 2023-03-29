using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;

namespace Favourites.Services
{
    public interface IFavouriteService
    {
        Task<IEnumerable<FavouriteDTO>> GetFavouritesByClient();
        Task<IEnumerable<FavouriteDTO>> GetFavourites(BaseFilter filter);
        Task<FavouriteDTO> GetFavourite(Guid favouriteId);
        Task RemoveFavourite(Guid productId);
        Task AddFavourite(Guid productId);
        Task Update(FavouriteDTO favourite);
        Task Save();
    }
}
