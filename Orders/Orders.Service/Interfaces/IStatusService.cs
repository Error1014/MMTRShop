using Orders.Repository.Entities;

namespace Orders.Service.Interfaces
{
    public interface IStatusService
    {
        Task<List<Status>> GetAll();
        Task<Status> GetStatus(Order order);
        Status GetStatusWaitingPlaced();
    }
}
