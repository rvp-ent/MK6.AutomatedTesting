using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MK6.AutomatedTesting.Load
{
    public static class LoadTestScriptHookBindings
    {
        public static void PreScriptHook(IterationContext context)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            context.Environment.Add(LoadTestEnvironmentKeys.HttpClient, BuildClient(context));
        }

        public static void PostScriptHook(IterationContext context)
        {
            var client = context.Environment[LoadTestEnvironmentKeys.HttpClient] as HttpClient;
            client.Dispose();
        }

        private static HttpClient BuildClient(IterationContext context)
        {
            var handler = new HttpClientHandler
            {
                CookieContainer = new CookieContainer()
            };

            var client = new HttpClient(handler)
            {
                Timeout = new TimeSpan(0, 5, 0),
                BaseAddress = new Uri(context.Environment[LoadTestEnvironmentKeys.BaseUrl] as string, UriKind.Absolute)
            };

            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Firefox", "33"));
            client.DefaultRequestHeaders.Add("X-MK6LoadTest", "1");

            return client;
        }
    }
}
