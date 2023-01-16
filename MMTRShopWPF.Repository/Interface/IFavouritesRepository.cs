using MMTRShopWPF.Model.Models;
using System;
using System.Collections.Generic;

namespace MMTRShopWPF.Repository.Interface
{
    public interface IFavouritesRepository: IRepository<Favourites,Guid>
    {
        IEnumerable<Favourites> GetFavourites(Client client);
        Favourites GetFavourites(Client client, Product product);
    }
}
