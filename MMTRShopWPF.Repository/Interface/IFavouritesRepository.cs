using MMTRShopWPF.Model.Models;
using System;
using System.Collections.Generic;

namespace MMTRShopWPF.Repository.Interface
{
    public interface IFavouritesRepository: IRepository<Favourites>
    {
        List<Favourites> GetFavouritesByIdUser(Guid id);
        Favourites GetFavouritByIdClientAndProduct(Guid userId,Guid productId);
    }
}
