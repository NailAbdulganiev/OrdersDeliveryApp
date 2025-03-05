using Microsoft.EntityFrameworkCore;
using OrdersDeliveryApp.Domain.Models;
using OrdersDeliveryApp.Data.Data;
using OrdersDeliveryApp.Domain.Interfaces;

namespace OrdersDeliveryApp.Data.Repository
{
    public class OrderRepository(AppDbContext context) : IOrderRepository
    {
        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            try
            {
                return await context.Orders.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving order by ID.", ex);
            }
        }

        public async Task<IEnumerable<Order?>> GetOrdersAsync()
        {
            try
            {
                return await context.Orders.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving orders.", ex);
            }
        }

        public async Task AddOrderAsync(Order? order)
        {
            try
            {
                await context.Orders.AddAsync(order);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding new order.", ex);
            }
        }

    }
}