
using System.Collections.Generic;
using System.Linq;

namespace InterfaceExample
{
    class Program
    {
        static void Main(string[] args)
        {
            IItem item1 = new Fruit("Apple",12,12);
            IItem item2 = new Vegetable(12, "Cucumber",12);
            var items = new List<IItem>();
            items.Add(item1);
            items.Add(item2);
            var fruits = items.Where(item => item is Fruit);
        }
    }
}
