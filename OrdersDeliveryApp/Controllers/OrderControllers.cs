using Microsoft.AspNetCore.Mvc;
using OrdersDeliveryApp.Services.Interfaces;
using OrdersDeliveryApp.Services.DTOs;
using OrdersDeliveryApp.Models;

namespace OrdersDeliveryApp.Controllers
{
    public class OrderController(IOrderService orderService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var orders = await orderService.GetOrdersAsync();
                return View(orders.OrderByDescending(o => o.OrderNumber));
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { Message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderDto orderDto)
        {
            if (IsValidOrder(orderDto))
            {
                try
                {
                    var order = await orderService.CreateOrderAsync(orderDto);
                    TempData["SuccessMessage"] = $"Order created successfully. Order Number: {order.OrderNumber}";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(orderDto);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var order = await orderService.GetOrderByIdAsync(id);
                if (order == null)
                {
                    return NotFound();
                }
                return View(order);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { Message = ex.Message });
            }
        }

        private bool IsValidOrder(OrderDto orderDto)
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(orderDto.SenderCity))
            {
                ModelState.AddModelError(nameof(orderDto.SenderCity), "Sender City is required.");
                isValid = false;
            }
            
            if (string.IsNullOrEmpty(orderDto.SenderAddress))
            {
                ModelState.AddModelError(nameof(orderDto.SenderAddress), "Sender Address is required.");
                isValid = false;
            }
            
            if (string.IsNullOrEmpty(orderDto.ReceiverCity))
            {
                ModelState.AddModelError(nameof(orderDto.ReceiverCity), "Receiver City is required.");
                isValid = false;
            }
            
            if (string.IsNullOrEmpty(orderDto.ReceiverAddress))
            {
                ModelState.AddModelError(nameof(orderDto.ReceiverAddress), "Receiver Address is required.");
                isValid = false;
            }
            
            if (orderDto.Weight <= 0)
            {
                ModelState.AddModelError(nameof(orderDto.Weight), "Weight must be greater than 0.");
                isValid = false;
            }
            
            if (orderDto.PickupDate == default)
            {
                ModelState.AddModelError(nameof(orderDto.PickupDate), "Pickup Date is required.");
                isValid = false;
            }

            return isValid;
        }
    }
}
