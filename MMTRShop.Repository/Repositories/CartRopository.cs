using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.HelperModels;
using MMTRShop.Repository.Entities;
using MMTRShop.Repository.Contexts;
using MMTRShop.Repository.Interface;
using MMTRShop.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMTRShop.Repositories.Repository
{
    public class CartRopository : Repository<Cart,Guid>, ICartRepository
    {
        private readonly ShopContext _shopContext;
        public CartRopository(ShopContext context) : base(context)
        {
            _shopContext = context;
        }

        public async Task<IEnumerable<Cart>> GetCarts(FilterByClient filter)
        {
            var query = ShopContext.Cart.AsQueryable();
            if (filter.ClientId.HasValue)
            {
                query = query.Where(x => x.ClientId == filter.ClientId);
            }
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<Cart>> GetCartsByClient(Guid clientId)
        {
            return await ShopContext.Cart.Where(c=>c.ClientId==clientId).ToListAsync();
        }

        public async Task<Cart> GetCartByClientIdAndProductId(Guid clientId, Guid productId)
        {
            return await ShopContext.Cart.Where(c => c.ClientId == clientId && c.ProductId == productId).FirstOrDefaultAsync();
        }

        public int GetCountPage(int sizePage)
        {
            int countPage = 0;
            if (_shopContext.Product.Count() % sizePage == 0)
            {
                countPage = _shopContext.Product.Count() / sizePage;
            }
            else
            {
                countPage = _shopContext.Product.Count() / sizePage + 1;
            }
            return countPage;
        }
    }
}
