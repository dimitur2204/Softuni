 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var fields = typeof(HarvestingFields).GetFields(
                BindingFlags.NonPublic | 
                BindingFlags.Public | 
                BindingFlags.Instance | 
                BindingFlags.Static);
            string command = Console.ReadLine();
            while (command != "HARVEST")
            {
                if (command == "private")
                {
                    foreach (var field in fields.Where(x => x.IsPrivate))
                    {
                        Console.WriteLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                    }
                }
                else if (command == "protected")
                {
                    foreach (var field in fields.Where(x => !x.IsPrivate && !x.IsPublic))
                    {
                        Console.WriteLine($"protected {field.FieldType.Name} {field.Name}");
                    }
                }
                else if (command == "public")
                {
                    foreach (var field in fields.Where(x => x.IsPublic))
                    {
                        Console.WriteLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                    }
                }
                else 
                {
                    foreach (var field in fields.Where(x => x.IsPrivate))
                    {
                        Console.WriteLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                    }
                    foreach (var field in fields.Where(x => !x.IsPrivate && !x.IsPublic))
                    {
                        Console.WriteLine($"protected {field.FieldType.Name} {field.Name}");
                    }
                    foreach (var field in fields.Where(x => x.IsPublic))
                    {
                        Console.WriteLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                    }
                }
                command = Console.ReadLine();
            }
        }
    }
}
