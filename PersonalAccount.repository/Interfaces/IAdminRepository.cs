using PersonalAccountMicroservice.PersonalAccount.Repository.Entities;

namespace PersonalAccountMicroservice.PersonalAccount.Repository.Interfaces
{
    public interface IAdminRepository: IRepository<Admin,Guid>
    {
    }
}
