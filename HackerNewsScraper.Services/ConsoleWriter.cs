using HackerNewScraper.Interfaces;
using System;

namespace HackerNewsScraper.Services
{
    public class ConsoleWriter : IDataExporter<string>
    {
        public void Export(string data)
        {
            Console.Write(data);
        }
    }
}
