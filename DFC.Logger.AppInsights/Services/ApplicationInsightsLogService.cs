using DFC.Logger.AppInsights.Constants;
using DFC.Logger.AppInsights.Contracts;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using System.Collections.Generic;

namespace DFC.Logger.AppInsights.Services
{
    public class ApplicationInsightsLogService : ILogService
    {
        private readonly ICorrelationIdProvider correlationIdProvider;
        private readonly TelemetryClient telemetryClient;

        public ApplicationInsightsLogService(ICorrelationIdProvider correlationIdProvider, TelemetryClient telemetryClient)
        {
            this.correlationIdProvider = correlationIdProvider;
            this.telemetryClient = telemetryClient;
        }

        public void LogVerbose(string message)
        {
            Log(message, SeverityLevel.Verbose);
        }

        public void LogInformation(string message)
        {
            Log(message, SeverityLevel.Information);
        }

        public void LogWarning(string message)
        {
            Log(message, SeverityLevel.Warning);
        }

        public void LogError(string message)
        {
            Log(message, SeverityLevel.Error);
        }

        public void LogCritical(string message)
        {
            Log(message, SeverityLevel.Critical);
        }

        private void Log(string message, SeverityLevel severityLevel)
        {
            var properties = new Dictionary<string, string>
            {
                { HeaderName.CorrelationId, correlationIdProvider.CorrelationId },
            };

            telemetryClient.TrackTrace(message, severityLevel, properties);
        }
    }
}