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

        public Task<string> GetAsync(string href, CancellationToken ct)
            => Task.FromResult(_returnThis);
    }
}
