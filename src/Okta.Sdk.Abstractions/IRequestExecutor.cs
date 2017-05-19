using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk.Abstractions
{
    public interface IRequestExecutor
    {
        Task<string> GetBodyAsync(string href, CancellationToken cancellationToken);

        Task<HttpResponse<string>> GetAsync(string href, CancellationToken cancellationToken);
    }
}