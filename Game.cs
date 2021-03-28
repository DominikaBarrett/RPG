using System;
using System.Collections.Generic;
using static System.Console;
using Figgle;


namespace RPG
{
    class Game
    {
        private Player _player;
        private Character CurrentEnemie;
        private List<Character> Enemies;


        public Game()
        {
            Ant krolowa = new Ant("Krolowa", 35, ConsoleColor.Blue, 6);

            Item cos = new Item("Cos", 34);
            Item leafNinjaStar = new Item("Leaf Ninja Star", 10);
            Item nowy = new Item("Szpada", 89);
            Ant mrowka = new Ant("Mrowka", 20, ConsoleColor.Magenta, 3);

            Bee buzzy = new Bee("Buzzy", 45, ConsoleColor.Red, true);
            Bee pszczolka = new Bee("Pszczolka", 12, ConsoleColor.Yellow, false);

            Osa zadlik = new Osa("zadlik", 30, ConsoleColor.Green, 12);

            zadlik.AddItem(cos);
            zadlik.AddItem(nowy);

            Enemies = new List<Character>() {krolowa, buzzy, pszczolka, zadlik, mrowka};
        }


        public void Run()
        {
            IntroToTheGame();


            for (int i = 0; i < Enemies.Count; i += 1)
            {
                CurrentEnemie = Enemies[i];
                IntroCurrentEnemy();
                BattleCurrentEnemy();

                if (_player.IsDead)
                {
                    WriteLine("You were defeated...");
                    WaitForKey();
                    break;
                }
                else if (CurrentEnemie.IsDead)
                {
                    WriteLine($"You defeated {CurrentEnemie.Name} ");
                    WaitForKey();
                }
            }

            RunGameOver();


            WriteLine("War is over...");

            WaitForKey();
        }


        private void IntroToTheGame()
        {
            WriteLine("##### Micro RPG #####\n");
            WriteLine(FiggleFonts.Ogre.Render("Micro RPG game"));
            WriteLine(FiggleFonts.Ogre.Render("Created BY Dominika Barrett"));
            Write("What is your name?");
            string name = ReadLine();
            _player = new Player(name, 30, ConsoleColor.Blue);

            ForegroundColor = ConsoleColor.DarkBlue;
            WriteLine(@"
You stuck in the insect world, you tinny surranded by grass...

     /  /          \
/   /   \          /   \
\   \   /          \   /  /
/   /  /     o   \  \  \  \
\  /  /  /  /|\  /  /  /  /
 \ \  \ /   / \  \ /   \ / ");
            ResetColor();
            WaitForKey();
            
            Clear();
            WriteLine($"Are you ready for a fight? You got {Enemies.Count}x oponnents to face...");
            _player.DisplayInfo();
            WaitForKey();
        }

        private void RunGameOver()
        {
            Clear();
            if (_player.IsDead)
            {
                WriteLine($@"{FiggleFonts.Epic.Render("You lose!")}
You were fight very brave it was not easy. 
Try  again ....");
            }
            else
            {
                WriteLine($@"{FiggleFonts.Epic.Render("You win!")}
Your journey is over. Exhausted, you made it. 
Be proud. It was not easy :) ");
            }

            WriteLine("Thanks for playing...");
        }

        private void IntroCurrentEnemy()
        {
            Clear();
            ForegroundColor = CurrentEnemie.Color;
            WriteLine($"A new enemy approaches!");
            ResetColor();
            CurrentEnemie.DisplayInfo();
            WriteLine();
            WaitForKey();
        }

        private void BattleCurrentEnemy()
        {
            while (_player.IsAlive && CurrentEnemie.IsAlive)
            {
                Clear();
                _player.DisplayHealthBar();
                CurrentEnemie.DisplayHealthBar();
                WriteLine();

                _player.Fight(CurrentEnemie);

                if (_player.IsDead || _player.IsDead)
                {
                    break;
                }

                WriteLine();
                WaitForKey();

                Clear();
                _player.DisplayHealthBar();
                CurrentEnemie.DisplayHealthBar();
                WriteLine();

                CurrentEnemie.Fight(_player);

                WaitForKey();
            }
        }

        private void WaitForKey()
        {
            WriteLine("Press any key to conntinue...\n");
            ReadKey(true);
        }
    }
}