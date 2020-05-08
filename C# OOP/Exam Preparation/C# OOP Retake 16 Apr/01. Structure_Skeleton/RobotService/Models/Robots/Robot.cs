
namespace RobotService.Models.Robots
{
    using RobotService.Models.Robots.Contracts;
    using System;

    public abstract class Robot : IRobot
    {
        private readonly string name;
        private int happiness;
        private int energy;
        private int procedureTime;
        private string owner = "Service";
        private bool isBought = false;
        private bool isChipped = false;
        private bool isChecked = false;
        public Robot(string name, int energy, int happiness, int procedureTime)
        {
            this.name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
        }

        public string Name => this.name;

        public int Happiness 
        {
            get => this.happiness;
            set 
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }
                this.happiness = value;
            }
        }
        public int Energy 
        {
            get => this.energy;
            set 
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }
                this.energy = value;
            } 
        }
        public int ProcedureTime
        {
            get => this.procedureTime; 
            set => this.procedureTime = value; 
        }
        public string Owner 
        {
            get => this.owner; 
            set => this.owner = value; 
        }
        public bool IsBought 
        {
            get => this.isBought; 
            set => this.isBought = value; 
        }
        public bool IsChipped 
        {
            get => this.isChipped;
            set => this.isChipped = value;
        }
        public bool IsChecked 
        {
            get => this.isChecked;
            set => this.isChecked = value;
        }
        public override string ToString()
        {
            return $" Robot type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
