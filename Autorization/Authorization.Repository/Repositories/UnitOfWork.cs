using Authorization.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Authorization.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(UserContext context)
        {
            _dbContext = context;
            Users = new UserRepository(context);
        }

        public IUserRepository Users { get; private set; }

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
