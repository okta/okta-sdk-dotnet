// <copyright file="DefaultDataStore.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Abstractions;

namespace Okta.Sdk
{
    public sealed class DefaultDataStore : IDataStore
    {
        private readonly IRequestExecutor _requestExecutor;
        private readonly ISerializer _serializer;
        private readonly ResourceFactory _resourceFactory;

        public DefaultDataStore(
            IRequestExecutor requestExecutor,
            ISerializer serializer)
        {
            _requestExecutor = requestExecutor ?? throw new ArgumentNullException(nameof(requestExecutor));
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            _resourceFactory = new ResourceFactory();
        }

        public IRequestExecutor RequestExecutor => _requestExecutor;

        public ISerializer Serializer => _serializer;

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

        private static HttpResponse<T> CreateResourceResponse<T>(HttpResponse<string> response, T resource)
            => new HttpResponse<T>
            {
                StatusCode = response.StatusCode,
                Headers = response.Headers,
                Payload = resource,
            };

        private static string PayloadOrEmpty(HttpResponse<string> response)
            => response?.Payload ?? string.Empty;

        public async Task<HttpResponse<T>> GetAsync<T>(string href, CancellationToken cancellationToken)
            where T : Resource, new()
        {
            // todo optional query string parameters

            var response = await _requestExecutor.GetAsync(href, cancellationToken).ConfigureAwait(false);
            EnsureResponseSuccess(response);

            var data = _serializer.Deserialize(PayloadOrEmpty(response));
            var resource = _resourceFactory.CreateNew<T>(data);

            return CreateResourceResponse(response, resource);
        }

        public async Task<HttpResponse<IEnumerable<T>>> GetArrayAsync<T>(string href, CancellationToken cancellationToken)
            where T : Resource, new()
        {
            // TODO apply query string parameters

            var response = await _requestExecutor.GetAsync(href, cancellationToken).ConfigureAwait(false);
            EnsureResponseSuccess(response);

            var resources = _serializer
                .DeserializeArray(PayloadOrEmpty(response))
                .Select(x => _resourceFactory.CreateNew<T>(x));

            return CreateResourceResponse(response, resources);
        }

        public async Task<HttpResponse<TResponse>> PostAsync<TResponse>(string href, object postData, CancellationToken cancellationToken)
            where TResponse : Resource, new()
        {
            var body = _serializer.Serialize(postData);
            // TODO apply query string parameters

            var response = await _requestExecutor.PostAsync(href, body, cancellationToken).ConfigureAwait(false);
            EnsureResponseSuccess(response);

            var data = _serializer.Deserialize(PayloadOrEmpty(response));
            var resource = _resourceFactory.CreateNew<TResponse>(data);

            return CreateResourceResponse(response, resource);
        }

        public async Task<HttpResponse<TResponse>> PutAsync<TResponse>(string href, object postData, CancellationToken cancellationToken) where TResponse : Resource, new()
        {
            var body = _serializer.Serialize(postData);
            // TODO apply query string parameters

            var response = await _requestExecutor.PutAsync(href, body, cancellationToken).ConfigureAwait(false);
            EnsureResponseSuccess(response);

            var data = _serializer.Deserialize(PayloadOrEmpty(response));
            var resource = _resourceFactory.CreateNew<TResponse>(data);

            return CreateResourceResponse(response, resource);
        }

        public async Task<HttpResponse> DeleteAsync(string href, CancellationToken cancellationToken)
        {
            var response = await _requestExecutor.DeleteAsync(href, cancellationToken).ConfigureAwait(false);
            EnsureResponseSuccess(response);

            return response;
        }
    }
}
