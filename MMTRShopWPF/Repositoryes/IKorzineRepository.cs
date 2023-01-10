using MMTRShopWPF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Repositoryes
{
    public interface IKorzineRepository:IRepository<Cart>
    {
        //List<Korzine> EditValueProduct(int id, int number);
        List<Cart> GetKorzineByIDUser(int id);
    }
}
