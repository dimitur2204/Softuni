using System;

namespace StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input = Console.ReadLine();
            //string newString = "";
            //for (int i = 0; i < input.Length; i++)
            //{

            //    if (input[i] == '>')
            //    {
            //        newString += input[i];
            //        int oldExplosionStr = input[i + 1] - '0';
            //        int newExplosionStr = oldExplosionStr;
            //        for (int j = i + 1; j < i + 1 + newExplosionStr; j++)
            //        {
            //            if (input[j] == '>')
            //            {
            //                newString += input[i];

            //                newExplosionStr += input[j + 1] - '0' - 1;                            
            //            }
            //        }
            //        i += newExplosionStr;
            //    }
            //    else
            //    {
            //        newString += input[i];
            //    }

            //}
            //Console.WriteLine(newString);

            string field = Console.ReadLine();
            int bomb = 0;
            for (int i = 0; i < field.Length; i++)
            {
                if (bomb > 0 && field[i] != '>')
                {
                    field = field.Remove(i, 1); // Remove char on this index
                    bomb--; // One bomb is used
                    i--; // after remove next char is moved 1 position, so return counter i to this char, decreasing i by 1  
                }
                else if (field[i] == '>')
                {
                    bomb += int.Parse(field[i + 1].ToString()); // takes the digit after '>' - bomb strength and add to bomb
                }
            }
            Console.WriteLine(field);

        }
    }
}