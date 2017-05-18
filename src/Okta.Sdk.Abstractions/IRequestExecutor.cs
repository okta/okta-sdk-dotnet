using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk.Abstractions
{
    public interface IRequestExecutor
    {
        Task<string> GetAsync(string href, CancellationToken ct);
    }
}