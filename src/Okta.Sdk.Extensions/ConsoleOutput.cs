// <copyright file="ConsoleOutput.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Threading.Tasks;

namespace Okta.Sdk.Extensions;

public class ConsoleOutput : IOutput
{
    public async ValueTask WriteAsync(string output)
    {
        Console.WriteLine(output.Trim());
    }
}