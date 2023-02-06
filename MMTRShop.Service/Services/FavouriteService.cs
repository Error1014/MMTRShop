using MMTRShop.Model;
using MMTRShop.Model.Models;
using MMTRShop.Repository.Interface;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMTRShop.Service.Services
{
    public class FavouriteService: IFavouriteService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FavouriteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Favourite>> GetFavourites()
        {
            return await _unitOfWork.Favorites.GetFavourites(AccountManager.Client);
        }
        public async Task<Favourite> GetFavourit(Product product)
        {
            return await _unitOfWork.Favorites.FindAsync(f=>f.ClientId == AccountManager.Client.Id && f.ProductId == product.Id);
        }

        public async void RemoveFavourietById(Guid id)
        {
            Favourite favourit = await _unitOfWork.Favorites.FindAsync(f=>f.Id==id);
            RemoveFavourite(favourit);
        }

        public void AddFavourite(Favourite favourite)
        {
            _unitOfWork.Favorites.Add(favourite);
            _unitOfWork.Favorites.Save();
        }
        public void RemoveFavourite(Favourite favourite)
        {
            _unitOfWork.Favorites.Remove(favourite);
            _unitOfWork.Favorites.Save();
        }
    }
}
