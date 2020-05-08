﻿using System;

using Attackers;
public abstract class AbstractHero : IAttacker
{
    private const string TARGET_NULL_MESSAGE = "Target is null.";
    private const string NO_TARGET_MESSAGE = "{0} has no target.";
    private const string TARGET_DEAD_MESSAGE = "{0} is dead.";
    private const string SET_TARGET_MESSAGE = "{0} targets {1}.";

    private string id;
    private int damage;
    private ITarget target;
    protected IHandler logger;

    public AbstractHero(string id, int damage, IHandler logger)
    {
        this.id = id;
        this.damage = damage;
        this.logger = logger;
    }

    public void Attack()
    {
        if(this.target == null)
        {
            var msg = string.Format(NO_TARGET_MESSAGE, this);
            this.logger.Handle(LogType.ATTACK, msg);
        }
        else if(this.target.IsDead)
        {
            var msg = string.Format(TARGET_DEAD_MESSAGE, this.target);
            this.logger.Handle(LogType.ATTACK,msg);
        }
        else
        {
            this.ExecuteClassSpecificAttack(this.target, this.damage);
        }
    }

    public void SetTarget(ITarget target)
    {
        if(target == null)
        {
            var msg = string.Format(TARGET_NULL_MESSAGE);
            this.logger.Handle(LogType.TARGET, msg);
        }
        else
        {
            this.target = target;

            var msg = string.Format(SET_TARGET_MESSAGE, this, target);
            this.logger.Handle(LogType.TARGET, msg);
        }
    }

    protected abstract void ExecuteClassSpecificAttack(ITarget target, int damage);

    public override string ToString()
    {
        return this.id;
    }
}