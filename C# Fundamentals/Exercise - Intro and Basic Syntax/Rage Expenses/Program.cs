using System;

namespace Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
            int numberOfHeadset = 0;
            int numberOfMouse = 0;
            int numberOfKeyboard = 0;
            int numberOfDisplay = 0;
            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0)
                {
                    numberOfHeadset++;
                }
                if (i % 3 == 0)
                {
                    numberOfMouse++;
                }
                if (i % 2 == 0 && i % 3 == 0)
                {
                    numberOfKeyboard++;
                }
            }
            numberOfDisplay = numberOfKeyboard / 2;
            double expenses = (numberOfHeadset * headsetPrice) + (numberOfMouse * mousePrice) + (numberOfKeyboard * keyboardPrice) + (numberOfDisplay * displayPrice);
            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
        }
    }
}
    
