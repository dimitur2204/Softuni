namespace CarSalesman
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = -1;
            this.Efficiency = "n/a";
        }
        public string Model { get; }
        public int Power { get; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }
        public override string ToString()
        {
            if (this.Displacement == - 1)
            {
                return $"{this.Model}:\n    Power: {this.Power}\n    Displacement: n/a\n    Efficiency: {this.Efficiency}";
            }
            return $"{this.Model}:\n    Power: {this.Power}\n    Displacement: {this.Displacement}\n    Efficiency: {this.Efficiency}";
        }
    }
}