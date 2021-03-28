using System;
using System.Drawing;
using static System.Console;

namespace RPG
{
    public class Ant : Character
    {
        private double ChargeDistance;
        private Item CurrentItem;
        private Item NewItem;

        public Ant(string name, int health, ConsoleColor color, int chargeDistance)
            : base(name, health, color, Art.Ant)
        {
            ChargeDistance = chargeDistance;
        }

        public void PickUpItem(Item item)
        {
            CurrentItem = item;
        }

        public void Fetch(Item item)
        {
            NewItem = item;

            if (NewItem != null)
            {
                WriteLine($"I fetched  a {NewItem.Name} and i hase so many {NewItem.Quantity}");
            }
        }


        public void Charge()
        {
            BackgroundColor = Color;
            Write($"{Name}");
            ResetColor();
            WriteLine();
            WriteLine($"Charges forward {ChargeDistance} inches");

            if (CurrentItem != null)
            {
                WriteLine($"They are carring a {CurrentItem.Name}");
            }
        }


        public void Bite()
        {
            BackgroundColor = Color;
            Write($"{Name}");
            ResetColor();
            WriteLine();
            WriteLine($"Viciously bites!");
        }

        public override void Fight(Character otherCharacter)
        {
            ForegroundColor = Color;
            WriteLine($"Ant{Name} is fighting {otherCharacter.Name}");
            int randProcent = RandomGenerator.Next(1, 101);
            Write($" {Name} bites at {otherCharacter.Name} and ");
            if (randProcent <= 50)
            {
                WriteLine("hits for 4 damage!");
                otherCharacter.TakeDemage(4);
            }
            else
            {
                WriteLine("misses....");
                Bite();
            }
            
            ResetColor();
        }

        public override void Go()
        {
            ForegroundColor = Color;
            WriteLine($"Ant {Name} is going!!!!");
            ResetColor();
        }
    }
}