using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk
{
    public sealed partial class SessionsClient : OktaClient, ISessionsClient, IAsyncEnumerable<ISession>
    {
        public IAsyncEnumerator<ISession> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
