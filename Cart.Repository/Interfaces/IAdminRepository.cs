using AuthorizationMicroservice.Authorization.Repository.Entities;
namespace AuthorizationMicroservice.Authorization.Repository.Interfaces
{
    public interface IAdminRepository: IRepository<Admin,Guid>
    {
    }
}
