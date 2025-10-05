# Okta.Sdk.Api.RoleCResourceSetResourceApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AddResourceSetResource**](RoleCResourceSetResourceApi.md#addresourcesetresource) | **POST** /api/v1/iam/resource-sets/{resourceSetIdOrLabel}/resources | Add a resource set resource with conditions
[**AddResourceSetResources**](RoleCResourceSetResourceApi.md#addresourcesetresources) | **PATCH** /api/v1/iam/resource-sets/{resourceSetIdOrLabel}/resources | Add more resources to a resource set
[**DeleteResourceSetResource**](RoleCResourceSetResourceApi.md#deleteresourcesetresource) | **DELETE** /api/v1/iam/resource-sets/{resourceSetIdOrLabel}/resources/{resourceId} | Delete a resource set resource
[**GetResourceSetResource**](RoleCResourceSetResourceApi.md#getresourcesetresource) | **GET** /api/v1/iam/resource-sets/{resourceSetIdOrLabel}/resources/{resourceId} | Retrieve a resource set resource
[**ListResourceSetResources**](RoleCResourceSetResourceApi.md#listresourcesetresources) | **GET** /api/v1/iam/resource-sets/{resourceSetIdOrLabel}/resources | List all resource set resources
[**ReplaceResourceSetResource**](RoleCResourceSetResourceApi.md#replaceresourcesetresource) | **PUT** /api/v1/iam/resource-sets/{resourceSetIdOrLabel}/resources/{resourceId} | Replace the resource set resource conditions


<a name="addresourcesetresource"></a>
# **AddResourceSetResource**
> ResourceSetResource AddResourceSetResource (string resourceSetIdOrLabel, ResourceSetResourcePostRequest instance)

Add a resource set resource with conditions

Adds a resource with conditions for a resource set

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

            var apiInstance = new RoleCResourceSetResourceApi(config);
            var resourceSetIdOrLabel = iamoJDFKaJxGIr0oamd9g;  // string | `id` or `label` of the resource set
            var instance = new ResourceSetResourcePostRequest(); // ResourceSetResourcePostRequest | 

            try
            {
                // Add a resource set resource with conditions
                ResourceSetResource result = apiInstance.AddResourceSetResource(resourceSetIdOrLabel, instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleCResourceSetResourceApi.AddResourceSetResource: " + e.Message );
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
 **instance** | [**ResourceSetResourcePostRequest**](ResourceSetResourcePostRequest.md)|  | 

### Return type

[**ResourceSetResource**](ResourceSetResource.md)

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

<a name="addresourcesetresources"></a>
# **AddResourceSetResources**
> ResourceSet AddResourceSetResources (string resourceSetIdOrLabel, ResourceSetResourcePatchRequest instance)

Add more resources to a resource set

Adds more resources to a resource set

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AddResourceSetResourcesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleCResourceSetResourceApi(config);
            var resourceSetIdOrLabel = iamoJDFKaJxGIr0oamd9g;  // string | `id` or `label` of the resource set
            var instance = new ResourceSetResourcePatchRequest(); // ResourceSetResourcePatchRequest | 

            try
            {
                // Add more resources to a resource set
                ResourceSet result = apiInstance.AddResourceSetResources(resourceSetIdOrLabel, instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleCResourceSetResourceApi.AddResourceSetResources: " + e.Message );
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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteresourcesetresource"></a>
# **DeleteResourceSetResource**
> void DeleteResourceSetResource (string resourceSetIdOrLabel, string resourceId)

Delete a resource set resource

Deletes a resource (identified by `resourceId`) from a resource set

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

            var apiInstance = new RoleCResourceSetResourceApi(config);
            var resourceSetIdOrLabel = iamoJDFKaJxGIr0oamd9g;  // string | `id` or `label` of the resource set
            var resourceId = ire106sQKoHoXXsAe0g4;  // string | `id` of the resource

            try
            {
                // Delete a resource set resource
                apiInstance.DeleteResourceSetResource(resourceSetIdOrLabel, resourceId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleCResourceSetResourceApi.DeleteResourceSetResource: " + e.Message );
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
 **resourceId** | **string**| &#x60;id&#x60; of the resource | 

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

<a name="getresourcesetresource"></a>
# **GetResourceSetResource**
> ResourceSetResource GetResourceSetResource (string resourceSetIdOrLabel, string resourceId)

Retrieve a resource set resource

Retrieves a resource identified by `resourceId` in a resource set

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetResourceSetResourceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleCResourceSetResourceApi(config);
            var resourceSetIdOrLabel = iamoJDFKaJxGIr0oamd9g;  // string | `id` or `label` of the resource set
            var resourceId = ire106sQKoHoXXsAe0g4;  // string | `id` of the resource

            try
            {
                // Retrieve a resource set resource
                ResourceSetResource result = apiInstance.GetResourceSetResource(resourceSetIdOrLabel, resourceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleCResourceSetResourceApi.GetResourceSetResource: " + e.Message );
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
 **resourceId** | **string**| &#x60;id&#x60; of the resource | 

### Return type

[**ResourceSetResource**](ResourceSetResource.md)

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

<a name="listresourcesetresources"></a>
# **ListResourceSetResources**
> ResourceSetResources ListResourceSetResources (string resourceSetIdOrLabel)

List all resource set resources

Lists all resources for the resource set

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

            var apiInstance = new RoleCResourceSetResourceApi(config);
            var resourceSetIdOrLabel = iamoJDFKaJxGIr0oamd9g;  // string | `id` or `label` of the resource set

            try
            {
                // List all resource set resources
                ResourceSetResources result = apiInstance.ListResourceSetResources(resourceSetIdOrLabel);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleCResourceSetResourceApi.ListResourceSetResources: " + e.Message );
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replaceresourcesetresource"></a>
# **ReplaceResourceSetResource**
> ResourceSetResource ReplaceResourceSetResource (string resourceSetIdOrLabel, string resourceId, ResourceSetResourcePutRequest resourceSetResourcePutRequest)

Replace the resource set resource conditions

Replaces the conditions of a resource identified by `resourceId` in a resource set

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceResourceSetResourceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleCResourceSetResourceApi(config);
            var resourceSetIdOrLabel = iamoJDFKaJxGIr0oamd9g;  // string | `id` or `label` of the resource set
            var resourceId = ire106sQKoHoXXsAe0g4;  // string | `id` of the resource
            var resourceSetResourcePutRequest = new ResourceSetResourcePutRequest(); // ResourceSetResourcePutRequest | 

            try
            {
                // Replace the resource set resource conditions
                ResourceSetResource result = apiInstance.ReplaceResourceSetResource(resourceSetIdOrLabel, resourceId, resourceSetResourcePutRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleCResourceSetResourceApi.ReplaceResourceSetResource: " + e.Message );
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
 **resourceId** | **string**| &#x60;id&#x60; of the resource | 
 **resourceSetResourcePutRequest** | [**ResourceSetResourcePutRequest**](ResourceSetResourcePutRequest.md)|  | 

### Return type

[**ResourceSetResource**](ResourceSetResource.md)

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

