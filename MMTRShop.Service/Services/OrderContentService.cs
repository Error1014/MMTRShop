using MMTRShop.Model.Models;
using MMTRShop.Repository.Interface;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Services
{
    public class OrderContentService: IOrderContentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderContentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async void CreateOrderContent(Order order)
        {
            var carts =await _unitOfWork.Carts.GetCartByClient(AccountManager.Client);
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
            //foreach (var item in orders)
            //{
            //    if (item.Status.Title!="Получен")
            //    {
            //        result.AddRange(_unitOfWork.OrderContents.GetAllAsync().Where(oc => oc.OrderId == item.Id));
            //    }
            //}

            return result;
        }
        public async Task<List<OrderContent>> GetOrderContents(Order order)
        {
            return await _unitOfWork.OrderContents.GetOrderContents(order);
        }

        public async Task<List<OrderContent>> GetCancelledOrder()
        {
            return await _unitOfWork.OrderContents.GetCanceledOrder(AccountManager.Client);
        }
    }
}
