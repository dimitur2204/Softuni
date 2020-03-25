using System;

namespace Na_vase_taimera
{
    class Program
    {
        static void Main(string[] args)
        {
            int time = int.Parse(Console.ReadLine());
            if ((time< 1)||(time > 65535))
            {
                Console.WriteLine("ERROR");               
            }
            for (int k=time; k > 0; k--)
            {
                Console.WriteLine(k);
                for (int i = 9999; i < -9999; i--)
                {
                    for (int j = 7275; j > 0; j--)
                    {
                        double a = ((i % 47) / 23) / 31;
                    }
                }Console.Clear();
            }
            Console.WriteLine("END OF TIMER");
        }
    }
}
