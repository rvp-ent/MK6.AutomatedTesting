using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MK6.AutomatedTesting.Load.Requests
{
    public abstract class FormPostRequest : PostRequest
    {
        protected override Uri GetRequestUri(IterationContext context)
        {
            return new Uri(context.Environment[LoadTestEnvironmentKeys.FormAction] as string);
        }

        protected override HttpContent GetContent(IterationContext context)
        {
            return new FormUrlEncodedContent(GetFormParameters(context));
        }

        protected virtual IDictionary<string, string> GetFormParameters(IterationContext context)
        {
            return new Dictionary<string, string>();
        }
    }
}
