using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerHand = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondPlayerHand = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            while (firstPlayerHand.Count != 0 && secondPlayerHand.Count != 0)
            {
                if (firstPlayerHand[0] > secondPlayerHand[0])
                {
                   firstPlayerHand = PlayerWin(firstPlayerHand[0], secondPlayerHand[0], firstPlayerHand);
                   secondPlayerHand = PlayerLose(secondPlayerHand);
                }
                else if (firstPlayerHand[0] < secondPlayerHand[0])
                {
                   secondPlayerHand = PlayerWin(secondPlayerHand[0] ,firstPlayerHand[0], secondPlayerHand);
                   firstPlayerHand = PlayerLose(firstPlayerHand);
                }
                else
                {
                    firstPlayerHand = PlayerLose(firstPlayerHand);
                    secondPlayerHand = PlayerLose(secondPlayerHand);
                }

            }

            if (firstPlayerHand.Count > 0)
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayerHand.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {secondPlayerHand.Sum()}");
            }

        }
        static List<int> PlayerWin(int winningPlayerCard, int losingPlayerCard, List<int> winningPlayerHand) 
        {
            winningPlayerHand.Add(winningPlayerCard);
            winningPlayerHand.Add(losingPlayerCard);
            winningPlayerHand.RemoveAt(0);
            return winningPlayerHand;
        }

        static List<int> PlayerLose(List<int> losingPlayerHand)
        {
            losingPlayerHand.RemoveAt(0);
            return losingPlayerHand;
        }


    }
}
