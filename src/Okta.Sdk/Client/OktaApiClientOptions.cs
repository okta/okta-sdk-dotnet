using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using RestSharp.Interceptors;

namespace Okta.Sdk.Client
{
    /// <summary>
    /// A class used to encapsulate optional Okta Api Client settings.
    /// </summary>
    public class OktaApiClientOptions
    {
        /// <summary>
        /// Initializes a new instance of OktaApiClientOptions.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="oAuthTokenProvider">The OAuth token provider.</param>
        /// <param name="webProxy">The web proxy.</param>
        /// <param name="httpMessageHandler">The HttpMessageHandler.</param>
        /// <param name="interceptors">The list of interceptors</param>
        public OktaApiClientOptions(Configuration configuration, IOAuthTokenProvider oAuthTokenProvider = null, WebProxy webProxy = null, HttpMessageHandler httpMessageHandler = null, IEnumerable<Interceptor> interceptors = null)
        {
            this.Configuration = configuration;
            this.OAuthTokenProvider = oAuthTokenProvider;
            this.WebProxy = webProxy;
            this.HttpMessageHandler = httpMessageHandler;
            this.Interceptors = interceptors?.ToList();
        }

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        public Configuration Configuration { get; set; }
        
        /// <summary>
        /// Gets or sets the OAuthTokenProvider.
        /// </summary>
        public IOAuthTokenProvider OAuthTokenProvider { get; set; }
        
        /// <summary>
        /// Gets or sets the WebProxy.
        /// </summary>
        public WebProxy WebProxy { get; set; }
        
        /// <summary>
        /// Gets or sets the HttpMessageHandler.
        /// </summary>
        public HttpMessageHandler HttpMessageHandler { get; set; }
        
        /// <summary>
        /// Gets or sets the list of Interceptors.
        /// </summary>
        public List<Interceptor> Interceptors { get; set; }
        
        /// <summary>
        /// Specifies that the default configuration is used.
        /// </summary>
        /// <returns>OktaApiServiceBuilder</returns>
        public static OktaApiServiceBuilder UseDefaultConfiguration()
        {
            OktaApiServiceBuilder builder = new OktaApiServiceBuilder(typeof(Configuration)).UseDefaultConfiguration();
            return builder.For<OktaApiClientOptions>().Use(new OktaApiClientOptions(builder.GetService<Configuration>()));
        }
        
        /// <summary>
        /// Specifies that the given configuration is used.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns>OktaApiServiceBuilder</returns>
        public static OktaApiServiceBuilder UseConfiguration(Configuration configuration)
        {
            OktaApiServiceBuilder builder = new OktaApiServiceBuilder(typeof(Configuration)).UseConfiguration(configuration);
            return builder.For<OktaApiClientOptions>().Use(new OktaApiClientOptions(builder.GetService<Configuration>()));
        }
        
        /// <summary>
        /// Specifies that the given function is used to load the configuration.
        /// </summary>
        /// <param name="loader">The function which loads the configuration.</param>
        /// <returns>OktaApiServiceBuilder</returns>
        public static OktaApiServiceBuilder UseConfiguration(Func<IServiceProvider, Configuration> loader)
        {
            OktaApiServiceBuilder builder = new OktaApiServiceBuilder(typeof(Configuration)).UseConfiguration(loader);
            return builder.For<OktaApiClientOptions>().Use(new OktaApiClientOptions(builder.GetService<Configuration>()));
        }

    }
}