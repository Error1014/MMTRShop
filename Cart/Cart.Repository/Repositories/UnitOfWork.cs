using Microsoft.EntityFrameworkCore;
using Carts.Repository.Interfaces;

namespace Carts.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(CartContext context)
        {
            _dbContext = context;
            CartItems = new CartItemRopository(context);
            Carts = new CartRepositiry(context);
        }

        public ICartItemRepository CartItems { get; private set; }
        public ICartRepository Carts { get; private set; }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
