using DFC.Logger.AppInsights.Contracts;
using DFC.Logger.AppInsights.Services;
using Microsoft.ApplicationInsights;
using Moq;
using Xunit;

namespace DFC.Logger.AppInsights.UnitTests.Services
{
    public class ApplicationInsightsLogServiceTests
    {
        private readonly ApplicationInsightsLogService applicationInsightsLogService;
        private readonly Mock<ICorrelationIdProvider> correlationIdProvider;
        private readonly TelemetryClient telemetryClient;

        public ApplicationInsightsLogServiceTests()
        {
            correlationIdProvider = new Mock<ICorrelationIdProvider>();
            telemetryClient = new TelemetryClient();

            applicationInsightsLogService = new ApplicationInsightsLogService(correlationIdProvider.Object, telemetryClient);
        }

        [Fact]
        public void LogVerboseIncludeCorrelationId()
        {
            var message = "Message1";
            applicationInsightsLogService.LogVerbose(message);

            correlationIdProvider.Verify(x => x.CorrelationId, Times.Once());
        }

        [Fact]
        public void LogInformationIncludeCorrelationId()
        {
            var message = "Message1";
            applicationInsightsLogService.LogInformation(message);

            correlationIdProvider.Verify(x => x.CorrelationId, Times.Once());
        }

        [Fact]
        public void LogWarningIncludeCorrelationId()
        {
            var message = "Message1";
            applicationInsightsLogService.LogWarning(message);

            correlationIdProvider.Verify(x => x.CorrelationId, Times.Once());
        }

        [Fact]
        public void LogCriticalIncludeCorrelationId()
        {
            var message = "Message1";
            applicationInsightsLogService.LogCritical(message);

            correlationIdProvider.Verify(x => x.CorrelationId, Times.Once());
        }

        [Fact]
        public void LogErrorIncludeCorrelationId()
        {
            var message = "Message1";
            applicationInsightsLogService.LogError(message);

            correlationIdProvider.Verify(x => x.CorrelationId, Times.Once());
        }
    }
}
