# Okta.Sdk.Api.ResourceSetApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AddMembersToBinding**](ResourceSetApi.md#addmemberstobinding) | **PATCH** /api/v1/iam/resource-sets/{resourceSetId}/bindings/{roleIdOrLabel}/members | Add more Members to a binding
[**AddResourceSetResource**](ResourceSetApi.md#addresourcesetresource) | **PATCH** /api/v1/iam/resource-sets/{resourceSetId}/resources | Add more Resource to a Resource Set
[**CreateResourceSet**](ResourceSetApi.md#createresourceset) | **POST** /api/v1/iam/resource-sets | Create a Resource Set
[**CreateResourceSetBinding**](ResourceSetApi.md#createresourcesetbinding) | **POST** /api/v1/iam/resource-sets/{resourceSetId}/bindings | Create a Resource Set Binding
[**DeleteBinding**](ResourceSetApi.md#deletebinding) | **DELETE** /api/v1/iam/resource-sets/{resourceSetId}/bindings/{roleIdOrLabel} | Delete a Binding
[**DeleteResourceSet**](ResourceSetApi.md#deleteresourceset) | **DELETE** /api/v1/iam/resource-sets/{resourceSetId} | Delete a Resource Set
[**DeleteResourceSetResource**](ResourceSetApi.md#deleteresourcesetresource) | **DELETE** /api/v1/iam/resource-sets/{resourceSetId}/resources/{resourceId} | Delete a Resource from a Resource Set
[**GetBinding**](ResourceSetApi.md#getbinding) | **GET** /api/v1/iam/resource-sets/{resourceSetId}/bindings/{roleIdOrLabel} | Retrieve a Binding
[**GetMemberOfBinding**](ResourceSetApi.md#getmemberofbinding) | **GET** /api/v1/iam/resource-sets/{resourceSetId}/bindings/{roleIdOrLabel}/members/{memberId} | Retrieve a Member of a binding
[**GetResourceSet**](ResourceSetApi.md#getresourceset) | **GET** /api/v1/iam/resource-sets/{resourceSetId} | Retrieve a Resource Set
[**ListBindings**](ResourceSetApi.md#listbindings) | **GET** /api/v1/iam/resource-sets/{resourceSetId}/bindings | List all Bindings
[**ListMembersOfBinding**](ResourceSetApi.md#listmembersofbinding) | **GET** /api/v1/iam/resource-sets/{resourceSetId}/bindings/{roleIdOrLabel}/members | List all Members of a binding
[**ListResourceSetResources**](ResourceSetApi.md#listresourcesetresources) | **GET** /api/v1/iam/resource-sets/{resourceSetId}/resources | List all Resources of a Resource Set
[**ListResourceSets**](ResourceSetApi.md#listresourcesets) | **GET** /api/v1/iam/resource-sets | List all Resource Sets
[**ReplaceResourceSet**](ResourceSetApi.md#replaceresourceset) | **PUT** /api/v1/iam/resource-sets/{resourceSetId} | Replace a Resource Set
[**UnassignMemberFromBinding**](ResourceSetApi.md#unassignmemberfrombinding) | **DELETE** /api/v1/iam/resource-sets/{resourceSetId}/bindings/{roleIdOrLabel}/members/{memberId} | Unassign a Member from a binding


<a name="addmemberstobinding"></a>
# **AddMembersToBinding**
> ResourceSetBindingResponse AddMembersToBinding (string resourceSetId, string roleIdOrLabel, ResourceSetBindingAddMembersRequest instance)

Add more Members to a binding

Adds more members to a Resource Set binding

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AddMembersToBindingExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ResourceSetApi(config);
            var resourceSetId = iamoJDFKaJxGIr0oamd9g;  // string | `id` of a Resource Set
            var roleIdOrLabel = cr0Yq6IJxGIr0ouum0g3;  // string | `id` or `label` of the role
            var instance = new ResourceSetBindingAddMembersRequest(); // ResourceSetBindingAddMembersRequest | 

            try
            {
                // Add more Members to a binding
                ResourceSetBindingResponse result = apiInstance.AddMembersToBinding(resourceSetId, roleIdOrLabel, instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ResourceSetApi.AddMembersToBinding: " + e.Message );
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
 **resourceSetId** | **string**| &#x60;id&#x60; of a Resource Set | 
 **roleIdOrLabel** | **string**| &#x60;id&#x60; or &#x60;label&#x60; of the role | 
 **instance** | [**ResourceSetBindingAddMembersRequest**](ResourceSetBindingAddMembersRequest.md)|  | 

### Return type

[**ResourceSetBindingResponse**](ResourceSetBindingResponse.md)

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
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="addresourcesetresource"></a>
# **AddResourceSetResource**
> ResourceSet AddResourceSetResource (string resourceSetId, ResourceSetResourcePatchRequest instance)

Add more Resource to a Resource Set

Adds more resources to a Resource Set

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AddResourceSetResourceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ResourceSetApi(config);
            var resourceSetId = iamoJDFKaJxGIr0oamd9g;  // string | `id` of a Resource Set
            var instance = new ResourceSetResourcePatchRequest(); // ResourceSetResourcePatchRequest | 

            try
            {
                // Add more Resource to a Resource Set
                ResourceSet result = apiInstance.AddResourceSetResource(resourceSetId, instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ResourceSetApi.AddResourceSetResource: " + e.Message );
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
 **resourceSetId** | **string**| &#x60;id&#x60; of a Resource Set | 
 **instance** | [**ResourceSetResourcePatchRequest**](ResourceSetResourcePatchRequest.md)|  | 

### Return type

[**ResourceSet**](ResourceSet.md)

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
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createresourceset"></a>
# **CreateResourceSet**
> ResourceSet CreateResourceSet (CreateResourceSetRequest instance)

Create a Resource Set

Creates a new Resource Set

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateResourceSetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ResourceSetApi(config);
            var instance = new CreateResourceSetRequest(); // CreateResourceSetRequest | 

            try
            {
                // Create a Resource Set
                ResourceSet result = apiInstance.CreateResourceSet(instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ResourceSetApi.CreateResourceSet: " + e.Message );
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
 **instance** | [**CreateResourceSetRequest**](CreateResourceSetRequest.md)|  | 

### Return type

[**ResourceSet**](ResourceSet.md)

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

<a name="createresourcesetbinding"></a>
# **CreateResourceSetBinding**
> ResourceSetBindingResponse CreateResourceSetBinding (string resourceSetId, ResourceSetBindingCreateRequest instance)

Create a Resource Set Binding

Creates a new Resource Set binding

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

            var apiInstance = new ResourceSetApi(config);
            var resourceSetId = iamoJDFKaJxGIr0oamd9g;  // string | `id` of a Resource Set
            var instance = new ResourceSetBindingCreateRequest(); // ResourceSetBindingCreateRequest | 

            try
            {
                // Create a Resource Set Binding
                ResourceSetBindingResponse result = apiInstance.CreateResourceSetBinding(resourceSetId, instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ResourceSetApi.CreateResourceSetBinding: " + e.Message );
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
 **resourceSetId** | **string**| &#x60;id&#x60; of a Resource Set | 
 **instance** | [**ResourceSetBindingCreateRequest**](ResourceSetBindingCreateRequest.md)|  | 

### Return type

[**ResourceSetBindingResponse**](ResourceSetBindingResponse.md)

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
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletebinding"></a>
# **DeleteBinding**
> void DeleteBinding (string resourceSetId, string roleIdOrLabel)

Delete a Binding

Deletes a Resource Set binding by `resourceSetId` and `roleIdOrLabel`

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

            var apiInstance = new ResourceSetApi(config);
            var resourceSetId = iamoJDFKaJxGIr0oamd9g;  // string | `id` of a Resource Set
            var roleIdOrLabel = cr0Yq6IJxGIr0ouum0g3;  // string | `id` or `label` of the role

            try
            {
                // Delete a Binding
                apiInstance.DeleteBinding(resourceSetId, roleIdOrLabel);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ResourceSetApi.DeleteBinding: " + e.Message );
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
 **resourceSetId** | **string**| &#x60;id&#x60; of a Resource Set | 
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
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteresourceset"></a>
# **DeleteResourceSet**
> void DeleteResourceSet (string resourceSetId)

Delete a Resource Set

Deletes a role by `resourceSetId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteResourceSetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ResourceSetApi(config);
            var resourceSetId = iamoJDFKaJxGIr0oamd9g;  // string | `id` of a Resource Set

            try
            {
                // Delete a Resource Set
                apiInstance.DeleteResourceSet(resourceSetId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ResourceSetApi.DeleteResourceSet: " + e.Message );
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
 **resourceSetId** | **string**| &#x60;id&#x60; of a Resource Set | 

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

<a name="deleteresourcesetresource"></a>
# **DeleteResourceSetResource**
> void DeleteResourceSetResource (string resourceSetId, string resourceId)

Delete a Resource from a Resource Set

Deletes a resource identified by `resourceId` from a Resource Set

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteResourceSetResourceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ResourceSetApi(config);
            var resourceSetId = iamoJDFKaJxGIr0oamd9g;  // string | `id` of a Resource Set
            var resourceId = ire106sQKoHoXXsAe0g4;  // string | `id` of a resource

            try
            {
                // Delete a Resource from a Resource Set
                apiInstance.DeleteResourceSetResource(resourceSetId, resourceId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ResourceSetApi.DeleteResourceSetResource: " + e.Message );
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
 **resourceSetId** | **string**| &#x60;id&#x60; of a Resource Set | 
 **resourceId** | **string**| &#x60;id&#x60; of a resource | 

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

<a name="getbinding"></a>
# **GetBinding**
> ResourceSetBindingResponse GetBinding (string resourceSetId, string roleIdOrLabel)

Retrieve a Binding

Retrieves a Resource Set binding by `resourceSetId` and `roleIdOrLabel`

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

            var apiInstance = new ResourceSetApi(config);
            var resourceSetId = iamoJDFKaJxGIr0oamd9g;  // string | `id` of a Resource Set
            var roleIdOrLabel = cr0Yq6IJxGIr0ouum0g3;  // string | `id` or `label` of the role

            try
            {
                // Retrieve a Binding
                ResourceSetBindingResponse result = apiInstance.GetBinding(resourceSetId, roleIdOrLabel);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ResourceSetApi.GetBinding: " + e.Message );
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
 **resourceSetId** | **string**| &#x60;id&#x60; of a Resource Set | 
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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getmemberofbinding"></a>
# **GetMemberOfBinding**
> ResourceSetBindingMember GetMemberOfBinding (string resourceSetId, string roleIdOrLabel, string memberId)

Retrieve a Member of a binding

Retrieves a member identified by `memberId` for a binding

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetMemberOfBindingExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ResourceSetApi(config);
            var resourceSetId = iamoJDFKaJxGIr0oamd9g;  // string | `id` of a Resource Set
            var roleIdOrLabel = cr0Yq6IJxGIr0ouum0g3;  // string | `id` or `label` of the role
            var memberId = irb1qe6PGuMc7Oh8N0g4;  // string | `id` of a member

            try
            {
                // Retrieve a Member of a binding
                ResourceSetBindingMember result = apiInstance.GetMemberOfBinding(resourceSetId, roleIdOrLabel, memberId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ResourceSetApi.GetMemberOfBinding: " + e.Message );
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
 **resourceSetId** | **string**| &#x60;id&#x60; of a Resource Set | 
 **roleIdOrLabel** | **string**| &#x60;id&#x60; or &#x60;label&#x60; of the role | 
 **memberId** | **string**| &#x60;id&#x60; of a member | 

### Return type

[**ResourceSetBindingMember**](ResourceSetBindingMember.md)

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

<a name="getresourceset"></a>
# **GetResourceSet**
> ResourceSet GetResourceSet (string resourceSetId)

Retrieve a Resource Set

Retrieves a Resource Set by `resourceSetId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetResourceSetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ResourceSetApi(config);
            var resourceSetId = iamoJDFKaJxGIr0oamd9g;  // string | `id` of a Resource Set

            try
            {
                // Retrieve a Resource Set
                ResourceSet result = apiInstance.GetResourceSet(resourceSetId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ResourceSetApi.GetResourceSet: " + e.Message );
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
 **resourceSetId** | **string**| &#x60;id&#x60; of a Resource Set | 

### Return type

[**ResourceSet**](ResourceSet.md)

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

<a name="listbindings"></a>
# **ListBindings**
> ResourceSetBindings ListBindings (string after = null)

List all Bindings

Lists all Resource Set bindings with pagination support

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

            var apiInstance = new ResourceSetApi(config);
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](/#pagination) for more information. (optional) 

            try
            {
                // List all Bindings
                ResourceSetBindings result = apiInstance.ListBindings(after);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ResourceSetApi.ListBindings: " + e.Message );
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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listmembersofbinding"></a>
# **ListMembersOfBinding**
> ResourceSetBindingMembers ListMembersOfBinding (string after = null)

List all Members of a binding

Lists all members of a Resource Set binding with pagination support

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListMembersOfBindingExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ResourceSetApi(config);
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](/#pagination) for more information. (optional) 

            try
            {
                // List all Members of a binding
                ResourceSetBindingMembers result = apiInstance.ListMembersOfBinding(after);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ResourceSetApi.ListMembersOfBinding: " + e.Message );
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

### Return type

[**ResourceSetBindingMembers**](ResourceSetBindingMembers.md)

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

<a name="listresourcesetresources"></a>
# **ListResourceSetResources**
> ResourceSetResources ListResourceSetResources (string resourceSetId)

List all Resources of a Resource Set

Lists all resources that make up the Resource Set

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListResourceSetResourcesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ResourceSetApi(config);
            var resourceSetId = iamoJDFKaJxGIr0oamd9g;  // string | `id` of a Resource Set

            try
            {
                // List all Resources of a Resource Set
                ResourceSetResources result = apiInstance.ListResourceSetResources(resourceSetId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ResourceSetApi.ListResourceSetResources: " + e.Message );
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
 **resourceSetId** | **string**| &#x60;id&#x60; of a Resource Set | 

### Return type

[**ResourceSetResources**](ResourceSetResources.md)

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

<a name="listresourcesets"></a>
# **ListResourceSets**
> ResourceSets ListResourceSets (string after = null)

List all Resource Sets

Lists all Resource Sets with pagination support

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListResourceSetsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ResourceSetApi(config);
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](/#pagination) for more information. (optional) 

            try
            {
                // List all Resource Sets
                ResourceSets result = apiInstance.ListResourceSets(after);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ResourceSetApi.ListResourceSets: " + e.Message );
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

### Return type

[**ResourceSets**](ResourceSets.md)

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

<a name="replaceresourceset"></a>
# **ReplaceResourceSet**
> ResourceSet ReplaceResourceSet (string resourceSetId, ResourceSet instance)

Replace a Resource Set

Replaces a Resource Set by `resourceSetId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceResourceSetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ResourceSetApi(config);
            var resourceSetId = iamoJDFKaJxGIr0oamd9g;  // string | `id` of a Resource Set
            var instance = new ResourceSet(); // ResourceSet | 

            try
            {
                // Replace a Resource Set
                ResourceSet result = apiInstance.ReplaceResourceSet(resourceSetId, instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ResourceSetApi.ReplaceResourceSet: " + e.Message );
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
 **resourceSetId** | **string**| &#x60;id&#x60; of a Resource Set | 
 **instance** | [**ResourceSet**](ResourceSet.md)|  | 

### Return type

[**ResourceSet**](ResourceSet.md)

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

<a name="unassignmemberfrombinding"></a>
# **UnassignMemberFromBinding**
> void UnassignMemberFromBinding (string resourceSetId, string roleIdOrLabel, string memberId)

Unassign a Member from a binding

Unassigns a member identified by `memberId` from a binding

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UnassignMemberFromBindingExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ResourceSetApi(config);
            var resourceSetId = iamoJDFKaJxGIr0oamd9g;  // string | `id` of a Resource Set
            var roleIdOrLabel = cr0Yq6IJxGIr0ouum0g3;  // string | `id` or `label` of the role
            var memberId = irb1qe6PGuMc7Oh8N0g4;  // string | `id` of a member

            try
            {
                // Unassign a Member from a binding
                apiInstance.UnassignMemberFromBinding(resourceSetId, roleIdOrLabel, memberId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ResourceSetApi.UnassignMemberFromBinding: " + e.Message );
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
 **resourceSetId** | **string**| &#x60;id&#x60; of a Resource Set | 
 **roleIdOrLabel** | **string**| &#x60;id&#x60; or &#x60;label&#x60; of the role | 
 **memberId** | **string**| &#x60;id&#x60; of a member | 

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

