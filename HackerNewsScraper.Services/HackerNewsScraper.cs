using HackerNewScraper.Interfaces;
using HackerNewsScraper.Domain;
using System;
using System.Collections.Generic;

namespace HackerNewsScraper.Services
{
    public class HackerNewsScraper : IPostsScraper
    {
        private const string _uri = "https://news.ycombinator.com/news?p=";
        private readonly IDataImporter<string, string> _importer;
        private readonly IDataParser<string, IEnumerable<Post>> _parser;
        private readonly IDataFormatter<List<Post>, string> _formatter;
        private readonly IDataExporter<string> _exporter;

        public HackerNewsScraper(IDataImporter<string,string> importer, IDataParser<string, IEnumerable<Post>> parser,
            IDataFormatter<List<Post>, string> formatter, IDataExporter<string> exporter)
        {
            _importer = importer;
            _parser = parser;
            _formatter = formatter;
            _exporter = exporter;
        }
        public void Scrape(uint numPosts)
        {
            if (numPosts == 0)
                throw new ArgumentOutOfRangeException("Number of posts must be greater than zero.");

            var posts = new List<Post>();
            bool requiredPostsAdded = false;

            int pageNumber = 1;

            while (!requiredPostsAdded)
            {
                string page = _importer.Import(_uri + pageNumber);
                IEnumerable<Post> pagePosts = _parser.Parse(page);
                foreach (var post in pagePosts)
                {
                    posts.Add(post);
                    if (posts.Count == numPosts)
                    {
                        requiredPostsAdded = true;
                        break;
                    }
                }
                pageNumber++;
            }

            string formattedPosts = _formatter.Format(posts);
            _exporter.Export(formattedPosts);
        }
    }
}
