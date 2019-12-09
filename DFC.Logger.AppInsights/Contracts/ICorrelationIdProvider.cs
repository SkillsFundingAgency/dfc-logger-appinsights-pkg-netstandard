namespace DFC.Logger.AppInsights.Contracts
{
    public interface ICorrelationIdProvider
    {
        string CorrelationId { get; set; }
    }
}