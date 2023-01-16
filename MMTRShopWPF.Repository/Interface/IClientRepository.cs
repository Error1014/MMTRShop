using MMTRShopWPF.Model.Models;
using System;

namespace MMTRShopWPF.Repository.Interface
{
    public interface IClientRepository: IRepository<Client,Guid>
    {
        Client GetClientByUserId(Guid id);
    }
}
