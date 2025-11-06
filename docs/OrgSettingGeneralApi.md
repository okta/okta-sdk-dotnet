# Okta.Sdk.Api.OrgSettingGeneralApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetOrgSettings**](OrgSettingGeneralApi.md#getorgsettings) | **GET** /api/v1/org | Retrieve the Org general settings
[**ReplaceOrgSettings**](OrgSettingGeneralApi.md#replaceorgsettings) | **PUT** /api/v1/org | Replace the Org general settings
[**UpdateOrgSettings**](OrgSettingGeneralApi.md#updateorgsettings) | **POST** /api/v1/org | Update the Org general settings


<a name="getorgsettings"></a>
# **GetOrgSettings**
> OrgSetting GetOrgSettings ()

Retrieve the Org general settings

Retrieves the Org General Settings

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetOrgSettingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrgSettingGeneralApi(config);

            try
            {
                // Retrieve the Org general settings
                OrgSetting result = apiInstance.GetOrgSettings();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrgSettingGeneralApi.GetOrgSettings: " + e.Message );
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

[**OrgSetting**](OrgSetting.md)

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
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replaceorgsettings"></a>
# **ReplaceOrgSettings**
> OrgSetting ReplaceOrgSettings (OrgSetting orgSetting)

Replace the Org general settings

Replaces the Org General Settings for your Okta org

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceOrgSettingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrgSettingGeneralApi(config);
            var orgSetting = new OrgSetting(); // OrgSetting | 

            try
            {
                // Replace the Org general settings
                OrgSetting result = apiInstance.ReplaceOrgSettings(orgSetting);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrgSettingGeneralApi.ReplaceOrgSettings: " + e.Message );
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
 **orgSetting** | [**OrgSetting**](OrgSetting.md)|  | 

### Return type

[**OrgSetting**](OrgSetting.md)

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

<a name="updateorgsettings"></a>
# **UpdateOrgSettings**
> OrgSetting UpdateOrgSettings (OrgSetting orgSetting = null)

Update the Org general settings

Updates partial Org General Settings

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateOrgSettingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrgSettingGeneralApi(config);
            var orgSetting = new OrgSetting(); // OrgSetting |  (optional) 

            try
            {
                // Update the Org general settings
                OrgSetting result = apiInstance.UpdateOrgSettings(orgSetting);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrgSettingGeneralApi.UpdateOrgSettings: " + e.Message );
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
 **orgSetting** | [**OrgSetting**](OrgSetting.md)|  | [optional] 

### Return type

[**OrgSetting**](OrgSetting.md)

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

