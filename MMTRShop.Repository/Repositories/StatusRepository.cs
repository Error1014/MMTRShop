using MMTRShop.Repository.Entities;
using MMTRShop.Repository.Contexts;
using MMTRShop.Repository.Interface;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MMTRShop.Repository.Repositories
{
    public class StatusRepository:Repository<Status,int>,IStatusRepository
    {
        private readonly ShopContext _shopContext;
        public StatusRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }

        //Продумать как это реализовать через enum
        public Status SetStatusWaitingPlaced()
        {
            return _shopContext.Status.Where(s => s.Title == "Ждёт подтверждения").First();
        }
        public Status SetStatusPlaced()
        {
            return _shopContext.Status.Where(s => s.Title == "Оформлен").First();
        }
        public Status Delivered()
        {
            return _shopContext.Status.Where(s => s.Title == "Доставлен").First();
        }

        public Status SetStatusCancelled()
        {
            return _shopContext.Status.Where(s => s.Title == "Отменён").First();
        }

        public Status SetStatusOnWay()
        {
            return _shopContext.Status.Where(s => s.Title == "В пути").First();
        }

        public Status SetStatusReceived()
        {
            return _shopContext.Status.Where(s => s.Title == "Получен").First();
        }

        
    }
}
