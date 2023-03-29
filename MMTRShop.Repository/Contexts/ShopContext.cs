﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MMTRShop.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Repository.Contexts
{
    public class ShopContext: DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) 
        {
            
        }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<BankCard> BankCard { get; set; }

    }
}
