using MMTRShopWPF.Model.Models;
using System;
using System.Collections.Generic;

namespace MMTRShopWPF.Repository.Interface
{
    public interface IOrderContentRepository:IRepository<OrderContent,Guid>
    {
        List<OrderContent> GetOrderContents(Order order);
    }
}
