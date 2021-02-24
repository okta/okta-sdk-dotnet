// <copyright file="OktasClient.Generated.cs" company="Okta, Inc">
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
    public sealed partial class OktasClient : OktaClient, IOktasClient
    {
        // Remove parameterless constructor
        private OktasClient()
        {
        }

        internal OktasClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public async Task<IUserSchema> UpdateApplicationUserProfileAsync(IUserSchema body, string appInstanceId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<UserSchema>(new HttpRequest
            {
                Uri = "/api/v1/meta/schemas/apps/{appInstanceId}/default",
                Verb = HttpVerb.Post,
                Payload = body,
                PathParameters = new Dictionary<string, object>()
                {
                    ["appInstanceId"] = appInstanceId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
    }
}
