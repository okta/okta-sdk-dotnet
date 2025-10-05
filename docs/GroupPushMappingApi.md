# Okta.Sdk.Api.GroupPushMappingApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateGroupPushMapping**](GroupPushMappingApi.md#creategrouppushmapping) | **POST** /api/v1/apps/{appId}/group-push/mappings | Create a group push mapping
[**DeleteGroupPushMapping**](GroupPushMappingApi.md#deletegrouppushmapping) | **DELETE** /api/v1/apps/{appId}/group-push/mappings/{mappingId} | Delete a group push mapping
[**GetGroupPushMapping**](GroupPushMappingApi.md#getgrouppushmapping) | **GET** /api/v1/apps/{appId}/group-push/mappings/{mappingId} | Retrieve a group push mapping
[**ListGroupPushMappings**](GroupPushMappingApi.md#listgrouppushmappings) | **GET** /api/v1/apps/{appId}/group-push/mappings | List all group push mappings
[**UpdateGroupPushMapping**](GroupPushMappingApi.md#updategrouppushmapping) | **PATCH** /api/v1/apps/{appId}/group-push/mappings/{mappingId} | Update a group push mapping


<a name="creategrouppushmapping"></a>
# **CreateGroupPushMapping**
> GroupPushMapping CreateGroupPushMapping (string appId, CreateGroupPushMappingRequest body)

Create a group push mapping

Creates or links a group push mapping.  **Note:** Either `targetGroupId` or `targetGroupName` must be provided, but not both. If `targetGroupId` is provided, it links to an existing group. If `targetGroupName` is provided, it creates a new group.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateGroupPushMappingExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupPushMappingApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var body = new CreateGroupPushMappingRequest(); // CreateGroupPushMappingRequest | 

            try
            {
                // Create a group push mapping
                GroupPushMapping result = apiInstance.CreateGroupPushMapping(appId, body);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupPushMappingApi.CreateGroupPushMapping: " + e.Message );
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
 **appId** | **string**| Application ID | 
 **body** | [**CreateGroupPushMappingRequest**](CreateGroupPushMappingRequest.md)|  | 

### Return type

[**GroupPushMapping**](GroupPushMapping.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletegrouppushmapping"></a>
# **DeleteGroupPushMapping**
> void DeleteGroupPushMapping (string appId, string mappingId, bool deleteTargetGroup)

Delete a group push mapping

Deletes a specific group push mapping. The group push mapping must be in an `INACTIVE` state.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteGroupPushMappingExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupPushMappingApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var mappingId = gPm00000000000000000;  // string | Group push mapping ID
            var deleteTargetGroup = false;  // bool | If set to `true`, the target group is also deleted. If set to `false`, the target group isn't deleted. (default to false)

            try
            {
                // Delete a group push mapping
                apiInstance.DeleteGroupPushMapping(appId, mappingId, deleteTargetGroup);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupPushMappingApi.DeleteGroupPushMapping: " + e.Message );
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
 **appId** | **string**| Application ID | 
 **mappingId** | **string**| Group push mapping ID | 
 **deleteTargetGroup** | **bool**| If set to &#x60;true&#x60;, the target group is also deleted. If set to &#x60;false&#x60;, the target group isn&#39;t deleted. | [default to false]

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
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getgrouppushmapping"></a>
# **GetGroupPushMapping**
> GroupPushMapping GetGroupPushMapping (string appId, string mappingId)

Retrieve a group push mapping

Retrieves a group push mapping by ID

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetGroupPushMappingExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupPushMappingApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var mappingId = gPm00000000000000000;  // string | Group push mapping ID

            try
            {
                // Retrieve a group push mapping
                GroupPushMapping result = apiInstance.GetGroupPushMapping(appId, mappingId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupPushMappingApi.GetGroupPushMapping: " + e.Message );
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
 **appId** | **string**| Application ID | 
 **mappingId** | **string**| Group push mapping ID | 

### Return type

[**GroupPushMapping**](GroupPushMapping.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listgrouppushmappings"></a>
# **ListGroupPushMappings**
> List&lt;GroupPushMapping&gt; ListGroupPushMappings (string appId, string after = null, int? limit = null, string lastUpdated = null, string sourceGroupId = null, GroupPushMappingStatus? status = null)

List all group push mappings

Lists all group push mappings with pagination support

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListGroupPushMappingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupPushMappingApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of mappings (optional) 
            var limit = 100;  // int? | Specifies the number of results returned (optional)  (default to 100)
            var lastUpdated = 2025-01-01T00:00:00Z;  // string | Filters group push mappings by last updated date. The `lastUpdated` parameter supports the following format: `YYYY-MM-DDTHH:mm:ssZ`. This filters mappings updated on or after the specified date and time in UTC.  If you don't specify a value, all group push mappings are returned. (optional) 
            var sourceGroupId = 00g00000000000000000;  // string | Filters group push mappings by source group ID. If you don't specify a value, all group push mappings are returned. (optional) 
            var status = (GroupPushMappingStatus) "ACTIVE";  // GroupPushMappingStatus? | Filters group push mappings by status. If you don't specify a value, all group push mappings are returned. (optional) 

            try
            {
                // List all group push mappings
                List<GroupPushMapping> result = apiInstance.ListGroupPushMappings(appId, after, limit, lastUpdated, sourceGroupId, status).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupPushMappingApi.ListGroupPushMappings: " + e.Message );
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
 **appId** | **string**| Application ID | 
 **after** | **string**| Specifies the pagination cursor for the next page of mappings | [optional] 
 **limit** | **int?**| Specifies the number of results returned | [optional] [default to 100]
 **lastUpdated** | **string**| Filters group push mappings by last updated date. The &#x60;lastUpdated&#x60; parameter supports the following format: &#x60;YYYY-MM-DDTHH:mm:ssZ&#x60;. This filters mappings updated on or after the specified date and time in UTC.  If you don&#39;t specify a value, all group push mappings are returned. | [optional] 
 **sourceGroupId** | **string**| Filters group push mappings by source group ID. If you don&#39;t specify a value, all group push mappings are returned. | [optional] 
 **status** | **GroupPushMappingStatus?**| Filters group push mappings by status. If you don&#39;t specify a value, all group push mappings are returned. | [optional] 

### Return type

[**List&lt;GroupPushMapping&gt;**](GroupPushMapping.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updategrouppushmapping"></a>
# **UpdateGroupPushMapping**
> GroupPushMapping UpdateGroupPushMapping (string appId, string mappingId, UpdateGroupPushMappingRequest body)

Update a group push mapping

Updates the status of a group push mapping

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateGroupPushMappingExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupPushMappingApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var mappingId = gPm00000000000000000;  // string | Group push mapping ID
            var body = new UpdateGroupPushMappingRequest(); // UpdateGroupPushMappingRequest | 

            try
            {
                // Update a group push mapping
                GroupPushMapping result = apiInstance.UpdateGroupPushMapping(appId, mappingId, body);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupPushMappingApi.UpdateGroupPushMapping: " + e.Message );
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
 **appId** | **string**| Application ID | 
 **mappingId** | **string**| Group push mapping ID | 
 **body** | [**UpdateGroupPushMappingRequest**](UpdateGroupPushMappingRequest.md)|  | 

### Return type

[**GroupPushMapping**](GroupPushMapping.md)

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
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

