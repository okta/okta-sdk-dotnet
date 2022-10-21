# Okta.Sdk.Api.RoleTargetApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AddAllAppsAsTargetToRole**](RoleTargetApi.md#addallappsastargettorole) | **PUT** /api/v1/users/{userId}/roles/{roleId}/targets/catalog/apps | Assign all Apps as Target to Role
[**AddApplicationInstanceTargetToAppAdminRoleGivenToGroup**](RoleTargetApi.md#addapplicationinstancetargettoappadminrolegiventogroup) | **PUT** /api/v1/groups/{groupId}/roles/{roleId}/targets/catalog/apps/{appName}/{applicationId} | Assign an Application Instance Target to Application Administrator Role
[**AddApplicationTargetToAdminRoleForUser**](RoleTargetApi.md#addapplicationtargettoadminroleforuser) | **PUT** /api/v1/users/{userId}/roles/{roleId}/targets/catalog/apps/{appName} | Assign an Application Target to Administrator Role
[**AddApplicationTargetToAdminRoleGivenToGroup**](RoleTargetApi.md#addapplicationtargettoadminrolegiventogroup) | **PUT** /api/v1/groups/{groupId}/roles/{roleId}/targets/catalog/apps/{appName} | Assign an Application Target to Administrator Role
[**AddApplicationTargetToAppAdminRoleForUser**](RoleTargetApi.md#addapplicationtargettoappadminroleforuser) | **PUT** /api/v1/users/{userId}/roles/{roleId}/targets/catalog/apps/{appName}/{applicationId} | Assign an Application Instance Target to an Application Administrator Role
[**AddGroupTargetToGroupAdministratorRoleForGroup**](RoleTargetApi.md#addgrouptargettogroupadministratorroleforgroup) | **PUT** /api/v1/groups/{groupId}/roles/{roleId}/targets/groups/{targetGroupId} | Assign a Group Target for Group Role
[**AddGroupTargetToRole**](RoleTargetApi.md#addgrouptargettorole) | **PUT** /api/v1/users/{userId}/roles/{roleId}/targets/groups/{groupId} | Assign a Group Target to Role
[**ListApplicationTargetsForApplicationAdministratorRoleForGroup**](RoleTargetApi.md#listapplicationtargetsforapplicationadministratorroleforgroup) | **GET** /api/v1/groups/{groupId}/roles/{roleId}/targets/catalog/apps | List all Application Targets for an Application Administrator Role
[**ListApplicationTargetsForApplicationAdministratorRoleForUser**](RoleTargetApi.md#listapplicationtargetsforapplicationadministratorroleforuser) | **GET** /api/v1/users/{userId}/roles/{roleId}/targets/catalog/apps | List all Application Targets for Application Administrator Role
[**ListGroupTargetsForGroupRole**](RoleTargetApi.md#listgrouptargetsforgrouprole) | **GET** /api/v1/groups/{groupId}/roles/{roleId}/targets/groups | List all Group Targets for a Group Role
[**ListGroupTargetsForRole**](RoleTargetApi.md#listgrouptargetsforrole) | **GET** /api/v1/users/{userId}/roles/{roleId}/targets/groups | List all Group Targets for Role
[**RemoveApplicationTargetFromAdministratorRoleForUser**](RoleTargetApi.md#removeapplicationtargetfromadministratorroleforuser) | **DELETE** /api/v1/users/{userId}/roles/{roleId}/targets/catalog/apps/{appName}/{applicationId} | Unassign an Application Instance Target to Application Administrator Role
[**RemoveApplicationTargetFromAdministratorRoleGivenToGroup**](RoleTargetApi.md#removeapplicationtargetfromadministratorrolegiventogroup) | **DELETE** /api/v1/groups/{groupId}/roles/{roleId}/targets/catalog/apps/{appName}/{applicationId} | Delete an Application Instance Target to Application Administrator Role
[**RemoveApplicationTargetFromApplicationAdministratorRoleForUser**](RoleTargetApi.md#removeapplicationtargetfromapplicationadministratorroleforuser) | **DELETE** /api/v1/users/{userId}/roles/{roleId}/targets/catalog/apps/{appName} | Unassign an Application Target from Application Administrator Role
[**RemoveApplicationTargetFromApplicationAdministratorRoleGivenToGroup**](RoleTargetApi.md#removeapplicationtargetfromapplicationadministratorrolegiventogroup) | **DELETE** /api/v1/groups/{groupId}/roles/{roleId}/targets/catalog/apps/{appName} | Delete an Application Target from Application Administrator Role
[**RemoveGroupTargetFromGroupAdministratorRoleGivenToGroup**](RoleTargetApi.md#removegrouptargetfromgroupadministratorrolegiventogroup) | **DELETE** /api/v1/groups/{groupId}/roles/{roleId}/targets/groups/{targetGroupId} | Delete a Group Target for Group Role
[**RemoveGroupTargetFromRole**](RoleTargetApi.md#removegrouptargetfromrole) | **DELETE** /api/v1/users/{userId}/roles/{roleId}/targets/groups/{groupId} | Unassign a Group Target from Role


<a name="addallappsastargettorole"></a>
# **AddAllAppsAsTargetToRole**
> void AddAllAppsAsTargetToRole (string userId, string roleId)

Assign all Apps as Target to Role

Assign all Apps as Target to Role

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AddAllAppsAsTargetToRoleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleTargetApi(config);
            var userId = "userId_example";  // string | 
            var roleId = "roleId_example";  // string | 

            try
            {
                // Assign all Apps as Target to Role
                apiInstance.AddAllAppsAsTargetToRole(userId, roleId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleTargetApi.AddAllAppsAsTargetToRole: " + e.Message );
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
 **roleId** | **string**|  | 

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

<a name="addapplicationinstancetargettoappadminrolegiventogroup"></a>
# **AddApplicationInstanceTargetToAppAdminRoleGivenToGroup**
> void AddApplicationInstanceTargetToAppAdminRoleGivenToGroup (string groupId, string roleId, string appName, string applicationId)

Assign an Application Instance Target to Application Administrator Role

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleTargetApi(config);
            var groupId = "groupId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var appName = "appName_example";  // string | 
            var applicationId = "applicationId_example";  // string | 

            try
            {
                // Assign an Application Instance Target to Application Administrator Role
                apiInstance.AddApplicationInstanceTargetToAppAdminRoleGivenToGroup(groupId, roleId, appName, applicationId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleTargetApi.AddApplicationInstanceTargetToAppAdminRoleGivenToGroup: " + e.Message );
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

<a name="addapplicationtargettoadminroleforuser"></a>
# **AddApplicationTargetToAdminRoleForUser**
> void AddApplicationTargetToAdminRoleForUser (string userId, string roleId, string appName)

Assign an Application Target to Administrator Role

Assign an application target to administrator role

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AddApplicationTargetToAdminRoleForUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleTargetApi(config);
            var userId = "userId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var appName = "appName_example";  // string | 

            try
            {
                // Assign an Application Target to Administrator Role
                apiInstance.AddApplicationTargetToAdminRoleForUser(userId, roleId, appName);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleTargetApi.AddApplicationTargetToAdminRoleForUser: " + e.Message );
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
 **roleId** | **string**|  | 
 **appName** | **string**|  | 

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

<a name="addapplicationtargettoadminrolegiventogroup"></a>
# **AddApplicationTargetToAdminRoleGivenToGroup**
> void AddApplicationTargetToAdminRoleGivenToGroup (string groupId, string roleId, string appName)

Assign an Application Target to Administrator Role

Assign an application target to administrator role

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleTargetApi(config);
            var groupId = "groupId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var appName = "appName_example";  // string | 

            try
            {
                // Assign an Application Target to Administrator Role
                apiInstance.AddApplicationTargetToAdminRoleGivenToGroup(groupId, roleId, appName);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleTargetApi.AddApplicationTargetToAdminRoleGivenToGroup: " + e.Message );
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

<a name="addapplicationtargettoappadminroleforuser"></a>
# **AddApplicationTargetToAppAdminRoleForUser**
> void AddApplicationTargetToAppAdminRoleForUser (string userId, string roleId, string appName, string applicationId)

Assign an Application Instance Target to an Application Administrator Role

Add App Instance Target to App Administrator Role given to a User

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AddApplicationTargetToAppAdminRoleForUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleTargetApi(config);
            var userId = "userId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var appName = "appName_example";  // string | 
            var applicationId = "applicationId_example";  // string | 

            try
            {
                // Assign an Application Instance Target to an Application Administrator Role
                apiInstance.AddApplicationTargetToAppAdminRoleForUser(userId, roleId, appName, applicationId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleTargetApi.AddApplicationTargetToAppAdminRoleForUser: " + e.Message );
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
 **roleId** | **string**|  | 
 **appName** | **string**|  | 
 **applicationId** | **string**|  | 

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

<a name="addgrouptargettogroupadministratorroleforgroup"></a>
# **AddGroupTargetToGroupAdministratorRoleForGroup**
> void AddGroupTargetToGroupAdministratorRoleForGroup (string groupId, string roleId, string targetGroupId)

Assign a Group Target for Group Role

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleTargetApi(config);
            var groupId = "groupId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var targetGroupId = "targetGroupId_example";  // string | 

            try
            {
                // Assign a Group Target for Group Role
                apiInstance.AddGroupTargetToGroupAdministratorRoleForGroup(groupId, roleId, targetGroupId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleTargetApi.AddGroupTargetToGroupAdministratorRoleForGroup: " + e.Message );
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

<a name="addgrouptargettorole"></a>
# **AddGroupTargetToRole**
> void AddGroupTargetToRole (string userId, string roleId, string groupId)

Assign a Group Target to Role

Assign a Group Target to Role

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AddGroupTargetToRoleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleTargetApi(config);
            var userId = "userId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var groupId = "groupId_example";  // string | 

            try
            {
                // Assign a Group Target to Role
                apiInstance.AddGroupTargetToRole(userId, roleId, groupId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleTargetApi.AddGroupTargetToRole: " + e.Message );
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
 **roleId** | **string**|  | 
 **groupId** | **string**|  | 

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
> List&lt;CatalogApplication&gt; ListApplicationTargetsForApplicationAdministratorRoleForGroup (string groupId, string roleId, string after = null, int? limit = null)

List all Application Targets for an Application Administrator Role

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleTargetApi(config);
            var groupId = "groupId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var after = "after_example";  // string |  (optional) 
            var limit = 20;  // int? |  (optional)  (default to 20)

            try
            {
                // List all Application Targets for an Application Administrator Role
                List<CatalogApplication> result = apiInstance.ListApplicationTargetsForApplicationAdministratorRoleForGroup(groupId, roleId, after, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleTargetApi.ListApplicationTargetsForApplicationAdministratorRoleForGroup: " + e.Message );
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
> List&lt;CatalogApplication&gt; ListApplicationTargetsForApplicationAdministratorRoleForUser (string userId, string roleId, string after = null, int? limit = null)

List all Application Targets for Application Administrator Role

Lists all App targets for an `APP_ADMIN` Role assigned to a User. This methods return list may include full Applications or Instances. The response for an instance will have an `ID` value, while Application will not have an ID.

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

            var apiInstance = new RoleTargetApi(config);
            var userId = "userId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var after = "after_example";  // string |  (optional) 
            var limit = 20;  // int? |  (optional)  (default to 20)

            try
            {
                // List all Application Targets for Application Administrator Role
                List<CatalogApplication> result = apiInstance.ListApplicationTargetsForApplicationAdministratorRoleForUser(userId, roleId, after, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleTargetApi.ListApplicationTargetsForApplicationAdministratorRoleForUser: " + e.Message );
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
 **roleId** | **string**|  | 
 **after** | **string**|  | [optional] 
 **limit** | **int?**|  | [optional] [default to 20]

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
> List&lt;Group&gt; ListGroupTargetsForGroupRole (string groupId, string roleId, string after = null, int? limit = null)

List all Group Targets for a Group Role

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleTargetApi(config);
            var groupId = "groupId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var after = "after_example";  // string |  (optional) 
            var limit = 20;  // int? |  (optional)  (default to 20)

            try
            {
                // List all Group Targets for a Group Role
                List<Group> result = apiInstance.ListGroupTargetsForGroupRole(groupId, roleId, after, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleTargetApi.ListGroupTargetsForGroupRole: " + e.Message );
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
> List&lt;Group&gt; ListGroupTargetsForRole (string userId, string roleId, string after = null, int? limit = null)

List all Group Targets for Role

List all group targets for role

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

            var apiInstance = new RoleTargetApi(config);
            var userId = "userId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var after = "after_example";  // string |  (optional) 
            var limit = 20;  // int? |  (optional)  (default to 20)

            try
            {
                // List all Group Targets for Role
                List<Group> result = apiInstance.ListGroupTargetsForRole(userId, roleId, after, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleTargetApi.ListGroupTargetsForRole: " + e.Message );
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
 **roleId** | **string**|  | 
 **after** | **string**|  | [optional] 
 **limit** | **int?**|  | [optional] [default to 20]

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

<a name="removeapplicationtargetfromadministratorroleforuser"></a>
# **RemoveApplicationTargetFromAdministratorRoleForUser**
> void RemoveApplicationTargetFromAdministratorRoleForUser (string userId, string roleId, string appName, string applicationId)

Unassign an Application Instance Target to Application Administrator Role

Remove App Instance Target to App Administrator Role given to a User

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RemoveApplicationTargetFromAdministratorRoleForUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleTargetApi(config);
            var userId = "userId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var appName = "appName_example";  // string | 
            var applicationId = "applicationId_example";  // string | 

            try
            {
                // Unassign an Application Instance Target to Application Administrator Role
                apiInstance.RemoveApplicationTargetFromAdministratorRoleForUser(userId, roleId, appName, applicationId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleTargetApi.RemoveApplicationTargetFromAdministratorRoleForUser: " + e.Message );
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
 **roleId** | **string**|  | 
 **appName** | **string**|  | 
 **applicationId** | **string**|  | 

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

<a name="removeapplicationtargetfromadministratorrolegiventogroup"></a>
# **RemoveApplicationTargetFromAdministratorRoleGivenToGroup**
> void RemoveApplicationTargetFromAdministratorRoleGivenToGroup (string groupId, string roleId, string appName, string applicationId)

Delete an Application Instance Target to Application Administrator Role

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleTargetApi(config);
            var groupId = "groupId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var appName = "appName_example";  // string | 
            var applicationId = "applicationId_example";  // string | 

            try
            {
                // Delete an Application Instance Target to Application Administrator Role
                apiInstance.RemoveApplicationTargetFromAdministratorRoleGivenToGroup(groupId, roleId, appName, applicationId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleTargetApi.RemoveApplicationTargetFromAdministratorRoleGivenToGroup: " + e.Message );
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

<a name="removeapplicationtargetfromapplicationadministratorroleforuser"></a>
# **RemoveApplicationTargetFromApplicationAdministratorRoleForUser**
> void RemoveApplicationTargetFromApplicationAdministratorRoleForUser (string userId, string roleId, string appName)

Unassign an Application Target from Application Administrator Role

Unassign an application target from application administrator role

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RemoveApplicationTargetFromApplicationAdministratorRoleForUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleTargetApi(config);
            var userId = "userId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var appName = "appName_example";  // string | 

            try
            {
                // Unassign an Application Target from Application Administrator Role
                apiInstance.RemoveApplicationTargetFromApplicationAdministratorRoleForUser(userId, roleId, appName);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleTargetApi.RemoveApplicationTargetFromApplicationAdministratorRoleForUser: " + e.Message );
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
 **roleId** | **string**|  | 
 **appName** | **string**|  | 

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

<a name="removeapplicationtargetfromapplicationadministratorrolegiventogroup"></a>
# **RemoveApplicationTargetFromApplicationAdministratorRoleGivenToGroup**
> void RemoveApplicationTargetFromApplicationAdministratorRoleGivenToGroup (string groupId, string roleId, string appName)

Delete an Application Target from Application Administrator Role

Delete an application target from application administrator role

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleTargetApi(config);
            var groupId = "groupId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var appName = "appName_example";  // string | 

            try
            {
                // Delete an Application Target from Application Administrator Role
                apiInstance.RemoveApplicationTargetFromApplicationAdministratorRoleGivenToGroup(groupId, roleId, appName);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleTargetApi.RemoveApplicationTargetFromApplicationAdministratorRoleGivenToGroup: " + e.Message );
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

<a name="removegrouptargetfromgroupadministratorrolegiventogroup"></a>
# **RemoveGroupTargetFromGroupAdministratorRoleGivenToGroup**
> void RemoveGroupTargetFromGroupAdministratorRoleGivenToGroup (string groupId, string roleId, string targetGroupId)

Delete a Group Target for Group Role

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleTargetApi(config);
            var groupId = "groupId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var targetGroupId = "targetGroupId_example";  // string | 

            try
            {
                // Delete a Group Target for Group Role
                apiInstance.RemoveGroupTargetFromGroupAdministratorRoleGivenToGroup(groupId, roleId, targetGroupId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleTargetApi.RemoveGroupTargetFromGroupAdministratorRoleGivenToGroup: " + e.Message );
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

<a name="removegrouptargetfromrole"></a>
# **RemoveGroupTargetFromRole**
> void RemoveGroupTargetFromRole (string userId, string roleId, string groupId)

Unassign a Group Target from Role

Unassign a Group Target from Role

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RemoveGroupTargetFromRoleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleTargetApi(config);
            var userId = "userId_example";  // string | 
            var roleId = "roleId_example";  // string | 
            var groupId = "groupId_example";  // string | 

            try
            {
                // Unassign a Group Target from Role
                apiInstance.RemoveGroupTargetFromRole(userId, roleId, groupId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleTargetApi.RemoveGroupTargetFromRole: " + e.Message );
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
 **roleId** | **string**|  | 
 **groupId** | **string**|  | 

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

