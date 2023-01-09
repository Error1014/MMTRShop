using MMTRShopWPF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Repositoryes
{
    public class KorzineRopository : Repository<Korzine>, IKorzineRepository
    {
        public KorzineRopository(ShopContext context) : base(context)
        {

        }

        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }

        

        public List<Korzine> GetKorzineByIDUser(int id)
        {
            return ShopContext.Korzine.Where(k=>k.UserID==id).ToList();
        }
    }
}
