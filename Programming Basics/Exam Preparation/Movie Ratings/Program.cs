using System;

namespace Movie_Ratings
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfFilms = int.Parse(Console.ReadLine());
            double highestRating = double.MinValue;
            double lowestRating = double.MaxValue;
            string highestRatingName = "";
            string lowestRatingName = "";
            double sumOfRatings = 0;
            for (int filmNumber = 0; filmNumber < numberOfFilms; filmNumber++)
            {
                string nameOfFilm = Console.ReadLine();
                double filmRating = double.Parse(Console.ReadLine());

                    if (filmRating >= highestRating)
                    {
                        highestRatingName = nameOfFilm;
                        highestRating = filmRating;
                    }
                    if (filmRating <= lowestRating)
                    {
                        lowestRatingName = nameOfFilm;
                        lowestRating = filmRating;
                    }                
                sumOfRatings = sumOfRatings + filmRating;               
            }
            double averageRating = sumOfRatings / numberOfFilms;
            Console.WriteLine($"{highestRatingName} is with highest rating: {highestRating:f1}");
            Console.WriteLine($"{lowestRatingName} is with lowest rating: {lowestRating:f1}");
            Console.WriteLine($"Average rating: {averageRating:f1}");
        }
    }
}
