using Microsoft.EntityFrameworkCore;
using PersonalAccountMicroservice.PersonalAccount.Repository.Interfaces;

namespace PersonalAccountMicroservice.PersonalAccount.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
       

        public UnitOfWork(UserContext context)
        {
            _dbContext = context;
            Clients = new ClientRepository(context);
            Admins = new AdminRepository(context);
            Operators = new OperatorRepository(context);
        }


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
