using HackerNewScraper.Interfaces;
using HackerNewsScraper.InputHandling;
using Microsoft.Extensions.DependencyInjection;
using HackerNewsScraper.Services;

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
            services.AddTransient<IInputParser, InputParser>();
            services.AddTransient<IPostsScraper, Services.HackerNewsScraper>();
        }
    }
}
