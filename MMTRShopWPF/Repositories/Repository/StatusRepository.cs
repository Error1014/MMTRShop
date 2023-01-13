﻿using MMTRShopWPF.Model;
using MMTRShopWPF.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Repositories.Repository
{
    public class StatusRepository:Repository<Status>,IStatusRepository
    {
        public StatusRepository(ShopContext context) : base(context)
        {

        }

        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }

        //Продумать как это реализовать через enum
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