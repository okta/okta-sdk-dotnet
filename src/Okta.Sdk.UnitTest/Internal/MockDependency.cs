// <copyright file="MockDependency.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk.UnitTest.Internal;

public class MockDependency : IMockDependency
{
    public MockDependency(SubDependency subDependency)
    {
        this.SubDependency = subDependency;
    }
    
    public SubDependency SubDependency { get; set; }
}