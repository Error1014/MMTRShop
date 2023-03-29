using AutoMapper;
using Favourites.Repository;
using Favourites.Repository.Interfaces;
using Shop.Infrastructure.Attributes;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.Exceptions;
using Shop.Infrastructure.HelperModels;
using Shop.Infrastructure.Interface;

namespace Favourites.Services
{
    public class FavouriteService : IFavouriteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserSessionGetter _userSession;
        public FavouriteService(IUnitOfWork unitOfWork, IMapper mapper, IUserSessionGetter userSessionGetter)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userSession = userSessionGetter;
        }

        public async Task<IEnumerable<FavouriteDTO>> GetFavouritesByClient()
        {
            var favourites = await _unitOfWork.Favorites.GetFavourites(_userSession.UserId);
            var result = _mapper.Map<IEnumerable<FavouriteDTO>>(favourites);
            return result;
        }
        public async Task<IEnumerable<FavouriteDTO>> GetFavourites(BaseFilter filter)
        {
            FilterByClient filterByClient = new FilterByClient(filter,_userSession.UserId);
            var favourites = await _unitOfWork.Favorites.GetFavourites(filterByClient);
            var result = _mapper.Map<IEnumerable<FavouriteDTO>>(favourites);
            return result;
        }
        public async Task<FavouriteDTO> GetFavourite(Guid favouriteId)
        {
            var favourite = await _unitOfWork.Favorites.GetByIdAsync(favouriteId);
            if (favourite == null)
            {
                throw new NotFoundException("Избраное не найдено");
            }
            var result = _mapper.Map<FavouriteDTO>(favourite);
            return result;
        }

        public async Task RemoveFavourite(Guid productId)
        {
            var id = await _unitOfWork.Favorites.GetIdByClientIdAndProductId(_userSession.UserId, productId);
            var favourite = await _unitOfWork.Favorites.GetByIdAsync(id);
            if (favourite == null)
            {
                throw new NotFoundException("Избраное не найдено");
            }
            _unitOfWork.Favorites.Remove(favourite);
            await Save();
        }

        public async Task AddFavourite(Guid productId)
        {
            var favourites = await GetFavouritesByClient();
            foreach (var item in favourites)
            {
                if (item.ProductId == productId)
                {
                    throw new DublicateException("Товар уже находится в избраном");
                }
            }
            var favourite = new Favourite(_userSession.UserId, productId);
            _unitOfWork.Favorites.Add(favourite);
            await Save();
        }
        public async Task Update(FavouriteDTO favouriteDTO)
        {
            var favourite = _mapper.Map<Favourite>(favouriteDTO);
            _unitOfWork.Favorites.Update(favourite);
            await Save();
        }
        public async Task Save()
        {
            await _unitOfWork.Favorites.SaveAsync();
        }
    }
}
