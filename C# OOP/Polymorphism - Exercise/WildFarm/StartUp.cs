using System;
using System.Collections.Generic;
using WildFarm.Animals;
using WildFarm.Animals.Birds;
using WildFarm.Animals.Mammals;
using WildFarm.Animals.Mammals.Felines;
using WildFarm.Foods;

namespace WildFarm
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();
            var animals = new List<Animal>();
            while (command != "End")
            {
                var animalInfo = command.Split();
                var type = animalInfo[0];
                var name = animalInfo[1];
                var weight = double.Parse(animalInfo[2]);
                Animal animal = null;
                if (type == "Cat")
                {
                    var cat = new Cat(name, weight, animalInfo[3], animalInfo[4]);
                    animal = cat;
                }
                else if (type == "Tiger")
                {
                    var tiger = new Tiger(name,weight,animalInfo[3],animalInfo[4]);
                    animal = tiger;
                }
                else if (type == "Dog")
                {
                    var dog = new Dog(name, weight, animalInfo[3]);
                    animal = dog;
                }
                else if (type == "Mouse")
                {
                    var mouse = new Mouse(name, weight, animalInfo[3]);
                    animal = mouse;
                }
                else if (type == "Hen")
                {
                    var hen = new Hen(name, weight, double.Parse(animalInfo[3]));
                    animal = hen;
                }
                else if (type == "Owl")
                {
                    var cat = new Owl(name, weight, double.Parse(animalInfo[3]));
                    animal = cat;
                }
                var foodInfo = Console.ReadLine().Split();
                Console.WriteLine(animal.AskForFood()); 
                Food food = null;
                if (foodInfo[0] == "Fruit")
                {
                    var newFood = new Fruit();
                    food = newFood;
                }
                else if (foodInfo[0] == "Vegetable")
                {
                    var newFood = new Vegetable();
                    food = newFood;
                }
                else if (foodInfo[0] == "Meat")
                {
                    var newFood = new Meat();
                    food = newFood;

                }
                else if (foodInfo[0] == "Seeds")
                {
                    var newFood = new Seeds();
                    food = newFood;
                }
                animal.Eat(food, int.Parse(foodInfo[1]));
                animals.Add(animal);
                command = Console.ReadLine();
            }
            animals.ForEach(x => Console.WriteLine(x));
        }
    }
}
