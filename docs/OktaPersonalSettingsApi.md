# Okta.Sdk.Api.OktaPersonalSettingsApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ListPersonalAppsExportBlockList**](OktaPersonalSettingsApi.md#listpersonalappsexportblocklist) | **GET** /okta-personal-settings/api/v1/export-blocklists | List all blocked email domains
[**ReplaceBlockedEmailDomains**](OktaPersonalSettingsApi.md#replaceblockedemaildomains) | **PUT** /okta-personal-settings/api/v1/export-blocklists | Replace the blocked email domains
[**ReplaceOktaPersonalAdminSettings**](OktaPersonalSettingsApi.md#replaceoktapersonaladminsettings) | **PUT** /okta-personal-settings/api/v1/edit-feature | Replace the Okta Personal admin settings


<a name="listpersonalappsexportblocklist"></a>
# **ListPersonalAppsExportBlockList**
> PersonalAppsBlockList ListPersonalAppsExportBlockList ()

List all blocked email domains

Lists all blocked email domains which are excluded from app migration

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListPersonalAppsExportBlockListExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OktaPersonalSettingsApi(config);

            try
            {
                // List all blocked email domains
                PersonalAppsBlockList result = apiInstance.ListPersonalAppsExportBlockList();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OktaPersonalSettingsApi.ListPersonalAppsExportBlockList: " + e.Message );
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

[**PersonalAppsBlockList**](PersonalAppsBlockList.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replaceblockedemaildomains"></a>
# **ReplaceBlockedEmailDomains**
> void ReplaceBlockedEmailDomains (PersonalAppsBlockList personalAppsBlockList)

Replace the blocked email domains

Replaces the list of blocked email domains which are excluded from app migration

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceBlockedEmailDomainsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OktaPersonalSettingsApi(config);
            var personalAppsBlockList = new PersonalAppsBlockList(); // PersonalAppsBlockList | 

            try
            {
                // Replace the blocked email domains
                apiInstance.ReplaceBlockedEmailDomains(personalAppsBlockList);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OktaPersonalSettingsApi.ReplaceBlockedEmailDomains: " + e.Message );
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
 **personalAppsBlockList** | [**PersonalAppsBlockList**](PersonalAppsBlockList.md)|  | 

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
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replaceoktapersonaladminsettings"></a>
# **ReplaceOktaPersonalAdminSettings**
> void ReplaceOktaPersonalAdminSettings (OktaPersonalAdminFeatureSettings oktaPersonalAdminFeatureSettings)

Replace the Okta Personal admin settings

Replaces Okta Personal admin settings in a Workforce org

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceOktaPersonalAdminSettingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OktaPersonalSettingsApi(config);
            var oktaPersonalAdminFeatureSettings = new OktaPersonalAdminFeatureSettings(); // OktaPersonalAdminFeatureSettings | 

            try
            {
                // Replace the Okta Personal admin settings
                apiInstance.ReplaceOktaPersonalAdminSettings(oktaPersonalAdminFeatureSettings);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OktaPersonalSettingsApi.ReplaceOktaPersonalAdminSettings: " + e.Message );
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
 **oktaPersonalAdminFeatureSettings** | [**OktaPersonalAdminFeatureSettings**](OktaPersonalAdminFeatureSettings.md)|  | 

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
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

