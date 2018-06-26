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

        Task<IApplication> CreateApplicationAsync(CreateBasicAuthApplicationOptions basicAuthApplicationOptions, bool? activate = true, CancellationToken cancellationToken = default(CancellationToken));

        Task<IApplication> CreateApplicationAsync(CreateBookmarkApplicationOptions bookmarkApplicationOptions, bool? activate = true, CancellationToken cancellationToken = default(CancellationToken));

        Task<IApplication> CreateApplicationAsync(CreateSwaApplicationOptions swaApplicationOptions, bool? activate = true, CancellationToken cancellationToken = default(CancellationToken));

        Task<IApplication> CreateApplicationAsync(CreateSwaNoPluginApplicationOptions swaNoPluginApplicationOptions, bool? activate = true, CancellationToken cancellationToken = default(CancellationToken));

        Task<IApplication> CreateApplicationAsync(CreateSwaThreeFieldApplicationOptions swaThreeFieldApplicationOptions, bool? activate = true, CancellationToken cancellationToken = default(CancellationToken));

        Task<IApplication> CreateApplicationAsync(CreateSwaCustomApplicationOptions swaCustomApplicationOptions, bool? activate = true, CancellationToken cancellationToken = default(CancellationToken));

        Task<IApplication> CreateApplicationAsync(CreateSamlApplicationOptions samlApplicationOptions, bool? activate = true, CancellationToken cancellationToken = default(CancellationToken));

        Task<IApplication> CreateApplicationAsync(CreateWsFederationApplicationOptions wsFederationApplicationOptions, bool? activate = true, CancellationToken cancellationToken = default(CancellationToken));
    }
}
