using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMTRShopWPF.Repository.Repositories
{
    public class OrderContentRepository:Repository<OrderContent,Guid>, IOrderContentRepository
    {
        public OrderContentRepository(ShopContext context) : base(context)
        {

        }

        public List<OrderContent> GetCanceledOrder()
        {
            return ShopContext.OrderContent.Where(o=>o.Order.Status.Title== "Получен").ToList();
        }

        public List<OrderContent> GetOrderContents(Order order)
        {
            return ShopContext.OrderContent.Where(o=>o.OrderId == order.Id).ToList();
        }
    }
}
