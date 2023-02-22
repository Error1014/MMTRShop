using MMTRShop.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Interface
{
    public interface IStatusService
    {
        Task<List<Status>> GetAll();
        Task<Status> GetStatus(Order order);
        Status GetStatusWaitingPlaced();
    }
}
