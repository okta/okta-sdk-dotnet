# Okta.Sdk.Api.RoleAssignmentApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AssignRoleToClient**](RoleAssignmentApi.md#assignroletoclient) | **POST** /oauth2/v1/clients/{clientId}/roles | Assign Role to Client
[**AssignRoleToGroup**](RoleAssignmentApi.md#assignroletogroup) | **POST** /api/v1/groups/{groupId}/roles | Assign a Role to a Group
[**AssignRoleToUser**](RoleAssignmentApi.md#assignroletouser) | **POST** /api/v1/users/{userId}/roles | Assign a Role to a User
[**DeleteRoleFromClient**](RoleAssignmentApi.md#deleterolefromclient) | **DELETE** /oauth2/v1/clients/{clientId}/roles/{roleId} | Unassign a Role from a Client
[**GetGroupAssignedRole**](RoleAssignmentApi.md#getgroupassignedrole) | **GET** /api/v1/groups/{groupId}/roles/{roleId} | Retrieve a Role assigned to Group
[**GetUserAssignedRole**](RoleAssignmentApi.md#getuserassignedrole) | **GET** /api/v1/users/{userId}/roles/{roleId} | Retrieve a Role assigned to a User
[**ListAssignedRolesForUser**](RoleAssignmentApi.md#listassignedrolesforuser) | **GET** /api/v1/users/{userId}/roles | List all Roles assigned to a User
[**ListGroupAssignedRoles**](RoleAssignmentApi.md#listgroupassignedroles) | **GET** /api/v1/groups/{groupId}/roles | List all Assigned Roles of Group
[**ListRolesForClient**](RoleAssignmentApi.md#listrolesforclient) | **GET** /oauth2/v1/clients/{clientId}/roles | List all Roles for a Client
[**ListUsersWithRoleAssignments**](RoleAssignmentApi.md#listuserswithroleassignments) | **GET** /api/v1/iam/assignees/users | List all Users with Role Assignments
[**RetrieveClientRole**](RoleAssignmentApi.md#retrieveclientrole) | **GET** /oauth2/v1/clients/{clientId}/roles/{roleId} | Retrieve a Client Role
[**UnassignRoleFromGroup**](RoleAssignmentApi.md#unassignrolefromgroup) | **DELETE** /api/v1/groups/{groupId}/roles/{roleId} | Unassign a Role from a Group
[**UnassignRoleFromUser**](RoleAssignmentApi.md#unassignrolefromuser) | **DELETE** /api/v1/users/{userId}/roles/{roleId} | Unassign a Role from a User


<a name="assignroletoclient"></a>
# **AssignRoleToClient**
> ModelClient AssignRoleToClient (string clientId, AssignRoleToClientRequest assignRoleToClientRequest)

Assign Role to Client

Assigns a Role to a Client

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AssignRoleToClientExample
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
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | `client_id` of the app
            var assignRoleToClientRequest = new AssignRoleToClientRequest(); // AssignRoleToClientRequest | 

            try
            {
                // Assign Role to Client
                ModelClient result = apiInstance.AssignRoleToClient(clientId, assignRoleToClientRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentApi.AssignRoleToClient: " + e.Message );
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
 **clientId** | **string**| &#x60;client_id&#x60; of the app | 
 **assignRoleToClientRequest** | [**AssignRoleToClientRequest**](AssignRoleToClientRequest.md)|  | 

### Return type

[**ModelClient**](ModelClient.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

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
            var userId = "userId_example";  // string | ID of an existing Okta user
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
 **userId** | **string**| ID of an existing Okta user | 
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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleterolefromclient"></a>
# **DeleteRoleFromClient**
> void DeleteRoleFromClient (string clientId, string roleId)

Unassign a Role from a Client

Unassigns a Role from a Client

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteRoleFromClientExample
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
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | `client_id` of the app
            var roleId = 3Vg1Pjp3qzw4qcCK5EdO;  // string | `id` of the Role

            try
            {
                // Unassign a Role from a Client
                apiInstance.DeleteRoleFromClient(clientId, roleId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentApi.DeleteRoleFromClient: " + e.Message );
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
 **clientId** | **string**| &#x60;client_id&#x60; of the app | 
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

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
            var userId = "userId_example";  // string | ID of an existing Okta user
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
 **userId** | **string**| ID of an existing Okta user | 
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

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
            var userId = "userId_example";  // string | ID of an existing Okta user
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
 **userId** | **string**| ID of an existing Okta user | 
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listrolesforclient"></a>
# **ListRolesForClient**
> ModelClient ListRolesForClient (string clientId)

List all Roles for a Client

Lists all Roles by `clientId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListRolesForClientExample
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
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | `client_id` of the app

            try
            {
                // List all Roles for a Client
                ModelClient result = apiInstance.ListRolesForClient(clientId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentApi.ListRolesForClient: " + e.Message );
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
 **clientId** | **string**| &#x60;client_id&#x60; of the app | 

### Return type

[**ModelClient**](ModelClient.md)

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
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="retrieveclientrole"></a>
# **RetrieveClientRole**
> ModelClient RetrieveClientRole (string clientId, string roleId)

Retrieve a Client Role

Retrieves a Client Role

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RetrieveClientRoleExample
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
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | `client_id` of the app
            var roleId = 3Vg1Pjp3qzw4qcCK5EdO;  // string | `id` of the Role

            try
            {
                // Retrieve a Client Role
                ModelClient result = apiInstance.RetrieveClientRole(clientId, roleId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentApi.RetrieveClientRole: " + e.Message );
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
 **clientId** | **string**| &#x60;client_id&#x60; of the app | 
 **roleId** | **string**| &#x60;id&#x60; of the Role | 

### Return type

[**ModelClient**](ModelClient.md)

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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

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
            var userId = "userId_example";  // string | ID of an existing Okta user
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
 **userId** | **string**| ID of an existing Okta user | 
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

