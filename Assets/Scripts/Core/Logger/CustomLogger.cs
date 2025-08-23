using System;
using Core.Extensions;
using UnityEngine;

namespace Core.Logger
{
    public class CustomLogger : ICustomLogger
    {
        protected ILogger Logger = Debug.unityLogger;

        public virtual void Log(string message, string tag)
        {
            Logger.Log(LogType.Log, FormatMessage(message.ToWhite(), tag));
        }

        public virtual void LogWarning(string message, string tag)
        {
            Logger.Log(LogType.Warning, FormatMessage(message.ToYellow(), tag));
        }

        public virtual void LogError(string message, string tag)
        {
            Logger.Log(LogType.Error, FormatMessage(message.ToLightRed(), tag));
        }

        public virtual void LogException(Exception exception, string tag)
        {
            Logger.Log(LogType.Exception, FormatMessage(exception.Message.ToLightRed(), tag), exception);
        }
        
        private string FormatMessage(string message, string tag)
        {
            return $"[{tag.ToCyan()}] {message}";
        }
    }
}