

namespace Attackers
{
    using System;

    using Attackers;
    public class Program
    {
        static void Main(string[] args)
        {
            IHandler combatLog = new CombatLogger();
            IHandler eventLog = new EventLogger();
            combatLog.SetSuccessor(eventLog);
            IAttacker attacker = new Warrior("Skral", 10, combatLog);
            ITarget target = new Dragon("Nozdormu", 100, 10, combatLog);
            attacker.SetTarget(target);
            attacker.Attack();
        }
    }
}
