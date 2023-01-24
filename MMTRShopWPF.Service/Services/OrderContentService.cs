using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service.Services
{
    public class OrderContentService
    {
        private readonly UnitOfWork UnitOfWork;
        public OrderContentService()
        {
            UnitOfWork = new UnitOfWork(new ShopContext());
        }
        public void CreateOrderContent(Order order)
        {
            var carts = UnitOfWork.Carts.GetCartByClient(AccountManager.Client);
            List<OrderContent> cartOrders = new List<OrderContent>();
            foreach (var cartItem in carts)
            {
                cartOrders.Add(new OrderContent(order, cartItem));
            }
            UnitOfWork.OrderContents.AddRange(cartOrders);
            UnitOfWork.OrderContents.Save();
        }
        public List<OrderContent> GetOrderContentNoСompleted(List<Order> orders)
        {
            List<OrderContent> result = new List<OrderContent>();
            foreach (var item in orders)
            {
                if (item.Status.Title!="Получен")
                {
                    result.AddRange(UnitOfWork.OrderContents.GetAll().Where(oc => oc.OrderId == item.Id));
                }
            }

            return result;
        }
        public List<OrderContent> GetOrderContents(Order order)
        {
            return UnitOfWork.OrderContents.GetOrderContents(order);
        }

        public List<OrderContent> GetCancelledOrder()
        {
            return UnitOfWork.OrderContents.GetCanceledOrder();
        }
    }
}
