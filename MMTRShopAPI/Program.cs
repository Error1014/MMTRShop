using Microsoft.EntityFrameworkCore;
using MMTRShop.Model.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System;
using Microsoft.Extensions.Configuration;
using MMTRShop.Service.Services;
using MMTRShop.Repository.Repositories;
using MMTRShop.Repository.Interface;
using MMTRShop.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextPool<ShopContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("MMTRShopAPI")));
builder.Services.AddDbContext<ShopContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var services = new ServiceCollection()
    .AddScoped<IUnitOfWork, UnitOfWork>()
    .AddScoped<ProductService>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
