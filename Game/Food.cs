using System;
using Snake.Core;

namespace Snake.Game
{
    public class Food
    {
        public Position Position { get; private set; }
        private Random random;

        public Food(int width, int height)
        {
            random = new Random();
            Position = new Position(random.Next(1, width - 2), random.Next(1, height - 2));
        }

        public void GenerateNewPosition(int width, int height)
        {
            Position = new Position(random.Next(1, width - 2), random.Next(1, height - 2));
        }
    }
} 