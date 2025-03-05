using OrdersDeliveryApp.Domain;
using OrdersDeliveryApp.Services.DTOs;
using OrdersDeliveryApp.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrdersDeliveryApp.Domain.Interfaces;
using OrdersDeliveryApp.Domain.Models;

namespace OrdersDeliveryApp.Services.Services
{
    public class OrderService(IOrderRepository orderRepository) : IOrderService
    {
        public async Task<OrderDto> GetOrderByIdAsync(int id)
        {
            var order = await orderRepository.GetOrderByIdAsync(id);
            return new OrderDto
            {
                Id = order.Id,
                OrderNumber = order.OrderNumber,
                SenderCity = order.SenderCity,
                SenderAddress = order.SenderAddress,
                ReceiverCity = order.ReceiverCity,
                ReceiverAddress = order.ReceiverAddress,
                Weight = order.Weight,
                PickupDate = order.PickupDate
            };
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersAsync()
        {
            var orders = await orderRepository.GetOrdersAsync();
            return orders.Select(order => new OrderDto
            {
                Id = order.Id,
                OrderNumber = order.OrderNumber,
                SenderCity = order.SenderCity,
                SenderAddress = order.SenderAddress,
                ReceiverCity = order.ReceiverCity,
                ReceiverAddress = order.ReceiverAddress,
                Weight = order.Weight,
                PickupDate = order.PickupDate
            }).ToList();
        }

        public async Task<OrderDto> CreateOrderAsync(OrderDto orderDto)
        {
            var order = new Order
            {
                OrderNumber = GenerateOrderNumber(),
                SenderCity = orderDto.SenderCity,
                SenderAddress = orderDto.SenderAddress,
                ReceiverCity = orderDto.ReceiverCity,
                ReceiverAddress = orderDto.ReceiverAddress,
                Weight = orderDto.Weight,
                PickupDate = orderDto.PickupDate.ToUniversalTime()
            };

            await orderRepository.AddOrderAsync(order);
            
            orderDto.Id = order.Id;
            orderDto.OrderNumber = order.OrderNumber;
            return orderDto;
        }

        private string GenerateOrderNumber()
        {
            var random = new Random();
            var year = DateTime.Now.Year;
            var randomNumber = random.Next(100000, 999999);
            return $"N{year}{randomNumber}";
        }
    }
}
