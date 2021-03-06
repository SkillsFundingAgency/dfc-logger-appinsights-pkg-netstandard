﻿namespace DFC.Logger.AppInsights.Contracts
{
    public interface ILogService
    {
        void LogVerbose(string message);

        void LogInformation(string message);

        void LogWarning(string message);

        void LogError(string message);

        void LogCritical(string message);
    }
}