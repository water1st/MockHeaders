using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace MockHeaders
{
    class MockerHeadersMiddleware : IMiddleware
    {
        private readonly IOptionsMonitor<HeadersOptions> options;

        public MockerHeadersMiddleware(IOptionsMonitor<HeadersOptions> options)
        {
            this.options = options;
        }

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var options = this.options.CurrentValue;
            foreach (var header in options.Headers)
            {
                context.Request.Headers.Add(header.Key, header.Value);
            }

            return next.Invoke(context);
        }
    }
}
