# Okta.Sdk.Api.AttackProtectionApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetAuthenticatorSettings**](AttackProtectionApi.md#getauthenticatorsettings) | **GET** /attack-protection/api/v1/authenticator-settings | Retrieve the authenticator settings
[**GetUserLockoutSettings**](AttackProtectionApi.md#getuserlockoutsettings) | **GET** /attack-protection/api/v1/user-lockout-settings | Retrieve the user lockout settings
[**ReplaceAuthenticatorSettings**](AttackProtectionApi.md#replaceauthenticatorsettings) | **PUT** /attack-protection/api/v1/authenticator-settings | Replace the authenticator settings
[**ReplaceUserLockoutSettings**](AttackProtectionApi.md#replaceuserlockoutsettings) | **PUT** /attack-protection/api/v1/user-lockout-settings | Replace the user lockout settings


<a name="getauthenticatorsettings"></a>
# **GetAuthenticatorSettings**
> List&lt;AttackProtectionAuthenticatorSettings&gt; GetAuthenticatorSettings ()

Retrieve the authenticator settings

Retrieves the Authenticator Settings for an org

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetAuthenticatorSettingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AttackProtectionApi(config);

            try
            {
                // Retrieve the authenticator settings
                List<AttackProtectionAuthenticatorSettings> result = apiInstance.GetAuthenticatorSettings().ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AttackProtectionApi.GetAuthenticatorSettings: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List&lt;AttackProtectionAuthenticatorSettings&gt;**](AttackProtectionAuthenticatorSettings.md)

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
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getuserlockoutsettings"></a>
# **GetUserLockoutSettings**
> List&lt;UserLockoutSettings&gt; GetUserLockoutSettings ()

Retrieve the user lockout settings

Retrieves the User Lockout Settings for an org

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetUserLockoutSettingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AttackProtectionApi(config);

            try
            {
                // Retrieve the user lockout settings
                List<UserLockoutSettings> result = apiInstance.GetUserLockoutSettings().ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AttackProtectionApi.GetUserLockoutSettings: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List&lt;UserLockoutSettings&gt;**](UserLockoutSettings.md)

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
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replaceauthenticatorsettings"></a>
# **ReplaceAuthenticatorSettings**
> AttackProtectionAuthenticatorSettings ReplaceAuthenticatorSettings (AttackProtectionAuthenticatorSettings authenticatorSettings)

Replace the authenticator settings

Replaces the Authenticator Settings for an org

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceAuthenticatorSettingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AttackProtectionApi(config);
            var authenticatorSettings = new AttackProtectionAuthenticatorSettings(); // AttackProtectionAuthenticatorSettings | 

            try
            {
                // Replace the authenticator settings
                AttackProtectionAuthenticatorSettings result = apiInstance.ReplaceAuthenticatorSettings(authenticatorSettings);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AttackProtectionApi.ReplaceAuthenticatorSettings: " + e.Message );
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
 **authenticatorSettings** | [**AttackProtectionAuthenticatorSettings**](AttackProtectionAuthenticatorSettings.md)|  | 

### Return type

[**AttackProtectionAuthenticatorSettings**](AttackProtectionAuthenticatorSettings.md)

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
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replaceuserlockoutsettings"></a>
# **ReplaceUserLockoutSettings**
> UserLockoutSettings ReplaceUserLockoutSettings (UserLockoutSettings lockoutSettings)

Replace the user lockout settings

Replaces the User Lockout Settings for an org

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceUserLockoutSettingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AttackProtectionApi(config);
            var lockoutSettings = new UserLockoutSettings(); // UserLockoutSettings | 

            try
            {
                // Replace the user lockout settings
                UserLockoutSettings result = apiInstance.ReplaceUserLockoutSettings(lockoutSettings);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AttackProtectionApi.ReplaceUserLockoutSettings: " + e.Message );
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
 **lockoutSettings** | [**UserLockoutSettings**](UserLockoutSettings.md)|  | 

### Return type

[**UserLockoutSettings**](UserLockoutSettings.md)

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
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

