// <copyright file="DefaultDataStore.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
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
    /// <summary>
    /// The default implementation of <see cref="IDataStore"/>.
    /// </summary>
    public sealed class DefaultDataStore : IDataStore
    {
        private readonly IRequestExecutor _requestExecutor;
        private readonly ISerializer _serializer;
        private readonly ILogger _logger;
        private readonly UserAgentBuilder _userAgentBuilder;
        private readonly ResourceFactory _resourceFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultDataStore"/> class.
        /// </summary>
        /// <param name="requestExecutor">The <see cref="IRequestExecutor">RequestExecutor</see> to use.</param>
        /// <param name="serializer">The <see cref="ISerializer">Serializer</see> to use.</param>
        /// <param name="resourceFactory">The <see cref="ResourceFactory"/>.</param>
        /// <param name="logger">The logging interface.</param>
        public DefaultDataStore(
            IRequestExecutor requestExecutor,
            ISerializer serializer,
            ResourceFactory resourceFactory,
            ILogger logger)
        {
            _requestExecutor = requestExecutor ?? throw new ArgumentNullException(nameof(requestExecutor));
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            _resourceFactory = resourceFactory ?? throw new ArgumentNullException(nameof(resourceFactory));
            _logger = logger;
            _userAgentBuilder = new UserAgentBuilder();
        }

        /// <inheritdoc/>
        public IRequestExecutor RequestExecutor => _requestExecutor;

        /// <inheritdoc/>
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

            if (request.PathParameters == null)
            {
                request.PathParameters = Enumerable.Empty<KeyValuePair<string, object>>();
            }

            if (request.QueryParameters == null)
            {
                request.QueryParameters = Enumerable.Empty<KeyValuePair<string, object>>();
            }
        }

        private void AddUserAgent(HttpRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.Headers == null)
            {
                request.Headers = new Dictionary<string, string>();
            }

            request.Headers["User-Agent"] = _userAgentBuilder.GetUserAgent();
        }

        private static void ApplyContextToRequest(HttpRequest request, RequestContext context)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (context == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(context.UserAgent))
            {
                request.Headers.TryGetValue("User-Agent", out string existingUserAgent);
                request.Headers["User-Agent"] = $"{context.UserAgent} {existingUserAgent}".Trim();
            }

            if (!string.IsNullOrEmpty(context.XForwardedFor))
            {
                request.Headers["X-Forwarded-For"] = context.XForwardedFor;
            }

            if (!string.IsNullOrEmpty(context.XForwardedPort))
            {
                request.Headers["X-Forwarded-Port"] = context.XForwardedPort;
            }

            if (!string.IsNullOrEmpty(context.XForwardedProto))
            {
                request.Headers["X-Forwarded-Proto"] = context.XForwardedProto;
            }
        }

        private void EnsureResponseSuccess(HttpResponse<string> response)
        {
            if (response == null)
            {
                throw new InvalidOperationException("The response from the RequestExecutor was null.");
            }

            if (response.StatusCode >= 200 && response.StatusCode < 300)
            {
                return;
            }

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

            throw new OktaApiException(response.StatusCode, _resourceFactory.CreateNew<ApiError>(errorData));
        }

        private void PrepareRequest(HttpRequest request, RequestContext context)
        {
            EnsureValidRequest(request);
            AddUserAgent(request);
            ApplyContextToRequest(request, context);
            request.Uri = UrlFormatter.ApplyParametersToPath(request);
        }

        /// <inheritdoc/>
        public async Task<HttpResponse<T>> GetAsync<T>(
            HttpRequest request,
            RequestContext requestContext,
            CancellationToken cancellationToken)
            where T : Resource, new()
        {
            PrepareRequest(request, requestContext);

            var response = await _requestExecutor.GetAsync(request.Uri, request.Headers, cancellationToken).ConfigureAwait(false);
            EnsureResponseSuccess(response);

            var data = _serializer.Deserialize(PayloadOrEmpty(response));
            var resource = _resourceFactory.CreateNew<T>(data);

            return CreateResourceResponse(response, resource);
        }

        /// <inheritdoc/>
        public async Task<HttpResponse<IEnumerable<T>>> GetArrayAsync<T>(HttpRequest request, RequestContext requestContext, CancellationToken cancellationToken)
            where T : IResource
        {
            PrepareRequest(request, requestContext);

            var response = await _requestExecutor.GetAsync(request.Uri, request.Headers, cancellationToken).ConfigureAwait(false);
            EnsureResponseSuccess(response);

            var resources = _serializer
                .DeserializeArray(PayloadOrEmpty(response))
                .Select(x => _resourceFactory.CreateNew<T>(x));

            return CreateResourceResponse(response, resources);
        }

        /// <inheritdoc/>
        public async Task<HttpResponse<TResponse>> PostAsync<TResponse>(HttpRequest request, RequestContext requestContext, CancellationToken cancellationToken)
            where TResponse : Resource, new()
        {
            PrepareRequest(request, requestContext);

            var body = _serializer.Serialize(request.Payload);

            var response = await _requestExecutor.PostAsync(request.Uri, request.Headers, body, cancellationToken).ConfigureAwait(false);
            EnsureResponseSuccess(response);

            var data = _serializer.Deserialize(PayloadOrEmpty(response));
            var resource = _resourceFactory.CreateNew<TResponse>(data);

            return CreateResourceResponse(response, resource);
        }

        /// <inheritdoc/>
        public async Task<HttpResponse<TResponse>> PutAsync<TResponse>(HttpRequest request, RequestContext requestContext, CancellationToken cancellationToken)
            where TResponse : Resource, new()
        {
            PrepareRequest(request, requestContext);

            var body = _serializer.Serialize(request.Payload);

            var response = await _requestExecutor.PutAsync(request.Uri, request.Headers, body, cancellationToken).ConfigureAwait(false);
            EnsureResponseSuccess(response);

            var data = _serializer.Deserialize(PayloadOrEmpty(response));
            var resource = _resourceFactory.CreateNew<TResponse>(data);

            return CreateResourceResponse(response, resource);
        }

        /// <inheritdoc/>
        public async Task<HttpResponse> DeleteAsync(HttpRequest request, RequestContext requestContext, CancellationToken cancellationToken)
        {
            PrepareRequest(request, requestContext);

            var response = await _requestExecutor.DeleteAsync(request.Uri, request.Headers, cancellationToken).ConfigureAwait(false);
            EnsureResponseSuccess(response);

            return response;
        }
    }
}
