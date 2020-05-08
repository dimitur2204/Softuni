
using Attackers;
public class Warrior : AbstractHero
{
    private const string ATTACK_MESSAGE = "{0} damages {1} for {2}";

    public Warrior(string id, int damage, IHandler logger) : base(id, damage, logger)
    {
    }

    protected override void ExecuteClassSpecificAttack(ITarget target, int damage)
    {
        var msg = string.Format(ATTACK_MESSAGE, this, target, damage);
        this.logger.Handle(LogType.ATTACK,msg);
    }
}
