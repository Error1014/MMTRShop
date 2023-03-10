using MMTRShop.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Repository.Interface
{
    public interface ICartRepository : IRepository<Cart, Guid>
    {
        Task<Cart> GetCartByClient(Guid clientId);
    }
}
