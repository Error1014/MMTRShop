using MMTRShop.Model.Models;
using System;
using System.Collections.Generic;

namespace MMTRShop.Repository.Interface
{
    public interface IFavouritesRepository: IRepository<Favourite,Guid>
    {
        Task<IEnumerable<Favourite>> GetFavourites(Client client);
    }
}
