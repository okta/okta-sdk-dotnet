# Okta.Sdk.Api.SystemLogApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ListLogEvents**](SystemLogApi.md#listlogevents) | **GET** /api/v1/logs | List all System Log Events


<a name="listlogevents"></a>
# **ListLogEvents**
> List&lt;LogEvent&gt; ListLogEvents (DateTimeOffset? since = null, DateTimeOffset? until = null, string filter = null, string q = null, int? limit = null, string sortOrder = null, string after = null)

List all System Log Events

Lists all system log events. The Okta System Log API provides read access to your organization’s system log. This API provides more functionality than the Events API

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
            var since = DateTime.Parse("2013-10-20T19:20:30+01:00");  // DateTimeOffset? |  (optional) 
            var until = DateTime.Parse("2013-10-20T19:20:30+01:00");  // DateTimeOffset? |  (optional) 
            var filter = "filter_example";  // string |  (optional) 
            var q = "q_example";  // string |  (optional) 
            var limit = 100;  // int? |  (optional)  (default to 100)
            var sortOrder = "\"ASCENDING\"";  // string |  (optional)  (default to "ASCENDING")
            var after = "after_example";  // string |  (optional) 

            try
            {
                // List all System Log Events
                List<LogEvent> result = apiInstance.ListLogEvents(since, until, filter, q, limit, sortOrder, after).ToListAsync();
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
 **since** | **DateTimeOffset?**|  | [optional] 
 **until** | **DateTimeOffset?**|  | [optional] 
 **filter** | **string**|  | [optional] 
 **q** | **string**|  | [optional] 
 **limit** | **int?**|  | [optional] [default to 100]
 **sortOrder** | **string**|  | [optional] [default to &quot;ASCENDING&quot;]
 **after** | **string**|  | [optional] 

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
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

