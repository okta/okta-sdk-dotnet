// <copyright file="TestResourceCreator.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using Okta.Sdk.Internal;

namespace Okta.Sdk.UnitTests.Internal
{
    public static class TestResourceCreator
    {
        public static IUser NewUser(string id, UserStatus status)
        {
            var data = new Dictionary<string, object>(StringComparer.Ordinal)
            {
                ["id"] = id,
                ["status"] = status.ToString(),
            };

            return Create<User>(data);
        }

        public static IFactor NewFactor(FactorType factorType, string provider, IFactorProfile profile)
        {
            var data = new Dictionary<string, object>(StringComparer.Ordinal)
            {
                ["factorType"] = factorType,
                ["provider"] = provider,
                ["profile"] = profile,
            };

            return Create<Factor>(data);
        }

        private static T Create<T>(Dictionary<string, object> data)
        {
            var factory = new ResourceFactory(null, null);
            return factory.CreateNew<T>(data);
        }
    }
}
