# Okta.Sdk.Api.OktaApplicationSettingsApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetFirstPartyAppSettings**](OktaApplicationSettingsApi.md#getfirstpartyappsettings) | **GET** /api/v1/first-party-app-settings/{appName} | Retrieve the Okta application settings
[**ReplaceFirstPartyAppSettings**](OktaApplicationSettingsApi.md#replacefirstpartyappsettings) | **PUT** /api/v1/first-party-app-settings/{appName} | Replace the Okta application settings


<a name="getfirstpartyappsettings"></a>
# **GetFirstPartyAppSettings**
> AdminConsoleSettings GetFirstPartyAppSettings (string appName)

Retrieve the Okta application settings

Retrieves the settings for an Okta app (also known as an Okta first-party app)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetFirstPartyAppSettingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OktaApplicationSettingsApi(config);
            var appName = admin-console;  // string | The key name for the Okta app.<br> Supported apps:   * Okta Admin Console (`admin-console`) 

            try
            {
                // Retrieve the Okta application settings
                AdminConsoleSettings result = apiInstance.GetFirstPartyAppSettings(appName);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OktaApplicationSettingsApi.GetFirstPartyAppSettings: " + e.Message );
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
 **appName** | **string**| The key name for the Okta app.&lt;br&gt; Supported apps:   * Okta Admin Console (&#x60;admin-console&#x60;)  | 

### Return type

[**AdminConsoleSettings**](AdminConsoleSettings.md)

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

<a name="replacefirstpartyappsettings"></a>
# **ReplaceFirstPartyAppSettings**
> AdminConsoleSettings ReplaceFirstPartyAppSettings (string appName, AdminConsoleSettings adminConsoleSettings)

Replace the Okta application settings

Replaces the settings for an Okta app (also known as an Okta first-party app)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceFirstPartyAppSettingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OktaApplicationSettingsApi(config);
            var appName = admin-console;  // string | The key name for the Okta app.<br> Supported apps:   * Okta Admin Console (`admin-console`) 
            var adminConsoleSettings = new AdminConsoleSettings(); // AdminConsoleSettings | 

            try
            {
                // Replace the Okta application settings
                AdminConsoleSettings result = apiInstance.ReplaceFirstPartyAppSettings(appName, adminConsoleSettings);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OktaApplicationSettingsApi.ReplaceFirstPartyAppSettings: " + e.Message );
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
 **appName** | **string**| The key name for the Okta app.&lt;br&gt; Supported apps:   * Okta Admin Console (&#x60;admin-console&#x60;)  | 
 **adminConsoleSettings** | [**AdminConsoleSettings**](AdminConsoleSettings.md)|  | 

### Return type

[**AdminConsoleSettings**](AdminConsoleSettings.md)

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

