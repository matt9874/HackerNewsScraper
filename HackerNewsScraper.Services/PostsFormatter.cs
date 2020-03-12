using HackerNewScraper.Interfaces;
using HackerNewsScraper.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace HackerNewsScraper.Services
{
    public class PostsFormatter : IDataFormatter<List<Post>, string>
    {
        public string Format(List<Post> posts)
        {
            return JsonConvert.SerializeObject(posts, new JsonSerializerSettings 
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            });
        }
    }
}
