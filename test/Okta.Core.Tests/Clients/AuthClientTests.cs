using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okta.Core.Clients;
using Okta.Core.Models;
using System.Collections.Generic;

namespace Okta.Core.Tests.Clients
{
    [TestClass]
    public class AuthClientTests
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

        [DataSource(TestConstants.USERS_DATASOURCE_NAME)]
        [TestMethod]
        public void AuthEnrollQuestionFactor()
        {
            string strEx = string.Empty;
            string strStatus = string.Empty;

            TestUser dbUser = Helpers.GetUser(TestContext);

            if (dbUser.Activate)
            {
                try
                {
                    var authClient = oktaClient.GetAuthClient();
                    AuthResponse authResponse = authClient.Authenticate(dbUser.Login, dbUser.Password);

                    if (authResponse.Status == Models.AuthStatus.MfaEnroll && authResponse.StateToken != null) //there is an MFA policy that requires the user to enroll
                    {
                        var usersClient = oktaClient.GetUsersClient();
                        User user = usersClient.GetByUsername(dbUser.Login);
                        var userFactorClient = oktaClient.GetUserFactorsClient(user);
                        List<Factor> userFactors = userFactorClient.GetFactorCatalog();
                        Factor questionFactor = new Factor();
                        //foreach (Factor factor in userFactors)
                        //{
                        //    if(factor.FactorType == Models.FactorType.Question)
                        //    {
                        //        questionFactor = factor;
                        //        break;
                        //    }
                        //}
                        if (questionFactor != null)
                        {
                            List<Question> questions = userFactorClient.GetQuestions();
                            if (questions != null && questions.Count > 0)
                            {
                                questionFactor.Provider = Models.FactorProviderType.Okta;
                                questionFactor.FactorType = Models.FactorType.Question;
                                questionFactor.Profile.QuestionType = questions[0].QuestionType;
                                questionFactor.Profile.Answer = "This is a test answer";
                                authResponse = authClient.Enroll(authResponse.StateToken, questionFactor);
                                strStatus = authResponse.Status;
                            }
                        }
                    }
                }
                catch (OktaException e)
                {
                    strEx = string.Format("Error Code: {0} - Summary: {1} - Message: {2}", e.ErrorCode, e.ErrorSummary, e.Message);
                }
                catch (Exception ex)
                {
                    strEx = ex.ToString();
                }
            }
        }
    }
}
