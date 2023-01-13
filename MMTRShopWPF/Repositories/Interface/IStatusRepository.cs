using MMTRShopWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Repositories.Interface
{
    public interface IStatusRepository:IRepository<Status>
    {
        Status SetStatusPlaced();
        Status SetStatusOnWay();
        Status Delivered();
        Status SetStatusReceived();
        Status SetStatusCancelled();
    }
}
