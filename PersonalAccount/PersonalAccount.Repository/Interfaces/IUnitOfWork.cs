using System;

namespace PersonalAccount.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IClientRepository Clients { get; }
        int Complete();
    }
}
