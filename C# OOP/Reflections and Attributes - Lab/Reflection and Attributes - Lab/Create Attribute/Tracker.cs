using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


[Author("Mitkatawe")]
public class Tracker
{
    public static void PrintMethodsByAuthor()
    {
        var type = typeof(StartUp);
        var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
        foreach (var method in methods)
        {
            if (method.CustomAttributes.Any(x => x.AttributeType == typeof(AuthorAttribute)))
            {
                var attributes = method.GetCustomAttributes(false);
                foreach (AuthorAttribute atrribute in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {atrribute.Name}");
                }
            }
        }
    }
    public static void PrintClassesByAuthor()
    {
        var classes = Assembly.GetExecutingAssembly().DefinedTypes;
        foreach (var myClass in classes)
        {
            if (myClass.CustomAttributes.Any(x => x.AttributeType == typeof(AuthorAttribute)))
            {
                var atrributes = myClass.GetCustomAttributes(false);
                foreach (AuthorAttribute attribute in atrributes)
                {
                    Console.WriteLine($"{myClass.Name} is written by {attribute.Name}");
                }
            }
        }
    }

}
