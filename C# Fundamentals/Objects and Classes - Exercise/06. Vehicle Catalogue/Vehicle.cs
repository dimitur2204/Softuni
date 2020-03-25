using System;
using System.Collections.Generic;
using System.Text;

namespace _06._Vehicle_Catalogue
{
    class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsepower)
        {
            Type = type;
            Model = model;
            Color = color;
            Horsepower = horsepower;
        }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }
            //Type: {typeOfVehicle}
            //Model: {modelOfVehicle}
            //Color: {colorOfVehicle}
            //Horsepower: {horsepowerOfVehicle}

        public override string ToString()
        {
            string output = "";
            if (this.Type == "car")
            {
                output = $"Type: Car\nModel: {this.Model}\nColor: {this.Color}\nHorsepower: {this.Horsepower}";
            }
            else
            {
                output = $"Type: Truck\nModel: {this.Model}\nColor: {this.Color}\nHorsepower: {this.Horsepower}";
            }
            
            return output;
        }
    }
}
