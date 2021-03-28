using System;
using System.Drawing;
using static System.Console;

namespace RPG
{
    public class Character
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int MaxHealth { get; protected set; }
        public string TextArt { get; protected set; }
        public ConsoleColor Color { get; protected set; }
        public Random RandomGenerator { get; protected set; }
        
        public bool IsAlive
        {
            get => Health > 0;
        }

        public bool IsDead
        {
            get => Health <= 0;
        }


        public Character(string name, int health, ConsoleColor color, string textArt)
        {
            Name = name;
            Health = health;
            MaxHealth = health;
            Color = color;
            TextArt = textArt;
            RandomGenerator = new Random();
        }

        public void DisplayInfo()
        {
            BackgroundColor = Color;
            WriteLine($"------{Name}-------");
            ResetColor();

            ForegroundColor = Color;
            WriteLine($"------\n{TextArt}\n-----");
            WriteLine($"Health: {Health}");
            WriteLine("------");
            ResetColor();
        }

        public virtual void Fight(Character otherCharacter)
        {
            WriteLine("Enemy is fighting");
        }

        public virtual void Go()
        {
            WriteLine($"Enemy is going!!!!!!!!!!!");
        }

        public void TakeDemage(int damageAmount)

        {
            Health -= damageAmount;
            if (Health < 0)
            {
                Health = 0;
            }
        }

        public void DisplayHealthBar()
        {
            WriteLine($"{Name} 's Health: ");
            ResetColor();
            Write("[");
            BackgroundColor = Color;
            // draw hit points

            for (int i = 0; i < Health; i++)
            {
                Write(" ");
            }

            // empty
            BackgroundColor = ConsoleColor.Black;
            for (int i = Health; i < MaxHealth; i++)
            {
                Write(" ");
            }


            ResetColor();
            WriteLine($"] ({Health}/{MaxHealth})");
            // WriteLine("[==========         ]");
        }
    }
}