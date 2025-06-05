using System;
using Snake.Core;

namespace Snake.Input
{
    public class InputHandler
    {
        public Direction GetDirection(Direction currentDirection)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (currentDirection != Direction.Down)
                            return Direction.Up;
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentDirection != Direction.Up)
                            return Direction.Down;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (currentDirection != Direction.Right)
                            return Direction.Left;
                        break;
                    case ConsoleKey.RightArrow:
                        if (currentDirection != Direction.Left)
                            return Direction.Right;
                        break;
                }
            }
            return currentDirection;
        }
    }
} 