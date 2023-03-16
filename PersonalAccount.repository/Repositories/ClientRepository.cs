using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.HelperModels;
using PersonalAccountMicroservice.PersonalAccount.Repository.Interfaces;
using PersonalAccountMicroservice.PersonalAccount.Repository.Entities;

namespace PersonalAccountMicroservice.PersonalAccount.Repository.Repositories
{
    public class ClientRepository : Repository<Client, Guid>, IClientRepository
    {
        public ClientRepository(DbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Client>> GetClientsPage(BaseFilter filter)
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
