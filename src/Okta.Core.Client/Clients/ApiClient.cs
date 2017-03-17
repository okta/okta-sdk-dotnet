namespace Okta.Core.Clients
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;

    using Okta.Core.Models;

    /// <summary>
    /// The base for clients with mostly CRUD operations
    /// </summary>
    /// <typeparam name="T"><see cref="OktaObject"/></typeparam>
    public class ApiClient<T> : AuthenticatedClient, IEnumerable<T>
        where T : OktaObject
    {
        protected string resourcePath { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient{T}"/> class.
        /// </summary>
        /// <param name="clientWrapper">The client wrapper.</param>
        /// <param name="resourcePath">The resource path.</param>
        public ApiClient(IOktaHttpClient clientWrapper, string resourcePath) : base(clientWrapper)
        {
            this.resourcePath = resourcePath;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient{T}"/> class. To be used ONLY when pointing to a *.okta.com tenant.
        /// </summary>
        /// <param name="apiToken">The API token.</param>
        /// <param name="subdomain">The production subdomain.</param>
        /// <param name="resourcePath">The resource path relative to the <see cref="AuthenticatedClient.BaseUri"/></param>
        public ApiClient(string apiToken, string subdomain, string resourcePath) : base(apiToken, subdomain)
        {
            this.resourcePath = resourcePath;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient{T}"/> class. To be used when pointing to a non-okta.com tenant. 
        /// </summary>
        /// <param name="apiToken">The API token.</param>
        /// <param name="uri">The Uri of the Okta (okta.com, oktapreview.com, okta-emea.com) subdomain.</param>
        /// <param name="resourcePath">The resource path relative to the <see cref="AuthenticatedClient.BaseUri"/></param>
        public ApiClient(string apiToken, Uri uri, string resourcePath) : base(apiToken, uri)
        {
            this.resourcePath = resourcePath;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient{T}"/> class.
        /// </summary>
        /// <param name="oktaSettings">The Okta settings to configure the <see cref="AuthenticatedClient.BaseClient"/></param>
        /// <param name="resourcePath">The resource path relative to the <see cref="AuthenticatedClient.BaseUri"/></param>
        public ApiClient(OktaSettings oktaSettings, string resourcePath) : base(oktaSettings)
        {
            this.resourcePath = resourcePath;
        }
        protected Uri GetRefreshUri(T oktaObject, params string[] extraResources)
        {
            if (oktaObject == null)
            {
                throw new ArgumentNullException("oktaObject");
            }

            // Start by trying to get the refresh uri of the object
            if (oktaObject.RefreshUri != null)
            {
                // Build a uri for this resource
                StringBuilder uri = new StringBuilder();
                uri.Append(oktaObject.RefreshUri);
                uri.Append(string.Join("/", extraResources));
                return new Uri(uri.ToString());
            }

            // Or try to build it
            if (oktaObject.Id != null)
            {
                return this.GetResourceUri(oktaObject.Id, extraResources);
            }

            // Otherwise, we're trying to get something that doesn't exist
            throw new OktaException("An object must have an href or an id");
        }

        protected Uri GetRefreshUri(string id, params string[] extraResources)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }

            StringBuilder uri = new StringBuilder();
            uri.Append(BaseClient.BaseUri.ToString().TrimEnd('/'));
            uri.Append(resourcePath);
            uri.Append("/" + id);
            uri.Append(string.Join("/", extraResources));
            return new Uri(uri.ToString());
        }

        protected Uri GetResourceUri(T oktaObject, params string[] extraResources)
        {
            if (oktaObject == null)
            {
                throw new ArgumentNullException("oktaObject");
            }

            if (oktaObject.SelfUri != null)
            {
                // Build a uri for this resource
                StringBuilder uri = new StringBuilder();
                uri.Append(oktaObject.SelfUri);
                uri.Append(string.Join("/", extraResources));
                return new Uri(uri.ToString());
            }

            // Then try to build it
            if (oktaObject.Id != null)
            {
                return this.GetResourceUri(oktaObject.Id, extraResources);
            }

            // Otherwise, we're trying to get something that doesn't exist
            throw new OktaException("An object must have an href or an id");
        }

        protected Uri GetResourceUri(string id, params string[] extraResources)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }

            StringBuilder uri = new StringBuilder();
            uri.Append(BaseClient.BaseUri.ToString().TrimEnd('/'));
            uri.Append(resourcePath);
            uri.Append("/" + id);
            uri.Append(string.Join("/", extraResources));
            return new Uri(uri.ToString());
        }

        protected virtual T Get(string id, Dictionary<string, object> urlParams = null)
        {
            var result = BaseClient.Get(this.GetResourceUri(id) + Utils.BuildUrlParams(urlParams));
            return Utils.Deserialize<T>(result);
        }

        protected virtual T Get(T oktaObject, Dictionary<string, object> urlParams = null)
        {
            var result = BaseClient.Get(this.GetResourceUri(oktaObject) + Utils.BuildUrlParams(urlParams));
            return Utils.Deserialize<T>(result);
        }

        protected virtual T Add(string id, string content = null, Dictionary<string, object> urlParams = null)
        {
            var result = BaseClient.Post(resourcePath + "/" + id + Utils.BuildUrlParams(urlParams), content);
            return Utils.Deserialize<T>(result);
        }

        protected virtual T Add(T oktaObject, Dictionary<string, object> urlParams = null)
        {
            var result = BaseClient.Post(resourcePath + Utils.BuildUrlParams(urlParams), oktaObject.ToJson());
            return Utils.Deserialize<T>(result);
        }

        protected virtual T Update(string id, string content = null, Dictionary<string, object> urlParams = null)
        {
            var result = BaseClient.Put(this.GetResourceUri(id) + Utils.BuildUrlParams(urlParams), content);
            return Utils.Deserialize<T>(result);
        }

        protected virtual T Update(T oktaObject, Dictionary<string, object> urlParams = null)
        {
            var result = BaseClient.Put(this.GetResourceUri(oktaObject) + Utils.BuildUrlParams(urlParams), oktaObject.ToJson());
            return Utils.Deserialize<T>(result);
        }

        protected virtual void Remove(string id, Dictionary<string, object> urlParams = null)
        {
            BaseClient.Delete(this.GetResourceUri(id) + Utils.BuildUrlParams(urlParams));
        }

        protected virtual void Remove(T oktaObject, Dictionary<string, object> urlParams = null)
        {
            BaseClient.Delete(this.GetResourceUri(oktaObject) + Utils.BuildUrlParams(urlParams));
        }

        /// <summary>
        /// Gets a single page list
        /// </summary>
        /// <param name="nextPage">The next page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="query">A query parameter supported by a few clients.</param>
        /// <param name="after">The cursor for where to begin the page.</param>
        /// <param name="startDate">A start date parameter supported by a few clients.</param>
        /// <returns>A single page list</returns>
        /// <exception cref="OktaException">Unable to convert the response from  + resourcePath +  to an enumerable</exception>
        public virtual PagedResults<T> GetList(
            Uri nextPage = null,
            int pageSize = Constants.DefaultPageSize,
            FilterBuilder filter = null,
            SearchType searchType = SearchType.Filter,
            string query = null,
            string after = null,
            DateTime? startDate = null)
        {
            // Ensure we have a non-empty query
            if (query == string.Empty)
            {
                query = null;
            }

            // Ensure we have a non-empty filter
            if (filter != null && filter.ToString() == string.Empty)
            {
                filter = null;
            }

            HttpResponseMessage result;
            if (nextPage != null)
            {
                result = BaseClient.Get(nextPage);
            }
            else
            {
                // Build the first request
                var path = new StringBuilder();
                path.Append(resourcePath);

                // Add a pageSize on every request
                path.Append("?limit=" + pageSize);

                // Add the filter if it exists
                if (filter != null)
                {
                    if (searchType == SearchType.Filter)
                        path.Append("&filter=" + filter);
                    else
                        path.Append("&search=" + filter);
                }

                // Add a query if it exists
                if (query != null)
                {
                    path.Append("&q=" + query);
                }

                // Add a start date if it exists
                if (startDate != null)
                {
                    path.Append("&startDate=" + startDate.Value.ToString(Constants.DateFormat));
                }

                // Add an after value if it exists
                if (after != null)
                {
                    path.Append("&after=" + after);
                }

                result = BaseClient.Get(path.ToString());
            }

            OktaExceptionResolver.ParseHttpResponse(result);
            var list = Utils.Deserialize<IList<T>>(result);
            if (list == null)
            {
                throw new OktaException("Unable to convert the response from " + resourcePath + " to an enumerable");
            }

            var results = new PagedResults<T>(list);
            results.RequestUri = result.RequestMessage.RequestUri;

            IEnumerable<string> linkHeaders;
            if (result.Headers.TryGetValues("Link", out linkHeaders))
            {
                foreach (var header in linkHeaders)
                {
                    // Split the header on semicolons
                    var split = header.Split(';');

                    // Get and sanitize the url
                    var url = split[0];
                    url = url.Trim('<', '>', ' ');

                    // Get and sanitize the relation
                    var relation = split[1];
                    relation = relation.Split('=')[1];
                    relation = relation.Trim('"');

                    if (relation == "self")
                    {
                        results.RequestUri = new Uri(url);
                    }
                    else if (relation == "next")
                    {
                        results.NextPage = new Uri(url);
                    }
                    else if (relation == "prev")
                    {
                        results.PrevPage = new Uri(url);
                    }
                }
            }

            return results;
        }

        /// <summary>
        /// An enumerator that handles pagination
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="query">A query parameter supported by a few clients.</param>
        /// <param name="after">The cursor for where to begin the page.</param>
        /// <param name="startDate">A start date parameter supported by a few clients.</param>
        /// <returns>An enumerator</returns>
        public virtual EnumerableResults<T> GetFilteredEnumerator(
            FilterBuilder filter = null,
            SearchType searchType = SearchType.Filter,
            int pageSize = Constants.DefaultPageSize,
            string query = null,
            string after = null,
            DateTime? startDate = null)
        {
            var nestedList = GetList(pageSize: pageSize, filter: filter, searchType: searchType, query: query, after: after, startDate: startDate);
            return new EnumerableResults<T>(this, nestedList);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetFilteredEnumerator().GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.GetFilteredEnumerator().GetEnumerator();
        }

        protected virtual HttpResponseMessage PerformLifecycle(
            T oktaObject,
            string lifecycle,
            string body = null,
            Dictionary<string, object> urlParams = null)
        {
            string urlParameters = string.Empty;
            if (urlParams != null)
            {
                urlParameters = Utils.BuildUrlParams(urlParams);
            }

            // If we have a link available
            if (oktaObject.Links.ContainsKey(lifecycle))
            {
                var link = oktaObject.Links[lifecycle].First();
                var results = BaseClient.Post(link.Href + urlParameters, body);
                return results;
            }

            // Otherwise, build one
            else
            {
                var results = BaseClient.Post(GetResourceUri(oktaObject) + Constants.LifecycleMap[lifecycle] + urlParameters, body);
                return results;
            }
        }

        protected virtual HttpResponseMessage PerformLifecycle(
            string id,
            string lifecycle,
            string body = null,
            Dictionary<string, object> urlParams = null)
        {
            string urlParameters = string.Empty;
            if (urlParams != null)
            {
                urlParameters = Utils.BuildUrlParams(urlParams);
            }

            var results = BaseClient.Post(GetResourceUri(id) + Constants.LifecycleMap[lifecycle] + urlParameters, body);
            return results;
        }
    }
}
