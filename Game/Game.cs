using System;
using Snake.Core;
using Snake.Input;
using Snake.Game.Core.Interfaces;
using Snake.Game.Core.Impl;

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
        private readonly ILogger _logger;

        public Game(string configPath)
        {
            var tempConfig = GameConfig.LoadFromFile(configPath, null);
            LogLevel logLevel = LogLevel.Info;
            Enum.TryParse(tempConfig.Logging.Level, true, out logLevel);
            _logger = new FileLogger("logs/snake.log", logLevel);
            _logger.Info($"Spúšťam hru s konfiguráciou: {configPath} a úrovňou logovania: {logLevel}");

            _config = tempConfig;
            _gameBoard = new GameBoard(_config.GameBoard.Width, _config.GameBoard.Height, _config.GameBoard.BorderCharacter[0], _logger);
            _snake = new Snake(_gameBoard.Width / 2, _gameBoard.Height / 2, Enum.Parse<ConsoleColor>(_config.Snake.Color), _logger);
            _food = new Food(_gameBoard.Width, _gameBoard.Height, _logger);
            _renderer = new GameRenderer(_logger);
            _inputHandler = new InputHandler(_logger);
            _gameLoop = new GameLoop(_gameBoard, _snake, _food, _renderer, _inputHandler, _config, _logger);
            _logger.Info("Konfigurácia úspešne načítaná.");
        }

        public void Start()
        {
            _logger.Info("Hra sa začína.");
            _gameLoop.Run();
            _logger.Info("Hra skončila.");
        }

        public static void Main(string[] args)
        {
            var game = new Game("Config/config.json");
            game.Start();
        }
    }
} 