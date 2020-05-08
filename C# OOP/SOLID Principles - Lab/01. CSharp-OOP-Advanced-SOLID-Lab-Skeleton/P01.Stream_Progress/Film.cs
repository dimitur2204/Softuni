namespace P01.Stream_Progress
{
    public class Film : IStreamable
    {
        private int length;
        private int bytes;
        private string name;
        public Film(string name, int length, int bytes)
        {
            this.name = name;
            this.bytes = bytes;
            this.length = length;
        }
        public int Length => this.length;

        public int BytesSent => this.bytes;
    }
}