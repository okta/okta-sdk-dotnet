# Okta.Sdk.Api.RoleBTargetBGroupApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AssignAppInstanceTargetToAppAdminRoleForGroup**](RoleBTargetBGroupApi.md#assignappinstancetargettoappadminroleforgroup) | **PUT** /api/v1/groups/{groupId}/roles/{roleAssignmentId}/targets/catalog/apps/{appName}/{appId} | Assign a group role app instance target
[**AssignAppTargetToAdminRoleForGroup**](RoleBTargetBGroupApi.md#assignapptargettoadminroleforgroup) | **PUT** /api/v1/groups/{groupId}/roles/{roleAssignmentId}/targets/catalog/apps/{appName} | Assign a group role app target
[**AssignGroupTargetToGroupAdminRole**](RoleBTargetBGroupApi.md#assigngrouptargettogroupadminrole) | **PUT** /api/v1/groups/{groupId}/roles/{roleAssignmentId}/targets/groups/{targetGroupId} | Assign a group role group target
[**ListApplicationTargetsForApplicationAdministratorRoleForGroup**](RoleBTargetBGroupApi.md#listapplicationtargetsforapplicationadministratorroleforgroup) | **GET** /api/v1/groups/{groupId}/roles/{roleAssignmentId}/targets/catalog/apps | List all group role app targets
[**ListGroupTargetsForGroupRole**](RoleBTargetBGroupApi.md#listgrouptargetsforgrouprole) | **GET** /api/v1/groups/{groupId}/roles/{roleAssignmentId}/targets/groups | List all group role group targets
[**UnassignAppInstanceTargetToAppAdminRoleForGroup**](RoleBTargetBGroupApi.md#unassignappinstancetargettoappadminroleforgroup) | **DELETE** /api/v1/groups/{groupId}/roles/{roleAssignmentId}/targets/catalog/apps/{appName}/{appId} | Unassign a group role app instance target
[**UnassignAppTargetToAdminRoleForGroup**](RoleBTargetBGroupApi.md#unassignapptargettoadminroleforgroup) | **DELETE** /api/v1/groups/{groupId}/roles/{roleAssignmentId}/targets/catalog/apps/{appName} | Unassign a group role app target
[**UnassignGroupTargetFromGroupAdminRole**](RoleBTargetBGroupApi.md#unassigngrouptargetfromgroupadminrole) | **DELETE** /api/v1/groups/{groupId}/roles/{roleAssignmentId}/targets/groups/{targetGroupId} | Unassign a group role group target


<a name="assignappinstancetargettoappadminroleforgroup"></a>
# **AssignAppInstanceTargetToAppAdminRoleForGroup**
> void AssignAppInstanceTargetToAppAdminRoleForGroup (string groupId, string roleAssignmentId, string appName, string appId)

Assign a group role app instance target

Assigns an app instance target to an `APP_ADMIN` role assignment to a group. When you assign the first OIN app or app instance target, you reduce the scope of the role assignment. The role no longer applies to all app targets, but applies only to the specified target.  > **Note:** You can target a mixture of both OIN app and app instance targets, but you can't assign permissions to manage all instances of an OIN app and then assign a subset of permissions to the same app. > For example, you can't specify that an admin has access to manage all instances of the Salesforce app and then also manage specific configurations of the Salesforce app.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AssignAppInstanceTargetToAppAdminRoleForGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleBTargetBGroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment
            var appName = google;  // string | Name of the app definition (the OIN catalog app key name)
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID

            try
            {
                // Assign a group role app instance target
                apiInstance.AssignAppInstanceTargetToAppAdminRoleForGroup(groupId, roleAssignmentId, appName, appId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleBTargetBGroupApi.AssignAppInstanceTargetToAppAdminRoleForGroup: " + e.Message );
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

<a name="assignapptargettoadminroleforgroup"></a>
# **AssignAppTargetToAdminRoleForGroup**
> void AssignAppTargetToAdminRoleForGroup (string groupId, string roleAssignmentId, string appName)

Assign a group role app target

Assigns an OIN app target to an `APP_ADMIN` role assignment to a group. When you assign the first OIN app target, you reduce the scope of the role assignment. The role no longer applies to all app targets, but applies only to the specified target. An OIN app target that's assigned to the role overrides any existing instance targets of the OIN app. For example, if a user is assigned to administer a specific Facebook instance, a successful request to add an OIN app with `facebook` for `appName` makes that user the administrator for all Facebook instances.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AssignAppTargetToAdminRoleForGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleBTargetBGroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment
            var appName = google;  // string | Name of the app definition (the OIN catalog app key name)

            try
            {
                // Assign a group role app target
                apiInstance.AssignAppTargetToAdminRoleForGroup(groupId, roleAssignmentId, appName);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleBTargetBGroupApi.AssignAppTargetToAdminRoleForGroup: " + e.Message );
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
| **200** | Success |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="assigngrouptargettogroupadminrole"></a>
# **AssignGroupTargetToGroupAdminRole**
> void AssignGroupTargetToGroupAdminRole (string groupId, string roleAssignmentId, string targetGroupId)

Assign a group role group target

Assigns a group target to a [`USER_ADMIN`](/openapi/okta-management/guides/roles/#standard-roles), `HELP_DESK_ADMIN`, or `GROUP_MEMBERSHIP_ADMIN` role assignment to a group. When you assign the first group target, you reduce the scope of the role assignment. The role no longer applies to all targets but applies only to the specified target.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AssignGroupTargetToGroupAdminRoleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleBTargetBGroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment
            var targetGroupId = 00g1e9dfjHeLAsdX983d;  // string | 

            try
            {
                // Assign a group role group target
                apiInstance.AssignGroupTargetToGroupAdminRole(groupId, roleAssignmentId, targetGroupId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleBTargetBGroupApi.AssignGroupTargetToGroupAdminRole: " + e.Message );
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
 **targetGroupId** | **string**|  | 

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

<a name="listapplicationtargetsforapplicationadministratorroleforgroup"></a>
# **ListApplicationTargetsForApplicationAdministratorRoleForGroup**
> List&lt;CatalogApplication&gt; ListApplicationTargetsForApplicationAdministratorRoleForGroup (string groupId, string roleAssignmentId, string after = null, int? limit = null)

List all group role app targets

Lists all app targets for an `APP_ADMIN` role assignment to a group. The response includes a list of OIN-cataloged apps or app instances. The response payload for an app instance contains the `id` property, but an OIN-cataloged app doesn't.

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleBTargetBGroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 
            var limit = 20;  // int? | A limit on the number of objects to return (optional)  (default to 20)

            try
            {
                // List all group role app targets
                List<CatalogApplication> result = apiInstance.ListApplicationTargetsForApplicationAdministratorRoleForGroup(groupId, roleAssignmentId, after, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleBTargetBGroupApi.ListApplicationTargetsForApplicationAdministratorRoleForGroup: " + e.Message );
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

<a name="listgrouptargetsforgrouprole"></a>
# **ListGroupTargetsForGroupRole**
> List&lt;Group&gt; ListGroupTargetsForGroupRole (string groupId, string roleAssignmentId, string after = null, int? limit = null)

List all group role group targets

Lists all group targets for a [`USER_ADMIN`](/openapi/okta-management/guides/roles/#standard-roles), `HELP_DESK_ADMIN`, or `GROUP_MEMBERSHIP_ADMIN` role assignment to a group. If the role isn't scoped to specific group targets, Okta returns an empty array `[]`.

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleBTargetBGroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 
            var limit = 20;  // int? | A limit on the number of objects to return (optional)  (default to 20)

            try
            {
                // List all group role group targets
                List<Group> result = apiInstance.ListGroupTargetsForGroupRole(groupId, roleAssignmentId, after, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleBTargetBGroupApi.ListGroupTargetsForGroupRole: " + e.Message );
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

<a name="unassignappinstancetargettoappadminroleforgroup"></a>
# **UnassignAppInstanceTargetToAppAdminRoleForGroup**
> void UnassignAppInstanceTargetToAppAdminRoleForGroup (string groupId, string roleAssignmentId, string appName, string appId)

Unassign a group role app instance target

Unassigns an app instance target from an `APP_ADMIN` role assignment to a group  > **Note:** You can't remove the last app instance target from a role assignment. > If you need a role assignment that applies to all apps, delete the `APP_ADMIN` role assignment with the target and create another one. See [Unassign a group role](/openapi/okta-management/management/tag/RoleAssignmentBGroup/#tag/RoleAssignmentBGroup/operation/unassignRoleFromGroup).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UnassignAppInstanceTargetToAppAdminRoleForGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleBTargetBGroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment
            var appName = google;  // string | Name of the app definition (the OIN catalog app key name)
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID

            try
            {
                // Unassign a group role app instance target
                apiInstance.UnassignAppInstanceTargetToAppAdminRoleForGroup(groupId, roleAssignmentId, appName, appId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleBTargetBGroupApi.UnassignAppInstanceTargetToAppAdminRoleForGroup: " + e.Message );
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

<a name="unassignapptargettoadminroleforgroup"></a>
# **UnassignAppTargetToAdminRoleForGroup**
> void UnassignAppTargetToAdminRoleForGroup (string groupId, string roleAssignmentId, string appName)

Unassign a group role app target

Unassigns an OIN app target from an `APP_ADMIN` role assignment to a group  > **Note:** You can't remove the last app target from a role assignment. > If you need a role assignment that applies to all apps, delete the `APP_ADMIN` role assignment with the target and create another one. See [Unassign a group role](/openapi/okta-management/management/tag/RoleAssignmentBGroup/#tag/RoleAssignmentBGroup/operation/unassignRoleFromGroup). 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UnassignAppTargetToAdminRoleForGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleBTargetBGroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment
            var appName = google;  // string | Name of the app definition (the OIN catalog app key name)

            try
            {
                // Unassign a group role app target
                apiInstance.UnassignAppTargetToAdminRoleForGroup(groupId, roleAssignmentId, appName);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleBTargetBGroupApi.UnassignAppTargetToAdminRoleForGroup: " + e.Message );
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

<a name="unassigngrouptargetfromgroupadminrole"></a>
# **UnassignGroupTargetFromGroupAdminRole**
> void UnassignGroupTargetFromGroupAdminRole (string groupId, string roleAssignmentId, string targetGroupId)

Unassign a group role group target

Unassigns a group target from a [`USER_ADMIN`](/openapi/okta-management/guides/roles/#standard-roles), `HELP_DESK_ADMIN`, or `GROUP_MEMBERSHIP_ADMIN` role assignment to a group.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UnassignGroupTargetFromGroupAdminRoleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleBTargetBGroupApi(config);
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment
            var targetGroupId = 00g1e9dfjHeLAsdX983d;  // string | 

            try
            {
                // Unassign a group role group target
                apiInstance.UnassignGroupTargetFromGroupAdminRole(groupId, roleAssignmentId, targetGroupId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleBTargetBGroupApi.UnassignGroupTargetFromGroupAdminRole: " + e.Message );
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
 **targetGroupId** | **string**|  | 

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

