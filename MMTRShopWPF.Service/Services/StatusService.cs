using MMTRShopWPF.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service.Services
{
    public class StatusService:BaseService
    {
        public static List<Status> GetAllStatus()
        {
            return UnitOfWork.Status.GetAll().ToList();
        }

        public static Status GetStatus(Order order)
        {
            return UnitOfWork.Status.GetStatusByOdrer(order);
        }
    }
}
