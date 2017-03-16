using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okta.Core.Clients;

namespace Okta.Core.Tests.Clients
{
    [TestClass]
    public class OrgFactorsClientTests
    {

        private Tenant oktaTenant;
        private OktaClient oktaClient;
        private OrgFactorsClient orgFactorsClient;
        private const string FACTOR_ERROR_STRING = "The status of factor {0} from Provider {1} is {2}";


        [TestInitialize()]
        public void InitializeTenant()
        {
            oktaTenant = Helpers.GetTenantFromConfig();
            oktaClient = new OktaClient(oktaTenant.ApiKey, new Uri(oktaTenant.Url));
            orgFactorsClient = oktaClient.GetOrgFactorsClient();
        }


        [TestMethod]
        public void GetSmsFactor()
        {
            Models.Factor factor = orgFactorsClient.GetFactor("okta_sms");
            Assert.IsTrue(factor.FactorType == Models.FactorType.Sms && factor.Provider == Models.FactorProviderType.Okta , "The SMS factor does not exist");
        }

        [TestMethod]
        public void ActivateSms()
        {
            Models.Factor factor = orgFactorsClient.ActivateSms();
            Assert.IsTrue(factor.FactorType == Models.FactorType.Sms && factor.Provider == Models.FactorProviderType.Okta && factor.Status == "ACTIVE", string.Format(FACTOR_ERROR_STRING, factor.FactorType, factor.Provider, factor.Status));
        }

        [TestMethod]
        public void DeactivateSms()
        {
            Models.Factor factor = orgFactorsClient.DeactivateSms();
            Assert.IsTrue(factor.FactorType == Models.FactorType.Sms && factor.Provider == Models.FactorProviderType.Okta && factor.Status == "INACTIVE", string.Format(FACTOR_ERROR_STRING, factor.FactorType, factor.Provider, factor.Status));
        }

        [TestMethod]
        public void ActivateQuestion()
        {
            Models.Factor factor = orgFactorsClient.ActivateQuestion();
            Assert.IsTrue(factor.FactorType == Models.FactorType.Question && factor.Provider == Models.FactorProviderType.Okta && factor.Status == "ACTIVE", string.Format(FACTOR_ERROR_STRING, factor.FactorType, factor.Provider, factor.Status));
        }

        [TestMethod]
        public void DeactivateQuestion()
        {
            Models.Factor factor = orgFactorsClient.DeactivateQuestion();
            Assert.IsTrue(factor.FactorType == Models.FactorType.Question && factor.Provider == Models.FactorProviderType.Okta && factor.Status == "INACTIVE", string.Format(FACTOR_ERROR_STRING, factor.FactorType, factor.Provider, factor.Status));
        }

        [TestMethod]
        public void ActivateOktaVerifyTOTP()
        {
            Models.Factor factor = orgFactorsClient.Activate(Constants.MfaTypes.OktaVerify.ToString());
            Assert.IsTrue(factor.FactorType == Models.FactorType.TotpToken && factor.Provider == Models.FactorProviderType.Okta && factor.Status == "ACTIVE", string.Format(FACTOR_ERROR_STRING, factor.FactorType, factor.Provider, factor.Status));
        }

        [TestMethod]
        public void DeactivateOktaVerifyTOTP()
        {
            Models.Factor factor = orgFactorsClient.Deactivate(Constants.MfaTypes.OktaVerify.ToString());
            Assert.IsTrue(factor.FactorType == Models.FactorType.TotpToken && factor.Provider == Models.FactorProviderType.Okta && factor.Status == "INACTIVE", string.Format(FACTOR_ERROR_STRING, factor.FactorType, factor.Provider, factor.Status));
        }

        [TestMethod]
        public void ActivateGoogleAuthenticator()
        {
            Models.Factor factor = orgFactorsClient.Activate(Constants.MfaTypes.GoogleAuth.ToString());
            Assert.IsTrue(factor.FactorType == Models.FactorType.TotpToken && factor.Provider == Models.FactorProviderType.Google && factor.Status == "ACTIVE", string.Format(FACTOR_ERROR_STRING, factor.FactorType, factor.Provider, factor.Status));
        }

        [TestMethod]
        public void DeactivateGoogleAuthenticator()
        {
            Models.Factor factor = orgFactorsClient.Deactivate(Constants.MfaTypes.GoogleAuth.ToString());
            Assert.IsTrue(factor.FactorType == Models.FactorType.TotpToken && factor.Provider == Models.FactorProviderType.Google && factor.Status == "INACTIVE", string.Format(FACTOR_ERROR_STRING, factor.FactorType, factor.Provider, factor.Status));
        }

        [TestMethod]
        public void ActivateOktaVerifyPush()
        {
            Models.Factor factor = orgFactorsClient.Activate(Constants.MfaTypes.OktaVerifyPush.ToString());
            Assert.IsTrue(factor.FactorType == Models.FactorType.Push && factor.Provider == Models.FactorProviderType.Okta && factor.Status == "ACTIVE", string.Format(FACTOR_ERROR_STRING, factor.FactorType, factor.Provider, factor.Status));
        }

        [TestMethod]
        public void DeactivateOktaVerifyPush()
        {
            Models.Factor factor = orgFactorsClient.Deactivate(Constants.MfaTypes.OktaVerifyPush.ToString());
            Assert.IsTrue(factor.FactorType == Models.FactorType.Push && factor.Provider == Models.FactorProviderType.Okta && factor.Status == "INACTIVE", string.Format(FACTOR_ERROR_STRING, factor.FactorType, factor.Provider, factor.Status));
        }

        [TestMethod]
        public void ActivateDuo()
        {
            if (IsFactorSetup(Constants.MfaTypes.Duo))
            {
                Models.Factor factor = orgFactorsClient.Activate(Constants.MfaTypes.Duo);
                Assert.IsTrue(factor.FactorType == Models.FactorType.Web && factor.Provider == Models.FactorProviderType.Duo && factor.Status == "ACTIVE", string.Format(FACTOR_ERROR_STRING, factor.FactorType, factor.Provider, factor.Status));
            }
        }

        [TestMethod]
        public void DeactivateDuo()
        {
            if (IsFactorSetup(Constants.MfaTypes.Duo))
            {
                Models.Factor factor = orgFactorsClient.Deactivate(Constants.MfaTypes.Duo);
                Assert.IsTrue(factor.FactorType == Models.FactorType.Web && factor.Provider == Models.FactorProviderType.Duo && factor.Status == "INACTIVE", string.Format(FACTOR_ERROR_STRING, factor.FactorType, factor.Provider, factor.Status));
            }
        }

        [TestMethod]
        public void ActivateRSA()
        {
            if (IsFactorSetup(Constants.MfaTypes.RSA))
            {
                Models.Factor factor = orgFactorsClient.Activate(Constants.MfaTypes.RSA);
                Assert.IsTrue(factor.FactorType == Models.FactorType.OtpToken && factor.Provider == Models.FactorProviderType.RSA && factor.Status == "ACTIVE", string.Format(FACTOR_ERROR_STRING, factor.FactorType, factor.Provider, factor.Status));
            }
        }

        [TestMethod]
        public void DeactivateRSA()
        {
            if (IsFactorSetup(Constants.MfaTypes.RSA))
            {
                Models.Factor factor = orgFactorsClient.Deactivate(Constants.MfaTypes.RSA);
                Assert.IsTrue(factor.FactorType == Models.FactorType.OtpToken && factor.Provider == Models.FactorProviderType.RSA && factor.Status == "INACTIVE", string.Format(FACTOR_ERROR_STRING, factor.FactorType, factor.Provider, factor.Status));
            }
        }

        [TestMethod]
        public void ActivateSymantec()
        {
            if (IsFactorSetup(Constants.MfaTypes.SymantecVIP))
            {
                Models.Factor factor = orgFactorsClient.Activate(Constants.MfaTypes.SymantecVIP);
                Assert.IsTrue(factor.FactorType == Models.FactorType.OtpToken && factor.Provider == Models.FactorProviderType.Symantec && factor.Status == "ACTIVE", string.Format(FACTOR_ERROR_STRING, factor.FactorType, factor.Provider, factor.Status));
            }
        }

        [TestMethod]
        public void DeactivateSymantec()
        {
            if (IsFactorSetup(Constants.MfaTypes.SymantecVIP))
            {
                Models.Factor factor = orgFactorsClient.Deactivate(Constants.MfaTypes.SymantecVIP);
                Assert.IsTrue(factor.FactorType == Models.FactorType.OtpToken && factor.Provider == Models.FactorProviderType.Symantec && factor.Status == "INACTIVE", string.Format(FACTOR_ERROR_STRING, factor.FactorType, factor.Provider, factor.Status));
            }
        }

       [TestMethod]
        public void ActivateYubikey()
        {
            if (IsFactorSetup(Constants.MfaTypes.Yubikey))
            {
                Models.Factor factor = orgFactorsClient.Activate(Constants.MfaTypes.Yubikey);
                Assert.IsTrue(factor.FactorType == Models.FactorType.HardwareToken && factor.Provider == Models.FactorProviderType.Yubico && factor.Status == "ACTIVE", string.Format(FACTOR_ERROR_STRING, factor.FactorType, factor.Provider, factor.Status));
            }
        }

        [TestMethod]
        public void DeactivateYubikey()
        {
            if (IsFactorSetup(Constants.MfaTypes.Yubikey))
            {
                Models.Factor factor = orgFactorsClient.Deactivate(Constants.MfaTypes.Yubikey);
                Assert.IsTrue(factor.FactorType == Models.FactorType.HardwareToken && factor.Provider == Models.FactorProviderType.Yubico && factor.Status == "INACTIVE", string.Format(FACTOR_ERROR_STRING, factor.FactorType, factor.Provider, factor.Status));
            }
        }


        private bool IsFactorSetup(string factorId)
        {
            bool bNotSetup = false;
            PagedResults<Models.Factor> factors = orgFactorsClient.GetList();

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
