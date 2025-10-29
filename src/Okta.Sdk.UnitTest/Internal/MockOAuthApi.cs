// <copyright file="MockOAuthApi.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Api;
using Okta.Sdk.Client;

namespace Okta.Sdk.UnitTest.Internal
{
    public class MockOAuthApi : IOAuthApi
    {
        private Queue<string> _returnQueue;
        private bool _isDpop;

        public MockOAuthApi(IReadableConfiguration configuration, Queue<string> returnQueue = null, bool isDpop = false)
        {
            Configuration = configuration;
            _returnQueue = returnQueue;
            _isDpop = isDpop;
        }
        public IReadableConfiguration Configuration { get ; set; }
        public ExceptionFactory ExceptionFactory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string GetBasePath()
        {
            return "https://foo.com";
        }

        public Task<OAuthTokenResponse> GetBearerTokenAsync(CancellationToken cancellationToken = default)
        {
            var token = _returnQueue?.Dequeue() ?? "foo";
            return Task.FromResult<OAuthTokenResponse>(new OAuthTokenResponse { AccessToken = token, TokenType = (_isDpop) ? "DPoP" : "Bearer"});
        }

        public Task<ApiResponse<OAuthTokenResponse>> GetBearerTokenWithHttpInfoAsync(CancellationToken cancellationToken = default)
        {
            return null;
        }
    }
}
