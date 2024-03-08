# Okta.Sdk.Api.EventHookApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateEventHook**](EventHookApi.md#activateeventhook) | **POST** /api/v1/eventHooks/{eventHookId}/lifecycle/activate | Activate an Event Hook
[**CreateEventHook**](EventHookApi.md#createeventhook) | **POST** /api/v1/eventHooks | Create an Event Hook
[**DeactivateEventHook**](EventHookApi.md#deactivateeventhook) | **POST** /api/v1/eventHooks/{eventHookId}/lifecycle/deactivate | Deactivate an Event Hook
[**DeleteEventHook**](EventHookApi.md#deleteeventhook) | **DELETE** /api/v1/eventHooks/{eventHookId} | Delete an Event Hook
[**GetEventHook**](EventHookApi.md#geteventhook) | **GET** /api/v1/eventHooks/{eventHookId} | Retrieve an Event Hook
[**ListEventHooks**](EventHookApi.md#listeventhooks) | **GET** /api/v1/eventHooks | List all Event Hooks
[**ReplaceEventHook**](EventHookApi.md#replaceeventhook) | **PUT** /api/v1/eventHooks/{eventHookId} | Replace an Event Hook
[**VerifyEventHook**](EventHookApi.md#verifyeventhook) | **POST** /api/v1/eventHooks/{eventHookId}/lifecycle/verify | Verify an Event Hook


<a name="activateeventhook"></a>
# **ActivateEventHook**
> EventHook ActivateEventHook (string eventHookId)

Activate an Event Hook

Activates an event hook

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateEventHookExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new EventHookApi(config);
            var eventHookId = YTDQbItFfFuy9RdHrvly;  // string | `id` of the Event Hook

            try
            {
                // Activate an Event Hook
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
 **eventHookId** | **string**| &#x60;id&#x60; of the Event Hook | 

### Return type

[**EventHook**](EventHook.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createeventhook"></a>
# **CreateEventHook**
> EventHook CreateEventHook (EventHook eventHook)

Create an Event Hook

Creates an event hook

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateEventHookExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new EventHookApi(config);
            var eventHook = new EventHook(); // EventHook | 

            try
            {
                // Create an Event Hook
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

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** |  |  -  |
| **403** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivateeventhook"></a>
# **DeactivateEventHook**
> EventHook DeactivateEventHook (string eventHookId)

Deactivate an Event Hook

Deactivates an event hook

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateEventHookExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new EventHookApi(config);
            var eventHookId = YTDQbItFfFuy9RdHrvly;  // string | `id` of the Event Hook

            try
            {
                // Deactivate an Event Hook
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
 **eventHookId** | **string**| &#x60;id&#x60; of the Event Hook | 

### Return type

[**EventHook**](EventHook.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteeventhook"></a>
# **DeleteEventHook**
> void DeleteEventHook (string eventHookId)

Delete an Event Hook

Deletes an event hook

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteEventHookExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new EventHookApi(config);
            var eventHookId = YTDQbItFfFuy9RdHrvly;  // string | `id` of the Event Hook

            try
            {
                // Delete an Event Hook
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
 **eventHookId** | **string**| &#x60;id&#x60; of the Event Hook | 

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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="geteventhook"></a>
# **GetEventHook**
> EventHook GetEventHook (string eventHookId)

Retrieve an Event Hook

Retrieves an event hook

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetEventHookExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new EventHookApi(config);
            var eventHookId = YTDQbItFfFuy9RdHrvly;  // string | `id` of the Event Hook

            try
            {
                // Retrieve an Event Hook
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
 **eventHookId** | **string**| &#x60;id&#x60; of the Event Hook | 

### Return type

[**EventHook**](EventHook.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listeventhooks"></a>
# **ListEventHooks**
> List&lt;EventHook&gt; ListEventHooks ()

List all Event Hooks

Lists all event hooks

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListEventHooksExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new EventHookApi(config);

            try
            {
                // List all Event Hooks
                List<EventHook> result = apiInstance.ListEventHooks().ToListAsync();
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

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **403** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replaceeventhook"></a>
# **ReplaceEventHook**
> EventHook ReplaceEventHook (string eventHookId, EventHook eventHook)

Replace an Event Hook

Replaces an event hook

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceEventHookExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new EventHookApi(config);
            var eventHookId = YTDQbItFfFuy9RdHrvly;  // string | `id` of the Event Hook
            var eventHook = new EventHook(); // EventHook | 

            try
            {
                // Replace an Event Hook
                EventHook result = apiInstance.ReplaceEventHook(eventHookId, eventHook);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling EventHookApi.ReplaceEventHook: " + e.Message );
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
 **eventHookId** | **string**| &#x60;id&#x60; of the Event Hook | 
 **eventHook** | [**EventHook**](EventHook.md)|  | 

### Return type

[**EventHook**](EventHook.md)

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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="verifyeventhook"></a>
# **VerifyEventHook**
> EventHook VerifyEventHook (string eventHookId)

Verify an Event Hook

Verifies an event hook

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class VerifyEventHookExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new EventHookApi(config);
            var eventHookId = YTDQbItFfFuy9RdHrvly;  // string | `id` of the Event Hook

            try
            {
                // Verify an Event Hook
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
 **eventHookId** | **string**| &#x60;id&#x60; of the Event Hook | 

### Return type

[**EventHook**](EventHook.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

