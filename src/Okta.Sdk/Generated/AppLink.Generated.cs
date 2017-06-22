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
        public string AppAssignmentId
        {
            get => GetStringProperty("appAssignmentId");
            set => this["appAssignmentId"] = value;
        }

        public string AppInstanceId
        {
            get => GetStringProperty("appInstanceId");
            set => this["appInstanceId"] = value;
        }

        public string AppName
        {
            get => GetStringProperty("appName");
            set => this["appName"] = value;
        }

        public bool? CredentialsSetup
        {
            get => GetBooleanProperty("credentialsSetup");
            set => this["credentialsSetup"] = value;
        }

        public bool? Hidden
        {
            get => GetBooleanProperty("hidden");
            set => this["hidden"] = value;
        }

        public string Id
        {
            get => GetStringProperty("id");
            set => this["id"] = value;
        }

        public string Label
        {
            get => GetStringProperty("label");
            set => this["label"] = value;
        }

        public string LinkUrl
        {
            get => GetStringProperty("linkUrl");
            set => this["linkUrl"] = value;
        }

        public string LogoUrl
        {
            get => GetStringProperty("logoUrl");
            set => this["logoUrl"] = value;
        }

        public int? SortOrder
        {
            get => GetIntegerProperty("sortOrder");
            set => this["sortOrder"] = value;
        }

    }
}
