using MMTRShop.Model.Models;
using MMTRShop.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Interface
{
    public interface IFavouritesService
    {
        Task<IEnumerable<Favourite>> GetFavourites();
        Task<Favourite> GetFavourit(Product product);
        void RemoveFavourietById(Guid id);
        void AddFavourite(Favourite favourit);
        void RemoveFavourite(Favourite favourit);
    }
}
