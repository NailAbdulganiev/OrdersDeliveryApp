using OrdersDeliveryApp.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersDeliveryApp.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order?> GetOrderByIdAsync(int id);
        Task<IEnumerable<Order?>> GetOrdersAsync();
        Task AddOrderAsync(Order? order);
    }
}