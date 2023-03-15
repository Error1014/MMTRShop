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
        private readonly DbContext _context;
        private readonly UserContext _userContext;

        public UnitOfWork(ShopContext context)
        {
            _context = context;
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
            _context = context;
            CartItems = new CartItemRopository(_context);
            Carts = new CartRepositiry(_context);
        }

        public UnitOfWork(UserContext context)
        {
            _context = context;
            _userContext = context;
            Users = new UserRepository(_userContext);
            Clients = new ClientRepository(_context);
            Admins = new AdminRepository(_context);
            Operators = new OperatorRepository(_context);
        }
        public UnitOfWork(CartContext cartContext, UserContext userContext)
        {
            CartItems = new CartItemRopository(cartContext);
            Carts = new CartRepositiry(cartContext);
            Users = new UserRepository(userContext);
            Clients = new ClientRepository(userContext);
            Admins = new AdminRepository(userContext);
            Operators = new OperatorRepository(userContext);
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
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
