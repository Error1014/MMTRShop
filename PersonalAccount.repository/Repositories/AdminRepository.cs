using Microsoft.EntityFrameworkCore;
using PersonalAccountMicroservice.PersonalAccount.Repository.Entities;
using PersonalAccountMicroservice.PersonalAccount.Repository.Interfaces;

namespace PersonalAccountMicroservice.PersonalAccount.Repository.Repositories
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
