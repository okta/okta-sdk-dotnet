using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Okta.Sdk.Client;
using RestSharp;

namespace Okta.Sdk.UnitTest.Internal
{
    public class MockAsyncClient : IAsynchronousClient
    {
        private readonly string _returnThis;

        private readonly HttpStatusCode _statusCode;

        private readonly Queue<MockResponseInfo> _returnThisInOrder;

        public Queue<Multimap<string, string>> ReceivedHeadersQueue { get; set; }

        public string ReceivedPath { get; set; }

        public string ReceivedBody { get; set; }

        public Multimap<string, string> ReceivedHeaders { get; set; }

        private Multimap<string, string> _returnHeaders { get; set; }

        public Multimap<string, string> ReceivedQueryParams { get; set; }

        public Dictionary<string, string> ReceivedPathParams { get; set; }


        public MockAsyncClient(string returnThis, HttpStatusCode statusCode = HttpStatusCode.OK, Multimap<string, string> returnHeaders = null)
        {
            _returnThis = returnThis;
            _statusCode = statusCode;
            _returnHeaders = returnHeaders;
        }

        public MockAsyncClient(Queue<MockResponseInfo> returnThisInOrder)
        {
            _returnThisInOrder = returnThisInOrder;
        }


        public Task<ApiResponse<T>> DeleteAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, CancellationToken cancellationToken = default)
        {
            return ExecuteAsync<T>(path, options);
        }


        private ApiResponse<T> ToApiResponse<T>(string returnThis, HttpStatusCode statusCode, Multimap<string, string> returnHeaders)
        {
            T result = JsonConvert.DeserializeObject<T>(returnThis);
            var transformed = new ApiResponse<T>(statusCode, returnHeaders, result, returnThis)
            {
                Cookies = new List<Cookie>(),

            };

            return transformed;
        }

        public Task<ApiResponse<T>> GetAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, CancellationToken cancellationToken = default)
        {
            return ExecuteAsync<T>(path, options);
        }

        private Task<ApiResponse<T>> ExecuteAsync<T>(string path, RequestOptions options)
        {
            var customCodec = new CustomJsonCodec(new Configuration { BasePath = "https://foo.com" });
            ReceivedPath = path;
            ReceivedQueryParams = options.QueryParameters;
            ReceivedPathParams = options.PathParameters;
            ReceivedHeaders = options.HeaderParameters;
            ReceivedBody = JsonConvert.SerializeObject(options.Data, customCodec.JsonSerializer);
            ReceivedHeadersQueue ??= new Queue<Multimap<string, string>>();
            ReceivedHeadersQueue.Enqueue(options.HeaderParameters);

            if (_returnThisInOrder != null)
            {
                var returnThis = _returnThisInOrder.Dequeue();

                return Task.FromResult(ToApiResponse<T>(returnThis.ReturnThis, returnThis.StatusCode, returnThis.ReceivedHeaders));
            }
            
            return Task.FromResult(ToApiResponse<T>(_returnThis, _statusCode, _returnHeaders));
        }

        public Task<ApiResponse<T>> HeadAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<T>> OptionsAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<T>> PatchAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<T>> PostAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, CancellationToken cancellationToken = default)
        {
            return ExecuteAsync<T>(path, options);
        }

        public Task<ApiResponse<T>> PutAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, CancellationToken cancellationToken = default)
        {
            return ExecuteAsync<T>(path, options);
        }
    }

    public class MockResponseInfo
    {
        public string ReturnThis { get; set; }

        public  HttpStatusCode StatusCode { get; set; }

        public Multimap<string, string> ReceivedHeaders { get; set; }
        
    }
}
