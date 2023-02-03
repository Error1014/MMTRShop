using MMTRShop.Model.Models;
using MMTRShop.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Interface
{
    public interface IOrderContentService
    {
        void CreateOrderContent(Order order);
        List<OrderContent> GetOrderContentNoСompleted(List<Order> orders);
        Task<List<OrderContent>> GetOrderContents(Order order);
        Task<List<OrderContent>> GetCancelledOrder();
    }
}
