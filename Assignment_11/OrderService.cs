using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_11
{
    public class OrderService
    {
        // Event based on Action<Order>
        public event Action<Order> OrderProcessed;

        public void ProcessOrder(Order order)
        {
            Console.WriteLine($"[Service] Order #{order.Id} execution started.");
            // Raise the event securely
            OrderProcessed?.Invoke(order);
        }
    }
}
