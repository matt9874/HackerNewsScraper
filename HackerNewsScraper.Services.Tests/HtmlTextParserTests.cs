using HackerNewsScraper.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HackerNewsScraper.Services.Tests
{
    [TestClass]
    public class HtmlTextParserTests
    {
        private static string _sampleHtml1;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _sampleHtml1 = File.ReadAllText("SampleHackerNewsHtml\\HackerNewsPage1_1.txt");
        }

        [TestMethod]
        public void Parse_Sample1_IsNotNull()
        {
            var parser = new HtmlTextParser();
            IEnumerable<Post> posts = parser.Parse(_sampleHtml1);
            Assert.IsNotNull(posts);
        }

        [TestMethod]
        public void Parse_Sample1_ContainsThirtyPosts()
        {
            var parser = new HtmlTextParser();
            IEnumerable<Post> posts = parser.Parse(_sampleHtml1);
            var x = posts.ToArray();
            Assert.AreEqual(30, posts.Count());
        }

        [TestMethod]
        public void Parse_Sample1_TitleOfFirstPost()
        {
            var parser = new HtmlTextParser();
            IEnumerable<Post> posts = parser.Parse(_sampleHtml1);
            Assert.AreEqual("Show HN: Visual SQL", posts.First().Title);
        }


        [TestMethod]
        public void Parse_Sample1_UriOfFirstPost()
        {
            var parser = new HtmlTextParser();
            IEnumerable<Post> posts = parser.Parse(_sampleHtml1);
            Assert.AreEqual("https://chartio.com/blog/why-we-made-sql-visual-and-how-we-finally-did-it/", posts.First().Uri);
        }

        [TestMethod]
        public void Parse_Sample1_AuthorOfFirstPost()
        {
            var parser = new HtmlTextParser();
            IEnumerable<Post> posts = parser.Parse(_sampleHtml1);
            Assert.AreEqual("thingsilearned", posts.First().Author);
        }

        [TestMethod]
        public void Parse_Sample1_PointsOfFirstPost()
        {
            var parser = new HtmlTextParser();
            IEnumerable<Post> posts = parser.Parse(_sampleHtml1);
            Assert.AreEqual(137u, posts.First().Points);
        }

        [TestMethod]
        public void Parse_Sample1_CommentsOfFirstPost()
        {
            var parser = new HtmlTextParser();
            IEnumerable<Post> posts = parser.Parse(_sampleHtml1);
            Assert.AreEqual(46u, posts.First().Comments);
        }

        [TestMethod]
        public void Parse_Sample1_RankOfFirstPost()
        {
            var parser = new HtmlTextParser();
            IEnumerable<Post> posts = parser.Parse(_sampleHtml1);
            Assert.AreEqual(1u, posts.First().Rank);
        }

        [TestMethod]
        public void Parse_Sample1_TitleOfLastPost()
        {
            var parser = new HtmlTextParser();
            IEnumerable<Post> posts = parser.Parse(_sampleHtml1);
            Assert.AreEqual("The FAQ of comp.lang.prolog is maintained as a Prolog source file", posts.Last().Title);
        }


        [TestMethod]
        public void Parse_Sample1_UriOfLastPost()
        {
            var parser = new HtmlTextParser();
            IEnumerable<Post> posts = parser.Parse(_sampleHtml1);
            Assert.AreEqual("https://www.metalevel.at/prolog/faq/", posts.Last().Uri);
        }

        [TestMethod]
        public void Parse_Sample1_AuthorOfLastPost()
        {
            var parser = new HtmlTextParser();
            IEnumerable<Post> posts = parser.Parse(_sampleHtml1);
            Assert.AreEqual("martinlaz", posts.Last().Author);
        }

        [TestMethod]
        public void Parse_Sample1_PointsOfLastPost()
        {
            var parser = new HtmlTextParser();
            IEnumerable<Post> posts = parser.Parse(_sampleHtml1);
            Assert.AreEqual(105u, posts.Last().Points);
        }

        [TestMethod]
        public void Parse_Sample1_CommentsOfLastPost()
        {
            var parser = new HtmlTextParser();
            IEnumerable<Post> posts = parser.Parse(_sampleHtml1);
            Assert.AreEqual(59u, posts.Last().Comments);
        }

        [TestMethod]
        public void Parse_Sample1_RankOfLastPost()
        {
            var parser = new HtmlTextParser();
            IEnumerable<Post> posts = parser.Parse(_sampleHtml1);
            Assert.AreEqual(30u, posts.Last().Rank);
        }
    }
}
