using System;

namespace Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string favouriteBook = Console.ReadLine();
            int booksChecked = 0;
            int capacity = int.Parse(Console.ReadLine());
            string book = "";

            while (capacity != 0)
            {              
                capacity--;
                book = Console.ReadLine();
                if (book == favouriteBook)
                {
                    break;
                }
                booksChecked++;
            }

            if (book == favouriteBook)
            {
                Console.WriteLine($"You checked {booksChecked} books and found it.");
            }
            else
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {booksChecked} books.");
            }
        }
    }
}
