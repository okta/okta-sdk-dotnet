# Okta.Sdk.Api.RoleCResourceSetApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateResourceSet**](RoleCResourceSetApi.md#createresourceset) | **POST** /api/v1/iam/resource-sets | Create a resource set
[**DeleteResourceSet**](RoleCResourceSetApi.md#deleteresourceset) | **DELETE** /api/v1/iam/resource-sets/{resourceSetIdOrLabel} | Delete a resource set
[**GetResourceSet**](RoleCResourceSetApi.md#getresourceset) | **GET** /api/v1/iam/resource-sets/{resourceSetIdOrLabel} | Retrieve a resource set
[**ListResourceSets**](RoleCResourceSetApi.md#listresourcesets) | **GET** /api/v1/iam/resource-sets | List all resource sets
[**ReplaceResourceSet**](RoleCResourceSetApi.md#replaceresourceset) | **PUT** /api/v1/iam/resource-sets/{resourceSetIdOrLabel} | Replace a resource set


<a name="createresourceset"></a>
# **CreateResourceSet**
> ResourceSet CreateResourceSet (CreateResourceSetRequest instance)

Create a resource set

Creates a new resource set. See [Supported resources](/openapi/okta-management/guides/roles/#supported-resources).  > **Note:** The maximum number of `resources` allowed in a resource set object is 1000. Resources are identified by either an Okta Resource Name (ORN) or by a REST URL format. See [Okta Resource Name](/openapi/okta-management/guides/roles/#okta-resource-name-orn).

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

            var apiInstance = new RoleCResourceSetApi(config);
            var instance = new CreateResourceSetRequest(); // CreateResourceSetRequest | 

            try
            {
                // Create a resource set
                ResourceSet result = apiInstance.CreateResourceSet(instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleCResourceSetApi.CreateResourceSet: " + e.Message );
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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteresourceset"></a>
# **DeleteResourceSet**
> void DeleteResourceSet (string resourceSetIdOrLabel)

Delete a resource set

Deletes a resource set by `resourceSetIdOrLabel`

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

            var apiInstance = new RoleCResourceSetApi(config);
            var resourceSetIdOrLabel = iamoJDFKaJxGIr0oamd9g;  // string | `id` or `label` of the resource set

            try
            {
                // Delete a resource set
                apiInstance.DeleteResourceSet(resourceSetIdOrLabel);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleCResourceSetApi.DeleteResourceSet: " + e.Message );
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

<a name="getresourceset"></a>
# **GetResourceSet**
> ResourceSet GetResourceSet (string resourceSetIdOrLabel)

Retrieve a resource set

Retrieves a resource set by `resourceSetIdOrLabel`

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

            var apiInstance = new RoleCResourceSetApi(config);
            var resourceSetIdOrLabel = iamoJDFKaJxGIr0oamd9g;  // string | `id` or `label` of the resource set

            try
            {
                // Retrieve a resource set
                ResourceSet result = apiInstance.GetResourceSet(resourceSetIdOrLabel);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleCResourceSetApi.GetResourceSet: " + e.Message );
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listresourcesets"></a>
# **ListResourceSets**
> ResourceSets ListResourceSets (string after = null)

List all resource sets

Lists all resource sets with pagination support

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

            var apiInstance = new RoleCResourceSetApi(config);
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 

            try
            {
                // List all resource sets
                ResourceSets result = apiInstance.ListResourceSets(after);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleCResourceSetApi.ListResourceSets: " + e.Message );
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
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 

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
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replaceresourceset"></a>
# **ReplaceResourceSet**
> ResourceSet ReplaceResourceSet (string resourceSetIdOrLabel, ResourceSet instance)

Replace a resource set

Replaces the label and description of a resource set

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

            var apiInstance = new RoleCResourceSetApi(config);
            var resourceSetIdOrLabel = iamoJDFKaJxGIr0oamd9g;  // string | `id` or `label` of the resource set
            var instance = new ResourceSet(); // ResourceSet | 

            try
            {
                // Replace a resource set
                ResourceSet result = apiInstance.ReplaceResourceSet(resourceSetIdOrLabel, instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleCResourceSetApi.ReplaceResourceSet: " + e.Message );
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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

