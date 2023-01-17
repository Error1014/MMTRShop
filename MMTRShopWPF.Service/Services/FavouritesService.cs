using MMTRShopWPF.Model;
using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMTRShopWPF.Service.Services
{
    public class FavouritesService
    {
        UnitOfWork UnitOfWork { get; set; }
        public FavouritesService()
        {
            UnitOfWork = new UnitOfWork(new ShopContext());
        }
        public List<Favourites> GetFavourites()
        {
            return UnitOfWork.Favorites.GetFavourites(AccountManager.Client).ToList();
        }
        public Favourites GetFavourit(Product product)
        {
            return UnitOfWork.Favorites.Find(f=>f.ClientId == AccountManager.Client.Id && f.ProductId == product.Id);
        }

        public void RemoveFavouritById(Guid id)
        {
            Favourites favourit = UnitOfWork.Favorites.Find(f=>f.Id==id);
            RemoveFavourite(favourit);
        }

        public void AddFavourite(Favourites favourit)
        {
            UnitOfWork.Favorites.Add(favourit);
            UnitOfWork.Favorites.Save();
        }
        public void RemoveFavourite(Favourites favourit)
        {
            UnitOfWork.Favorites.Remove(favourit);
            UnitOfWork.Favorites.Save();
        }
    }
}
