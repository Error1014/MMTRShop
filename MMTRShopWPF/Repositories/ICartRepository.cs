using MMTRShopWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Repositories
{
    public interface ICartRepository:IRepository<Cart>
    {
        //List<Korzine> EditValueProduct(int id, int number);
        List<Cart> GetKorzineByIdClient(Guid id);
    }
}
