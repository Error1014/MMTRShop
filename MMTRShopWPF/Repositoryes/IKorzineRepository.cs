using MMTRShopWPF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Repositoryes
{
    public interface IKorzineRepository:IRepository<Korzine>
    {
        //List<Korzine> EditValueProduct(int id, int number);
        List<Korzine> GetKorzineByIDUser(int id);
    }
}
