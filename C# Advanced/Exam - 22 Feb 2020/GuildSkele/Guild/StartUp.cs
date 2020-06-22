using System;

namespace Guild
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var guild = new Guild("ABV",2);
            guild.AddPlayer(new Player("someone","rogue"));
            guild.AddPlayer(new Player("otherone", "rogue"));
            guild.PromotePlayer("someone");
            guild.DemotePlayer("someone");
            Console.WriteLine(guild.Count);

        }
    }
}
