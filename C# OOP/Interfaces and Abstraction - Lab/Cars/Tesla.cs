using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    class Tesla
        : ICar, IElectricCar
    {
        private string model;
        private string color;
        private int batteries;
        public Tesla(string model, string color, int batteries)
        {
            this.model = model;
            this.color = color;
            this.batteries = batteries;
        }
        string ICar.Model => this.model;

        string ICar.Color => this.color;

        int IElectricCar.Battery => this.batteries;

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
        public override string ToString()
        {
            return $"{this.color} {nameof(Tesla)} {this.model} with {this.batteries} Batteries\n{Start()}\n{Stop()}";
        }
    }
}
