using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_11
{
    public class OrderManager
    {
        public static decimal CalculateTotal(Order order)
        {
            return order.Price * order.Quantity; //
        }

        public static decimal CalculateTotalWithDiscount(Order order)
        {
            return (order.Price * order.Quantity) - 15.00m; //
        }

        public static decimal CalculateOrderPrice1(Order order, PriceCalculator calculator)
        {
            return calculator(order);
        }
        // --- Part 2: Built-in Func<> ---
        public static decimal CalculateOrderPrice(Order order, Func<Order, decimal> calculator)
        {
            return calculator(order);
        }
        // --- Part 3: Predicate<> Validation ---
        public static bool ValidateOrder(Order order, Predicate<Order> validationRule)
        {
            return validationRule(order);
        }
        // --- Part 4: Action<> Processing ---
        public static void ProcessOrderAction(Order order, Action<Order> action)
        {
            action(order);
        }
    }
}
