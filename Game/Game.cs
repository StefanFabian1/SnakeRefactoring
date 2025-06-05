using System;
using Snake.Core;
using Snake.Input;

namespace Snake.Game
{
    public class Game
    {
        private readonly GameBoard _gameBoard;
        private readonly Snake _snake;
        private readonly Food _food;
        private readonly GameRenderer _renderer;
        private readonly InputHandler _inputHandler;
        private readonly GameLoop _gameLoop;
        private readonly GameConfig _config;

        public Game(string configPath)
        {
            _config = GameConfig.LoadFromFile(configPath);
            _gameBoard = new GameBoard(_config.GameBoard.Width, _config.GameBoard.Height, _config.GameBoard.BorderCharacter[0]);
            _snake = new Snake(_gameBoard.Width / 2, _gameBoard.Height / 2, Enum.Parse<ConsoleColor>(_config.Snake.Color));
            _food = new Food(_gameBoard.Width, _gameBoard.Height);
            _renderer = new GameRenderer();
            _inputHandler = new InputHandler();
            _gameLoop = new GameLoop(_gameBoard, _snake, _food, _renderer, _inputHandler, _config);
        }

        public void Start()
        {
            _gameLoop.Run();
        }

        public static void Main(string[] args)
        {
            var game = new Game("config.json");
            game.Start();
        }
    }
} 