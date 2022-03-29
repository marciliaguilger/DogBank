using Microsoft.AspNetCore.Builder;
using Prometheus;

namespace DogBank.Api.Application.Configurations
{
    public static class PrometheusConfigurations
    {
        public static void ConfigurePrometheus(this IApplicationBuilder app)
        {
            var counter = Metrics
                .CreateCounter("DogBankApi", "Counts requests to the API",
                    new CounterConfiguration
                    {
                        LabelNames = new[] { "method", "endpoint" }
                    });


            app.Use((context, next) =>
            {
                counter.WithLabels(context.Request.Method, context.Request.Path).Inc();
                return next();
            });

            app.UseMetricServer();
            app.UseHttpMetrics();
        }
    }
}
