using Okta.Sdk.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    public sealed class DefaultRequestExecutor : IRequestExecutor
    {
        public Task<HttpResponse<string>> GetAsync(string href, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetBodyAsync(string href, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponse<string>> PostAsync(string href, string body, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
