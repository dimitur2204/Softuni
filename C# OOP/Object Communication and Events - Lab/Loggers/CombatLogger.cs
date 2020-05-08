
namespace Attackers
{
    using System;
    public class CombatLogger : Logger
    {
        public override void Handle(LogType logType, string msg)
        {
            if (logType == LogType.ATTACK || logType == LogType.MAGIC)
            {
                Console.WriteLine(logType.ToString() + ":" + msg);
            }
            else
            {
                this.PassToSuccessor(logType,msg);
            }
        }
    }
}
