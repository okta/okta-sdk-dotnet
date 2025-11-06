# Okta.Sdk.Api.UserSessionsApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**EndUserSessions**](UserSessionsApi.md#endusersessions) | **POST** /api/v1/users/me/lifecycle/delete_sessions | End a current user session
[**RevokeUserSessions**](UserSessionsApi.md#revokeusersessions) | **DELETE** /api/v1/users/{userId}/sessions | Revoke all user sessions


<a name="endusersessions"></a>
# **EndUserSessions**
> void EndUserSessions (KeepCurrent keepCurrent = null)

End a current user session

Ends Okta sessions for the currently signed in user. By default, the current session remains active. Use this method in a browser-based app. > **Note:** This operation requires a session cookie for the user. The API token isn't allowed for this operation.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class EndUserSessionsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserSessionsApi(config);
            var keepCurrent = new KeepCurrent(); // KeepCurrent |  (optional) 

            try
            {
                // End a current user session
                apiInstance.EndUserSessions(keepCurrent);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserSessionsApi.EndUserSessions: " + e.Message );
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
 **keepCurrent** | [**KeepCurrent**](KeepCurrent.md)|  | [optional] 

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
| **200** | OK |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="revokeusersessions"></a>
# **RevokeUserSessions**
> void RevokeUserSessions (string userId, bool? oauthTokens = null, bool? forgetDevices = null)

Revoke all user sessions

Revokes all active identity provider sessions of the user. This forces the user to authenticate on the next operation. Optionally revokes OpenID Connect and OAuth refresh and access tokens issued to the user.  You can also clear the user's remembered factors for all devices using the `forgetDevices` parameter. See [forgetDevices](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/UserSessions/#tag/UserSessions/operation/revokeUserSessions!in=query&path=forgetDevices&t=request). > **Note:** This operation doesn't clear the sessions created for web or native apps.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RevokeUserSessionsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserSessionsApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var oauthTokens = false;  // bool? | Revokes issued OpenID Connect and OAuth refresh and access tokens (optional)  (default to false)
            var forgetDevices = true;  // bool? | Clears the user's remembered factors for all devices. > **Note:** This parameter defaults to false in Classic Engine. (optional)  (default to true)

            try
            {
                // Revoke all user sessions
                apiInstance.RevokeUserSessions(userId, oauthTokens, forgetDevices);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserSessionsApi.RevokeUserSessions: " + e.Message );
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
 **oauthTokens** | **bool?**| Revokes issued OpenID Connect and OAuth refresh and access tokens | [optional] [default to false]
 **forgetDevices** | **bool?**| Clears the user&#39;s remembered factors for all devices. &gt; **Note:** This parameter defaults to false in Classic Engine. | [optional] [default to true]

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

