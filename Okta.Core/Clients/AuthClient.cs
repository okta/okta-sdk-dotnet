using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Okta.Core.Models;

namespace Okta.Core.Clients
{
    /// <summary>
    /// A client to manage the authentication flow.
    /// </summary>
    public class AuthClient : AuthenticatedClient
    {
        public AuthClient(IOktaHttpClient clientWrapper) : base(clientWrapper) { resourcePath = Constants.EndpointV1 + Constants.AuthnEndpoint; }
        public AuthClient(OktaSettings oktaSettings) : base(oktaSettings) { resourcePath = Constants.EndpointV1 + Constants.AuthnEndpoint; }
        public AuthClient(string apiToken, string subdomain) : base(apiToken, subdomain) { resourcePath = Constants.EndpointV1 + Constants.AuthnEndpoint; }

        protected string resourcePath { get; set; }

        public AuthResponse Authenticate(string username, string password, string relayState = null)
        {
            var authRequest = new AuthRequest() {
                Username = username,
                Password = password,
                RelayState = relayState
            };

            var response = BaseClient.Post(resourcePath, authRequest.ToJson());
            return Utils.Deserialize<AuthResponse>(response);
        }

        public AuthResponse Enroll(string stateToken, Factor factor)
        {
            factor.SetProperty("stateToken", stateToken);
            var response = BaseClient.Post(resourcePath + Constants.FactorsEndpoint, factor.ToJson());
            return Utils.Deserialize<AuthResponse>(response);
        }

        public AuthResponse Verify(string stateToken, Factor factor, MfaAnswer answer = null)
        {
            // This is "Href" and not "First()" because this is a "Factor Links Object" - remove this line?
            var verifyLink = factor.Links["verify"].First().Href;
            return Execute(stateToken, verifyLink, answer);
        }

        public AuthResponse ActivateTotpFactor(string stateToken, AuthResponse authResponse, string passCode)
        {
            var apiObject = new ApiObject();
            apiObject.SetProperty("passCode", passCode);
            var nextLink = authResponse.Links["next"].First();
            return Execute(stateToken, nextLink, apiObject);
        }

        public AuthResponse ValidateToken(string recoveryToken)
        {
            var apiObject = new ApiObject();
            apiObject.SetProperty("recoveryToken", recoveryToken);
            var response = BaseClient.Post(resourcePath + Constants.RecoveryEndpoint + Constants.TokenEndpoint, apiObject.ToJson());
            return Utils.Deserialize<AuthResponse>(response);
        }

        public AuthResponse GetStatus(string stateToken)
        {
            var apiObject = new ApiObject();
            apiObject.SetProperty("stateToken", stateToken);
            var response = BaseClient.Post(resourcePath, apiObject.ToJson());
            return Utils.Deserialize<AuthResponse>(response);
        }

        public AuthResponse Execute(string stateToken, Link link, ApiObject apiObject = null)
        {
            return Execute(stateToken, link.Href, apiObject);
        }

        public AuthResponse Execute(string stateToken, Uri uri, ApiObject apiObject = null)
        {
            // Create a new apiObject if it's null, because we need to add a stateToken
            apiObject = apiObject ?? new ApiObject();
            apiObject.SetProperty("stateToken", stateToken);
            var response = BaseClient.Post(uri, apiObject.ToJson());
            return Utils.Deserialize<AuthResponse>(response);
        }
    }
}
