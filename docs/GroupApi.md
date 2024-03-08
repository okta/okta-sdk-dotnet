# Okta.Sdk.Api.GroupApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateGroupRule**](GroupApi.md#activategrouprule) | **POST** /api/v1/groups/rules/{groupRuleId}/lifecycle/activate | Activate a Group Rule
[**AssignGroupOwner**](GroupApi.md#assigngroupowner) | **POST** /api/v1/groups/{groupId}/owners | Assign a Group Owner
[**AssignUserToGroup**](GroupApi.md#assignusertogroup) | **PUT** /api/v1/groups/{groupId}/users/{userId} | Assign a User
[**CreateGroup**](GroupApi.md#creategroup) | **POST** /api/v1/groups | Create a Group
[**CreateGroupRule**](GroupApi.md#creategrouprule) | **POST** /api/v1/groups/rules | Create a Group Rule
[**DeactivateGroupRule**](GroupApi.md#deactivategrouprule) | **POST** /api/v1/groups/rules/{groupRuleId}/lifecycle/deactivate | Deactivate a Group Rule
[**DeleteGroup**](GroupApi.md#deletegroup) | **DELETE** /api/v1/groups/{groupId} | Delete a Group
[**DeleteGroupOwner**](GroupApi.md#deletegroupowner) | **DELETE** /api/v1/groups/{groupId}/owners/{ownerId} | Delete a Group Owner
[**DeleteGroupRule**](GroupApi.md#deletegrouprule) | **DELETE** /api/v1/groups/rules/{groupRuleId} | Delete a group Rule
[**GetGroup**](GroupApi.md#getgroup) | **GET** /api/v1/groups/{groupId} | Retrieve a Group
[**GetGroupRule**](GroupApi.md#getgrouprule) | **GET** /api/v1/groups/rules/{groupRuleId} | Retrieve a Group Rule
[**ListAssignedApplicationsForGroup**](GroupApi.md#listassignedapplicationsforgroup) | **GET** /api/v1/groups/{groupId}/apps | List all Assigned Applications
[**ListGroupOwners**](GroupApi.md#listgroupowners) | **GET** /api/v1/groups/{groupId}/owners | List all Group Owners
[**ListGroupRules**](GroupApi.md#listgrouprules) | **GET** /api/v1/groups/rules | List all Group Rules
[**ListGroupUsers**](GroupApi.md#listgroupusers) | **GET** /api/v1/groups/{groupId}/users | List all Member Users
[**ListGroups**](GroupApi.md#listgroups) | **GET** /api/v1/groups | List all Groups
[**ReplaceGroup**](GroupApi.md#replacegroup) | **PUT** /api/v1/groups/{groupId} | Replace a Group
[**ReplaceGroupRule**](GroupApi.md#replacegrouprule) | **PUT** /api/v1/groups/rules/{groupRuleId} | Replace a Group Rule
[**UnassignUserFromGroup**](GroupApi.md#unassignuserfromgroup) | **DELETE** /api/v1/groups/{groupId}/users/{userId} | Unassign a User


<a name="activategrouprule"></a>
# **ActivateGroupRule**
> void ActivateGroupRule (string groupRuleId)

Activate a Group Rule

Activates a specific group rule by `groupRuleId`

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupRuleId = 0pr3f7zMZZHPgUoWO0g4;  // string | The `id` of the group rule

            try
            {
                // Activate a Group Rule
                apiInstance.ActivateGroupRule(groupRuleId);
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
 **groupRuleId** | **string**| The &#x60;id&#x60; of the group rule | 

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

<a name="assigngroupowner"></a>
# **AssignGroupOwner**
> GroupOwner AssignGroupOwner (string groupId, string groupId2, AssignGroupOwnerRequestBody assignGroupOwnerRequestBody)

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

            var apiInstance = new GroupApi(config);
            var groupId = "groupId_example";  // string | 
            var groupId2 = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var assignGroupOwnerRequestBody = new AssignGroupOwnerRequestBody(); // AssignGroupOwnerRequestBody | 

            try
            {
                // Assign a Group Owner
                GroupOwner result = apiInstance.AssignGroupOwner(groupId, groupId2, assignGroupOwnerRequestBody);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.AssignGroupOwner: " + e.Message );
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
 **groupId2** | **string**| The &#x60;id&#x60; of the group | 
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
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="assignusertogroup"></a>
# **AssignUserToGroup**
> void AssignUserToGroup (string groupId, string userId)

Assign a User

Assigns a user to a group with 'OKTA_GROUP' type

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AssignUserToGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var userId = "userId_example";  // string | 

            try
            {
                // Assign a User
                apiInstance.AssignUserToGroup(groupId, userId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.AssignUserToGroup: " + e.Message );
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
 **userId** | **string**|  | 

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

<a name="creategroup"></a>
# **CreateGroup**
> Group CreateGroup (Group group)

Create a Group

Creates a new group with `OKTA_GROUP` type

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var group = new Group(); // Group | 

            try
            {
                // Create a Group
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
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="creategrouprule"></a>
# **CreateGroupRule**
> GroupRule CreateGroupRule (GroupRule groupRule)

Create a Group Rule

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupRule = new GroupRule(); // GroupRule | 

            try
            {
                // Create a Group Rule
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
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivategrouprule"></a>
# **DeactivateGroupRule**
> void DeactivateGroupRule (string groupRuleId)

Deactivate a Group Rule

Deactivates a specific group rule by `groupRuleId`

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupRuleId = 0pr3f7zMZZHPgUoWO0g4;  // string | The `id` of the group rule

            try
            {
                // Deactivate a Group Rule
                apiInstance.DeactivateGroupRule(groupRuleId);
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
 **groupRuleId** | **string**| The &#x60;id&#x60; of the group rule | 

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

<a name="deletegroup"></a>
# **DeleteGroup**
> void DeleteGroup (string groupId)

Delete a Group

Deletes a group with `OKTA_GROUP` type

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group

            try
            {
                // Delete a Group
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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

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

            var apiInstance = new GroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var ownerId = 00u1emaK22TWRYd3TtG;  // string | The `id` of the group owner

            try
            {
                // Delete a Group Owner
                apiInstance.DeleteGroupOwner(groupId, ownerId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.DeleteGroupOwner: " + e.Message );
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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletegrouprule"></a>
# **DeleteGroupRule**
> void DeleteGroupRule (string groupRuleId, bool? removeUsers = null)

Delete a group Rule

Deletes a specific group rule by `groupRuleId`

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupRuleId = 0pr3f7zMZZHPgUoWO0g4;  // string | The `id` of the group rule
            var removeUsers = true;  // bool? | Indicates whether to keep or remove users from groups assigned by this rule. (optional) 

            try
            {
                // Delete a group Rule
                apiInstance.DeleteGroupRule(groupRuleId, removeUsers);
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
 **groupRuleId** | **string**| The &#x60;id&#x60; of the group rule | 
 **removeUsers** | **bool?**| Indicates whether to keep or remove users from groups assigned by this rule. | [optional] 

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
| **202** | Accepted |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getgroup"></a>
# **GetGroup**
> Group GetGroup (string groupId)

Retrieve a Group

Retrieves a group by `groupId`

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group

            try
            {
                // Retrieve a Group
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
 **groupId** | **string**| The &#x60;id&#x60; of the group | 

### Return type

[**Group**](Group.md)

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

<a name="getgrouprule"></a>
# **GetGroupRule**
> GroupRule GetGroupRule (string groupRuleId, string expand = null)

Retrieve a Group Rule

Retrieves a specific group rule by `groupRuleId`

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupRuleId = 0pr3f7zMZZHPgUoWO0g4;  // string | The `id` of the group rule
            var expand = "expand_example";  // string |  (optional) 

            try
            {
                // Retrieve a Group Rule
                GroupRule result = apiInstance.GetGroupRule(groupRuleId, expand);
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
 **groupRuleId** | **string**| The &#x60;id&#x60; of the group rule | 
 **expand** | **string**|  | [optional] 

### Return type

[**GroupRule**](GroupRule.md)

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

<a name="listassignedapplicationsforgroup"></a>
# **ListAssignedApplicationsForGroup**
> List&lt;Application&gt; ListAssignedApplicationsForGroup (string groupId, string after = null, int? limit = null)

List all Assigned Applications

Lists all applications that are assigned to a group

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of apps (optional) 
            var limit = 20;  // int? | Specifies the number of app results for a page (optional)  (default to 20)

            try
            {
                // List all Assigned Applications
                List<Application> result = apiInstance.ListAssignedApplicationsForGroup(groupId, after, limit).ToListAsync();
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
 **groupId** | **string**| The &#x60;id&#x60; of the group | 
 **after** | **string**| Specifies the pagination cursor for the next page of apps | [optional] 
 **limit** | **int?**| Specifies the number of app results for a page | [optional] [default to 20]

### Return type

[**List&lt;Application&gt;**](Application.md)

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

<a name="listgroupowners"></a>
# **ListGroupOwners**
> List&lt;GroupOwner&gt; ListGroupOwners (string groupId, string filter = null, string after = null, int? limit = null)

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

            var apiInstance = new GroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var filter = "filter_example";  // string | SCIM Filter expression for group owners. Allows to filter owners by type. (optional) 
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of owners (optional) 
            var limit = 1000;  // int? | Specifies the number of owner results in a page (optional)  (default to 1000)

            try
            {
                // List all Group Owners
                List<GroupOwner> result = apiInstance.ListGroupOwners(groupId, filter, after, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.ListGroupOwners: " + e.Message );
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
 **filter** | **string**| SCIM Filter expression for group owners. Allows to filter owners by type. | [optional] 
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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listgrouprules"></a>
# **ListGroupRules**
> List&lt;GroupRule&gt; ListGroupRules (int? limit = null, string after = null, string search = null, string expand = null)

List all Group Rules

Lists all group rules

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var limit = 50;  // int? | Specifies the number of rule results in a page (optional)  (default to 50)
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of rules (optional) 
            var search = "search_example";  // string | Specifies the keyword to search fules for (optional) 
            var expand = "expand_example";  // string | If specified as `groupIdToGroupNameMap`, then show group names (optional) 

            try
            {
                // List all Group Rules
                List<GroupRule> result = apiInstance.ListGroupRules(limit, after, search, expand).ToListAsync();
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

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **403** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listgroupusers"></a>
# **ListGroupUsers**
> List&lt;User&gt; ListGroupUsers (string groupId, string after = null, int? limit = null)

List all Member Users

Lists all users that are a member of a group

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of users (optional) 
            var limit = 1000;  // int? | Specifies the number of user results in a page (optional)  (default to 1000)

            try
            {
                // List all Member Users
                List<User> result = apiInstance.ListGroupUsers(groupId, after, limit).ToListAsync();
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
 **groupId** | **string**| The &#x60;id&#x60; of the group | 
 **after** | **string**| Specifies the pagination cursor for the next page of users | [optional] 
 **limit** | **int?**| Specifies the number of user results in a page | [optional] [default to 1000]

### Return type

[**List&lt;User&gt;**](User.md)

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

<a name="listgroups"></a>
# **ListGroups**
> List&lt;Group&gt; ListGroups (string q = null, string filter = null, string after = null, int? limit = null, string expand = null, string search = null, string sortBy = null, string sortOrder = null)

List all Groups

Lists all groups with pagination support. A subset of groups can be returned that match a supported filter expression or query.

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var q = "q_example";  // string | Searches the name property of groups for matching value (optional) 
            var filter = "filter_example";  // string | Filter expression for groups (optional) 
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of groups (optional) 
            var limit = 10000;  // int? | Specifies the number of group results in a page (optional)  (default to 10000)
            var expand = "expand_example";  // string | If specified, it causes additional metadata to be included in the response. (optional) 
            var search = "search_example";  // string | Searches for groups with a supported filtering expression for all attributes except for _embedded, _links, and objectClass (optional) 
            var sortBy = lastUpdated;  // string | Specifies field to sort by and can be any single property (for search queries only). (optional) 
            var sortOrder = "\"asc\"";  // string | Specifies sort order `asc` or `desc` (for search queries only). This parameter is ignored if `sortBy` is not present. Groups with the same value for the `sortBy` parameter are ordered by `id`. (optional)  (default to "asc")

            try
            {
                // List all Groups
                List<Group> result = apiInstance.ListGroups(q, filter, after, limit, expand, search, sortBy, sortOrder).ToListAsync();
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
 **filter** | **string**| Filter expression for groups | [optional] 
 **after** | **string**| Specifies the pagination cursor for the next page of groups | [optional] 
 **limit** | **int?**| Specifies the number of group results in a page | [optional] [default to 10000]
 **expand** | **string**| If specified, it causes additional metadata to be included in the response. | [optional] 
 **search** | **string**| Searches for groups with a supported filtering expression for all attributes except for _embedded, _links, and objectClass | [optional] 
 **sortBy** | **string**| Specifies field to sort by and can be any single property (for search queries only). | [optional] 
 **sortOrder** | **string**| Specifies sort order &#x60;asc&#x60; or &#x60;desc&#x60; (for search queries only). This parameter is ignored if &#x60;sortBy&#x60; is not present. Groups with the same value for the &#x60;sortBy&#x60; parameter are ordered by &#x60;id&#x60;. | [optional] [default to &quot;asc&quot;]

### Return type

[**List&lt;Group&gt;**](Group.md)

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
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacegroup"></a>
# **ReplaceGroup**
> Group ReplaceGroup (string groupId, Group group)

Replace a Group

Replaces the profile for a group with `OKTA_GROUP` type

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var group = new Group(); // Group | 

            try
            {
                // Replace a Group
                Group result = apiInstance.ReplaceGroup(groupId, group);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.ReplaceGroup: " + e.Message );
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
 **group** | [**Group**](Group.md)|  | 

### Return type

[**Group**](Group.md)

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

<a name="replacegrouprule"></a>
# **ReplaceGroupRule**
> GroupRule ReplaceGroupRule (string groupRuleId, GroupRule groupRule)

Replace a Group Rule

Replaces a group rule. Only `INACTIVE` rules can be updated.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceGroupRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupRuleId = 0pr3f7zMZZHPgUoWO0g4;  // string | The `id` of the group rule
            var groupRule = new GroupRule(); // GroupRule | 

            try
            {
                // Replace a Group Rule
                GroupRule result = apiInstance.ReplaceGroupRule(groupRuleId, groupRule);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.ReplaceGroupRule: " + e.Message );
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
 **groupRuleId** | **string**| The &#x60;id&#x60; of the group rule | 
 **groupRule** | [**GroupRule**](GroupRule.md)|  | 

### Return type

[**GroupRule**](GroupRule.md)

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

<a name="unassignuserfromgroup"></a>
# **UnassignUserFromGroup**
> void UnassignUserFromGroup (string groupId, string userId)

Unassign a User

Unassigns a user from a group with 'OKTA_GROUP' type

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UnassignUserFromGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var userId = "userId_example";  // string | 

            try
            {
                // Unassign a User
                apiInstance.UnassignUserFromGroup(groupId, userId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GroupApi.UnassignUserFromGroup: " + e.Message );
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
 **userId** | **string**|  | 

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

