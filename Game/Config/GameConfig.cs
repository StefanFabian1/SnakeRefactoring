using System;
using System.IO;
using System.Text.Json;
using Snake.Game.Core.Interfaces;
using Snake.Game.Core.Impl;

namespace Snake.Game
{
    public class GameConfig
    {
        public GameBoardConfig GameBoard { get; set; } = new();
        public GameSpeedConfig GameSpeed { get; set; } = new();
        public SnakeConfig Snake { get; set; } = new();
        public FoodConfig Food { get; set; } = new();
        public LoggingConfig Logging { get; set; } = new();

        public GameConfig() { }

        public static GameConfig LoadFromFile(string filePath, ILogger? logger)
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var config = JsonSerializer.Deserialize<GameConfig>(jsonString, options);
                if (config == null)
                {
                    throw new InvalidOperationException("Failed to load configuration from file.");
                }
                logger?.Info("Konfigurácia úspešne načítaná.");
                return config;
            }
            catch (Exception ex)
            {
                logger?.Error($"Chyba pri načítaní konfigurácie: {ex.Message}");
                throw;
            }
        }
    }

    public class GameBoardConfig
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string BorderCharacter { get; set; } = "■";

        public GameBoardConfig() { }

        public GameBoardConfig(int width, int height, string borderCharacter)
        {
            if (width <= 0) throw new ArgumentException("Width must be greater than 0.", nameof(width));
            if (height <= 0) throw new ArgumentException("Height must be greater than 0.", nameof(height));
            if (string.IsNullOrEmpty(borderCharacter)) throw new ArgumentException("Border character cannot be null or empty.", nameof(borderCharacter));

            Width = width;
            Height = height;
            BorderCharacter = borderCharacter;
        }
    }

    public class GameSpeedConfig
    {
        public int FrameDelay { get; set; }
    }

    public class SnakeConfig
    {
        public int InitialScore { get; set; }
        public string Color { get; set; } = "Red";
        public string RenderCharacter { get; set; } = "■";

        public SnakeConfig() { }

        public SnakeConfig(int initialScore, string color, string renderCharacter)
        {
            if (initialScore < 0) throw new ArgumentException("Initial score cannot be negative.", nameof(initialScore));
            if (string.IsNullOrEmpty(color)) throw new ArgumentException("Color cannot be null or empty.", nameof(color));
            if (string.IsNullOrEmpty(renderCharacter)) throw new ArgumentException("Render character cannot be null or empty.", nameof(renderCharacter));

            InitialScore = initialScore;
            Color = color;
            RenderCharacter = renderCharacter;
        }
    }

    public class FoodConfig
    {
        public string Color { get; set; } = "Cyan";
        public string RenderCharacter { get; set; } = "■";

        public FoodConfig() { }

        public FoodConfig(string color, string renderCharacter)
        {
            if (string.IsNullOrEmpty(color)) throw new ArgumentException("Color cannot be null or empty.", nameof(color));
            if (string.IsNullOrEmpty(renderCharacter)) throw new ArgumentException("Render character cannot be null or empty.", nameof(renderCharacter));

            Color = color;
            RenderCharacter = renderCharacter;
        }
    }

    public class LoggingConfig
    {
        public string Level { get; set; } = "Info";
    }
} 