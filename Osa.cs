using System;
using System.Drawing;
using static System.Console;

namespace RPG
{
    public class Osa : Character
    {
        public int HasBite;
        private Item _newItem;
       

        public Osa(string name, int health, ConsoleColor color, int hasBite) 
            : base(name, health,color, Art.Bee)

        {
            HasBite = hasBite;
        }

        public void Zadli()
        {
            BackgroundColor = Color;
            Write($"{Name}");
            ResetColor();
            WriteLine();
            WriteLine($"Viciously bites!{HasBite} times.");
            if(_newItem != null)
            {
                WriteLine($"I am carring big {_newItem.Name}");
            }
        }
        
        public void AddItem(Item item)
        {
            _newItem = item;
        }
        
        public override  void Fight(Character otherCharacter)
        {
            ForegroundColor = Color;
            WriteLine($" Osa {Name} is fighting {otherCharacter.Name}");
            ResetColor();
        }

        public override void Go()
        {
            ForegroundColor = Color;
            WriteLine($"Osa {Name} is going!!!!");
            int randNum = RandomGenerator.Next(1, 101);
            if (randNum <= 70)
            {
                Zadli();
            }
            else 
            {
                Go();
            }


            ResetColor();
        }

       
           
    }
        
}
