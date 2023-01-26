using MMTRShop.Model.Models;
using System;
using System.Collections.Generic;

namespace MMTRShop.Repository.Interface
{
    public interface IFavouritesRepository: IRepository<Favourites,Guid>
    {
        IEnumerable<Favourites> GetFavourites(Client client);
    }
}
