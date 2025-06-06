using System;
using Snake.Core;
using Snake.Game.Core.Interfaces;

namespace Snake.Game
{
    public class GameBoard : IGameBoard
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        private char BORDER_CHAR;
        private readonly ILogger? _logger;

        public GameBoard(int width, int height, char borderChar, ILogger? logger = null)
        {
            Width = width;
            Height = height;
            BORDER_CHAR = borderChar;
            _logger = logger;
            InitializeConsole();
        }

        private void InitializeConsole()
        {
            try
            {
                int maxWidth = Console.LargestWindowWidth;
                int maxHeight = Console.LargestWindowHeight;
                int setWidth = Math.Min(Width, maxWidth);
                int setHeight = Math.Min(Height, maxHeight);
                _logger?.Info($"Nastavujem velkost okna: pozadovane {Width}x{Height}, nastavene {setWidth}x{setHeight}, max {maxWidth}x{maxHeight}");
                Console.SetWindowSize(setWidth, setHeight);
                Console.SetBufferSize(setWidth, setHeight);
            }
            catch (Exception ex)
            {
                _logger?.Warning($"Nepodarilo sa nastaviť veľkosť terminálu: {ex.Message}");
            }
        }

        public void DrawBorders()
        {
            // Horná hranica
            for (int i = 0; i < Width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write(BORDER_CHAR);
            }

            // Spodná hranica
            for (int i = 0; i < Width; i++)
            {
                Console.SetCursorPosition(i, Height - 1);
                Console.Write(BORDER_CHAR);
            }

            // Ľavá hranica
            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(BORDER_CHAR);
            }

            // Pravá hranica
            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(Width - 1, i);
                Console.Write(BORDER_CHAR);
            }
        }

        public bool IsPositionValid(Position position)
        {
            return position.X > 0 && position.X < Width - 1 &&
                   position.Y > 0 && position.Y < Height - 1;
        }
    }
} 