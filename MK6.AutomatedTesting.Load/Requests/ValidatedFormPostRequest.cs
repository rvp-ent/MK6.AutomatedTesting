using System;
using System.Collections.Generic;

namespace MK6.AutomatedTesting.Load.Requests
{
    public abstract class ValidatedFormPostRequest : FormPostRequest
    {
        private const string RequestVerificationTokenName = "__RequestVerificationToken";

        protected override Uri GetRequestUri(IterationContext context)
        {
            return context.Environment[LoadTestEnvironmentKeys.FormAction] as Uri;
        }

        protected override IDictionary<string, string> GetFormParameters(IterationContext context)
        {
            var formParameters = base.GetFormParameters(context);
            formParameters.SafeAdd(RequestVerificationTokenName,
                context.Environment[LoadTestEnvironmentKeys.RequestVerificationToken] as string);

            return formParameters;
        }
    }
}
