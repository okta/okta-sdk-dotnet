// <copyright file="CAPTCHAsClient.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Okta.Sdk.Configuration;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    /// <inheritdoc/>
    public sealed partial class CAPTCHAsClient : OktaClient, ICAPTCHAsClient
    {
        // Remove parameterless constructor
        private CAPTCHAsClient()
        {
        }

        internal CAPTCHAsClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public ICollectionClient<ICAPTCHAInstance> ListCaptchaInstances()
            => GetCollectionClient<ICAPTCHAInstance>(new HttpRequest
            {
                Uri = "/api/v1/captchas",
                Verb = HttpVerb.Get,
                
            });
                    
        /// <inheritdoc />
        public async Task<ICAPTCHAInstance> CreateCaptchaInstanceAsync(ICAPTCHAInstance captchaInstance, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<CAPTCHAInstance>(new HttpRequest
            {
                Uri = "/api/v1/captchas",
                Verb = HttpVerb.Post,
                Payload = captchaInstance,
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeleteCaptchaInstanceAsync(CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/captchas/{captchaId}",
                Verb = HttpVerb.Delete,
                
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<ICAPTCHAInstance> GetCaptchaInstanceAsync(CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<CAPTCHAInstance>(new HttpRequest
            {
                Uri = "/api/v1/captchas/{captchaId}",
                Verb = HttpVerb.Get,
                
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<ICAPTCHAInstance> PartialUpdateCaptchaInstanceAsync(ICAPTCHAInstance captchaInstance, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<CAPTCHAInstance>(new HttpRequest
            {
                Uri = "/api/v1/captchas/{captchaId}",
                Verb = HttpVerb.Post,
                Payload = captchaInstance,
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<ICAPTCHAInstance> UpdateCaptchaInstanceAsync(ICAPTCHAInstance captchaInstance, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync<CAPTCHAInstance>(new HttpRequest
            {
                Uri = "/api/v1/captchas/{captchaId}",
                Verb = HttpVerb.Put,
                Payload = captchaInstance,
                }, cancellationToken).ConfigureAwait(false);
        
    }
}
