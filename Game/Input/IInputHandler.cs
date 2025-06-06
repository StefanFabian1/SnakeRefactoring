using Snake.Core;

namespace Snake.Game.Core.Interfaces
{
    public interface IInputHandler
    {
        Direction GetDirection(Direction currentDirection);
    }
} 