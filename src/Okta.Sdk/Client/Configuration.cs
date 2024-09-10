/*
 * Okta Admin Management
 *
 * Allows customers to easily access the Okta Management APIs
 *
 * The version of the OpenAPI document: 5.1.0
 * Contact: devex-public@okta.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Concurrent;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Okta.Sdk.Abstractions.Configuration.Providers.EnvironmentVariables;
using Okta.Sdk.Abstractions.Configuration.Providers.Object;
using Okta.Sdk.Abstractions.Configuration.Providers.Yaml;

namespace Okta.Sdk.Client
{
    /// <summary>
    /// Represents a set of configuration settings
    /// </summary>
    public class Configuration : IReadableConfiguration
    {
        #region Constants

        /// <summary>
        /// Version of the package.
        /// </summary>
        /// <value>Version of the package.</value>
        public const string Version = "8.1.2";

        /// <summary>
        /// Identifier for ISO 8601 DateTime Format
        /// </summary>
        /// <remarks>See https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx#Anchor_8 for more information.</remarks>
        // ReSharper disable once InconsistentNaming
        public const string ISO8601_DATETIME_FORMAT = "o";

        #endregion Constants
        
        #region Okta Members
        
        private bool? _disableHttpsCheck = false;
        private bool? _disableOktaDomainCheck;

        /// <summary>
        /// Gets or sets the Okta API token.
        /// </summary>
        /// <value>
        /// The Okta API token.
        /// </value>
        /// <remarks>An API token can be generated from the Okta developer dashboard.</remarks>
        public string Token
        {
            get => _token;
            set
            {
                _token = value;
                _apiKey = _apiKey ?? new Dictionary<string, string>();
                if (!_apiKey.ContainsKey("Authorization"))
                {
                    _apiKey.Add("Authorization", string.Empty);
                }
                _apiKey["Authorization"] = _token;

                _apiKeyPrefix = _apiKeyPrefix ?? new Dictionary<string, string>();

                if (!_apiKeyPrefix.ContainsKey("Authorization"))
                {
                    _apiKeyPrefix.Add("Authorization", String.Empty);
                }
                _apiKeyPrefix["Authorization"] = "SSWS";
            }
        }

        /// <summary>
        /// Gets or sets the flag to disable https check.
        /// This allows for insecure configurations and is NOT recommended for production use.
        /// </summary>
        public bool? DisableHttpsCheck
        {
            get
            {
                return _disableHttpsCheck;
            }

            set
            {
                if (value.HasValue && value.Value)
                {
                    Trace.TraceWarning("Warning: HTTPS check is disabled. This allows for insecure configurations and is NOT recommended for production use.");
                }

                _disableHttpsCheck = value;
            }
        }

        /// <summary>
        /// Gets or sets the flag to disable Okta domain check.
        /// This allows for insecure configurations and is NOT recommended for production use.
        /// </summary>
        public bool? DisableOktaDomainCheck
        {
            get
            {
                return _disableOktaDomainCheck;
            }

            set
            {
                if (value.HasValue && value.Value)
                {
                    Trace.TraceWarning("Warning: Okta domain check is disabled. This allows for insecure configurations and is NOT recommended for production use.");
                }

                _disableOktaDomainCheck = value;
            }
        }

        /// <summary>
        /// Gets or sets the Okta Organization URL to use.
        /// </summary>
        /// <value>
        /// The Okta Organization URL to use.
        /// </value>
        /// <remarks>
        /// This URL is typically in the form <c>https://dev-12345.oktapreview.com</c>. If your Okta domain includes <c>-admin</c>, remove it.
        /// </remarks>
        public string OktaDomain
        {
            get { return _basePath; }
            set { _basePath = value; }
        }
        
        /// <summary>
        /// Gets or sets the optional proxy configuration to use for HTTP connections. If <c>null</c>, the default system proxy is used, if any.
        /// </summary>
        /// <value>
        /// The proxy to use for HTTP connections.
        /// </value>
        public ProxyConfiguration Proxy { get; set; }
        
        /// <summary>
        /// The default HTTP connection timeout in milliseconds.
        /// </summary>
        public const int DefaultConnectionTimeout = 30000; // milliseconds

        /// <summary>
        /// The default number of times to retry
        /// </summary>
        public const int DefaultMaxRetries = 2;

        /// <summary>
        /// The default request timeout in milliseconds
        /// </summary>
        public const int DefaultRequestTimeout = 0;

        /// <summary>
        /// Gets or sets the HTTP connection timeout in milliseconds. If <c>null</c>, the default timeout is used.
        /// </summary>
        /// <value>
        /// The HTTP connection timeout in milliseconds.
        /// </value>
        public int? ConnectionTimeout { get; set; } = DefaultConnectionTimeout;

        /// <summary>
        /// Gets or sets the time to waiting time for the client to resolve the request (includes retries). Less than or equal to 0 means "no timeout".
        /// </summary>
        /// <value>
        /// The request timeout in milliseconds.
        /// </value>
        public int? RequestTimeout { get; set; } = DefaultRequestTimeout;

        /// <summary>
        /// Gets or sets the number of times to retry
        /// </summary>
        /// <value>
        /// The number of times to retry
        /// </value>
        public int? MaxRetries { get; set; } = DefaultMaxRetries;
        
        /// <summary>
        /// Gets or sets the authorization mode.
        /// </summary>
        public AuthorizationMode? AuthorizationMode { get; set; } = Client.AuthorizationMode.SSWS;

        /// <summary>
        /// Gets or sets the private key. Required when AuthorizationMode is equal to PrivateKey.
        /// </summary>
        public JsonWebKeyConfiguration PrivateKey { get; set; }

        /// <summary>
        /// Gets or sets the client id. Required when AuthorizationMode is equal to PrivateKey.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the Okta scopes
        /// </summary>
        public HashSet<string> Scopes { get; set; }
        
        /// <summary>
        /// Returns true if the AuthorizationMode is equals to PrivateKey, false otherwise.
        /// </summary>
        public static bool IsPrivateKeyMode (IReadableConfiguration configuration) 
            => configuration.AuthorizationMode.HasValue && configuration.AuthorizationMode.Value == Okta.Sdk.Client.AuthorizationMode.PrivateKey;

        /// <summary>
        /// Returns true if the AuthorizationMode is equals to SSWS, false otherwise.
        /// </summary>
        public static bool IsSswsMode (IReadableConfiguration configuration) 
            => configuration.AuthorizationMode.HasValue && configuration.AuthorizationMode.Value == Okta.Sdk.Client.AuthorizationMode.SSWS;

        /// <summary>
        /// Returns true if the AuthorizationMode is equals to BearerToken, false otherwise.
        /// </summary>
        public static bool IsBearerTokenMode(IReadableConfiguration configuration) 
            => configuration.AuthorizationMode.HasValue && configuration.AuthorizationMode.Value == Okta.Sdk.Client.AuthorizationMode.BearerToken;

        #endregion

        #region Static Members

        /// <summary>
        /// Default creation of exceptions for a given method name and response object
        /// </summary>
        public static readonly ExceptionFactory DefaultExceptionFactory = (methodName, response) =>
        {
            var status = (int)response.StatusCode;
            if (status >= 400)
            {
                return new ApiException(status,
                    string.Format("Error calling {0}: {1}", methodName, response.RawContent),
                    response.RawContent, response.Headers);
            }
            return null;
        };
        
        /// <summary>
        /// Validates the Okta configuration
        /// </summary>
        /// <param name="configuration">The configuration to be validated</param>
        public static void Validate(IReadableConfiguration configuration)
        {
            if (string.IsNullOrEmpty(configuration.OktaDomain))
            {
                throw new ArgumentNullException(nameof(configuration.OktaDomain), "Your Okta URL is missing. You can copy your domain from the Okta Developer Console. Follow these instructions to find it: https://bit.ly/finding-okta-domain");
            }

            if ((!configuration.DisableOktaDomainCheck.GetValueOrDefault() && !configuration.DisableHttpsCheck.GetValueOrDefault()) && !configuration.OktaDomain.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"Your Okta URL must start with https. Current value: {configuration.OktaDomain}. You can copy your domain from the Okta Developer Console. Follow these instructions to find it: https://bit.ly/finding-okta-domain", nameof(configuration.OktaDomain));
            }

            if (!configuration.DisableOktaDomainCheck.GetValueOrDefault())
            {
                if (configuration.OktaDomain.IndexOf("{yourOktaDomain}", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    throw new ArgumentNullException(nameof(configuration.OktaDomain),
                        "Replace {yourOktaDomain} with your Okta domain. You can copy your domain from the Okta Developer Console. Follow these instructions to find it: https://bit.ly/finding-okta-domain");
                }

                if (configuration.OktaDomain.IndexOf("-admin.okta.com", StringComparison.OrdinalIgnoreCase) >= 0 ||
                    configuration.OktaDomain.IndexOf("-admin.oktapreview.com", StringComparison.OrdinalIgnoreCase) >=
                    0 ||
                    configuration.OktaDomain.IndexOf("-admin.okta-emea.com", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    throw new ArgumentNullException(nameof(configuration.OktaDomain),
                        $"Your Okta domain should not contain -admin. Current value: {configuration.OktaDomain}. You can copy your domain from the Okta Developer Console. Follow these instructions to find it: https://bit.ly/finding-okta-domain");
                }

                if (configuration.OktaDomain.IndexOf(".com.com", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    throw new ArgumentNullException(nameof(configuration.OktaDomain),
                        $"It looks like there's a typo in your Okta domain. Current value: {configuration.OktaDomain}. You can copy your domain from the Okta Developer Console. Follow these instructions to find it: https://bit.ly/finding-okta-domain");
                }
            }

            if (Configuration.IsSswsMode(configuration))
            {
                if (Regex.Matches(configuration.OktaDomain, "://").Count != 1)
                {
                    throw new ArgumentNullException(nameof(configuration.OktaDomain), $"It looks like there's a typo in your Okta domain. Current value: {configuration.OktaDomain}. You can copy your domain from the Okta Developer Console. Follow these instructions to find it: https://bit.ly/finding-okta-domain");
                }

                if (string.IsNullOrEmpty(configuration.Token))
                {
                    throw new ArgumentNullException(nameof(configuration.Token), "Your Okta API token is missing. You can generate one in the Okta Developer Console. Follow these instructions: https://bit.ly/get-okta-api-token");
                }

                if (configuration.Token.IndexOf("{apiToken}", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    throw new ArgumentException("Replace {apiToken} with your Okta API token. You can generate one in the Okta Developer Console. Follow these instructions: https://bit.ly/get-okta-api-token", nameof(configuration.Token));
                }
            }
            
            if(Configuration.IsPrivateKeyMode(configuration))
            {
                if (string.IsNullOrEmpty(configuration.ClientId))
                {
                    throw new ArgumentNullException(nameof(configuration.ClientId), "Your client ID is missing. You can copy it from the Okta Developer Console in the details for the Application you created. Follow these instructions to find it: https://bit.ly/finding-okta-app-credentials");
                }

                if (configuration.ClientId.IndexOf("{ClientId}", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    throw new ArgumentNullException(
                        nameof(configuration.ClientId),
                        "Replace {clientId} with the client ID of your Application. You can copy it from the Okta Developer Console in the details for the Application you created. Follow these instructions to find it: https://bit.ly/finding-okta-app-credentials");
                }

                if (configuration.PrivateKey == null)
                {
                    throw new ArgumentNullException(nameof(configuration.PrivateKey), "Your private key is missing.");
                }

                if (configuration.Scopes == null || configuration.Scopes.Count == 0)
                {
                    throw new ArgumentNullException(nameof(configuration.Scopes), "Scopes cannot be null or empty.");
                }
            }

            if (Configuration.IsBearerTokenMode(configuration))
            {
                if (string.IsNullOrEmpty(configuration.AccessToken))
                {
                    throw new ArgumentNullException(nameof(configuration.AccessToken), "Your access token is missing.");
                }
            }
        }

        #endregion Static Members

        #region Private Members

        /// <summary>
        /// Defines the base path of the target API server.
        /// Example: http://localhost:3000/v1/
        /// </summary>
        private string _basePath;

        /// <summary>
        /// Defines the token used by the Okta API
        /// </summary>
        private string _token { get; set; }

        /// <summary>
        /// Gets or sets the API key based on the authentication name.
        /// This is the key and value comprising the "secret" for accessing an API.
        /// </summary>
        /// <value>The API key.</value>
        private IDictionary<string, string> _apiKey;

        /// <summary>
        /// Gets or sets the prefix (e.g. Token) of the API key based on the authentication name.
        /// </summary>
        /// <value>The prefix of the API key.</value>
        private IDictionary<string, string> _apiKeyPrefix;

        private string _dateTimeFormat = ISO8601_DATETIME_FORMAT;
        private string _tempFolderPath = Path.GetTempPath();

        /// <summary>
        /// Gets or sets the servers defined in the OpenAPI spec.
        /// </summary>
        /// <value>The servers</value>
        private IList<IReadOnlyDictionary<string, object>> _servers;
        #endregion Private Members

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration" /> class
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public Configuration()
        {
            UseProxy = true; // Set to true to avoid change of default behavior.  See #691.
            Proxy = null;
            UserAgent = "/okta-sdk-dotnet/csharp/oasv3";
            OktaDomain = "https://subdomain.okta.com";
            DefaultHeaders = new ConcurrentDictionary<string, string>();
            ApiKey = new ConcurrentDictionary<string, string>();
            ApiKeyPrefix = new ConcurrentDictionary<string, string>();
            Servers = new List<IReadOnlyDictionary<string, object>>()
            {
                {
                    new Dictionary<string, object> {
                        {"url", "https://{yourOktaDomain}"},
                        {"description", "No description provided"},
                        {
                            "variables", new Dictionary<string, object> {
                                {
                                    "yourOktaDomain", new Dictionary<string, object> {
                                        {"description", "The domain of your organization. This can be a provided subdomain of an official okta domain (okta.com, oktapreview.com, etc) or one of your configured custom domains."},
                                        {"default_value", "subdomain.okta.com"},
                                    }
                                }
                            }
                        }
                    }
                }
            };

            // Setting Timeout has side effects (forces ApiClient creation).
            Timeout = 100000;
            AuthorizationMode = Client.AuthorizationMode.SSWS;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration" /> class
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public Configuration(
            IDictionary<string, string> defaultHeaders,
            IDictionary<string, string> apiKey,
            IDictionary<string, string> apiKeyPrefix,
            string oktaDomain = "https://subdomain.okta.com") : this()
        {
            if (string.IsNullOrWhiteSpace(oktaDomain))
                throw new ArgumentException("The provided oktaDomain is invalid.", "oktaDomain");
            if (defaultHeaders == null)
                throw new ArgumentNullException("defaultHeaders");
            if (apiKey == null)
                throw new ArgumentNullException("apiKey");
            if (apiKeyPrefix == null)
                throw new ArgumentNullException("apiKeyPrefix");

            OktaDomain = oktaDomain;

            foreach (var keyValuePair in defaultHeaders)
            {
                DefaultHeaders.Add(keyValuePair);
            }

            foreach (var keyValuePair in apiKey)
            {
                ApiKey.Add(keyValuePair);
            }

            foreach (var keyValuePair in apiKeyPrefix)
            {
                ApiKeyPrefix.Add(keyValuePair);
            }
            
            AuthorizationMode = Client.AuthorizationMode.SSWS;
        }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public Configuration(
            string oktaDomain,
            string token) : this()
        {
            if (string.IsNullOrWhiteSpace(oktaDomain))
                throw new ArgumentException("The provided oktaDomain is invalid.", "oktaDomain");

            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentException("The provided token is invalid.", "token");

            OktaDomain = oktaDomain;
            Token = token;
            AuthorizationMode = Client.AuthorizationMode.SSWS;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the base path for API access.
        /// </summary>
        public virtual string BasePath {
            get { return _basePath; }
            set { _basePath = value; }
        }

        /// <summary>
        /// Gets or sets the default header.
        /// </summary>
        [Obsolete("Use DefaultHeaders instead.")]
        public virtual IDictionary<string, string> DefaultHeader
        {
            get
            {
                return DefaultHeaders;
            }
            set
            {
                DefaultHeaders = value;
            }
        }

        /// <summary>
        /// Gets or sets the default headers.
        /// </summary>
        public virtual IDictionary<string, string> DefaultHeaders { get; set; }

        /// <summary>
        /// Gets or sets the HTTP timeout (milliseconds) of ApiClient. Default to 100000 milliseconds.
        /// </summary>
        public virtual int Timeout { get; set; }

        /// <summary>
        /// Gets or sets the HTTP user agent.
        /// </summary>
        /// <value>Http user agent.</value>
        public virtual string UserAgent
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the username (HTTP basic authentication).
        /// </summary>
        /// <value>The username.</value>
        public virtual string Username { get; set; }

        /// <summary>
        /// Gets or sets the password (HTTP basic authentication).
        /// </summary>
        /// <value>The password.</value>
        public virtual string Password { get; set; }

        /// <summary>
        /// Gets the API key with prefix.
        /// </summary>
        /// <param name="apiKeyIdentifier">API key identifier (authentication scheme).</param>
        /// <returns>API key with prefix.</returns>
        public string GetApiKeyWithPrefix(string apiKeyIdentifier)
        {
            string apiKeyValue;
            ApiKey.TryGetValue(apiKeyIdentifier, out apiKeyValue);
            string apiKeyPrefix;
            if (ApiKeyPrefix.TryGetValue(apiKeyIdentifier, out apiKeyPrefix))
            {
                return apiKeyPrefix + " " + apiKeyValue;
            }

            return apiKeyValue;
        }

        /// <summary>
        /// Gets or sets certificate collection to be sent with requests.
        /// </summary>
        /// <value>X509 Certificate collection.</value>
        public X509CertificateCollection ClientCertificates { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use the proxy settings defined
        /// in the Proxy node of the configuration.
        /// </summary>
        /// <value>Value indicating whether to use the proxy settings defined in the Proxy node.</value>
        public bool? UseProxy { get; set; }

        /// <summary>
        /// Gets or sets the access token for OAuth2 authentication.
        ///
        /// This helper property simplifies code generation.
        /// </summary>
        /// <value>The access token.</value>
        public virtual string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the temporary folder path to store the files downloaded from the server.
        /// </summary>
        /// <value>Folder path.</value>
        public virtual string TempFolderPath
        {
            get { return _tempFolderPath; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _tempFolderPath = Path.GetTempPath();
                    return;
                }

                // create the directory if it does not exist
                if (!Directory.Exists(value))
                {
                    Directory.CreateDirectory(value);
                }

                // check if the path contains directory separator at the end
                if (value[value.Length - 1] == Path.DirectorySeparatorChar)
                {
                    _tempFolderPath = value;
                }
                else
                {
                    _tempFolderPath = value + Path.DirectorySeparatorChar;
                }
            }
        }

        /// <summary>
        /// Gets or sets the date time format used when serializing in the ApiClient
        /// By default, it's set to ISO 8601 - "o", for others see:
        /// https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx
        /// and https://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.110).aspx
        /// No validation is done to ensure that the string you're providing is valid
        /// </summary>
        /// <value>The DateTimeFormat string</value>
        public virtual string DateTimeFormat
        {
            get { return _dateTimeFormat; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    // Never allow a blank or null string, go back to the default
                    _dateTimeFormat = ISO8601_DATETIME_FORMAT;
                    return;
                }

                // Caution, no validation when you choose date time format other than ISO 8601
                // Take a look at the above links
                _dateTimeFormat = value;
            }
        }

        /// <summary>
        /// Gets or sets the prefix (e.g. Token) of the API key based on the authentication name.
        ///
        /// Whatever you set here will be prepended to the value defined in AddApiKey.
        ///
        /// An example invocation here might be:
        /// <example>
        /// ApiKeyPrefix["Authorization"] = "Bearer";
        /// </example>
        /// … where ApiKey["Authorization"] would then be used to set the value of your bearer token.
        ///
        /// <remarks>
        /// OAuth2 workflows should set tokens via AccessToken.
        /// </remarks>
        /// </summary>
        /// <value>The prefix of the API key.</value>
        public virtual IDictionary<string, string> ApiKeyPrefix
        {
            get { return _apiKeyPrefix; }
            set
            {
                if (value == null)
                {
                    throw new InvalidOperationException("ApiKeyPrefix collection may not be null.");
                }
                _apiKeyPrefix = value;
            }
        }

        /// <summary>
        /// Gets or sets the API key based on the authentication name.
        /// </summary>
        /// <value>The API key.</value>
        public virtual IDictionary<string, string> ApiKey
        {
            get { return _apiKey; }
            set
            {
                if (value == null)
                {
                    throw new InvalidOperationException("ApiKey collection may not be null.");
                }
                _apiKey = value;
            }
        }

        /// <summary>
        /// Gets or sets the servers.
        /// </summary>
        /// <value>The servers.</value>
        public virtual IList<IReadOnlyDictionary<string, object>> Servers
        {
            get { return _servers; }
            set
            {
                if (value == null)
                {
                    throw new InvalidOperationException("Servers may not be null.");
                }
                _servers = value;
            }
        }

        /// <summary>
        /// Returns URL based on server settings without providing values
        /// for the variables
        /// </summary>
        /// <param name="index">Array index of the server settings.</param>
        /// <return>The server URL.</return>
        public string GetServerUrl(int index)
        {
            return GetServerUrl(index, null);
        }

        /// <summary>
        /// Returns URL based on server settings.
        /// </summary>
        /// <param name="index">Array index of the server settings.</param>
        /// <param name="inputVariables">Dictionary of the variables and the corresponding values.</param>
        /// <return>The server URL.</return>
        public string GetServerUrl(int index, Dictionary<string, string> inputVariables)
        {
            if (index < 0 || index >= Servers.Count)
            {
                throw new InvalidOperationException($"Invalid index {index} when selecting the server. Must be less than {Servers.Count}.");
            }

            if (inputVariables == null)
            {
                inputVariables = new Dictionary<string, string>();
            }

            IReadOnlyDictionary<string, object> server = Servers[index];
            string url = (string)server["url"];

            // go through variable and assign a value
            foreach (KeyValuePair<string, object> variable in (IReadOnlyDictionary<string, object>)server["variables"])
            {

                IReadOnlyDictionary<string, object> serverVariables = (IReadOnlyDictionary<string, object>)(variable.Value);

                if (inputVariables.ContainsKey(variable.Key))
                {
                    if (((List<string>)serverVariables["enum_values"]).Contains(inputVariables[variable.Key]))
                    {
                        url = url.Replace("{" + variable.Key + "}", inputVariables[variable.Key]);
                    }
                    else
                    {
                        throw new InvalidOperationException($"The variable `{variable.Key}` in the server URL has invalid value #{inputVariables[variable.Key]}. Must be {(List<string>)serverVariables["enum_values"]}");
                    }
                }
                else
                {
                    // use default value
                    url = url.Replace("{" + variable.Key + "}", (string)serverVariables["default_value"]);
                }
            }

            return url;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Returns a string with essential information for debugging.
        /// </summary>
        public static string ToDebugReport()
        {
            string report = "C# SDK (Okta.Sdk) Debug Report:\n";
            report += "    OS: " + System.Environment.OSVersion + "\n";
            report += "    .NET Framework Version: " + System.Environment.Version  + "\n";
            report += "    Version of the API: 5.1.0\n";
            report += "    SDK Package Version: 8.1.2\n";

            return report;
        }

        /// <summary>
        /// Add Api Key Header.
        /// </summary>
        /// <param name="key">Api Key name.</param>
        /// <param name="value">Api Key value.</param>
        /// <returns></returns>
        protected void AddApiKey(string key, string value)
        {
            ApiKey[key] = value;
        }

        /// <summary>
        /// Sets the API key prefix.
        /// </summary>
        /// <param name="key">Api Key name.</param>
        /// <param name="value">Api Key value.</param>
        protected void AddApiKeyPrefix(string key, string value)
        {
            ApiKeyPrefix[key] = value;
        }

        #endregion Methods

        #region Static Members
        /// <summary>
        /// Merge configurations.
        /// </summary>
        /// <param name="first">First configuration.</param>
        /// <param name="second">Second configuration.</param>
        /// <return>Merged configuration.</return>
        public static IReadableConfiguration MergeConfigurations(IReadableConfiguration first, IReadableConfiguration second)
        {
            if (second == null) return first ?? GlobalConfiguration.Instance;

            Dictionary<string, string> apiKey = first.ApiKey.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Dictionary<string, string> apiKeyPrefix = first.ApiKeyPrefix.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Dictionary<string, string> defaultHeaders = first.DefaultHeaders.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var kvp in second.ApiKey) apiKey[kvp.Key] = kvp.Value;
            foreach (var kvp in second.ApiKeyPrefix) apiKeyPrefix[kvp.Key] = kvp.Value;
            foreach (var kvp in second.DefaultHeaders) defaultHeaders[kvp.Key] = kvp.Value;

            var config = new Configuration
            {
                ApiKey = apiKey,
                ApiKeyPrefix = apiKeyPrefix,
                DefaultHeaders = defaultHeaders,
                OktaDomain = second.OktaDomain ?? first.OktaDomain,
                Token = second.Token ?? first.Token,
                ConnectionTimeout = second.ConnectionTimeout,
                MaxRetries = second.MaxRetries ?? first.MaxRetries,
                RequestTimeout = second.RequestTimeout ?? first.RequestTimeout,
                Proxy = second.Proxy ?? first.Proxy,
                UserAgent = second.UserAgent ?? first.UserAgent,
                Username = second.Username ?? first.Username,
                Password = second.Password ?? first.Password,
                AccessToken = second.AccessToken ?? first.AccessToken,
                TempFolderPath = second.TempFolderPath ?? first.TempFolderPath,
                DateTimeFormat = second.DateTimeFormat ?? first.DateTimeFormat,
                ClientCertificates = second.ClientCertificates ?? first.ClientCertificates,
                AuthorizationMode = second.AuthorizationMode ?? first.AuthorizationMode,
                ClientId = second.ClientId ?? first.ClientId,
                Scopes = second.Scopes ?? first.Scopes,
                PrivateKey = second.PrivateKey ?? first.PrivateKey,
                DisableOktaDomainCheck = second.DisableOktaDomainCheck ?? first.DisableOktaDomainCheck,
                DisableHttpsCheck = second.DisableHttpsCheck ?? first.DisableHttpsCheck,
                UseProxy = second.UseProxy ?? first.UseProxy,
            };
            return config;
        }
        
        public static Configuration GetConfigurationOrDefault(Configuration configuration = null)
        {
            string configurationFileRoot = Directory.GetCurrentDirectory();

            var homeOktaYamlLocation = HomePath.Resolve("~", ".okta", "okta.yaml");

            var applicationAppSettingsLocation = Path.Combine(configurationFileRoot ?? string.Empty, "appsettings.json");
            var applicationOktaYamlLocation = Path.Combine(configurationFileRoot ?? string.Empty, "okta.yaml");

            var configBuilder = new ConfigurationBuilder()
                .AddYamlFile(homeOktaYamlLocation, optional: true)
                .AddJsonFile(applicationAppSettingsLocation, optional: true)
                .AddYamlFile(applicationOktaYamlLocation, optional: true)
                .AddEnvironmentVariables("okta", "_", root: "okta")
                .AddEnvironmentVariables("okta_testing", "_", root: "okta")
                .AddObject(configuration, root: "okta:client")
                .AddObject(configuration, root: "okta:testing")
                .AddObject(configuration);

            var compiledConfig = new Configuration();
            configBuilder.Build().GetSection("okta").GetSection("client").Bind(compiledConfig);
            configBuilder.Build().GetSection("okta").GetSection("testing").Bind(compiledConfig);
            configBuilder.Build().Bind(compiledConfig);

            return compiledConfig;
        }
        
        #endregion Static Members
    }
    
    /// <summary>
    /// Contains methods for resolving the home directory path.
    /// </summary>
    internal static class HomePath
    {
        /// <summary>
        /// Resolves a collection of path segments with a home directory path.
        /// </summary>
        /// <remarks>
        /// Provides support for Unix-like paths on Windows. If the first path segment starts with <c>~</c>, this segment is prepended with the home directory path.
        /// </remarks>
        /// <param name="pathSegments">The path segments.</param>
        /// <returns>A combined path which includes the resolved home directory path (if necessary). If home directory path cannot be resolved, returns null.</returns>
        public static string Resolve(params string[] pathSegments)
        {
            if (pathSegments.Length == 0)
            {
                return null;
            }

            if (!pathSegments[0].StartsWith("~"))
            {
                return Path.Combine(pathSegments);
            }

            if (!TryGetHomePath(out string homePath))
            {
                return null;
            }

            var newSegments =
                new string[] { pathSegments[0].Replace("~", homePath) }
                .Concat(pathSegments.Skip(1))
                .ToArray();

            return Path.Combine(newSegments);
        }

        /// <summary>
        /// Resolves the current user's home directory path.
        /// Throws an exception if the path cannot be resolved.
        /// </summary>
        /// <returns>The home path.</returns>
        public static string GetHomePath()
        {
            if (TryGetHomePath(out var homePath))
            {
                return homePath;
            }
            else
            {
                throw new Exception("Home directory cannot be found in environment variables.");
            }
        }

        /// <summary>
        /// Tries to resolve the current user's home directory path.
        /// </summary>
        /// <param name="homePath">Output: resolved home path.</param>
        /// <returns>true if home path was resolved; otherwise, false.</returns>
        public static bool TryGetHomePath(out string homePath)
        {
#if NET45
            homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
#else
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                homePath = Environment.GetEnvironmentVariable("USERPROFILE") ??
                           Path.Combine(Environment.GetEnvironmentVariable("HOMEDRIVE"), Environment.GetEnvironmentVariable("HOMEPATH"));
            }
            else
            {
                homePath = Environment.GetEnvironmentVariable("HOME");
            }
#endif

            return !string.IsNullOrEmpty(homePath);
        }
    }
}
