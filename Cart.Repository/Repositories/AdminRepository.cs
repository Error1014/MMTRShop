using AuthorizationMicroservice.Authorization.Repository.Entities;
using AuthorizationMicroservice.Authorization.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationMicroservice.Authorization.Repository.Repositories
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
