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
            return await _unitOfWork.Favorites.GetFavouritesByClientId(AccountManager.Client.Id);
        }
        public async Task<Favourite> GetFavourit(Guid productId)
        {
            return await _unitOfWork.Favorites.FindAsync(f=>f.ClientId == AccountManager.Client.Id && f.ProductId == productId);
        }

        public async Task RemoveFavourietById(Guid id)
        {
            Favourite favourit = await _unitOfWork.Favorites.FindAsync(f=>f.Id==id);
            await RemoveFavourite(favourit);
        }

        public async Task AddFavourite(Favourite favourite)
        {
            _unitOfWork.Favorites.Add(favourite);
            await _unitOfWork.Favorites.SaveAsync();
        }
        public async Task RemoveFavourite(Favourite favourite)
        {
            _unitOfWork.Favorites.Remove(favourite);
            await _unitOfWork.Favorites.SaveAsync();
        }
    }
}
