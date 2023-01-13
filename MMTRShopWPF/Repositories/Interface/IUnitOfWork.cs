using System;

namespace MMTRShopWPF.Repositories.Interface
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
        IBankCardRepository BankCards { get; }
        IOrderRepository Orders { get; }
        ICartOrderRepository CartOrders { get; }
        IStatusRepository Status { get; }
        int Complete();
    }
}
