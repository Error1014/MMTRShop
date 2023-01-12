using MMTRShopWPF.Model;
using MMTRShopWPF.Repositories.Interface;

namespace MMTRShopWPF.Repositories.Repository
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
        }

        public IProductRepository Products { get;private set; }

        public ICartRepository Carts { get; private set; }

        public ICategoryRepository Categorys { get; private set; }

        public IBrandRepository Brands { get; private set; }

        public IUserRepository Users { get; private set; }

        public IClientRepository Clients { get; private set; }

        public IFavouritesRepository Favorites { get; private set; }

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
