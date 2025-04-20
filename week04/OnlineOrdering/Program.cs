using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            Address address1 = new Address("123 Main St", "New York", "NY", "USA");
            Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");

            Customer customer1 = new Customer("John Doe", address1);
            Customer customer2 = new Customer("Jane Smith", address2);

            Order order1 = new Order(customer1);
            order1.AddProduct(new Product("Laptop", "L123", 999.99, 1));
            order1.AddProduct(new Product("Mouse", "M456", 25.50, 2));

            Order order2 = new Order(customer2);
            order2.AddProduct(new Product("Phone", "P789", 799.99, 1));
            order2.AddProduct(new Product("Charger", "C012", 19.99, 3));

            List<Order> orders = new List<Order> { order1, order2 };

            foreach (var order in orders)
            {
                Console.WriteLine(order.GetPackingLabel());
                Console.WriteLine(order.GetShippingLabel());
                Console.WriteLine($"Total Cost: ${order.GetTotalCost():F2}\n");
            }
        }
    }
}
