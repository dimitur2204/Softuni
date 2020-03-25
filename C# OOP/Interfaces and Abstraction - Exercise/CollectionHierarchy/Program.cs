using CollectionHierarchy.Interfaces;
using System;

namespace CollectionHierarchy
{
    class Program
    {
        public static void Main(string[] args)
        {
            var addCol = new AddCollection();
            var addRemCol = new AddRemoveCollection();
            var myListCol = new MyList();
            var words = Console.ReadLine().Split();
            PrintAdds(addCol, words);
            PrintAdds(addRemCol, words);
            PrintAdds(myListCol, words);
            var numberOfRemoves = int.Parse(Console.ReadLine());
            PrintRemoves(addRemCol, numberOfRemoves);
            PrintRemoves(myListCol, numberOfRemoves);
        }
        public static void PrintAdds(IAddCollection addCol,string[] words) 
        {
            foreach (var word in words)
            {
                Console.Write(addCol.Add(word) + " ");
            }
            Console.WriteLine();
        }
        public static void PrintRemoves(IAddRemoveCollection addCol, int number)
        {
            for (int i = 0; i < number; i++)
            {
                Console.Write(addCol.Remove() + " ");
            }
            Console.WriteLine();
        }
    }
}
