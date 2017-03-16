namespace Okta.Core.Clients
{
    using System;
    using System.Linq;

    using Okta.Core.Models;
    using System.Collections.Generic;
    /// <summary>
    /// A client to manage the authentication flow.
    /// </summary>
    public class AuthClient : AuthenticatedClient
    {
        public AuthClient(IOktaHttpClient clientWrapper) : base(clientWrapper) { resourcePath = Constants.EndpointV1 + Constants.AuthnEndpoint; }
        public AuthClient(OktaSettings oktaSettings) : base(oktaSettings) { resourcePath = Constants.EndpointV1 + Constants.AuthnEndpoint; }
        public AuthClient(string apiToken, string subdomain) : base(apiToken, subdomain) { resourcePath = Constants.EndpointV1 + Constants.AuthnEndpoint; }

        protected string resourcePath { get; set; }

        /// <summary>
        /// Authenticates an Okta user
        /// </summary>
        /// <param name="username">User's username/login</param>
        /// <param name="password">User's password</param>
        /// <param name="relayState">opaque value for the transaction and processed as untrusted data which is just echoed in a response. It is the client’s responsibility to escape/encode this value before displaying in a UI such as a HTML document </param>
        /// <param name="bWarnPasswordExpired">Optional parameter indicating whether the PASSWORD_WARN status should be returned if available. Defaults to false</param>
        /// <param name="bMultiOptionalFactorEnroll">Optional parameter indicating whether the user should be prompted to add an additional second factor if available </param>
        /// <returns></returns>
        public virtual AuthResponse Authenticate(string username, string password, string relayState = null, bool bWarnPasswordExpired = false, bool bMultiOptionalFactorEnroll = false)
        {
            var authRequest = new AuthRequest {
                Username = username, 
                Password = password, 
                RelayState = relayState,
                Options =
                {
                    WarnBeforePasswordExpiration = bWarnPasswordExpired,
                    MultiOptionalFactorEnroll = bMultiOptionalFactorEnroll
                }
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

        public virtual AuthResponse VerifyTotpFactor(string factorId, AuthResponse authResponse, string passCode)
        {
            
            var apiObject = new ApiObject();
            apiObject.SetProperty("stateToken", authResponse.StateToken);
            apiObject.SetProperty("passCode", passCode);
            var response = BaseClient.Post(resourcePath + Constants.FactorsEndpoint + "/" + factorId + Constants.VerifyEndpoint, apiObject.ToJson(), true);
            return Utils.Deserialize<AuthResponse>(response);
        }

        public virtual AuthResponse VerifyPullFactor(string factorId, AuthResponse authResponse)
        {
            var apiObject = new ApiObject();
            apiObject.SetProperty("stateToken", authResponse.StateToken);
            var response = BaseClient.Post(resourcePath + Constants.FactorsEndpoint + "/" + factorId + Constants.VerifyEndpoint, apiObject.ToJson(), true);
            return Utils.Deserialize<AuthResponse>(response);
        }


        public virtual AuthResponse ChangePassword(string stateToken, string oldPassword, string newPassword)
        {
            AuthNewPassword anp = new AuthNewPassword
            {
                OldPassword = oldPassword,
                NewPassword = newPassword,
                StateToken = stateToken
            };
            var response = BaseClient.Post(resourcePath + Constants.LifecycleMap[Constants.LifecycleChangePassword], anp.ToJson(), false);
            return Utils.Deserialize<AuthResponse>(response);
        }


        public virtual AuthResponse Skip(string stateToken)
        {
            var apiObject = new ApiObject();
            apiObject.SetProperty("stateToken", stateToken);
            var response = BaseClient.Post(resourcePath + Constants.SkipEndpoint, apiObject.ToJson());
            return Utils.Deserialize<AuthResponse>(response);
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

        public virtual AuthResponse Execute(string stateToken, string relativeUri, ApiObject apiObject = null)
        {
            // Create a new apiObject if it's null, because we need to add a stateToken
            apiObject = apiObject ?? new ApiObject();
            if (!apiObject.ContainsProperty("stateToken"))
                apiObject.SetProperty("stateToken", stateToken);
            var response = BaseClient.Post(relativeUri, apiObject.ToJson(), true);
            return Utils.Deserialize<AuthResponse>(response);
        }

        public virtual AuthResponse Execute(string stateToken, Uri uri, ApiObject apiObject = null)
        {
            // Create a new apiObject if it's null, because we need to add a stateToken
            apiObject = apiObject ?? new ApiObject();
            if(!apiObject.ContainsProperty("stateToken"))
                apiObject.SetProperty("stateToken", stateToken);
            var response = BaseClient.Post( uri, apiObject.ToJson());
            return Utils.Deserialize<AuthResponse>(response);
        }
    }
}
