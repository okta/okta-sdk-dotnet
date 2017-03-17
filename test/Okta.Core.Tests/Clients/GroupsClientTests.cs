using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okta.Core.Clients;
using Okta.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okta.Core.Tests.Clients
{
    [TestClass]
    public class GroupsClientTests
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
        //[DataSource("OktaGroups")]
        public void GetAllGroups()
        {
            var groupsClient = oktaClient.GetGroupsClient();

            foreach (var group in groupsClient)
            {
                string groupName = group.Profile.Name;
            }
        }

        [TestMethod]
        //[DataSource("OktaGroups")]
        public void GetGroupById()
        {
            var groupsClient = oktaClient.GetGroupsClient();

            Group group = groupsClient.Get("00g5qi7bkxT5pcEbQ0h7");
            string groupName = group.Profile.Name;
        }

        [TestMethod]
        [DataSource(TestConstants.GROUPS_DATASOURCE_NAME)]
        public void GetGroupByName()
        {
            var groupsClient = oktaClient.GetGroupsClient();
            var dbGroup = Helpers.GetGroup(TestContext);
            string strGroupName = string.Empty;

            Group group = groupsClient.GetByName(dbGroup.Name);
            if (group != null)
            {
                strGroupName = group.Profile.Name;
            }

            Assert.IsTrue(group != null, "Could not find group {0}", dbGroup.Name);

            Assert.IsTrue(strGroupName.ToLower() == dbGroup.Name.ToLower(), "The name of the found group is {0} while you were searching for {1}", strGroupName, dbGroup.Name);

        }

        [TestMethod]
        [DataSource(TestConstants.GROUPS_DATASOURCE_NAME)]
        public void CreateGroup()
        {
            TestGroup dbGroup = Helpers.GetGroup(TestContext);
            string strEx = string.Empty;

            Models.Group oktaGroup = Helpers.CreateGroup(oktaClient, dbGroup, out strEx);

            Assert.IsNotNull(oktaGroup, "Okta Group {0} could not be created: {1}", dbGroup.Name, strEx);

            Assert.IsTrue(oktaGroup.GroupType == TestConstants.OKTA_GROUP_TYPE, "Group type for {0} is {1}", oktaGroup.Profile.Name, oktaGroup.GroupType);
            Assert.IsTrue(oktaGroup.Profile.Name == dbGroup.Name, "Group name is {0} instead of {1}", oktaGroup.Profile.Name, dbGroup.Name);
            Assert.IsTrue(oktaGroup.Profile.Description == dbGroup.Description, "Group description is {0} instead of {1}", oktaGroup.Profile.Description, dbGroup.Description);
        }

        [TestMethod]
        [DataSource(TestConstants.GROUPS_DATASOURCE_NAME)]
        public void DeleteGroup()
        {
            TestGroup dbGroup = Helpers.GetGroup(TestContext);
            string strEx = string.Empty;
            var groupsClient = oktaClient.GetGroupsClient();

            Group oktaGroup = groupsClient.GetByName(dbGroup.Name);

            Assert.IsNotNull(oktaGroup, "Okta Group {0} does not exist.", dbGroup.Name);

            try
            {
                groupsClient.Remove(oktaGroup);
            }
            catch (OktaException e)
            {
                strEx = string.Format("Okta Error Code: {0} - Summary: {1} - Message: {2}", e.ErrorCode, e.ErrorSummary, e.Message);
            }
            catch (Exception ex)
            {
                strEx = string.Format("Generic Error: {0} ", ex.Message);
            }

            Assert.IsTrue(string.IsNullOrEmpty(strEx), "Exception occurred while deleting group {0}: {1}", dbGroup.Name, strEx);
        }


    }
}
