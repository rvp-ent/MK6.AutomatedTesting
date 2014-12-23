using Microsoft.VisualStudio.TestTools.UnitTesting;
using MK6.AutomatedTesting.Runner.Tests.Properties;
using System;
using System.Collections.Generic;

namespace MK6.AutomatedTesting.Runner.Tests
{
    [TestClass]
    public class ConfigurationFileReaderTests
    {
        [TestMethod]
        public void Read_ReturnsDictionaryWithOneValue_WhenGivenArrayWithOneValue()
        {
            var config = ReadConfigFromResource(new[] { "Key:Value" });

            Assert.IsTrue(config.ContainsKey("Key"));
            Assert.AreEqual("Value", config["Key"]);
        }

        [TestMethod]
        public void Read_DoesNotIncludeLeadingSpaceInKey_WhenKeyContainsLeadingSpace()
        {
            var config = ReadConfigFromResource(new[] { "    Key:Value" });

            Assert.IsTrue(config.ContainsKey("Key"));
            Assert.AreEqual("Value", config["Key"]);
        }

        [TestMethod]
        public void Read_DoesNotIncludeTrailingSpaceInKey_WhenKeyContainsTrailingSpace()
        {
            var config = ReadConfigFromResource(new[] { "Key    : Value" });

            Assert.IsTrue(config.ContainsKey("Key"));
            Assert.AreEqual("Value", config["Key"]);
        }

        [TestMethod]
        public void Read_DoesNotIncludeLeadingSpaceInValuey_WhenValueContainsLeadingSpace()
        {
            var config = ReadConfigFromResource(new[] { "Key:    Value" });

            Assert.IsTrue(config.ContainsKey("Key"));
            Assert.AreEqual("Value", config["Key"]);
        }

        [TestMethod]
        public void Read_DoesNotIncludeTrailingSpaceInValue_WhenValueContainsTrailingSpace()
        {
            var config = ReadConfigFromResource(new[] { "Key:Value    " });

            Assert.IsTrue(config.ContainsKey("Key"));
            Assert.AreEqual("Value", config["Key"]);
        }

        [TestMethod]
        public void Read_DoesNotIncludeBlanktLinesInResult()
        {
            Assert.AreEqual(
                1,
                ReadConfigFromResource(new[] { " ", "Key:Value" }).Count);
        }

        [TestMethod]
        public void Read_DoesNotIncludeCommentLinesInResult()
        {
            Assert.AreEqual(
                1,
                ReadConfigFromResource(new[] { "# Comment", "Key:Value" }).Count);
        }

        [TestMethod]
        public void Read_ReturnsEmptyDictionary_WhenInputFileContentIsEmpty()
        {
            Assert.AreEqual(
                0,
                ReadConfigFromResource(new string[] { }).Count);
        }

        [TestMethod]
        public void Read_ReturnsTwoEntryDictionary_WhenInputFileContainsTwoLines()
        {
            Assert.AreEqual(
                2,
                ReadConfigFromResource(new[] { "Key:Value", "Key2:Value" }).Count);
        }

        [TestMethod]
        public void Read_ReturnsKeyWithoutColon_WhenValueContainsAColon()
        {
            var config = ReadConfigFromResource(new[] { "Key:http://localhost" });

            Assert.IsTrue(config.ContainsKey("Key"));
        }

        private IDictionary<string, string> ReadConfigFromResource(string[] lines)
        {
            return ConfigurationReader.Read(
                "AnyFileName.config",
                f => lines);
        }
    }
}
