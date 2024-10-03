# Okta.Sdk.Api.GroupOwnerApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AssignGroupOwner**](GroupOwnerApi.md#assigngroupowner) | **POST** /api/v1/groups/{groupId}/owners | Assign a Group Owner
[**DeleteGroupOwner**](GroupOwnerApi.md#deletegroupowner) | **DELETE** /api/v1/groups/{groupId}/owners/{ownerId} | Delete a Group Owner
[**ListGroupOwners**](GroupOwnerApi.md#listgroupowners) | **GET** /api/v1/groups/{groupId}/owners | List all Group Owners


<a name="assigngroupowner"></a>
# **AssignGroupOwner**
> GroupOwner AssignGroupOwner (string groupId, AssignGroupOwnerRequestBody assignGroupOwnerRequestBody)

Assign a Group Owner

Assigns a group owner

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AssignGroupOwnerExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupOwnerApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var assignGroupOwnerRequestBody = new AssignGroupOwnerRequestBody(); // AssignGroupOwnerRequestBody | 

            try
            {
                // Assign a Group Owner
                GroupOwner result = apiInstance.AssignGroupOwner(groupId, assignGroupOwnerRequestBody);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupOwnerApi.AssignGroupOwner: " + e.Message );
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
 **groupId** | **string**| The &#x60;id&#x60; of the group | 
 **assignGroupOwnerRequestBody** | [**AssignGroupOwnerRequestBody**](AssignGroupOwnerRequestBody.md)|  | 

### Return type

[**GroupOwner**](GroupOwner.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Success |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletegroupowner"></a>
# **DeleteGroupOwner**
> void DeleteGroupOwner (string groupId, string ownerId)

Delete a Group Owner

Deletes a group owner from a specific group

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteGroupOwnerExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupOwnerApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var ownerId = 00u1emaK22TWRYd3TtG;  // string | The `id` of the group owner

            try
            {
                // Delete a Group Owner
                apiInstance.DeleteGroupOwner(groupId, ownerId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupOwnerApi.DeleteGroupOwner: " + e.Message );
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
 **groupId** | **string**| The &#x60;id&#x60; of the group | 
 **ownerId** | **string**| The &#x60;id&#x60; of the group owner | 

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

<a name="listgroupowners"></a>
# **ListGroupOwners**
> List&lt;GroupOwner&gt; ListGroupOwners (string groupId, string search = null, string after = null, int? limit = null)

List all Group Owners

Lists all owners for a specific group

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListGroupOwnersExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupOwnerApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var search = "search_example";  // string | SCIM Filter expression for group owners. Allows to filter owners by type. (optional) 
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of owners (optional) 
            var limit = 1000;  // int? | Specifies the number of owner results in a page (optional)  (default to 1000)

            try
            {
                // List all Group Owners
                List<GroupOwner> result = apiInstance.ListGroupOwners(groupId, search, after, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupOwnerApi.ListGroupOwners: " + e.Message );
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
 **groupId** | **string**| The &#x60;id&#x60; of the group | 
 **search** | **string**| SCIM Filter expression for group owners. Allows to filter owners by type. | [optional] 
 **after** | **string**| Specifies the pagination cursor for the next page of owners | [optional] 
 **limit** | **int?**| Specifies the number of owner results in a page | [optional] [default to 1000]

### Return type

[**List&lt;GroupOwner&gt;**](GroupOwner.md)

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

