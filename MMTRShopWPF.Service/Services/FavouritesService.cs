using MMTRShopWPF.Model;
using MMTRShopWPF.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMTRShopWPF.Service.Services
{
    public class FavouritesService:BaseService
    {
        public static List<Favourites> GetFavourites()
        {
            return UnitOfWork.Favorites.GetFavourites(AccountManager.Client).ToList();
        }
        public static Favourites GetFavourit(Product product)
        {
            return UnitOfWork.Favorites.Find(f=>f.ClientId == AccountManager.Client.Id && f.ProductId == product.Id);
        }

        public static void RemoveFavouritById(Guid id)
        {
            Favourites favourit = UnitOfWork.Favorites.Find(f=>f.Id==id);
            RemoveFavourite(favourit);
        }

        public static void AddFavourite(Favourites favourit)
        {
            UnitOfWork.Favorites.Add(favourit);
            UnitOfWork.Favorites.Save();
        }
        public static void RemoveFavourite(Favourites favourit)
        {
            UnitOfWork.Favorites.Remove(favourit);
            UnitOfWork.Favorites.Save();
        }
    }
}
