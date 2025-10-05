# Okta.Sdk.Api.ApplicationGroupsApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AssignGroupToApplication**](ApplicationGroupsApi.md#assigngrouptoapplication) | **PUT** /api/v1/apps/{appId}/groups/{groupId} | Assign an application group
[**GetApplicationGroupAssignment**](ApplicationGroupsApi.md#getapplicationgroupassignment) | **GET** /api/v1/apps/{appId}/groups/{groupId} | Retrieve an application group
[**ListApplicationGroupAssignments**](ApplicationGroupsApi.md#listapplicationgroupassignments) | **GET** /api/v1/apps/{appId}/groups | List all application groups
[**UnassignApplicationFromGroup**](ApplicationGroupsApi.md#unassignapplicationfromgroup) | **DELETE** /api/v1/apps/{appId}/groups/{groupId} | Unassign an application group
[**UpdateGroupAssignmentToApplication**](ApplicationGroupsApi.md#updategroupassignmenttoapplication) | **PATCH** /api/v1/apps/{appId}/groups/{groupId} | Update an application group


<a name="assigngrouptoapplication"></a>
# **AssignGroupToApplication**
> ApplicationGroupAssignment AssignGroupToApplication (string appId, string groupId, ApplicationGroupAssignment applicationGroupAssignment = null)

Assign an application group

Assigns a [Group](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/Group/) to an app, which in turn assigns the app to each [User](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/User/) that belongs to the group.  The resulting application user [scope](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/ApplicationUsers/#tag/ApplicationUsers/operation/listApplicationUsers!c=200&path=scope&t=response) is `GROUP` since the assignment was from the group membership.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AssignGroupToApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationGroupsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var applicationGroupAssignment = new ApplicationGroupAssignment(); // ApplicationGroupAssignment |  (optional) 

            try
            {
                // Assign an application group
                ApplicationGroupAssignment result = apiInstance.AssignGroupToApplication(appId, groupId, applicationGroupAssignment);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationGroupsApi.AssignGroupToApplication: " + e.Message );
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
 **groupId** | **string**| The &#x60;id&#x60; of the group | 
 **applicationGroupAssignment** | [**ApplicationGroupAssignment**](ApplicationGroupAssignment.md)|  | [optional] 

### Return type

[**ApplicationGroupAssignment**](ApplicationGroupAssignment.md)

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

<a name="getapplicationgroupassignment"></a>
# **GetApplicationGroupAssignment**
> ApplicationGroupAssignment GetApplicationGroupAssignment (string appId, string groupId, string expand = null)

Retrieve an application group

Retrieves an app group assignment

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetApplicationGroupAssignmentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationGroupsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var expand = group;  // string | An optional query parameter to return the corresponding assigned [group](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/Group/) or  the group assignment metadata details in the `_embedded` property. (optional) 

            try
            {
                // Retrieve an application group
                ApplicationGroupAssignment result = apiInstance.GetApplicationGroupAssignment(appId, groupId, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationGroupsApi.GetApplicationGroupAssignment: " + e.Message );
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
 **groupId** | **string**| The &#x60;id&#x60; of the group | 
 **expand** | **string**| An optional query parameter to return the corresponding assigned [group](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/Group/) or  the group assignment metadata details in the &#x60;_embedded&#x60; property. | [optional] 

### Return type

[**ApplicationGroupAssignment**](ApplicationGroupAssignment.md)

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

<a name="listapplicationgroupassignments"></a>
# **ListApplicationGroupAssignments**
> List&lt;ApplicationGroupAssignment&gt; ListApplicationGroupAssignments (string appId, string q = null, string after = null, int? limit = null, string expand = null)

List all application groups

Lists all app group assignments

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListApplicationGroupAssignmentsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationGroupsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var q = test;  // string | Specifies a filter for a list of assigned groups returned based on their names. The value of `q` is matched against the group `name`.  This filter only supports the `startsWith` operation that matches the `q` string against the beginning of the [group name](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/Group/#tag/Group/operation/listGroups!c=200&path=profile/name&t=response). (optional) 
            var after = 16275000448691;  // string | Specifies the pagination cursor for the `next` page of results. Treat this as an opaque value obtained through the next link relationship. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 
            var limit = 20;  // int? | Specifies the number of objects to return per page. If there are multiple pages of results, the Link header contains a `next` link that you need to use as an opaque value (follow it, don't parse it). See [Pagination](/#pagination). (optional)  (default to 20)
            var expand = group;  // string | An optional query parameter to return the corresponding assigned [group](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/Group/) or  the group assignment metadata details in the `_embedded` property. (optional) 

            try
            {
                // List all application groups
                List<ApplicationGroupAssignment> result = apiInstance.ListApplicationGroupAssignments(appId, q, after, limit, expand).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationGroupsApi.ListApplicationGroupAssignments: " + e.Message );
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
 **q** | **string**| Specifies a filter for a list of assigned groups returned based on their names. The value of &#x60;q&#x60; is matched against the group &#x60;name&#x60;.  This filter only supports the &#x60;startsWith&#x60; operation that matches the &#x60;q&#x60; string against the beginning of the [group name](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/Group/#tag/Group/operation/listGroups!c&#x3D;200&amp;path&#x3D;profile/name&amp;t&#x3D;response). | [optional] 
 **after** | **string**| Specifies the pagination cursor for the &#x60;next&#x60; page of results. Treat this as an opaque value obtained through the next link relationship. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 
 **limit** | **int?**| Specifies the number of objects to return per page. If there are multiple pages of results, the Link header contains a &#x60;next&#x60; link that you need to use as an opaque value (follow it, don&#39;t parse it). See [Pagination](/#pagination). | [optional] [default to 20]
 **expand** | **string**| An optional query parameter to return the corresponding assigned [group](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/Group/) or  the group assignment metadata details in the &#x60;_embedded&#x60; property. | [optional] 

### Return type

[**List&lt;ApplicationGroupAssignment&gt;**](ApplicationGroupAssignment.md)

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

<a name="unassignapplicationfromgroup"></a>
# **UnassignApplicationFromGroup**
> void UnassignApplicationFromGroup (string appId, string groupId)

Unassign an application group

Unassigns a Group from an app

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UnassignApplicationFromGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationGroupsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group

            try
            {
                // Unassign an application group
                apiInstance.UnassignApplicationFromGroup(appId, groupId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationGroupsApi.UnassignApplicationFromGroup: " + e.Message );
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
 **groupId** | **string**| The &#x60;id&#x60; of the group | 

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

<a name="updategroupassignmenttoapplication"></a>
# **UpdateGroupAssignmentToApplication**
> ApplicationGroupAssignment UpdateGroupAssignmentToApplication (string appId, string groupId, List<JsonPatchOperation> jsonPatchOperation = null)

Update an application group

Updates a group assignment to an app

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateGroupAssignmentToApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationGroupsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var jsonPatchOperation = new List<JsonPatchOperation>(); // List<JsonPatchOperation> |  (optional) 

            try
            {
                // Update an application group
                ApplicationGroupAssignment result = apiInstance.UpdateGroupAssignmentToApplication(appId, groupId, jsonPatchOperation);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationGroupsApi.UpdateGroupAssignmentToApplication: " + e.Message );
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
 **groupId** | **string**| The &#x60;id&#x60; of the group | 
 **jsonPatchOperation** | [**List&lt;JsonPatchOperation&gt;**](JsonPatchOperation.md)|  | [optional] 

### Return type

[**ApplicationGroupAssignment**](ApplicationGroupAssignment.md)

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

