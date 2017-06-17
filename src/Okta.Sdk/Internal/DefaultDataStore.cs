// <copyright file="DefaultDataStore.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Okta.Sdk.Internal
{
    public sealed class DefaultDataStore : IDataStore
    {
        private readonly IRequestExecutor _requestExecutor;
        private readonly ISerializer _serializer;
        private readonly ILogger _logger;
        private readonly ResourceFactory _resourceFactory;

        public DefaultDataStore(
            IRequestExecutor requestExecutor,
            ISerializer serializer,
            ILogger logger)
        {
            _requestExecutor = requestExecutor ?? throw new ArgumentNullException(nameof(requestExecutor));
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            _resourceFactory = new ResourceFactory(this, logger);
            _logger = logger;
        }

        public IRequestExecutor RequestExecutor => _requestExecutor;

        public ISerializer Serializer => _serializer;

        private static HttpResponse<T> CreateResourceResponse<T>(HttpResponse<string> response, T resource)
            => new HttpResponse<T>
            {
                StatusCode = response.StatusCode,
                Headers = response.Headers,
                Payload = resource,
            };

        private static string PayloadOrEmpty(HttpResponse<string> response)
            => response?.Payload ?? string.Empty;

        private static void EnsureValidRequest(HttpRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.PathParams == null)
            {
                request.PathParams = Enumerable.Empty<KeyValuePair<string, object>>();
            }

            if (request.QueryParams == null)
            {
                request.QueryParams = Enumerable.Empty<KeyValuePair<string, object>>();
            }
        }

        private void EnsureResponseSuccess(HttpResponse<string> response)
        {
            if (response == null)
            {
                throw new InvalidOperationException("The response from the RequestExecutor was null.");
            }

            if (response.StatusCode != 200)
            {
                IDictionary<string, object> errorData = null;

                try
                {
                    errorData = _serializer.Deserialize(PayloadOrEmpty(response));
                    if (errorData == null)
                    {
                        throw new Exception("The error data was null.");
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"An error occurred deserializing the error body for response code {response.StatusCode}. See the inner exception for details.", ex);
                }

                throw new OktaApiException(response.StatusCode, _resourceFactory.CreateNew<Resource>(errorData));
            }
        }

        public async Task<HttpResponse<T>> GetAsync<T>(HttpRequest request, CancellationToken cancellationToken)
            where T : Resource, new()
        {
            EnsureValidRequest(request);
            var path = UrlFormatter.ApplyParametersToPath(request);

            var response = await _requestExecutor.GetAsync(path, cancellationToken).ConfigureAwait(false);
            EnsureResponseSuccess(response);

            var data = _serializer.Deserialize(PayloadOrEmpty(response));
            var resource = _resourceFactory.CreateNew<T>(data);

            return CreateResourceResponse(response, resource);
        }

        public async Task<HttpResponse<IEnumerable<T>>> GetArrayAsync<T>(HttpRequest request, CancellationToken cancellationToken)
            where T : Resource, new()
        {
            EnsureValidRequest(request);
            var path = UrlFormatter.ApplyParametersToPath(request);

            var response = await _requestExecutor.GetAsync(path, cancellationToken).ConfigureAwait(false);
            EnsureResponseSuccess(response);

            var resources = _serializer
                .DeserializeArray(PayloadOrEmpty(response))
                .Select(x => _resourceFactory.CreateNew<T>(x));

            return CreateResourceResponse(response, resources);
        }

        public async Task<HttpResponse<TResponse>> PostAsync<TResponse>(HttpRequest request, CancellationToken cancellationToken)
            where TResponse : Resource, new()
        {
            EnsureValidRequest(request);
            var path = UrlFormatter.ApplyParametersToPath(request);

            var body = _serializer.Serialize(request.Payload);

            var response = await _requestExecutor.PostAsync(path, body, cancellationToken).ConfigureAwait(false);
            EnsureResponseSuccess(response);

            var data = _serializer.Deserialize(PayloadOrEmpty(response));
            var resource = _resourceFactory.CreateNew<TResponse>(data);

            return CreateResourceResponse(response, resource);
        }

        public async Task<HttpResponse<TResponse>> PutAsync<TResponse>(HttpRequest request, CancellationToken cancellationToken)
            where TResponse : Resource, new()
        {
            EnsureValidRequest(request);
            var path = UrlFormatter.ApplyParametersToPath(request);

            var body = _serializer.Serialize(request.Payload);

            var response = await _requestExecutor.PutAsync(path, body, cancellationToken).ConfigureAwait(false);
            EnsureResponseSuccess(response);

            var data = _serializer.Deserialize(PayloadOrEmpty(response));
            var resource = _resourceFactory.CreateNew<TResponse>(data);

            return CreateResourceResponse(response, resource);
        }

        public async Task<HttpResponse> DeleteAsync(HttpRequest request, CancellationToken cancellationToken)
        {
            EnsureValidRequest(request);
            var path = UrlFormatter.ApplyParametersToPath(request);

            var response = await _requestExecutor.DeleteAsync(path, cancellationToken).ConfigureAwait(false);
            EnsureResponseSuccess(response);

            return response;
        }
    }
}
