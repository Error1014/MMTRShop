using Microsoft.EntityFrameworkCore;
using Favourites.Repository.Interfaces;
using Favourites.Repository.Context;

namespace Favourites.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        public UnitOfWork(FavouritesContext context)
        {
            _dbContext = context;
            Favorites = new FavouritesRepository(context);
        }

        public IFavouritesRepository Favorites { get; private set; }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
