
namespace RobotService.Models.Garages
{
    using System;
    using System.Collections.Generic;

    using RobotService.Models.Garages.Contracts;
    using RobotService.Models.Robots.Contracts;
    public class Garage : IGarage
    {
        private const int Capacity = 10;
        private readonly Dictionary<string,IRobot> robots;
        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();  
        }
        public IReadOnlyDictionary<string, IRobot> Robots => this.robots;

        public void Manufacture(IRobot robot)
        {
            if (robots.Count == Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }
            else if (robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException($"Robot {robot.Name} already exist");
            }
            else
            {
                this.robots.Add(robot.Name,robot);
            }
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!this.robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            else
            {
                this.robots[robotName].Owner = ownerName;
                this.robots[robotName].IsBought = true;
                this.robots.Remove(robotName);
            }
        }
    }
}
