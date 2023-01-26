using MMTRShop.Model.Models;
using MMTRShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMTRShop.Repository.Repositories
{
    public class ProductRepository : Repository<Product,Guid>, IProductRepository
    {
        public ProductRepository(ShopContext context) : base(context)
        {

        }

        public IEnumerable<Product> GetProductsPage(int numPage, int sizePage,Category category)
        {
            return ShopContext.Product.OrderBy(product => product.Id).Where(product => product.CategoryId == category.Id).Skip((numPage - 1) * sizePage).Take(sizePage).ToList();
        }

        public IEnumerable<Product> GetProductsPage(int numPage, int sizePage,Brand brand)
        {
            return ShopContext.Product.OrderBy(product => product.Id).Where(product => product.BrandId == brand.Id).Skip((numPage - 1) * sizePage).Take(sizePage).ToList();
        }

        public IEnumerable<Product> GetProductsPage(int numPage, int sizePage,Category category, Brand brand)
        {
            return ShopContext.Product.OrderBy(product => product.Id).Where(product => product.CategoryId == category.Id && product.BrandId == brand.Id).Skip((numPage - 1) * sizePage).Take(sizePage).ToList();
        }

        public IEnumerable<Product> GetProductsPage(int numPage, int sizePage)
        {
            return ShopContext.Product.OrderBy(product=> product.Id).Skip((numPage-1)*sizePage).Take(sizePage).ToList();
        }
    }
}
