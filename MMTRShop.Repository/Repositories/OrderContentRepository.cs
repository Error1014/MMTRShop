using MMTRShop.Repository.Entities;
using MMTRShop.Repository.Contexts;
using MMTRShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMTRShop.Repository.Repositories
{
    public class OrderContentRepository:Repository<OrderContent,Guid>, IOrderContentRepository
    {
        private readonly ShopContext _shopContext;
        public OrderContentRepository(ShopContext context) : base(context)
        {
            _shopContext = context;
        }

        public async Task<IEnumerable<OrderContent>> GetCanceledOrderByClientId(Guid clientId)
        {
            return _shopContext.OrderContent.Where(o => o.Order.Status.Title == "Получен" && o.Order.ClientId == clientId);
        }

        public async Task<IEnumerable<OrderContent>> GetOrderContentsByOrderId(Guid orderId)
        {
            return _shopContext.OrderContent.Where(o => o.OrderId == orderId);
        }
    }
}
