using MMTRShop.Model.Models;
using MMTRShop.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Interface
{
    public interface IFavouriteService
    {
        Task<IEnumerable<Favourite>> GetFavourites();
        Task<Favourite> GetFavourit(Product product);
        Task RemoveFavourietById(Guid id);
        Task AddFavourite(Favourite favourit);
        Task RemoveFavourite(Favourite favourit);
    }
}
