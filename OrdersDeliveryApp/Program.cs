using Microsoft.EntityFrameworkCore;
using OrdersDeliveryApp.Data.Data;
using OrdersDeliveryApp.Data.Repository;
using OrdersDeliveryApp.Domain.Interfaces;
using OrdersDeliveryApp.Services.Interfaces;
using OrdersDeliveryApp.Services.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Order}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
