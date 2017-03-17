using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okta.Core.Models;
using Newtonsoft.Json;

namespace Okta.Core.Tests.Serialization
{
    [TestClass]
    public class AppSerializationTests
    {
        public const string AppSampleData = @"
        [{
            'id': '00000000000000000000',
            'name': 'OktaApiTestApp_001',
            'label': 'Test App',
            'status': 'ACTIVE',
            'lastUpdated': '2015-01-20T17:54:40.000Z',
            'created': '2015-01-16T22:53:43.000Z',
            'accessibility': {
                'selfService': false,
                'errorRedirectUrl': null
            },
            'visibility': {
                'autoSubmitToolbar': false,
                'hide': {
                    'iOS': false,
                    'web': false
                },
                'appLinks': {
                    'okta_okta_1_link': true
                }
            },
            'features': [],
            'signOnMode': 'SAML_2_0',
            'credentials': {
                'userNameTemplate': {
                    'template': '${source.login}',
                    'type': 'BUILT_IN'
                }
            },
            'settings': {
                'app': {}
            },
            '_links': {
                'logo': [{
                    'name': 'medium',
                    'href': 'https://op1static.oktacdn.com/img/logos/default.png',
                    'type': 'image/png'
                }],
                'appLinks': [{
                    'name': 'okta_okta_1_link',
                    'href': 'https://www.oktapreview.com/home/okta_okta_1/00000000000000000000/9921',
                    'type': 'text/html'
                }],
                'users': {
                    'href': 'https://www.oktapreview.com/home/okta_okta_1/00000000000000000000/users'
                },
                'deactivate': {
                    'href': 'https://www.oktapreview.com/home/okta_okta_1/00000000000000000000/lifecycle/deactivate'
                },
                'groups': {
                    'href': 'https://www.oktapreview.com/home/okta_okta_1/00000000000000000000/groups'
                },
                'metadata': {
                    'href': 'https://www.oktapreview.com/home/okta_okta_1/00000000000000000000/sso/saml/metadata',
                    'type': 'application/xml'
                }
            }
        }]";

        [TestMethod]
        public void AppShouldDeserialize()
        {
            var result = JsonConvert.DeserializeObject<List<App>>(AppSampleData, new OktaJsonConverter());
        }
    }
}
