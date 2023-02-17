using Microsoft.EntityFrameworkCore;
using MMTRShop.Model.HelperModels;
using MMTRShop.Model.Models;
using MMTRShop.Repository.Contexts;
using MMTRShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMTRShop.Repository.Repositories
{
    public class OrderRepository:Repository<Order,Guid>,IOrderRepository
    {
        public OrderRepository(ShopContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Order>> GetOrders(FilterByClient filter)
        {
            var query = ShopContext.Order.AsQueryable();
            if (filter.ClientId.HasValue)
            {
                query = query.Where(x => x.ClientId == filter.ClientId);
            }
            query = query
                .OrderBy(x => x.Id)
                .Skip((filter.NumPage - 1) * filter.SizePage)
                .Take(filter.SizePage);
            return await query.ToListAsync();
        }
    }
}
