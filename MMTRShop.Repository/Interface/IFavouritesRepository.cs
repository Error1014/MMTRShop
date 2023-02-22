using Shop.Infrastructure.HelperModels;
using MMTRShop.Repository.Entities;
using System;
using System.Collections.Generic;

namespace MMTRShop.Repository.Interface
{
    public interface IFavouritesRepository: IRepository<Favourite,Guid>
    {
        Task<IEnumerable<Favourite>> GetFavourites(Guid clientId);
        Task<IEnumerable<Favourite>> GetFavourites(FilterByClient filter);
    }
}
