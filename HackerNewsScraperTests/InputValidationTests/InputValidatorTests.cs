using HackerNewsScraper.InputValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsScraperTests.InputValidationTests
{
    [TestClass]
    public class InputValidatorTests
    {
        [TestMethod]
        public void Validate_Empty_IsNotValid()
        {
            InputValidator inputValidator = new InputValidator();
            var args = new string[0];
            InputStatus inputStatus = inputValidator.Validate(args);
            Assert.IsFalse(inputStatus.IsValid);
        }

        [TestMethod]
        public void Validate_FivePosts_IsValid()
        {
            InputValidator inputValidator = new InputValidator();
            var args = new string[] {"--posts", "5" };
            InputStatus inputStatus = inputValidator.Validate(args);
            Assert.IsTrue(inputStatus.IsValid);
        }

        [TestMethod]
        public void Validate_IncorrectFirstArgument_IsNotValid()
        {
            InputValidator inputValidator = new InputValidator();
            var args = new string[] { "--pots", "5" };
            InputStatus inputStatus = inputValidator.Validate(args);
            Assert.IsFalse(inputStatus.IsValid);
        }

        [TestMethod]
        public void Validate_MissingNumberOfPosts_IsNotValid()
        {
            InputValidator inputValidator = new InputValidator();
            var args = new string[] { "--posts"};
            InputStatus inputStatus = inputValidator.Validate(args);
            Assert.IsFalse(inputStatus.IsValid);
        }

        [TestMethod]
        public void Validate_NonInteger_IsNotValid()
        {
            InputValidator inputValidator = new InputValidator();
            var args = new string[] { "--posts", "x" };
            InputStatus inputStatus = inputValidator.Validate(args);
            Assert.IsFalse(inputStatus.IsValid);
        }

        [TestMethod]
        public void Validate_ZeroPostsRequested_IsNotValid()
        {
            InputValidator inputValidator = new InputValidator();
            var args = new string[] { "--posts", "0" };
            InputStatus inputStatus = inputValidator.Validate(args);
            Assert.IsFalse(inputStatus.IsValid);
        }

        [TestMethod]
        public void Validate_HundredAndOnePostsRequested_IsNotValid()
        {
            InputValidator inputValidator = new InputValidator();
            var args = new string[] { "--posts", "101" };
            InputStatus inputStatus = inputValidator.Validate(args);
            Assert.IsFalse(inputStatus.IsValid);
        }


    }
}
