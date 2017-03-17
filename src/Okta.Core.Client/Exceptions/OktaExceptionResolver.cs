namespace Okta.Core
{
    using System;
    using System.Net.Http;

    /// <summary>
    /// Parse an http response into an <see cref="OktaException"/>
    /// </summary>
    public class OktaExceptionResolver
    {
        public static void ParseHttpResponse(HttpResponseMessage httpResponseMessage)
        {
            if(httpResponseMessage == null)
            {
                throw new OktaException("OktaExceptionResolver.ParseHttpResponse has invalid arguments", new ArgumentNullException("httpResponseMessage"));
            }

            if (!Constants.AcceptableHttpStatusCodes.Contains(httpResponseMessage.StatusCode))
            {
                var exception = Utils.Deserialize<OktaException>(httpResponseMessage);
                exception.HttpStatusCode = httpResponseMessage.StatusCode;
                if (exception.ErrorCode == OktaErrorCodes.TooManyRequestsException)
                {
                    throw new OktaRequestThrottlingException(exception);
                }

                if (exception.ErrorCode == OktaErrorCodes.AuthenticationException)
                {
                    throw new OktaAuthenticationException(exception);
                }

                throw exception;
            }
        }
    }
}
