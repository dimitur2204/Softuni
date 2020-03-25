using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    class Dough
    {
        private const double defaultCal = 2;
        private const double whiteCal = 1.5;
        private const double wholegrainCal = 1.0;
        private const double crispyCal = 0.9;
        private const double chewyCal = 1.1;
        private const double homemadeCal = 1.0;

        private string type;
        private string bakingTechnique;
        private double weight;

        public Dough(string type, string bakingTechnique, double weight)
        {
            this.Type = type;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string Type
        {
            get => this.type;
            private set 
            {
                if (ValidateDoughType(value))
                {
                    this.type = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set 
            {
                if (ValidateDoughTechnique(value))
                {
                    this.bakingTechnique = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        public double Weight 
        {
            get => this.weight;
            private set 
            {
                if (value >= 1 && value <= 200)
                {
                    this.weight = value;
                }
                else
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
            }
        }
        public double GetCalories()
        {
            if (this.Type.ToLower() == "white")
            {
                if (this.BakingTechnique.ToLower() == "chewy")
                {
                    return defaultCal * this.weight * whiteCal * chewyCal;
                }
                else if (this.BakingTechnique.ToLower() == "crispy")
                {
                    return defaultCal * this.weight * whiteCal * crispyCal;
                }
                else
                {
                    return defaultCal * this.weight * whiteCal * homemadeCal;
                }
            }
            else
            {
                if (this.BakingTechnique.ToLower() == "chewy")
                {
                    return defaultCal * this.weight * wholegrainCal * chewyCal;
                }
                else if (this.BakingTechnique.ToLower() == "crispy")
                {
                    return defaultCal * this.weight * wholegrainCal * crispyCal;
                }
                else
                {
                    return defaultCal * this.weight * wholegrainCal * homemadeCal;
                }
            }
        }
        private bool ValidateDoughType(string type) 
        {
            var types = new List<string> 
            {
                "white",
                "wholegrain" 
            };
            if (types.Contains(type.ToLower()))
            {
                return true;
            }
            return false;
        }
        private bool ValidateDoughTechnique(string type)
        {
            var types = new List<string>
            {
                "crispy",
                "chewy",
                "homemade"
            };
            if (types.Contains(type.ToLower()))
            {
                return true;
            }
            return false;
        }
    }
}
