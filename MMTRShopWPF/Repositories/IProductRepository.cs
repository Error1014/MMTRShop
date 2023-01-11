﻿using MMTRShopWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Repositoryes
{
    public interface IProductRepository: IRepository<Product>
    {
        List<Product> GetProductsPage(int numPage, int sizePage);
    }
}