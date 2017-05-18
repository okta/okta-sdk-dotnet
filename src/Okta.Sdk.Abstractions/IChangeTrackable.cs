// <copyright file="IChangeTrackable.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk.Abstractions
{
    public interface IChangeTrackable
    {
        void Reset();

        void MarkDirty(string key);

        void MarkClean(string key);

        object Difference { get; }
    }
}
