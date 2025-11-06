# Okta.Sdk.Api.RoleBTargetClientApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AssignAppTargetInstanceRoleForClient**](RoleBTargetClientApi.md#assignapptargetinstanceroleforclient) | **PUT** /oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}/targets/catalog/apps/{appName}/{appId} | Assign a client role app instance target
[**AssignAppTargetRoleToClient**](RoleBTargetClientApi.md#assignapptargetroletoclient) | **PUT** /oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}/targets/catalog/apps/{appName} | Assign a client role app target
[**AssignGroupTargetRoleForClient**](RoleBTargetClientApi.md#assigngrouptargetroleforclient) | **PUT** /oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}/targets/groups/{groupId} | Assign a client role group target
[**ListAppTargetRoleToClient**](RoleBTargetClientApi.md#listapptargetroletoclient) | **GET** /oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}/targets/catalog/apps | List all client role app targets
[**ListGroupTargetRoleForClient**](RoleBTargetClientApi.md#listgrouptargetroleforclient) | **GET** /oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}/targets/groups | List all client role group targets
[**RemoveAppTargetInstanceRoleForClient**](RoleBTargetClientApi.md#removeapptargetinstanceroleforclient) | **DELETE** /oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}/targets/catalog/apps/{appName}/{appId} | Unassign a client role app instance target
[**RemoveAppTargetRoleFromClient**](RoleBTargetClientApi.md#removeapptargetrolefromclient) | **DELETE** /oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}/targets/catalog/apps/{appName} | Unassign a client role app target
[**RemoveGroupTargetRoleFromClient**](RoleBTargetClientApi.md#removegrouptargetrolefromclient) | **DELETE** /oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}/targets/groups/{groupId} | Unassign a client role group target


<a name="assignapptargetinstanceroleforclient"></a>
# **AssignAppTargetInstanceRoleForClient**
> void AssignAppTargetInstanceRoleForClient (string clientId, string roleAssignmentId, string appName, string appId)

Assign a client role app instance target

Assigns an app instance target to an `APP_ADMIN` role assignment to a client. When you assign the first OIN app or app instance target, you reduce the scope of the role assignment. The role no longer applies to all app targets, but applies only to the specified target.  > **Note:** You can target a mixture of both OIN app and app instance targets, but you can't assign permissions to manage all instances of an OIN app and then assign a subset of permissions to the same app. For example, you can't specify that an admin has access to manage all instances of the Salesforce app and then also manage only specific configurations of the Salesforce app.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AssignAppTargetInstanceRoleForClientExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleBTargetClientApi(config);
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | Client app ID
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment
            var appName = google;  // string | Name of the app definition (the OIN catalog app key name)
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID

            try
            {
                // Assign a client role app instance target
                apiInstance.AssignAppTargetInstanceRoleForClient(clientId, roleAssignmentId, appName, appId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleBTargetClientApi.AssignAppTargetInstanceRoleForClient: " + e.Message );
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
 **clientId** | **string**| Client app ID | 
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

<a name="assignapptargetroletoclient"></a>
# **AssignAppTargetRoleToClient**
> void AssignAppTargetRoleToClient (string clientId, string roleAssignmentId, string appName)

Assign a client role app target

Assigns an OIN app target for an `APP_ADMIN` role assignment to a client. When you assign an app target from the OIN catalog, you reduce the scope of the role assignment. The role assignment applies to only app instances that are included in the specified OIN app target.  An assigned OIN app target overrides any existing app instance targets. For example, if a user is assigned to administer a specific Facebook instance, a successful request to add an OIN app target with `facebook` for `appName` makes that user the administrator for all Facebook instances.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AssignAppTargetRoleToClientExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleBTargetClientApi(config);
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | Client app ID
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment
            var appName = google;  // string | Name of the app definition (the OIN catalog app key name)

            try
            {
                // Assign a client role app target
                apiInstance.AssignAppTargetRoleToClient(clientId, roleAssignmentId, appName);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleBTargetClientApi.AssignAppTargetRoleToClient: " + e.Message );
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
 **clientId** | **string**| Client app ID | 
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

<a name="assigngrouptargetroleforclient"></a>
# **AssignGroupTargetRoleForClient**
> void AssignGroupTargetRoleForClient (string clientId, string roleAssignmentId, string groupId)

Assign a client role group target

Assigns a group target to a [`USER_ADMIN`](/openapi/okta-management/guides/roles/#standard-roles), `HELP_DESK_ADMIN`, or `GROUP_MEMBERSHIP_ADMIN` role assignment to a client app. When you assign the first group target, you reduce the scope of the role assignment. The role no longer applies to all targets, but applies only to the specified target.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AssignGroupTargetRoleForClientExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleBTargetClientApi(config);
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | Client app ID
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group

            try
            {
                // Assign a client role group target
                apiInstance.AssignGroupTargetRoleForClient(clientId, roleAssignmentId, groupId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleBTargetClientApi.AssignGroupTargetRoleForClient: " + e.Message );
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
 **clientId** | **string**| Client app ID | 
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

<a name="listapptargetroletoclient"></a>
# **ListAppTargetRoleToClient**
> List&lt;CatalogApplication&gt; ListAppTargetRoleToClient (string clientId, string roleAssignmentId, string after = null, int? limit = null)

List all client role app targets

Lists all OIN app targets for an `APP_ADMIN` role that's assigned to a client (by `clientId`).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListAppTargetRoleToClientExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleBTargetClientApi(config);
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | Client app ID
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 
            var limit = 20;  // int? | A limit on the number of objects to return (optional)  (default to 20)

            try
            {
                // List all client role app targets
                List<CatalogApplication> result = apiInstance.ListAppTargetRoleToClient(clientId, roleAssignmentId, after, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleBTargetClientApi.ListAppTargetRoleToClient: " + e.Message );
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
 **clientId** | **string**| Client app ID | 
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

<a name="listgrouptargetroleforclient"></a>
# **ListGroupTargetRoleForClient**
> List&lt;Group&gt; ListGroupTargetRoleForClient (string clientId, string roleAssignmentId, string after = null, int? limit = null)

List all client role group targets

Lists all group targets for a [`USER_ADMIN`](/openapi/okta-management/guides/roles/#standard-roles), `HELP_DESK_ADMIN`, or `GROUP_MEMBERSHIP_ADMIN` role assignment to a client. If the role isn't scoped to specific group targets, Okta returns an empty array `[]`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListGroupTargetRoleForClientExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleBTargetClientApi(config);
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | Client app ID
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 
            var limit = 20;  // int? | A limit on the number of objects to return (optional)  (default to 20)

            try
            {
                // List all client role group targets
                List<Group> result = apiInstance.ListGroupTargetRoleForClient(clientId, roleAssignmentId, after, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleBTargetClientApi.ListGroupTargetRoleForClient: " + e.Message );
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
 **clientId** | **string**| Client app ID | 
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

<a name="removeapptargetinstanceroleforclient"></a>
# **RemoveAppTargetInstanceRoleForClient**
> void RemoveAppTargetInstanceRoleForClient (string clientId, string roleAssignmentId, string appName, string appId)

Unassign a client role app instance target

Unassigns an app instance target from a role assignment to a client app  > **Note:** You can't remove the last app instance target from a role assignment. > If you need a role assignment that applies to all the apps, delete the role assignment with the instance target and create another one.  See [Unassign a client role](/openapi/okta-management/management/tag/RoleAssignmentClient/#tag/RoleAssignmentClient/operation/deleteRoleFromClient).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RemoveAppTargetInstanceRoleForClientExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleBTargetClientApi(config);
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | Client app ID
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment
            var appName = google;  // string | Name of the app definition (the OIN catalog app key name)
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID

            try
            {
                // Unassign a client role app instance target
                apiInstance.RemoveAppTargetInstanceRoleForClient(clientId, roleAssignmentId, appName, appId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleBTargetClientApi.RemoveAppTargetInstanceRoleForClient: " + e.Message );
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
 **clientId** | **string**| Client app ID | 
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

<a name="removeapptargetrolefromclient"></a>
# **RemoveAppTargetRoleFromClient**
> void RemoveAppTargetRoleFromClient (string clientId, string roleAssignmentId, string appName)

Unassign a client role app target

Unassigns an OIN app target for a role assignment to a client app  > **Note:** You can't remove the last OIN app target from a role assignment. > If you need a role assignment that applies to all apps, delete the role assignment with the target and create another one. See [Unassign a client role](/openapi/okta-management/management/tag/RoleAssignmentClient/#tag/RoleAssignmentClient/operation/deleteRoleFromClient).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RemoveAppTargetRoleFromClientExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleBTargetClientApi(config);
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | Client app ID
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment
            var appName = google;  // string | Name of the app definition (the OIN catalog app key name)

            try
            {
                // Unassign a client role app target
                apiInstance.RemoveAppTargetRoleFromClient(clientId, roleAssignmentId, appName);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleBTargetClientApi.RemoveAppTargetRoleFromClient: " + e.Message );
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
 **clientId** | **string**| Client app ID | 
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

<a name="removegrouptargetrolefromclient"></a>
# **RemoveGroupTargetRoleFromClient**
> void RemoveGroupTargetRoleFromClient (string clientId, string roleAssignmentId, string groupId)

Unassign a client role group target

Unassigns a Group target from a `USER_ADMIN`, `HELP_DESK_ADMIN`, or `GROUP_MEMBERSHIP_ADMIN` role assignment to a client app.  > **Note:** You can't remove the last group target from a role assignment. If you need a role assignment that applies to all groups, delete the role assignment with the target and create another one. See [Unassign a client role](/openapi/okta-management/management/tag/RoleAssignmentClient/#tag/RoleAssignmentClient/operation/deleteRoleFromClient).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RemoveGroupTargetRoleFromClientExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleBTargetClientApi(config);
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | Client app ID
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment
            var groupId = 00g1emaKYZTWRYYRRTSK;  // string | The `id` of the group

            try
            {
                // Unassign a client role group target
                apiInstance.RemoveGroupTargetRoleFromClient(clientId, roleAssignmentId, groupId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleBTargetClientApi.RemoveGroupTargetRoleFromClient: " + e.Message );
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
 **clientId** | **string**| Client app ID | 
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

