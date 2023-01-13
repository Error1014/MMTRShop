using MMTRShopWPF.Model.Models;
using System;
using System.Collections.Generic;

namespace MMTRShopWPF.Repository.Interface
{
    public interface ICartRepository:IRepository<Cart>
    {
        //List<Korzine> EditValueProduct(int id, int number);
        List<Cart> GetCartByIdClient(Guid id);
    }
}
