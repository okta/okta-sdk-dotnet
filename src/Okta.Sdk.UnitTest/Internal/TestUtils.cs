using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using Moq;
using Newtonsoft.Json;
using RestSharp;

namespace Okta.Sdk.UnitTest.Internal
{
    public class TestUtils
    {
        public static IRestClient MockRestClient(HttpStatusCode httpStatusCode, string json, List<Parameter> headers = null)
        {
            var response = new Mock<IRestResponse>();
            response.Setup(_ => _.Headers).Returns(headers);
            response.Setup(_ => _.StatusCode).Returns(httpStatusCode);

            var mockIRestClient = new Mock<IRestClient>();
            mockIRestClient
                .Setup(x => x.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response.Object);
            return mockIRestClient.Object;
        }

        public static IRestClient MockRestClient(Queue<MockResponseInfo> queueResponseInfo)
        {
            var mockIRestClient = new Mock<IRestClient>();
            var mockSequence = mockIRestClient.SetupSequence(x =>
                x.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()));

            while (queueResponseInfo.Count > 0)
            {
                var responseInfo = queueResponseInfo.Dequeue();
                var response = new Mock<IRestResponse>();
                response.Setup(_ => _.Headers).Returns(responseInfo.Headers);
                response.Setup(_ => _.StatusCode).Returns(responseInfo.StatusCode);
                mockSequence = mockSequence.ReturnsAsync(response.Object);

            }

            return mockIRestClient.Object;
        }

        public class MockResponseInfo
        {
            public string ReturnThis { get; set; }

            public HttpStatusCode StatusCode { get; set; }

            public List<Parameter> Headers { get; set; }
        }
    }
}
