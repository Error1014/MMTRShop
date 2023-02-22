using MMTRShop.Repository.Entities;
using System;

namespace MMTRShop.Repository.Interface
{
    public interface IStatusRepository:IRepository<Status, int>
    {
        Status SetStatusWaitingPlaced();
        Status SetStatusPlaced();
        Status SetStatusOnWay();
        Status Delivered();
        Status SetStatusReceived();
        Status SetStatusCancelled();
    }
}
