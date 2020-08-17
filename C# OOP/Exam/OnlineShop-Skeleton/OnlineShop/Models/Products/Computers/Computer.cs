
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product,IComputer
    {
        private double _overallPerformance;
        private decimal _price;
        private readonly List<IComponent> _components;
        private readonly List<IPeripheral> _peripherals;
        public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
            this._components = new List<IComponent>();
            this._peripherals = new List<IPeripheral>();
            this.OverallPerformance = overallPerformance;
            this.Price = price;
        }

        public override double OverallPerformance
        {
            get
            {
                if (!this.Components.Any())
                {
                    return this._overallPerformance;
                }

                return this._overallPerformance + this.Components.Average(c => c.OverallPerformance);
            }
            private protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Overall Performance can not be less or equal than 0.");
                }

                this._overallPerformance = value;
            }
        }
        public override decimal Price
        {
            get
            {
                return this._price 
                       + this.Components.Sum(c => c.Price) 
                       + this.Peripherals.Sum(p => p.Price);
            }
            private protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price can not be less or equal than 0.");
                }

                this._price = value;
            }
        }

        public IReadOnlyCollection<IComponent> Components => this._components.AsReadOnly();
        public IReadOnlyCollection<IPeripheral> Peripherals => this._peripherals.AsReadOnly();
        public void AddComponent(IComponent component)
        {
            var componentt = this.Components.FirstOrDefault(c => c.GetType().Name == component.GetType().Name);
            if (componentt == null)
            {
                this._components.Add(component);
                return;
            }
            throw new ArgumentException($"Component {componentt.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
        }

        public IComponent RemoveComponent(string componentType)
        {
            var componentt = this.Components.FirstOrDefault(c => c.GetType().Name == componentType);
            if (this.Components.Any() || componentt != null)
            {
                this._components.Remove(componentt);
                return componentt;
            }
            throw new ArgumentException($"Component {componentType} does not exist in {this.GetType().Name} with Id {this.Id}.");
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            var peripherall = this.Peripherals.FirstOrDefault(c => c.GetType().Name == peripheral.GetType().Name);
            if (peripherall == null)
            {
                this._peripherals.Add(peripheral);
                return;
            }
            throw new ArgumentException($"Peripheral {peripherall.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var peripherall = this.Peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);
            if (this.Peripherals.Any() || peripherall != null)
            {
                this._peripherals.Remove(peripherall);
                return peripherall;
            }
            throw new ArgumentException($"Peripheral {peripheralType} does not exist in {this.GetType().Name} with Id {this.Id}.");
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine();
            sb.AppendLine($" Components ({this.Components.Count}):");
            foreach (var component in Components)
            {
                sb.AppendLine("  " + component);
            }

            if (this.Peripherals.Count > 0)
            {
                sb.AppendLine(
                    $" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({this.Peripherals.Average(p => p.OverallPerformance):f2}):");
            }
            else
            {
                sb.AppendLine(
                    $" Peripherals ({this.Peripherals.Count}); Average Overall Performance (0.00):");
            }
           
            foreach (var peripheral in Peripherals)
            {
                sb.AppendLine("  " + peripheral);
            }

            return sb.ToString().Trim();
        }
    }
}
