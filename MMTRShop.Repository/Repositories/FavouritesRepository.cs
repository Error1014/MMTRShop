using MMTRShop.Model.Models;
using MMTRShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMTRShop.Repository.Repositories
{
    public class FavouritesRepository : Repository<Favourite,Guid>, IFavouritesRepository
    {
        public FavouritesRepository(ShopContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Favourite>> GetFavouritesByClientId(Guid clientId)
        {
            return ShopContext.Favourites.Where(k => k.ClientId == clientId);
        }

    }
}
