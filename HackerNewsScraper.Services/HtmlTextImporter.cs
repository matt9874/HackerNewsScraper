using HackerNewScraper.Interfaces;
using System.Net.Http;

namespace HackerNewsScraper.Services
{
    public class HtmlTextImporter : IDataImporter<string, string>
    {
        private static HttpClient _httpClient = new HttpClient();
        public string Import(string uri)
        {
            using (HttpResponseMessage response = _httpClient.GetAsync(uri).Result)
            using (HttpContent content = response.Content)
                return content.ReadAsStringAsync().Result;
        }
    }
}
