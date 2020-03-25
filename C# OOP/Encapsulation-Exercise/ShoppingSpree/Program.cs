using System;
using System.Collections.Generic;
using System.Linq;
namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var personInfo = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);
                var productInfo = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);
                var people = new List<Person>();
                var products = new List<Product>();
                Person.ExtractAndAddPeople(personInfo, people);
                Product.ExtractAndAddProducts(productInfo, products);
                var command = Console.ReadLine();

                while (command != "END")
                {
                    var productToBuy = command.Split();
                    var personName = productToBuy[0];
                    var productName = productToBuy[1];
                    var person = people
                        .Find(x => x.Name == personName);
                    var product = products
                        .Find(x => x.Name == productName);
                    if (person.Money >= product.Cost)
                    {
                        Console.WriteLine($"{person.Name} bought {product.Name}");
                        person.BuyProduct(product);
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} can't afford {product.Name}");
                    }

                    command = Console.ReadLine();
                }
                foreach (var person in people)
                {
                    Console.WriteLine(person);     
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
