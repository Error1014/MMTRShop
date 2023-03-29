using Microsoft.EntityFrameworkCore;
using Products.Repository.Context;
using Products.Repository.Interfaces;

namespace Products.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        public UnitOfWork(ProductContext context)
        {
            _dbContext = context;
            Products = new ProductRepository(context);
            Categories = new CategoryRepository(context);
            Brands = new BrandRepository(context);
        }

        public IProductRepository Products { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public IBrandRepository Brands { get; private set; }

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
