using Microsoft.EntityFrameworkCore;
using OrdersDeliveryApp.Domain.Models;

namespace OrdersDeliveryApp.Data.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Order> Orders { get; set; }
    }
}