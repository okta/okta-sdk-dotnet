using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okta.Core.Clients;
using Okta.Core.Models;

namespace Okta.Core.Tests.Clients
{
    [TestClass]
    public class GroupsUsersClientTests
    {
        private string strDateSuffix;

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
            strDateSuffix = DateTime.Now.ToString("yyyy.MM.dd.hh.mm.ss.ff");
        }

        [TestMethod]
        [DataSource(TestConstants.GROUPS_DATASOURCE_NAME)]
        public void AddUserToGroup()
        {
            string strEx = string.Empty;

            try
            {

            var groupsClient = oktaClient.GetGroupsClient();

                TestUser dbUser = new TestUser
                {
                    Id = 1,
                    Login = "testuser_addtogroup@company.com",
                    FirstName = "John",
                    LastName = "Add To Group",
                    Email = "user01@mailinator.com",
                    Password = "Pass@word1",
                };
                TestGroup dbGroup = Helpers.GetGroup(TestContext);

            Group group = groupsClient.GetByName(dbGroup.Name);
            if (group == null)
            {
                group = Helpers.CreateGroup(oktaClient, dbGroup, out strEx);
            }

            var groupsUserClient = oktaClient.GetGroupUsersClient(group);
            Models.User oktaUser = Helpers.CreateUser(oktaClient, dbUser, strDateSuffix, out strEx);
            groupsUserClient.Add(oktaUser);
            }
            catch (OktaException e)
            {
                strEx = string.Format("Okta Error Code: {0} - Summary: {1} - Message: {2}", e.ErrorCode, e.ErrorSummary, e.Message);
            }
            catch (Exception ex)
            {
                strEx = string.Format("Generic Error: {0} ", ex.Message);
            }


        }

        [TestMethod]
        public void RemoveUser()
        {
        }
    }
}
