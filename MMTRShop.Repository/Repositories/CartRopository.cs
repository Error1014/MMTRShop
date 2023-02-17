using Microsoft.EntityFrameworkCore;
using MMTRShop.Model.HelperModels;
using MMTRShop.Model.Models;
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
        public CartRopository(ShopContext context) : base(context)
        {

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
            return ShopContext.Cart.Where(k=>k.ClientId==clientId);
        }

        public int GetCountPage(int sizePage)
        {
            int countPage = 0;
            if (ShopContext.GetContext().Product.Count() % sizePage == 0)
            {
                countPage = ShopContext.GetContext().Product.Count() / sizePage;
            }
            else
            {
                countPage = ShopContext.GetContext().Product.Count() / sizePage + 1;
            }
            return countPage;
        }
    }
}
