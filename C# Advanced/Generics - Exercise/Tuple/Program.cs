using System;
using System.Collections.Generic;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            var personInfo = Console.ReadLine().Split();
            var personName = personInfo[0] + " " + personInfo[1];
            var personAddress = personInfo[2];
            var personAddress2 = personInfo[3];
            var personTuple = new Tuple<string,string,string>(personName,personAddress,personAddress2);
            var beerInfo = Console.ReadLine().Split();
            var beerName = beerInfo[0];
            var beerLiters = int.Parse(beerInfo[1]);
            var beerLiters1 = beerInfo[2];
            var beerTuple = new Tuple<string,int,bool>(beerName,beerLiters, beerLiters1 == "drunk" );
            var numberInfo = Console.ReadLine().Split();
            var integer = numberInfo[0];
            var doublee = double.Parse(numberInfo[1]);
            var doublee1 = numberInfo[2];
            var numberTuple = new Tuple<string, double,string>(integer,doublee,doublee1);
            Console.WriteLine(personTuple.FirstItem + " -> " + personTuple.SecondItem + " -> " + personTuple.ThirdItem);
            Console.WriteLine(beerTuple.FirstItem + " -> " + beerTuple.SecondItem + " -> " + beerTuple.ThirdItem);
            Console.WriteLine(numberTuple.FirstItem + " -> " + numberTuple.SecondItem + " -> " + numberTuple.ThirdItem);
        }
    }
}
