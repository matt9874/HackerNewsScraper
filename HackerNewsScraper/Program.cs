using HackerNewsScraper.InputValidation;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HackerNewsScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = DependencyInjectionConfiguration.GetServiceProvider();

            IInputValidator inputValidator = serviceProvider.GetRequiredService<IInputValidator>();
            InputStatus inputStatus = inputValidator.Validate(args);

            if (inputStatus.IsValid)
            {

            }
            else 
            {
                Console.WriteLine(inputStatus.ErrorMessage);
            }
        }
    }
}
