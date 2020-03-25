using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Songs
{
    class Song
    {
        //Type List, Name and Time
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }    
        public void Print() 
        {
            Console.WriteLine(this);
        }
    }
}
