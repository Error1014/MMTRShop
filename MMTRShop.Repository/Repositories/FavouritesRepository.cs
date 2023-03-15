﻿using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.HelperModels;
using MMTRShop.Repository.Entities;
using MMTRShop.Repository.Contexts;
using MMTRShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMTRShop.Repository.Repositories
{
    public class FavouritesRepository : Repository<Favourite,Guid>, IFavouritesRepository
    {
        private readonly ShopContext _shopContext;
        public FavouritesRepository(ShopContext context) : base(context)
        {
            _shopContext = context;
        }

        public async Task<IEnumerable<Favourite>> GetFavourites(Guid clientId)
        {
            return _shopContext.Favourites.Where(k => k.ClientId == clientId);
        }
        public async Task<IEnumerable<Favourite>> GetFavourites(FilterByClient filter)
        {
            var query = Set;
            if (filter.ClientId.HasValue)
            {
                query = query.Where(x => x.ClientId == filter.ClientId);
            }
            query = query
                .OrderBy(x => x.Id)
                .Skip((filter.NumPage - 1) * filter.SizePage)
                .Take(filter.SizePage);
            return await query.ToListAsync();
        }
    }
}
