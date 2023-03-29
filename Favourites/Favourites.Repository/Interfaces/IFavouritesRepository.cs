using Shop.Infrastructure.HelperModels;
using Shop.Infrastructure.Repository;
using System;
using System.Collections.Generic;

namespace Favourites.Repository.Interfaces
{
    public interface IFavouritesRepository : IRepository<Favourite, Guid>
    {
        Task<Guid> GetIdByClientIdAndProductId(Guid clientId, Guid productId);
        Task<IEnumerable<Favourite>> GetFavourites(Guid clientId);
        Task<IEnumerable<Favourite>> GetFavourites(FilterByClient filter);
    }
}
