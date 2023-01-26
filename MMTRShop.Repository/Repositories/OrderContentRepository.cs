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

        public List<OrderContent> GetCanceledOrder(Client client)
        {
            return ShopContext.OrderContent.Where(o=>o.Order.Status.Title== "Получен" && o.Order.ClientId == client.Id).ToList();
        }

        public List<OrderContent> GetOrderContents(Order order)
        {
            return ShopContext.OrderContent.Where(o=>o.OrderId == order.Id).ToList();
        }
    }
}
