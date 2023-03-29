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
            Feedbacks = new FeedbackRepository(context);
        }

        public IFavouritesRepository Favorites { get; private set; }

        public IBankCardRepository BankCards { get; private set; }

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
