using System.Text.RegularExpressions;

namespace MK6.AutomatedTesting.Load
{
    public static class ResponseContentExtractors
    {
        public static string GetFormAction(string responseContent)
        {
            return Regex.Match(responseContent, @"<form .*action=""([^""]*)"".*>").Groups[1].Value;
        }

        public static string GetRequestVerification(string responseContent)
        {
            return
                Regex.Match(responseContent,
                    @"<input name=""__RequestVerificationToken"" type=""hidden"" value=""([^""]*)"" />").Groups[1].Value;
        }

        public static string GetADFSAction(string responseContent)
        {
            return Regex.Match(responseContent, @"name=""wa"" value=""([^""]*)""").Groups[1].Value;
        }

        public static string GetADFSContext(string responseContent)
        {
            return Regex.Match(responseContent, @"name=""wctx"" value=""([^""]*)""").Groups[1].Value;
        }

        public static string GetADFSResult(string responseContent)
        {
            return Regex.Match(responseContent, @"name=""wresult"" value=""([^""]*)""").Groups[1].Value
                .Replace("&quot;", @"""")
                .Replace("&lt;", "<")
                .Replace("&gt;", ">");
        }
    }
}