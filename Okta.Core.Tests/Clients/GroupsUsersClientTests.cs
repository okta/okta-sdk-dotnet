using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okta.Core.Clients;

namespace Okta.Core.Tests.Clients
{
    [TestClass]
    public class GroupsUsersClientTests
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        private Tenant oktaTenant;
        private OktaClient oktaClient;

        [TestInitialize()]
        public void InitializeTenant()
        {
            oktaTenant = Helpers.GetTenantFromConfig();
            oktaClient = new OktaClient(oktaTenant.ApiKey, new Uri(oktaTenant.Url));
        }


        [TestMethod]
        [DataSource(TestConstants.GROUPS_DATASOURCE_NAME)]
        public void AddUser()
        {
        }

        [TestMethod]
        public void RemoveUser()
        {
        }
    }
}
