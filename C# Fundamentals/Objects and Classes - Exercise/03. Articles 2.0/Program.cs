using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Articles_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfArticles = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();
            for (int i = 0; i < numberOfArticles; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(", ");
                string title = input[0];
                string author = input[1];
                string content = input[2];
                Article currentArticle = new Article(title, author, content);
                articles.Add(currentArticle);
            }
            string orderingCrit = Console.ReadLine();
            if (orderingCrit == "title")
            {
                foreach (var article in articles.OrderBy(x => x.Title))
                {
                    Console.WriteLine(article.ToString());
                }
            }
            else if (orderingCrit == "content")
            {
                foreach (var article in articles.OrderBy(x => x.Content))
                {
                    Console.WriteLine(article.ToString());
                }
            }
            else if (orderingCrit == "author")
            {
                foreach (var article in articles.OrderBy(x => x.Author))
                {
                    Console.WriteLine(article.ToString());
                }
            }
        }
    }
}
