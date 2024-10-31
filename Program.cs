using _03._10.AppDbContexts;
using _03._10.Models;

namespace _03._10
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                var service = new OrderService(context);

                var newOrder = new Order { OrderDate = DateTime.Now };
                newOrder.Products.Add(new Product { Name = "Product1", Price = 10.5m });
                service.AddOrder(newOrder);

                var orders = service.GetOrders();
                foreach (var order in orders)
                {
                    Console.WriteLine($"Order ID: {order.Id}, Date: {order.OrderDate}");
                    foreach (var product in order.Products)
                    {
                        Console.WriteLine($" - Product: {product.Name}, Price: {product.Price}");
                    }
                }

                service.RemoveOrder(newOrder.Id);
            }
        }
    }

}
