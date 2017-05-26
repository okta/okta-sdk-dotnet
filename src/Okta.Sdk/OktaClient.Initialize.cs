using Microsoft.Extensions.Configuration;
using Okta.Sdk.Abstractions;
using System;
using System.IO;

namespace Okta.Sdk
{
    public partial class OktaClient
    {
        public OktaClient(ApiClientConfiguration apiClientConfiguration = null)
        {
            string configurationFileRoot = null; // TODO find the application root directory at runtime?

            var homeOktaJsonLocation = HomePath.Resolve("~", ".okta", "okta.json");
            var homeOktaYamlLocation = HomePath.Resolve("~", ".okta", "okta.yaml");

            var applicationAppSettingsLocation = Path.Combine(configurationFileRoot ?? string.Empty, "appsettings.json");
            var applicationOktaJsonLocation = Path.Combine(configurationFileRoot ?? string.Empty, "okta.json");
            var applicationOktaYamlLocation = Path.Combine(configurationFileRoot ?? string.Empty, "okta.yaml");

            //var configBuilder = new ConfigurationBuilder()
            //    .AddYamlFile(homeOktaYamlLocation, optional: true, root: "okta")
            //    .AddJsonFile(homeOktaJsonLocation, optional: true, root: "okta")
            //    .AddJsonFile(applicationAppSettingsLocation, optional: true)
            //    .AddYamlFile(applicationOktaYamlLocation, optional: true, root: "okta")
            //    .AddJsonFile(applicationOktaJsonLocation, optional: true, root: "okta")
            //    .AddEnvironmentVariables("okta", "_", root: "okta")
            //    .AddObject(apiClientConfiguration, root: "okta");

            //var config = configBuilder.Build();

            throw new NotImplementedException();
        }
    }
}
