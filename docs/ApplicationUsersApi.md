# Okta.Sdk.Api.ApplicationUsersApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AssignUserToApplication**](ApplicationUsersApi.md#assignusertoapplication) | **POST** /api/v1/apps/{appId}/users | Assign a User
[**GetApplicationUser**](ApplicationUsersApi.md#getapplicationuser) | **GET** /api/v1/apps/{appId}/users/{userId} | Retrieve an assigned User
[**ListApplicationUsers**](ApplicationUsersApi.md#listapplicationusers) | **GET** /api/v1/apps/{appId}/users | List all assigned Users
[**UnassignUserFromApplication**](ApplicationUsersApi.md#unassignuserfromapplication) | **DELETE** /api/v1/apps/{appId}/users/{userId} | Unassign an App User
[**UpdateApplicationUser**](ApplicationUsersApi.md#updateapplicationuser) | **POST** /api/v1/apps/{appId}/users/{userId} | Update an App Profile for an assigned User


<a name="assignusertoapplication"></a>
# **AssignUserToApplication**
> AppUser AssignUserToApplication (string appId, AppUser appUser)

Assign a User

Assigns a user to an app with credentials and an app-specific [profile](/openapi/okta-management/management/tag/Application/#tag/Application/operation/assignUserToApplication!c=200&path=profile&t=response). Profile mappings defined for the app are applied first before applying any profile properties that are specified in the request.  > **Notes:** > * You need to specify the `id` and omit the `credentials` parameter in the request body only for `signOnMode` or authentication schemes (`credentials.scheme`) that don't require credentials. > * You can only specify profile properties that aren't defined by profile mappings when Universal Directory is enabled. > * If your SSO app requires a profile but doesn't have provisioning enabled, you need to add a profile to the request body.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AssignUserToApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationUsersApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application
            var appUser = new AppUser(); // AppUser | 

            try
            {
                // Assign a User
                AppUser result = apiInstance.AssignUserToApplication(appId, appUser);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationUsersApi.AssignUserToApplication: " + e.Message );
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
 **appId** | **string**| ID of the Application | 
 **appUser** | [**AppUser**](AppUser.md)|  | 

### Return type

[**AppUser**](AppUser.md)

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

<a name="getapplicationuser"></a>
# **GetApplicationUser**
> AppUser GetApplicationUser (string appId, string userId, string expand = null)

Retrieve an assigned User

Retrieves a specific user assignment for app by `id`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetApplicationUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationUsersApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application
            var userId = "userId_example";  // string | 
            var expand = "expand_example";  // string |  (optional) 

            try
            {
                // Retrieve an assigned User
                AppUser result = apiInstance.GetApplicationUser(appId, userId, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationUsersApi.GetApplicationUser: " + e.Message );
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
 **appId** | **string**| ID of the Application | 
 **userId** | **string**|  | 
 **expand** | **string**|  | [optional] 

### Return type

[**AppUser**](AppUser.md)

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

<a name="listapplicationusers"></a>
# **ListApplicationUsers**
> List&lt;AppUser&gt; ListApplicationUsers (string appId, string q = null, string queryScope = null, string after = null, int? limit = null, string filter = null, string expand = null)

List all assigned Users

Lists all assigned users for an app

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListApplicationUsersExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationUsersApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application
            var q = "q_example";  // string |  (optional) 
            var queryScope = "queryScope_example";  // string |  (optional) 
            var after = "after_example";  // string | specifies the pagination cursor for the next page of assignments (optional) 
            var limit = -1;  // int? | specifies the number of results for a page (optional)  (default to -1)
            var filter = "filter_example";  // string |  (optional) 
            var expand = "expand_example";  // string |  (optional) 

            try
            {
                // List all assigned Users
                List<AppUser> result = apiInstance.ListApplicationUsers(appId, q, queryScope, after, limit, filter, expand).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationUsersApi.ListApplicationUsers: " + e.Message );
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
 **appId** | **string**| ID of the Application | 
 **q** | **string**|  | [optional] 
 **queryScope** | **string**|  | [optional] 
 **after** | **string**| specifies the pagination cursor for the next page of assignments | [optional] 
 **limit** | **int?**| specifies the number of results for a page | [optional] [default to -1]
 **filter** | **string**|  | [optional] 
 **expand** | **string**|  | [optional] 

### Return type

[**List&lt;AppUser&gt;**](AppUser.md)

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

<a name="unassignuserfromapplication"></a>
# **UnassignUserFromApplication**
> void UnassignUserFromApplication (string appId, string userId, bool? sendEmail = null)

Unassign an App User

Unassigns a user from an application

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UnassignUserFromApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationUsersApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application
            var userId = "userId_example";  // string | 
            var sendEmail = false;  // bool? |  (optional)  (default to false)

            try
            {
                // Unassign an App User
                apiInstance.UnassignUserFromApplication(appId, userId, sendEmail);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationUsersApi.UnassignUserFromApplication: " + e.Message );
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
 **appId** | **string**| ID of the Application | 
 **userId** | **string**|  | 
 **sendEmail** | **bool?**|  | [optional] [default to false]

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

<a name="updateapplicationuser"></a>
# **UpdateApplicationUser**
> AppUser UpdateApplicationUser (string appId, string userId, AppUser appUser)

Update an App Profile for an assigned User

Updates a user's profile for an application

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateApplicationUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationUsersApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application
            var userId = "userId_example";  // string | 
            var appUser = new AppUser(); // AppUser | 

            try
            {
                // Update an App Profile for an assigned User
                AppUser result = apiInstance.UpdateApplicationUser(appId, userId, appUser);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationUsersApi.UpdateApplicationUser: " + e.Message );
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
 **appId** | **string**| ID of the Application | 
 **userId** | **string**|  | 
 **appUser** | [**AppUser**](AppUser.md)|  | 

### Return type

[**AppUser**](AppUser.md)

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

