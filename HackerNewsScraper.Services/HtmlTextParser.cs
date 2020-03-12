using HackerNewScraper.Interfaces;
using HackerNewsScraper.Domain;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerNewsScraper.Services
{
    public class HtmlTextParser : IDataParser<string, IEnumerable<Post>>
    {
        private const string _hackerNewsBaseUrl = "https://news.ycombinator.com/";
        public IEnumerable<Post> Parse(string data)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(data);

            List<HtmlNode> itemListRows = document.DocumentNode.Descendants("table")
                .First(x => x.Attributes["class"]!=null && x.Attributes["class"].Value == "itemlist")
                .Descendants("tr")
                .ToList();
            
            int numPosts = itemListRows.Count / 3;

            for (var i = 0; i < numPosts; i++)
            {
                HtmlNode itemRow1 = itemListRows[3 * i];
                HtmlNode itemRow2 = itemListRows[3 * i + 1];

                string title = itemRow1?.Descendants("a")
                    ?.FirstOrDefault(x => x.Attributes["class"] != null && x.Attributes["class"].Value == "storylink")
                    ?.InnerText;
                    
                if (title == null || title.Length == 0)
                    title = "Untitled";

                if (title.Length > 256)
                    title = title.Substring(0, 256);

                string uri = itemRow1?.Descendants("a")
                    ?.FirstOrDefault(x => x.Attributes["class"] != null && x.Attributes["class"].Value == "storylink")
                    ?.Attributes["href"].Value;

                if (!Uri.IsWellFormedUriString(uri, UriKind.Absolute))
                {
                    string hackerNewsUri = _hackerNewsBaseUrl + uri;
                    if (!Uri.IsWellFormedUriString(hackerNewsUri, UriKind.Absolute))
                        continue;
                    uri = hackerNewsUri;
                }
                string author = itemRow2?.Descendants("a")
                    ?.FirstOrDefault(x => x.Attributes["class"] != null && x.Attributes["class"].Value == "hnuser")
                    ?.InnerText;

                if (author == null || author.Length == 0)
                    author = "Unknown";

                if (author.Length > 256)
                    author = author.Substring(0, 256);

                string scoreInnerText = itemRow2?.Descendants("span")
                    ?.FirstOrDefault(x => x.Attributes["class"] != null && x.Attributes["class"].Value == "score")
                    ?.InnerText;

                uint score;
                if (scoreInnerText == null)
                    score = 0u;
                else
                {
                    string[] splitScoreText = scoreInnerText.Split(null);
                    if (splitScoreText.Length != 2 || (!UInt32.TryParse(splitScoreText[0], out score)))
                        score = 0u;
                }

                string commentsInnerText = itemRow2.Descendants("td")
                    ?.FirstOrDefault(x => x.Attributes["class"] != null && x.Attributes["class"].Value == "subtext")
                    ?.Descendants("a")
                    ?.Last()
                    ?.InnerText;

                uint comments;
                if (commentsInnerText == null || commentsInnerText == "discuss")
                    comments = 0u;
                else
                {
                    string[] splitCommentstext = commentsInnerText.Split('&');
                    if (splitCommentstext.Length != 2)
                        comments = 0u;
                    string commentsText = splitCommentstext[0];
                    if (!UInt32.TryParse(commentsText, out comments))
                        comments = 0u;
                }

                string rankText = itemRow1?.Descendants("span")
                    ?.FirstOrDefault(x => x.Attributes["class"] != null && x.Attributes["class"].Value == "rank")
                    ?.InnerText;
                uint rank;
                if (rankText == null)
                    rank = 0u;
                else
                {
                    string[] splitRankText = rankText.Split('.');
                    if (splitRankText.Length != 2 || (!UInt32.TryParse(splitRankText[0], out rank)))
                        rank = 0u;
                }
                yield return new Post(title, uri, author, score, comments, rank);
            }
        }
    }
}
