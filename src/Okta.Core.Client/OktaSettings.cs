namespace Okta.Core
{
    using System;
    using System.Net.Http;

    /// <summary>
    /// Custom settings for creating an Okta client
    /// </summary>
    public class OktaSettings
    {
        /// <summary>
        /// Gets or sets the API token.
        /// </summary>
        /// <value>
        /// An Okta API token
        /// </value>
        public string ApiToken { get; set; }

        /// <summary>
        /// Gets or sets the base URI.
        /// </summary>
        /// <value>
        /// The URI all api requests are based on
        /// </value>
        public Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets the custom HTTP handler.
        /// </summary>
        /// <value>
        /// The custom HTTP handler for the <see cref="AuthenticatedClient.BaseClient"/>
        /// </value>
        public HttpClientHandler CustomHttpHandler { get; set; }

        /// <summary>
        /// Gets or sets the dispose custom HTTP handler.
        /// </summary>
        /// <value>
        /// The dispose custom HTTP handler option when building the <see cref="AuthenticatedClient.BaseClient"/>
        /// </value>
        public bool? DisposeCustomHttpHandler { get; set; }

        /// <summary>
        /// Sets the production subdomain.
        /// </summary>
        /// <value>
        /// The production subdomain.
        /// </value>
        public string Subdomain
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    BaseUri = new Uri(string.Format(Constants.BaseUriFormat, value));
                }
            }
        }

        private int _pageSize = Constants.DefaultPageSize;

        /// <summary>
        /// Gets or sets the default size of pages returned.
        /// </summary>
        /// <value>
        /// The default size of pages.
        /// </value>
        /// <exception cref="Okta.Core.OktaException">The SDK doesn't allow page sizes greater than  + Constants.MaxPageSize</exception>
        public int PageSize
        {
            get
            {
                return _pageSize;
            }

            set
            {
                if (value > Constants.MaxPageSize)
                {
                    throw new OktaException("The SDK doesn't allow page sizes greater than " + Constants.MaxPageSize);
                }

                this._pageSize = value;
            }
        }

        private string _userAgent = Constants.UserAgent;


        /// <summary>
        /// Gets or sets the user agent.
        /// </summary>
        /// <value>
        /// The user agent.
        /// </value>
        public string UserAgent
        {
            get
            {
                return this._userAgent;
            }

            set
            {
                this._userAgent = string.IsNullOrWhiteSpace(value) 
                    ? Constants.UserAgent 
                    : string.Format("{0} ({1})", value, Constants.UserAgent);
            }
        }
    }
}
