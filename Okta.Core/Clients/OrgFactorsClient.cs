namespace Okta.Core.Clients
{
    using Okta.Core.Models;

    /// <summary>
    /// A client to manage <see cref="Factor"/>s for an org
    /// </summary>
    public class OrgFactorsClient : ApiClient<Factor>
    {
        public OrgFactorsClient(IOktaHttpClient clientWrapper) : base(clientWrapper, Constants.EndpointV1 + Constants.OrgEndpoint + Constants.FactorsEndpoint) { }
        public OrgFactorsClient(OktaSettings oktaSettings) : base(oktaSettings, Constants.EndpointV1 + Constants.OrgEndpoint + Constants.FactorsEndpoint) { }
        public OrgFactorsClient(string apiToken, string subdomain) : base(apiToken, subdomain, Constants.EndpointV1 + Constants.OrgEndpoint + Constants.FactorsEndpoint) { }

        // TODO: Maybe try a TryActivate/TryDeactivate
        public virtual Factor Activate(string id)
        {
            var response = PerformLifecycle(id, "activate");
            return Utils.Deserialize<Factor>(response);
        }

        public virtual Factor Activate(Factor factor)
        {
            var response = PerformLifecycle(factor, "activate");
            return Utils.Deserialize<Factor>(response);
        }

        public virtual Factor Deactivate(string id)
        {
            var response = PerformLifecycle(id, "deactivate");
            return Utils.Deserialize<Factor>(response);
        }

        public virtual Factor Deactivate(Factor factor)
        {
            var response = PerformLifecycle(factor, "deactivate");
            return Utils.Deserialize<Factor>(response);
        }

        public virtual Factor ActivateQuestion()
        {
            return Activate(Constants.MfaTypes.SecurityQuestion);
        }

        public virtual Factor DeactivateQuestion()
        {
            return Deactivate(Constants.MfaTypes.SecurityQuestion);
        }

        public virtual Factor ActivateSms()
        {
            return Activate(Constants.MfaTypes.SMS);
        }

        public virtual Factor DeactivateSms()
        {
            return Deactivate(Constants.MfaTypes.SMS);
        }

        /// <summary>
        /// Activates the Yubikey factor - will throws a "Yubikey seed file is not uploaded yet." error if a Yubikey seed file has not been uploaded yet
        /// </summary>
        /// <returns></returns>
        public virtual Factor ActivateYubikey()
        {
            return Activate(Constants.MfaTypes.Yubikey);
        }

        public virtual Factor DeactivateYubikey()
        {
            return Deactivate(Constants.MfaTypes.Yubikey);
        }

        public virtual Factor GetFactor(string strMfaType)
        {
            Factor factor = null;
            PagedResults<Models.Factor> factors = this.GetList();

            foreach (Models.Factor f in factors.Results)
            {
                if (f.Id == strMfaType)
                {
                    break;
                }
            }
            return factor;
        }

        public virtual bool IsFactorSetup(string factorId)
        {
            bool bNotSetup = false;
            PagedResults<Models.Factor> factors = this.GetList();

            foreach (Models.Factor f in factors.Results)
            {
                if (f.Id == factorId)
                {
                    if (f.Status == "NOT_SETUP")
                    {
                        bNotSetup = true;
                    }
                    break;
                }
            }
            return !bNotSetup;
        }
    }
}
