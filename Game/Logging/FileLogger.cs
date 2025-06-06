using System;
using System.IO;
using System.Text;
using Snake.Game.Core.Interfaces;

namespace Snake.Game.Core.Impl
{
    public class FileLogger : ILogger
    {
        private readonly string _logFilePath;
        private readonly LogLevel _minLevel;
        private readonly object _lock = new object();
        private const int MaxLogFiles = 5;

        public FileLogger(string logFilePath, LogLevel minLevel = LogLevel.Info)
        {
            _logFilePath = logFilePath;
            _minLevel = minLevel;
            Directory.CreateDirectory(Path.GetDirectoryName(_logFilePath) ?? ".");
            RotateLogs();
        }

        private void RotateLogs()
        {
            try
            {
                for (int i = MaxLogFiles - 1; i >= 1; i--)
                {
                    string src = i == 1 ? _logFilePath : $"{_logFilePath}.{i - 1}";
                    string dest = $"{_logFilePath}.{i}";
                    if (File.Exists(dest))
                        File.Delete(dest);
                    if (File.Exists(src))
                        File.Move(src, dest);
                }
                // Vytvor nový prázdny log
                File.WriteAllText(_logFilePath, string.Empty, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                // Ak rotácia zlyhá, logovanie pokračuje do aktuálneho logu
                Console.WriteLine($"[Logger] Chyba pri rotácii logov: {ex.Message}");
            }
        }

        public void Log(string message, LogLevel level = LogLevel.Info)
        {
            if (level < _minLevel) return;
            var logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}";
            lock (_lock)
            {
                using (var writer = new StreamWriter(_logFilePath, true, Encoding.UTF8))
                {
                    writer.WriteLine(logEntry);
                }
            }
        }

        public void Debug(string message) => Log(message, LogLevel.Debug);
        public void Info(string message) => Log(message, LogLevel.Info);
        public void Warning(string message) => Log(message, LogLevel.Warning);
        public void Error(string message) => Log(message, LogLevel.Error);
    }
} 