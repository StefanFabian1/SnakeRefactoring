using System;
using System.Threading;
using Snake.Core;
using Snake.Game.Core.Interfaces;

namespace Snake.Game
{
    public class GameLoop : IGameLoop
    {
        private readonly IGameBoard _gameBoard;
        private readonly ISnake _snake;
        private readonly IFood _food;
        private readonly IGameRenderer _renderer;
        private readonly IInputHandler _inputHandler;
        private Direction _currentDirection;
        private int _score;
        private readonly int _frameDelay;
        private readonly GameConfig _config;
        private readonly ILogger _logger;

        public GameLoop(
            IGameBoard gameBoard,
            ISnake snake,
            IFood food,
            IGameRenderer renderer,
            IInputHandler inputHandler,
            GameConfig config,
            ILogger logger)
        {
            _gameBoard = gameBoard;
            _snake = snake;
            _food = food;
            _renderer = renderer;
            _inputHandler = inputHandler;
            _currentDirection = Direction.Right;
            _score = config.Snake.InitialScore;
            _frameDelay = config.GameSpeed.FrameDelay;
            _config = config;
            _logger = logger;
        }

        public void Run()
        {
            _logger.Info("Začína hlavný herný cyklus.");
            try
            {
                while (true)
                {
                    Console.Clear();
                    
                    if (_snake.CheckCollision(_gameBoard.Width, _gameBoard.Height) || _snake.CheckSelfCollision())
                    {
                        _logger.Warning($"Koniec hry: kolízia.");
                        break;
                    }

                    _gameBoard.DrawBorders();

                    if (_food.Position.X == _snake.Head.X && _food.Position.Y == _snake.Head.Y)
                    {
                        _score++;
                        _logger.Info($"Had zožral jedlo na pozícii X={_food.Position.X}, Y={_food.Position.Y}. Skóre: {_score}");
                        _food.GenerateNewPosition(_gameBoard.Width, _gameBoard.Height);
                    }

                    _renderer.RenderSnake(_snake, _config.Snake.RenderCharacter);
                    _renderer.RenderFood(_food, _config.Food.RenderCharacter);

                    _currentDirection = _inputHandler.GetDirection(_currentDirection);
                    _snake.Move(_currentDirection);

                    if (_snake.Body.Count > _score)
                    {
                        _snake.Body.RemoveAt(0);
                    }

                    Thread.Sleep(_frameDelay);
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Neočekávaná chyba v hlavnom cykle: {ex.Message}");
                throw;
            }

            _logger.Info($"Hra skončila. Konečné skóre: {_score}");
            _renderer.RenderScore(_score, _gameBoard.Width, _gameBoard.Height);
        }
    }
} 