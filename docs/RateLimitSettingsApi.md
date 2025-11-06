# Okta.Sdk.Api.RateLimitSettingsApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetRateLimitSettingsAdminNotifications**](RateLimitSettingsApi.md#getratelimitsettingsadminnotifications) | **GET** /api/v1/rate-limit-settings/admin-notifications | Retrieve the rate limit admin notification settings
[**GetRateLimitSettingsPerClient**](RateLimitSettingsApi.md#getratelimitsettingsperclient) | **GET** /api/v1/rate-limit-settings/per-client | Retrieve the per-client rate limit settings
[**GetRateLimitSettingsWarningThreshold**](RateLimitSettingsApi.md#getratelimitsettingswarningthreshold) | **GET** /api/v1/rate-limit-settings/warning-threshold | Retrieve the rate limit warning threshold percentage
[**ReplaceRateLimitSettingsAdminNotifications**](RateLimitSettingsApi.md#replaceratelimitsettingsadminnotifications) | **PUT** /api/v1/rate-limit-settings/admin-notifications | Replace the rate limit admin notification settings
[**ReplaceRateLimitSettingsPerClient**](RateLimitSettingsApi.md#replaceratelimitsettingsperclient) | **PUT** /api/v1/rate-limit-settings/per-client | Replace the per-client rate limit settings
[**ReplaceRateLimitSettingsWarningThreshold**](RateLimitSettingsApi.md#replaceratelimitsettingswarningthreshold) | **PUT** /api/v1/rate-limit-settings/warning-threshold | Replace the rate limit warning threshold percentage


<a name="getratelimitsettingsadminnotifications"></a>
# **GetRateLimitSettingsAdminNotifications**
> RateLimitAdminNotifications GetRateLimitSettingsAdminNotifications ()

Retrieve the rate limit admin notification settings

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
                // Retrieve the rate limit admin notification settings
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

Retrieve the per-client rate limit settings

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
                // Retrieve the per-client rate limit settings
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

<a name="getratelimitsettingswarningthreshold"></a>
# **GetRateLimitSettingsWarningThreshold**
> RateLimitWarningThresholdResponse GetRateLimitSettingsWarningThreshold ()

Retrieve the rate limit warning threshold percentage

Retrieves the currently configured threshold for warning notifications when the API's rate limit is exceeded

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetRateLimitSettingsWarningThresholdExample
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
                // Retrieve the rate limit warning threshold percentage
                RateLimitWarningThresholdResponse result = apiInstance.GetRateLimitSettingsWarningThreshold();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RateLimitSettingsApi.GetRateLimitSettingsWarningThreshold: " + e.Message );
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

[**RateLimitWarningThresholdResponse**](RateLimitWarningThresholdResponse.md)

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

Replace the rate limit admin notification settings

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
                // Replace the rate limit admin notification settings
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

Replace the per-client rate limit settings

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
                // Replace the per-client rate limit settings
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

<a name="replaceratelimitsettingswarningthreshold"></a>
# **ReplaceRateLimitSettingsWarningThreshold**
> RateLimitWarningThresholdResponse ReplaceRateLimitSettingsWarningThreshold (RateLimitWarningThresholdRequest rateLimitWarningThreshold = null)

Replace the rate limit warning threshold percentage

Replaces the Rate Limit Warning Threshold Percentage and returns the configured property

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceRateLimitSettingsWarningThresholdExample
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
            var rateLimitWarningThreshold = new RateLimitWarningThresholdRequest(); // RateLimitWarningThresholdRequest |  (optional) 

            try
            {
                // Replace the rate limit warning threshold percentage
                RateLimitWarningThresholdResponse result = apiInstance.ReplaceRateLimitSettingsWarningThreshold(rateLimitWarningThreshold);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RateLimitSettingsApi.ReplaceRateLimitSettingsWarningThreshold: " + e.Message );
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
 **rateLimitWarningThreshold** | [**RateLimitWarningThresholdRequest**](RateLimitWarningThresholdRequest.md)|  | [optional] 

### Return type

[**RateLimitWarningThresholdResponse**](RateLimitWarningThresholdResponse.md)

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

