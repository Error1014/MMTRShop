using AuthorizationMicroservice.Authorization.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationMicroservice.Authorization.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(UserContext context)
        {
            _dbContext = context;
            Users = new UserRepository(context);
            Clients = new ClientRepository(context);
            Admins = new AdminRepository(context);
            Operators = new OperatorRepository(context);
        }

        public IUserRepository Users { get; private set; }

        public IClientRepository Clients { get; private set; }

        public IAdminRepository Admins { get; private set; }
        public IOperatorRepository Operators { get; private set; }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
