using MMTRShopWPF.Model.Models;
using System;

namespace MMTRShopWPF.Repository.Interface
{
    public interface IStatusRepository:IRepository<Status,Guid>
    {
        Status SetStatusWaitingPlaced();
        Status SetStatusPlaced();
        Status SetStatusOnWay();
        Status Delivered();
        Status SetStatusReceived();
        Status SetStatusCancelled();
    }
}
