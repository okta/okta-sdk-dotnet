# Okta.Sdk.Api.EventHookApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateEventHook**](EventHookApi.md#activateeventhook) | **POST** /api/v1/eventHooks/{eventHookId}/lifecycle/activate | Activate an event hook
[**CreateEventHook**](EventHookApi.md#createeventhook) | **POST** /api/v1/eventHooks | Create an event hook
[**DeactivateEventHook**](EventHookApi.md#deactivateeventhook) | **POST** /api/v1/eventHooks/{eventHookId}/lifecycle/deactivate | Deactivate an event hook
[**DeleteEventHook**](EventHookApi.md#deleteeventhook) | **DELETE** /api/v1/eventHooks/{eventHookId} | Delete an event hook
[**GetEventHook**](EventHookApi.md#geteventhook) | **GET** /api/v1/eventHooks/{eventHookId} | Retrieve an event hook
[**ListEventHooks**](EventHookApi.md#listeventhooks) | **GET** /api/v1/eventHooks | List all event hooks
[**ReplaceEventHook**](EventHookApi.md#replaceeventhook) | **PUT** /api/v1/eventHooks/{eventHookId} | Replace an event hook
[**VerifyEventHook**](EventHookApi.md#verifyeventhook) | **POST** /api/v1/eventHooks/{eventHookId}/lifecycle/verify | Verify an event hook


<a name="activateeventhook"></a>
# **ActivateEventHook**
> EventHook ActivateEventHook (string eventHookId)

Activate an event hook

Activates the event hook that matches the provided `id`

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
            var eventHookId = who8vt36qfNpCGz9H1e6;  // string | `id` of the Event Hook

            try
            {
                // Activate an event hook
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createeventhook"></a>
# **CreateEventHook**
> EventHook CreateEventHook (EventHook eventHook)

Create an event hook

Creates a new event hook for your organization in `ACTIVE` status. You pass an event hook object in the JSON payload of your request. That object represents the set of required information about the event hook you're registering, including:   * The URI of your external service   * The [events](https://developer.okta.com/docs/reference/api/event-types/) in Okta you want to subscribe to   * An optional event hook filter that can reduce the number of event hook calls. This is a self-service Early Access (EA) feature.     See [Create an event hook filter](https://developer.okta.com/docs/concepts/event-hooks/#create-an-event-hook-filter).      Additionally, you can specify a secret API key for Okta to pass to your external service endpoint for security verification. Note that the API key you set here is unrelated to the Okta API token you must supply when making calls to Okta APIs. Optionally, you can specify extra headers that Okta passes to your external service with each call. Your external service must use a valid HTTPS endpoint.

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
                // Create an event hook
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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivateeventhook"></a>
# **DeactivateEventHook**
> EventHook DeactivateEventHook (string eventHookId)

Deactivate an event hook

Deactivates the event hook that matches the provided `id`

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
            var eventHookId = who8vt36qfNpCGz9H1e6;  // string | `id` of the Event Hook

            try
            {
                // Deactivate an event hook
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteeventhook"></a>
# **DeleteEventHook**
> void DeleteEventHook (string eventHookId)

Delete an event hook

Deletes the event hook that matches the provided `id`. After deletion, the event hook is unrecoverable. As a safety precaution, you can only delete event hooks with a status of `INACTIVE`.

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
            var eventHookId = who8vt36qfNpCGz9H1e6;  // string | `id` of the Event Hook

            try
            {
                // Delete an event hook
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="geteventhook"></a>
# **GetEventHook**
> EventHook GetEventHook (string eventHookId)

Retrieve an event hook

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
            var eventHookId = who8vt36qfNpCGz9H1e6;  // string | `id` of the Event Hook

            try
            {
                // Retrieve an event hook
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listeventhooks"></a>
# **ListEventHooks**
> List&lt;EventHook&gt; ListEventHooks ()

List all event hooks

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
                // List all event hooks
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
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replaceeventhook"></a>
# **ReplaceEventHook**
> EventHook ReplaceEventHook (string eventHookId, EventHook eventHook)

Replace an event hook

Replaces an event hook. Okta validates the new properties before replacing the existing values. Some event hook properties are immutable and can't be updated. Refer to the parameter description in the request body schema.  >**Note:** Updating the `channel` property requires you to verify the hook again.

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
            var eventHookId = who8vt36qfNpCGz9H1e6;  // string | `id` of the Event Hook
            var eventHook = new EventHook(); // EventHook | 

            try
            {
                // Replace an event hook
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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="verifyeventhook"></a>
# **VerifyEventHook**
> EventHook VerifyEventHook (string eventHookId)

Verify an event hook

Verifies that the event hook matches the provided `eventHookId`. To verify ownership, your endpoint must send information back to Okta in JSON format. See [Event hooks](https://developer.okta.com/docs/concepts/event-hooks/#one-time-verification-request).  Only `ACTIVE` and `VERIFIED` event hooks can receive events from Okta.  If a response is not received within 3 seconds, the outbound request times out. One retry is attempted after a timeout or error response. If a successful response still isn't received, this operation returns a 400 error with more information about the failure.

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
            var eventHookId = who8vt36qfNpCGz9H1e6;  // string | `id` of the Event Hook

            try
            {
                // Verify an event hook
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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

