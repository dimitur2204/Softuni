using System;
using System.Collections.Generic;
using System.Linq;


    namespace _07._Store_Boxes
    {

class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List <Box> boxes = new List<Box>();
            while (input != "end")
            {
                string[] properties = input.Split();
                Box currentBox = new Box();
                Item currentItem = new Item();
                currentItem.Price = decimal.Parse(properties[3]);
                currentItem.Name = properties[1];
                currentBox.Item = currentItem;
                currentBox.SerialNumber = properties[0];             
                currentBox.ItemQuantity = int.Parse(properties[2]);
                
                boxes.Add(currentBox);
                input = Console.ReadLine();
            }
            //{ boxSerialNumber}
            //-- { boxItemName} – ${ boxItemPrice}: { boxItemQuantity}
            //-- ${ boxPrice} descending price
            foreach (var box in boxes.OrderByDescending(x => x.PriceForABox))
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceForABox:f2}");
            }
        }
    }
}
