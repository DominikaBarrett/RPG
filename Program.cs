using System;
using static System.Console;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Micro RPG";
            Game mygame = new Game();
            mygame.Run();
        }
    }
}