// <copyright file="TestNestedResource.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk.UnitTests
{
    public class TestNestedResource : TestResource
    {
        public TestNestedResource Nested
        {
            get => GetProperty<TestNestedResource>("nested");
            set => SetProperty("nested", value);
        }
    }
}
