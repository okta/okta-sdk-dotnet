using Okta.Core.Models.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okta.Core.Clients
{
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

        public Schema Get()
        {
            var result = BaseClient.Get(resourcePath);
            return Utils.Deserialize<Schema>(result);
        }
    }
}
