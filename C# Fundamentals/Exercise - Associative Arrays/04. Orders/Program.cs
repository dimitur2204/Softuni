using System;
using System.Collections.Generic;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            while (command != "buy")
            {
                var commandSep = command.Split();
                var name = commandSep[0];
                var price = double.Parse(commandSep[1]);
                var quantity = int.Parse(commandSep[2]);
                if (!products.ContainsKey(name))
                {
                    Product product = new Product(quantity, price);
                    products.Add(name, product);
                }
                else
                {
                    products[name].Price = price;
                    products[name].Quantity += quantity;
                }
                command = Console.ReadLine();
            }
            foreach (var item in products)
            {
                var totalPrice = item.Value.Price * item.Value.Quantity;
                Console.WriteLine($"{item.Key} -> {totalPrice:f2}");
            }
        }
    }
}
