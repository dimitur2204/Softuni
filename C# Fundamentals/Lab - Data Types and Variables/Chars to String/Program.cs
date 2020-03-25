using System;
using System.Text;

namespace Chars_to_String
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder koKoKoleda = new StringBuilder();
            char Character1 = char.Parse(Console.ReadLine());
            char Character2 = char.Parse(Console.ReadLine());
            char Character3 = char.Parse(Console.ReadLine());
            koKoKoleda.Append(Character1);
            koKoKoleda.Append(Character2);
            koKoKoleda.Append(Character3);
            Console.WriteLine(koKoKoleda);

        }
    }
}
