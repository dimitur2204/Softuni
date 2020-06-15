
namespace DateModifier
{

    using System;

    public class Startup
    {
        static void Main(string[] args)
        {
            var startDate = Console.ReadLine();
            var endDate = Console.ReadLine();
            var dateMod = new DateModifier(startDate,endDate);
            Console.WriteLine(dateMod.CalculateDifference());
        }
    }
}
