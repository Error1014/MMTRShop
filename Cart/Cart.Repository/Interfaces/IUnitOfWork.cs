using System;

namespace Carts.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICartItemRepository CartItems { get; }
        ICartRepository Carts { get; }
        int Complete();
    }
}
