# Okta.Sdk.Api.InlineHookApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateInlineHook**](InlineHookApi.md#activateinlinehook) | **POST** /api/v1/inlineHooks/{inlineHookId}/lifecycle/activate | Activate an Inline Hook
[**CreateInlineHook**](InlineHookApi.md#createinlinehook) | **POST** /api/v1/inlineHooks | Create an Inline Hook
[**DeactivateInlineHook**](InlineHookApi.md#deactivateinlinehook) | **POST** /api/v1/inlineHooks/{inlineHookId}/lifecycle/deactivate | Deactivate an Inline Hook
[**DeleteInlineHook**](InlineHookApi.md#deleteinlinehook) | **DELETE** /api/v1/inlineHooks/{inlineHookId} | Delete an Inline Hook
[**ExecuteInlineHook**](InlineHookApi.md#executeinlinehook) | **POST** /api/v1/inlineHooks/{inlineHookId}/execute | Execute an Inline Hook
[**GetInlineHook**](InlineHookApi.md#getinlinehook) | **GET** /api/v1/inlineHooks/{inlineHookId} | Retrieve an Inline Hook
[**ListInlineHooks**](InlineHookApi.md#listinlinehooks) | **GET** /api/v1/inlineHooks | List all Inline Hooks
[**ReplaceInlineHook**](InlineHookApi.md#replaceinlinehook) | **PUT** /api/v1/inlineHooks/{inlineHookId} | Replace an Inline Hook


<a name="activateinlinehook"></a>
# **ActivateInlineHook**
> InlineHook ActivateInlineHook (string inlineHookId)

Activate an Inline Hook

Activates the inline hook by `inlineHookId`

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InlineHookApi(config);
            var inlineHookId = Y7Rzrd4g4xj6WdKzrBHH;  // string | `id` of the Inline Hook

            try
            {
                // Activate an Inline Hook
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
 **inlineHookId** | **string**| &#x60;id&#x60; of the Inline Hook | 

### Return type

[**InlineHook**](InlineHook.md)

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

<a name="createinlinehook"></a>
# **CreateInlineHook**
> InlineHook CreateInlineHook (InlineHook inlineHook)

Create an Inline Hook

Creates an inline hook

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InlineHookApi(config);
            var inlineHook = new InlineHook(); // InlineHook | 

            try
            {
                // Create an Inline Hook
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

<a name="deactivateinlinehook"></a>
# **DeactivateInlineHook**
> InlineHook DeactivateInlineHook (string inlineHookId)

Deactivate an Inline Hook

Deactivates the inline hook by `inlineHookId`

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InlineHookApi(config);
            var inlineHookId = Y7Rzrd4g4xj6WdKzrBHH;  // string | `id` of the Inline Hook

            try
            {
                // Deactivate an Inline Hook
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
 **inlineHookId** | **string**| &#x60;id&#x60; of the Inline Hook | 

### Return type

[**InlineHook**](InlineHook.md)

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

<a name="deleteinlinehook"></a>
# **DeleteInlineHook**
> void DeleteInlineHook (string inlineHookId)

Delete an Inline Hook

Deletes an inline hook by `inlineHookId`. Once deleted, the Inline Hook is unrecoverable. As a safety precaution, only Inline Hooks with a status of INACTIVE are eligible for deletion.

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InlineHookApi(config);
            var inlineHookId = Y7Rzrd4g4xj6WdKzrBHH;  // string | `id` of the Inline Hook

            try
            {
                // Delete an Inline Hook
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
 **inlineHookId** | **string**| &#x60;id&#x60; of the Inline Hook | 

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

<a name="executeinlinehook"></a>
# **ExecuteInlineHook**
> InlineHookResponse ExecuteInlineHook (string inlineHookId, Object payloadData)

Execute an Inline Hook

Executes the inline hook by `inlineHookId` using the request body as the input. This will send the provided data through the Channel and return a response if it matches the correct data contract. This execution endpoint should only be used for testing purposes.

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InlineHookApi(config);
            var inlineHookId = Y7Rzrd4g4xj6WdKzrBHH;  // string | `id` of the Inline Hook
            var payloadData = null;  // Object | 

            try
            {
                // Execute an Inline Hook
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
 **inlineHookId** | **string**| &#x60;id&#x60; of the Inline Hook | 
 **payloadData** | **Object**|  | 

### Return type

[**InlineHookResponse**](InlineHookResponse.md)

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

<a name="getinlinehook"></a>
# **GetInlineHook**
> InlineHook GetInlineHook (string inlineHookId)

Retrieve an Inline Hook

Retrieves an inline hook by `inlineHookId`

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InlineHookApi(config);
            var inlineHookId = Y7Rzrd4g4xj6WdKzrBHH;  // string | `id` of the Inline Hook

            try
            {
                // Retrieve an Inline Hook
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
 **inlineHookId** | **string**| &#x60;id&#x60; of the Inline Hook | 

### Return type

[**InlineHook**](InlineHook.md)

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

<a name="listinlinehooks"></a>
# **ListInlineHooks**
> List&lt;InlineHook&gt; ListInlineHooks (string type = null)

List all Inline Hooks

Lists all inline hooks

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InlineHookApi(config);
            var type = "type_example";  // string |  (optional) 

            try
            {
                // List all Inline Hooks
                List<InlineHook> result = apiInstance.ListInlineHooks(type).ToListAsync();
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

<a name="replaceinlinehook"></a>
# **ReplaceInlineHook**
> InlineHook ReplaceInlineHook (string inlineHookId, InlineHook inlineHook)

Replace an Inline Hook

Replaces an inline hook by `inlineHookId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceInlineHookExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InlineHookApi(config);
            var inlineHookId = Y7Rzrd4g4xj6WdKzrBHH;  // string | `id` of the Inline Hook
            var inlineHook = new InlineHook(); // InlineHook | 

            try
            {
                // Replace an Inline Hook
                InlineHook result = apiInstance.ReplaceInlineHook(inlineHookId, inlineHook);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InlineHookApi.ReplaceInlineHook: " + e.Message );
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
 **inlineHookId** | **string**| &#x60;id&#x60; of the Inline Hook | 
 **inlineHook** | [**InlineHook**](InlineHook.md)|  | 

### Return type

[**InlineHook**](InlineHook.md)

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

