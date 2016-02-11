using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okta.Core.Clients;
using System.Configuration;

namespace Okta.Core.Tests.Clients
{
    [TestClass]
    public class UsersClientTests
    {

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        private Tenant oktaTenant;
        private OktaClient oktaClient;
        private string strDateSuffix;

        [TestInitialize()]
        public void InitializeTenant()
        {
            oktaTenant = Helpers.GetTenantFromConfig();
            oktaClient = new OktaClient(oktaTenant.ApiKey, new Uri(oktaTenant.Url));
            strDateSuffix = DateTime.Now.ToString("yyyy.MM.dd.hh.mm.ss.ff");
        }

        //[TestMethod]
        //[DataSource(Constants.TEST_USERS_TABLE)]
        //public void GetAllUsers()
        //{
        //    var usersClient = oktaClient.GetUsersClient();

        //    foreach (var user in usersClient)
        //    {
        //        string userLogin = user.Profile.Login;
        //    }
        //}

        [TestMethod]
        [DataSource(TestConstants.USERS_DATASOURCE_NAME)]
        public void CreateUser()
        {
            TestUser dbUser = Helpers.GetUser(TestContext);
            string strEx = string.Empty;
            Models.User oktaUser = CreateUser(dbUser, out strEx);

            Assert.IsNotNull(oktaUser, "Okta User {0} could not be created: {1}", dbUser.Login, strEx);
            
            Assert.IsTrue(oktaUser.Status == (dbUser.Activate ? Models.UserStatus.Provisioned : Models.UserStatus.Staged) , "Okta User {0} status is {1}", dbUser.Login, oktaUser.Status);
        }

        [TestMethod]
        [DataSource(TestConstants.USERS_DATASOURCE_NAME)]
        public void ActivateUser()
        {
            TestUser dbUser = Helpers.GetUser(TestContext);
            Assert.IsTrue(RegexUtilities.IsValidEmail(dbUser.Login), string.Format("Okta user login {0} is not valid", dbUser.Login));
            Assert.IsTrue(RegexUtilities.IsValidEmail(dbUser.Email), string.Format("Okta user email {0} is not valid", dbUser.Email));

            string strEx = string.Empty;
            Models.User existingUser = null;
            Models.User updatedUser = null;
            string strUserLogin = dbUser.Login;
            string strNewUserLogin = string.Empty;
            Uri uriActivation = null;
            try
            {
                var usersClient = oktaClient.GetUsersClient();
                existingUser = usersClient.GetByUsername(strUserLogin);

                if (existingUser != null && existingUser.Status == Models.UserStatus.Staged)
                {
                    //the second sendEmail parameter is set to false in order to retrieve a non-null uriActivation object
                    uriActivation = usersClient.Activate(existingUser, false);
                    updatedUser = usersClient.Get(existingUser.Id);
                }
            }
            catch (OktaException e)
            {
                strEx = string.Format("Error Code: {0} - Summary: {1} - Message: {2}", e.ErrorCode, e.ErrorSummary, e.Message);
            }

            Assert.IsNotNull(existingUser, "Okta User {0} could not be retrieved: {1}", dbUser.Login, strEx);
            if (updatedUser != null)
            {
                Assert.IsTrue(updatedUser.Status == Models.UserStatus.Provisioned, "Okta User {0} status is {1}", dbUser.Login, existingUser.Status);
                //Assert.IsNotNull(uriActivation, "Activation Url for Okta User {0} is not present", dbUser.Login);
            }
        }

        [TestMethod]
        [DataSource(TestConstants.USERS_DATASOURCE_NAME)]
        public void SetPassword()
        {
            TestUser dbUser = Helpers.GetUser(TestContext);
            Assert.IsTrue(RegexUtilities.IsValidEmail(dbUser.Login), string.Format("Okta user login {0} is not valid", dbUser.Login));
            Assert.IsTrue(RegexUtilities.IsValidEmail(dbUser.Email), string.Format("Okta user email {0} is not valid", dbUser.Email));

            string strEx = string.Empty;
            Models.User existingUser = null;
            string strUserLogin = dbUser.Login;
            string strNewUserLogin = string.Empty;

            try
            {
                var usersClient = oktaClient.GetUsersClient();

                existingUser = usersClient.Get(strUserLogin);

                if (existingUser != null)
                {
                    existingUser = usersClient.SetPassword(existingUser, dbUser.Password);
                    //existingUser = usersClient.SetCredentials(existingUser, new Models.LoginCredentials
                    //{
                    //    Password =
                    //    { Value = dbUser.Password },
                    //    Provider = {
                    //    Name = "OKTA",
                    //    Type = "OKTA"
                    //}
                    //});
                }
            }
            catch (OktaException e)
            {
                strEx = string.Format("Error Code: {0} - Summary: {1} - Message: {2}", e.ErrorCode, e.ErrorSummary, e.Message);
            }

            Assert.IsNotNull(existingUser, "Okta User {0} could not be retrieved: {1}", dbUser.Login, strEx);
            if (existingUser.Status != Models.UserStatus.Staged)
            {
                Assert.IsTrue(existingUser.Status == Models.UserStatus.Active, "Okta User {0} status is {1}", dbUser.Login, existingUser.Status);
            }
        }

        [TestMethod]
        [DataSource(TestConstants.USERS_DATASOURCE_NAME)]
        public void AuthenticateUser()
        {
            TestUser dbUser = Helpers.GetUser(TestContext);
            Assert.IsTrue(RegexUtilities.IsValidEmail(dbUser.Login), string.Format("Okta user login {0} is not valid", dbUser.Login));
            Assert.IsTrue(RegexUtilities.IsValidEmail(dbUser.Email), string.Format("Okta user email {0} is not valid", dbUser.Email));

            string strEx = string.Empty;
            //Models.User existingUser = null;
            string strUserLogin = dbUser.Login;
            string strNewUserLogin = string.Empty;
            Models.AuthResponse authResponse = null;

            try
            {
                //var usersClient = oktaClient.GetUsersClient();

                var authClient = oktaClient.GetAuthClient();

                authResponse = authClient.Authenticate(dbUser.Login, dbUser.Password);
                //existingUser = usersClient.GetByUsername(strUserLogin);

                //if (existingUser != null)
                //{
                //    existingUser = usersClient.SetPassword(existingUser, dbUser.Password);
                //}

            }
            catch (OktaException e)
            {
                strEx = string.Format("Error Code: {0} - Summary: {1} - Message: {2}", e.ErrorCode, e.ErrorSummary, e.Message);
            }

            Assert.IsNotNull(authResponse, "Authentication for Okta User {0} failed: {1}", dbUser.Login, strEx);
            Assert.IsTrue(authResponse.Status == "SUCCESS", "Authentication for Okta User {0} failed. Auth Status is {1}", dbUser.Login, authResponse.Status);
            //if (existingUser.Status != Models.UserStatus.Staged)
            //{
            //    Assert.IsTrue(existingUser.Status == Models.UserStatus.Active, "Okta User {0} status is {1}", dbUser.Login, existingUser.Status);
            //}
        }

        [TestMethod]
        [DataSource(TestConstants.USERS_DATASOURCE_NAME)]
        public void RenameUser()
        {
            TestUser dbUser = Helpers.GetUser(TestContext);
            Assert.IsTrue(RegexUtilities.IsValidEmail(dbUser.Login), string.Format("Okta user login {0} is not valid", dbUser.Login));
            Assert.IsTrue(RegexUtilities.IsValidEmail(dbUser.Email), string.Format("Okta user email {0} is not valid", dbUser.Email));
            string strEx = string.Empty;
            Models.User existingUser = null;
            string strUserLogin = dbUser.Login;
            string strNewUserLogin = string.Empty;

            try
            {
                var usersClient = oktaClient.GetUsersClient();

                existingUser = usersClient.GetByUsername(strUserLogin);

                if (existingUser != null)
                {
                    string[] arUserLogin = strUserLogin.Split('@');
                    //changing the username to make it unique (since it's not yet possible to delete Okta users)
                    strNewUserLogin = string.Format("{0}_{1}@{2}", arUserLogin[0], strDateSuffix, arUserLogin[1]);
                    existingUser.Profile.Login = strNewUserLogin;
                    existingUser = usersClient.Update(existingUser);
                    Assert.IsNotNull(existingUser, "Okta User {0} could not be retrieved: {1}", dbUser.Login, strEx);
                    Assert.IsTrue(existingUser.Profile.Login == strNewUserLogin, "Okta User Login could not be renamed from {0} to {1}", dbUser.Login, strNewUserLogin);
                }
            }
            catch (OktaException e)
            {
                strEx = string.Format("Error Code: {0} - Summary: {1} - Message: {2}", e.ErrorCode, e.ErrorSummary, e.Message);
            }

        }

        private Models.User GetUser(string strUserId)
        {
            Models.User user = null;
            var usersClient = oktaClient.GetUsersClient();
            return user;
        }

        private Models.User CreateUser(TestUser dbUser, out string strEx)
        {
            Models.User oktaUser = null;
            strEx = string.Empty;

            Assert.IsTrue(RegexUtilities.IsValidEmail(dbUser.Login), string.Format("Okta user login {0} is not valid", dbUser.Login));
            Assert.IsTrue(RegexUtilities.IsValidEmail(dbUser.Email), string.Format("Okta user email {0} is not valid", dbUser.Email));
            string strUserLogin = dbUser.Login;

            try
            {
                var usersClient = oktaClient.GetUsersClient();

                Models.User user = new Models.User(strUserLogin, dbUser.Email, dbUser.FirstName, dbUser.LastName);

                Models.User existingUser = usersClient.GetByUsername(strUserLogin);

                //in case our user already exists, we create a new user with a "more unique" username
                if (existingUser != null)
                {
                    string[] arUserLogin = strUserLogin.Split('@');
                    //changing the username to make it unique (since it's not yet possible to delete Okta users)
                    strUserLogin = string.Format("{0}_{1}@{2}", arUserLogin[0], strDateSuffix, arUserLogin[1]);
                    user = new Models.User(strUserLogin, dbUser.Email, dbUser.FirstName, dbUser.LastName);
                }

                oktaUser = usersClient.Add(user, dbUser.Activate);

            }
            catch (OktaException e)
            {
                strEx = string.Format("Error Code: {0} - Summary: {1} - Message: {2}", e.ErrorCode, e.ErrorSummary, e.Message);
            }

            return oktaUser;
        }

        //private Tenant getTenant(TestContext context)
        //{
        //    Tenant tenant = new Tenant
        //    {
        //        Id = Convert.ToInt32(context.DataRow["Id"]),
        //        Url = Convert.ToString(context.DataRow["Url"]),
        //        ApiKey = Convert.ToString(context.DataRow["ApiKey"])

        //    };

        //    return tenant;
        //}

    }
}
