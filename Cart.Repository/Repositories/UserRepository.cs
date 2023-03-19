using AuthorizationMicroservice.Authorization.Repository.Entities;
using AuthorizationMicroservice.Authorization.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.HelperModels;
using Shop.Infrastructure.Repository;

namespace AuthorizationMicroservice.Authorization.Repository.Repositories
{
    public class UserRepository:Repository<User,Guid>,IUserRepository
    {
        public UserRepository(UserContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<string> GetRole(Guid userId)
        {
            return Set.Where(x=>x.Id == userId).Select(x=>x.Role.Name).FirstOrDefault();
        } 
        public async Task<IEnumerable<User>> GetUsersPage(BaseFilter filter)
        {
            var query = Set;
            query = query
                .OrderBy(x => x.Id)
                .Skip((filter.NumPage - 1) * filter.SizePage)
                .Take(filter.SizePage);
            return await query.ToListAsync();
        }

    }
}
