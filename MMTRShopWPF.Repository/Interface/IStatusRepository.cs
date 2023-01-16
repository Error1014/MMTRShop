using MMTRShopWPF.Model.Models;

namespace MMTRShopWPF.Repository.Interface
{
    public interface IStatusRepository:IRepository<Status>
    {
        Status SetStatusWaitingPlaced();
        Status SetStatusPlaced();
        Status SetStatusOnWay();
        Status Delivered();
        Status SetStatusReceived();
        Status SetStatusCancelled();
        Status GetStatusByOdrer(Order order);
    }
}
