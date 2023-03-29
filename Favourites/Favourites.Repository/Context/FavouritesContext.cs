using Favourites.Repository;
using Microsoft.EntityFrameworkCore;

namespace Favourites.Repository.Context
{
    public class FavouritesContext : DbContext
    {
        public FavouritesContext(DbContextOptions<FavouritesContext> options) : base(options)
        {

        }
        public DbSet<Favourite> Favourites { get; set; }

    }
}
