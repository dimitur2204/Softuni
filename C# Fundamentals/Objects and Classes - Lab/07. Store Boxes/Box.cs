using System;
using System.Collections.Generic;
using System.Text;

namespace _07._Store_Boxes
{
    class Box
    {
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public decimal PriceForABox
        => Item.Price * ItemQuantity;

    }
}
