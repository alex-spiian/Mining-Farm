using System;

namespace Core.Logger
{
    public interface ICustomLogger
    {
        public void Log(string message, string tag);
        public void LogWarning(string message, string tag);
        public void LogError(string message, string tag);
        public void LogException(Exception exception, string tag);
    }
}