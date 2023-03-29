using System;

namespace Favourites.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IFavouritesRepository Favorites { get; }
        int Complete();
    }
}
