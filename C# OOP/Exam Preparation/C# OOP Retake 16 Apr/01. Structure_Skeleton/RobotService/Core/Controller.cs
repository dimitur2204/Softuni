
namespace RobotService.Core
{
    using System;
    using System.Linq;

    using RobotService.Core.Contracts;
    using RobotService.Models.Garages;
    using RobotService.Models.Garages.Contracts;
    using RobotService.Models.Procedures;
    using RobotService.Models.Procedures.Contracts;
    using RobotService.Models.Robots.Contracts;

    public class Controller : IController
    {
        private readonly IGarage garage = new Garage();
        private readonly IProcedure chip = new Chip();
        private readonly IProcedure charge = new Charge();
        private readonly IProcedure polish = new Polish();
        private readonly IProcedure rest = new Rest();
        private readonly IProcedure techcheck = new TechCheck();
        private readonly IProcedure work = new Work();
        private bool RobotExistsInTheGarage(string robotName) 
        {
            if (!garage.Robots.ContainsKey(robotName)) 
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            return true;
        }
        public string Charge(string robotName, int procedureTime)
        {
            if (RobotExistsInTheGarage(robotName))
            {
                charge.DoService(this.garage.Robots[robotName], procedureTime);
                return $"{robotName} had charge procedure";
            }
            return null;
        }

        public string Chip(string robotName, int procedureTime)
        {
            if (RobotExistsInTheGarage(robotName))
            {
                chip.DoService(this.garage.Robots[robotName], procedureTime);
                return $"{robotName} had chip procedure";
            }
                return null;
        }

        public string History(string procedureType)
        {
            var procedure = this.GetType()
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == procedureType);
            if (procedure == null)
            {
                throw new ArgumentException("Ne sa kazali kakvo da pishe");
            }
            else
            {
                var procedureHistory = (IProcedure)this.GetType()
                    .GetFields()
                    .First(x => x.Name == procedureType.ToLower())
                    .GetValue(this);
                return procedureHistory.History();
            }
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            var type = this
                .GetType()
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == robotType);
            if (type == null)
            {
                throw new ArgumentException($"{robotType} type doesn't exist");
            }
            else
            {
                var robot = (IRobot)Activator.CreateInstance(type,name,energy,happiness,procedureTime);
                this.garage.Manufacture(robot);
                return $"Robot {robot.Name} registered successfully";
            }
        }

        public string Polish(string robotName, int procedureTime)
        {
            if (RobotExistsInTheGarage(robotName))
            {
                polish.DoService(this.garage.Robots[robotName], procedureTime);
                return $"{robotName} had polish procedure";
            }
            return null;
        }

        public string Rest(string robotName, int procedureTime)
        {
            if (RobotExistsInTheGarage(robotName))
            {
                rest.DoService(this.garage.Robots[robotName], procedureTime);
                return $"{robotName} had rest procedure";
            }
            return null;
        }

        public string Sell(string robotName, string ownerName)
        {
            if (RobotExistsInTheGarage(robotName))
            {
                if (this.garage.Robots[robotName].IsChipped)
                {
                    this.garage.Robots[robotName].Owner = ownerName;
                    return $"{ownerName} bought robot with chip";
                }
                else
                {
                    this.garage.Robots[robotName].Owner = ownerName;
                    return $"{ownerName} bought robot without chip";
                }
            }
            return null;
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            if (RobotExistsInTheGarage(robotName))
            {
                techcheck.DoService(this.garage.Robots[robotName], procedureTime);
                return $"{robotName} had tech check procedure";
            }
            return null;
        }

        public string Work(string robotName, int procedureTime)
        {
            if (RobotExistsInTheGarage(robotName))
            {
                work.DoService(this.garage.Robots[robotName], procedureTime);
                return $"{robotName} was working for {procedureTime} hours";
            }
            return null;
        }
    }
}
