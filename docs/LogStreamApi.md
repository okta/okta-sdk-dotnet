# Okta.Sdk.Api.LogStreamApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateLogStream**](LogStreamApi.md#activatelogstream) | **POST** /api/v1/logStreams/{logStreamId}/lifecycle/activate | Activate a Log Stream
[**CreateLogStream**](LogStreamApi.md#createlogstream) | **POST** /api/v1/logStreams | Create a Log Stream
[**DeactivateLogStream**](LogStreamApi.md#deactivatelogstream) | **POST** /api/v1/logStreams/{logStreamId}/lifecycle/deactivate | Deactivate a Log Stream
[**DeleteLogStream**](LogStreamApi.md#deletelogstream) | **DELETE** /api/v1/logStreams/{logStreamId} | Delete a Log Stream
[**GetLogStream**](LogStreamApi.md#getlogstream) | **GET** /api/v1/logStreams/{logStreamId} | Retrieve a Log Stream
[**ListLogStreams**](LogStreamApi.md#listlogstreams) | **GET** /api/v1/logStreams | List all Log Streams
[**ReplaceLogStream**](LogStreamApi.md#replacelogstream) | **PUT** /api/v1/logStreams/{logStreamId} | Replace a Log Stream


<a name="activatelogstream"></a>
# **ActivateLogStream**
> LogStream ActivateLogStream (string logStreamId)

Activate a Log Stream

Activates a log stream by `logStreamId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateLogStreamExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new LogStreamApi(config);
            var logStreamId = 0oa1orzg0CHSgPcjZ0g4;  // string | Unique identifier for the Log Stream

            try
            {
                // Activate a Log Stream
                LogStream result = apiInstance.ActivateLogStream(logStreamId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling LogStreamApi.ActivateLogStream: " + e.Message );
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
 **logStreamId** | **string**| Unique identifier for the Log Stream | 

### Return type

[**LogStream**](LogStream.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createlogstream"></a>
# **CreateLogStream**
> LogStream CreateLogStream (LogStream instance)

Create a Log Stream

Creates a new Log Stream object

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateLogStreamExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new LogStreamApi(config);
            var instance = new LogStream(); // LogStream | 

            try
            {
                // Create a Log Stream
                LogStream result = apiInstance.CreateLogStream(instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling LogStreamApi.CreateLogStream: " + e.Message );
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
 **instance** | [**LogStream**](LogStream.md)|  | 

### Return type

[**LogStream**](LogStream.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** |  |  -  |
| **403** | Forbidden |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivatelogstream"></a>
# **DeactivateLogStream**
> LogStream DeactivateLogStream (string logStreamId)

Deactivate a Log Stream

Deactivates a log stream by `logStreamId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateLogStreamExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new LogStreamApi(config);
            var logStreamId = 0oa1orzg0CHSgPcjZ0g4;  // string | Unique identifier for the Log Stream

            try
            {
                // Deactivate a Log Stream
                LogStream result = apiInstance.DeactivateLogStream(logStreamId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling LogStreamApi.DeactivateLogStream: " + e.Message );
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
 **logStreamId** | **string**| Unique identifier for the Log Stream | 

### Return type

[**LogStream**](LogStream.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletelogstream"></a>
# **DeleteLogStream**
> void DeleteLogStream (string logStreamId)

Delete a Log Stream

Deletes a Log Stream object from your org by ID

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteLogStreamExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new LogStreamApi(config);
            var logStreamId = 0oa1orzg0CHSgPcjZ0g4;  // string | Unique identifier for the Log Stream

            try
            {
                // Delete a Log Stream
                apiInstance.DeleteLogStream(logStreamId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling LogStreamApi.DeleteLogStream: " + e.Message );
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
 **logStreamId** | **string**| Unique identifier for the Log Stream | 

### Return type

void (empty response body)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |
| **403** | Forbidden |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getlogstream"></a>
# **GetLogStream**
> LogStream GetLogStream (string logStreamId)

Retrieve a Log Stream

Retrieves a Log Stream object by ID

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetLogStreamExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new LogStreamApi(config);
            var logStreamId = 0oa1orzg0CHSgPcjZ0g4;  // string | Unique identifier for the Log Stream

            try
            {
                // Retrieve a Log Stream
                LogStream result = apiInstance.GetLogStream(logStreamId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling LogStreamApi.GetLogStream: " + e.Message );
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
 **logStreamId** | **string**| Unique identifier for the Log Stream | 

### Return type

[**LogStream**](LogStream.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listlogstreams"></a>
# **ListLogStreams**
> List&lt;LogStream&gt; ListLogStreams (string after = null, int? limit = null, string filter = null)

List all Log Streams

Lists all Log Stream objects in your org. You can request a paginated list or a subset of Log Streams that match a supported filter expression.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListLogStreamsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new LogStreamApi(config);
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](/#pagination) for more information. (optional) 
            var limit = 20;  // int? | A limit on the number of objects to return (optional)  (default to 20)
            var filter = type eq "aws_eventbridge";  // string | An expression that [filters](/#filter) the returned objects. You can only use the `eq` operator on either the `status` or `type` properties in the filter expression. (optional) 

            try
            {
                // List all Log Streams
                List<LogStream> result = apiInstance.ListLogStreams(after, limit, filter).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling LogStreamApi.ListLogStreams: " + e.Message );
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
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](/#pagination) for more information. | [optional] 
 **limit** | **int?**| A limit on the number of objects to return | [optional] [default to 20]
 **filter** | **string**| An expression that [filters](/#filter) the returned objects. You can only use the &#x60;eq&#x60; operator on either the &#x60;status&#x60; or &#x60;type&#x60; properties in the filter expression. | [optional] 

### Return type

[**List&lt;LogStream&gt;**](LogStream.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **403** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacelogstream"></a>
# **ReplaceLogStream**
> LogStream ReplaceLogStream (string logStreamId, LogStreamPutSchema instance)

Replace a Log Stream

Replaces the Log Stream object properties for a given ID.  This operation is typically used to update the configuration of a Log Stream. Depending on the type of Log Stream you want to update, certain properties can't be modified after the Log Stream is initially created. Use the [Retrieve the Log Stream Schema for the schema type](/openapi/okta-management/management/tag/Schema/#tag/Schema/operation/getLogStreamSchema) request to determine which properties you can update for the specific Log Stream type. Log Stream properties with the `\"writeOnce\" : true` attribute can't be updated after creation. You must still specify these `writeOnce` properties in the request body with the original values in the PUT request.  > **Note:** You don't have to specify properties that have both the `\"writeOnce\": true` and the `\"writeOnly\": true` attributes in the PUT request body. These property values are ignored even if you add them in the PUT request body.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceLogStreamExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new LogStreamApi(config);
            var logStreamId = 0oa1orzg0CHSgPcjZ0g4;  // string | Unique identifier for the Log Stream
            var instance = new LogStreamPutSchema(); // LogStreamPutSchema | 

            try
            {
                // Replace a Log Stream
                LogStream result = apiInstance.ReplaceLogStream(logStreamId, instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling LogStreamApi.ReplaceLogStream: " + e.Message );
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
 **logStreamId** | **string**| Unique identifier for the Log Stream | 
 **instance** | [**LogStreamPutSchema**](LogStreamPutSchema.md)|  | 

### Return type

[**LogStream**](LogStream.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

