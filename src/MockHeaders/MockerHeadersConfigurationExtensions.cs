using Microsoft.AspNetCore.Builder;
using MockHeaders;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MockerHeadersConfigurationExtensions
    {
        public static IServiceCollection AddMockerHeaders(this IServiceCollection services, Action<HeadersOptions> options)
        {
            services.Configure(options);
            services.AddScoped<MockerHeadersMiddleware>();

            return services;
        }

        public static IApplicationBuilder UseMockerHeaders(this IApplicationBuilder app, Func<bool> enable = null)
        {
            bool isEnable = true;
            if (enable != null)
            {
                isEnable = enable();
            }

            if (isEnable)
                app.UseMiddleware<MockerHeadersMiddleware>();

            return app;
        }
    }
}
