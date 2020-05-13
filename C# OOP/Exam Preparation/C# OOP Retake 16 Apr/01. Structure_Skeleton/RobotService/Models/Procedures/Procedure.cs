
namespace RobotService.Models.Procedures
{

    using RobotService.Models.Procedures.Contracts;
    using RobotService.Models.Robots;
    using RobotService.Models.Robots.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Procedure : IProcedure
    {
        protected List<IRobot> Robots { get; set; }
        public abstract void DoService(IRobot robot, int procedureTime);
        public Procedure()
        {
            this.Robots = new List<IRobot>();
        }
        protected bool RobotHasEnoughTime(IRobot robot, int procedureTime) 
        {
            if (robot.ProcedureTime >= procedureTime)
            {
                robot.ProcedureTime -= procedureTime;
                this.Robots.Add(robot);
                return true;
            }
            else 
            {
                throw new ArgumentException("Robot doesn't have enough procedure time");
            }
        }

        public string History()
        {
            var information = new StringBuilder();
            information.AppendLine(this.GetType().Name);
            foreach (var robot in Robots)
            {
                information.AppendLine(robot.ToString());
            }
            return information.ToString().Trim();
        }
    }
}
