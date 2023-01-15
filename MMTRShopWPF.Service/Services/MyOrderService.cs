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

        public static List<OrderContent> GetOrderContent()
        {
            var orderContents = GetOrderClient(AccountManager.Client).Join(UnitOfWork.OrderContents.GetAll(),
            o=>o.Id,
            oc => oc.OrderId, (o, oc) => new { o, oc }).Select(x => x.oc).ToList();
            return orderContents;
        }
    }
}
