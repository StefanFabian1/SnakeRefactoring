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
            var gameBoard = new GameBoard();
            var snake = new Game.Snake(gameBoard.Width / 2, gameBoard.Height / 2);
            var food = new Food(gameBoard.Width, gameBoard.Height);
            string movement = "RIGHT";
            DateTime tijd = DateTime.Now;
            DateTime tijd2 = DateTime.Now;
            string buttonpressed = "no";
            while (true)
            {
                Console.Clear();
                if (snake.CheckCollision(gameBoard.Width, gameBoard.Height) || snake.CheckSelfCollision())
                { 
                    gameover = 1;
                }
                gameBoard.DrawBorders();
                Console.ForegroundColor = ConsoleColor.Green;
                if (food.Position.X == snake.Head.X && food.Position.Y == snake.Head.Y)
                {
                    score++;
                    food.GenerateNewPosition(gameBoard.Width, gameBoard.Height);
                } 
                foreach (var pos in snake.Body)
                {
                    Console.SetCursorPosition(pos.X, pos.Y);
                    Console.Write("■");
                }
                if (gameover == 1)
                {
                    break;
                }
                Console.SetCursorPosition(snake.Head.X, snake.Head.Y);
                Console.ForegroundColor = snake.Color;
                Console.Write("■");
                Console.SetCursorPosition(food.Position.X, food.Position.Y);
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
                switch (movement)
                {
                    case "UP":
                        snake.Move(Direction.Up);
                        break;
                    case "DOWN":
                        snake.Move(Direction.Down);
                        break;
                    case "LEFT":
                        snake.Move(Direction.Left);
                        break;
                    case "RIGHT":
                        snake.Move(Direction.Right);
                        break;
                }
                if (snake.Body.Count > score)
                {
                    snake.Body.RemoveAt(0);
                }
            }
            Console.SetCursorPosition(gameBoard.Width / 5, gameBoard.Height / 2);
            Console.WriteLine("Game over, Score: "+ score);
            Console.SetCursorPosition(gameBoard.Width / 5, gameBoard.Height / 2 +1);
        }
    }
}
//¦