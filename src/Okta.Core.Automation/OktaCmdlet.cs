using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using Okta.Core.Clients;

namespace Okta.Core.Automation
{
    [Cmdlet(VerbsCommunications.Connect, "Okta")]
    public class OktaCmdlet : PSCmdlet
    {
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Api token to connect to Okta"
        )]
        [Alias("ApiToken")]
        public string Token { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Subdomain to connect to a production instance of Okta"
        )]
        public string Subdomain { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Full Okta domain (used for alternative environments like oktapreview)"
        )]
        public string FullDomain { get; set; }

        internal static OktaClient Client { get; set; }
        protected override void BeginProcessing()
        {
            if (Client == null)
            {
                var oktaSettings = new OktaSettings()
                {
                    ApiToken = Token,
                    BaseUri = String.IsNullOrEmpty(FullDomain) ? null : new Uri(FullDomain),
                    Subdomain = Subdomain
                };

                Client = new OktaClient(oktaSettings);
            }
        }

        private void PromptForLogin()
        {
            if (String.IsNullOrEmpty(Token))
            {
                var response = this.InvokeCommand.InvokeScript("Read-Host", "Enter your API Token");
                Token = response.First().BaseObject.ToString();
                WriteVerbose("This is the token " + Token);
            }

            var oktaSettings = new OktaSettings()
            {
                ApiToken = Token,
                BaseUri = String.IsNullOrEmpty(FullDomain) ? null : new Uri(FullDomain),
                Subdomain = Subdomain
            };

            Client = new OktaClient(oktaSettings);
        }
    }
}
