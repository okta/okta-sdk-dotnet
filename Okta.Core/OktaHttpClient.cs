using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Okta.Core;

namespace Okta.Core
{
    /// <summary>
    /// The primary http client wrapper. Handles rate limiting.
    /// </summary>
    public class OktaHttpClient : IOktaHttpClient
    {
        private HttpClient httpClient = new HttpClient()
        {
            Timeout = Constants.DefaultTimeout
        };

        public override Uri BaseUri
        {
            get { return httpClient.BaseAddress; }
            set { httpClient.BaseAddress = value; }
        }

        private string apiToken;
        public override string ApiToken
        {
            get
            {
                return apiToken;
            }
            set
            {
                apiToken = value;

                // Will overwrite any existing Authorization header
                httpClient.DefaultRequestHeaders.Add("Authorization", "SSWS " + apiToken);
            }
        }

        public OktaHttpClient(OktaSettings oktaSettings)
        {
            if (oktaSettings.BaseUri == null || oktaSettings.ApiToken == null)
            {
                throw new OktaException("Both a BaseUri and an ApiToken must be provided");
            }

            if (oktaSettings.CustomHttpHandler != null)
            {
                if (oktaSettings.DisposeCustomHttpHandler != null)
                {
                    httpClient = new HttpClient(oktaSettings.CustomHttpHandler, oktaSettings.DisposeCustomHttpHandler.Value);
                }
                else
                {
                    httpClient = new HttpClient(oktaSettings.CustomHttpHandler);
                }

                httpClient.Timeout = Constants.DefaultTimeout;
            }

            this.BaseUri = oktaSettings.BaseUri;
            this.ApiToken = oktaSettings.ApiToken;

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("User-agent", Constants.UserAgent);
        }

        public override HttpResponseMessage Execute(HttpRequestType requestType, Uri uri = null, string relativeUri = null, string content = null, int waitMillis = 0, int retryCount = 0)
        {
            try
            {
                var response = ExecuteAsync(requestType, uri, relativeUri, content, waitMillis).Result;

                // Handle any errors
                try
                {
                    OktaExceptionResolver.ParseHttpResponse(response);
                }

                // If it's a rate-limiting error
                catch (OktaRequestThrottlingException e)
                {
                    // If we haven't met the retry threshold
                    if (waitMillis < Constants.MaxThrottlingRetryMillis * 1000)
                    {
                        // If this is our second retry, then we need to scale back
                        if (retryCount > 0)
                        {
                            // Use exponential backoff
                            int millis = (int)Math.Pow(2, retryCount) * 1000;
                            return Execute(requestType, uri, relativeUri, content, millis, retryCount: retryCount++);
                        }
                        else
                        {
                            // Determine the number of milliseconds to wait using the header
                            IEnumerable<string> resetValues;
                            if (!response.Headers.TryGetValues("X-Rate-Limit-Reset", out resetValues))
                            {
                                // TODO: Log that we were unable to get the reset pageSize
                                throw e;
                            }
                            else
                            {
                                // Parse the string header to an int
                                var waitUntilString = resetValues.FirstOrDefault();
                                int waitUntilUnixTime;
                                if (!int.TryParse(waitUntilString, out waitUntilUnixTime))
                                {
                                    // TODO: Log that we were unable to convert the header
                                    throw e;
                                }
                                else
                                {
                                    // See how long until we hit that time
                                    var unixTime = (Int64)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds;
                                    var millisToWait = unixTime - ((Int64)waitUntilUnixTime * 1000);

                                    if (millisToWait > Int32.MaxValue)
                                    {
                                        // TODO: Log that we miscalculated the wait time
                                        throw e;
                                    }

                                    // Then attempt to send the request again
                                    return Execute(requestType, uri, relativeUri, content, (int)millisToWait, retryCount: 1);
                                }
                            }
                        }
                    }
                    else
                    {
                        // TODO: Log that there are too many requests queued
                        throw e;
                    }
                }

                // If there were no errors, just return
                return response;
            }
            catch (OktaException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new OktaException("Error making an HTTP request: " + e.Message, e);
            }
        }

        public override Task<HttpResponseMessage> ExecuteAsync(HttpRequestType requestType, Uri uri = null, string relativeUri = null, string content = null, int waitMillis = 0)
        {
            // Ensure we have exactly one useable Uri
            if (String.IsNullOrEmpty(relativeUri) && uri == null)
            {
                throw new OktaException("Cannot execute an Http request without a Uri");
            }
            else if (!String.IsNullOrEmpty(relativeUri) && uri != null)
            {
                throw new OktaException("Http request is ambiguous: cannot determine whether to execute " + uri.ToString() + " or " + relativeUri);
            }

            try
            {
                // Wait
                Utils.Sleep(waitMillis);

                // Handle GETs
                if (requestType == HttpRequestType.GET)
                {
                    if (uri != null)
                    {
                        return httpClient.GetAsync(uri);
                    }
                    else
                    {
                        return httpClient.GetAsync(relativeUri);
                    }
                }

                // Handle POSTs
                else if (requestType == HttpRequestType.POST)
                {
                    content = content ?? "";
                    if (uri != null)
                    {
                        return httpClient.PostAsync(uri, new StringContent(content, Encoding.UTF8, "application/json"));
                    }
                    else
                    {
                        return httpClient.PostAsync(relativeUri, new StringContent(content, Encoding.UTF8, "application/json"));
                    }
                }

                // Handle PUTs
                else if (requestType == HttpRequestType.PUT)
                {
                    content = content ?? "";
                    if (uri != null)
                    {
                        return httpClient.PutAsync(uri, new StringContent(content, Encoding.UTF8, "application/json"));
                    }
                    else
                    {
                        return httpClient.PutAsync(relativeUri, new StringContent(content, Encoding.UTF8, "application/json"));
                    }
                }

                // Handle DELETEs
                else if (requestType == HttpRequestType.DELETE)
                {
                    if (uri != null)
                    {
                        return httpClient.DeleteAsync(uri);
                    }
                    else
                    {
                        return httpClient.DeleteAsync(relativeUri);
                    }
                }

                else
                {
                    throw new OktaException("The " + requestType.ToString() + " http verb is not yet supported");
                }
            }
            catch (OktaException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new OktaException("Error making an HTTP request: " + e.Message, e);
            }
        }
    }
}
