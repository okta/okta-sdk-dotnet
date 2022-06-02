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

        public string ReceivedPath { get; set; }

        public string ReceivedBody { get; set; }

        public Multimap<string, string> ReceivedHeaders { get; set; }

        public Multimap<string, string> ReceivedQueryParams { get; set; }

        public Dictionary<string, string> ReceivedPathParams { get; set; }

        public MockAsyncClient(string returnThis, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            _returnThis = returnThis;
            _statusCode = statusCode;
        }

        
        public Task<ApiResponse<T>> DeleteAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, CancellationToken cancellationToken = default)
        {
            return ExecuteAsync<T>(path, options);
        }


        private ApiResponse<T> ToApiResponse<T>(string returnThis, HttpStatusCode statusCode)
        {
            T result = JsonConvert.DeserializeObject<T>(returnThis);

            var transformed = new ApiResponse<T>(statusCode, new Multimap<string, string>(), result, returnThis)
            {
                Cookies = new List<Cookie>()
            };

            return transformed;
        }

        public Task<ApiResponse<T>> GetAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, CancellationToken cancellationToken = default)
        {
            return ExecuteAsync<T>(path, options);
        }

        private Task<ApiResponse<T>> ExecuteAsync<T>(string path, RequestOptions options)
        {
            ReceivedPath = path;
            ReceivedQueryParams = options.QueryParameters;
            ReceivedPathParams = options.PathParameters;
            ReceivedHeaders = options.HeaderParameters;
            ReceivedBody = JsonConvert.SerializeObject(options.Data);
            return Task.FromResult(ToApiResponse<T>(_returnThis, _statusCode));
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
}
