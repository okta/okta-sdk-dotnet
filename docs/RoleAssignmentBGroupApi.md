# Okta.Sdk.Api.RoleAssignmentBGroupApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AssignRoleToGroup**](RoleAssignmentBGroupApi.md#assignroletogroup) | **POST** /api/v1/groups/{groupId}/roles | Assign a role to a group
[**GetGroupAssignedRole**](RoleAssignmentBGroupApi.md#getgroupassignedrole) | **GET** /api/v1/groups/{groupId}/roles/{roleAssignmentId} | Retrieve a group role assignment
[**ListGroupAssignedRoles**](RoleAssignmentBGroupApi.md#listgroupassignedroles) | **GET** /api/v1/groups/{groupId}/roles | List all group role assignments
[**UnassignRoleFromGroup**](RoleAssignmentBGroupApi.md#unassignrolefromgroup) | **DELETE** /api/v1/groups/{groupId}/roles/{roleAssignmentId} | Unassign a group role


<a name="assignroletogroup"></a>
# **AssignRoleToGroup**
> ListGroupAssignedRoles200ResponseInner AssignRoleToGroup (string groupId, AssignRoleToGroupRequest assignRoleRequest, bool? disableNotifications = null)

Assign a role to a group

Assigns a [standard role](/openapi/okta-management/guides/roles/#standard-roles) to a group.  You can also assign a custom role to a group, but the preferred method to assign a custom role to a group is to create a binding between the custom role, the resource set, and the group. See [Create a role resource set binding](/openapi/okta-management/management/tag/RoleDResourceSetBinding/#tag/RoleDResourceSetBinding/operation/createResourceSetBinding).  > **Notes:** > * The request payload is different for standard and custom role assignments. > * For IAM-based standard role assignments, use the request payload for standard roles. However, the response payload for IAM-based role assignments is similar to the custom role's assignment response.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AssignRoleToGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleAssignmentBGroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var assignRoleRequest = new AssignRoleToGroupRequest(); // AssignRoleToGroupRequest | 
            var disableNotifications = false;  // bool? | Grants the group third-party admin status when set to `true` (optional)  (default to false)

            try
            {
                // Assign a role to a group
                ListGroupAssignedRoles200ResponseInner result = apiInstance.AssignRoleToGroup(groupId, assignRoleRequest, disableNotifications);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentBGroupApi.AssignRoleToGroup: " + e.Message );
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
 **assignRoleRequest** | [**AssignRoleToGroupRequest**](AssignRoleToGroupRequest.md)|  | 
 **disableNotifications** | **bool?**| Grants the group third-party admin status when set to &#x60;true&#x60; | [optional] [default to false]

### Return type

[**ListGroupAssignedRoles200ResponseInner**](ListGroupAssignedRoles200ResponseInner.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **201** | Success |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getgroupassignedrole"></a>
# **GetGroupAssignedRole**
> ListGroupAssignedRoles200ResponseInner GetGroupAssignedRole (string groupId, string roleAssignmentId)

Retrieve a group role assignment

Retrieves a role assigned to a group (identified by the `groupId`). The `roleAssignmentId` is the unique identifier for either a standard role group assignment object or a custom role resource set binding object.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetGroupAssignedRoleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleAssignmentBGroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment

            try
            {
                // Retrieve a group role assignment
                ListGroupAssignedRoles200ResponseInner result = apiInstance.GetGroupAssignedRole(groupId, roleAssignmentId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentBGroupApi.GetGroupAssignedRole: " + e.Message );
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
 **roleAssignmentId** | **string**| The &#x60;id&#x60; of the role assignment | 

### Return type

[**ListGroupAssignedRoles200ResponseInner**](ListGroupAssignedRoles200ResponseInner.md)

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

<a name="listgroupassignedroles"></a>
# **ListGroupAssignedRoles**
> List&lt;ListGroupAssignedRoles200ResponseInner&gt; ListGroupAssignedRoles (string groupId, string expand = null)

List all group role assignments

Lists all assigned roles of a group by `groupId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListGroupAssignedRolesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleAssignmentBGroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var expand = targets/groups;  // string | An optional parameter used to return targets configured for the standard role assignment in the `embedded` property. Supported values: `targets/groups` or `targets/catalog/apps` (optional) 

            try
            {
                // List all group role assignments
                List<ListGroupAssignedRoles200ResponseInner> result = apiInstance.ListGroupAssignedRoles(groupId, expand).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentBGroupApi.ListGroupAssignedRoles: " + e.Message );
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
 **expand** | **string**| An optional parameter used to return targets configured for the standard role assignment in the &#x60;embedded&#x60; property. Supported values: &#x60;targets/groups&#x60; or &#x60;targets/catalog/apps&#x60; | [optional] 

### Return type

[**List&lt;ListGroupAssignedRoles200ResponseInner&gt;**](ListGroupAssignedRoles200ResponseInner.md)

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

<a name="unassignrolefromgroup"></a>
# **UnassignRoleFromGroup**
> void UnassignRoleFromGroup (string groupId, string roleAssignmentId)

Unassign a group role

Unassigns a role assignment (identified by `roleAssignmentId`) from a group (identified by the `groupId`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UnassignRoleFromGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleAssignmentBGroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment

            try
            {
                // Unassign a group role
                apiInstance.UnassignRoleFromGroup(groupId, roleAssignmentId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentBGroupApi.UnassignRoleFromGroup: " + e.Message );
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
 **roleAssignmentId** | **string**| The &#x60;id&#x60; of the role assignment | 

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

