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
        Task CreateOrderContent(Order order);
        List<OrderContent> GetOrderContentNoСompleted(List<Order> orders);
        Task<IEnumerable<OrderContent>> GetOrderContents(Guid orderId);
        Task<IEnumerable<OrderContent>> GetCancelledOrder();
    }
}
