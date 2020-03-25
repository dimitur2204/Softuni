using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    class Seat
        : ICar
    {
        private string model;
        private string color;
        public Seat(string model, string color)
        {
            this.model = model;
            this.color = color;
        }
        string ICar.Model => this.model;

        string ICar.Color => this.color;

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
            return $"{this.color} {nameof(Seat)} {this.model}\n{Start()}\n{Stop()}";
        }
    }
}
