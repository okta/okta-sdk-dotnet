using Okta.Sdk.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    public sealed class DefaultRequestExecutor : IRequestExecutor
    {
        Task<string> IRequestExecutor.GetAsync(string href, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
