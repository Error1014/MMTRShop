using MMTRShop.Repository.Entities;
using MMTRShop.Repositories.Repository;
using MMTRShop.Repository.Contexts;
using MMTRShop.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using XAct;

namespace MMTRShop.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        public UnitOfWork(ShopContext context)
        {
            _dbContext = context;
            Products = new ProductRepository(context);
            Categories = new CategoryRepository(context);
            Brands = new BrandRepository(context);
            Favorites = new FavouritesRepository(context);
            BankCards = new BankCardRepository(context);
            Orders = new OrderRepository(context);
            OrderContents = new OrderContentRepository(context);
            Status = new StatusRepository(context);
            Feedbacks = new FeedbackRepository(context);
        }

        public UnitOfWork(CartContext context)
        {
            _dbContext = context;
            CartItems = new CartItemRopository(context);
            Carts = new CartRepositiry(context);
        }

        public UnitOfWork(UserContext context)
        {
            _dbContext = context;
            Users = new UserRepository(context);
            Clients = new ClientRepository(context);
            Admins = new AdminRepository(context);
            Operators = new OperatorRepository(context);
        }
        public IProductRepository Products { get; private set; }

        public ICartItemRepository CartItems { get; private set; }
        public ICartRepository Carts { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public IBrandRepository Brands { get; private set; }

        public IUserRepository Users { get; private set; }

        public IClientRepository Clients { get; private set; }

        public IFavouritesRepository Favorites { get; private set; }

        public IBankCardRepository BankCards { get; private set; }

        public IOrderRepository Orders { get; private set; }

        public IOrderContentRepository OrderContents { get; private set; }

        public IStatusRepository Status { get; private set; }

        public IAdminRepository Admins { get; private set; }
        public IOperatorRepository Operators { get; private set; }
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
