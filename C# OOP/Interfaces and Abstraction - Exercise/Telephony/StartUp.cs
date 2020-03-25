using System;

namespace Telephony
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var phoneNumbers = Console.ReadLine()
                .Split();
            var URLs = Console.ReadLine()
                .Split();
            var stationary = new Stationary();
            var smartphone = new Smartphone();
            foreach (var phone in phoneNumbers)
            {
                if (phone.Length == 7)
                {
                    Console.WriteLine(stationary.Dial(phone)); 
                }
                else
                {
                    Console.WriteLine(smartphone.Call(phone));
                }
            }
            foreach (var URL in URLs)
            {
                Console.WriteLine(smartphone.BrowseWeb(URL));
            }
        }
    }
}
