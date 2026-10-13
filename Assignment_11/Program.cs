namespace Assignment_11
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            #region Section 1
            List<Book> books = new List<Book>
            {
                new Book("1", "C#", new string[] { "Nour" }, new DateTime(2019, 3, 1), 45.99m),
                new Book("2", "API", new string[] { "Shabana" }, new DateTime(2008, 8, 1), 39.99m)
            };

            Console.WriteLine("--- 1. User-Defined Delegate ---");
            LibraryEngine.ProcessBooks1(books, BookFunctions.GetTitle);

            Console.WriteLine("\n--- 2. Built-in Func<> Delegate ---");
            LibraryEngine.ProcessBooks(books, BookFunctions.GetPrice);

            Console.WriteLine("\n--- 3. Anonymous Method (Get ISBN) ---");
            LibraryEngine.ProcessBooks(books, delegate (Book b) { return b.ISBN; });

            Console.WriteLine("\n--- 4. Lambda Expression (Get Publication Date) ---");
            LibraryEngine.ProcessBooks(books, b => b.PublicationDate.ToShortDateString());
            #endregion
            #region Section 2
            Order order = new Order { Id = 101, CustomerName = "Nour Shabana", Price = 100.00m, Quantity = 3 };

            #region Part1&2
            decimal total = OrderManager.CalculateOrderPrice1(order, OrderManager.CalculateTotal);
            decimal discounted = OrderManager.CalculateOrderPrice(order, x => x.Price * x.Quantity - 20.00m);
            Console.WriteLine($"Standard Total: {total:C} | Discounted Total: {discounted:C}");
            #endregion

            #region Part3
            bool isValidQty = OrderManager.ValidateOrder(order, o => o.Quantity > 0);
            bool isValidName = OrderManager.ValidateOrder(order, o => !string.IsNullOrEmpty(o.CustomerName));
            Console.WriteLine($"Order Validated -> Quantity > 0: {isValidQty}, Has Name: {isValidName}");
            #endregion

            # region Part4
            OrderManager.ProcessOrderAction(order, o => Console.WriteLine($"Action: Processing order for {o.CustomerName}"));
            #endregion

            #region Part 5&6
            OrderService service = new OrderService();

            Action<Order> handler1 = o => Console.WriteLine($"   [Handler 1] Printed receipt for Order #{o.Id}");
            Action<Order> handler2 = o => Console.WriteLine($"   [Handler 2] Sent confirmation SMS to {o.CustomerName}");
            Action<Order> handler3 = o => Console.WriteLine($"   [Handler 3] Logged audit trail for Order #{o.Id}");

            // Subscribe multiple handlers (Multicast)
            service.OrderProcessed += handler1;
            service.OrderProcessed += handler2;
            service.OrderProcessed += handler3;

            Console.WriteLine("\n--- Processing Order (All Handlers Active) ---");
            service.ProcessOrder(order);

            // Unsubscribe handler1
            service.OrderProcessed -= handler1;

            Console.WriteLine("\n--- Processing Order (After Unsubscribing Handler 1) ---");
            service.ProcessOrder(order);
            #endregion

            #endregion
            #region Questions 
            /*
             Q1: What is the difference between PriceCalculator and Func<Order, decimal>?
            PriceCalculator is a custom user-defined delegate explicitly declared in code.
            Func<Order, decimal> is a built-in generic delegate provided by the .NET Framework. 
            Functionally they are identical (both take an Order and return a decimal), 
            Func<> eliminates the need to declare a custom delegate type signature explicitly.   */

            /*
             * Q2)What is the difference between Action<Order> and Func<Order, decimal>?
             * Action<T> represents a method that performs an operation and returns void.
             * Func<T, TResult> represents a method that performs an operation and returns a result of type TResult.
             */

            /*
             *Q3) Why does Predicate<T> return bool, and what problem does it solve?
             * Predicate<T> always returns a bool because it is specifically engineered to represent
             * criteria evaluation or filtering rules (e.g., checking if an item meets a condition).
             */

            /*
             Q4: What is the difference between a delegate and an event?
                A delegate is a type that holds references to methods and can be invoked or reassigned directly from anywhere.
                An event is a wrapper around a delegate that restricts external classes. External classes can only add (+=) or remove (-=) subscriber methods; they cannot clear the list or invoke the event directly.
             */

            /*
             * Q5: Why can't external code normally invoke an event declared in another class?
             * To enforce encapsulation and prevent external classes from triggering side-effects or disrupting publisher workflows.
             * Only the containing class where the event is defined has permission to trigger (Invoke) it.
             */


            #endregion
        }
    }
}
