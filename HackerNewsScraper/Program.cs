using HackerNewScraper.Interfaces;
using HackerNewsScraper.InputHandling;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HackerNewsScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = DependencyInjectionConfiguration.GetServiceProvider();

            IInputParser inputValidator = serviceProvider.GetRequiredService<IInputParser>();
            Input inputStatus = inputValidator.Parse(args);

            if (inputStatus.IsValid)
            {
                var scraper = serviceProvider.GetRequiredService<IPostsScraper>();
                scraper.Scrape(inputStatus.NumPosts);
            }
            else 
            {
                Console.WriteLine(inputStatus.ErrorMessage);
            }
        }
    }
}
