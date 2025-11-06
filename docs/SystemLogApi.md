# Okta.Sdk.Api.SystemLogApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ListLogEvents**](SystemLogApi.md#listlogevents) | **GET** /api/v1/logs | List all System Log events


<a name="listlogevents"></a>
# **ListLogEvents**
> List&lt;LogEvent&gt; ListLogEvents (string since = null, string until = null, string after = null, string filter = null, string q = null, int? limit = null, SortOrderParameter? sortOrder = null)

List all System Log events

Lists all System Log events  See [System Log query](https://developer.okta.com/docs/reference/system-log-query/) for further details and examples, and [System Log filters and search](https://help.okta.com/okta_help.htm?type=oie&id=csh-syslog-filters) for common use cases.  By default, 100 System Log events are returned. If there are more events, see the [header link](https://developer.okta.com/docs/api/#link-header) for the `next` link, or increase the number of returned objects using the `limit` parameter.  >**Note:** The value of the `clientSecret` property in the System Log is secured by a hashing function, and isn't the value used during authentication.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListLogEventsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SystemLogApi(config);
            var since = "\"7 days prior to until\"";  // string | Filters the lower time bound of the log events `published` property for bounded queries or persistence time for polling queries (optional)  (default to "7 days prior to until")
            var until = "\"current time\"";  // string | Filters the upper time bound of the log events `published` property for bounded queries or persistence time for polling queries. (optional)  (default to "current time")
            var after = "after_example";  // string | Retrieves the next page of results. Okta returns a link in the HTTP Header (`rel=next`) that includes the after query parameter (optional) 
            var filter = "filter_example";  // string | Filter expression that filters the results. All operators except [ ] are supported. See [Filter](https://developer.okta.com/docs/api/#filter) and [Operators](https://developer.okta.com/docs/api/#operators). (optional) 
            var q = "q_example";  // string | Filters log events results by one or more case insensitive keywords. (optional) 
            var limit = 100;  // int? | Sets the number of results that are returned in the response (optional)  (default to 100)
            var sortOrder = (SortOrderParameter) "ASCENDING";  // SortOrderParameter? | The order of the returned events that are sorted by the `published` property (optional) 

            try
            {
                // List all System Log events
                List<LogEvent> result = apiInstance.ListLogEvents(since, until, after, filter, q, limit, sortOrder).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SystemLogApi.ListLogEvents: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **since** | **string**| Filters the lower time bound of the log events &#x60;published&#x60; property for bounded queries or persistence time for polling queries | [optional] [default to &quot;7 days prior to until&quot;]
 **until** | **string**| Filters the upper time bound of the log events &#x60;published&#x60; property for bounded queries or persistence time for polling queries. | [optional] [default to &quot;current time&quot;]
 **after** | **string**| Retrieves the next page of results. Okta returns a link in the HTTP Header (&#x60;rel&#x3D;next&#x60;) that includes the after query parameter | [optional] 
 **filter** | **string**| Filter expression that filters the results. All operators except [ ] are supported. See [Filter](https://developer.okta.com/docs/api/#filter) and [Operators](https://developer.okta.com/docs/api/#operators). | [optional] 
 **q** | **string**| Filters log events results by one or more case insensitive keywords. | [optional] 
 **limit** | **int?**| Sets the number of results that are returned in the response | [optional] [default to 100]
 **sortOrder** | **SortOrderParameter?**| The order of the returned events that are sorted by the &#x60;published&#x60; property | [optional] 

### Return type

[**List&lt;LogEvent&gt;**](LogEvent.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

