using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Products.Repository.Interfaces;
using Products.Repository.Entities;
using Products.Repository.Context;
using Shop.Infrastructure.Repository;

namespace Products.Repository.Repositories
{
    public class ProductRepository : Repository<Product, Guid>, IProductRepository
    {
        public ProductRepository(ProductContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Product>> GetProductsPage(ProductPageFilter filter)
        {
            var query = Set;
            if (filter.CategoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == filter.CategoryId);
            }
            if (filter.BrandId.HasValue)
            {
                query = query.Where(x => x.BrandId == filter.BrandId);
            }
            query = query
                .OrderBy(x => x.Id)
                .Skip((filter.NumPage - 1) * filter.SizePage)
                .Take(filter.SizePage);
            return await query.ToListAsync();
        }
    }
}
