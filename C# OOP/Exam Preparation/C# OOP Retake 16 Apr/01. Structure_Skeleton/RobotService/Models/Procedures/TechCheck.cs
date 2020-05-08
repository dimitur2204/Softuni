
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class TechCheck : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            if (RobotHasEnoughTime(robot,procedureTime))
            {
                if (robot.IsChecked)
                {
                    robot.Energy -= 8;
                }
                else
                {
                    robot.IsChecked = true;
                    robot.Energy -= 8;
                }
            }
        }
    }
}
