using BankCards.Repository.Context;
using BankCards.Repository.Interfaces;
using Shop.Infrastructure.Repository;

namespace BankCards.Repository.Repositories
{
    public class BankCardRepository : Repository<BankCard, Guid>, IBankCardRepository
    {
        public BankCardRepository(BankCardContext context) : base(context)
        {

        }
    }
}
