
namespace Truck_Tour
{
    class PetrolStation
    {
        public PetrolStation(int fuel, int distance)
        {
            this.Fuel = fuel;
            this.Distance = distance;
        }
        public int Fuel { get; set; }
        public int Distance { get; set; }
    }
}
