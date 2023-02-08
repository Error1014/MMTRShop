using MMTRShop.Model.Models;
using MMTRShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMTRShop.Repository.Repositories
{
    public class OrderContentRepository:Repository<OrderContent,Guid>, IOrderContentRepository
    {
        public OrderContentRepository(ShopContext context) : base(context)
        {

        }

        public async Task<IEnumerable<OrderContent>> GetCanceledOrderByClientId(Guid clientId)
        {
            return ShopContext.OrderContent.Where(o => o.Order.Status.Title == "Получен" && o.Order.ClientId == clientId);
        }

        public async Task<IEnumerable<OrderContent>> GetOrderContentsByOrderId(Guid orderId)
        {
            return ShopContext.OrderContent.Where(o => o.OrderId == orderId);
        }
    }
}
