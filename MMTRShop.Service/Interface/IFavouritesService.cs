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
        Task<IEnumerable<Favourites>> GetFavourites();
        Task<Favourites> GetFavourit(Product product);
        void RemoveFavouritById(Guid id);
        void AddFavourite(Favourites favourit);
        void RemoveFavourite(Favourites favourit);
    }
}
