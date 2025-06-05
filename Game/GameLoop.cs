using System;
using Snake.Core;
using Snake.Game;
using Snake.Input;

namespace Snake.Game
{
    public class GameLoop
    {
        private readonly GameBoard _gameBoard;
        private readonly Snake _snake;
        private readonly Food _food;
        private readonly GameRenderer _renderer;
        private readonly InputHandler _inputHandler;
        private Direction _currentDirection;
        private int _score;
        private const int FrameDelay = 500; // ms

        public GameLoop(GameBoard gameBoard, Snake snake, Food food, GameRenderer renderer, InputHandler inputHandler)
        {
            _gameBoard = gameBoard;
            _snake = snake;
            _food = food;
            _renderer = renderer;
            _inputHandler = inputHandler;
            _currentDirection = Direction.Right;
            _score = 5;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                
                if (_snake.CheckCollision(_gameBoard.Width, _gameBoard.Height) || _snake.CheckSelfCollision())
                {
                    break;
                }

                _gameBoard.DrawBorders();

                if (_food.Position.X == _snake.Head.X && _food.Position.Y == _snake.Head.Y)
                {
                    _score++;
                    _food.GenerateNewPosition(_gameBoard.Width, _gameBoard.Height);
                }

                _renderer.RenderSnake(_snake);
                _renderer.RenderFood(_food);

                _currentDirection = _inputHandler.GetDirection(_currentDirection);
                _snake.Move(_currentDirection);

                if (_snake.Body.Count > _score)
                {
                    _snake.Body.RemoveAt(0);
                }

                Thread.Sleep(FrameDelay);
            }

            _renderer.RenderScore(_score, _gameBoard.Width, _gameBoard.Height);
        }
    }
} 