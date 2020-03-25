using System;

namespace Calories_Diary
{
    class Program
    {
        static void Main(string[] args)
        {
            int dailyCalories = int.Parse(Console.ReadLine());
            int numberOfActivities = int.Parse(Console.ReadLine());
            int caloriesBalance = 0;
            for (int activityNumber = 0; activityNumber < numberOfActivities; activityNumber++)
            {
                string typeOfActivity = Console.ReadLine();
                int calories = int.Parse(Console.ReadLine());
                if (typeOfActivity == "eat")
                {
                    caloriesBalance = caloriesBalance + calories;
                }
                else
                {
                    caloriesBalance = caloriesBalance - calories;
                    if (caloriesBalance < 0)
                    {
                        caloriesBalance = 0;
                    }
                }
                if (caloriesBalance > dailyCalories)
                {
                    Console.WriteLine("Oh no, it seems you ate too much...");
                    Console.WriteLine($"Overdose: {(caloriesBalance - dailyCalories)}");
                    return;
                }
            }
            Console.WriteLine("Nice job! Today was a heathy day!");
            Console.WriteLine($"Calories to the limit: {dailyCalories - caloriesBalance}");
        }
    }
}
