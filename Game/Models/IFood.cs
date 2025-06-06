using Snake.Core;

namespace Snake.Game.Core.Interfaces
{
    public interface IFood
    {
        Position Position { get; }
        void GenerateNewPosition(int width, int height);
    }
} 