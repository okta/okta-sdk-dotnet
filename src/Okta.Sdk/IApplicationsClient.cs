using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    public partial interface IApplicationsClient
    {
        Task<T> GetApplicationAsync<T>(string appId, CancellationToken cancellationToken = default(CancellationToken))
            where T : class, IApplication;

        Task<T> UpdateApplicationAsync<T>(IApplication application, string appId, CancellationToken cancellationToken = default(CancellationToken))
            where T : class, IApplication;

        Task<IApplication> CreateApplicationAsync(CreateBasicAuthApplicationOptions basicAuthApplicationOptions, CancellationToken cancellationToken = default(CancellationToken));

        Task<IApplication> CreateApplicationAsync(CreateBookmarkApplicationOptions bookmarkApplicationOptions, CancellationToken cancellationToken = default(CancellationToken));

        Task<IApplication> CreateApplicationAsync(CreateSwaApplicationOptions swaApplicationOptions, CancellationToken cancellationToken = default(CancellationToken));

        Task<IApplication> CreateApplicationAsync(CreateSwaNoPluginApplicationOptions swaNoPluginApplicationOptions, CancellationToken cancellationToken = default(CancellationToken));

        Task<IApplication> CreateApplicationAsync(CreateSwaThreeFieldApplicationOptions swaThreeFieldApplicationOptions, CancellationToken cancellationToken = default(CancellationToken));

        Task<IApplication> CreateApplicationAsync(CreateSwaCustomApplicationOptions swaCustomApplicationOptions, CancellationToken cancellationToken = default(CancellationToken));

        Task<IApplication> CreateApplicationAsync(CreateSamlApplicationOptions samlApplicationOptions, CancellationToken cancellationToken = default(CancellationToken));

        Task<IApplication> CreateApplicationAsync(CreateWsFederationApplicationOptions wsFederationApplicationOptions, CancellationToken cancellationToken = default(CancellationToken));

        Task<IApplication> CreateApplicationAsync(CreateOpenIdConnectApplication openIdApplicationOptions, CancellationToken cancellationToken = default(CancellationToken));
    }
}
