using MMTRShopWPF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Repositoryes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopContext _context;

        public UnitOfWork(ShopContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
            Korzins = new KorzineRopository(_context);
            Categorys = new CategoryRepository(_context);
        }

        public IProductRepository Products { get;private set; }

        public IKorzineRepository Korzins { get; private set; }

        public ICategoryRepository Categorys { get; private set; }

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
