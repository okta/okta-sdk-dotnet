// <copyright file="MockInterceptor.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using RestSharp.Interceptors;

namespace Okta.Sdk.UnitTest.Internal;

public class MockInterceptor : Interceptor
{
    public MockInterceptor(IMockDependency mockDependency)
    {
        this.MockDependency = mockDependency;
    }
    
    public IMockDependency MockDependency { get; set; }
}