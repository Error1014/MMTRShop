using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repositories.Repository;
using MMTRShopWPF.Repository.Interface;

namespace MMTRShopWPF.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopContext _context;

        public UnitOfWork(ShopContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
            Carts = new CartRopository(_context);
            Categorys = new CategoryRepository(_context);
            Brands = new BrandRepository(_context);
            Users = new UserRepository(_context);
            Clients = new ClientRepository(_context);
            Favorites = new FavouritesRepository(_context);
            BankCards = new BankCardRepository(_context);
            Orders = new OrderRepository(_context);
            OrderContents = new OrderContentRepository(_context);
            Status = new StatusRepository(_context);
            Admins = new AdminRepository(_context);
            Operators = new OperatorRepository(_context);
        }

        public IProductRepository Products { get;private set; }

        public ICartRepository Carts { get; private set; }

        public ICategoryRepository Categorys { get; private set; }

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
