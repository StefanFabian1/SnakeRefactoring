using System;
using System.Collections.Generic;
using Snake.Core;

namespace Snake.Game
{
    public class Snake
    {
        public Position Head { get; private set; }
        public List<Position> Body { get; private set; }
        public ConsoleColor Color { get; private set; }

        public Snake(int startX, int startY, ConsoleColor color = ConsoleColor.Red)
        {
            Head = new Position(startX, startY);
            Body = new List<Position>();
            Color = color;
        }

        public void Move(Direction direction)
        {
            Body.Add(new Position(Head.X, Head.Y));
            switch (direction)
            {
                case Direction.Up:
                    Head.Y--;
                    break;
                case Direction.Down:
                    Head.Y++;
                    break;
                case Direction.Left:
                    Head.X--;
                    break;
                case Direction.Right:
                    Head.X++;
                    break;
            }
        }

        public bool CheckCollision(int width, int height)
        {
            return Head.X <= 0 || Head.X >= width - 1 || Head.Y <= 0 || Head.Y >= height - 1;
        }

        public bool CheckSelfCollision()
        {
            return Body.Exists(pos => pos.X == Head.X && pos.Y == Head.Y);
        }
    }
} 