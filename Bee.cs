using System;
using System.Security.Cryptography;
using static System.Console;

namespace RPG
{
    public class Bee : Character
    {
        private bool HasPoisonSting;

        public Bee(string name,int health, ConsoleColor color,bool hasPoison)
            : base(name,health,color,Art.Bee)
        {
            HasPoisonSting = hasPoison;
        }

        public void Fly()
        {
            BackgroundColor = Color;
            Write($"{Name}");
            WriteLine();
            ResetColor();
            WriteLine($"i am flying");
            WriteLine();
        }

        public void Sting()
        {
            BackgroundColor = Color;
            Write($"{Name}");
            WriteLine();
            ResetColor();
            WriteLine($" I am stinging");
          
            if(HasPoisonSting) Write(("poison stinger!"));
            else WriteLine("sharp stinger!!!");
        }
        
        public override void Fight(Character otherCharacter)
        {
            ForegroundColor = Color;
            WriteLine($" Bee {Name} is fighting {otherCharacter.Name}");
            int randNum = RandomGenerator.Next(1, 101);
            if (randNum <= 50)
            {
                Fly();
            }
            else 
            {
                Sting();
            }
         

            ResetColor();
        }
        
        public override void Go()
        {
            ForegroundColor = Color;
            WriteLine($"Bee {Name} is going!!!!");
            ResetColor();
        }
    }
}