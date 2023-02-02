using Microsoft.EntityFrameworkCore;
using MMTRShop.Model.Models;

namespace MMTRShopAPI
{
    public class SampleContextFactory
    {
        //public ShopContext CreateDbContext(string[] args)
        //{
        //    var optionsBuilder = new DbContextOptionsBuilder<ShopContext>();

        //    // получаем конфигурацию из файла appsettings.json
        //    ConfigurationBuilder builder = new ConfigurationBuilder();
        //    builder.SetBasePath(Directory.GetCurrentDirectory());
        //    builder.AddJsonFile("appsettings.json");
        //    IConfigurationRoot config = builder.Build();

        //    // получаем строку подключения из файла appsettings.json
        //    string connectionString = config.GetConnectionString("DefaultConnection");
        //    optionsBuilder.UseSqlServer(connectionString, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
        //    return new ShopContext(optionsBuilder.Options);
        //}
    }
}
