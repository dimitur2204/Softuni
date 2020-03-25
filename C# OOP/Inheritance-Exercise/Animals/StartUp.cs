namespace Animals
{
    using System;
    using System.Linq;
    using Cats;
    using Dogs;
    using Frogs;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var command = Console.ReadLine();
            while (command!="Beast!")
            {
                try
                {
                    var typeOfAnimal = command;
                    var animalInfo = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    var animalName = animalInfo[0];
                    int animalAge;
                    if (!int.TryParse(animalInfo[1], out animalAge))
                    {
                        throw new ArgumentException("Invalid input!");
                    }
                    var gender = animalInfo[2];

                    switch (typeOfAnimal)
                    {
                        case "Dog":
                            Dog dog = new Dog(animalName, animalAge, gender);
                            Console.WriteLine("Dog");
                            Console.WriteLine(dog.ProduceSound());
                            break;
                        case "Cat":
                            Cat cat = new Cat(animalName, animalAge, gender);
                            Console.WriteLine("Cat");
                            Console.WriteLine(cat.ProduceSound());
                            break;
                        case "Frog":
                            Frog frog = new Frog(animalName, animalAge, gender);
                            Console.WriteLine("Frog");
                            Console.WriteLine(frog.ProduceSound());
                            break;
                        case "Kitten":
                            Kitten kitten = new Kitten(animalName, animalAge);
                            Console.WriteLine("Kitten");
                            Console.WriteLine(kitten.ProduceSound());
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(animalName, animalAge);
                            Console.WriteLine("Tomcat");
                            Console.WriteLine(tomcat.ProduceSound());
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                command = Console.ReadLine();
                }
            }
        }
    }
