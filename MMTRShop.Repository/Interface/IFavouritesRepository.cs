using MMTRShop.Model.HelperModels;
using MMTRShop.Model.Models;
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
