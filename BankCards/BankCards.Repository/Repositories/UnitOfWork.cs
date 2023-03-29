using BankCards.Repository.Context;
using BankCards.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankCards.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        public UnitOfWork(BankCardContext context)
        {
            _dbContext = context;
            BankCards = new BankCardRepository(context);
        }

        public IBankCardRepository BankCards { get; private set; }

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
