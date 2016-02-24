namespace Okta.Core.Clients
{
    using System;
    using System.Linq;

    using Okta.Core.Models;

    /// <summary>
    /// A client to manage the authentication flow.
    /// </summary>
    public class AuthClient : AuthenticatedClient
    {
        public AuthClient(IOktaHttpClient clientWrapper) : base(clientWrapper) { resourcePath = Constants.EndpointV1 + Constants.AuthnEndpoint; }
        public AuthClient(OktaSettings oktaSettings) : base(oktaSettings) { resourcePath = Constants.EndpointV1 + Constants.AuthnEndpoint; }
        public AuthClient(string apiToken, string subdomain) : base(apiToken, subdomain) { resourcePath = Constants.EndpointV1 + Constants.AuthnEndpoint; }

        protected string resourcePath { get; set; }

        public virtual AuthResponse Authenticate(string username, string password, string relayState = null)
        {
            var authRequest = new AuthRequest {
                Username = username, 
                Password = password, 
                RelayState = relayState
            };

            var response = BaseClient.Post(resourcePath, authRequest.ToJson(), false);
            return Utils.Deserialize<AuthResponse>(response);
        }

        public virtual AuthResponse Enroll(string stateToken, Factor factor)
        {
            factor.SetProperty("stateToken", stateToken);
            var response = BaseClient.Post(resourcePath + Constants.FactorsEndpoint, factor.ToJson(), false);
            return Utils.Deserialize<AuthResponse>(response);
        }

        public virtual AuthResponse Verify(string stateToken, Factor factor, MfaAnswer answer = null)
        {
            // This is "Href" and not "First()" because this is a "Factor Links Object" - remove this line?
            var verifyLink = factor.Links["verify"].First().Href;
            return Execute(stateToken, verifyLink, answer);
        }

        public virtual AuthResponse ActivateTotpFactor(string stateToken, AuthResponse authResponse, string passCode)
        {
            var apiObject = new ApiObject();
            apiObject.SetProperty("passCode", passCode);
            var nextLink = authResponse.Links["next"].First();
            return Execute(stateToken, nextLink, apiObject);
        }

        public virtual AuthResponse ValidateToken(string recoveryToken)
        {
            var apiObject = new ApiObject();
            apiObject.SetProperty("recoveryToken", recoveryToken);
            var response = BaseClient.Post(resourcePath + Constants.RecoveryEndpoint + Constants.TokenEndpoint, apiObject.ToJson());
            return Utils.Deserialize<AuthResponse>(response);
        }

        public virtual AuthResponse GetStatus(string stateToken)
        {
            var apiObject = new ApiObject();
            apiObject.SetProperty("stateToken", stateToken);
            var response = BaseClient.Post(resourcePath, apiObject.ToJson());
            return Utils.Deserialize<AuthResponse>(response);
        }

        public virtual AuthResponse Execute(string stateToken, Link link, ApiObject apiObject = null)
        {
            return Execute(stateToken, link.Href, apiObject);
        }

        public virtual AuthResponse Execute(string stateToken, Uri uri, ApiObject apiObject = null)
        {
            // Create a new apiObject if it's null, because we need to add a stateToken
            apiObject = apiObject ?? new ApiObject();
            apiObject.SetProperty("stateToken", stateToken);
            var response = BaseClient.Post(uri, apiObject.ToJson());
            return Utils.Deserialize<AuthResponse>(response);
        }
    }
}
