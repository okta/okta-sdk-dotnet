# Okta.Sdk.Api.RoleAssignmentClientApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AssignRoleToClient**](RoleAssignmentClientApi.md#assignroletoclient) | **POST** /oauth2/v1/clients/{clientId}/roles | Assign a client role
[**DeleteRoleFromClient**](RoleAssignmentClientApi.md#deleterolefromclient) | **DELETE** /oauth2/v1/clients/{clientId}/roles/{roleAssignmentId} | Unassign a client role
[**ListRolesForClient**](RoleAssignmentClientApi.md#listrolesforclient) | **GET** /oauth2/v1/clients/{clientId}/roles | List all client role assignments
[**RetrieveClientRole**](RoleAssignmentClientApi.md#retrieveclientrole) | **GET** /oauth2/v1/clients/{clientId}/roles/{roleAssignmentId} | Retrieve a client role


<a name="assignroletoclient"></a>
# **AssignRoleToClient**
> ListGroupAssignedRoles200ResponseInner AssignRoleToClient (string clientId, AssignRoleToGroupRequest assignRoleToGroupRequest)

Assign a client role

Assigns a [standard role](/openapi/okta-management/guides/roles/#standard-roles) to a client app.  You can also assign a custom role to a client app, but the preferred method to assign a custom role to a client is to create a binding between the custom role, the resource set, and the client app. See [Create a role resource set binding](/openapi/okta-management/management/tag/RoleDResourceSetBinding/#tag/RoleDResourceSetBinding/operation/createResourceSetBinding).  > **Notes:** > * The request payload is different for standard and custom role assignments. > * For IAM-based standard role assignments, use the request payload for standard roles. However, the response payload for IAM-based role assignments is similar to the custom role's assignment response.

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

            var apiInstance = new RoleAssignmentClientApi(config);
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | Client app ID
            var assignRoleToGroupRequest = new AssignRoleToGroupRequest(); // AssignRoleToGroupRequest | 

            try
            {
                // Assign a client role
                ListGroupAssignedRoles200ResponseInner result = apiInstance.AssignRoleToClient(clientId, assignRoleToGroupRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentClientApi.AssignRoleToClient: " + e.Message );
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
 **assignRoleToGroupRequest** | [**AssignRoleToGroupRequest**](AssignRoleToGroupRequest.md)|  | 

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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleterolefromclient"></a>
# **DeleteRoleFromClient**
> void DeleteRoleFromClient (string clientId, string roleAssignmentId)

Unassign a client role

Unassigns a role assignment (identified by `roleAssignmentId`) from a client app (identified by `clientId`)

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

            var apiInstance = new RoleAssignmentClientApi(config);
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | Client app ID
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment

            try
            {
                // Unassign a client role
                apiInstance.DeleteRoleFromClient(clientId, roleAssignmentId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentClientApi.DeleteRoleFromClient: " + e.Message );
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

<a name="listrolesforclient"></a>
# **ListRolesForClient**
> List&lt;ListGroupAssignedRoles200ResponseInner&gt; ListRolesForClient (string clientId)

List all client role assignments

Lists all roles assigned to a client app identified by `clientId`

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

            var apiInstance = new RoleAssignmentClientApi(config);
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | Client app ID

            try
            {
                // List all client role assignments
                List<ListGroupAssignedRoles200ResponseInner> result = apiInstance.ListRolesForClient(clientId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentClientApi.ListRolesForClient: " + e.Message );
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

<a name="retrieveclientrole"></a>
# **RetrieveClientRole**
> ListGroupAssignedRoles200ResponseInner RetrieveClientRole (string clientId, string roleAssignmentId)

Retrieve a client role

Retrieves a role assignment (identified by `roleAssignmentId`) for a client app (identified by `clientId`)

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

            var apiInstance = new RoleAssignmentClientApi(config);
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | Client app ID
            var roleAssignmentId = JBCUYUC7IRCVGS27IFCE2SKO;  // string | The `id` of the role assignment

            try
            {
                // Retrieve a client role
                ListGroupAssignedRoles200ResponseInner result = apiInstance.RetrieveClientRole(clientId, roleAssignmentId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleAssignmentClientApi.RetrieveClientRole: " + e.Message );
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

