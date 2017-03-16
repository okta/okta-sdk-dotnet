namespace Okta.Core
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// An abstract Okta http client
    /// </summary>
    public abstract class IOktaHttpClient
    {
        public enum HttpRequestType
        {
            GET, 
            PUT, 
            POST, 
            DELETE
        }

        public virtual string ApiToken { get; set; }
        public virtual Uri BaseUri { get; set; }

        public abstract HttpResponseMessage Execute(HttpRequestType requestType, Uri uri = null, string relativeUri = null, string content = null, int waitMillis = 0, int retryCount = 0, bool bAddAuthorizationHeader = true);
        public abstract Task<HttpResponseMessage> ExecuteAsync(HttpRequestType requestType, Uri uri = null, string relativeUri = null, string content = null, int waitMillis = 0, bool bAddAuthorizationHeader = true);

        #region GET methods
        public HttpResponseMessage Get(string relativeUri)
        {
            return Execute(HttpRequestType.GET, relativeUri: relativeUri);
        }

        public Task<HttpResponseMessage> GetAsync(string relativeUri)
        {
            return ExecuteAsync(HttpRequestType.GET, relativeUri: relativeUri);
        }

        public HttpResponseMessage Get(Uri uri)
        {
            return Execute(HttpRequestType.GET, uri);
        }

        public Task<HttpResponseMessage> GetAsync(Uri uri)
        {
            return ExecuteAsync(HttpRequestType.GET, uri);
        }

        #endregion

        #region POST methods
        public HttpResponseMessage Post(string relativeUri, string content = null, bool bAddAuthorizationHeader = true)
        {
            return Execute(HttpRequestType.POST, relativeUri: relativeUri, content: content, bAddAuthorizationHeader: bAddAuthorizationHeader);
        }

        public Task<HttpResponseMessage> PostAsync(string relativeUri, string content = null)
        {
            return ExecuteAsync(HttpRequestType.POST, relativeUri: relativeUri, content: content);
        }

        public HttpResponseMessage Post(Uri uri, string content)
        {
            return Execute(HttpRequestType.POST, uri, content: content);
        }

        public Task<HttpResponseMessage> PostAsync(Uri uri, string content)
        {
            return ExecuteAsync(HttpRequestType.POST, uri, content: content);
        }

        #endregion

        #region PUT methods
        public HttpResponseMessage Put(string relativeUri, string content = null)
        {
            return Execute(HttpRequestType.PUT, relativeUri: relativeUri, content: content);
        }

        public Task<HttpResponseMessage> PutAsync(string relativeUri, string content = null)
        {
            return ExecuteAsync(HttpRequestType.PUT, relativeUri: relativeUri, content: content);
        }

        public HttpResponseMessage Put(Uri uri, string content = null)
        {
            return Execute(HttpRequestType.PUT, uri, content: content);
        }

        public Task<HttpResponseMessage> PutAsync(Uri uri, string content = null)
        {
            return ExecuteAsync(HttpRequestType.PUT, uri, content: content);
        }

        #endregion

        #region DELETE methods
        public HttpResponseMessage Delete(string relativeUri)
        {
            return Execute(HttpRequestType.DELETE, relativeUri: relativeUri);
        }

        public Task<HttpResponseMessage> DeleteAsync(string relativeUri)
        {
            return ExecuteAsync(HttpRequestType.DELETE, relativeUri: relativeUri);
        }

        public HttpResponseMessage Delete(Uri uri)
        {
            return Execute(HttpRequestType.DELETE, uri);
        }

        public Task<HttpResponseMessage> DeleteAsync(Uri uri)
        {
            return ExecuteAsync(HttpRequestType.DELETE, uri);
        }

        #endregion
    }
}
