using System;
namespace CreatingCustomStrucutres
{
    class Program
    {
        static void Main(string[] args)
        {
            var doubly = new DoublyLinkedList();
            doubly.AddFirst(5);//5
            doubly.AddLast(4);//5,4
            doubly.AddFirst(4);//4,5,4
            doubly.AddFirst(2);//2,4,5,4
            doubly.AddFirst(3);//3,2,4,5,4
            doubly.ForEach(Console.WriteLine);
            doubly.ForEach(Console.WriteLine);
            var arr = doubly.ToArray();
            doubly.ForEach(Console.WriteLine);
        }
    }
}
