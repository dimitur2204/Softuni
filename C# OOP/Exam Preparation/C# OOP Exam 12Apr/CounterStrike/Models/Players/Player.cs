
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Drawing;
using System.Net.NetworkInformation;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private IGun gun;
        public Player(string username, int health, int armor, IGun gun)
        {
            this.Username = username;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;
        }
        public string Username 
        {
            get => this.username;
            private set 
            {
                if (String.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArgumentException("Username cannot be null or empty.");
                }
                this.username = value;
            }
        }

        public int Health 
        {
            get => this.health;
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player health cannot be below or equal to 0.");
                }
                this.health = value;
            }
        }

        public int Armor 
        {
            get => this.armor;
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player armor cannot be below 0.");
                }
                this.armor = value;
            }
        }

        public bool IsAlive => this.health > 0;

        public IGun Gun 
        {
            get => this.gun;
            private set 
            {
                this.gun = value ?? throw new ArgumentException("Gun cannot be null or empty");
            }
        }

        public void TakeDamage(int points)
        {
            if (this.Armor < points)
            {
                this.Health -= points - this.armor;
                this.Armor = 0;
            }
            else if (this.Armor >= points) 
            {
                this.Armor -= points;
            }
            else
            {
                this.Health -= points;
            }
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.username}\n--Health: {this.Health}\n--Armor: {this.armor}\n--Gun: {this.gun.Name}";
        }
    }
}
