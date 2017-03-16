namespace Okta.Core
{
    using System;
    using System.Text;

    /// <summary>
    /// Builds a filter that follows Okta's expression language.
    /// </summary>
    public class FilterBuilder
    {
        public FilterBuilder() { }
        public FilterBuilder(string stringFilter)
        {
            stringBuilder.Append(stringFilter);
        }

        private StringBuilder stringBuilder = new StringBuilder();
        private const string equalSign = " eq ";
        private const string containSign = " co ";
        private const string startsWithSign = " sw ";
        private const string presentSign = " pr";
        private const string greaterThanSign = " gt ";
        private const string greaterThanOrEqualSign = " ge ";
        private const string lessThanSign = " lt ";
        private const string lessThanOrEqualSign = " le ";
        private const string andSign = " and ";
        private const string orSign = " or ";

        public override string ToString()
        {
            return this.stringBuilder.ToString();
        }

        private static string ConvertDateTime(DateTime dateTime)
        {
            return dateTime.ToString(Constants.DateFormat);
        }

        public FilterBuilder Where(string attr)
        {
            return this.Attr(attr);
        }

        public FilterBuilder Where(FilterBuilder filter)
        {
            stringBuilder.Append("(" + filter + ")");
            return this;
        }

        public FilterBuilder Attr(string attr)
        {
            stringBuilder.Append(attr);
            return this;
        }

        public FilterBuilder Value(string value)
        {
            stringBuilder.Append('"' + value + '"');
            return this;
        }

        public FilterBuilder Value(bool value)
        {
            stringBuilder.Append(value.ToString().ToLower());
            return this;
        }

        public FilterBuilder Value(int value)
        {
            stringBuilder.Append(value);
            return this;
        }

        public FilterBuilder Value(DateTime value)
        {
            stringBuilder.Append('"' + ConvertDateTime(value) + '"');
            return this;
        }

        private FilterBuilder EqualTo()
        {
            stringBuilder.Append(equalSign);
            return this;
        }

        public FilterBuilder EqualTo(string value)
        {
            return EqualTo().Value(value);
        }

        public FilterBuilder EqualTo(int value)
        {
            return EqualTo().Value(value);
        }

        public FilterBuilder EqualTo(bool value)
        {
            return EqualTo().Value(value);
        }

        public FilterBuilder EqualTo(DateTime value)
        {
            return EqualTo().Value(value);
        }

        private FilterBuilder Contains()
        {
            stringBuilder.Append(containSign);
            return this;
        }

        public FilterBuilder Contains(string value)
        {
            return Contains().Value(value);
        }

        public FilterBuilder Contains(int value)
        {
            return Contains().Value(value);
        }

        private FilterBuilder StartsWith()
        {
            stringBuilder.Append(startsWithSign);
            return this;
        }

        public FilterBuilder StartsWith(string value)
        {
            return StartsWith().Value(value);
        }

        public FilterBuilder StartsWith(int value)
        {
            return StartsWith().Value(value);
        }

        public FilterBuilder Present()
        {
            stringBuilder.Append(presentSign);
            return this;
        }

        public FilterBuilder Present(string value)
        {
            return Value(value).Present();
        }

        private FilterBuilder GreaterThan()
        {
            stringBuilder.Append(greaterThanSign);
            return this;
        }

        public FilterBuilder GreaterThan(string value)
        {
            return GreaterThan().Value(value);
        }

        public FilterBuilder GreaterThan(int value)
        {
            return GreaterThan().Value(value);
        }

        public FilterBuilder GreaterThan(DateTime value)
        {
            return GreaterThan().Value(value);
        }

        private FilterBuilder GreaterThanOrEqual()
        {
            stringBuilder.Append(greaterThanOrEqualSign);
            return this;
        }

        public FilterBuilder GreaterThanOrEqual(string value)
        {
            return GreaterThanOrEqual().Value(value);
        }

        public FilterBuilder GreaterThanOrEqual(int value)
        {
            return GreaterThanOrEqual().Value(value);
        }

        public FilterBuilder GreaterThanOrEqual(DateTime value)
        {
            return GreaterThanOrEqual().Value(value);
        }

        private FilterBuilder LessThan()
        {
            stringBuilder.Append(lessThanSign);
            return this;
        }

        public FilterBuilder LessThan(string value)
        {
            return LessThan().Value(value);
        }

        public FilterBuilder LessThan(int value)
        {
            return LessThan().Value(value);
        }

        public FilterBuilder LessThan(DateTime value)
        {
            return LessThan().Value(value);
        }

        private FilterBuilder LessThanOrEqual()
        {
            stringBuilder.Append(lessThanOrEqualSign);
            return this;
        }

        public FilterBuilder LessThanOrEqual(string value)
        {
            return LessThanOrEqual().Value(value);
        }

        public FilterBuilder LessThanOrEqual(int value)
        {
            return LessThanOrEqual().Value(value);
        }

        public FilterBuilder LessThanOrEqual(DateTime value)
        {
            return LessThanOrEqual().Value(value);
        }

        public FilterBuilder And()
        {
            stringBuilder.Append(andSign);
            return this;
        }

        public FilterBuilder And(FilterBuilder filter)
        {
            stringBuilder.Append(andSign);
            return Where(filter);
        }

        public FilterBuilder Or()
        {
            stringBuilder.Append(orSign);
            return this;
        }

        public FilterBuilder Or(FilterBuilder filter)
        {
            stringBuilder.Append(orSign);
            return Where(filter);
        }
    }

    public enum SearchType
    {
        Filter = 0,
        ElasticSearch = 1
    }
}