// <copyright file="FileOutput.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.IO;
using System.Threading.Tasks;

namespace Okta.Sdk.Extensions;

public class FileOutput : IOutput
{
    public FileOutput(FileInfo file)
    {
        this.File = file;
    }
    protected FileInfo File { get; }
    public async ValueTask WriteAsync(string output)
    {
        await using StreamWriter streamWriter = File.AppendText();
        await streamWriter.WriteAsync(output);
    }
}