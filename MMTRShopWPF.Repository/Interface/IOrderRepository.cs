using MMTRShopWPF.Model.Models;
using System;
using System.Collections.Generic;

namespace MMTRShopWPF.Repository.Interface
{
    public interface IOrderRepository: IRepository<Order,Guid>
    {
        IEnumerable<Order> GetOrdersByClientId(Guid id);
    }
}
