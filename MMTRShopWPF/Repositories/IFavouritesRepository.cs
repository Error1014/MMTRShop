using MMTRShopWPF.Model;
using System;
using System.Collections.Generic;

namespace MMTRShopWPF.Repositories
{
    public interface IFavouritesRepository: IRepository<Favourites>
    {
        List<Favourites> GetFavouritesByIdUser(Guid id);
        Favourites GetFavouritByIdUserAndProduct(Guid userId,Guid productId);
    }
}
