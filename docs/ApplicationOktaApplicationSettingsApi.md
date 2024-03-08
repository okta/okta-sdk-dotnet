# Okta.Sdk.Api.ApplicationOktaApplicationSettingsApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetFirstPartyAppSettings**](ApplicationOktaApplicationSettingsApi.md#getfirstpartyappsettings) | **GET** /api/v1/first-party-app-settings/{appName} | Retrieve the Okta app settings
[**ReplaceFirstPartyAppSettings**](ApplicationOktaApplicationSettingsApi.md#replacefirstpartyappsettings) | **PUT** /api/v1/first-party-app-settings/{appName} | Replace the Okta app settings


<a name="getfirstpartyappsettings"></a>
# **GetFirstPartyAppSettings**
> AdminConsoleSettings GetFirstPartyAppSettings (string appName)

Retrieve the Okta app settings

Retrieves the settings for the first party Okta app

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

            var apiInstance = new ApplicationOktaApplicationSettingsApi(config);
            var appName = admin-console;  // string | `appName` of the application

            try
            {
                // Retrieve the Okta app settings
                AdminConsoleSettings result = apiInstance.GetFirstPartyAppSettings(appName);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationOktaApplicationSettingsApi.GetFirstPartyAppSettings: " + e.Message );
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
 **appName** | **string**| &#x60;appName&#x60; of the application | 

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

Replace the Okta app settings

Replaces the settings for the first party Okta app

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

            var apiInstance = new ApplicationOktaApplicationSettingsApi(config);
            var appName = admin-console;  // string | `appName` of the application
            var adminConsoleSettings = new AdminConsoleSettings(); // AdminConsoleSettings | 

            try
            {
                // Replace the Okta app settings
                AdminConsoleSettings result = apiInstance.ReplaceFirstPartyAppSettings(appName, adminConsoleSettings);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationOktaApplicationSettingsApi.ReplaceFirstPartyAppSettings: " + e.Message );
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
 **appName** | **string**| &#x60;appName&#x60; of the application | 
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

