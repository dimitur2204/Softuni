﻿using System;

using Attackers;
public class Dragon : ITarget
{
    private const string THIS_DIED_EVENT = "{0} dies";

    private string id;
    private int hp;
    private int reward;
    private bool eventTriggered;
    private IHandler logger;
    public Dragon(string id, int hp, int reward, IHandler logger)
    {
        this.id = id;
        this.hp = hp;
        this.reward = reward;
        this.logger = logger;
    }

    public bool IsDead { get => this.hp <= 0; }

    public void ReceiveDamage(int damage)
    {
        if (!this.IsDead)
        {
            this.hp -= damage;
        }

        if(this.IsDead && !eventTriggered)
        {
            var msg = string.Format(THIS_DIED_EVENT, this);
            this.logger.Handle(LogType.EVENT, msg);
            this.eventTriggered = true;
        }
    }

    public override string ToString()
    {
        return this.id;
    }
}