# Okta.Sdk.Api.OrgSettingCommunicationApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetOktaCommunicationSettings**](OrgSettingCommunicationApi.md#getoktacommunicationsettings) | **GET** /api/v1/org/privacy/oktaCommunication | Retrieve the Okta communication settings
[**OptInUsersToOktaCommunicationEmails**](OrgSettingCommunicationApi.md#optinuserstooktacommunicationemails) | **POST** /api/v1/org/privacy/oktaCommunication/optIn | Opt in to Okta user communication emails
[**OptOutUsersFromOktaCommunicationEmails**](OrgSettingCommunicationApi.md#optoutusersfromoktacommunicationemails) | **POST** /api/v1/org/privacy/oktaCommunication/optOut | Opt out of Okta user communication emails


<a name="getoktacommunicationsettings"></a>
# **GetOktaCommunicationSettings**
> OrgOktaCommunicationSetting GetOktaCommunicationSettings ()

Retrieve the Okta communication settings

Retrieves Okta Communication Settings of your org

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetOktaCommunicationSettingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrgSettingCommunicationApi(config);

            try
            {
                // Retrieve the Okta communication settings
                OrgOktaCommunicationSetting result = apiInstance.GetOktaCommunicationSettings();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrgSettingCommunicationApi.GetOktaCommunicationSettings: " + e.Message );
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

[**OrgOktaCommunicationSetting**](OrgOktaCommunicationSetting.md)

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

<a name="optinuserstooktacommunicationemails"></a>
# **OptInUsersToOktaCommunicationEmails**
> OrgOktaCommunicationSetting OptInUsersToOktaCommunicationEmails ()

Opt in to Okta user communication emails

Opts in all users of this org to Okta communication emails

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class OptInUsersToOktaCommunicationEmailsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrgSettingCommunicationApi(config);

            try
            {
                // Opt in to Okta user communication emails
                OrgOktaCommunicationSetting result = apiInstance.OptInUsersToOktaCommunicationEmails();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrgSettingCommunicationApi.OptInUsersToOktaCommunicationEmails: " + e.Message );
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

[**OrgOktaCommunicationSetting**](OrgOktaCommunicationSetting.md)

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

<a name="optoutusersfromoktacommunicationemails"></a>
# **OptOutUsersFromOktaCommunicationEmails**
> OrgOktaCommunicationSetting OptOutUsersFromOktaCommunicationEmails ()

Opt out of Okta user communication emails

Opts out all users of this org from Okta communication emails

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class OptOutUsersFromOktaCommunicationEmailsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrgSettingCommunicationApi(config);

            try
            {
                // Opt out of Okta user communication emails
                OrgOktaCommunicationSetting result = apiInstance.OptOutUsersFromOktaCommunicationEmails();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrgSettingCommunicationApi.OptOutUsersFromOktaCommunicationEmails: " + e.Message );
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

[**OrgOktaCommunicationSetting**](OrgOktaCommunicationSetting.md)

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

