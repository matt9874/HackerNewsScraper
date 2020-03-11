using HackerNewScraper.Interfaces;
using HackerNewsScraper.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace HackerNewsScraper.Services.Tests
{
    [TestClass]
    public class HackerNewsScraperTests
    {
        private Mock<IDataImporter<string, string>> _importer;
        private Mock<IDataParser<string, IEnumerable<Post>>> _parser;
        private Mock<IDataFormatter<List<Post>, string>> _formatter;
        private Mock<IDataExporter<string>> _exporter;
        private string _page1;
        private string _page2;
        private string _page3;
        private string _page4;

        [TestInitialize]
        public void TestInit()
        {
            _importer = new Mock<IDataImporter<string,string>>();
            _parser = new Mock<IDataParser<string, IEnumerable<Post>>>();
            _formatter = new Mock<IDataFormatter<List<Post>, string>>();
            _exporter = new Mock<IDataExporter<string>>();

            _page1 = "p1";
            _importer.Setup(i => i.Import("https://news.ycombinator.com/news?p=1")).Returns(_page1);
            _page2 = "p2";
            _importer.Setup(i => i.Import("https://news.ycombinator.com/news?p=2")).Returns(_page2);
            _page3 = "p3";
            _importer.Setup(i => i.Import("https://news.ycombinator.com/news?p=3")).Returns(_page3);
            _page4 = "p4";
            _importer.Setup(i => i.Import("https://news.ycombinator.com/news?p=4")).Returns(_page4);
        }

        [TestMethod]
        public void Scrape_Zero_ThrowsArgumentOutOfRangeException()
        {
            var scraper = new HackerNewsScraper(_importer.Object, _parser.Object, _formatter.Object, _exporter.Object);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => scraper.Scrape(0));
        }

        [TestMethod]
        public void Scrape_One_ImporterCalledOnce()
        {
            _parser.Setup(p => p.Parse(_page1)).Returns(new Post[30]);
            var scraper = new HackerNewsScraper(_importer.Object, _parser.Object, _formatter.Object, _exporter.Object);
            scraper.Scrape(1);
            _importer.Verify(i => i.Import(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void Scrape_One_FormatterCalledOnceOnListOfCountOne()
        {
            _parser.Setup(p => p.Parse(_page1)).Returns(new Post[30]);
            var scraper = new HackerNewsScraper(_importer.Object, _parser.Object, _formatter.Object, _exporter.Object);
            scraper.Scrape(1);
            _formatter.Verify(i => i.Format(It.Is<List<Post>>(p=>p.Count==1)), Times.Once);
        }

        [TestMethod]
        public void Scrape_One_FormatterCalledOnceOnListStartingWithFirstPost()
        {
            var parsed = new Post[30];
            _parser.Setup(p => p.Parse(_page1)).Returns(parsed);
            var scraper = new HackerNewsScraper(_importer.Object, _parser.Object, _formatter.Object, _exporter.Object);
            scraper.Scrape(1);
            _formatter.Verify(i => i.Format(It.Is<List<Post>>(p => p[0] == parsed[0])), Times.Once);
        }

        [TestMethod]
        public void Scrape_One_ExporterCalledOnce()
        {
            _parser.Setup(p => p.Parse(_page1)).Returns(new Post[30]);
            var scraper = new HackerNewsScraper(_importer.Object, _parser.Object, _formatter.Object, _exporter.Object);
            scraper.Scrape(1);
            _exporter.Verify(i => i.Export(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void Scrape_OneHundred_ImporterCalledFourTimes()
        {
            _parser.Setup(p => p.Parse(_page1)).Returns(new Post[30]);
            _parser.Setup(p => p.Parse(_page2)).Returns(new Post[29]);
            _parser.Setup(p => p.Parse(_page3)).Returns(new Post[28]);
            _parser.Setup(p => p.Parse(_page4)).Returns(new Post[27]);
            var scraper = new HackerNewsScraper(_importer.Object, _parser.Object, _formatter.Object, _exporter.Object);
            scraper.Scrape(100);
            _importer.Verify(i => i.Import(It.IsAny<string>()), Times.Exactly(4));
        }

        [TestMethod]
        public void Scrape_OneHundred_FormatterCalledOnceOnListOfCountOneHundred()
        {
            _parser.Setup(p => p.Parse(_page1)).Returns(new Post[30]);
            _parser.Setup(p => p.Parse(_page2)).Returns(new Post[29]);
            _parser.Setup(p => p.Parse(_page3)).Returns(new Post[28]);
            _parser.Setup(p => p.Parse(_page4)).Returns(new Post[27]);
            var scraper = new HackerNewsScraper(_importer.Object, _parser.Object, _formatter.Object, _exporter.Object);
            scraper.Scrape(100);
            _formatter.Verify(i => i.Format(It.Is<List<Post>>(p => p.Count == 100)), Times.Once);
        }

        [TestMethod]
        public void Scrape_OneHundred_ExporterCalledOnce()
        {
            _parser.Setup(p => p.Parse(_page1)).Returns(new Post[30]);
            _parser.Setup(p => p.Parse(_page2)).Returns(new Post[29]);
            _parser.Setup(p => p.Parse(_page3)).Returns(new Post[28]);
            _parser.Setup(p => p.Parse(_page4)).Returns(new Post[27]);
            var scraper = new HackerNewsScraper(_importer.Object, _parser.Object, _formatter.Object, _exporter.Object);
            scraper.Scrape(100);
            _exporter.Verify(i => i.Export(It.IsAny<string>()), Times.Once);
        }
    }
}
