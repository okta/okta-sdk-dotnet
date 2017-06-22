// <copyright file="GroupRuleUserCondition.Generated.cs" company="Okta, Inc">
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
    public sealed partial class GroupRuleUserCondition : Resource, IGroupRuleUserCondition
    {
        public IList<string> Exclude
        {
            get => GetArrayProperty<string>("exclude");
            set => this["exclude"] = value;
        }

        public IList<string> Include
        {
            get => GetArrayProperty<string>("include");
            set => this["include"] = value;
        }

    }
}
