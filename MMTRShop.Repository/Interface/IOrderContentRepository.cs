using MMTRShop.Model.Models;
using System;
using System.Collections.Generic;

namespace MMTRShop.Repository.Interface
{
    public interface IOrderContentRepository:IRepository<OrderContent,Guid>
    {
        Task<List<OrderContent>> GetOrderContents(Order order);

        Task<List<OrderContent>> GetCanceledOrder(Client client);
    }
}
