# Okta.Sdk.Api.InlineHookApi

All URIs are relative to *https://your-subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateInlineHook**](InlineHookApi.md#activateinlinehook) | **POST** /api/v1/inlineHooks/{inlineHookId}/lifecycle/activate | Activate Inline Hook
[**CreateInlineHook**](InlineHookApi.md#createinlinehook) | **POST** /api/v1/inlineHooks | Create Inline Hook
[**DeactivateInlineHook**](InlineHookApi.md#deactivateinlinehook) | **POST** /api/v1/inlineHooks/{inlineHookId}/lifecycle/deactivate | Deactivate Inline Hook
[**DeleteInlineHook**](InlineHookApi.md#deleteinlinehook) | **DELETE** /api/v1/inlineHooks/{inlineHookId} | Delete Inline Hook
[**ExecuteInlineHook**](InlineHookApi.md#executeinlinehook) | **POST** /api/v1/inlineHooks/{inlineHookId}/execute | Execute Inline Hook
[**GetInlineHook**](InlineHookApi.md#getinlinehook) | **GET** /api/v1/inlineHooks/{inlineHookId} | Get Inline Hook
[**ListInlineHooks**](InlineHookApi.md#listinlinehooks) | **GET** /api/v1/inlineHooks | List Inline Hooks
[**UpdateInlineHook**](InlineHookApi.md#updateinlinehook) | **PUT** /api/v1/inlineHooks/{inlineHookId} | Update Inline Hook


<a name="activateinlinehook"></a>
# **ActivateInlineHook**
> InlineHook ActivateInlineHook (string inlineHookId)

Activate Inline Hook

Activates the Inline Hook matching the provided id

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateInlineHookExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            var apiInstance = new InlineHookApi(config);
            var inlineHookId = "inlineHookId_example";  // string | 

            try
            {
                // Activate Inline Hook
                InlineHook result = apiInstance.ActivateInlineHook(inlineHookId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InlineHookApi.ActivateInlineHook: " + e.Message );
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
 **inlineHookId** | **string**|  | 

### Return type

[**InlineHook**](InlineHook.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createinlinehook"></a>
# **CreateInlineHook**
> InlineHook CreateInlineHook (InlineHook inlineHook)

Create Inline Hook

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateInlineHookExample
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

            var apiInstance = new InlineHookApi(config);
            var inlineHook = new InlineHook(); // InlineHook | 

            try
            {
                // Create Inline Hook
                InlineHook result = apiInstance.CreateInlineHook(inlineHook);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InlineHookApi.CreateInlineHook: " + e.Message );
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
 **inlineHook** | [**InlineHook**](InlineHook.md)|  | 

### Return type

[**InlineHook**](InlineHook.md)

### Authorization

[API Token](../README.md#API Token), [OAuth 2.0](../README.md#OAuth 2.0)

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

<a name="deactivateinlinehook"></a>
# **DeactivateInlineHook**
> InlineHook DeactivateInlineHook (string inlineHookId)

Deactivate Inline Hook

Deactivates the Inline Hook matching the provided id

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateInlineHookExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            var apiInstance = new InlineHookApi(config);
            var inlineHookId = "inlineHookId_example";  // string | 

            try
            {
                // Deactivate Inline Hook
                InlineHook result = apiInstance.DeactivateInlineHook(inlineHookId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InlineHookApi.DeactivateInlineHook: " + e.Message );
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
 **inlineHookId** | **string**|  | 

### Return type

[**InlineHook**](InlineHook.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteinlinehook"></a>
# **DeleteInlineHook**
> void DeleteInlineHook (string inlineHookId)

Delete Inline Hook

Deletes the Inline Hook matching the provided id. Once deleted, the Inline Hook is unrecoverable. As a safety precaution, only Inline Hooks with a status of INACTIVE are eligible for deletion.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteInlineHookExample
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

            var apiInstance = new InlineHookApi(config);
            var inlineHookId = "inlineHookId_example";  // string | 

            try
            {
                // Delete Inline Hook
                apiInstance.DeleteInlineHook(inlineHookId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InlineHookApi.DeleteInlineHook: " + e.Message );
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
 **inlineHookId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[API Token](../README.md#API Token), [OAuth 2.0](../README.md#OAuth 2.0)

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

<a name="executeinlinehook"></a>
# **ExecuteInlineHook**
> InlineHookResponse ExecuteInlineHook (string inlineHookId, Object payloadData)

Execute Inline Hook

Executes the Inline Hook matching the provided inlineHookId using the request body as the input. This will send the provided data through the Channel and return a response if it matches the correct data contract. This execution endpoint should only be used for testing purposes.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ExecuteInlineHookExample
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

            var apiInstance = new InlineHookApi(config);
            var inlineHookId = "inlineHookId_example";  // string | 
            var payloadData = null;  // Object | 

            try
            {
                // Execute Inline Hook
                InlineHookResponse result = apiInstance.ExecuteInlineHook(inlineHookId, payloadData);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InlineHookApi.ExecuteInlineHook: " + e.Message );
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
 **inlineHookId** | **string**|  | 
 **payloadData** | **Object**|  | 

### Return type

[**InlineHookResponse**](InlineHookResponse.md)

### Authorization

[API Token](../README.md#API Token), [OAuth 2.0](../README.md#OAuth 2.0)

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

<a name="getinlinehook"></a>
# **GetInlineHook**
> InlineHook GetInlineHook (string inlineHookId)

Get Inline Hook

Gets an inline hook by ID

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetInlineHookExample
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

            var apiInstance = new InlineHookApi(config);
            var inlineHookId = "inlineHookId_example";  // string | 

            try
            {
                // Get Inline Hook
                InlineHook result = apiInstance.GetInlineHook(inlineHookId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InlineHookApi.GetInlineHook: " + e.Message );
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
 **inlineHookId** | **string**|  | 

### Return type

[**InlineHook**](InlineHook.md)

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
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listinlinehooks"></a>
# **ListInlineHooks**
> List&lt;InlineHook&gt; ListInlineHooks (string type = null)

List Inline Hooks

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListInlineHooksExample
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

            var apiInstance = new InlineHookApi(config);
            var type = "type_example";  // string |  (optional) 

            try
            {
                // List Inline Hooks
                List<InlineHook> result = apiInstance.ListInlineHooks(type);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InlineHookApi.ListInlineHooks: " + e.Message );
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
 **type** | **string**|  | [optional] 

### Return type

[**List&lt;InlineHook&gt;**](InlineHook.md)

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

<a name="updateinlinehook"></a>
# **UpdateInlineHook**
> InlineHook UpdateInlineHook (string inlineHookId, InlineHook inlineHook)

Update Inline Hook

Updates an inline hook by ID

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateInlineHookExample
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

            var apiInstance = new InlineHookApi(config);
            var inlineHookId = "inlineHookId_example";  // string | 
            var inlineHook = new InlineHook(); // InlineHook | 

            try
            {
                // Update Inline Hook
                InlineHook result = apiInstance.UpdateInlineHook(inlineHookId, inlineHook);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InlineHookApi.UpdateInlineHook: " + e.Message );
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
 **inlineHookId** | **string**|  | 
 **inlineHook** | [**InlineHook**](InlineHook.md)|  | 

### Return type

[**InlineHook**](InlineHook.md)

### Authorization

[API Token](../README.md#API Token), [OAuth 2.0](../README.md#OAuth 2.0)

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

