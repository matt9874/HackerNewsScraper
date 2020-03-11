using HackerNewsScraper.InputHandling;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsScraperTests.InputHandlingTests
{
    [TestClass]
    public class InputParserTests
    {
        [TestMethod]
        public void Validate_Empty_IsNotValid()
        {
            InputParser inputValidator = new InputParser();
            var args = new string[0];
            Input inputStatus = inputValidator.Parse(args);
            Assert.IsFalse(inputStatus.IsValid);
        }

        [TestMethod]
        public void Validate_FivePosts_IsValid()
        {
            InputParser inputValidator = new InputParser();
            var args = new string[] {"--posts", "5" };
            Input inputStatus = inputValidator.Parse(args);
            Assert.IsTrue(inputStatus.IsValid);
        }

        [TestMethod]
        public void Validate_FivePosts_FivePosts()
        {
            InputParser inputValidator = new InputParser();
            var args = new string[] { "--posts", "5" };
            Input inputStatus = inputValidator.Parse(args);
            Assert.AreEqual(5u, inputStatus.NumPosts);
        }

        [TestMethod]
        public void Validate_IncorrectFirstArgument_IsNotValid()
        {
            InputParser inputValidator = new InputParser();
            var args = new string[] { "--pots", "5" };
            Input inputStatus = inputValidator.Parse(args);
            Assert.IsFalse(inputStatus.IsValid);
        }

        [TestMethod]
        public void Validate_MissingNumberOfPosts_IsNotValid()
        {
            InputParser inputValidator = new InputParser();
            var args = new string[] { "--posts"};
            Input inputStatus = inputValidator.Parse(args);
            Assert.IsFalse(inputStatus.IsValid);
        }

        [TestMethod]
        public void Validate_NonInteger_IsNotValid()
        {
            InputParser inputValidator = new InputParser();
            var args = new string[] { "--posts", "x" };
            Input inputStatus = inputValidator.Parse(args);
            Assert.IsFalse(inputStatus.IsValid);
        }

        [TestMethod]
        public void Validate_ZeroPostsRequested_IsNotValid()
        {
            InputParser inputValidator = new InputParser();
            var args = new string[] { "--posts", "0" };
            Input inputStatus = inputValidator.Parse(args);
            Assert.IsFalse(inputStatus.IsValid);
        }

        [TestMethod]
        public void Validate_HundredAndOnePostsRequested_IsNotValid()
        {
            InputParser inputValidator = new InputParser();
            var args = new string[] { "--posts", "101" };
            Input inputStatus = inputValidator.Parse(args);
            Assert.IsFalse(inputStatus.IsValid);
        }


    }
}
