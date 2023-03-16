using System;

namespace PersonalAccountMicroservice.PersonalAccount.Repository.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IClientRepository  Clients { get; }
        IAdminRepository Admins { get; }
        IOperatorRepository Operators { get; }
        int Complete();
    }
}
