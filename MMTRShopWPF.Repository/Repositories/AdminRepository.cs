using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Repository.Repositories
{
    public class AdminRepository:Repository<Admin,Guid>,IAdminRepository
    {
        public AdminRepository(ShopContext context) : base(context)
        {

        }
        public Admin GetAdminByUser(User user)
        {
            return ShopContext.Admin.FirstOrDefault(c=>c.UserId==user.Id);
        }
    }
}
