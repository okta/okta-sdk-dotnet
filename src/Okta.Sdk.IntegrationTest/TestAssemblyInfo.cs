// <copyright file="TestAssemblyInfo.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using Xunit;

// Enforce strictly sequential test execution across all collections.
// Integration tests share a live Okta org and must not run in parallel.
[assembly: CollectionBehavior(DisableTestParallelization = true, MaxParallelThreads = 1)]
