using Snake.Core;

namespace Snake.Game.Core.Interfaces
{
    public interface IGameBoard
    {
        int Width { get; }
        int Height { get; }
        void DrawBorders();
        bool IsPositionValid(Position position);
    }
} 