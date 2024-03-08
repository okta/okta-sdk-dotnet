# Okta.Sdk.Api.RoleApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateRole**](RoleApi.md#createrole) | **POST** /api/v1/iam/roles | Create a Role
[**CreateRolePermission**](RoleApi.md#createrolepermission) | **POST** /api/v1/iam/roles/{roleIdOrLabel}/permissions/{permissionType} | Create a Permission
[**DeleteRole**](RoleApi.md#deleterole) | **DELETE** /api/v1/iam/roles/{roleIdOrLabel} | Delete a Role
[**DeleteRolePermission**](RoleApi.md#deleterolepermission) | **DELETE** /api/v1/iam/roles/{roleIdOrLabel}/permissions/{permissionType} | Delete a Permission
[**GetRole**](RoleApi.md#getrole) | **GET** /api/v1/iam/roles/{roleIdOrLabel} | Retrieve a Role
[**GetRolePermission**](RoleApi.md#getrolepermission) | **GET** /api/v1/iam/roles/{roleIdOrLabel}/permissions/{permissionType} | Retrieve a Permission
[**ListRolePermissions**](RoleApi.md#listrolepermissions) | **GET** /api/v1/iam/roles/{roleIdOrLabel}/permissions | List all Permissions
[**ListRoles**](RoleApi.md#listroles) | **GET** /api/v1/iam/roles | List all Roles
[**ReplaceRole**](RoleApi.md#replacerole) | **PUT** /api/v1/iam/roles/{roleIdOrLabel} | Replace a Role
[**ReplaceRolePermission**](RoleApi.md#replacerolepermission) | **PUT** /api/v1/iam/roles/{roleIdOrLabel}/permissions/{permissionType} | Replace a Permission


<a name="createrole"></a>
# **CreateRole**
> IamRole CreateRole (CreateIamRoleRequest instance)

Create a Role

Creates a new role

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateRoleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleApi(config);
            var instance = new CreateIamRoleRequest(); // CreateIamRoleRequest | 

            try
            {
                // Create a Role
                IamRole result = apiInstance.CreateRole(instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleApi.CreateRole: " + e.Message );
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
 **instance** | [**CreateIamRoleRequest**](CreateIamRoleRequest.md)|  | 

### Return type

[**IamRole**](IamRole.md)

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
| **403** | Forbidden |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createrolepermission"></a>
# **CreateRolePermission**
> void CreateRolePermission (string roleIdOrLabel, string permissionType, CreateUpdateIamRolePermissionRequest instance = null)

Create a Permission

Creates a permission specified by `permissionType` to the role

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

            var apiInstance = new RoleApi(config);
            var roleIdOrLabel = cr0Yq6IJxGIr0ouum0g3;  // string | `id` or `label` of the role
            var permissionType = okta.users.manage;  // string | An okta permission type
            var instance = new CreateUpdateIamRolePermissionRequest(); // CreateUpdateIamRolePermissionRequest |  (optional) 

            try
            {
                // Create a Permission
                apiInstance.CreateRolePermission(roleIdOrLabel, permissionType, instance);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleApi.CreateRolePermission: " + e.Message );
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
 **permissionType** | **string**| An okta permission type | 
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
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleterole"></a>
# **DeleteRole**
> void DeleteRole (string roleIdOrLabel)

Delete a Role

Deletes a role by `roleIdOrLabel`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteRoleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleApi(config);
            var roleIdOrLabel = cr0Yq6IJxGIr0ouum0g3;  // string | `id` or `label` of the role

            try
            {
                // Delete a Role
                apiInstance.DeleteRole(roleIdOrLabel);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleApi.DeleteRole: " + e.Message );
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
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleterolepermission"></a>
# **DeleteRolePermission**
> void DeleteRolePermission (string roleIdOrLabel, string permissionType)

Delete a Permission

Deletes a permission from a role by `permissionType`

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

            var apiInstance = new RoleApi(config);
            var roleIdOrLabel = cr0Yq6IJxGIr0ouum0g3;  // string | `id` or `label` of the role
            var permissionType = okta.users.manage;  // string | An okta permission type

            try
            {
                // Delete a Permission
                apiInstance.DeleteRolePermission(roleIdOrLabel, permissionType);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleApi.DeleteRolePermission: " + e.Message );
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
 **permissionType** | **string**| An okta permission type | 

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
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getrole"></a>
# **GetRole**
> IamRole GetRole (string roleIdOrLabel)

Retrieve a Role

Retrieves a role by `roleIdOrLabel`

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleApi(config);
            var roleIdOrLabel = cr0Yq6IJxGIr0ouum0g3;  // string | `id` or `label` of the role

            try
            {
                // Retrieve a Role
                IamRole result = apiInstance.GetRole(roleIdOrLabel);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleApi.GetRole: " + e.Message );
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

[**IamRole**](IamRole.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getrolepermission"></a>
# **GetRolePermission**
> Permission GetRolePermission (string roleIdOrLabel, string permissionType)

Retrieve a Permission

Retrieves a permission by `permissionType`

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

            var apiInstance = new RoleApi(config);
            var roleIdOrLabel = cr0Yq6IJxGIr0ouum0g3;  // string | `id` or `label` of the role
            var permissionType = okta.users.manage;  // string | An okta permission type

            try
            {
                // Retrieve a Permission
                Permission result = apiInstance.GetRolePermission(roleIdOrLabel, permissionType);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleApi.GetRolePermission: " + e.Message );
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
 **permissionType** | **string**| An okta permission type | 

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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listrolepermissions"></a>
# **ListRolePermissions**
> Permissions ListRolePermissions (string roleIdOrLabel)

List all Permissions

Lists all permissions of the role by `roleIdOrLabel`

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

            var apiInstance = new RoleApi(config);
            var roleIdOrLabel = cr0Yq6IJxGIr0ouum0g3;  // string | `id` or `label` of the role

            try
            {
                // List all Permissions
                Permissions result = apiInstance.ListRolePermissions(roleIdOrLabel);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleApi.ListRolePermissions: " + e.Message );
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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listroles"></a>
# **ListRoles**
> IamRoles ListRoles (string after = null)

List all Roles

Lists all roles with pagination support

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListRolesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleApi(config);
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](/#pagination) for more information. (optional) 

            try
            {
                // List all Roles
                IamRoles result = apiInstance.ListRoles(after);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleApi.ListRoles: " + e.Message );
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
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](/#pagination) for more information. | [optional] 

### Return type

[**IamRoles**](IamRoles.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **403** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacerole"></a>
# **ReplaceRole**
> IamRole ReplaceRole (string roleIdOrLabel, UpdateIamRoleRequest instance)

Replace a Role

Replaces a role by `roleIdOrLabel`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceRoleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RoleApi(config);
            var roleIdOrLabel = cr0Yq6IJxGIr0ouum0g3;  // string | `id` or `label` of the role
            var instance = new UpdateIamRoleRequest(); // UpdateIamRoleRequest | 

            try
            {
                // Replace a Role
                IamRole result = apiInstance.ReplaceRole(roleIdOrLabel, instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleApi.ReplaceRole: " + e.Message );
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
 **instance** | [**UpdateIamRoleRequest**](UpdateIamRoleRequest.md)|  | 

### Return type

[**IamRole**](IamRole.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacerolepermission"></a>
# **ReplaceRolePermission**
> Permission ReplaceRolePermission (string roleIdOrLabel, string permissionType, CreateUpdateIamRolePermissionRequest instance = null)

Replace a Permission

Replaces a permission specified by `permissionType` in the role

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

            var apiInstance = new RoleApi(config);
            var roleIdOrLabel = cr0Yq6IJxGIr0ouum0g3;  // string | `id` or `label` of the role
            var permissionType = okta.users.manage;  // string | An okta permission type
            var instance = new CreateUpdateIamRolePermissionRequest(); // CreateUpdateIamRolePermissionRequest |  (optional) 

            try
            {
                // Replace a Permission
                Permission result = apiInstance.ReplaceRolePermission(roleIdOrLabel, permissionType, instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleApi.ReplaceRolePermission: " + e.Message );
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
 **permissionType** | **string**| An okta permission type | 
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
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

