# Okta.Sdk.Api.RoleAssignmentAUserApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AssignRoleToUser**](RoleAssignmentAUserApi.md#assignroletouser) | **POST** /api/v1/users/{userId}/roles | Assign a user role
[**GetRoleAssignmentGovernanceGrant**](RoleAssignmentAUserApi.md#getroleassignmentgovernancegrant) | **GET** /api/v1/users/{userId}/roles/{roleAssignmentId}/governance/{grantId} | Retrieve a user role governance source
[**GetRoleAssignmentGovernanceGrantResources**](RoleAssignmentAUserApi.md#getroleassignmentgovernancegrantresources) | **GET** /api/v1/users/{userId}/roles/{roleAssignmentId}/governance/{grantId}/resources | Retrieve the user role governance source resources
[**GetUserAssignedRole**](RoleAssignmentAUserApi.md#getuserassignedrole) | **GET** /api/v1/users/{userId}/roles/{roleAssignmentId} | Retrieve a user role assignment
[**GetUserAssignedRoleGovernance**](RoleAssignmentAUserApi.md#getuserassignedrolegovernance) | **GET** /api/v1/users/{userId}/roles/{roleAssignmentId}/governance | Retrieve all user role governance sources
[**ListAssignedRolesForUser**](RoleAssignmentAUserApi.md#listassignedrolesforuser) | **GET** /api/v1/users/{userId}/roles | List all user role assignments
[**ListUsersWithRoleAssignments**](RoleAssignmentAUserApi.md#listuserswithroleassignments) | **GET** /api/v1/iam/assignees/users | List all users with role assignments
[**UnassignRoleFromUser**](RoleAssignmentAUserApi.md#unassignrolefromuser) | **DELETE** /api/v1/users/{userId}/roles/{roleAssignmentId} | Unassign a user role


<a name="assignroletouser"></a>
# **AssignRoleToUser**
> AssignRoleToUser201Response AssignRoleToUser (string userId, AssignRoleToUserRequest assignRoleRequest, bool? disableNotifications = null)

Assign a user role

Assigns a [standard role](/openapi/okta-management/guides/roles/#standard-roles) to a user.  You can also assign a custom role to a user, but the preferred method to assign a custom role to a user is to create a binding between the custom role, the resource set, and the user. See [Create a role resource set binding](/openapi/okta-management/management/tag/RoleDResourceSetBinding/#tag/RoleDResourceSetBinding/operation/createResourceSetBinding).  > **Notes:** > * The request payload is different for standard and custom role assignments. > * For IAM-based standard role assignments, use the request payload for standard roles. However, the response payload for IAM-based role assignments is similar to the custom role's assignment response.

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

            var apiInstance = new RoleAssignmentAUserApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var assignRoleRequest = new AssignRoleToUserRequest(); // AssignRoleToUserRequest | 
            var disableNotifications = false;  // bool? | Setting this to `true` grants the user third-party admin status (optional)  (default to false)

            try
            {
                // Assign a user role
                AssignRoleToUser201Response result = apiInstance.AssignRoleToUser(userId, assignRoleRequest, disableNotifications);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentAUserApi.AssignRoleToUser: " + e.Message );
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
 **assignRoleRequest** | [**AssignRoleToUserRequest**](AssignRoleToUserRequest.md)|  | 
 **disableNotifications** | **bool?**| Setting this to &#x60;true&#x60; grants the user third-party admin status | [optional] [default to false]

### Return type

[**AssignRoleToUser201Response**](AssignRoleToUser201Response.md)

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

<a name="getroleassignmentgovernancegrant"></a>
# **GetRoleAssignmentGovernanceGrant**
> RoleGovernanceSource GetRoleAssignmentGovernanceGrant (string userId, string roleAssignmentId, string grantId)

Retrieve a user role governance source

Retrieves a governance source (identified by `grantId`) for a role (identified by `roleAssignmentId`) that's assigned to a user (identified by `userId`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetRoleAssignmentGovernanceGrantExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleAssignmentAUserApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment
            var grantId = iJoqkwx50mrgX4T9LcaH;  // string | Grant ID

            try
            {
                // Retrieve a user role governance source
                RoleGovernanceSource result = apiInstance.GetRoleAssignmentGovernanceGrant(userId, roleAssignmentId, grantId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentAUserApi.GetRoleAssignmentGovernanceGrant: " + e.Message );
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
 **roleAssignmentId** | **string**| The &#x60;id&#x60; of the role assignment | 
 **grantId** | **string**| Grant ID | 

### Return type

[**RoleGovernanceSource**](RoleGovernanceSource.md)

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

<a name="getroleassignmentgovernancegrantresources"></a>
# **GetRoleAssignmentGovernanceGrantResources**
> RoleGovernanceResources GetRoleAssignmentGovernanceGrantResources (string userId, string roleAssignmentId, string grantId)

Retrieve the user role governance source resources

Retrieves the resources of a governance source (identified by `grantId`) for a role (identified by `roleAssignmentId`) that's assigned to a user (identified by `userId`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetRoleAssignmentGovernanceGrantResourcesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleAssignmentAUserApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment
            var grantId = iJoqkwx50mrgX4T9LcaH;  // string | Grant ID

            try
            {
                // Retrieve the user role governance source resources
                RoleGovernanceResources result = apiInstance.GetRoleAssignmentGovernanceGrantResources(userId, roleAssignmentId, grantId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentAUserApi.GetRoleAssignmentGovernanceGrantResources: " + e.Message );
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
 **roleAssignmentId** | **string**| The &#x60;id&#x60; of the role assignment | 
 **grantId** | **string**| Grant ID | 

### Return type

[**RoleGovernanceResources**](RoleGovernanceResources.md)

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
> ListGroupAssignedRoles200ResponseInner GetUserAssignedRole (string userId, string roleAssignmentId)

Retrieve a user role assignment

Retrieves a role assigned to a user (identified by `userId`). The `roleAssignmentId` parameter is the unique identifier for either a standard role assignment object or a custom role resource set binding object.

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

            var apiInstance = new RoleAssignmentAUserApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment

            try
            {
                // Retrieve a user role assignment
                ListGroupAssignedRoles200ResponseInner result = apiInstance.GetUserAssignedRole(userId, roleAssignmentId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentAUserApi.GetUserAssignedRole: " + e.Message );
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

<a name="getuserassignedrolegovernance"></a>
# **GetUserAssignedRoleGovernance**
> RoleGovernance GetUserAssignedRoleGovernance (string userId, string roleAssignmentId)

Retrieve all user role governance sources

Retrieves the governance sources of a role (identified by `roleAssignmentId`) that's assigned to a user (identified by `userId`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetUserAssignedRoleGovernanceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleAssignmentAUserApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment

            try
            {
                // Retrieve all user role governance sources
                RoleGovernance result = apiInstance.GetUserAssignedRoleGovernance(userId, roleAssignmentId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentAUserApi.GetUserAssignedRoleGovernance: " + e.Message );
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
 **roleAssignmentId** | **string**| The &#x60;id&#x60; of the role assignment | 

### Return type

[**RoleGovernance**](RoleGovernance.md)

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
> List&lt;ListGroupAssignedRoles200ResponseInner&gt; ListAssignedRolesForUser (string userId, string expand = null)

List all user role assignments

Lists all roles assigned to a user (identified by `userId`)

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

            var apiInstance = new RoleAssignmentAUserApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var expand = targets/groups;  // string | An optional parameter used to return targets configured for the standard role assignment in the `embedded` property. Supported values: `targets/groups` or `targets/catalog/apps` (optional) 

            try
            {
                // List all user role assignments
                List<ListGroupAssignedRoles200ResponseInner> result = apiInstance.ListAssignedRolesForUser(userId, expand).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentAUserApi.ListAssignedRolesForUser: " + e.Message );
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

<a name="listuserswithroleassignments"></a>
# **ListUsersWithRoleAssignments**
> RoleAssignedUsers ListUsersWithRoleAssignments (string after = null, int? limit = null)

List all users with role assignments

Lists all users with role assignments

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

            var apiInstance = new RoleAssignmentAUserApi(config);
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of targets (optional) 
            var limit = 100;  // int? | Specifies the number of results returned. Defaults to `100`. (optional)  (default to 100)

            try
            {
                // List all users with role assignments
                RoleAssignedUsers result = apiInstance.ListUsersWithRoleAssignments(after, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentAUserApi.ListUsersWithRoleAssignments: " + e.Message );
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
 **after** | **string**| Specifies the pagination cursor for the next page of targets | [optional] 
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

<a name="unassignrolefromuser"></a>
# **UnassignRoleFromUser**
> void UnassignRoleFromUser (string userId, string roleAssignmentId)

Unassign a user role

Unassigns a role assignment (identified by `roleAssignmentId`) from a user (identified by `userId`)

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

            var apiInstance = new RoleAssignmentAUserApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment

            try
            {
                // Unassign a user role
                apiInstance.UnassignRoleFromUser(userId, roleAssignmentId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentAUserApi.UnassignRoleFromUser: " + e.Message );
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

