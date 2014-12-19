using System;
using System.Net.Http;

namespace MK6.AutomatedTesting.Load.Requests
{
    public abstract class PostRequest : Request
    {
        public PostRequest(string description = "")
            : base(description)
        { }

        public override HttpRequestMessage GetHttpRequest(IterationContext context)
        {
            var request =  new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = this.GetRequestUri(context),
                Content = this.GetContent(context)
            };

            ModifyRequestBeforeSending(request);

            return request;
        }

        protected virtual void ModifyRequestBeforeSending(HttpRequestMessage request)
        {
            // Default behavior is to make no modifications
        }

        protected abstract Uri GetRequestUri(IterationContext context);

        protected abstract HttpContent GetContent(IterationContext context);
    }
}
