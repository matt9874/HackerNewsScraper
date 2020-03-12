using HackerNewScraper.Interfaces;
using HackerNewsScraper.InputHandling;
using Microsoft.Extensions.DependencyInjection;
using HackerNewsScraper.Services;
using System.Collections.Generic;
using HackerNewsScraper.Domain;

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
            services.AddTransient<IDataImporter<string,string>, HtmlTextImporter>();
            services.AddTransient<IDataParser<string,IEnumerable<Post>>, HtmlTextParser>();
            services.AddTransient<IDataFormatter<List<Post>, string>, PostsFormatter>();
            services.AddTransient<IDataExporter<string>, ConsoleWriter>();
        }
    }
}
