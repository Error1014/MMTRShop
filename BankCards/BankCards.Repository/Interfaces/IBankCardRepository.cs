using Shop.Infrastructure.Repository;
using System;

namespace BankCards.Repository.Interfaces
{
    public interface IBankCardRepository : IRepository<BankCard, Guid>
    {
    }
}
