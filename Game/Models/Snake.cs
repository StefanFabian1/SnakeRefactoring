using System;
using System.Collections.Generic;
using Snake.Core;
using Snake.Game.Core.Interfaces;

namespace Snake.Game
{
    public class Snake : ISnake
    {
        public Position Head { get; private set; }
        public List<Position> Body { get; private set; }
        public ConsoleColor Color { get; private set; }
        private readonly ILogger? _logger;

        public Snake(int startX, int startY, ConsoleColor color = ConsoleColor.Red, ILogger? logger = null)
        {
            Head = new Position(startX, startY);
            Body = new List<Position>();
            Color = color;
            _logger = logger;
            _logger?.Info($"Inicializujem hada na pozícii X={startX}, Y={startY}, farba: {color}");
        }

        public void Move(Direction direction)
        {
            try
            {
                Body.Add(new Position(Head.X, Head.Y));
                var oldHead = new Position(Head.X, Head.Y);
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
                _logger?.Debug($"Had sa pohol z X={oldHead.X}, Y={oldHead.Y} na X={Head.X}, Y={Head.Y} (smer: {direction})");
            }
            catch (Exception ex)
            {
                _logger?.Error($"Chyba pri pohybe hada: {ex.Message}");
                throw;
            }
        }

        public bool CheckCollision(int width, int height)
        {
            bool collision = Head.X <= 0 || Head.X >= width - 1 || Head.Y <= 0 || Head.Y >= height - 1;
            if (collision)
                _logger?.Warning($"Had narazil do steny na pozícii X={Head.X}, Y={Head.Y}");
            return collision;
        }

        public bool CheckSelfCollision()
        {
            bool selfCollision = Body.Exists(pos => pos.X == Head.X && pos.Y == Head.Y);
            if (selfCollision)
                _logger?.Warning($"Had narazil do svojho tela na pozícii X={Head.X}, Y={Head.Y}");
            return selfCollision;
        }
    }
} 