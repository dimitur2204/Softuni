using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            var music = new Music("Drake","One Dance", 3, 500);
            var file = new File("ILoveNicki.txt", 42, 42);
            var film = new Film("TheDictator.mp4", 4242, 16000);
            var streamMusic = new StreamProgressInfo(music);
            var streamFile = new StreamProgressInfo(file);
            var streamFilm = new StreamProgressInfo(film);
            Console.WriteLine(streamMusic.CalculateCurrentPercent());
            Console.WriteLine(streamFile.CalculateCurrentPercent());
            Console.WriteLine(streamFilm.CalculateCurrentPercent());
        }
    }
}
