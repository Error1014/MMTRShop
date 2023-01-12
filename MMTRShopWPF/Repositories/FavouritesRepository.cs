using MMTRShopWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Repositories
{
    public class FavouritesRepository : Repository<Favourites>, IFavouritesRepository
    {
        public FavouritesRepository(ShopContext context) : base(context)
        {

        }

        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }

        public List<Favourites> GetFavouritesByIdUser(Guid id)
        {
            return ShopContext.Favourites.Where(k => k.ClientId == id).ToList();
        }

        public Favourites GetFavouritByIdClientAndProduct(Guid clientId, Guid productId)
        {
            return ShopContext.Favourites.Where(k => k.ClientId == clientId && k.ProductId ==productId).FirstOrDefault();
        }
    }
}
