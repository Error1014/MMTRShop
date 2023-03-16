using AuthorizationMicroservice.Authorization.Repository.Entities;
using AuthorizationMicroservice.Authorization.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.HelperModels;

namespace AuthorizationMicroservice.Authorization.Repository.Repositories
{
    public class UserRepository:Repository<User,Guid>,IUserRepository
    {
        public UserRepository(UserContext context) : base(context)
        {
            this.context = context;
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
