using MMTRShop.Model.Models;
using MMTRShop.Repository.Contexts;
using MMTRShop.Repository.Interface;
using System;
using System.Linq;

namespace MMTRShop.Repository.Repositories
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

        
    }
}
