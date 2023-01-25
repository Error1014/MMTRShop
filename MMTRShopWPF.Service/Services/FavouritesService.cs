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
        private readonly UnitOfWork _unitOfWork;
        public FavouritesService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<Favourites> GetFavourites()
        {
            return _unitOfWork.Favorites.GetFavourites(AccountManager.Client).ToList();
        }
        public Favourites GetFavourit(Product product)
        {
            return _unitOfWork.Favorites.Find(f=>f.ClientId == AccountManager.Client.Id && f.ProductId == product.Id);
        }

        public void RemoveFavouritById(Guid id)
        {
            Favourites favourit = _unitOfWork.Favorites.Find(f=>f.Id==id);
            RemoveFavourite(favourit);
        }

        public void AddFavourite(Favourites favourit)
        {
            _unitOfWork.Favorites.Add(favourit);
            _unitOfWork.Favorites.Save();
        }
        public void RemoveFavourite(Favourites favourit)
        {
            _unitOfWork.Favorites.Remove(favourit);
            _unitOfWork.Favorites.Save();
        }
    }
}
