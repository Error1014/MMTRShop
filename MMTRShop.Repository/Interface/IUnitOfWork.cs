using System;

namespace MMTRShop.Repository.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        IFavouritesRepository Favorites { get; }
        IBankCardRepository BankCards { get; }
        IOrderRepository Orders { get; }
        IOrderContentRepository OrderContents { get; }
        IStatusRepository Status { get; }
        IFeedbackReporitory Feedbacks { get; }
        int Complete();
    }
}
