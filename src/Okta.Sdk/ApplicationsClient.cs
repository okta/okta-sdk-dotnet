using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    public partial class ApplicationsClient : OktaClient, IApplicationsClient, IAsyncEnumerable<IApplication>
    {
        /// <inheritdoc/>
        public IAsyncEnumerator<IApplication> GetEnumerator() => ListApplications().GetEnumerator();
    }
}
