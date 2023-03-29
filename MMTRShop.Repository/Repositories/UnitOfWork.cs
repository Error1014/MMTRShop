using MMTRShop.Repository.Contexts;
using MMTRShop.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MMTRShop.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        public UnitOfWork(ShopContext context)
        {
            _dbContext = context;
            Favorites = new FavouritesRepository(context);
            BankCards = new BankCardRepository(context);
            Orders = new OrderRepository(context);
            OrderContents = new OrderContentRepository(context);
            Status = new StatusRepository(context);
            Feedbacks = new FeedbackRepository(context);
        }

        public IFavouritesRepository Favorites { get; private set; }

        public IBankCardRepository BankCards { get; private set; }

        public IOrderRepository Orders { get; private set; }

        public IOrderContentRepository OrderContents { get; private set; }

        public IStatusRepository Status { get; private set; }

        public IFeedbackReporitory Feedbacks { get; private set; }

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
