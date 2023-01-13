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
            return UnitOfWork.Favorites.GetFavouritesByIdUser(AccountManager.Client.Id);
        }
        public static Favourites GetFavourites(Guid id)
        {
            return UnitOfWork.Favorites.GetFavouritByIdClientAndProduct(AccountManager.Client.Id, id);
        }
        public static List<Product> GetProducts()
        {
            var products = GetFavourites().Join(UnitOfWork.Products.GetAll(),
            f => f.ProductId,
            p => p.Id, (f, p) => new { f, p }).Select(x => x.p).ToList();
            return products;
        }

        public static void RemoveFavouritById(Guid id)
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
