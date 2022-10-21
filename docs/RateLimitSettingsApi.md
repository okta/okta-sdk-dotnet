# Okta.Sdk.Api.RateLimitSettingsApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetRateLimitSettingsAdminNotifications**](RateLimitSettingsApi.md#getratelimitsettingsadminnotifications) | **GET** /api/v1/rate-limit-settings/admin-notifications | Retrieve the Rate Limit Admin Notification Settings
[**GetRateLimitSettingsPerClient**](RateLimitSettingsApi.md#getratelimitsettingsperclient) | **GET** /api/v1/rate-limit-settings/per-client | Retrieve the Per-Client Rate Limit Settings
[**ReplaceRateLimitSettingsAdminNotifications**](RateLimitSettingsApi.md#replaceratelimitsettingsadminnotifications) | **PUT** /api/v1/rate-limit-settings/admin-notifications | Replace the Rate Limit Admin Notification Settings
[**ReplaceRateLimitSettingsPerClient**](RateLimitSettingsApi.md#replaceratelimitsettingsperclient) | **PUT** /api/v1/rate-limit-settings/per-client | Replace the Per-Client Rate Limit Settings


<a name="getratelimitsettingsadminnotifications"></a>
# **GetRateLimitSettingsAdminNotifications**
> RateLimitAdminNotifications GetRateLimitSettingsAdminNotifications ()

Retrieve the Rate Limit Admin Notification Settings

Retrieves the currently configured Rate Limit Admin Notification Settings

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetRateLimitSettingsAdminNotificationsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RateLimitSettingsApi(config);

            try
            {
                // Retrieve the Rate Limit Admin Notification Settings
                RateLimitAdminNotifications result = apiInstance.GetRateLimitSettingsAdminNotifications();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RateLimitSettingsApi.GetRateLimitSettingsAdminNotifications: " + e.Message );
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

[**RateLimitAdminNotifications**](RateLimitAdminNotifications.md)

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

<a name="getratelimitsettingsperclient"></a>
# **GetRateLimitSettingsPerClient**
> PerClientRateLimitSettings GetRateLimitSettingsPerClient ()

Retrieve the Per-Client Rate Limit Settings

Retrieves the currently configured Per-Client Rate Limit Settings

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetRateLimitSettingsPerClientExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RateLimitSettingsApi(config);

            try
            {
                // Retrieve the Per-Client Rate Limit Settings
                PerClientRateLimitSettings result = apiInstance.GetRateLimitSettingsPerClient();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RateLimitSettingsApi.GetRateLimitSettingsPerClient: " + e.Message );
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

[**PerClientRateLimitSettings**](PerClientRateLimitSettings.md)

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

<a name="replaceratelimitsettingsadminnotifications"></a>
# **ReplaceRateLimitSettingsAdminNotifications**
> RateLimitAdminNotifications ReplaceRateLimitSettingsAdminNotifications (RateLimitAdminNotifications rateLimitAdminNotifications)

Replace the Rate Limit Admin Notification Settings

Replaces the Rate Limit Admin Notification Settings and returns the configured properties

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceRateLimitSettingsAdminNotificationsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RateLimitSettingsApi(config);
            var rateLimitAdminNotifications = new RateLimitAdminNotifications(); // RateLimitAdminNotifications | 

            try
            {
                // Replace the Rate Limit Admin Notification Settings
                RateLimitAdminNotifications result = apiInstance.ReplaceRateLimitSettingsAdminNotifications(rateLimitAdminNotifications);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RateLimitSettingsApi.ReplaceRateLimitSettingsAdminNotifications: " + e.Message );
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
 **rateLimitAdminNotifications** | [**RateLimitAdminNotifications**](RateLimitAdminNotifications.md)|  | 

### Return type

[**RateLimitAdminNotifications**](RateLimitAdminNotifications.md)

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
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replaceratelimitsettingsperclient"></a>
# **ReplaceRateLimitSettingsPerClient**
> PerClientRateLimitSettings ReplaceRateLimitSettingsPerClient (PerClientRateLimitSettings perClientRateLimitSettings)

Replace the Per-Client Rate Limit Settings

Replaces the Per-Client Rate Limit Settings and returns the configured properties

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceRateLimitSettingsPerClientExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RateLimitSettingsApi(config);
            var perClientRateLimitSettings = new PerClientRateLimitSettings(); // PerClientRateLimitSettings | 

            try
            {
                // Replace the Per-Client Rate Limit Settings
                PerClientRateLimitSettings result = apiInstance.ReplaceRateLimitSettingsPerClient(perClientRateLimitSettings);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RateLimitSettingsApi.ReplaceRateLimitSettingsPerClient: " + e.Message );
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
 **perClientRateLimitSettings** | [**PerClientRateLimitSettings**](PerClientRateLimitSettings.md)|  | 

### Return type

[**PerClientRateLimitSettings**](PerClientRateLimitSettings.md)

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
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

