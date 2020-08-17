
using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller:IController
    {
        private readonly List<IComputer> computers = new List<IComputer>();
        private readonly List<IComponent> components = new List<IComponent>();
        private readonly List<IPeripheral> peripherals = new List<IPeripheral>();
        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(c => c.Id == id))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            if (computerType != "DesktopComputer" && computerType != "Laptop")
            {
                throw new ArgumentException("Computer type is invalid.");
            }

            if (computerType == "DesktopComputer")
            {
                var newComputer = new DesktopComputer(id,manufacturer,model,price);
                this.computers.Add(newComputer);
            }
            if (computerType == "Laptop")
            {
                var newComputer = new Laptop(id,manufacturer,model,price);
                this.computers.Add(newComputer);
            }
            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price,
            double overallPerformance, string connectionType)
        {
            CheckForComputer(computerId);
            var computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            if (this.peripherals.Any(c => c.Id == id))
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }

            if (peripheralType != "Headset" &&
                peripheralType != "Keyboard" &&
                peripheralType != "Monitor" &&
                peripheralType != "Mouse")
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }

            if (peripheralType == "Headset")
            {
                var newComp = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                this.peripherals.Add(newComp);
                computer.AddPeripheral(newComp);
            }
            if (peripheralType == "Keyboard")
            {
                var newComp = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                this.peripherals.Add(newComp);
                computer.AddPeripheral(newComp);
            }
            if (peripheralType == "Monitor")
            {
                var newComp = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                this.peripherals.Add(newComp);
                computer.AddPeripheral(newComp);
            }
            if (peripheralType == "Mouse")
            {
                var newComp = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                this.peripherals.Add(newComp);
                computer.AddPeripheral(newComp);
            }
            return
                $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            CheckForComputer(computerId);
            var computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            var comp = computer.Peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);
            computer.RemovePeripheral(peripheralType);
            peripherals.Remove(comp);
            return $"Successfully removed {peripheralType} with id {comp.Id}.";
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price,
            double overallPerformance, int generation)
        {
            CheckForComputer(computerId);
            var computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            if (this.components.Any(c => c.Id == id))
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            if (componentType != "CentralProcessingUnit" &&
                componentType != "Motherboard" &&
                componentType != "PowerSupply" &&
                componentType != "RandomAccessMemory" &&
                componentType != "SolidStateDrive" &&
                componentType != "VideoCard")
            {
                throw new ArgumentException("Component type is invalid.");
            }

            if (componentType == "CentralProcessingUnit")
            {
                var newComp = new CentralProcessingUnit(id,manufacturer,model,price,overallPerformance,generation);
                this.components.Add(newComp);
                computer.AddComponent(newComp);
            }
            if (componentType == "Motherboard")
            {
                var newComp = new Motherboard(id,manufacturer,model,price,overallPerformance,generation);
                this.components.Add(newComp);
                computer.AddComponent(newComp);
            }
            if (componentType == "PowerSupply")
            {
                var newComp = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                this.components.Add(newComp);
                computer.AddComponent(newComp);
            }
            if (componentType == "RandomAccessMemory")
            {
                var newComp = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                this.components.Add(newComp);
                computer.AddComponent(newComp);
            }
            if (componentType == "SolidStateDrive")
            {
                var newComp = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                this.components.Add(newComp);
                computer.AddComponent(newComp);
            }
            if (componentType == "VideoCard")
            {
                var newComp = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                this.components.Add(newComp);
                computer.AddComponent(newComp);
            }
            return
                $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            CheckForComputer(computerId);
            var computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            var comp = computer.Components.FirstOrDefault(c => c.GetType().Name == componentType);
            if (comp == null)
            {
                throw new ArgumentException($"Component {componentType} does not exist in {computer.GetType().Name} with Id {computer.Id}.");
            }
            computer.RemoveComponent(componentType);
            components.Remove(comp);
            return $"Successfully removed {componentType} with id {comp.Id}.";
        }

        public string BuyComputer(int id)
        {
            CheckForComputer(id);
            var computer = computers.FirstOrDefault(c => c.Id == id);
            if (computers.Remove(computer))
            {
                return computer.ToString();
            }

            return "";
        }

        public string BuyBest(decimal budget)
        {
            var possibleComputers = computers.Where(c => c.Price <= budget).ToList();
            if (possibleComputers.Count == 0)
            {
                throw new ArgumentException($"Can't buy a computer with a budget of {budget}.");
            }
            var best = possibleComputers.OrderByDescending(c => c.OverallPerformance).ToArray()[0];
            computers.Remove(best);
            return best.ToString();
        }

        public string GetComputerData(int id)
        {
            CheckForComputer(id);
            var computer = computers.FirstOrDefault(c => c.Id == id);
            return computer.ToString();
        }

        private void CheckForComputer(int id)
        {
            if (!this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
        }
    }
}
