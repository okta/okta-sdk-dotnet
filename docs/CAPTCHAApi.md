# Okta.Sdk.Api.CAPTCHAApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateCaptchaInstance**](CAPTCHAApi.md#createcaptchainstance) | **POST** /api/v1/captchas | Create a CAPTCHA instance
[**DeleteCaptchaInstance**](CAPTCHAApi.md#deletecaptchainstance) | **DELETE** /api/v1/captchas/{captchaId} | Delete a CAPTCHA Instance
[**DeleteOrgCaptchaSettings**](CAPTCHAApi.md#deleteorgcaptchasettings) | **DELETE** /api/v1/org/captcha | Delete the Org-wide CAPTCHA Settings
[**GetCaptchaInstance**](CAPTCHAApi.md#getcaptchainstance) | **GET** /api/v1/captchas/{captchaId} | Retrieve a CAPTCHA Instance
[**GetOrgCaptchaSettings**](CAPTCHAApi.md#getorgcaptchasettings) | **GET** /api/v1/org/captcha | Retrieve the Org-wide CAPTCHA Settings
[**ListCaptchaInstances**](CAPTCHAApi.md#listcaptchainstances) | **GET** /api/v1/captchas | List all CAPTCHA Instances
[**ReplaceCaptchaInstance**](CAPTCHAApi.md#replacecaptchainstance) | **PUT** /api/v1/captchas/{captchaId} | Replace a CAPTCHA Instance
[**ReplacesOrgCaptchaSettings**](CAPTCHAApi.md#replacesorgcaptchasettings) | **PUT** /api/v1/org/captcha | Replace the Org-wide CAPTCHA Settings
[**UpdateCaptchaInstance**](CAPTCHAApi.md#updatecaptchainstance) | **POST** /api/v1/captchas/{captchaId} | Update a CAPTCHA Instance


<a name="createcaptchainstance"></a>
# **CreateCaptchaInstance**
> CAPTCHAInstance CreateCaptchaInstance (CAPTCHAInstance instance)

Create a CAPTCHA instance

Creates a new CAPTCHA instance. Currently, an org can only configure a single CAPTCHA instance.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateCaptchaInstanceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CAPTCHAApi(config);
            var instance = new CAPTCHAInstance(); // CAPTCHAInstance | 

            try
            {
                // Create a CAPTCHA instance
                CAPTCHAInstance result = apiInstance.CreateCaptchaInstance(instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CAPTCHAApi.CreateCaptchaInstance: " + e.Message );
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
 **instance** | [**CAPTCHAInstance**](CAPTCHAInstance.md)|  | 

### Return type

[**CAPTCHAInstance**](CAPTCHAInstance.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletecaptchainstance"></a>
# **DeleteCaptchaInstance**
> void DeleteCaptchaInstance (string captchaId)

Delete a CAPTCHA Instance

Deletes a specified CAPTCHA instance > **Note:** If your CAPTCHA instance is still associated with your org, the request fails. You must first update your Org-wide CAPTCHA settings to remove the CAPTCHA instance.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteCaptchaInstanceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CAPTCHAApi(config);
            var captchaId = "captchaId_example";  // string | The unique key used to identify your CAPTCHA instance

            try
            {
                // Delete a CAPTCHA Instance
                apiInstance.DeleteCaptchaInstance(captchaId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CAPTCHAApi.DeleteCaptchaInstance: " + e.Message );
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
 **captchaId** | **string**| The unique key used to identify your CAPTCHA instance | 

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

<a name="deleteorgcaptchasettings"></a>
# **DeleteOrgCaptchaSettings**
> void DeleteOrgCaptchaSettings ()

Delete the Org-wide CAPTCHA Settings

Deletes the CAPTCHA settings object for your organization

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteOrgCaptchaSettingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CAPTCHAApi(config);

            try
            {
                // Delete the Org-wide CAPTCHA Settings
                apiInstance.DeleteOrgCaptchaSettings();
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CAPTCHAApi.DeleteOrgCaptchaSettings: " + e.Message );
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

<a name="getcaptchainstance"></a>
# **GetCaptchaInstance**
> CAPTCHAInstance GetCaptchaInstance (string captchaId)

Retrieve a CAPTCHA Instance

Retrieves the properties of a specified CAPTCHA instance

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetCaptchaInstanceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CAPTCHAApi(config);
            var captchaId = "captchaId_example";  // string | The unique key used to identify your CAPTCHA instance

            try
            {
                // Retrieve a CAPTCHA Instance
                CAPTCHAInstance result = apiInstance.GetCaptchaInstance(captchaId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CAPTCHAApi.GetCaptchaInstance: " + e.Message );
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
 **captchaId** | **string**| The unique key used to identify your CAPTCHA instance | 

### Return type

[**CAPTCHAInstance**](CAPTCHAInstance.md)

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
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getorgcaptchasettings"></a>
# **GetOrgCaptchaSettings**
> OrgCAPTCHASettings GetOrgCaptchaSettings ()

Retrieve the Org-wide CAPTCHA Settings

Retrieves the CAPTCHA settings object for your organization. > **Note**: If the current organization hasn't configured CAPTCHA Settings, the request returns an empty object.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetOrgCaptchaSettingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CAPTCHAApi(config);

            try
            {
                // Retrieve the Org-wide CAPTCHA Settings
                OrgCAPTCHASettings result = apiInstance.GetOrgCaptchaSettings();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CAPTCHAApi.GetOrgCaptchaSettings: " + e.Message );
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

[**OrgCAPTCHASettings**](OrgCAPTCHASettings.md)

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

<a name="listcaptchainstances"></a>
# **ListCaptchaInstances**
> List&lt;CAPTCHAInstance&gt; ListCaptchaInstances ()

List all CAPTCHA Instances

Lists all CAPTCHA instances with pagination support. A subset of CAPTCHA instances can be returned that match a supported filter expression or query.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListCaptchaInstancesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CAPTCHAApi(config);

            try
            {
                // List all CAPTCHA Instances
                List<CAPTCHAInstance> result = apiInstance.ListCaptchaInstances().ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CAPTCHAApi.ListCaptchaInstances: " + e.Message );
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

[**List&lt;CAPTCHAInstance&gt;**](CAPTCHAInstance.md)

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

<a name="replacecaptchainstance"></a>
# **ReplaceCaptchaInstance**
> CAPTCHAInstance ReplaceCaptchaInstance (string captchaId, CAPTCHAInstance instance)

Replace a CAPTCHA Instance

Replaces the properties for a specified CAPTCHA instance

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceCaptchaInstanceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CAPTCHAApi(config);
            var captchaId = "captchaId_example";  // string | The unique key used to identify your CAPTCHA instance
            var instance = new CAPTCHAInstance(); // CAPTCHAInstance | 

            try
            {
                // Replace a CAPTCHA Instance
                CAPTCHAInstance result = apiInstance.ReplaceCaptchaInstance(captchaId, instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CAPTCHAApi.ReplaceCaptchaInstance: " + e.Message );
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
 **captchaId** | **string**| The unique key used to identify your CAPTCHA instance | 
 **instance** | [**CAPTCHAInstance**](CAPTCHAInstance.md)|  | 

### Return type

[**CAPTCHAInstance**](CAPTCHAInstance.md)

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
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacesorgcaptchasettings"></a>
# **ReplacesOrgCaptchaSettings**
> OrgCAPTCHASettings ReplacesOrgCaptchaSettings (OrgCAPTCHASettings orgCAPTCHASettings)

Replace the Org-wide CAPTCHA Settings

Replaces the CAPTCHA settings object for your organization. > **Note**: You can disable CAPTCHA for your organization by setting `captchaId` and `enabledPages` to `null`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplacesOrgCaptchaSettingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CAPTCHAApi(config);
            var orgCAPTCHASettings = new OrgCAPTCHASettings(); // OrgCAPTCHASettings | 

            try
            {
                // Replace the Org-wide CAPTCHA Settings
                OrgCAPTCHASettings result = apiInstance.ReplacesOrgCaptchaSettings(orgCAPTCHASettings);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CAPTCHAApi.ReplacesOrgCaptchaSettings: " + e.Message );
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
 **orgCAPTCHASettings** | [**OrgCAPTCHASettings**](OrgCAPTCHASettings.md)|  | 

### Return type

[**OrgCAPTCHASettings**](OrgCAPTCHASettings.md)

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

<a name="updatecaptchainstance"></a>
# **UpdateCaptchaInstance**
> CAPTCHAInstance UpdateCaptchaInstance (string captchaId, CAPTCHAInstance instance)

Update a CAPTCHA Instance

Partially updates the properties of a specified CAPTCHA instance

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateCaptchaInstanceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CAPTCHAApi(config);
            var captchaId = "captchaId_example";  // string | The unique key used to identify your CAPTCHA instance
            var instance = new CAPTCHAInstance(); // CAPTCHAInstance | 

            try
            {
                // Update a CAPTCHA Instance
                CAPTCHAInstance result = apiInstance.UpdateCaptchaInstance(captchaId, instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CAPTCHAApi.UpdateCaptchaInstance: " + e.Message );
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
 **captchaId** | **string**| The unique key used to identify your CAPTCHA instance | 
 **instance** | [**CAPTCHAInstance**](CAPTCHAInstance.md)|  | 

### Return type

[**CAPTCHAInstance**](CAPTCHAInstance.md)

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
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

