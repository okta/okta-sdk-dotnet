# Okta.Sdk.Api.InlineHookApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateInlineHook**](InlineHookApi.md#activateinlinehook) | **POST** /api/v1/inlineHooks/{inlineHookId}/lifecycle/activate | Activate an inline hook
[**CreateInlineHook**](InlineHookApi.md#createinlinehook) | **POST** /api/v1/inlineHooks | Create an inline hook
[**DeactivateInlineHook**](InlineHookApi.md#deactivateinlinehook) | **POST** /api/v1/inlineHooks/{inlineHookId}/lifecycle/deactivate | Deactivate an inline hook
[**DeleteInlineHook**](InlineHookApi.md#deleteinlinehook) | **DELETE** /api/v1/inlineHooks/{inlineHookId} | Delete an inline hook
[**ExecuteInlineHook**](InlineHookApi.md#executeinlinehook) | **POST** /api/v1/inlineHooks/{inlineHookId}/execute | Execute an inline hook
[**GetInlineHook**](InlineHookApi.md#getinlinehook) | **GET** /api/v1/inlineHooks/{inlineHookId} | Retrieve an inline hook
[**ListInlineHooks**](InlineHookApi.md#listinlinehooks) | **GET** /api/v1/inlineHooks | List all inline hooks
[**ReplaceInlineHook**](InlineHookApi.md#replaceinlinehook) | **PUT** /api/v1/inlineHooks/{inlineHookId} | Replace an inline hook
[**UpdateInlineHook**](InlineHookApi.md#updateinlinehook) | **POST** /api/v1/inlineHooks/{inlineHookId} | Update an inline hook


<a name="activateinlinehook"></a>
# **ActivateInlineHook**
> InlineHook ActivateInlineHook (string inlineHookId)

Activate an inline hook

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
            var inlineHookId = Y7Rzrd4g4xj6WdKzrBHH;  // string | `id` of the inline hook

            try
            {
                // Activate an inline hook
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
 **inlineHookId** | **string**| &#x60;id&#x60; of the inline hook | 

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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createinlinehook"></a>
# **CreateInlineHook**
> InlineHookCreateResponse CreateInlineHook (InlineHookCreate inlineHookCreate)

Create an inline hook

Creates an inline hook  This endpoint creates an inline hook for your org in an `ACTIVE` status. You need to pass an inline hooks object in the JSON payload of your request.  That object represents the set of required information about the inline hook that you're registering, including:  * The URI of your external service endpoint * The type of inline hook you're registering * The type of authentication you're registering  There are two authentication options that you can configure for your inline hook: HTTP headers and OAuth 2.0 tokens.  HTTP headers let you specify a secret API key that you want Okta to pass to your external service endpoint (so that your external service can check for its presence as a security measure).  >**Note:** The API key that you set here is unrelated to the Okta API token you must supply when making calls to Okta APIs.  You can also optionally specify extra headers that you want Okta to pass to your external service with each call.  To configure HTTP header authentication, see parameters for the `config` object.  OAuth 2.0 tokens provide enhanced security between Okta and your external service. You can configure these tokens for the following types&mdash;client secret and private key.  >**Note:** Your external service's endpoint needs to be a valid HTTPS endpoint. The URI you specify should always begin with `https://`.  The total number of inline hooks that you can create in an Okta org is limited to 50, which is a combined total for any combination of inline hook types.

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
            var inlineHookCreate = new InlineHookCreate(); // InlineHookCreate | 

            try
            {
                // Create an inline hook
                InlineHookCreateResponse result = apiInstance.CreateInlineHook(inlineHookCreate);
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
 **inlineHookCreate** | [**InlineHookCreate**](InlineHookCreate.md)|  | 

### Return type

[**InlineHookCreateResponse**](InlineHookCreateResponse.md)

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

<a name="deactivateinlinehook"></a>
# **DeactivateInlineHook**
> InlineHook DeactivateInlineHook (string inlineHookId)

Deactivate an inline hook

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
            var inlineHookId = Y7Rzrd4g4xj6WdKzrBHH;  // string | `id` of the inline hook

            try
            {
                // Deactivate an inline hook
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
 **inlineHookId** | **string**| &#x60;id&#x60; of the inline hook | 

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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteinlinehook"></a>
# **DeleteInlineHook**
> void DeleteInlineHook (string inlineHookId)

Delete an inline hook

Deletes an inline hook by `inlineHookId`. After it's deleted, the inline hook is unrecoverable. As a safety precaution, only inline hooks with a status of `INACTIVE` are eligible for deletion.

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
            var inlineHookId = Y7Rzrd4g4xj6WdKzrBHH;  // string | `id` of the inline hook

            try
            {
                // Delete an inline hook
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
 **inlineHookId** | **string**| &#x60;id&#x60; of the inline hook | 

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

<a name="executeinlinehook"></a>
# **ExecuteInlineHook**
> ExecuteInlineHook200Response ExecuteInlineHook (string inlineHookId, ExecuteInlineHookRequest payloadData)

Execute an inline hook

Executes the inline hook that matches the provided `inlineHookId` by using the request body as the input. This inline hook sends the provided  data through the `channel` object and returns a response if it matches the correct data contract. Otherwise it returns an error. You need to  construct a JSON payload that matches the payloads that Okta would send to your external service for this inline hook type.  A timeout of three seconds is enforced on all outbound requests, with one retry in the event of a timeout or an error response from the remote system.  If a successful response isn't received after the request, a 400 error is returned with more information about what failed.  >**Note:** This execution endpoint isn't tied to any other functionality in Okta, and you should only use it for testing purposes.

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
            var inlineHookId = Y7Rzrd4g4xj6WdKzrBHH;  // string | `id` of the inline hook
            var payloadData = new ExecuteInlineHookRequest(); // ExecuteInlineHookRequest | 

            try
            {
                // Execute an inline hook
                ExecuteInlineHook200Response result = apiInstance.ExecuteInlineHook(inlineHookId, payloadData);
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
 **inlineHookId** | **string**| &#x60;id&#x60; of the inline hook | 
 **payloadData** | [**ExecuteInlineHookRequest**](ExecuteInlineHookRequest.md)|  | 

### Return type

[**ExecuteInlineHook200Response**](ExecuteInlineHook200Response.md)

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

<a name="getinlinehook"></a>
# **GetInlineHook**
> InlineHook GetInlineHook (string inlineHookId)

Retrieve an inline hook

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
            var inlineHookId = Y7Rzrd4g4xj6WdKzrBHH;  // string | `id` of the inline hook

            try
            {
                // Retrieve an inline hook
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
 **inlineHookId** | **string**| &#x60;id&#x60; of the inline hook | 

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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listinlinehooks"></a>
# **ListInlineHooks**
> List&lt;InlineHook&gt; ListInlineHooks (InlineHookTypeParameter? type = null)

List all inline hooks

Lists all inline hooks or all inline hooks of a specific type.  When listing a specific inline hook, you need to specify its type. The following types are currently supported:   | Type Value                         | Name                                                           |   |- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -|   | `com.okta.import.transform`        | [User import inline hook](/openapi/okta-management/management/tag/InlineHook/#tag/InlineHook/operation/createUserImportInlineHook)       |   | `com.okta.oauth2.tokens.transform` | [Token inline hook](/openapi/okta-management/management/tag/InlineHook/#tag/InlineHook/operation/createTokenInlineHook)               |   | `com.okta.saml.tokens.transform`   | [SAML assertion inline hook](/openapi/okta-management/management/tag/InlineHook/#tag/InlineHook/operation/createSAMLAssertionInlineHook)       |   | `com.okta.telephony.provider`      | [Telephony inline hook](/openapi/okta-management/management/tag/InlineHook/#tag/InlineHook/operation/createTelephonyInlineHook) |   | `com.okta.user.credential.password.import` | [Password import inline hook](/openapi/okta-management/management/tag/InlineHook/#tag/InlineHook/operation/createPasswordImportInlineHook)|   | `com.okta.user.pre-registration`   | [Registration inline hook](/openapi/okta-management/management/tag/InlineHook/#tag/InlineHook/operation/create-registration-hook) |

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
            var type = (InlineHookTypeParameter) "com.okta.import.transform";  // InlineHookTypeParameter? | One of the supported inline hook types (optional) 

            try
            {
                // List all inline hooks
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
 **type** | **InlineHookTypeParameter?**| One of the supported inline hook types | [optional] 

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
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replaceinlinehook"></a>
# **ReplaceInlineHook**
> InlineHook ReplaceInlineHook (string inlineHookId, InlineHookReplace inlineHook)

Replace an inline hook

Replaces an inline hook by `inlineHookId`. The submitted inline hook properties replace the existing properties after passing validation.  >**Note:** Some properties are immutable and can't be updated.

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
            var inlineHookId = Y7Rzrd4g4xj6WdKzrBHH;  // string | `id` of the inline hook
            var inlineHook = new InlineHookReplace(); // InlineHookReplace | 

            try
            {
                // Replace an inline hook
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
 **inlineHookId** | **string**| &#x60;id&#x60; of the inline hook | 
 **inlineHook** | [**InlineHookReplace**](InlineHookReplace.md)|  | 

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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateinlinehook"></a>
# **UpdateInlineHook**
> InlineHook UpdateInlineHook (string inlineHookId, InlineHookReplace inlineHook)

Update an inline hook

Updates an inline hook by `inlineHookId`

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InlineHookApi(config);
            var inlineHookId = Y7Rzrd4g4xj6WdKzrBHH;  // string | `id` of the inline hook
            var inlineHook = new InlineHookReplace(); // InlineHookReplace | 

            try
            {
                // Update an inline hook
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
 **inlineHookId** | **string**| &#x60;id&#x60; of the inline hook | 
 **inlineHook** | [**InlineHookReplace**](InlineHookReplace.md)|  | 

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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

