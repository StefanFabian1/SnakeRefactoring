namespace Snake.Game.Core.Interfaces
{
    public interface IGameRenderer
    {
        void RenderSnake(ISnake snake, string renderChar);
        void RenderFood(IFood food, string renderChar);
        void RenderScore(int score, int width, int height);
    }
} 