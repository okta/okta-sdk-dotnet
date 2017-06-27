// <copyright file="AppLink.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// Do not modify this file directly. This file was automatically generated with:
// spec.json - 0.3.0

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    public sealed partial class AppLink : Resource, IAppLink
    {
        public string AppAssignmentId => GetStringProperty("appAssignmentId");

        public string AppInstanceId => GetStringProperty("appInstanceId");

        public string AppName => GetStringProperty("appName");

        public bool? CredentialsSetup => GetBooleanProperty("credentialsSetup");

        public bool? Hidden => GetBooleanProperty("hidden");

        public string Id => GetStringProperty("id");

        public string Label => GetStringProperty("label");

        public string LinkUrl => GetStringProperty("linkUrl");

        public string LogoUrl => GetStringProperty("logoUrl");

        public int? SortOrder => GetIntegerProperty("sortOrder");

    }
}
