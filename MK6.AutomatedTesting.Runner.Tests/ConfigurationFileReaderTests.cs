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
            var config = ReadConfigFromResource(Resources.SingleLine);

            Assert.IsTrue(config.ContainsKey("Key"));
            Assert.AreEqual("Value", config["Key"]);
        }

        [TestMethod]
        public void Read_DoesNotIncludeLeadingSpaceInKey_WhenKeyContainsLeadingSpace()
        {
            var config = ReadConfigFromResource(Resources.SingleLineWithLeadingSpaceInKey);

            Assert.IsTrue(config.ContainsKey("Key"));
            Assert.AreEqual("Value", config["Key"]);
        }

        [TestMethod]
        public void Read_DoesNotIncludeTrailingSpaceInKey_WhenKeyContainsTrailingSpace()
        {
            var configLines = new[] { "Key    : Value" };
            var config = ReadConfigFromResource(Resources.SingleLineWithTrailingSpaceInKey);

            Assert.IsTrue(config.ContainsKey("Key"));
            Assert.AreEqual("Value", config["Key"]);
        }

        [TestMethod]
        public void Read_DoesNotIncludeLeadingSpaceInValuey_WhenValueContainsLeadingSpace()
        {
            var config = ReadConfigFromResource(Resources.SingleLineWithLeadingSpaceInValue);

            Assert.IsTrue(config.ContainsKey("Key"));
            Assert.AreEqual("Value", config["Key"]);
        }

        [TestMethod]
        public void Read_DoesNotIncludeTrailingSpaceInValue_WhenValueContainsTrailingSpace()
        {
            var config = ReadConfigFromResource(Resources.SingleLineWithTrailingspaceInValue);

            Assert.IsTrue(config.ContainsKey("Key"));
            Assert.AreEqual("Value", config["Key"]);
        }

        [TestMethod]
        public void Read_DoesNotIncludeBlanktLinesInResult()
        {
            Assert.AreEqual(
                1, 
                ReadConfigFromResource(Resources.ConfigFileWithLeadingBlankLine).Count);
        }

        [TestMethod]
        public void Read_DoesNotIncludeCommentLinesInResult()
        {
            Assert.AreEqual(
                1,
                ReadConfigFromResource(Resources.CommentedConfigFile).Count);
        }

        [TestMethod]
        public void Read_ReturnsEmptyDictionary_WhenInputFileContentIsEmpty()
        {
            Assert.AreEqual(
                0,
                ReadConfigFromResource(Resources.EmptyConfigFile).Count);
        }

        [TestMethod]
        public void Read_ReturnsTwoEntryDictionary_WhenInputFileContainsTwoLines()
        {
            Assert.AreEqual(
                2,
                ReadConfigFromResource(Resources.ConfigFileWithTwoLines).Count);
        }

        [TestMethod]
        public void Read_ReturnsKeyWithoutColon_WhenValueContainsAColon()
        {
            var config = ReadConfigFromResource(Resources.SingleLineWithColonInValue);

            Assert.IsTrue(config.ContainsKey("Key"));
        }

        private IDictionary<string, string> ReadConfigFromResource(string resource)
        {
            return ConfigurationReader.Read(
                "AnyFileName.config",
                StringSplitterMethodFactory(resource));
        }

        private ConfigurationReader.ReadFileLinesDelegate StringSplitterMethodFactory(string resource)
        {
            return f => resource
                .Split(
                    new[] { Environment.NewLine },
                    StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
