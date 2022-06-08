# Okta.Sdk.Api.SystemLogApi

All URIs are relative to *https://your-subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetLogs**](SystemLogApi.md#getlogs) | **GET** /api/v1/logs | Fetch a list of events from your Okta organization system log.


<a name="getlogs"></a>
# **GetLogs**
> List&lt;LogEvent&gt; GetLogs (DateTimeOffset? since = null, DateTimeOffset? until = null, string filter = null, string q = null, int? limit = null, string sortOrder = null, string after = null)

Fetch a list of events from your Okta organization system log.

The Okta System Log API provides read access to your organization’s system log. This API provides more functionality than the Events API

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetLogsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth 2.0
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
                // Fetch a list of events from your Okta organization system log.
                List<LogEvent> result = apiInstance.GetLogs(since, until, filter, q, limit, sortOrder, after);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SystemLogApi.GetLogs: " + e.Message );
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

[API Token](../README.md#API Token), [OAuth 2.0](../README.md#OAuth 2.0)

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

