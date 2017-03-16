namespace Okta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Okta.Core.Models;

    /// <summary>
    /// A single page of <see cref="Okta.Core.Models.OktaObject"/>s
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedResults<T> where T : OktaObject
    {
        public PagedResults(IList<T> results)
        {
            this.Results = results;
        }

        private IList<T> _results;
        public IList<T> Results
        {
            get
            {
                Read = true;
                return _results;
            }

            private set
            {
                _results = value;
            }
        }

        public bool Read { get; private set; }
        public string LastId { get { return Results.Last().Id; } }
        public Uri RequestUri { get; internal set; }
        public Uri NextPage { get; set; }
        public Uri PrevPage { get; set; }

        public bool IsLastPage
        {
            get { return Results == null ? false : this.NextPage == null; }
        }

        public bool IsFirstPage
        {
            get { return Results == null ? true : this.PrevPage == null; }
        }
    }
}
