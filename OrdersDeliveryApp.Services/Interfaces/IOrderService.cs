using OrdersDeliveryApp.Services.DTOs;

namespace OrdersDeliveryApp.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> GetOrderByIdAsync(int id);
        Task<IEnumerable<OrderDto>> GetOrdersAsync();
        Task<OrderDto> CreateOrderAsync(OrderDto orderDto);
    }
}