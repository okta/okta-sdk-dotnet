using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okta.Core.Clients;

namespace Okta.Core.Tests.Clients
{
    [TestClass]
    public class UserFactorsClientTests
    {

        private Tenant oktaTenant;
        private OktaClient oktaClient;
        private const string FACTOR_ERROR_STRING = "The status of factor {0} from Provider {1} is {2}";
        private OrgFactorsClient orgFactorsClient;

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestInitialize()]
        public void InitializeTenant()
        {
            oktaTenant = Helpers.GetTenantFromConfig();
            oktaClient = new OktaClient(oktaTenant.ApiKey, new Uri(oktaTenant.Url));
            orgFactorsClient = oktaClient.GetOrgFactorsClient();
        }


        [TestMethod]
        [DataSource(TestConstants.USERS_DATASOURCE_NAME)]
        public void AssignFactorToUser()
        {
            TestUser dbUser = Helpers.GetUser(TestContext);
            string strEx = string.Empty;

            if (dbUser.Factors != null && dbUser.Factors.Count > 0)
            {
                Models.User existingUser = null;
                string strUserLogin = dbUser.Login;

                try
                {
                    var usersClient = oktaClient.GetUsersClient();
                    existingUser = usersClient.Get(strUserLogin);

                    Assert.IsNotNull(existingUser, "Okta user {0} does not exist", dbUser.Login);

                    if (existingUser != null)
                    {
                        UserFactorsClient factorsClient = oktaClient.GetUserFactorsClient(existingUser);

                        foreach(string strFactor in dbUser.Factors)
                        {
                            Models.Factor orgFactor = orgFactorsClient.GetFactor(strFactor);
                            if(orgFactor!=null && orgFactor.Status == "ACTIVE")
                            {
                                Models.Factor userFactor = factorsClient.Enroll(orgFactor);
                                Assert.IsTrue(userFactor.Status == "ACTIVE", string.Format("Factor {0} status for user {1} is {2}", orgFactor.Id, dbUser.Login, userFactor.Status));
                            }
                        }
                    }

                }
                catch (OktaException e)
                {
                    strEx = string.Format("Error Code: {0} - Summary: {1} - Message: {2}", e.ErrorCode, e.ErrorSummary, e.Message);
                }
            }
        }
    }
}
