using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk.Abstractions
{
    public interface IDataStore
    {
        IRequestExecutor RequestExecutor { get; }

        ISerializer Serializer { get; }

        IResourceFactory ResourceFactory { get; }

        Task<HttpResponse<T>> GetAsync<T>(string href, CancellationToken cancellationToken = default(CancellationToken));

        Task<HttpResponse<IEnumerable<T>>> GetArrayAsync<T>(string href, CancellationToken cancellationToken = default(CancellationToken));
    }
}
