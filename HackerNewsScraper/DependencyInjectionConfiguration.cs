using HackerNewsScraper.InputValidation;
using Microsoft.Extensions.DependencyInjection;

namespace HackerNewsScraper
{
    internal static class DependencyInjectionConfiguration
    {
        internal static ServiceProvider GetServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            Configure(services);
            return services.BuildServiceProvider();
        }

        internal static void Configure(IServiceCollection services)
        {
            services.AddTransient<IInputValidator, InputValidator>();
        }
    }
}
