# Okta.Sdk.Api.DeviceAccessApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetDesktopMFAEnforceNumberMatchingChallengeOrgSetting**](DeviceAccessApi.md#getdesktopmfaenforcenumbermatchingchallengeorgsetting) | **GET** /device-access/api/v1/desktop-mfa/enforce-number-matching-challenge-settings | Retrieve the Desktop MFA Enforce Number Matching Challenge org setting
[**GetDesktopMFARecoveryPinOrgSetting**](DeviceAccessApi.md#getdesktopmfarecoverypinorgsetting) | **GET** /device-access/api/v1/desktop-mfa/recovery-pin-settings | Retrieve the Desktop MFA Recovery PIN org setting
[**ReplaceDesktopMFAEnforceNumberMatchingChallengeOrgSetting**](DeviceAccessApi.md#replacedesktopmfaenforcenumbermatchingchallengeorgsetting) | **PUT** /device-access/api/v1/desktop-mfa/enforce-number-matching-challenge-settings | Replace the Desktop MFA Enforce Number Matching Challenge org setting
[**ReplaceDesktopMFARecoveryPinOrgSetting**](DeviceAccessApi.md#replacedesktopmfarecoverypinorgsetting) | **PUT** /device-access/api/v1/desktop-mfa/recovery-pin-settings | Replace the Desktop MFA Recovery PIN org setting


<a name="getdesktopmfaenforcenumbermatchingchallengeorgsetting"></a>
# **GetDesktopMFAEnforceNumberMatchingChallengeOrgSetting**
> DesktopMFAEnforceNumberMatchingChallengeOrgSetting GetDesktopMFAEnforceNumberMatchingChallengeOrgSetting ()

Retrieve the Desktop MFA Enforce Number Matching Challenge org setting

Retrieves the status of the Desktop MFA Enforce Number Matching Challenge push notifications feature. That is, whether or not the feature is enabled for your org.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetDesktopMFAEnforceNumberMatchingChallengeOrgSettingExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DeviceAccessApi(config);

            try
            {
                // Retrieve the Desktop MFA Enforce Number Matching Challenge org setting
                DesktopMFAEnforceNumberMatchingChallengeOrgSetting result = apiInstance.GetDesktopMFAEnforceNumberMatchingChallengeOrgSetting();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DeviceAccessApi.GetDesktopMFAEnforceNumberMatchingChallengeOrgSetting: " + e.Message );
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

[**DesktopMFAEnforceNumberMatchingChallengeOrgSetting**](DesktopMFAEnforceNumberMatchingChallengeOrgSetting.md)

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

<a name="getdesktopmfarecoverypinorgsetting"></a>
# **GetDesktopMFARecoveryPinOrgSetting**
> DesktopMFARecoveryPinOrgSetting GetDesktopMFARecoveryPinOrgSetting ()

Retrieve the Desktop MFA Recovery PIN org setting

Retrieves the status of the Desktop MFA Recovery PIN feature. That is, whether or not the feature is enabled for your org.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetDesktopMFARecoveryPinOrgSettingExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DeviceAccessApi(config);

            try
            {
                // Retrieve the Desktop MFA Recovery PIN org setting
                DesktopMFARecoveryPinOrgSetting result = apiInstance.GetDesktopMFARecoveryPinOrgSetting();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DeviceAccessApi.GetDesktopMFARecoveryPinOrgSetting: " + e.Message );
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

[**DesktopMFARecoveryPinOrgSetting**](DesktopMFARecoveryPinOrgSetting.md)

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

<a name="replacedesktopmfaenforcenumbermatchingchallengeorgsetting"></a>
# **ReplaceDesktopMFAEnforceNumberMatchingChallengeOrgSetting**
> DesktopMFAEnforceNumberMatchingChallengeOrgSetting ReplaceDesktopMFAEnforceNumberMatchingChallengeOrgSetting (DesktopMFAEnforceNumberMatchingChallengeOrgSetting desktopMFAEnforceNumberMatchingChallengeOrgSetting)

Replace the Desktop MFA Enforce Number Matching Challenge org setting

Replaces the status of the Desktop MFA Enforce Number Matching Challenge push notifications feature. That is, whether or not the feature is enabled for your org.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceDesktopMFAEnforceNumberMatchingChallengeOrgSettingExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DeviceAccessApi(config);
            var desktopMFAEnforceNumberMatchingChallengeOrgSetting = new DesktopMFAEnforceNumberMatchingChallengeOrgSetting(); // DesktopMFAEnforceNumberMatchingChallengeOrgSetting | 

            try
            {
                // Replace the Desktop MFA Enforce Number Matching Challenge org setting
                DesktopMFAEnforceNumberMatchingChallengeOrgSetting result = apiInstance.ReplaceDesktopMFAEnforceNumberMatchingChallengeOrgSetting(desktopMFAEnforceNumberMatchingChallengeOrgSetting);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DeviceAccessApi.ReplaceDesktopMFAEnforceNumberMatchingChallengeOrgSetting: " + e.Message );
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
 **desktopMFAEnforceNumberMatchingChallengeOrgSetting** | [**DesktopMFAEnforceNumberMatchingChallengeOrgSetting**](DesktopMFAEnforceNumberMatchingChallengeOrgSetting.md)|  | 

### Return type

[**DesktopMFAEnforceNumberMatchingChallengeOrgSetting**](DesktopMFAEnforceNumberMatchingChallengeOrgSetting.md)

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

<a name="replacedesktopmfarecoverypinorgsetting"></a>
# **ReplaceDesktopMFARecoveryPinOrgSetting**
> DesktopMFARecoveryPinOrgSetting ReplaceDesktopMFARecoveryPinOrgSetting (DesktopMFARecoveryPinOrgSetting desktopMFARecoveryPinOrgSetting)

Replace the Desktop MFA Recovery PIN org setting

Replaces the Desktop MFA Recovery PIN feature for your org

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceDesktopMFARecoveryPinOrgSettingExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DeviceAccessApi(config);
            var desktopMFARecoveryPinOrgSetting = new DesktopMFARecoveryPinOrgSetting(); // DesktopMFARecoveryPinOrgSetting | 

            try
            {
                // Replace the Desktop MFA Recovery PIN org setting
                DesktopMFARecoveryPinOrgSetting result = apiInstance.ReplaceDesktopMFARecoveryPinOrgSetting(desktopMFARecoveryPinOrgSetting);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DeviceAccessApi.ReplaceDesktopMFARecoveryPinOrgSetting: " + e.Message );
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
 **desktopMFARecoveryPinOrgSetting** | [**DesktopMFARecoveryPinOrgSetting**](DesktopMFARecoveryPinOrgSetting.md)|  | 

### Return type

[**DesktopMFARecoveryPinOrgSetting**](DesktopMFARecoveryPinOrgSetting.md)

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

