using System;

namespace Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPayments = int.Parse(Console.ReadLine());
            double totalBalance = 0.00;
            double payment;
            while (numberOfPayments != 0)
            {
              
                payment = double.Parse(Console.ReadLine());  
                if (payment > 0)
                {
                totalBalance += payment;
                Console.WriteLine($"Increase: {payment:f2}");
                numberOfPayments--;
                }
                else 
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                
            }
            Console.WriteLine($"Total: {totalBalance:f2}");
        }
    }
}
