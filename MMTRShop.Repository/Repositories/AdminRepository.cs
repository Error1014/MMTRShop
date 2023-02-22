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
    public class AdminRepository:Repository<Admin,Guid>,IAdminRepository
    {
        public AdminRepository(ShopContext context) : base(context)
        {

        }

    }
}
