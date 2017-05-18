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
        public Task<HttpResponseWrapper> GetAsync(string href, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<string> IRequestExecutor.GetBodyAsync(string href, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
