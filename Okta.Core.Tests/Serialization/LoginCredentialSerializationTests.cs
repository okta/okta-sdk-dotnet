using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Okta.Core.Models;

namespace Okta.Core.Tests.Serialization
{
    //[TestClass]
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
            var result = JsonConvert.DeserializeObject<LoginCredentials>(LoginCredentialSampleData, new OktaJsonConverter());
            Assert.IsNotNull(result.RecoveryQuestion.Question);
            Assert.IsNotNull(result.Provider.Type);
            Assert.IsNotNull(result.Provider.Name);
        }
    }
}
