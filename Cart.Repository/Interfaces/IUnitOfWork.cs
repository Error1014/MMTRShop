using System;

namespace AuthorizationMicroservice.Authorization.Repository.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IUserRepository Users { get; }
        IClientRepository  Clients { get; }
        IAdminRepository Admins { get; }
        IOperatorRepository Operators { get; }
        int Complete();
    }
}
