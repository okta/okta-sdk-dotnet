using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okta.Core.Clients;
using Okta.Core.Models;
using System.Collections.Generic;

namespace Okta.Core.Tests.Clients
{
    [TestClass]
    public class AppsClientTests
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
        public void AddSwaApp()
        {
            try
            {
                App app = App.BuildSwaPlugin("http://localhost/login", "username", "password", "btnLogin", "Test SWA App 1");
                AppsClient appsClient = oktaClient.GetAppsClient();
                app = appsClient.Add(app);
            }
            catch (OktaException oe)
            {
                string strError = oe.ErrorSummary;
            }
        }

        [TestMethod]
        public void AddWSFedApp()
        {
            try
            {
                App app = App.BuildWSFed("Test WS-Fed App", "urn:example:app", "SampleGroup", "samAccountName", "urn:example:apprealm", "https://apps.example.com/wsfed/app1/replyto", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname|${user.firstName}|,http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname|${user.lastName}|", "urn:oasis:names:tc:SAML:2.0:nameid-format:persistent", "urn:oasis:names:tc:SAML:2.0:ac:classes:Password", "https://example.com/app1", true, "app1.*", usernameAttribute: "upnAndUsername");
                Hide visibility = new Hide
                {
                    Web = true,
                    IOS = true
                };
                app.Visibility.Hide = visibility;
                AppsClient appsClient = oktaClient.GetAppsClient();
                app = appsClient.Add(app);
            }
            catch (OktaException oe)
            {
                string strError = oe.ErrorSummary;
            }
        }

        [TestMethod]
        public void RemoveApp()
        {
            try
            {
                AppsClient appsClient = oktaClient.GetAppsClient();
                FilterBuilder filter = new FilterBuilder("status eq \"ACTIVE\"");
                PagedResults<App> apps = appsClient.GetList(nextPage: null, pageSize: 200, filter: filter);
                App selectedApp = null;
                foreach(App app in apps.Results)
                {
                    if (app.Label == "Test SWA App 1" || app.Label  == "Test WS-Fed App")
                    {
                        selectedApp = app;
                        break;
                    }

                }
                try
                {
                    if (selectedApp != null)
                    {
                        appsClient.Deactivate(selectedApp);
                        appsClient.Remove(selectedApp);
                    }

                }
                catch (OktaException oe)
                {
                    string strError = oe.ErrorSummary;
                }
            }
            catch (OktaException oe)
            {
                string strError = oe.ErrorSummary;
            }

        }
    }
}
