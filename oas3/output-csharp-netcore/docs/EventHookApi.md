# Org.OpenAPITools.Api.EventHookApi

All URIs are relative to *https://your-subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateEventHook**](EventHookApi.md#activateeventhook) | **POST** /api/v1/eventHooks/{eventHookId}/lifecycle/activate | Activate Event Hook
[**CreateEventHook**](EventHookApi.md#createeventhook) | **POST** /api/v1/eventHooks | Create Event Hook
[**DeactivateEventHook**](EventHookApi.md#deactivateeventhook) | **POST** /api/v1/eventHooks/{eventHookId}/lifecycle/deactivate | Deactivate Event Hook
[**DeleteEventHook**](EventHookApi.md#deleteeventhook) | **DELETE** /api/v1/eventHooks/{eventHookId} | Delete Event Hook
[**GetEventHook**](EventHookApi.md#geteventhook) | **GET** /api/v1/eventHooks/{eventHookId} | Get Event Hook
[**ListEventHooks**](EventHookApi.md#listeventhooks) | **GET** /api/v1/eventHooks | List Event Hooks
[**UpdateEventHook**](EventHookApi.md#updateeventhook) | **PUT** /api/v1/eventHooks/{eventHookId} | Update Event Hook
[**VerifyEventHook**](EventHookApi.md#verifyeventhook) | **POST** /api/v1/eventHooks/{eventHookId}/lifecycle/verify | Verify Event Hook


<a name="activateeventhook"></a>
# **ActivateEventHook**
> EventHook ActivateEventHook (string eventHookId)

Activate Event Hook

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ActivateEventHookExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new EventHookApi(config);
            var eventHookId = "eventHookId_example";  // string | 

            try
            {
                // Activate Event Hook
                EventHook result = apiInstance.ActivateEventHook(eventHookId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling EventHookApi.ActivateEventHook: " + e.Message );
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
 **eventHookId** | **string**|  | 

### Return type

[**EventHook**](EventHook.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createeventhook"></a>
# **CreateEventHook**
> EventHook CreateEventHook (EventHook eventHook)

Create Event Hook

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class CreateEventHookExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new EventHookApi(config);
            var eventHook = new EventHook(); // EventHook | 

            try
            {
                // Create Event Hook
                EventHook result = apiInstance.CreateEventHook(eventHook);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling EventHookApi.CreateEventHook: " + e.Message );
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
 **eventHook** | [**EventHook**](EventHook.md)|  | 

### Return type

[**EventHook**](EventHook.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivateeventhook"></a>
# **DeactivateEventHook**
> EventHook DeactivateEventHook (string eventHookId)

Deactivate Event Hook

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class DeactivateEventHookExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new EventHookApi(config);
            var eventHookId = "eventHookId_example";  // string | 

            try
            {
                // Deactivate Event Hook
                EventHook result = apiInstance.DeactivateEventHook(eventHookId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling EventHookApi.DeactivateEventHook: " + e.Message );
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
 **eventHookId** | **string**|  | 

### Return type

[**EventHook**](EventHook.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteeventhook"></a>
# **DeleteEventHook**
> void DeleteEventHook (string eventHookId)

Delete Event Hook

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class DeleteEventHookExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new EventHookApi(config);
            var eventHookId = "eventHookId_example";  // string | 

            try
            {
                // Delete Event Hook
                apiInstance.DeleteEventHook(eventHookId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling EventHookApi.DeleteEventHook: " + e.Message );
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
 **eventHookId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="geteventhook"></a>
# **GetEventHook**
> EventHook GetEventHook (string eventHookId)

Get Event Hook

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetEventHookExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new EventHookApi(config);
            var eventHookId = "eventHookId_example";  // string | 

            try
            {
                // Get Event Hook
                EventHook result = apiInstance.GetEventHook(eventHookId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling EventHookApi.GetEventHook: " + e.Message );
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
 **eventHookId** | **string**|  | 

### Return type

[**EventHook**](EventHook.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listeventhooks"></a>
# **ListEventHooks**
> List&lt;EventHook&gt; ListEventHooks ()

List Event Hooks

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ListEventHooksExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new EventHookApi(config);

            try
            {
                // List Event Hooks
                List<EventHook> result = apiInstance.ListEventHooks();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling EventHookApi.ListEventHooks: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List&lt;EventHook&gt;**](EventHook.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateeventhook"></a>
# **UpdateEventHook**
> EventHook UpdateEventHook (string eventHookId, EventHook eventHook)

Update Event Hook

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class UpdateEventHookExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new EventHookApi(config);
            var eventHookId = "eventHookId_example";  // string | 
            var eventHook = new EventHook(); // EventHook | 

            try
            {
                // Update Event Hook
                EventHook result = apiInstance.UpdateEventHook(eventHookId, eventHook);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling EventHookApi.UpdateEventHook: " + e.Message );
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
 **eventHookId** | **string**|  | 
 **eventHook** | [**EventHook**](EventHook.md)|  | 

### Return type

[**EventHook**](EventHook.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="verifyeventhook"></a>
# **VerifyEventHook**
> EventHook VerifyEventHook (string eventHookId)

Verify Event Hook

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class VerifyEventHookExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new EventHookApi(config);
            var eventHookId = "eventHookId_example";  // string | 

            try
            {
                // Verify Event Hook
                EventHook result = apiInstance.VerifyEventHook(eventHookId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling EventHookApi.VerifyEventHook: " + e.Message );
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
 **eventHookId** | **string**|  | 

### Return type

[**EventHook**](EventHook.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

