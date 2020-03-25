namespace _03StudentSystem
{
    using System;

    class StartUp
    {
        static void Main()
        {
            var commandParser = new Parser();
            var studentSystem = new StudentSystem();
            while (true)
            {
                var command = commandParser.Parse(Console.ReadLine());
                if (command.Name == "Create")
                {
                    var name = command.Arguments[0];
                    var age = int.Parse(command.Arguments[1]);
                    double grade = double.Parse(command.Arguments[2]);
                    studentSystem.Add(name, age, grade);
                }
                else if (command.Name == "Show")
                {
                    var name = command.Arguments[0];
                    Console.WriteLine(studentSystem.Get(name));
                }
                if (command.Name == "Exit")
                {
                    break;
                }
            }
        }
    }
}
