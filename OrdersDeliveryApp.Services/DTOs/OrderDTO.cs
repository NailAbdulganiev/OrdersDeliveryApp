using System;

namespace OrdersDeliveryApp.Services.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }

        public string OrderNumber { get; set; }

        public string SenderCity { get; set; }

        public string SenderAddress { get; set; }

        public string ReceiverCity { get; set; }

        public string ReceiverAddress { get; set; }

        public double Weight { get; set; }

        public DateTime PickupDate { get; set; }
    }
}