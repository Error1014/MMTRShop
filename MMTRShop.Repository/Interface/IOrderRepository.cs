using Shop.Infrastructure.HelperModels;
using MMTRShop.Repository.Entities;
using System;
using System.Collections.Generic;

namespace MMTRShop.Repository.Interface
{
    public interface IOrderRepository: IRepository<Order,Guid>
    {
        Task<IEnumerable<Order>> GetOrders(OrderFilter filterByClient);
    }
}
