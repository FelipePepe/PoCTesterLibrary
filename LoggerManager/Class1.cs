using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerManager
{
    public enum LogLevel
    {
        Debug,
        Info,
        Warning,
        Error,
        Critical
    }

    public interface ILogger
    {
        void Log(LogLevel level, string message, Exception exception = null);
        void LogDebug(string message);
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message, Exception exception = null);
        void LogCritical(string message, Exception exception = null);
    }

    public class FileLogger : ILogger
    {
        private readonly string _logPath;
        private readonly LogLevel _minimumLogLevel;

        public FileLogger(string logPath = null, LogLevel minimumLogLevel = LogLevel.Info)
        {
            // Usa configuración o ruta por defecto
            _logPath = logPath ??
                ConfigurationManager.AppSettings["LogPath"] ??
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "PoCTesterLogs");

            // Asegura que el directorio exista
            Directory.CreateDirectory(_logPath);

            _minimumLogLevel = minimumLogLevel;
        }

        public void Log(LogLevel level, string message, Exception exception = null)
        {
            if (level < _minimumLogLevel) return;

            try
            {
                string logFile = Path.Combine(_logPath, $"{DateTime.Now:yyyyMMdd}_log.txt");

                var logMessage = new StringBuilder()
                    .Append($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ")
                    .Append($"[{level}] ")
                    .Append(message);

                if (exception != null)
                {
                    logMessage.Append($"\nException: {exception.Message}")
                              .Append($"\nStack Trace: {exception.StackTrace}");
                }

                File.AppendAllText(logFile, logMessage.ToString() + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // Logging del error de logging (fallback)
                Trace.WriteLine($"Error logging message: {ex.Message}");
            }
        }

        public void LogDebug(string message) => Log(LogLevel.Debug, message);
        public void LogInfo(string message) => Log(LogLevel.Info, message);
        public void LogWarning(string message) => Log(LogLevel.Warning, message);
        public void LogError(string message, Exception exception = null) => Log(LogLevel.Error, message, exception);
        public void LogCritical(string message, Exception exception = null) => Log(LogLevel.Critical, message, exception);
    }

    // Fábrica para crear loggers
    public static class LoggerFactory
    {
        public static ILogger CreateLogger(string logPath = null, LogLevel minimumLevel = LogLevel.Info)
        {
            return new FileLogger(logPath, minimumLevel);
        }
    }
}
