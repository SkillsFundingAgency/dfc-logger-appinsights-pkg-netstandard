using DFC.Logger.AppInsights.Contracts;
using System.Diagnostics.CodeAnalysis;

namespace DFC.Logger.AppInsights.CorrelationIdProviders
{
    [ExcludeFromCodeCoverage]
    public class InMemoryCorrelationIdProvider : ICorrelationIdProvider
    {
        public string CorrelationId { get; set; }
    }
}