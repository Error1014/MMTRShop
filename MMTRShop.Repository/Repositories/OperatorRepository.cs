using MMTRShop.Repository.Entities;
using MMTRShop.Repository.Contexts;
using MMTRShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Repository.Repositories
{
    public class OperatorRepository:Repository<Operator,Guid>, IOperatorRepository
    {
        public OperatorRepository(ShopContext context) : base(context)
        {
            
        }
    }
}
