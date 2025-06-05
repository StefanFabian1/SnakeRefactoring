using System;
using Snake.Core;

namespace Snake.Game
{
    public class GameBoard
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        private char BORDER_CHAR;

        public GameBoard(int width, int height, char borderChar)
        {
            Width = width;
            Height = height;
            BORDER_CHAR = borderChar;
            InitializeConsole();
        }

        private void InitializeConsole()
        {
            Console.WindowHeight = Height;
            Console.WindowWidth = Width;
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