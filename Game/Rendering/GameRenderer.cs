using System;
using Snake.Core;
using Snake.Game.Core.Interfaces;

namespace Snake.Game
{
    public class GameRenderer : IGameRenderer
    {
        private readonly ILogger? _logger;
        public GameRenderer(ILogger? logger = null)
        {
            _logger = logger;
        }

        public void RenderSnake(ISnake snake, string renderChar)
        {
            try
            {
                _logger?.Debug($"Renderujem hada na pozícii X={snake.Head.X}, Y={snake.Head.Y}");
                Console.SetCursorPosition(snake.Head.X, snake.Head.Y);
                Console.ForegroundColor = snake.Color;
                Console.Write(renderChar);
                foreach (var pos in snake.Body)
                {
                    Console.SetCursorPosition(pos.X, pos.Y);
                    Console.Write(renderChar);
                }
            }
            catch (Exception ex)
            {
                _logger?.Error($"Chyba pri renderovaní hada: {ex.Message}");
                throw;
            }
        }

        public void RenderFood(IFood food, string renderChar)
        {
            try
            {
                _logger?.Debug($"Renderujem jedlo na pozícii X={food.Position.X}, Y={food.Position.Y}");
                Console.SetCursorPosition(food.Position.X, food.Position.Y);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(renderChar);
            }
            catch (Exception ex)
            {
                _logger?.Error($"Chyba pri renderovaní jedla: {ex.Message}");
                throw;
            }
        }

        public void RenderScore(int score, int width, int height)
        {
            try
            {
                _logger?.Info($"Renderujem skóre: {score}");
                Console.SetCursorPosition(width / 5, height / 2);
                Console.WriteLine("Game over, Score: " + score);
            }
            catch (Exception ex)
            {
                _logger?.Error($"Chyba pri renderovaní skóre: {ex.Message}");
                throw;
            }
        }
    }
} 