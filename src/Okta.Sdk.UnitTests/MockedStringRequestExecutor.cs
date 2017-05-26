using Okta.Sdk.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk.UnitTests
{
    public class MockedStringRequestExecutor : IRequestExecutor
    {
        private readonly string _returnThis;

        public MockedStringRequestExecutor(string returnThis)
        {
            _returnThis = returnThis ?? throw new ArgumentNullException(nameof(returnThis));
        }

        public Task<string> GetBodyAsync(string href, CancellationToken cancellationToken)
            => Task.FromResult(_returnThis);

        public async Task<HttpResponse<string>> GetAsync(string href, CancellationToken cancellationToken)
            => new HttpResponse<string>
            {
                StatusCode = 200,
                Payload = await GetBodyAsync(href, cancellationToken)
            };

        public Task<HttpResponse<string>> PostAsync(string href, string body, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
