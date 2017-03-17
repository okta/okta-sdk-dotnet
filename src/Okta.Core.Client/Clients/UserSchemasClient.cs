namespace Okta.Core.Clients
{
    using Okta.Core.Models.Schemas;

    /// <summary>
    /// A client to read the schemas of your Okta <see cref="User"/>
    /// </summary>
    public class UserSchemasClient : ApiClient<Schema>
    {
        public UserSchemasClient(IOktaHttpClient clientWrapper) :
            base(clientWrapper, Constants.EndpointV1 + Constants.UserSchemasEndpoint )
        { }

        public UserSchemasClient(OktaSettings oktaSettings) :
            base(oktaSettings, Constants.EndpointV1 + Constants.UserSchemasEndpoint) 
        { }

        public UserSchemasClient(string apiToken, string subdomain) :
            base(apiToken, subdomain, Constants.EndpointV1 + Constants.UserSchemasEndpoint) 
        { }

        public virtual Schema Get()
        {
            var result = BaseClient.Get(resourcePath);
            return Utils.Deserialize<Schema>(result);
        }
    }
}
