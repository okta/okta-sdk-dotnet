# Okta.Sdk.Api.ApplicationUsersApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AssignUserToApplication**](ApplicationUsersApi.md#assignusertoapplication) | **POST** /api/v1/apps/{appId}/users | Assign an application user
[**GetApplicationUser**](ApplicationUsersApi.md#getapplicationuser) | **GET** /api/v1/apps/{appId}/users/{userId} | Retrieve an application user
[**ListApplicationUsers**](ApplicationUsersApi.md#listapplicationusers) | **GET** /api/v1/apps/{appId}/users | List all application users
[**UnassignUserFromApplication**](ApplicationUsersApi.md#unassignuserfromapplication) | **DELETE** /api/v1/apps/{appId}/users/{userId} | Unassign an application user
[**UpdateApplicationUser**](ApplicationUsersApi.md#updateapplicationuser) | **POST** /api/v1/apps/{appId}/users/{userId} | Update an application user


<a name="assignusertoapplication"></a>
# **AssignUserToApplication**
> AppUser AssignUserToApplication (string appId, AppUserAssignRequest appUser)

Assign an application user

Assigns a user to an app for:    * SSO only<br>     Assignments to SSO apps typically don't include a user profile.     However, if your SSO app requires a profile but doesn't have provisioning enabled, you can add profile attributes in the request body.    * SSO and provisioning<br>     Assignments to SSO and provisioning apps typically include credentials and an app-specific profile.     Profile mappings defined for the app are applied first before applying any profile properties that are specified in the request body.     > **Notes:**     > * When Universal Directory is enabled, you can only specify profile properties that aren't defined in profile mappings.     > * Omit mapped properties during assignment to minimize assignment errors.

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
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var appUser = new AppUserAssignRequest(); // AppUserAssignRequest | 

            try
            {
                // Assign an application user
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
 **appId** | **string**| Application ID | 
 **appUser** | [**AppUserAssignRequest**](AppUserAssignRequest.md)|  | 

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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getapplicationuser"></a>
# **GetApplicationUser**
> AppUser GetApplicationUser (string appId, string userId, string expand = null)

Retrieve an application user

Retrieves a specific user assignment for a specific app

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
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var userId = 00u13okQOVWZJGDOAUVR;  // string | ID of an existing Okta user
            var expand = user;  // string | An optional query parameter to return the corresponding [User](/openapi/okta-management/management/tag/User/) object in the `_embedded` property. Valid value: `user` (optional) 

            try
            {
                // Retrieve an application user
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
 **appId** | **string**| Application ID | 
 **userId** | **string**| ID of an existing Okta user | 
 **expand** | **string**| An optional query parameter to return the corresponding [User](/openapi/okta-management/management/tag/User/) object in the &#x60;_embedded&#x60; property. Valid value: &#x60;user&#x60; | [optional] 

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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listapplicationusers"></a>
# **ListApplicationUsers**
> List&lt;AppUser&gt; ListApplicationUsers (string appId, string after = null, int? limit = null, string q = null, string expand = null)

List all application users

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
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var after = 16275000448691;  // string | Specifies the pagination cursor for the next page of results. Treat this as an opaque value obtained through the next link relationship. See [Pagination](/#pagination). (optional) 
            var limit = 50;  // int? | Specifies the number of objects to return per page. If there are multiple pages of results, the Link header contains a `next` link that you need to use as an opaque value (follow it, don't parse it). See [Pagination](/#pagination).  (optional)  (default to 50)
            var q = sam;  // string | Specifies a filter for the list of application users returned based on their profile attributes. The value of `q` is matched against the beginning of the following profile attributes: `userName`, `firstName`, `lastName`, and `email`. This filter only supports the `startsWith` operation that matches the `q` string against the beginning of the attribute values. > **Note:** For OIDC apps, user profiles don't contain the `firstName` or `lastName` attributes. Therefore, the query only matches against the `userName` or `email` attributes.  (optional) 
            var expand = user;  // string | An optional query parameter to return the corresponding [User](/openapi/okta-management/management/tag/User/) object in the `_embedded` property. Valid value: `user` (optional) 

            try
            {
                // List all application users
                List<AppUser> result = apiInstance.ListApplicationUsers(appId, after, limit, q, expand).ToListAsync();
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
 **appId** | **string**| Application ID | 
 **after** | **string**| Specifies the pagination cursor for the next page of results. Treat this as an opaque value obtained through the next link relationship. See [Pagination](/#pagination). | [optional] 
 **limit** | **int?**| Specifies the number of objects to return per page. If there are multiple pages of results, the Link header contains a &#x60;next&#x60; link that you need to use as an opaque value (follow it, don&#39;t parse it). See [Pagination](/#pagination).  | [optional] [default to 50]
 **q** | **string**| Specifies a filter for the list of application users returned based on their profile attributes. The value of &#x60;q&#x60; is matched against the beginning of the following profile attributes: &#x60;userName&#x60;, &#x60;firstName&#x60;, &#x60;lastName&#x60;, and &#x60;email&#x60;. This filter only supports the &#x60;startsWith&#x60; operation that matches the &#x60;q&#x60; string against the beginning of the attribute values. &gt; **Note:** For OIDC apps, user profiles don&#39;t contain the &#x60;firstName&#x60; or &#x60;lastName&#x60; attributes. Therefore, the query only matches against the &#x60;userName&#x60; or &#x60;email&#x60; attributes.  | [optional] 
 **expand** | **string**| An optional query parameter to return the corresponding [User](/openapi/okta-management/management/tag/User/) object in the &#x60;_embedded&#x60; property. Valid value: &#x60;user&#x60; | [optional] 

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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="unassignuserfromapplication"></a>
# **UnassignUserFromApplication**
> void UnassignUserFromApplication (string appId, string userId, bool? sendEmail = null)

Unassign an application user

Unassigns a user from an app  For directories like Active Directory and LDAP, they act as the owner of the user's credential with Okta delegating authentication (DelAuth) to that directory. If this request is successful for a user when DelAuth is enabled, then the user is in a state with no password. You can then reset the user's password.  > **Important:** This is a destructive operation. You can't recover the user's app profile. If the app is enabled for provisioning and configured to deactivate users, the user is also deactivated in the target app.

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
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var userId = 00u13okQOVWZJGDOAUVR;  // string | ID of an existing Okta user
            var sendEmail = false;  // bool? | Sends a deactivation email to the administrator if `true` (optional)  (default to false)

            try
            {
                // Unassign an application user
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
 **appId** | **string**| Application ID | 
 **userId** | **string**| ID of an existing Okta user | 
 **sendEmail** | **bool?**| Sends a deactivation email to the administrator if &#x60;true&#x60; | [optional] [default to false]

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

<a name="updateapplicationuser"></a>
# **UpdateApplicationUser**
> AppUser UpdateApplicationUser (string appId, string userId, AppUserUpdateRequest appUser)

Update an application user

Updates the profile or credentials of a user assigned to an app

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
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var userId = 00u13okQOVWZJGDOAUVR;  // string | ID of an existing Okta user
            var appUser = new AppUserUpdateRequest(); // AppUserUpdateRequest | 

            try
            {
                // Update an application user
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
 **appId** | **string**| Application ID | 
 **userId** | **string**| ID of an existing Okta user | 
 **appUser** | [**AppUserUpdateRequest**](AppUserUpdateRequest.md)|  | 

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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

