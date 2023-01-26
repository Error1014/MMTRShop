using MMTRShop.Model.Models;
using System;

namespace MMTRShop.Repository.Interface
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
