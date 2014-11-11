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
    /// A client to manage <see cref="Factor"/>s for an org
    /// </summary>
    public class OrgFactorsClient : ApiClient<Factor>
    {
        public OrgFactorsClient(IOktaHttpClient clientWrapper) : base(clientWrapper, Constants.EndpointV1 + Constants.OrgEndpoint + Constants.FactorsEndpoint) { }
        public OrgFactorsClient(OktaSettings oktaSettings) : base(oktaSettings, Constants.EndpointV1 + Constants.OrgEndpoint + Constants.FactorsEndpoint) { }
        public OrgFactorsClient(string apiToken, string subdomain) : base(apiToken, subdomain, Constants.EndpointV1 + Constants.OrgEndpoint + Constants.FactorsEndpoint) { }

        // TODO: Maybe try a TryActivate/TryDeactivate

        public Factor Activate(string id)
        {
            var response = PerformLifecycle(id, "activate");
            return Utils.Deserialize<Factor>(response);
        }

        public Factor Activate(Factor factor)
        {
            var response = PerformLifecycle(factor, "activate");
            return Utils.Deserialize<Factor>(response);
        }

        public Factor Deactivate(string id)
        {
            var response = PerformLifecycle(id, "deactivate");
            return Utils.Deserialize<Factor>(response);
        }

        public Factor Deactivate(Factor factor)
        {
            var response = PerformLifecycle(factor, "deactivate");
            return Utils.Deserialize<Factor>(response);
        }

        public Factor ActivateQuestion()
        {
            return Activate(Constants.MfaTypes.SecurityQuestion);
        }

        public Factor DeactivateQuestion()
        {
            return Deactivate(Constants.MfaTypes.SecurityQuestion);
        }

        public Factor ActivateSms()
        {
            return Activate(Constants.MfaTypes.SMS);
        }

        public Factor DeactivateSms()
        {
            return Deactivate(Constants.MfaTypes.SMS);
        }
    }
}
