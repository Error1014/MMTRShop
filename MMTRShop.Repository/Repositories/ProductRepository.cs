using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Product>> GetProductsPage(int numPage, int sizePage,Category category)
        {
            return await ShopContext.Product.OrderBy(product => product.Id).Where(product => product.CategoryId == category.Id).Skip((numPage - 1) * sizePage).Take(sizePage).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsPage(int numPage, int sizePage,Brand brand)
        {
            return await ShopContext.Product.OrderBy(product => product.Id).Where(product => product.BrandId == brand.Id).Skip((numPage - 1) * sizePage).Take(sizePage).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsPage(int numPage, int sizePage,Category category, Brand brand)
        {
            return await ShopContext.Product.OrderBy(product => product.Id).Where(product => product.CategoryId == category.Id && product.BrandId == brand.Id).Skip((numPage - 1) * sizePage).Take(sizePage).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsPage(int numPage, int sizePage)
        {
            return await ShopContext.Product.OrderBy(product=> product.Id).Skip((numPage-1)*sizePage).Take(sizePage).ToListAsync();
        }
    }
}
