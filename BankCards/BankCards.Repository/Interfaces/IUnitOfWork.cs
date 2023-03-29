namespace BankCards.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBankCardRepository BankCards { get; }
        int Complete();
    }
}
