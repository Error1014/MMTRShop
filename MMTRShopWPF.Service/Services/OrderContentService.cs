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
        private readonly UnitOfWork _unitOfWork;
        public OrderContentService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void CreateOrderContent(Order order)
        {
            var carts = _unitOfWork.Carts.GetCartByClient(AccountManager.Client);
            List<OrderContent> cartOrders = new List<OrderContent>();
            foreach (var cartItem in carts)
            {
                cartOrders.Add(new OrderContent(order, cartItem));
            }
            _unitOfWork.OrderContents.AddRange(cartOrders);
            _unitOfWork.OrderContents.Save();
        }
        public List<OrderContent> GetOrderContentNoСompleted(List<Order> orders)
        {
            List<OrderContent> result = new List<OrderContent>();
            foreach (var item in orders)
            {
                if (item.Status.Title!="Получен")
                {
                    result.AddRange(_unitOfWork.OrderContents.GetAll().Where(oc => oc.OrderId == item.Id));
                }
            }

            return result;
        }
        public List<OrderContent> GetOrderContents(Order order)
        {
            return _unitOfWork.OrderContents.GetOrderContents(order);
        }

        public List<OrderContent> GetCancelledOrder()
        {
            return _unitOfWork.OrderContents.GetCanceledOrder(AccountManager.Client);
        }
    }
}
