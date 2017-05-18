using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk.Abstractions
{
    public interface IRequestExecutor
    {
        Task<string> GetBodyAsync(string href, CancellationToken cancellationToken);

        Task<HttpResponseWrapper> GetAsync(string href, CancellationToken cancellationToken);
    }
}