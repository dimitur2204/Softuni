using System;
using System.Collections.Generic;
using System.Dynamic;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            //"{title}, {content}, {author}"
            string input = Console.ReadLine();
            string[] inputSeparated = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string title = inputSeparated[0];
            string content = inputSeparated[1];
            string author = inputSeparated[2];
            Article newArticle = new Article(title, content, author);
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] commands = Console.ReadLine()
                    .Split(": " , StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "Edit")
                {
                    newArticle.Edit(commands[1]);
                }
                else if (commands[0] == "ChangeAuthor")
                {
                    newArticle.ChangeAuthor(commands[1]);
                }
                else
                {
                    newArticle.Rename(commands[1]);
                }
            }
            Console.WriteLine(newArticle.ToString());
        }
    }
}
