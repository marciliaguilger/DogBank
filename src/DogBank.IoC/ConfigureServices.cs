using DogBank.Infra;
using DogBank.Infra.Sqs;
using Microsoft.Extensions.DependencyInjection;

namespace DogBank.IoC
{
    public static class ConfigureServices
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IMessageBus, MessageBus>();
            services.AddSingleton<ISqsClientFactory, SqsClientFactory>();
        }
    }
}