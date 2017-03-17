namespace Okta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The primary http client wrapper. Handles rate limiting.
    /// </summary>
    public class OktaHttpClient : IOktaHttpClient
    {
        private HttpClient httpClient = new HttpClient {
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
            httpClient.DefaultRequestHeaders.Add("User-Agent", oktaSettings.UserAgent);
        }

        public override HttpResponseMessage Execute(HttpRequestType requestType, Uri uri = null, string relativeUri = null, string content = null, int waitMillis = 0, int retryCount = 0, bool bAddAuthorizationHeader = true)
        {
            try
            {
                var task = ExecuteAsync(requestType, uri, relativeUri, content, waitMillis, bAddAuthorizationHeader);
                task.Wait();
                var response = task.Result;

                // Handle any errors
                try
                {
                    OktaExceptionResolver.ParseHttpResponse(response);
                }

                // If it's a rate-limiting error
                catch (OktaRequestThrottlingException)
                {
                    // If we haven't met the retry threshold
                    if (waitMillis < Constants.MaxThrottlingRetryMillis * 1000)
                    {
                        // If this is our second retry, then we need to scale back
                        if (retryCount > 0)
                        {
                            // Use exponential backoff
                            int millis = (int)Math.Pow(2, retryCount) * 1000;
                            return Execute(requestType, uri, relativeUri, content, millis, retryCount++);
                        }

                        // Determine the number of milliseconds to wait using the header
                        IEnumerable<string> resetValues;
                        if (!response.Headers.TryGetValues("X-Rate-Limit-Reset", out resetValues))
                        {
                            // TODO: Log that we were unable to get the reset pageSize
                            throw;
                        }

                        // Parse the string header to an int
                        var waitUntilString = resetValues.FirstOrDefault();
                        int waitUntilUnixTime;
                        if (!int.TryParse(waitUntilString, out waitUntilUnixTime))
                        {
                            // TODO: Log that we were unable to convert the header
                            throw;
                        }

                        // See how long until we hit that time
                        var unixTime = (Int64)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds;
                        var millisToWait = unixTime - ((Int64)waitUntilUnixTime * 1000);

                        if (millisToWait > int.MaxValue)
                        {
                            // TODO: Log that we miscalculated the wait time
                            throw;
                        }

                        // Then attempt to send the request again
                        return this.Execute(requestType, uri, relativeUri, content, (int)millisToWait, 1);
                    }

                    // TODO: Log that there are too many requests queued
                    throw;
                }

                // If there were no errors, just return
                return response;
            }
            catch (OktaException oe)
            {
                throw oe;
            }
            catch (Exception e)
            {
                throw new OktaException("Error making an HTTP request: " + e.Message, e);
            }
        }

        public override Task<HttpResponseMessage> ExecuteAsync(HttpRequestType requestType, Uri uri = null, string relativeUri = null, string content = null, int waitMillis = 0, bool bAddAuthorizationHeader = true)
        {
            // Ensure we have exactly one usable Uri
            if (string.IsNullOrEmpty(relativeUri) && uri == null)
            {
                throw new OktaException("Cannot execute an Http request without a Uri");
            }

            if (!string.IsNullOrEmpty(relativeUri) && uri != null)
            {
                throw new OktaException("Http request is ambiguous: cannot determine whether to execute " + uri + " or " + relativeUri);
            }

            try
            {
                // Wait
                Utils.Sleep(waitMillis);

                // Handle GETs
                if (requestType == HttpRequestType.GET)
                {
                    return uri != null ? this.httpClient.GetAsync(uri) : this.httpClient.GetAsync(relativeUri);
                }

                // Handle POSTs
                if (requestType == HttpRequestType.POST)
                {
                    content = content ?? string.Empty;
                    if (!bAddAuthorizationHeader)
                    {
                        httpClient.DefaultRequestHeaders.Remove("Authorization");
                    }
                    return uri != null ? this.httpClient.PostAsync(uri, new StringContent(content, Encoding.UTF8, "application/json")) 
                        : this.httpClient.PostAsync(relativeUri, new StringContent(content, Encoding.UTF8, "application/json"));
                }

                // Handle PUTs
                if (requestType == HttpRequestType.PUT)
                {
                    content = content ?? string.Empty;
                    return uri != null ? this.httpClient.PutAsync(uri, new StringContent(content, Encoding.UTF8, "application/json")) : this.httpClient.PutAsync(relativeUri, new StringContent(content, Encoding.UTF8, "application/json"));
                }

                // Handle DELETEs
                if (requestType == HttpRequestType.DELETE)
                {
                    return uri != null ? this.httpClient.DeleteAsync(uri) : this.httpClient.DeleteAsync(relativeUri);
                }

                throw new OktaException("The " + requestType + " http verb is not yet supported");
            }
            catch (OktaException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new OktaException("Error making an HTTP request: " + e.Message, e);
            }
        }
    }
}
