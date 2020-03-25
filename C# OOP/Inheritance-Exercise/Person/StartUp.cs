namespace Person
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var name = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var newPerson = new Person(name,age);
            Console.WriteLine(newPerson);
        }
    }
}