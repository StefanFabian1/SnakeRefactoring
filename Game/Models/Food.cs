using System;
using Snake.Core;
using Snake.Game.Core.Interfaces;

namespace Snake.Game
{
    public class Food : IFood
    {
        public Position Position { get; private set; }
        private Random random;
        private readonly ILogger? _logger;

        public Food(int width, int height, ILogger? logger = null)
        {
            random = new Random();
            _logger = logger;
            try
            {
                Position = new Position(random.Next(1, width - 2), random.Next(1, height - 2));
                _logger?.Info($"Generujem jedlo na pozícii X={Position.X}, Y={Position.Y}");
            }
            catch (Exception ex)
            {
                _logger?.Error($"Chyba pri generovaní jedla: {ex.Message}");
                throw;
            }
        }

        public void GenerateNewPosition(int width, int height)
        {
            try
            {
                Position = new Position(random.Next(1, width - 2), random.Next(1, height - 2));
                _logger?.Info($"Generujem nové jedlo na pozícii X={Position.X}, Y={Position.Y}");
            }
            catch (Exception ex)
            {
                _logger?.Error($"Chyba pri generovaní novej pozície jedla: {ex.Message}");
                throw;
            }
        }
    }
} 