using System;

namespace MMTRShop.Repository.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        IProductRepository Products { get; }
        ICartRepository Carts { get; }
        ICategoryRepository Categories { get; }
        IBrandRepository Brands { get; }
        IUserRepository Users { get; }
        IClientRepository  Clients { get; }
        IFavouritesRepository Favorites { get; }
        IBankCardRepository BankCards { get; }
        IOrderRepository Orders { get; }
        IOrderContentRepository OrderContents { get; }
        IStatusRepository Status { get; }
        IAdminRepository Admins { get; }
        IOperatorRepository Operators { get; }
        IFeedbackReporitory Feedbacks { get; }
        int Complete();
    }
}
