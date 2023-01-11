﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Model
{
    public class Favourites:BaseEntity<Guid>
    {
        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}