using System;
using Snake.Core;

namespace Snake.Game
{
    public class GameRenderer
    {
        public void RenderSnake(Snake snake, string renderChar)
        {
            Console.SetCursorPosition(snake.Head.X, snake.Head.Y);
            Console.ForegroundColor = snake.Color;
            Console.Write(renderChar);
            foreach (var pos in snake.Body)
            {
                Console.SetCursorPosition(pos.X, pos.Y);
                Console.Write(renderChar);
            }
        }

        public void RenderFood(Food food, string renderChar)
        {
            Console.SetCursorPosition(food.Position.X, food.Position.Y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(renderChar);
        }

        public void RenderScore(int score, int width, int height)
        {
            Console.SetCursorPosition(width / 5, height / 2);
            Console.WriteLine("Game over, Score: " + score);
        }
    }
} 