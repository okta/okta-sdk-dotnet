# Okta.Sdk.Api.RoleDResourceSetBindingApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateResourceSetBinding**](RoleDResourceSetBindingApi.md#createresourcesetbinding) | **POST** /api/v1/iam/resource-sets/{resourceSetIdOrLabel}/bindings | Create a role resource set binding
[**DeleteBinding**](RoleDResourceSetBindingApi.md#deletebinding) | **DELETE** /api/v1/iam/resource-sets/{resourceSetIdOrLabel}/bindings/{roleIdOrLabel} | Delete a role resource set binding
[**GetBinding**](RoleDResourceSetBindingApi.md#getbinding) | **GET** /api/v1/iam/resource-sets/{resourceSetIdOrLabel}/bindings/{roleIdOrLabel} | Retrieve a role resource set binding
[**ListBindings**](RoleDResourceSetBindingApi.md#listbindings) | **GET** /api/v1/iam/resource-sets/{resourceSetIdOrLabel}/bindings | List all role resource set bindings


<a name="createresourcesetbinding"></a>
# **CreateResourceSetBinding**
> ResourceSetBindingEditResponse CreateResourceSetBinding (string resourceSetIdOrLabel, ResourceSetBindingCreateRequest instance)

Create a role resource set binding

Creates a binding for the resource set, custom role, and members (users or groups)  > **Note:** If you use a custom role with permissions that don't apply to the resources in the resource set, it doesn't affect the admin role. For example,  the `okta.users.userprofile.manage` permission gives the admin no privileges if it's granted to a resource set that only includes `https://{yourOktaDomain}/api/v1/groups/{targetGroupId}`  resources. If you want the admin to be able to manage the users within the group, the resource set must include the corresponding `https://{yourOktaDomain}/api/v1/groups/{targetGroupId}/users` resource.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateResourceSetBindingExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleDResourceSetBindingApi(config);
            var resourceSetIdOrLabel = iamoJDFKaJxGIr0oamd9g;  // string | `id` or `label` of the resource set
            var instance = new ResourceSetBindingCreateRequest(); // ResourceSetBindingCreateRequest | 

            try
            {
                // Create a role resource set binding
                ResourceSetBindingEditResponse result = apiInstance.CreateResourceSetBinding(resourceSetIdOrLabel, instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleDResourceSetBindingApi.CreateResourceSetBinding: " + e.Message );
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
 **resourceSetIdOrLabel** | **string**| &#x60;id&#x60; or &#x60;label&#x60; of the resource set | 
 **instance** | [**ResourceSetBindingCreateRequest**](ResourceSetBindingCreateRequest.md)|  | 

### Return type

[**ResourceSetBindingEditResponse**](ResourceSetBindingEditResponse.md)

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

<a name="deletebinding"></a>
# **DeleteBinding**
> void DeleteBinding (string resourceSetIdOrLabel, string roleIdOrLabel)

Delete a role resource set binding

Deletes a binding of a role (identified by `roleIdOrLabel`) and a resource set (identified by `resourceSetIdOrLabel`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteBindingExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleDResourceSetBindingApi(config);
            var resourceSetIdOrLabel = iamoJDFKaJxGIr0oamd9g;  // string | `id` or `label` of the resource set
            var roleIdOrLabel = cr0Yq6IJxGIr0ouum0g3;  // string | `id` or `label` of the role

            try
            {
                // Delete a role resource set binding
                apiInstance.DeleteBinding(resourceSetIdOrLabel, roleIdOrLabel);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleDResourceSetBindingApi.DeleteBinding: " + e.Message );
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
 **resourceSetIdOrLabel** | **string**| &#x60;id&#x60; or &#x60;label&#x60; of the resource set | 
 **roleIdOrLabel** | **string**| &#x60;id&#x60; or &#x60;label&#x60; of the role | 

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

<a name="getbinding"></a>
# **GetBinding**
> ResourceSetBindingResponse GetBinding (string resourceSetIdOrLabel, string roleIdOrLabel)

Retrieve a role resource set binding

Retrieves the binding of a role (identified by `roleIdOrLabel`) for a resource set (identified by `resourceSetIdOrLabel`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetBindingExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleDResourceSetBindingApi(config);
            var resourceSetIdOrLabel = iamoJDFKaJxGIr0oamd9g;  // string | `id` or `label` of the resource set
            var roleIdOrLabel = cr0Yq6IJxGIr0ouum0g3;  // string | `id` or `label` of the role

            try
            {
                // Retrieve a role resource set binding
                ResourceSetBindingResponse result = apiInstance.GetBinding(resourceSetIdOrLabel, roleIdOrLabel);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleDResourceSetBindingApi.GetBinding: " + e.Message );
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
 **resourceSetIdOrLabel** | **string**| &#x60;id&#x60; or &#x60;label&#x60; of the resource set | 
 **roleIdOrLabel** | **string**| &#x60;id&#x60; or &#x60;label&#x60; of the role | 

### Return type

[**ResourceSetBindingResponse**](ResourceSetBindingResponse.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listbindings"></a>
# **ListBindings**
> ResourceSetBindings ListBindings (string resourceSetIdOrLabel, string after = null)

List all role resource set bindings

Lists all bindings for a resource set with pagination support.  The returned `roles` array contains the roles for each binding associated with the specified resource set. If there are more than 100 bindings for the specified resource set, `links.next` provides the resource with pagination for the next list of bindings.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListBindingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleDResourceSetBindingApi(config);
            var resourceSetIdOrLabel = iamoJDFKaJxGIr0oamd9g;  // string | `id` or `label` of the resource set
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 

            try
            {
                // List all role resource set bindings
                ResourceSetBindings result = apiInstance.ListBindings(resourceSetIdOrLabel, after);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleDResourceSetBindingApi.ListBindings: " + e.Message );
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
 **resourceSetIdOrLabel** | **string**| &#x60;id&#x60; or &#x60;label&#x60; of the resource set | 
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 

### Return type

[**ResourceSetBindings**](ResourceSetBindings.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

