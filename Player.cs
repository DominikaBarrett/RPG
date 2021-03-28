using System;
using static System.Console;

namespace RPG
{
    public class Player : Character
    {
        public Player(string name, int health, ConsoleColor color) : base(name, health, color, Art.Player)
        {
        }


        private void ThrowStone(Character otherCharacter)
        {
            Write("You throw a stone");
            int randProcent = RandomGenerator.Next(1, 101);
            if (randProcent <= 90)
            {
                WriteLine("and it hits!!!");
                otherCharacter.TakeDemage(2);
            }
            else
            {
                WriteLine("and it misses!!!");
            }
        }

        private void Hit(Character otherCharacter)
        {
            Write("You are hitting .....");
            int randProcent = RandomGenerator.Next(1, 101);
            if (randProcent <= 50)
            {
                WriteLine("and you got him!!!");
                otherCharacter.TakeDemage(4);
            }
            else
            {
                WriteLine("and you missed it!!!");
            }
        }


        public override void Fight(Character otherCharacter)
        {
            ForegroundColor = Color;
            WriteLine($@"

You are facing {otherCharacter.Name}. What would you like to do?

1) Throw a stone? (90% chance to do 2 damage....)
2) Take a swing and hit it? (50% chance to do 4 damage....)
           
                ");
            
            ConsoleKeyInfo keyInfo = ReadKey(true);
            if (keyInfo.Key == ConsoleKey.D1)
            {
                ThrowStone(otherCharacter);
            }
            else if (keyInfo.Key == ConsoleKey.D2)
            {
                Hit(otherCharacter);
            }
            else
            {
                WriteLine("Thats not a valid move.Try again.....");
                Fight(otherCharacter);
                return;
            }

            ResetColor();
        }
    }
}