using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Okta.Core.Models;
using Okta.Core.Clients;

namespace Okta.Core
{
    /// <summary>
    /// An enumerable list of <see cref="Okta.Core.Models.OktaObject"/>s
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EnumerableResults<T> : IEnumerable<T> where T : OktaObject
    {
        public EnumerableResults(ApiClient<T> apiClient, PagedResults<T> pagedResults)
        {
            this.Client = apiClient;
            this.CurrentPage = pagedResults;
        }

        ApiClient<T> Client { get; set; }
        PagedResults<T> CurrentPage { get; set; }

        private IEnumerator<T> ResultsEnumerator()
        {
            do
            {
                foreach (var result in CurrentPage.Results)
                {
                    yield return result;
                }

                if (CurrentPage.NextPage != null)
                {
                    CurrentPage = Client.GetList(CurrentPage.NextPage);
                }
            }
            while (!CurrentPage.Read);
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return ResultsEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            // Lets call the generic version here
            return this.GetEnumerator();
        }
    }
}
