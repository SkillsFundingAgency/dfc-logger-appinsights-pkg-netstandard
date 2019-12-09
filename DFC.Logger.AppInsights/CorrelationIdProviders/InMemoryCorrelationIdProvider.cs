using DFC.Logger.AppInsights.Contracts;

namespace DFC.Logger.AppInsights.CorrelationIdProviders
{
    public class InMemoryCorrelationIdProvider : ICorrelationIdProvider
    {
        public string CorrelationId { get; set; }
    }
}