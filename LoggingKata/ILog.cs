using System;
namespace LoggingKata
{
    public interface ILog  //This interface will help us log Taco Bell Information.
    {
        void LogFatal(string log, Exception exception = null);
        void LogError(string log, Exception exception = null);
        void LogWarning(string log);
        void LogInfo(string log);
        void LogDebug(string log);
    }
}
