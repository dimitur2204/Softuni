using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var pizzaName = Console.ReadLine().Split()[1];
                var pizza = new Pizza(pizzaName);
                var doughInfo = Console.ReadLine().Split();
                var dough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));
                var command = Console.ReadLine();
                var toppings = new List<Topping>();
                while (command != "END")
                {
                    var toppingInfo = command.Split();
                    var topping = new Topping(toppingInfo[1], double.Parse(toppingInfo[2]));
                    toppings.Add(topping);
                    command = Console.ReadLine();
                }
                pizza.Dough = dough;
                pizza.Toppings = toppings;
                Console.WriteLine($"{pizza.Name} - {pizza.GetCalories():f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
