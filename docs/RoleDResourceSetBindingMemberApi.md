# Okta.Sdk.Api.RoleDResourceSetBindingMemberApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AddMembersToBinding**](RoleDResourceSetBindingMemberApi.md#addmemberstobinding) | **PATCH** /api/v1/iam/resource-sets/{resourceSetIdOrLabel}/bindings/{roleIdOrLabel}/members | Add more role resource set binding members
[**GetMemberOfBinding**](RoleDResourceSetBindingMemberApi.md#getmemberofbinding) | **GET** /api/v1/iam/resource-sets/{resourceSetIdOrLabel}/bindings/{roleIdOrLabel}/members/{memberId} | Retrieve a role resource set binding member
[**ListMembersOfBinding**](RoleDResourceSetBindingMemberApi.md#listmembersofbinding) | **GET** /api/v1/iam/resource-sets/{resourceSetIdOrLabel}/bindings/{roleIdOrLabel}/members | List all role resource set binding members
[**UnassignMemberFromBinding**](RoleDResourceSetBindingMemberApi.md#unassignmemberfrombinding) | **DELETE** /api/v1/iam/resource-sets/{resourceSetIdOrLabel}/bindings/{roleIdOrLabel}/members/{memberId} | Unassign a role resource set binding member


<a name="addmemberstobinding"></a>
# **AddMembersToBinding**
> ResourceSetBindingEditResponse AddMembersToBinding (string resourceSetIdOrLabel, string roleIdOrLabel, ResourceSetBindingAddMembersRequest instance)

Add more role resource set binding members

Adds more members to a role resource set binding

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

            var apiInstance = new RoleDResourceSetBindingMemberApi(config);
            var resourceSetIdOrLabel = iamoJDFKaJxGIr0oamd9g;  // string | `id` or `label` of the resource set
            var roleIdOrLabel = cr0Yq6IJxGIr0ouum0g3;  // string | `id` or `label` of the role
            var instance = new ResourceSetBindingAddMembersRequest(); // ResourceSetBindingAddMembersRequest | 

            try
            {
                // Add more role resource set binding members
                ResourceSetBindingEditResponse result = apiInstance.AddMembersToBinding(resourceSetIdOrLabel, roleIdOrLabel, instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleDResourceSetBindingMemberApi.AddMembersToBinding: " + e.Message );
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
 **instance** | [**ResourceSetBindingAddMembersRequest**](ResourceSetBindingAddMembersRequest.md)|  | 

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

<a name="getmemberofbinding"></a>
# **GetMemberOfBinding**
> ResourceSetBindingMember GetMemberOfBinding (string resourceSetIdOrLabel, string roleIdOrLabel, string memberId)

Retrieve a role resource set binding member

Retrieves a member (identified by `memberId`) that belongs to a role resource set binding

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

            var apiInstance = new RoleDResourceSetBindingMemberApi(config);
            var resourceSetIdOrLabel = iamoJDFKaJxGIr0oamd9g;  // string | `id` or `label` of the resource set
            var roleIdOrLabel = cr0Yq6IJxGIr0ouum0g3;  // string | `id` or `label` of the role
            var memberId = irb1qe6PGuMc7Oh8N0g4;  // string | `id` of the member

            try
            {
                // Retrieve a role resource set binding member
                ResourceSetBindingMember result = apiInstance.GetMemberOfBinding(resourceSetIdOrLabel, roleIdOrLabel, memberId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleDResourceSetBindingMemberApi.GetMemberOfBinding: " + e.Message );
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
 **memberId** | **string**| &#x60;id&#x60; of the member | 

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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listmembersofbinding"></a>
# **ListMembersOfBinding**
> ResourceSetBindingMembers ListMembersOfBinding (string resourceSetIdOrLabel, string roleIdOrLabel, string after = null)

List all role resource set binding members

Lists all members of a role resource set binding with pagination support

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

            var apiInstance = new RoleDResourceSetBindingMemberApi(config);
            var resourceSetIdOrLabel = iamoJDFKaJxGIr0oamd9g;  // string | `id` or `label` of the resource set
            var roleIdOrLabel = cr0Yq6IJxGIr0ouum0g3;  // string | `id` or `label` of the role
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 

            try
            {
                // List all role resource set binding members
                ResourceSetBindingMembers result = apiInstance.ListMembersOfBinding(resourceSetIdOrLabel, roleIdOrLabel, after);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleDResourceSetBindingMemberApi.ListMembersOfBinding: " + e.Message );
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
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 

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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="unassignmemberfrombinding"></a>
# **UnassignMemberFromBinding**
> void UnassignMemberFromBinding (string resourceSetIdOrLabel, string roleIdOrLabel, string memberId)

Unassign a role resource set binding member

Unassigns a member (identified by `memberId`) from a role resource set binding

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

            var apiInstance = new RoleDResourceSetBindingMemberApi(config);
            var resourceSetIdOrLabel = iamoJDFKaJxGIr0oamd9g;  // string | `id` or `label` of the resource set
            var roleIdOrLabel = cr0Yq6IJxGIr0ouum0g3;  // string | `id` or `label` of the role
            var memberId = irb1qe6PGuMc7Oh8N0g4;  // string | `id` of the member

            try
            {
                // Unassign a role resource set binding member
                apiInstance.UnassignMemberFromBinding(resourceSetIdOrLabel, roleIdOrLabel, memberId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleDResourceSetBindingMemberApi.UnassignMemberFromBinding: " + e.Message );
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
 **memberId** | **string**| &#x60;id&#x60; of the member | 

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

