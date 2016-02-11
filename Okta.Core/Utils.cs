namespace Okta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Threading;

    using Newtonsoft.Json;

    internal class Utils
    {
        public static Tuple<string, Uri> ParseLinkHeader(string header)
        {
            if (header == null)
            {
                throw new OktaException("Cannot parse a null header", new ArgumentNullException("header"));
            }

            // Parse this format: <http://rain.okta1.com:1802/api/v1/users?pageSize=10000>; rel="self"

            // Split the header on semicolons
            var split = header.Split(';');

            if (split.Count() == 1)
            {
                throw new OktaException("The header \"" + header + "\" is formatted improperly");
            }

            // Get and sanitize the url
            var url = split[0];
            url = url.Trim('<', '>', ' ');

            if(!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                throw new OktaException("The header uri \"" + url + "\" is not an absolute URI");
            }

            // Get and sanitize the relation
            var relation = split[1];
            var relationSplit = relation.Split('=');

            if (relationSplit.Count() == 1)
            {
                throw new OktaException("The header \"" + header + "\" is formatted improperly");
            }

            relation = relationSplit[1];
            relation = relation.Trim('"');

            return new Tuple<string, Uri>(relation, new Uri(url));
        }

        private static OktaJsonConverter oktaJsonConverter = new OktaJsonConverter();
        public static T Deserialize<T>(string value)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(value, oktaJsonConverter);
            }
            catch (Exception e)
            {
                throw new OktaException("Unable to deserialize the response properly", e);
            }
        }

        public static T Deserialize<T>(HttpResponseMessage response)
        {
            string content;
            try
            {
                content = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                throw new OktaException("Unable to read the results of the Http response", e);
            }

            return Deserialize<T>(content);
        }

        public static object DeserializeObject(string value, Type type)
        {
            try
            {
                return JsonConvert.DeserializeObject(value, type, oktaJsonConverter);
            }
            catch (Exception e)
            {
                throw new OktaException("Unable to deserialize the response properly", e);
            }
        }

        public static string SerializeObject(object value)
        {
            try
            {
                return JsonConvert.SerializeObject(value, oktaJsonConverter);
            }
            catch (Exception e)
            {
                throw new OktaException("Unable to serialize the object properly", e);
            }
        }

        internal static string StripPairedQuotes(string s)
        {
            // We only remove quotes if they are a pair
            if (s.Length > 1 && s.StartsWith("\"") && s.EndsWith("\""))
            {
                return s.Remove(s.Length - 1).Remove(0);
            }

            return s;
        }

        internal static string AddPairedQuotes(string s)
        {
            return s.Insert(s.Length, "\"").Insert(0, "\"");
        }

        public static string BuildUrlParams(Dictionary<string, object> urlParams)
        {
            if (urlParams == null || urlParams.Count < 1)
            {
                return string.Empty;
            }

            var paramList = new List<string>();
            foreach (var kvp in urlParams)
            {
                paramList.Add(kvp.Key + "=" + kvp.Value);
            }

            return "?" + string.Join("&", paramList);
        }

        public static void Sleep(int milliseconds)
        {
            if (milliseconds > 0)
            {
                // Cross platform sleep
                using (var mre = new ManualResetEvent(false))
                {
                    mre.WaitOne(milliseconds);
                }
            }
        }

        public static string GetAssemblyVersion()
        {
            return new AssemblyName(typeof(Utils).Assembly.FullName).Version.ToString();
        }
    }
}
