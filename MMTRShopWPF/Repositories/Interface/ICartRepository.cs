using MMTRShopWPF.Model;
using System;
using System.Collections.Generic;

namespace MMTRShopWPF.Repositories.Interface
{
    public interface ICartRepository:IRepository<Cart>
    {
        //List<Korzine> EditValueProduct(int id, int number);
        List<Cart> GetKorzineByIdClient(Guid id);
    }
}
