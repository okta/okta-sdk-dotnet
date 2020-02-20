using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Okta.Sdk.Internal
{
    public class HttpRequestMessageHelper
    {
        public static async Task<HttpRequestMessage> CloneHttpRequestMessageAsync(HttpRequestMessage request)
        {
            HttpRequestMessage clonedRequest = new HttpRequestMessage(request.Method, request.RequestUri);

            if (request.Content != null)
            {
                // Copy the request's content (via a MemoryStream) into the cloned object
                var memoryStream = new MemoryStream();
                await request.Content.CopyToAsync(memoryStream).ConfigureAwait(false);
                memoryStream.Position = 0;
                clonedRequest.Content = new StreamContent(memoryStream);

                // Copy the content headers
                if (request.Content.Headers != null)
                {
                    foreach (var header in request.Content.Headers)
                    {
                        clonedRequest.Content.Headers.Add(header.Key, header.Value);
                    }
                }
            }

            clonedRequest.Version = request.Version;

            foreach (KeyValuePair<string, object> property in request.Properties)
            {
                clonedRequest.Properties.Add(property);
            }

            foreach (KeyValuePair<string, IEnumerable<string>> header in request.Headers)
            {
                clonedRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            return clonedRequest;
        }
    }
}
