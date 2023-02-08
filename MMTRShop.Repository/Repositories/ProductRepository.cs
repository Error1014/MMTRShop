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
        public async Task<IEnumerable<Product>> GetProductsPage(int numPage, int sizePage, Guid? categoryId, Guid? brandId)
        {
            var query = ShopContext.Product.AsQueryable();
            if (categoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == categoryId);
            }
            if (brandId.HasValue)
            {
                query = query.Where(x => x.BrandId == brandId);
            }
            query = query
                .OrderBy(x => x.Id)
                .Skip((numPage - 1) * sizePage)
                .Take(sizePage);
            return await query.ToListAsync();
        }
    }
}
