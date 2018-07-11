using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk
{
    public sealed partial class LogsClient : OktaClient, ILogsClient, IAsyncEnumerable<ILogEvent>
    {
        public IAsyncEnumerator<ILogEvent> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
