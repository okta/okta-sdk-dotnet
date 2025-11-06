# Okta.Sdk.Api.RoleBTargetAdminApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AssignAllAppsAsTargetToRoleForUser**](RoleBTargetAdminApi.md#assignallappsastargettoroleforuser) | **PUT** /api/v1/users/{userId}/roles/{roleAssignmentId}/targets/catalog/apps | Assign all apps as target to admin role
[**AssignAppInstanceTargetToAppAdminRoleForUser**](RoleBTargetAdminApi.md#assignappinstancetargettoappadminroleforuser) | **PUT** /api/v1/users/{userId}/roles/{roleAssignmentId}/targets/catalog/apps/{appName}/{appId} | Assign an admin role app instance target
[**AssignAppTargetToAdminRoleForUser**](RoleBTargetAdminApi.md#assignapptargettoadminroleforuser) | **PUT** /api/v1/users/{userId}/roles/{roleAssignmentId}/targets/catalog/apps/{appName} | Assign an admin role app target
[**AssignGroupTargetToUserRole**](RoleBTargetAdminApi.md#assigngrouptargettouserrole) | **PUT** /api/v1/users/{userId}/roles/{roleAssignmentId}/targets/groups/{groupId} | Assign an admin role group target
[**GetRoleTargetsByUserIdAndRoleId**](RoleBTargetAdminApi.md#getroletargetsbyuseridandroleid) | **GET** /api/v1/users/{userId}/roles/{roleIdOrEncodedRoleId}/targets | Retrieve a role target by assignment type
[**ListApplicationTargetsForApplicationAdministratorRoleForUser**](RoleBTargetAdminApi.md#listapplicationtargetsforapplicationadministratorroleforuser) | **GET** /api/v1/users/{userId}/roles/{roleAssignmentId}/targets/catalog/apps | List all admin role app targets
[**ListGroupTargetsForRole**](RoleBTargetAdminApi.md#listgrouptargetsforrole) | **GET** /api/v1/users/{userId}/roles/{roleAssignmentId}/targets/groups | List all admin role group targets
[**UnassignAppInstanceTargetFromAdminRoleForUser**](RoleBTargetAdminApi.md#unassignappinstancetargetfromadminroleforuser) | **DELETE** /api/v1/users/{userId}/roles/{roleAssignmentId}/targets/catalog/apps/{appName}/{appId} | Unassign an admin role app instance target
[**UnassignAppTargetFromAppAdminRoleForUser**](RoleBTargetAdminApi.md#unassignapptargetfromappadminroleforuser) | **DELETE** /api/v1/users/{userId}/roles/{roleAssignmentId}/targets/catalog/apps/{appName} | Unassign an admin role app target
[**UnassignGroupTargetFromUserAdminRole**](RoleBTargetAdminApi.md#unassigngrouptargetfromuseradminrole) | **DELETE** /api/v1/users/{userId}/roles/{roleAssignmentId}/targets/groups/{groupId} | Unassign an admin role group target


<a name="assignallappsastargettoroleforuser"></a>
# **AssignAllAppsAsTargetToRoleForUser**
> void AssignAllAppsAsTargetToRoleForUser (string userId, string roleAssignmentId)

Assign all apps as target to admin role

Assigns all apps as target to an `APP_ADMIN` role

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AssignAllAppsAsTargetToRoleForUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleBTargetAdminApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment

            try
            {
                // Assign all apps as target to admin role
                apiInstance.AssignAllAppsAsTargetToRoleForUser(userId, roleAssignmentId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleBTargetAdminApi.AssignAllAppsAsTargetToRoleForUser: " + e.Message );
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
| **200** | Success |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="assignappinstancetargettoappadminroleforuser"></a>
# **AssignAppInstanceTargetToAppAdminRoleForUser**
> void AssignAppInstanceTargetToAppAdminRoleForUser (string userId, string roleAssignmentId, string appName, string appId)

Assign an admin role app instance target

Assigns an app instance target to an `APP_ADMIN` role assignment to an admin user. When you assign the first OIN app or app instance target, you reduce the scope of the role assignment. The role no longer applies to all app targets, but applies only to the specified target.  > **Note:** You can target a mixture of both OIN app and app instance targets, but can't assign permissions to manage all instances of an OIN app and then assign a subset of permission to the same OIN app. > For example, you can't specify that an admin has access to manage all instances of the Salesforce app and then also manage specific configurations of the Salesforce app. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AssignAppInstanceTargetToAppAdminRoleForUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleBTargetAdminApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment
            var appName = google;  // string | Name of the app definition (the OIN catalog app key name)
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID

            try
            {
                // Assign an admin role app instance target
                apiInstance.AssignAppInstanceTargetToAppAdminRoleForUser(userId, roleAssignmentId, appName, appId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleBTargetAdminApi.AssignAppInstanceTargetToAppAdminRoleForUser: " + e.Message );
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
 **appName** | **string**| Name of the app definition (the OIN catalog app key name) | 
 **appId** | **string**| Application ID | 

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

<a name="assignapptargettoadminroleforuser"></a>
# **AssignAppTargetToAdminRoleForUser**
> void AssignAppTargetToAdminRoleForUser (string userId, string roleAssignmentId, string appName)

Assign an admin role app target

Assigns an OIN app target for an `APP_ADMIN` role assignment to an admin user. When you assign the first app target, you reduce the scope of the role assignment. The role no longer applies to all app targets, but applies only to the specified target.  Assigning an OIN app target overrides any existing app instance targets of the OIN app. For example, if a user was assigned to administer a specific Facebook instance, a successful request to add an OIN app target with `facebook` for `appName` makes that user the admin for all Facebook instances. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AssignAppTargetToAdminRoleForUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleBTargetAdminApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment
            var appName = google;  // string | Name of the app definition (the OIN catalog app key name)

            try
            {
                // Assign an admin role app target
                apiInstance.AssignAppTargetToAdminRoleForUser(userId, roleAssignmentId, appName);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleBTargetAdminApi.AssignAppTargetToAdminRoleForUser: " + e.Message );
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
 **appName** | **string**| Name of the app definition (the OIN catalog app key name) | 

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

<a name="assigngrouptargettouserrole"></a>
# **AssignGroupTargetToUserRole**
> void AssignGroupTargetToUserRole (string userId, string roleAssignmentId, string groupId)

Assign an admin role group target

Assigns a group target for a `USER_ADMIN`, `HELP_DESK_ADMIN`, or `GROUP_MEMBERSHIP_ADMIN` role assignment to an admin user. When you assign the first group target, you reduce the scope of the role assignment. The role no longer applies to all targets but applies only to the specified target. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AssignGroupTargetToUserRoleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleBTargetAdminApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group

            try
            {
                // Assign an admin role group target
                apiInstance.AssignGroupTargetToUserRole(userId, roleAssignmentId, groupId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleBTargetAdminApi.AssignGroupTargetToUserRole: " + e.Message );
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

<a name="getroletargetsbyuseridandroleid"></a>
# **GetRoleTargetsByUserIdAndRoleId**
> List&lt;RoleTarget&gt; GetRoleTargetsByUserIdAndRoleId (string userId, string roleIdOrEncodedRoleId, AssignmentTypeParameter? assignmentType = null, string after = null, int? limit = null)

Retrieve a role target by assignment type

Retrieves all role targets for an `APP_ADMIN`, `USER_ADMIN`, `HELP_DESK_ADMIN`, or `GROUP_MEMBERSHIP_ADMIN` role assignment to an admin user by user or group assignment type. If the role isn't scoped to specific group targets or any app targets, an empty array `[]` is returned. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetRoleTargetsByUserIdAndRoleIdExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleBTargetAdminApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var roleIdOrEncodedRoleId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role or Base32 encoded `id` of the role name
            var assignmentType = (AssignmentTypeParameter) "USER";  // AssignmentTypeParameter? | Specifies the assignment type of the user (optional) 
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 
            var limit = 20;  // int? | A limit on the number of objects to return (optional)  (default to 20)

            try
            {
                // Retrieve a role target by assignment type
                List<RoleTarget> result = apiInstance.GetRoleTargetsByUserIdAndRoleId(userId, roleIdOrEncodedRoleId, assignmentType, after, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleBTargetAdminApi.GetRoleTargetsByUserIdAndRoleId: " + e.Message );
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
 **roleIdOrEncodedRoleId** | **string**| The &#x60;id&#x60; of the role or Base32 encoded &#x60;id&#x60; of the role name | 
 **assignmentType** | **AssignmentTypeParameter?**| Specifies the assignment type of the user | [optional] 
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 
 **limit** | **int?**| A limit on the number of objects to return | [optional] [default to 20]

### Return type

[**List&lt;RoleTarget&gt;**](RoleTarget.md)

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

<a name="listapplicationtargetsforapplicationadministratorroleforuser"></a>
# **ListApplicationTargetsForApplicationAdministratorRoleForUser**
> List&lt;CatalogApplication&gt; ListApplicationTargetsForApplicationAdministratorRoleForUser (string userId, string roleAssignmentId, string after = null, int? limit = null)

List all admin role app targets

Lists all app targets for an `APP_ADMIN` role assigned to a user. The response is a list that includes OIN-cataloged apps or app instances. The response payload for an app instance contains the `id` property, but an OIN-cataloged app payload doesn't.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListApplicationTargetsForApplicationAdministratorRoleForUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleBTargetAdminApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 
            var limit = 20;  // int? | A limit on the number of objects to return (optional)  (default to 20)

            try
            {
                // List all admin role app targets
                List<CatalogApplication> result = apiInstance.ListApplicationTargetsForApplicationAdministratorRoleForUser(userId, roleAssignmentId, after, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleBTargetAdminApi.ListApplicationTargetsForApplicationAdministratorRoleForUser: " + e.Message );
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
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 
 **limit** | **int?**| A limit on the number of objects to return | [optional] [default to 20]

### Return type

[**List&lt;CatalogApplication&gt;**](CatalogApplication.md)

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

<a name="listgrouptargetsforrole"></a>
# **ListGroupTargetsForRole**
> List&lt;Group&gt; ListGroupTargetsForRole (string userId, string roleAssignmentId, string after = null, int? limit = null)

List all admin role group targets

Lists all group targets for a `USER_ADMIN`, `HELP_DESK_ADMIN`, or `GROUP_MEMBERSHIP_ADMIN` role assignment to an admin user. If the role isn't scoped to specific group targets, an empty array `[]` is returned. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListGroupTargetsForRoleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleBTargetAdminApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 
            var limit = 20;  // int? | A limit on the number of objects to return (optional)  (default to 20)

            try
            {
                // List all admin role group targets
                List<Group> result = apiInstance.ListGroupTargetsForRole(userId, roleAssignmentId, after, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleBTargetAdminApi.ListGroupTargetsForRole: " + e.Message );
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
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 
 **limit** | **int?**| A limit on the number of objects to return | [optional] [default to 20]

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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="unassignappinstancetargetfromadminroleforuser"></a>
# **UnassignAppInstanceTargetFromAdminRoleForUser**
> void UnassignAppInstanceTargetFromAdminRoleForUser (string userId, string roleAssignmentId, string appName, string appId)

Unassign an admin role app instance target

Unassigns an app instance target from an `APP_ADMIN` role assignment to an admin user.  > **Note:** You can't remove the last app instance target from a role assignment since this causes an exception. > If you need a role assignment that applies to all apps, delete the `APP_ADMIN` role assignment and recreate a new one.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UnassignAppInstanceTargetFromAdminRoleForUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleBTargetAdminApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment
            var appName = google;  // string | Name of the app definition (the OIN catalog app key name)
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID

            try
            {
                // Unassign an admin role app instance target
                apiInstance.UnassignAppInstanceTargetFromAdminRoleForUser(userId, roleAssignmentId, appName, appId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleBTargetAdminApi.UnassignAppInstanceTargetFromAdminRoleForUser: " + e.Message );
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
 **appName** | **string**| Name of the app definition (the OIN catalog app key name) | 
 **appId** | **string**| Application ID | 

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

<a name="unassignapptargetfromappadminroleforuser"></a>
# **UnassignAppTargetFromAppAdminRoleForUser**
> void UnassignAppTargetFromAppAdminRoleForUser (string userId, string roleAssignmentId, string appName)

Unassign an admin role app target

Unassigns an OIN app target from an `APP_ADMIN` role assignment to an admin user.  > **Note:** You can't remove the last OIN app target from a role assignment since this causes an exception. > If you need a role assignment that applies to all apps, delete the `APP_ADMIN` role assignment to the user and recreate a new one. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UnassignAppTargetFromAppAdminRoleForUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleBTargetAdminApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment
            var appName = google;  // string | Name of the app definition (the OIN catalog app key name)

            try
            {
                // Unassign an admin role app target
                apiInstance.UnassignAppTargetFromAppAdminRoleForUser(userId, roleAssignmentId, appName);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleBTargetAdminApi.UnassignAppTargetFromAppAdminRoleForUser: " + e.Message );
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
 **appName** | **string**| Name of the app definition (the OIN catalog app key name) | 

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

<a name="unassigngrouptargetfromuseradminrole"></a>
# **UnassignGroupTargetFromUserAdminRole**
> void UnassignGroupTargetFromUserAdminRole (string userId, string roleAssignmentId, string groupId)

Unassign an admin role group target

Unassigns a group target from a `USER_ADMIN`, `HELP_DESK_ADMIN`, or `GROUP_MEMBERSHIP_ADMIN` role assignment to an admin user.  > **Note:** You can't remove the last group target from a role assignment since this causes an exception. > If you need a role assignment that applies to all groups, delete the role assignment to the user and recreate a new one. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UnassignGroupTargetFromUserAdminRoleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleBTargetAdminApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group

            try
            {
                // Unassign an admin role group target
                apiInstance.UnassignGroupTargetFromUserAdminRole(userId, roleAssignmentId, groupId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleBTargetAdminApi.UnassignGroupTargetFromUserAdminRole: " + e.Message );
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

