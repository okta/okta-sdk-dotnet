using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okta.Core.Clients;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Okta.Core.Tests.Clients
{
    class Helpers
    {
        internal static Tenant GetTenantFromConfig()
        {
            Tenant tenant = new Tenant
            {
                Url = ConfigurationManager.AppSettings["TenantUrl"],
                ApiKey = ConfigurationManager.AppSettings["ApiKey"],
                TestUserLogin = ConfigurationManager.AppSettings["TestUserLogin"],
                TestUserId = ConfigurationManager.AppSettings["TestUserId"]
            };

            return tenant;
        }

        internal static TestUser GetUser(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext context)
        {
            TestUser user = new TestUser
            {
                Id = Convert.ToInt32(context.DataRow["Id"]),
                Login = Convert.ToString(context.DataRow["Login"]),
                FirstName = Convert.ToString(context.DataRow["FirstName"]),
                LastName = Convert.ToString(context.DataRow["LastName"]),
                Email = Convert.ToString(context.DataRow["Email"]),
                Password = Convert.ToString(context.DataRow["Password"]),
            };

            //if Activate is not checked, the column value will be null, not false
            if (context.DataRow["Activate"] != System.DBNull.Value)
            {
                user.Activate = Convert.ToBoolean(context.DataRow["Activate"]);
            }

            if (context.DataRow["Factors"] != null && !(context.DataRow["Factors"] is System.DBNull) && !string.IsNullOrEmpty((string)context.DataRow["Factors"]))
            {
                string strFactors = (string)context.DataRow["Factors"];
                List<string> lstFactors = strFactors.Split(',').ToList<string>();
                user.Factors = lstFactors;
            }

            return user;
        }

        internal static TestGroup GetGroup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext context)
        {
            TestGroup group = new TestGroup
            {
                Id = Convert.ToInt32(context.DataRow["Id"]),
                Name = Convert.ToString(context.DataRow["Name"]),
                Description = Convert.ToString(context.DataRow["Description"]),
            };

            if (context.DataRow["Users"] != null && !(context.DataRow["Users"] is System.DBNull) && !string.IsNullOrEmpty((string)context.DataRow["Users"]))
            {
                string strUsers = (string)context.DataRow["Users"];
                group.Users = strUsers.Split(',').ToList<string>();
            }
            return group;
        }

        internal static TestCustomAttribute GetCustomAttribute(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext context)
        {
            TestCustomAttribute attr = new TestCustomAttribute
            {
                Login = Convert.ToString(context.DataRow["Login"]),
                Name = Convert.ToString(context.DataRow["AttributeName"]),
                Value = Convert.ToString(context.DataRow["AttributeValue"]),
            };

            if (context.DataRow["MultiValued"] != System.DBNull.Value)
            {
                attr.MultiValued = Convert.ToBoolean(context.DataRow["MultiValued"]);
            }
            return attr;
        }

        internal static Models.User CreateUser(OktaClient oktaClient, TestUser dbUser, string strDateSuffix, out string strEx)
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

                //in case our user already exists, we create a new user with a "more unique" username attribute
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

        internal static Models.Group CreateGroup(OktaClient oktaClient, TestGroup dbGroup, out string strEx)
        {
            Models.Group oktaGroup = null;
            strEx = string.Empty;

            string strGroupName = dbGroup.Name;
            try
            {
                var groupsClient = oktaClient.GetGroupsClient();
                Models.Group group = new Models.Group(strGroupName, dbGroup.Description);
                Models.Group existingGroup = groupsClient.GetByName(strGroupName);

                if (existingGroup == null)
                {
                    oktaGroup = groupsClient.Add(group);
                }
                else
                {
                    strEx = string.Format("Group {0} already exists", existingGroup.Profile.Name);
                }
            }
            catch (OktaException e)
            {
                strEx = string.Format("Error Code: {0} - Summary: {1} - Message: {2}", e.ErrorCode, e.ErrorSummary, e.Message);
            }
            return oktaGroup;
        }

        internal static string GetRandomString()
        {

            const string allowedChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz#@$^*()";
            Random rng = new Random();

            return RandomString(allowedChars, 8, 16, rng);
        }

        private static string RandomString(
            string allowedChars,
            int minLength,
            int maxLength,

            Random rng)
        {
            char[] chars = new char[maxLength];
            int setLength = allowedChars.Length;

            int length = rng.Next(minLength, maxLength + 1);

            for (int i = 0; i < length; ++i)
            {
                chars[i] = allowedChars[rng.Next(setLength)];
            }

            return new string(chars, 0, length);

        }
    }
}
