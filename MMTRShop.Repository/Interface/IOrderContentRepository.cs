using MMTRShop.Model.Models;
using System;
using System.Collections.Generic;

namespace MMTRShop.Repository.Interface
{
    public interface IOrderContentRepository:IRepository<OrderContent,Guid>
    {
        List<OrderContent> GetOrderContents(Order order);

        List<OrderContent> GetCanceledOrder(Client client);
    }
}
