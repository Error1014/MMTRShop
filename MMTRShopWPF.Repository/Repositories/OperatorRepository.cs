using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Repository.Repositories
{
    public class OperatorRepository:Repository<Operator>, IOperatorRepository
    {
        public OperatorRepository(ShopContext context) : base(context)
        {
            
        }

        public Operator GetOperatorByUserId(Guid id)
        {
            return ShopContext.Operator.Where(c => c.UserId == id).FirstOrDefault();
        }
    }
}
