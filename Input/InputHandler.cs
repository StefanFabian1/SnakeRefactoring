using System;
using Snake.Core;
using Snake.Game.Core.Interfaces;

namespace Snake.Input
{
    public class InputHandler : IInputHandler
    {
        private readonly ILogger? _logger;
        public InputHandler(ILogger? logger = null)
        {
            _logger = logger;
        }

        public Direction GetDirection(Direction currentDirection)
        {
            try
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    _logger?.Debug($"Stlačený kláves: {key.Key}");
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (currentDirection != Direction.Down)
                            {
                                _logger?.Info("Zmena smeru: Hore");
                                return Direction.Up;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (currentDirection != Direction.Up)
                            {
                                _logger?.Info("Zmena smeru: Dole");
                                return Direction.Down;
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (currentDirection != Direction.Right)
                            {
                                _logger?.Info("Zmena smeru: Vľavo");
                                return Direction.Left;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (currentDirection != Direction.Left)
                            {
                                _logger?.Info("Zmena smeru: Vpravo");
                                return Direction.Right;
                            }
                            break;
                    }
                }
                return currentDirection;
            }
            catch (Exception ex)
            {
                _logger?.Error($"Chyba pri spracovaní vstupu: {ex.Message}");
                throw;
            }
        }
    }
} 