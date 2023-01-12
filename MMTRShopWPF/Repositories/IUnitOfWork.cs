using MMTRShopWPF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Repositories
{
    internal interface IUnitOfWork:IDisposable
    {
        IProductRepository Products { get; }
        ICartRepository Carts { get; }
        ICategoryRepository Categorys { get; }
        IBrandRepository Brands { get; }
        IUserRepository Users { get; }
        IClientRepository  Clients { get; }
        IFavouritesRepository Favorites { get; }
        int Complete();
    }
}
