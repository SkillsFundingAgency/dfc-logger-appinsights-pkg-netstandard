using DFC.Logger.AppInsights.Constants;
using DFC.Logger.AppInsights.Contracts;
using Microsoft.AspNetCore.Http;

namespace DFC.Logger.AppInsights.CorrelationIdProviders
{
    public class RequestHeaderCorrelationIdProvider : ICorrelationIdProvider
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public RequestHeaderCorrelationIdProvider(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string CorrelationId
        {
            get { return httpContextAccessor.HttpContext.Request.Headers[HeaderName.CorrelationId]; }
            set { httpContextAccessor.HttpContext.Request.Headers[HeaderName.CorrelationId] = value; }
        }
    }
}