# Okta.Sdk.Api.ApplicationGroupsApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AssignGroupToApplication**](ApplicationGroupsApi.md#assigngrouptoapplication) | **PUT** /api/v1/apps/{appId}/groups/{groupId} | Assign a Group
[**GetApplicationGroupAssignment**](ApplicationGroupsApi.md#getapplicationgroupassignment) | **GET** /api/v1/apps/{appId}/groups/{groupId} | Retrieve an Assigned Group
[**ListApplicationGroupAssignments**](ApplicationGroupsApi.md#listapplicationgroupassignments) | **GET** /api/v1/apps/{appId}/groups | List all Assigned Groups
[**UnassignApplicationFromGroup**](ApplicationGroupsApi.md#unassignapplicationfromgroup) | **DELETE** /api/v1/apps/{appId}/groups/{groupId} | Unassign a Group


<a name="assigngrouptoapplication"></a>
# **AssignGroupToApplication**
> ApplicationGroupAssignment AssignGroupToApplication (string appId, string groupId, string appId2, string groupId2, ApplicationGroupAssignment applicationGroupAssignment = null)

Assign a Group

Assigns a group to an application

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
            var appId = "appId_example";  // string | 
            var groupId = "groupId_example";  // string | 
            var appId2 = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application
            var groupId2 = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var applicationGroupAssignment = new ApplicationGroupAssignment(); // ApplicationGroupAssignment |  (optional) 

            try
            {
                // Assign a Group
                ApplicationGroupAssignment result = apiInstance.AssignGroupToApplication(appId, groupId, appId2, groupId2, applicationGroupAssignment);
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
 **appId** | **string**|  | 
 **groupId** | **string**|  | 
 **appId2** | **string**| ID of the Application | 
 **groupId2** | **string**| The &#x60;id&#x60; of the group | 
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
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getapplicationgroupassignment"></a>
# **GetApplicationGroupAssignment**
> ApplicationGroupAssignment GetApplicationGroupAssignment (string appId, string groupId, string appId2, string groupId2, string expand = null)

Retrieve an Assigned Group

Retrieves an application group assignment

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
            var appId = "appId_example";  // string | 
            var groupId = "groupId_example";  // string | 
            var appId2 = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application
            var groupId2 = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var expand = "expand_example";  // string |  (optional) 

            try
            {
                // Retrieve an Assigned Group
                ApplicationGroupAssignment result = apiInstance.GetApplicationGroupAssignment(appId, groupId, appId2, groupId2, expand);
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
 **appId** | **string**|  | 
 **groupId** | **string**|  | 
 **appId2** | **string**| ID of the Application | 
 **groupId2** | **string**| The &#x60;id&#x60; of the group | 
 **expand** | **string**|  | [optional] 

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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listapplicationgroupassignments"></a>
# **ListApplicationGroupAssignments**
> List&lt;ApplicationGroupAssignment&gt; ListApplicationGroupAssignments (string appId, string q = null, string after = null, int? limit = null, string expand = null)

List all Assigned Groups

Lists all group assignments for an application

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
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application
            var q = "q_example";  // string |  (optional) 
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of assignments (optional) 
            var limit = -1;  // int? | Specifies the number of results for a page (optional)  (default to -1)
            var expand = "expand_example";  // string |  (optional) 

            try
            {
                // List all Assigned Groups
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
 **appId** | **string**| ID of the Application | 
 **q** | **string**|  | [optional] 
 **after** | **string**| Specifies the pagination cursor for the next page of assignments | [optional] 
 **limit** | **int?**| Specifies the number of results for a page | [optional] [default to -1]
 **expand** | **string**|  | [optional] 

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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="unassignapplicationfromgroup"></a>
# **UnassignApplicationFromGroup**
> void UnassignApplicationFromGroup (string appId, string groupId, string appId2, string groupId2)

Unassign a Group

Unassigns a group from an application

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
            var appId = "appId_example";  // string | 
            var groupId = "groupId_example";  // string | 
            var appId2 = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application
            var groupId2 = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group

            try
            {
                // Unassign a Group
                apiInstance.UnassignApplicationFromGroup(appId, groupId, appId2, groupId2);
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
 **appId** | **string**|  | 
 **groupId** | **string**|  | 
 **appId2** | **string**| ID of the Application | 
 **groupId2** | **string**| The &#x60;id&#x60; of the group | 

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

