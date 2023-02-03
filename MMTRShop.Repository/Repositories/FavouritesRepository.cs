using MMTRShop.Model.Models;
using MMTRShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMTRShop.Repository.Repositories
{
    public class FavouritesRepository : Repository<Favourites,Guid>, IFavouritesRepository
    {
        public FavouritesRepository(ShopContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Favourites>> GetFavourites(Client client)
        {
            return ShopContext.Favourites.Where(k => k.ClientId == client.Id).ToList();
        }

    }
}
