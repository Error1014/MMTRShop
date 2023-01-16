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
        public static Favourites GetFavourites(Product product)
        {
            return UnitOfWork.Favorites.GetFavourites(AccountManager.Client, product);
        }

        public static void RemoveFavourit(Guid id)
        {
            Favourites favourit = UnitOfWork.Favorites.GetById(id);
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
