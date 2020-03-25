using System;
using System.Collections.Generic;
using System.Text;

namespace FootballТeamGenerator
{
    class Player
    {
        private string name;
        private double endurance;
        private double sprint;
        private double dribble;
        private double passing;
        private double shooting;
        private double overall;
        public Player(string name, double endurance, double sprint, double dribble, double passing, double shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
            this.overall =
                Math.Round((this.endurance +
                this.sprint +
                this.dribble +
                this.passing +
                this.shooting) / 5);
        }
        public string Name 
        {
            get => this.name;
            private set 
            {
                if (ValidateName(value))
                {
                    this.name = value;
                }
            }
        }
        public double Endurance
        {
            get => this.endurance;
            private set 
            {
                if (ValidateStat(nameof(this.Endurance), value))
                {
                    this.endurance = value;
                }
            }
        }
        public double Sprint
        {
            get => this.sprint;
            private set
            {
                if (ValidateStat(nameof(this.Sprint), value))
                {
                    this.sprint = value;
                }
            }
        }
        public double Dribble
        {
            get => this.dribble;
            private set
            {
                if (ValidateStat(nameof(this.Dribble), value))
                {
                    this.dribble = value;
                }
            }
        }
        public double Passing
        {
            get => this.passing;
            private set
            {
                if (ValidateStat(nameof(this.Passing), value))
                {
                    this.passing = value;
                }
            }
        }
        public double Shooting
        {
            get => this.shooting;
            private set
            {
                if (ValidateStat(nameof(this.Shooting), value))
                {
                    this.shooting = value;
                }
            }
        }

        public double Overall 
        { 
            get => this.overall;
            private set 
            {
                this.overall = value;
            } 
        }
        private bool ValidateStat(string statType, double statValue) 
        {
            if (statValue < 0 || statValue > 100)
            {
                throw new ArgumentException($"{statType} should be between 0 and 100.");
            }
            return true;
        }
        private bool ValidateName(string name) 
        {
            if (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"A name should not be empty.");
            }
            return true;
        }
    }
}
