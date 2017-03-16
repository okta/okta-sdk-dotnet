using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okta.Core.Models;

namespace Okta.Core.Tests.Serialization
{
    [TestClass]
    public class LoginCredentialSerializationTests
    {
        public const string LoginCredentialSampleData = @"
        {
            'password': {},
            'recovery_question': {
                'question': 'What happens when I update my question'
            },
            'provider': {
                'type': 'OKTA',
                'name': 'OKTA'
            }
        }";

        [TestMethod]
        public void LoginCredentialShouldDeserialize()
        {
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginCredentials>(LoginCredentialSampleData, new OktaJsonConverter());
            Assert.IsNotNull(result.RecoveryQuestion.Question);
            Assert.IsNotNull(result.Provider.Type);
            Assert.IsNotNull(result.Provider.Name);
        }
    }
}
