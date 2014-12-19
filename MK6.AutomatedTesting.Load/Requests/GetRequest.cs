using System.Net.Http;

namespace MK6.AutomatedTesting.Load.Requests
{
    public class GetRequest : Request
    {
        private readonly string _mainRequestUrl;

        public GetRequest(string mainRequestUrl, string description = null)
            : base (description)
        {
            this._mainRequestUrl = mainRequestUrl;
        }

        public override HttpRequestMessage GetHttpRequest(IterationContext context)
        {
            return new HttpRequestMessage(HttpMethod.Get, this._mainRequestUrl);
        }
    }
}
