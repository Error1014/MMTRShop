using Orders.Repository.Entities;
using Shop.Infrastructure.Repository;

namespace Orders.Repository.Interfaces
{
    public interface IStatusRepository : IRepository<Status, int>
    {
        Status SetStatusWaitingPlaced();
        Status SetStatusPlaced();
        Status SetStatusOnWay();
        Status Delivered();
        Status SetStatusReceived();
        Status SetStatusCancelled();
    }
}
