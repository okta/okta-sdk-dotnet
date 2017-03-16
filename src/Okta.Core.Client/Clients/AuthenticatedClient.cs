namespace Okta.Core.Clients
{
    using System;

    /// <summary>
    /// An http client that handles authentication with Okta
    /// </summary>
    public abstract class AuthenticatedClient
    {
        public IOktaHttpClient BaseClient { get; set; }

        /// <summary>
        /// Gets or sets the API token.
        /// </summary>
        /// <value>
        /// A token permitting access to the API for a specific org
        /// </value>
        public string ApiToken
        {
            get { return this.BaseClient.ApiToken; }
            set { this.BaseClient.ApiToken = value; }
        }

        /// <summary>
        /// Gets the base URI.
        /// </summary>
        /// <value>
        /// The base for all the api requests
        /// </value>
        public Uri BaseUri
        {
            get { return this.BaseClient.BaseUri; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticatedClient"/> class.
        /// </summary>
        /// <param name="apiToken">The API token.</param>
        /// <param name="subdomain">The production subdomain.</param>
        public AuthenticatedClient(string apiToken, string subdomain)
        {
            var oktaSettings = new OktaSettings();
            oktaSettings.ApiToken = apiToken;
            oktaSettings.Subdomain = subdomain;

            BaseClient = new OktaHttpClient(oktaSettings);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticatedClient"/> class.
        /// </summary>
        /// <param name="apiToken">The API token.</param>
        /// <param name="baseUri">The base URI.</param>
        public AuthenticatedClient(string apiToken, Uri baseUri)
        {
            var oktaSettings = new OktaSettings {
                ApiToken = apiToken, 
                BaseUri = baseUri
            };

            BaseClient = new OktaHttpClient(oktaSettings);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticatedClient"/> class.
        /// </summary>
        /// <param name="oktaSettings">Settings to configure a <see cref="AuthenticatedClient.BaseClient"/>.</param>
        public AuthenticatedClient(OktaSettings oktaSettings)
        {
            BaseClient = new OktaHttpClient(oktaSettings);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticatedClient"/> class.
        /// </summary>
        /// <param name="clientWrapper">A preconfigured client for the <see cref="AuthenticatedClient.BaseClient"/></param>
        public AuthenticatedClient(IOktaHttpClient clientWrapper)
        {
            this.BaseClient = clientWrapper;
        }
    }
}
