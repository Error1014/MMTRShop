using System;

namespace MMTRShop.Repository.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        IFavouritesRepository Favorites { get; }
        IBankCardRepository BankCards { get; }
        IFeedbackReporitory Feedbacks { get; }
        int Complete();
    }
}
