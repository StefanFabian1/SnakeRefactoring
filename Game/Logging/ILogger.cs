namespace Snake.Game.Core.Interfaces
{
    public enum LogLevel
    {
        Debug,
        Info,
        Warning,
        Error
    }

    public interface ILogger
    {
        void Log(string message, LogLevel level = LogLevel.Info);
        void Debug(string message);
        void Info(string message);
        void Warning(string message);
        void Error(string message);
    }
} 