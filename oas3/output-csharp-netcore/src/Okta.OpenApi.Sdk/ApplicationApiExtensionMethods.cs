using System;
using System.Threading;
using System.Threading.Tasks;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Model;

namespace Okta.OpenApi.Sdk
{
    public static class ApplicationApiExtensionMethods
    {
        public static async Task<T> GetApplicationAsync<T>(this IApplicationApi api, string appId, CancellationToken cancellationToken = default(CancellationToken))
            where T : Application
            => await api.GetApplicationAsync(appId, null, cancellationToken).ConfigureAwait(false) as T;

        public static async Task<T> UpdateApplicationAsync<T>(this IApplicationApi api, Application application, string appId, CancellationToken cancellationToken = default(CancellationToken))
            where T : Application
            => await api.UpdateApplicationAsync(appId, application, cancellationToken).ConfigureAwait(false) as T;

    }
}
