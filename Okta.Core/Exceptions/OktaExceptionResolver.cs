using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Okta.Core
{
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
                else if (exception.ErrorCode == OktaErrorCodes.AuthenticationException)
                {
                    throw new OktaAuthenticationException(exception);
                }
                else
                {
                    throw exception;
                }
            }
        }
    }
}
