# Okta.Sdk.Api.GroupApi

All URIs are relative to *https://your-subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateGroupRule**](GroupApi.md#activategrouprule) | **POST** /api/v1/groups/rules/{ruleId}/lifecycle/activate | Activate a group Rule
[**AddApplicationInstanceTargetToAppAdminRoleGivenToGroup**](GroupApi.md#addapplicationinstancetargettoappadminrolegiventogroup) | **PUT** /api/v1/groups/{groupId}/roles/{roleId}/targets/catalog/apps/{appName}/{applicationId} | Add App Instance Target to App Administrator Role given to a Group
[**AddApplicationTargetToAdminRoleGivenToGroup**](GroupApi.md#addapplicationtargettoadminrolegiventogroup) | **PUT** /api/v1/groups/{groupId}/roles/{roleId}/targets/catalog/apps/{appName} | Add Application Target to Admin Role Given to Group
[**AddGroupTargetToGroupAdministratorRoleForGroup**](GroupApi.md#addgrouptargettogroupadministratorroleforgroup) | **PUT** /api/v1/groups/{groupId}/roles/{roleId}/targets/groups/{targetGroupId} | Add Group Target for Group Role
[**AddUserToGroup**](GroupApi.md#addusertogroup) | **PUT** /api/v1/groups/{groupId}/users/{userId} | Add User to Group
[**AssignRoleToGroup**](GroupApi.md#assignroletogroup) | **POST** /api/v1/groups/{groupId}/roles | Assign Role to Group
[**CreateGroup**](GroupApi.md#creategroup) | **POST** /api/v1/groups | Add Group
[**CreateGroupRule**](GroupApi.md#creategrouprule) | **POST** /api/v1/groups/rules | Create Group Rule
[**DeactivateGroupRule**](GroupApi.md#deactivategrouprule) | **POST** /api/v1/groups/rules/{ruleId}/lifecycle/deactivate | Deactivate a group Rule
[**DeleteGroup**](GroupApi.md#deletegroup) | **DELETE** /api/v1/groups/{groupId} | Remove Group
[**DeleteGroupRule**](GroupApi.md#deletegrouprule) | **DELETE** /api/v1/groups/rules/{ruleId} | Delete a group Rule
[**GetGroup**](GroupApi.md#getgroup) | **GET** /api/v1/groups/{groupId} | List Group Rules
[**GetGroupRule**](GroupApi.md#getgrouprule) | **GET** /api/v1/groups/rules/{ruleId} | Get Group Rule
[**GetRole**](GroupApi.md#getrole) | **GET** /api/v1/groups/{groupId}/roles/{roleId} | Get Role
[**ListApplicationTargetsForApplicationAdministratorRoleForGroup**](GroupApi.md#listapplicationtargetsforapplicationadministratorroleforgroup) | **GET** /api/v1/groups/{groupId}/roles/{roleId}/targets/catalog/apps | List Application Targets for Application Administrator Role for Group
[**ListAssignedApplicationsForGroup**](GroupApi.md#listassignedapplicationsforgroup) | **GET** /api/v1/groups/{groupId}/apps | List Assigned Applications
[**ListGroupAssignedRoles**](GroupApi.md#listgroupassignedroles) | **GET** /api/v1/groups/{groupId}/roles | List Group Assigned Roles
[**ListGroupRules**](GroupApi.md#listgrouprules) | **GET** /api/v1/groups/rules | List Group Rules
[**ListGroupTargetsForGroupRole**](GroupApi.md#listgrouptargetsforgrouprole) | **GET** /api/v1/groups/{groupId}/roles/{roleId}/targets/groups | List Group Targets for Group Role
[**ListGroupUsers**](GroupApi.md#listgroupusers) | **GET** /api/v1/groups/{groupId}/users | List Group Members
[**ListGroups**](GroupApi.md#listgroups) | **GET** /api/v1/groups | List Groups
[**RemoveApplicationTargetFromAdministratorRoleGivenToGroup**](GroupApi.md#removeapplicationtargetfromadministratorrolegiventogroup) | **DELETE** /api/v1/groups/{groupId}/roles/{roleId}/targets/catalog/apps/{appName}/{applicationId} | Remove App Instance Target to App Administrator Role given to a Group
[**RemoveApplicationTargetFromApplicationAdministratorRoleGivenToGroup**](GroupApi.md#removeapplicationtargetfromapplicationadministratorrolegiventogroup) | **DELETE** /api/v1/groups/{groupId}/roles/{roleId}/targets/catalog/apps/{appName} | Remove Application Target from Application Administrator Role Given to Group
[**RemoveGroupTargetFromGroupAdministratorRoleGivenToGroup**](GroupApi.md#removegrouptargetfromgroupadministratorrolegiventogroup) | **DELETE** /api/v1/groups/{groupId}/roles/{roleId}/targets/groups/{targetGroupId} | Delete Group Target for Group Role
[**RemoveRoleFromGroup**](GroupApi.md#removerolefromgroup) | **DELETE** /api/v1/groups/{groupId}/roles/{roleId} | Remove Role from Group
[**RemoveUserFromGroup**](GroupApi.md#removeuserfromgroup) | **DELETE** /api/v1/groups/{groupId}/users/{userId} | Remove User from Group
[**UpdateGroup**](GroupApi.md#updategroup) | **PUT** /api/v1/groups/{groupId} | Update Group
[**UpdateGroupRule**](GroupApi.md#updategrouprule) | **PUT** /api/v1/groups/rules/{ruleId} | Update Group Rule


<a name="activategrouprule"></a>
# **ActivateGroupRule**
> void ActivateGroupRule (string ruleId)

Activate a group Rule

Activates a specific group rule by id from your organization

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateGroupRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var ruleId = "ruleId_example";  // string | 

            try
            {
                // Activate a group Rule
                apiInstance.ActivateGroupRule(ruleId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.ActivateGroupRule: " + e.Message );
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
 **ruleId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="addapplicationinstancetargettoappadminrolegiventogroup"></a>
# **AddApplicationInstanceTargetToAppAdminRoleGivenToGroup**
> void AddApplicationInstanceTargetToAppAdminRoleGivenToGroup (string groupId, string roleId, string appName, string applicationId)

Add App Instance Target to App Administrator Role given to a Group

Add App Instance Target to App Administrator Role given to a Group

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AddApplicationInstanceTargetToAppAdminRoleGivenToGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = "groupId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var appName = "appName_example";  // string | 
            var applicationId = "applicationId_example";  // string | 

            try
            {
                // Add App Instance Target to App Administrator Role given to a Group
                apiInstance.AddApplicationInstanceTargetToAppAdminRoleGivenToGroup(groupId, roleId, appName, applicationId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.AddApplicationInstanceTargetToAppAdminRoleGivenToGroup: " + e.Message );
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
 **groupId** | **string**|  | 
 **roleId** | **string**|  | 
 **appName** | **string**|  | 
 **applicationId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="addapplicationtargettoadminrolegiventogroup"></a>
# **AddApplicationTargetToAdminRoleGivenToGroup**
> void AddApplicationTargetToAdminRoleGivenToGroup (string groupId, string roleId, string appName)

Add Application Target to Admin Role Given to Group

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AddApplicationTargetToAdminRoleGivenToGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = "groupId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var appName = "appName_example";  // string | 

            try
            {
                // Add Application Target to Admin Role Given to Group
                apiInstance.AddApplicationTargetToAdminRoleGivenToGroup(groupId, roleId, appName);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.AddApplicationTargetToAdminRoleGivenToGroup: " + e.Message );
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
 **groupId** | **string**|  | 
 **roleId** | **string**|  | 
 **appName** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="addgrouptargettogroupadministratorroleforgroup"></a>
# **AddGroupTargetToGroupAdministratorRoleForGroup**
> void AddGroupTargetToGroupAdministratorRoleForGroup (string groupId, string roleId, string targetGroupId)

Add Group Target for Group Role

Enumerates group targets for a group role.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AddGroupTargetToGroupAdministratorRoleForGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = "groupId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var targetGroupId = "targetGroupId_example";  // string | 

            try
            {
                // Add Group Target for Group Role
                apiInstance.AddGroupTargetToGroupAdministratorRoleForGroup(groupId, roleId, targetGroupId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.AddGroupTargetToGroupAdministratorRoleForGroup: " + e.Message );
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
 **groupId** | **string**|  | 
 **roleId** | **string**|  | 
 **targetGroupId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="addusertogroup"></a>
# **AddUserToGroup**
> void AddUserToGroup (string groupId, string userId)

Add User to Group

Adds a user to a group with 'OKTA_GROUP' type.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AddUserToGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = "groupId_example";  // string | 
            var userId = "userId_example";  // string | 

            try
            {
                // Add User to Group
                apiInstance.AddUserToGroup(groupId, userId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.AddUserToGroup: " + e.Message );
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
 **groupId** | **string**|  | 
 **userId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="assignroletogroup"></a>
# **AssignRoleToGroup**
> Role AssignRoleToGroup (string groupId, AssignRoleRequest assignRoleRequest, bool? disableNotifications = null)

Assign Role to Group

Assigns a Role to a Group

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
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = "groupId_example";  // string | 
            var assignRoleRequest = new AssignRoleRequest(); // AssignRoleRequest | 
            var disableNotifications = true;  // bool? |  (optional) 

            try
            {
                // Assign Role to Group
                Role result = apiInstance.AssignRoleToGroup(groupId, assignRoleRequest, disableNotifications);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.AssignRoleToGroup: " + e.Message );
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
 **groupId** | **string**|  | 
 **assignRoleRequest** | [**AssignRoleRequest**](AssignRoleRequest.md)|  | 
 **disableNotifications** | **bool?**|  | [optional] 

### Return type

[**Role**](Role.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **201** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="creategroup"></a>
# **CreateGroup**
> Group CreateGroup (Group group)

Add Group

Adds a new group with `OKTA_GROUP` type to your organization.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var group = new Group(); // Group | 

            try
            {
                // Add Group
                Group result = apiInstance.CreateGroup(group);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.CreateGroup: " + e.Message );
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
 **group** | [**Group**](Group.md)|  | 

### Return type

[**Group**](Group.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="creategrouprule"></a>
# **CreateGroupRule**
> GroupRule CreateGroupRule (GroupRule groupRule)

Create Group Rule

Creates a group rule to dynamically add users to the specified group if they match the condition

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateGroupRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupRule = new GroupRule(); // GroupRule | 

            try
            {
                // Create Group Rule
                GroupRule result = apiInstance.CreateGroupRule(groupRule);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.CreateGroupRule: " + e.Message );
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
 **groupRule** | [**GroupRule**](GroupRule.md)|  | 

### Return type

[**GroupRule**](GroupRule.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivategrouprule"></a>
# **DeactivateGroupRule**
> void DeactivateGroupRule (string ruleId)

Deactivate a group Rule

Deactivates a specific group rule by id from your organization

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateGroupRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var ruleId = "ruleId_example";  // string | 

            try
            {
                // Deactivate a group Rule
                apiInstance.DeactivateGroupRule(ruleId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.DeactivateGroupRule: " + e.Message );
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
 **ruleId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletegroup"></a>
# **DeleteGroup**
> void DeleteGroup (string groupId)

Remove Group

Removes a group with `OKTA_GROUP` type from your organization.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = "groupId_example";  // string | 

            try
            {
                // Remove Group
                apiInstance.DeleteGroup(groupId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.DeleteGroup: " + e.Message );
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
 **groupId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletegrouprule"></a>
# **DeleteGroupRule**
> void DeleteGroupRule (string ruleId, bool? removeUsers = null)

Delete a group Rule

Removes a specific group rule by id from your organization

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteGroupRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var ruleId = "ruleId_example";  // string | 
            var removeUsers = true;  // bool? | Indicates whether to keep or remove users from groups assigned by this rule. (optional) 

            try
            {
                // Delete a group Rule
                apiInstance.DeleteGroupRule(ruleId, removeUsers);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.DeleteGroupRule: " + e.Message );
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
 **ruleId** | **string**|  | 
 **removeUsers** | **bool?**| Indicates whether to keep or remove users from groups assigned by this rule. | [optional] 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | Accepted |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getgroup"></a>
# **GetGroup**
> Group GetGroup (string groupId)

List Group Rules

Fetches a group from your organization.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = "groupId_example";  // string | 

            try
            {
                // List Group Rules
                Group result = apiInstance.GetGroup(groupId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.GetGroup: " + e.Message );
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
 **groupId** | **string**|  | 

### Return type

[**Group**](Group.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getgrouprule"></a>
# **GetGroupRule**
> GroupRule GetGroupRule (string ruleId, string expand = null)

Get Group Rule

Fetches a specific group rule by id from your organization

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetGroupRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var ruleId = "ruleId_example";  // string | 
            var expand = "expand_example";  // string |  (optional) 

            try
            {
                // Get Group Rule
                GroupRule result = apiInstance.GetGroupRule(ruleId, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.GetGroupRule: " + e.Message );
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
 **ruleId** | **string**|  | 
 **expand** | **string**|  | [optional] 

### Return type

[**GroupRule**](GroupRule.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getrole"></a>
# **GetRole**
> Role GetRole (string groupId, string roleId)

Get Role

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetRoleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = "groupId_example";  // string | 
            var roleId = "roleId_example";  // string | 

            try
            {
                // Get Role
                Role result = apiInstance.GetRole(groupId, roleId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.GetRole: " + e.Message );
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
 **groupId** | **string**|  | 
 **roleId** | **string**|  | 

### Return type

[**Role**](Role.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listapplicationtargetsforapplicationadministratorroleforgroup"></a>
# **ListApplicationTargetsForApplicationAdministratorRoleForGroup**
> List&lt;CatalogApplication&gt; ListApplicationTargetsForApplicationAdministratorRoleForGroup (string groupId, string roleId, string after = null, int? limit = null)

List Application Targets for Application Administrator Role for Group

Lists all App targets for an `APP_ADMIN` Role assigned to a Group. This methods return list may include full Applications or Instances. The response for an instance will have an `ID` value, while Application will not have an ID.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListApplicationTargetsForApplicationAdministratorRoleForGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = "groupId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var after = "after_example";  // string |  (optional) 
            var limit = 20;  // int? |  (optional)  (default to 20)

            try
            {
                // List Application Targets for Application Administrator Role for Group
                List<CatalogApplication> result = apiInstance.ListApplicationTargetsForApplicationAdministratorRoleForGroup(groupId, roleId, after, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.ListApplicationTargetsForApplicationAdministratorRoleForGroup: " + e.Message );
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
 **groupId** | **string**|  | 
 **roleId** | **string**|  | 
 **after** | **string**|  | [optional] 
 **limit** | **int?**|  | [optional] [default to 20]

### Return type

[**List&lt;CatalogApplication&gt;**](CatalogApplication.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listassignedapplicationsforgroup"></a>
# **ListAssignedApplicationsForGroup**
> List&lt;Application&gt; ListAssignedApplicationsForGroup (string groupId, string after = null, int? limit = null)

List Assigned Applications

Enumerates all applications that are assigned to a group.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListAssignedApplicationsForGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = "groupId_example";  // string | 
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of apps (optional) 
            var limit = 20;  // int? | Specifies the number of app results for a page (optional)  (default to 20)

            try
            {
                // List Assigned Applications
                List<Application> result = apiInstance.ListAssignedApplicationsForGroup(groupId, after, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.ListAssignedApplicationsForGroup: " + e.Message );
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
 **groupId** | **string**|  | 
 **after** | **string**| Specifies the pagination cursor for the next page of apps | [optional] 
 **limit** | **int?**| Specifies the number of app results for a page | [optional] [default to 20]

### Return type

[**List&lt;Application&gt;**](Application.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listgroupassignedroles"></a>
# **ListGroupAssignedRoles**
> List&lt;Role&gt; ListGroupAssignedRoles (string groupId, string expand = null)

List Group Assigned Roles

Success

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
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = "groupId_example";  // string | 
            var expand = "expand_example";  // string |  (optional) 

            try
            {
                // List Group Assigned Roles
                List<Role> result = apiInstance.ListGroupAssignedRoles(groupId, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.ListGroupAssignedRoles: " + e.Message );
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
 **groupId** | **string**|  | 
 **expand** | **string**|  | [optional] 

### Return type

[**List&lt;Role&gt;**](Role.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listgrouprules"></a>
# **ListGroupRules**
> List&lt;GroupRule&gt; ListGroupRules (int? limit = null, string after = null, string search = null, string expand = null)

List Group Rules

Lists all group rules for your organization.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListGroupRulesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var limit = 50;  // int? | Specifies the number of rule results in a page (optional)  (default to 50)
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of rules (optional) 
            var search = "search_example";  // string | Specifies the keyword to search fules for (optional) 
            var expand = "expand_example";  // string | If specified as `groupIdToGroupNameMap`, then show group names (optional) 

            try
            {
                // List Group Rules
                List<GroupRule> result = apiInstance.ListGroupRules(limit, after, search, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.ListGroupRules: " + e.Message );
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
 **limit** | **int?**| Specifies the number of rule results in a page | [optional] [default to 50]
 **after** | **string**| Specifies the pagination cursor for the next page of rules | [optional] 
 **search** | **string**| Specifies the keyword to search fules for | [optional] 
 **expand** | **string**| If specified as &#x60;groupIdToGroupNameMap&#x60;, then show group names | [optional] 

### Return type

[**List&lt;GroupRule&gt;**](GroupRule.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listgrouptargetsforgrouprole"></a>
# **ListGroupTargetsForGroupRole**
> List&lt;Group&gt; ListGroupTargetsForGroupRole (string groupId, string roleId, string after = null, int? limit = null)

List Group Targets for Group Role

Enumerates group targets for a group role.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListGroupTargetsForGroupRoleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = "groupId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var after = "after_example";  // string |  (optional) 
            var limit = 20;  // int? |  (optional)  (default to 20)

            try
            {
                // List Group Targets for Group Role
                List<Group> result = apiInstance.ListGroupTargetsForGroupRole(groupId, roleId, after, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.ListGroupTargetsForGroupRole: " + e.Message );
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
 **groupId** | **string**|  | 
 **roleId** | **string**|  | 
 **after** | **string**|  | [optional] 
 **limit** | **int?**|  | [optional] [default to 20]

### Return type

[**List&lt;Group&gt;**](Group.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listgroupusers"></a>
# **ListGroupUsers**
> List&lt;User&gt; ListGroupUsers (string groupId, string after = null, int? limit = null)

List Group Members

Enumerates all users that are a member of a group.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListGroupUsersExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = "groupId_example";  // string | 
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of users (optional) 
            var limit = 1000;  // int? | Specifies the number of user results in a page (optional)  (default to 1000)

            try
            {
                // List Group Members
                List<User> result = apiInstance.ListGroupUsers(groupId, after, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.ListGroupUsers: " + e.Message );
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
 **groupId** | **string**|  | 
 **after** | **string**| Specifies the pagination cursor for the next page of users | [optional] 
 **limit** | **int?**| Specifies the number of user results in a page | [optional] [default to 1000]

### Return type

[**List&lt;User&gt;**](User.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listgroups"></a>
# **ListGroups**
> List&lt;Group&gt; ListGroups (string q = null, string search = null, string after = null, int? limit = null, string expand = null)

List Groups

Enumerates groups in your organization with pagination. A subset of groups can be returned that match a supported filter expression or query.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListGroupsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var q = "q_example";  // string | Searches the name property of groups for matching value (optional) 
            var search = "search_example";  // string | Filter expression for groups (optional) 
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of groups (optional) 
            var limit = 10000;  // int? | Specifies the number of group results in a page (optional)  (default to 10000)
            var expand = "expand_example";  // string | If specified, it causes additional metadata to be included in the response. (optional) 

            try
            {
                // List Groups
                List<Group> result = apiInstance.ListGroups(q, search, after, limit, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.ListGroups: " + e.Message );
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
 **q** | **string**| Searches the name property of groups for matching value | [optional] 
 **search** | **string**| Filter expression for groups | [optional] 
 **after** | **string**| Specifies the pagination cursor for the next page of groups | [optional] 
 **limit** | **int?**| Specifies the number of group results in a page | [optional] [default to 10000]
 **expand** | **string**| If specified, it causes additional metadata to be included in the response. | [optional] 

### Return type

[**List&lt;Group&gt;**](Group.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="removeapplicationtargetfromadministratorrolegiventogroup"></a>
# **RemoveApplicationTargetFromAdministratorRoleGivenToGroup**
> void RemoveApplicationTargetFromAdministratorRoleGivenToGroup (string groupId, string roleId, string appName, string applicationId)

Remove App Instance Target to App Administrator Role given to a Group

Remove App Instance Target to App Administrator Role given to a Group

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RemoveApplicationTargetFromAdministratorRoleGivenToGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = "groupId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var appName = "appName_example";  // string | 
            var applicationId = "applicationId_example";  // string | 

            try
            {
                // Remove App Instance Target to App Administrator Role given to a Group
                apiInstance.RemoveApplicationTargetFromAdministratorRoleGivenToGroup(groupId, roleId, appName, applicationId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.RemoveApplicationTargetFromAdministratorRoleGivenToGroup: " + e.Message );
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
 **groupId** | **string**|  | 
 **roleId** | **string**|  | 
 **appName** | **string**|  | 
 **applicationId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="removeapplicationtargetfromapplicationadministratorrolegiventogroup"></a>
# **RemoveApplicationTargetFromApplicationAdministratorRoleGivenToGroup**
> void RemoveApplicationTargetFromApplicationAdministratorRoleGivenToGroup (string groupId, string roleId, string appName)

Remove Application Target from Application Administrator Role Given to Group

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RemoveApplicationTargetFromApplicationAdministratorRoleGivenToGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = "groupId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var appName = "appName_example";  // string | 

            try
            {
                // Remove Application Target from Application Administrator Role Given to Group
                apiInstance.RemoveApplicationTargetFromApplicationAdministratorRoleGivenToGroup(groupId, roleId, appName);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.RemoveApplicationTargetFromApplicationAdministratorRoleGivenToGroup: " + e.Message );
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
 **groupId** | **string**|  | 
 **roleId** | **string**|  | 
 **appName** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="removegrouptargetfromgroupadministratorrolegiventogroup"></a>
# **RemoveGroupTargetFromGroupAdministratorRoleGivenToGroup**
> void RemoveGroupTargetFromGroupAdministratorRoleGivenToGroup (string groupId, string roleId, string targetGroupId)

Delete Group Target for Group Role

remove group target for a group role.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RemoveGroupTargetFromGroupAdministratorRoleGivenToGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = "groupId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var targetGroupId = "targetGroupId_example";  // string | 

            try
            {
                // Delete Group Target for Group Role
                apiInstance.RemoveGroupTargetFromGroupAdministratorRoleGivenToGroup(groupId, roleId, targetGroupId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.RemoveGroupTargetFromGroupAdministratorRoleGivenToGroup: " + e.Message );
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
 **groupId** | **string**|  | 
 **roleId** | **string**|  | 
 **targetGroupId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="removerolefromgroup"></a>
# **RemoveRoleFromGroup**
> void RemoveRoleFromGroup (string groupId, string roleId)

Remove Role from Group

Unassigns a Role from a Group

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RemoveRoleFromGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = "groupId_example";  // string | 
            var roleId = "roleId_example";  // string | 

            try
            {
                // Remove Role from Group
                apiInstance.RemoveRoleFromGroup(groupId, roleId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.RemoveRoleFromGroup: " + e.Message );
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
 **groupId** | **string**|  | 
 **roleId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="removeuserfromgroup"></a>
# **RemoveUserFromGroup**
> void RemoveUserFromGroup (string groupId, string userId)

Remove User from Group

Removes a user from a group with 'OKTA_GROUP' type.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RemoveUserFromGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = "groupId_example";  // string | 
            var userId = "userId_example";  // string | 

            try
            {
                // Remove User from Group
                apiInstance.RemoveUserFromGroup(groupId, userId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.RemoveUserFromGroup: " + e.Message );
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
 **groupId** | **string**|  | 
 **userId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updategroup"></a>
# **UpdateGroup**
> Group UpdateGroup (string groupId, Group group)

Update Group

Updates the profile for a group with `OKTA_GROUP` type from your organization.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = "groupId_example";  // string | 
            var group = new Group(); // Group | 

            try
            {
                // Update Group
                Group result = apiInstance.UpdateGroup(groupId, group);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.UpdateGroup: " + e.Message );
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
 **groupId** | **string**|  | 
 **group** | [**Group**](Group.md)|  | 

### Return type

[**Group**](Group.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updategrouprule"></a>
# **UpdateGroupRule**
> GroupRule UpdateGroupRule (string ruleId, GroupRule groupRule)

Update Group Rule

Updates a group rule. Only `INACTIVE` rules can be updated.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateGroupRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var ruleId = "ruleId_example";  // string | 
            var groupRule = new GroupRule(); // GroupRule | 

            try
            {
                // Update Group Rule
                GroupRule result = apiInstance.UpdateGroupRule(ruleId, groupRule);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.UpdateGroupRule: " + e.Message );
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
 **ruleId** | **string**|  | 
 **groupRule** | [**GroupRule**](GroupRule.md)|  | 

### Return type

[**GroupRule**](GroupRule.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

