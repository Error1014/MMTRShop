using MMTRShop.Model.Models;
using System;
using System.Collections.Generic;

namespace MMTRShop.Repository.Interface
{
    public interface IOrderRepository: IRepository<Order,Guid>
    {
        IEnumerable<Order> GetOrdersByClientId(Guid id);
    }
}
