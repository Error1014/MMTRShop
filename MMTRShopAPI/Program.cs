using Microsoft.EntityFrameworkCore;
using MMTRShop.Model.Models;
using MMTRShop.Service.Services;
using MMTRShop.Repository.Repositories;
using MMTRShop.Repository.Interface;
using MMTRShop.Service.Interface;
using MMTRShopAPI;
using MMTRShop.MiddlewareException;
using MMTRShop.Repository.Contexts;
using MMTRShop.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Необходимо для создания мигаций
builder.Services.AddDbContext<ShopContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services
    .AddScoped<IUnitOfWork, UnitOfWork>()
    .AddScoped<IProductService, ProductService>()
    .AddScoped<IUserService, UserService>()
    .AddScoped<IBankCardService, BankCardService>()
    .AddScoped<IBrandService, BrandService>()
    .AddScoped<ICartService, CartService>()
    .AddScoped<ICategoryServise, CategoryService>()
    .AddScoped<IClientService, ClientService>()
    .AddScoped<IFavouriteService, FavouriteService>()
    .AddScoped<IFeedbackService, FeedbackService>()
    .AddScoped<IOrderService, OrderService>()
    .AddScoped<IOrderContentService, OrderContentService>()
    .AddScoped<IStatusService, StatusService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStatusCodePages();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<ExceptionMiddleware>();
app.Run();

