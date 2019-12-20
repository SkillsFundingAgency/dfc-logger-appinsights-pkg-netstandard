using DFC.Logger.AppInsights.Contracts;
using DFC.Logger.AppInsights.CorrelationIdProviders;
using DFC.Logger.AppInsights.Services;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace DFC.Logger.AppInsights.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDFCLogging(this IServiceCollection services, string instrumentationKey)
        {
            var applicationInsightsServiceOptions = new ApplicationInsightsServiceOptions
            {
                InstrumentationKey = instrumentationKey,
            };
            services.AddApplicationInsightsTelemetry(applicationInsightsServiceOptions);

            services.AddScoped<ICorrelationIdProvider, RequestHeaderCorrelationIdProvider>();
            services.AddScoped<ILogService, ApplicationInsightsLogService>();

            return services;
        }
    }
}
