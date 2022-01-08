﻿using NLog;
using StudentTeacher.Service.Interfaces;

namespace StudentTeacher.Service.Services;

public class LoggerManager : ILoggerManager
{
    private static ILogger logger = LogManager.GetCurrentClassLogger();
    public LoggerManager() { }
    public void LogDebug(string message)
    {
        logger.Debug(message);
    }
    public void LogError(string message)
    {
        logger.Error(message);
    }
    public void LogInfo(string message)
    {
        logger.Info(message);
    }
    public void LogWarn(string message)
    {
        logger.Warn(message);
    }
}
