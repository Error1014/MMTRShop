using MMTRShopWPF.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service.Services
{
    public class MyOrderService:BaseService
    {
        public static List<Order> GetOrderClient(Client client)
        {
            return UnitOfWork.Orders.GetOrdersByClientId(client.Id);
        }

        public static List<OrderContent> GetOrderContent(List<Order> orders)
        {
            List<OrderContent> result = new List<OrderContent>();
            foreach (var item in orders)
            {
                result.AddRange(UnitOfWork.OrderContents.GetAll().Where(oc=>oc.OrderId==item.Id));
            }
           
            return result;
        }
    }
}
