﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.HelperModels
{
    public class FilterByClient:BaseFilter
    {
        public Guid? ClientId { get; set; }
        public FilterByClient()
        {

        }
        public FilterByClient(BaseFilter filter, Guid clientId)
        {
            ClientId = clientId;
            NumPage = filter.NumPage;
            SizePage = filter.SizePage;
        }
    }
}
