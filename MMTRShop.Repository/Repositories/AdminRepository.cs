using MMTRShop.Repository.Entities;
using MMTRShop.Repository.Contexts;
using MMTRShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MMTRShop.Repository.Repositories
{
    public class AdminRepository:Repository<Admin,Guid>,IAdminRepository
    {
        private readonly DbContext _userContext;
        public AdminRepository(DbContext context) : base(context)
        {
            _userContext = context;
        }

    }
}
