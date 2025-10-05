# Okta.Sdk.Api.RoleECustomPermissionApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateRolePermission**](RoleECustomPermissionApi.md#createrolepermission) | **POST** /api/v1/iam/roles/{roleIdOrLabel}/permissions/{permissionType} | Create a custom role permission
[**DeleteRolePermission**](RoleECustomPermissionApi.md#deleterolepermission) | **DELETE** /api/v1/iam/roles/{roleIdOrLabel}/permissions/{permissionType} | Delete a custom role permission
[**GetRolePermission**](RoleECustomPermissionApi.md#getrolepermission) | **GET** /api/v1/iam/roles/{roleIdOrLabel}/permissions/{permissionType} | Retrieve a custom role permission
[**ListRolePermissions**](RoleECustomPermissionApi.md#listrolepermissions) | **GET** /api/v1/iam/roles/{roleIdOrLabel}/permissions | List all custom role permissions
[**ReplaceRolePermission**](RoleECustomPermissionApi.md#replacerolepermission) | **PUT** /api/v1/iam/roles/{roleIdOrLabel}/permissions/{permissionType} | Replace a custom role permission


<a name="createrolepermission"></a>
# **CreateRolePermission**
> void CreateRolePermission (string roleIdOrLabel, string permissionType, CreateUpdateIamRolePermissionRequest instance = null)

Create a custom role permission

Creates a permission (specified by `permissionType`) for a custom role

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateRolePermissionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleECustomPermissionApi(config);
            var roleIdOrLabel = cr0Yq6IJxGIr0ouum0g3;  // string | `id` or `label` of the role
            var permissionType = okta.users.manage;  // string | An Okta [permission](/openapi/okta-management/guides/permissions)
            var instance = new CreateUpdateIamRolePermissionRequest(); // CreateUpdateIamRolePermissionRequest |  (optional) 

            try
            {
                // Create a custom role permission
                apiInstance.CreateRolePermission(roleIdOrLabel, permissionType, instance);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleECustomPermissionApi.CreateRolePermission: " + e.Message );
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
 **roleIdOrLabel** | **string**| &#x60;id&#x60; or &#x60;label&#x60; of the role | 
 **permissionType** | **string**| An Okta [permission](/openapi/okta-management/guides/permissions) | 
 **instance** | [**CreateUpdateIamRolePermissionRequest**](CreateUpdateIamRolePermissionRequest.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleterolepermission"></a>
# **DeleteRolePermission**
> void DeleteRolePermission (string roleIdOrLabel, string permissionType)

Delete a custom role permission

Deletes a permission (identified by `permissionType`) from a custom role

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteRolePermissionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleECustomPermissionApi(config);
            var roleIdOrLabel = cr0Yq6IJxGIr0ouum0g3;  // string | `id` or `label` of the role
            var permissionType = okta.users.manage;  // string | An Okta [permission](/openapi/okta-management/guides/permissions)

            try
            {
                // Delete a custom role permission
                apiInstance.DeleteRolePermission(roleIdOrLabel, permissionType);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleECustomPermissionApi.DeleteRolePermission: " + e.Message );
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
 **roleIdOrLabel** | **string**| &#x60;id&#x60; or &#x60;label&#x60; of the role | 
 **permissionType** | **string**| An Okta [permission](/openapi/okta-management/guides/permissions) | 

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

<a name="getrolepermission"></a>
# **GetRolePermission**
> Permission GetRolePermission (string roleIdOrLabel, string permissionType)

Retrieve a custom role permission

Retrieves a permission (identified by `permissionType`) for a custom role

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetRolePermissionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleECustomPermissionApi(config);
            var roleIdOrLabel = cr0Yq6IJxGIr0ouum0g3;  // string | `id` or `label` of the role
            var permissionType = okta.users.manage;  // string | An Okta [permission](/openapi/okta-management/guides/permissions)

            try
            {
                // Retrieve a custom role permission
                Permission result = apiInstance.GetRolePermission(roleIdOrLabel, permissionType);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleECustomPermissionApi.GetRolePermission: " + e.Message );
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
 **roleIdOrLabel** | **string**| &#x60;id&#x60; or &#x60;label&#x60; of the role | 
 **permissionType** | **string**| An Okta [permission](/openapi/okta-management/guides/permissions) | 

### Return type

[**Permission**](Permission.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listrolepermissions"></a>
# **ListRolePermissions**
> Permissions ListRolePermissions (string roleIdOrLabel)

List all custom role permissions

Lists all permissions for a custom role by `roleIdOrLabel`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListRolePermissionsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleECustomPermissionApi(config);
            var roleIdOrLabel = cr0Yq6IJxGIr0ouum0g3;  // string | `id` or `label` of the role

            try
            {
                // List all custom role permissions
                Permissions result = apiInstance.ListRolePermissions(roleIdOrLabel);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleECustomPermissionApi.ListRolePermissions: " + e.Message );
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
 **roleIdOrLabel** | **string**| &#x60;id&#x60; or &#x60;label&#x60; of the role | 

### Return type

[**Permissions**](Permissions.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacerolepermission"></a>
# **ReplaceRolePermission**
> Permission ReplaceRolePermission (string roleIdOrLabel, string permissionType, CreateUpdateIamRolePermissionRequest instance = null)

Replace a custom role permission

Replaces a permission (specified by `permissionType`) for a custom role

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceRolePermissionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleECustomPermissionApi(config);
            var roleIdOrLabel = cr0Yq6IJxGIr0ouum0g3;  // string | `id` or `label` of the role
            var permissionType = okta.users.manage;  // string | An Okta [permission](/openapi/okta-management/guides/permissions)
            var instance = new CreateUpdateIamRolePermissionRequest(); // CreateUpdateIamRolePermissionRequest |  (optional) 

            try
            {
                // Replace a custom role permission
                Permission result = apiInstance.ReplaceRolePermission(roleIdOrLabel, permissionType, instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleECustomPermissionApi.ReplaceRolePermission: " + e.Message );
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
 **roleIdOrLabel** | **string**| &#x60;id&#x60; or &#x60;label&#x60; of the role | 
 **permissionType** | **string**| An Okta [permission](/openapi/okta-management/guides/permissions) | 
 **instance** | [**CreateUpdateIamRolePermissionRequest**](CreateUpdateIamRolePermissionRequest.md)|  | [optional] 

### Return type

[**Permission**](Permission.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

