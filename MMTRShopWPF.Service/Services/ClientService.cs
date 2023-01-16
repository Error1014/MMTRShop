﻿using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service.Services
{
    public class ClientService:BaseService
    {
        public static Client GetClient(Order order)
        {
            return UnitOfWork.Clients.GetById(order.ClientId);
        }
    }
}
