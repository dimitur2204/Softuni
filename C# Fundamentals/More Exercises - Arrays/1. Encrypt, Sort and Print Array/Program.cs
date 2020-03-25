using System;
using System.Linq;
namespace _1._Encrypt__Sort_and_Print_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = new string[n];

            for (int i = 0; i < names.Length; i++)
            {
                names[i] = Console.ReadLine();
            }

            int[] encryptedNames = new int[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                int sumForEncryption = 0;
                for (int charOfName = 0; charOfName < names[i].Length; charOfName++)
                {
                    
                    if ((names[i])[charOfName] == 'A' || (names[i])[charOfName] == 'E' || (names[i])[charOfName] == 'I' || (names[i])[charOfName] == 'O' || (names[i])[charOfName] == 'U' || (names[i])[charOfName] == 'a' || (names[i])[charOfName] == 'e' || (names[i])[charOfName] == 'i' || (names[i])[charOfName] == 'o' || (names[i])[charOfName] == 'u')
                    {
                        sumForEncryption += (int)(names[i])[charOfName] * names[i].Length;
                    }
                    else
                    {
                        sumForEncryption += (int)(names[i])[charOfName] / names[i].Length;
                    }
                }
                encryptedNames[i] = sumForEncryption;
            }
            Array.Sort(encryptedNames);
            for (int i = 0; i < encryptedNames.Length; i++) 
            {
                Console.WriteLine(encryptedNames[i]);
            }
        }
    }
}
