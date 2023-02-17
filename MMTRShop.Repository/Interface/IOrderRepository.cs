using MMTRShop.Model.HelperModels;
using MMTRShop.Model.Models;
using System;
using System.Collections.Generic;

namespace MMTRShop.Repository.Interface
{
    public interface IOrderRepository: IRepository<Order,Guid>
    {
        Task<IEnumerable<Order>> GetOrders(OrderFilter filterByClient);
    }
}
