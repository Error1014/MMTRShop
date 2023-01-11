﻿using MMTRShopWPF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service
{
    public class Brand : BaseEntity<Guid>
    {
        public string Name { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
