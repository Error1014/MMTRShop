using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Interface;
using System;
using System.Linq;

namespace MMTRShopWPF.Repository.Repositories
{
    public class StatusRepository:Repository<Status,Guid>,IStatusRepository
    {
        public StatusRepository(ShopContext context) : base(context)
        {

        }

        //Продумать как это реализовать через enum
        public Status SetStatusWaitingPlaced()
        {
            return ShopContext.Status.Where(s => s.Title == "Ждёт подтверждения").First();
        }
        public Status SetStatusPlaced()
        {
            return ShopContext.Status.Where(s => s.Title == "Оформлен").First();
        }
        public Status Delivered()
        {
            return ShopContext.Status.Where(s => s.Title == "Доставлен").First();
        }

        public Status SetStatusCancelled()
        {
            return ShopContext.Status.Where(s => s.Title == "Отменён").First();
        }

        public Status SetStatusOnWay()
        {
            return ShopContext.Status.Where(s => s.Title == "В пути").First();
        }

        public Status SetStatusReceived()
        {
            return ShopContext.Status.Where(s => s.Title == "Получен").First();
        }

        public Status GetStatusByOdrer(Order order)
        {
            return ShopContext.Status.Where(s => s.Id == order.StatusId).FirstOrDefault();
        }

        
    }
}
