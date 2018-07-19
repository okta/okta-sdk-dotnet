// <copyright file="OktaClientShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.UnitTests.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class OktaClientShould
    {
        [Fact]
        public async Task GetCollection()
        {
            // Arrange
            var testItems = new[]
            {
                new TestResource { Foo = "foo1" },
                new TestResource { Foo = "foo2", Bar = true },
                new TestResource { Foo = "foo3", Bar = false },
            };
            var mockRequestExecutor = new MockedCollectionRequestExecutor<TestResource>(pageSize: 2, items: testItems);
            var client = new TestableOktaClient(mockRequestExecutor);

            // Act
            var items = await client.GetCollection<TestResource>("https://stuff").ToArray();

            // Assert
            items.Count().Should().Be(3);
            items.ElementAt(0).Foo.Should().Be("foo1");
            items.ElementAt(0).Bar.Should().BeNull();

            items.ElementAt(1).Foo.Should().Be("foo2");
            items.ElementAt(1).Bar.Should().Be(true);

            items.ElementAt(2).Foo.Should().Be("foo3");
            items.ElementAt(2).Bar.Should().Be(false);
        }

        /// <summary>
        /// Ensures that methods that accept either an interface or class type constraint can work with both.
        /// </summary>
        /// <returns>The asynchronous test.</returns>
        [Fact]
        public async Task GetResouceAsConcrete()
        {
            var json = @"{
  ""id"": ""foobar123""
}";
            var mockRequestExecutor = new MockedStringRequestExecutor(json);
            var client = new TestableOktaClient(mockRequestExecutor);

            var app = await client.Applications.GetApplicationAsync<Application>("apps/foobar123");
            app.Id.Should().Be("foobar123");
        }

        /// <summary>
        /// Ensures that methods that accept either an interface or class type constraint can work with both.
        /// </summary>
        /// <returns>The asynchronous test.</returns>
        [Fact]
        public async Task GetResouceAsInterface()
        {
            var json = @"{
  ""id"": ""foobar123""
}";
            var mockRequestExecutor = new MockedStringRequestExecutor(json);
            var client = new TestableOktaClient(mockRequestExecutor);

            var app = await client.Applications.GetApplicationAsync<IApplication>("apps/foobar123");
            app.Id.Should().Be("foobar123");
        }

        [Fact]
        public async Task ThrowApiExceptionFor4xx()
        {
            var rawErrorResponse = @"
{
    ""errorCode"": ""E0000011"",
    ""errorSummary"": ""Invalid token provided"",
    ""errorLink"": ""E0000011"",
    ""errorId"": ""oaelUIU6UZ_RxuqVbi3pxR1ag"",
    ""errorCauses"": []
}";
            var mockRequestExecutor = new MockedStringRequestExecutor(rawErrorResponse, 400);
            var client = new TestableOktaClient(mockRequestExecutor);

            try
            {
                await client.Users.GetUserAsync("12345");
            }
            catch (OktaApiException apiException)
            {
                apiException.Message.Should().Be("Invalid token provided (400, E0000011)");
                apiException.ErrorCode.Should().Be("E0000011");
                apiException.ErrorSummary.Should().Be("Invalid token provided");
                apiException.ErrorLink.Should().Be("E0000011");
                apiException.ErrorId.Should().Be("oaelUIU6UZ_RxuqVbi3pxR1ag");
                apiException.Error.Should().NotBeNull();
            }
        }

        [Fact]
        public async Task IncludeErrorCausesInApiException()
        {
            var rawErrorResponse = @"
{
    ""errorCode"": ""E0000001"",
    ""errorSummary"": ""Api validation failed"",
    ""errorLink"": ""E0000001"",
    ""errorId"": ""oae3xUDal8cTr-_k3gWnVmXhQ"",
    ""errorCauses"": [
        {
            ""errorSummary"": ""Password requirements were not met.""
        },
        {
            ""errorSummary"": ""Another bad thing that happened""
        }
    ]
}";
            var mockRequestExecutor = new MockedStringRequestExecutor(rawErrorResponse, 500);
            var client = new TestableOktaClient(mockRequestExecutor);

            try
            {
                await client.GetAsync<Resource>("/something");
            }
            catch (OktaApiException apiException)
            {
                var expectedMessage = "Api validation failed (500, E0000001): Password requirements were not met., Another bad thing that happened";
                apiException.Message.Should().Be(expectedMessage);
                apiException.ToString().Should().StartWith($"Okta.Sdk.OktaApiException: {expectedMessage}");

                var causes = apiException.ErrorCauses.ToArray();
                causes.Should().HaveCount(2);
                causes.First().ErrorSummary.Should().Be("Password requirements were not met.");
                causes.Last().ErrorSummary.Should().Be("Another bad thing that happened");
            }
        }

        [Fact]
        public void UsePassedHttpClient()
        {
            var testableClient = new TestableHttpClient();
            var client = new OktaClient(
                TestableOktaClient.DefaultFakeConfiguration,
                testableClient);

            Func<Task> act = async () => await client.Users.GetUserAsync("foobar");

            act.Should().Throw<NotImplementedException>()
                .WithMessage("Used the client!");
        }

        public class TestableHttpClient : System.Net.Http.HttpClient
        {
            public override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException("Used the client!");
            }
        }

        /// <summary>
        /// Tests a specific edge case where an object contains an IList{ISomething}.
        /// </summary>
        /// <returns>The asynchronous test.</returns>
        [Fact]
        public async Task RetrieveNestedListOfObjects()
        {
            var samlAppJson = @"{
   ""id"":""0oafrfggz8xxkU6rZ0h7"",
   ""name"":""x_samplesamlcustomapp_2"",
   ""label"":""Sample SAML Custom App"",
   ""status"":""ACTIVE"",
   ""lastUpdated"":""2018-07-19T15:04:22.000Z"",
   ""created"":""2018-07-19T15:04:22.000Z"",
   ""accessibility"":{
      ""selfService"":false,
      ""errorRedirectUrl"":null,
      ""loginRedirectUrl"":null
   },
   ""visibility"":{
      ""autoSubmitToolbar"":false,
      ""hide"":{
         ""iOS"":false,
         ""web"":false
      },
      ""appLinks"":{
         ""x_samplesamlcustomapp_2_link"":true
      }
   },
   ""features"":[

   ],
   ""signOnMode"":""SAML_2_0"",
   ""credentials"":{
      ""userNameTemplate"":{
         ""template"":""${source.login}"",
         ""type"":""BUILT_IN""
      },
      ""signing"":{
         ""kid"":""5QjW-5eYYSrgxIORXHyte6Ys5vwn5gu7uifxPkLpbPA""
      }
   },
   ""settings"":{
      ""app"":{

      },
      ""notifications"":{
         ""vpn"":{
            ""network"":{
               ""connection"":""DISABLED""
            },
            ""message"":null,
            ""helpUrl"":null
         }
      },
      ""signOn"":{
         ""defaultRelayState"":null,
         ""ssoAcsUrl"":""http://testorgone.okta"",
         ""idpIssuer"":""http://www.okta.com/${org.externalKey}"",
         ""audience"":""asdqwe123"",
         ""recipient"":""http://testorgone.okta"",
         ""destination"":""http://testorgone.okta"",
         ""subjectNameIdTemplate"":""${user.userName}"",
         ""subjectNameIdFormat"":""urn:oasis:names:tc:SAML:1.1:nameid-format:unspecified"",
         ""responseSigned"":true,
         ""assertionSigned"":true,
         ""signatureAlgorithm"":""RSA_SHA256"",
         ""digestAlgorithm"":""SHA256"",
         ""honorForceAuthn"":true,
         ""authnContextClassRef"":""urn:oasis:names:tc:SAML:2.0:ac:classes:PasswordProtectedTransport"",
         ""spIssuer"":null,
         ""requestCompressed"":false,
         ""attributeStatements"":[
            {
               ""type"":""EXPRESSION"",
               ""name"":""Attribute"",
               ""namespace"":""urn:oasis:names:tc:SAML:2.0:attrname-format:unspecified"",
               ""values"":[
                  ""Value""
               ]
            }
         ]
      }
   },
   ""_links"":{
      ""help"":{
         ""href"":""https://dev-xxx.oktapreview.com/app/x_samplesamlcustomapp_2/0oafrfggz8Z7kU6rC0h7/setup/help/SAML_2_0/instructions"",
         ""type"":""text/html""
      },
      ""metadata"":{
         ""href"":""https://dev-xxx.oktapreview.com/api/v1/apps/0oafrfggz8Z7kU6rC0h7/sso/saml/metadata"",
         ""type"":""application/xml""
      },
      ""appLinks"":[
         {
            ""name"":""x_samplesamlcustomapp_2_link"",
            ""href"":""https://dev-xxx.oktapreview.com/home/x_samplesamlcustomapp_2/0oafrfggz8Z7kU6rC0h7/alnfrftec6nKa2KSg0h7"",
            ""type"":""text/html""
         }
      ],
      ""groups"":{
         ""href"":""https://dev-xxx.oktapreview.com/api/v1/apps/0oafrfggz8Z7kU6rC0h7/groups""
      },
      ""logo"":[
         {
            ""name"":""medium"",
            ""href"":""https://op1static.oktacdn.com/assets/img/logos/default.6770228fb0dab49a1695ef440a5279bb.png"",
            ""type"":""image/png""
         }
      ],
      ""users"":{
         ""href"":""https://dev-xxx.oktapreview.com/api/v1/apps/0oafrfggz8Z7kU6rC0h7/users""
      },
      ""deactivate"":{
         ""href"":""https://dev-xxx.oktapreview.com/api/v1/apps/0oafrfggz8Z7kU6rC0h7/lifecycle/deactivate""
      }
   }
}";
            var mockRequestExecutor = new MockedStringRequestExecutor(samlAppJson);
            var client = new TestableOktaClient(mockRequestExecutor);

            var samlApp = await client.Applications.GetApplicationAsync<ISamlApplication>("0oafrfggz8xxkU6rZ0h7");
            var statements = samlApp.Settings.SignOn.AttributeStatements.ToArray();
            statements.First().Type.Should().Be("EXPRESSION");
            statements.First().Name.Should().Be("Attribute");
        }
    }
}
