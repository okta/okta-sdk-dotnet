namespace Okta.Core.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    using Okta.Core.Models;

    /// <summary>
    /// A client to manage <see cref="Session"/>s. See the <see cref="AuthClient"/> for flows with MFA.
    /// </summary>
    public class SessionsClient : ApiClient<Session>
    {
        public SessionsClient(IOktaHttpClient clientWrapper) : base(clientWrapper, Constants.EndpointV1 + Constants.SessionsEndpoint) { }
        public SessionsClient(OktaSettings oktaSettings) : base(oktaSettings, Constants.EndpointV1 + Constants.SessionsEndpoint) { }
        public SessionsClient(string apiToken, string subdomain) : base(apiToken, subdomain, Constants.EndpointV1 + Constants.SessionsEndpoint) { }

        // TODO: Determine whether this is reasonable. If we don't provide a token attribute, then we don't get a token
        public virtual Session Create(string login, string password, TokenAttribute? tokenAttribute = null)
        {
            // Create a temporary credentials object
            var credentials = new Dictionary<string, object> {
                {"username", login}, 
                {"password", password}
            };

            // Serialize the credentials
            var serializedCredentials = Utils.SerializeObject(credentials);

            HttpResponseMessage results;
            var urlParameters = string.Empty;
            if(tokenAttribute != null)
            {
                // Add the token attribute as a url param
                var serializedTokenAttribute = Utils.SerializeObject(tokenAttribute).Trim('"');
                var urlParams = new Dictionary<string, object> {
                    {"additionalFields", serializedTokenAttribute}
                };
                urlParameters = Utils.BuildUrlParams(urlParams);
            }

            // Call the api
            results = BaseClient.Post(resourcePath + urlParameters, serializedCredentials);
            return Utils.Deserialize<Session>(results);
        }

        public virtual Session Validate(Session session) { return Validate(session.Id); }
        public virtual Session Validate(string id)
        {
            return Get(id);
        }

        public virtual Session Extend(Session session) { return Update(session); }
        public virtual Session Extend(string id) { return Update(id); }

        public virtual void Close(Session session) { this.Remove(session); }
        public virtual void Close(string id) { this.Remove(id); }

        // Create a session url string with a cookieToken and final redirectUrl.
        // Send the user a redirect to the resulting url to set a cookie.
        public virtual string CreateSessionUrlString(string cookieToken, Uri redirectUrl)
        {
            var sessionRedirectUrlFormat = "{0}login/sessionCookieRedirect?token={1}&redirectUrl={2}";
            var encodedUrl = Uri.EscapeDataString(redirectUrl.ToString());
            return string.Format(sessionRedirectUrlFormat, this.BaseUri, cookieToken, encodedUrl);
        }
    }
}
