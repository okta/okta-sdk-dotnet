# Okta.Sdk.Api.RoleAssignmentApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AssignRoleToGroup**](RoleAssignmentApi.md#assignroletogroup) | **POST** /api/v1/groups/{groupId}/roles | Assign a Role to a Group
[**AssignRoleToUser**](RoleAssignmentApi.md#assignroletouser) | **POST** /api/v1/users/{userId}/roles | Assign a Role to a User
[**GetGroupAssignedRole**](RoleAssignmentApi.md#getgroupassignedrole) | **GET** /api/v1/groups/{groupId}/roles/{roleId} | Retrieve a Role assigned to Group
[**GetUserAssignedRole**](RoleAssignmentApi.md#getuserassignedrole) | **GET** /api/v1/users/{userId}/roles/{roleId} | Retrieve a Role assigned to a User
[**ListAssignedRolesForUser**](RoleAssignmentApi.md#listassignedrolesforuser) | **GET** /api/v1/users/{userId}/roles | List all Roles assigned to a User
[**ListGroupAssignedRoles**](RoleAssignmentApi.md#listgroupassignedroles) | **GET** /api/v1/groups/{groupId}/roles | List all Assigned Roles of Group
[**ListUsersWithRoleAssignments**](RoleAssignmentApi.md#listuserswithroleassignments) | **GET** /api/v1/iam/assignees/users | List all Users with Role Assignments
[**UnassignRoleFromGroup**](RoleAssignmentApi.md#unassignrolefromgroup) | **DELETE** /api/v1/groups/{groupId}/roles/{roleId} | Unassign a Role from a Group
[**UnassignRoleFromUser**](RoleAssignmentApi.md#unassignrolefromuser) | **DELETE** /api/v1/users/{userId}/roles/{roleId} | Unassign a Role from a User


<a name="assignroletogroup"></a>
# **AssignRoleToGroup**
> Role AssignRoleToGroup (string groupId, AssignRoleRequest assignRoleRequest, bool? disableNotifications = null)

Assign a Role to a Group

Assigns a role to a group

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

            var apiInstance = new RoleAssignmentApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var assignRoleRequest = new AssignRoleRequest(); // AssignRoleRequest | 
            var disableNotifications = true;  // bool? | Setting this to `true` grants the group third-party admin status (optional) 

            try
            {
                // Assign a Role to a Group
                Role result = apiInstance.AssignRoleToGroup(groupId, assignRoleRequest, disableNotifications);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentApi.AssignRoleToGroup: " + e.Message );
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
 **assignRoleRequest** | [**AssignRoleRequest**](AssignRoleRequest.md)|  | 
 **disableNotifications** | **bool?**| Setting this to &#x60;true&#x60; grants the group third-party admin status | [optional] 

### Return type

[**Role**](Role.md)

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
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="assignroletouser"></a>
# **AssignRoleToUser**
> Role AssignRoleToUser (string userId, AssignRoleRequest assignRoleRequest, bool? disableNotifications = null)

Assign a Role to a User

Assigns a role to a user identified by `userId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AssignRoleToUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleAssignmentApi(config);
            var userId = "userId_example";  // string | 
            var assignRoleRequest = new AssignRoleRequest(); // AssignRoleRequest | 
            var disableNotifications = true;  // bool? | Setting this to `true` grants the user third-party admin status (optional) 

            try
            {
                // Assign a Role to a User
                Role result = apiInstance.AssignRoleToUser(userId, assignRoleRequest, disableNotifications);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentApi.AssignRoleToUser: " + e.Message );
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
 **userId** | **string**|  | 
 **assignRoleRequest** | [**AssignRoleRequest**](AssignRoleRequest.md)|  | 
 **disableNotifications** | **bool?**| Setting this to &#x60;true&#x60; grants the user third-party admin status | [optional] 

### Return type

[**Role**](Role.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getgroupassignedrole"></a>
# **GetGroupAssignedRole**
> Role GetGroupAssignedRole (string groupId, string roleId)

Retrieve a Role assigned to Group

Retrieves a role identified by `roleId` assigned to group identified by `groupId`

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

            var apiInstance = new RoleAssignmentApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var roleId = 3Vg1Pjp3qzw4qcCK5EdO;  // string | `id` of the Role

            try
            {
                // Retrieve a Role assigned to Group
                Role result = apiInstance.GetGroupAssignedRole(groupId, roleId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentApi.GetGroupAssignedRole: " + e.Message );
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
 **roleId** | **string**| &#x60;id&#x60; of the Role | 

### Return type

[**Role**](Role.md)

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

<a name="getuserassignedrole"></a>
# **GetUserAssignedRole**
> Role GetUserAssignedRole (string userId, string roleId)

Retrieve a Role assigned to a User

Retrieves a role identified by `roleId` assigned to a user identified by `userId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetUserAssignedRoleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleAssignmentApi(config);
            var userId = "userId_example";  // string | 
            var roleId = 3Vg1Pjp3qzw4qcCK5EdO;  // string | `id` of the Role

            try
            {
                // Retrieve a Role assigned to a User
                Role result = apiInstance.GetUserAssignedRole(userId, roleId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentApi.GetUserAssignedRole: " + e.Message );
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
 **userId** | **string**|  | 
 **roleId** | **string**| &#x60;id&#x60; of the Role | 

### Return type

[**Role**](Role.md)

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

<a name="listassignedrolesforuser"></a>
# **ListAssignedRolesForUser**
> List&lt;Role&gt; ListAssignedRolesForUser (string userId, string expand = null)

List all Roles assigned to a User

Lists all roles assigned to a user identified by `userId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListAssignedRolesForUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleAssignmentApi(config);
            var userId = "userId_example";  // string | 
            var expand = "expand_example";  // string |  (optional) 

            try
            {
                // List all Roles assigned to a User
                List<Role> result = apiInstance.ListAssignedRolesForUser(userId, expand).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentApi.ListAssignedRolesForUser: " + e.Message );
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
 **userId** | **string**|  | 
 **expand** | **string**|  | [optional] 

### Return type

[**List&lt;Role&gt;**](Role.md)

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

<a name="listgroupassignedroles"></a>
# **ListGroupAssignedRoles**
> List&lt;Role&gt; ListGroupAssignedRoles (string groupId, string expand = null)

List all Assigned Roles of Group

Lists all assigned roles of group identified by `groupId`

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

            var apiInstance = new RoleAssignmentApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var expand = "expand_example";  // string |  (optional) 

            try
            {
                // List all Assigned Roles of Group
                List<Role> result = apiInstance.ListGroupAssignedRoles(groupId, expand).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentApi.ListGroupAssignedRoles: " + e.Message );
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
 **expand** | **string**|  | [optional] 

### Return type

[**List&lt;Role&gt;**](Role.md)

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

<a name="listuserswithroleassignments"></a>
# **ListUsersWithRoleAssignments**
> RoleAssignedUsers ListUsersWithRoleAssignments (string after = null, int? limit = null)

List all Users with Role Assignments

Lists all users with Role Assignments

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListUsersWithRoleAssignmentsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleAssignmentApi(config);
            var after = "after_example";  // string |  (optional) 
            var limit = 100;  // int? | Specifies the number of results returned. Defaults to `100`. (optional)  (default to 100)

            try
            {
                // List all Users with Role Assignments
                RoleAssignedUsers result = apiInstance.ListUsersWithRoleAssignments(after, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentApi.ListUsersWithRoleAssignments: " + e.Message );
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
 **after** | **string**|  | [optional] 
 **limit** | **int?**| Specifies the number of results returned. Defaults to &#x60;100&#x60;. | [optional] [default to 100]

### Return type

[**RoleAssignedUsers**](RoleAssignedUsers.md)

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
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="unassignrolefromgroup"></a>
# **UnassignRoleFromGroup**
> void UnassignRoleFromGroup (string groupId, string roleId)

Unassign a Role from a Group

Unassigns a role identified by `roleId` assigned to group identified by `groupId`

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

            var apiInstance = new RoleAssignmentApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var roleId = 3Vg1Pjp3qzw4qcCK5EdO;  // string | `id` of the Role

            try
            {
                // Unassign a Role from a Group
                apiInstance.UnassignRoleFromGroup(groupId, roleId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentApi.UnassignRoleFromGroup: " + e.Message );
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
 **roleId** | **string**| &#x60;id&#x60; of the Role | 

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

<a name="unassignrolefromuser"></a>
# **UnassignRoleFromUser**
> void UnassignRoleFromUser (string userId, string roleId)

Unassign a Role from a User

Unassigns a role identified by `roleId` from a user identified by `userId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UnassignRoleFromUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleAssignmentApi(config);
            var userId = "userId_example";  // string | 
            var roleId = 3Vg1Pjp3qzw4qcCK5EdO;  // string | `id` of the Role

            try
            {
                // Unassign a Role from a User
                apiInstance.UnassignRoleFromUser(userId, roleId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentApi.UnassignRoleFromUser: " + e.Message );
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
 **userId** | **string**|  | 
 **roleId** | **string**| &#x60;id&#x60; of the Role | 

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

