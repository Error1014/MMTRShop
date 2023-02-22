using MMTRShop.Repository.Entities;
using System;
using System.Collections.Generic;

namespace MMTRShop.Repository.Interface
{
    public interface IOrderContentRepository:IRepository<OrderContent,Guid>
    {
        Task<IEnumerable<OrderContent>> GetOrderContentsByOrderId(Guid orderId);

        Task<IEnumerable<OrderContent>> GetCanceledOrderByClientId(Guid clientId);
    }
}
