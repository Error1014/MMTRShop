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
    public class OperatorRepository:Repository<Operator,Guid>, IOperatorRepository
    {
        private readonly DbContext _userContext;
        public OperatorRepository(DbContext context) : base(context)
        {
            _userContext = context;
        }
    }
}
