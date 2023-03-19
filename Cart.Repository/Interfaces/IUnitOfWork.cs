using System;
using Shop.Infrastructure.Repository;

namespace AuthorizationMicroservice.Authorization.Repository.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IUserRepository Users { get; }
        int Complete();
    }
}
