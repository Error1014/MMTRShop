using MMTRShopWPF.Model;
using MMTRShopWPF.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;

namespace MMTRShopWPF.Repositories.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ShopContext context) : base(context)
        {

        }

        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }

        public List<Product> GetProductsPage(int numPage, int sizePage,Category category)
        {
            return ShopContext.Product.OrderBy(product => product.Id).Where(product => product.CategoryId == category.Id).Skip((numPage - 1) * sizePage).Take(sizePage).ToList();
        }

        public List<Product> GetProductsPage(int numPage, int sizePage,Brand brand)
        {
            return ShopContext.Product.OrderBy(product => product.Id).Where(product => product.BrandId == brand.Id).Skip((numPage - 1) * sizePage).Take(sizePage).ToList();
        }

        public List<Product> GetProductsPage(int numPage, int sizePage,Category category, Brand brand)
        {
            return ShopContext.Product.OrderBy(product => product.Id).Where(product => product.CategoryId == category.Id && product.BrandId == brand.Id).Skip((numPage - 1) * sizePage).Take(sizePage).ToList();
        }

        public List<Product> GetProductsPage(int numPage, int sizePage)
        {
            return ShopContext.Product.OrderBy(product=> product.Id).Skip((numPage-1)*sizePage).Take(sizePage).ToList();
        }
    }
}
