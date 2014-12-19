using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MK6.AutomatedTesting.Runner
{
    public static class ConfigurationReader
    {
        public delegate IEnumerable<string> ReadFileLinesDelegate(string configFilePath);

        public static IDictionary<string, string> Read(string configFilePath)
        {
            return Read(configFilePath, ReadFileLines);
        }

        internal static IDictionary<string, string> Read(
            string configFilePath,
            ReadFileLinesDelegate fileLineReader)
        {
            if (string.IsNullOrWhiteSpace(configFilePath))
            {
                return new Dictionary<string, string>();
            }

            return new Dictionary<string, string>().AddRange(
                fileLineReader.Invoke(configFilePath)
                    .Select(GetConfigValue)
                    .Where(l => !string.IsNullOrEmpty(l.Key)));
        }

        internal static IEnumerable<string> ReadFileLines(string configFilePath)
        {
            return File.ReadAllLines(
                    Path.GetFullPath(configFilePath));
        }

        private static KeyValuePair<string, string> GetConfigValue(string configFileLine)
        {
            return string.IsNullOrWhiteSpace(configFileLine)
                ? new KeyValuePair<string, string>(string.Empty, string.Empty)
                : SplitConfigLine(configFileLine);
        }

        private static KeyValuePair<string, string> SplitConfigLine(string configFileLine)
        {
            var match = Regex.Match(configFileLine, @"^\s*([^#^:]*)\s*:\s*(.*)$");

            if (match.Success)
            {
                return new KeyValuePair<string, string>(
                    match.Groups[1].Value.Trim(),
                    match.Groups[2].Value.Trim());
            }

            return new KeyValuePair<string, string>(string.Empty, string.Empty);
        }
    }
}
