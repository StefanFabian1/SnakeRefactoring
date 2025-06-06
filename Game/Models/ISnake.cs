using System;
using System.Collections.Generic;
using Snake.Core;

namespace Snake.Game.Core.Interfaces
{
    public interface ISnake
    {
        Position Head { get; }
        List<Position> Body { get; }
        ConsoleColor Color { get; }
        void Move(Direction direction);
        bool CheckCollision(int width, int height);
        bool CheckSelfCollision();
    }
} 