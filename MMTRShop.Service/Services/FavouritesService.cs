using MMTRShop.Model;
using MMTRShop.Model.Models;
using MMTRShop.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMTRShop.Service.Services
{
    public class FavouritesService
    {
        private readonly UnitOfWork _unitOfWork;
        public FavouritesService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Favourites>> GetFavourites()
        {
            return await _unitOfWork.Favorites.GetFavourites(AccountManager.Client);
        }
        public async Task<Favourites> GetFavourit(Product product)
        {
            return await _unitOfWork.Favorites.FindAsync(f=>f.ClientId == AccountManager.Client.Id && f.ProductId == product.Id);
        }

        public async void RemoveFavouritById(Guid id)
        {
            Favourites favourit = await _unitOfWork.Favorites.FindAsync(f=>f.Id==id);
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
