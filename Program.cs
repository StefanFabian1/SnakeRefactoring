using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Snake.Game;
using Snake.Core;
///█ ■
////https://www.youtube.com/watch?v=SGZgvMwjq2U
namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomnummer = new Random();
            int score = 5;
            int gameover = 0;
            // TODO: Inicializácia GameBoard
            var gameBoard = new GameBoard();
            Position hoofd = new Position(gameBoard.Width/2, gameBoard.Height/2);
            ConsoleColor hoofdColor = ConsoleColor.Red;
            string movement = "RIGHT";
            List<int> xposlijf = new List<int>();
            List<int> yposlijf = new List<int>();
            int berryx = randomnummer.Next(0, gameBoard.Width);
            int berryy = randomnummer.Next(0, gameBoard.Height);
            DateTime tijd = DateTime.Now;
            DateTime tijd2 = DateTime.Now;
            string buttonpressed = "no";
            while (true)
            {
                Console.Clear();
                if (hoofd.X == gameBoard.Width-1 || hoofd.X == 0 || hoofd.Y == gameBoard.Height-1 || hoofd.Y == 0)
                { 
                    gameover = 1;
                }
                // TODO: Vykreslenie hraníc cez GameBoard
                gameBoard.DrawBorders();
                Console.ForegroundColor = ConsoleColor.Green;
                if (berryx == hoofd.X && berryy == hoofd.Y)
                {
                    score++;
                    berryx = randomnummer.Next(1, gameBoard.Width-2);
                    berryy = randomnummer.Next(1, gameBoard.Height-2);
                } 
                for (int i = 0; i < xposlijf.Count(); i++)
                {
                    Console.SetCursorPosition(xposlijf[i], yposlijf[i]);
                    Console.Write("■");
                    if (xposlijf[i] == hoofd.X && yposlijf[i] == hoofd.Y)
                    {
                        gameover = 1;
                    }
                }
                if (gameover == 1)
                {
                    break;
                }
                Console.SetCursorPosition(hoofd.X, hoofd.Y);
                Console.ForegroundColor = hoofdColor;
                Console.Write("■");
                Console.SetCursorPosition(berryx, berryy);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("■");
                tijd = DateTime.Now;
                buttonpressed = "no";
                while (true)
                {
                    tijd2 = DateTime.Now;
                    if (tijd2.Subtract(tijd).TotalMilliseconds > 500) { break; }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo toets = Console.ReadKey(true);
                        if (toets.Key.Equals(ConsoleKey.UpArrow) && movement != "DOWN" && buttonpressed == "no")
                        {
                            movement = "UP";
                            buttonpressed = "yes";
                        }
                        if (toets.Key.Equals(ConsoleKey.DownArrow) && movement != "UP" && buttonpressed == "no")
                        {
                            movement = "DOWN";
                            buttonpressed = "yes";
                        }
                        if (toets.Key.Equals(ConsoleKey.LeftArrow) && movement != "RIGHT" && buttonpressed == "no")
                        {
                            movement = "LEFT";
                            buttonpressed = "yes";
                        }
                        if (toets.Key.Equals(ConsoleKey.RightArrow) && movement != "LEFT" && buttonpressed == "no")
                        {
                            movement = "RIGHT";
                            buttonpressed = "yes";
                        }
                    }
                }
                xposlijf.Add(hoofd.X);
                yposlijf.Add(hoofd.Y);
                switch (movement)
                {
                    case "UP":
                        hoofd.Y--;
                        break;
                    case "DOWN":
                        hoofd.Y++;
                        break;
                    case "LEFT":
                        hoofd.X--;
                        break;
                    case "RIGHT":
                        hoofd.X++;
                        break;
                }
                if (xposlijf.Count() > score)
                {
                    xposlijf.RemoveAt(0);
                    yposlijf.RemoveAt(0);
                }
            }
            Console.SetCursorPosition(gameBoard.Width / 5, gameBoard.Height / 2);
            Console.WriteLine("Game over, Score: "+ score);
            Console.SetCursorPosition(gameBoard.Width / 5, gameBoard.Height / 2 +1);
        }
    }
}
//¦