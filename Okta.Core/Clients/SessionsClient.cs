using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Okta.Core.Models;

namespace Okta.Core.Clients
{
    /// <summary>
    /// A client to manage <see cref="Session"/>s. See the <see cref="AuthClient"/> for flows with MFA.
    /// </summary>
    public class SessionsClient : ApiClient<Session>
    {
        public SessionsClient(IOktaHttpClient clientWrapper) : base(clientWrapper, Constants.EndpointV1 + Constants.SessionsEndpoint) { }
        public SessionsClient(OktaSettings oktaSettings) : base(oktaSettings, Constants.EndpointV1 + Constants.SessionsEndpoint) { }
        public SessionsClient(string apiToken, string subdomain) : base(apiToken, subdomain, Constants.EndpointV1 + Constants.SessionsEndpoint) { }

        // TODO: Determine whether this is reasonable. If we don't provide a token attribute, then we don't get a token
        // public Session Create(string login, string password) { return Create(login, password, null); }
        public Session Create(string login, string password, TokenAttribute? tokenAttribute = null)
        {
            // Create a temporary credentials object
            var credentials = new Dictionary<string, object> {
                {"username", login},
                {"password", password}
            };

            // Serialize the credentials
            var serializedCredentials = Utils.SerializeObject(credentials);

            HttpResponseMessage results;
            var urlParameters = "";
            if(tokenAttribute != null)
            {
                // Add the token attribute as a url param
                var serializedTokenAttribute = Utils.SerializeObject(tokenAttribute).Trim('"');
                var urlParams = new Dictionary<string, object>()
                {
                    {"additionalFields", serializedTokenAttribute}
                };
                urlParameters = Utils.BuildUrlParams(urlParams);
            }

            // Call the api
            results = BaseClient.Post(resourcePath + urlParameters, serializedCredentials);
            return Utils.Deserialize<Session>(results);
        }

        public Session Validate(Session session) { return Validate(session.Id); }
        public Session Validate(string id)
        {
            return Get(id);
        }

        public Session Extend(Session session) { return Update(session); }
        public Session Extend(string id) { return Update(id); }

        public void Close(Session session) { base.Remove(session); }
        public void Close(string id) { base.Remove(id); }
    }
}
