using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service.Services
{
    public class StatusService
    {
        UnitOfWork UnitOfWork { get; set; }
        public StatusService()
        {
            UnitOfWork = new UnitOfWork(new ShopContext());
        }

        public List<Status> GetAll()
        {
            return UnitOfWork.Status.GetAll().ToList();
        }
        public Status GetStatus(Order order)
        {
            return UnitOfWork.Status.Find(s=>s.Id == order.StatusId);
        }
    }
}
