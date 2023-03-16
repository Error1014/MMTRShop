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
        }


        public IClientRepository Clients { get; private set; }


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
