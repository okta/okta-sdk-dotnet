# Okta.Sdk.Api.CAPTCHAApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateCaptchaInstance**](CAPTCHAApi.md#createcaptchainstance) | **POST** /api/v1/captchas | Create a CAPTCHA instance
[**DeleteCaptchaInstance**](CAPTCHAApi.md#deletecaptchainstance) | **DELETE** /api/v1/captchas/{captchaId} | Delete a CAPTCHA Instance
[**GetCaptchaInstance**](CAPTCHAApi.md#getcaptchainstance) | **GET** /api/v1/captchas/{captchaId} | Retrieve a CAPTCHA Instance
[**ListCaptchaInstances**](CAPTCHAApi.md#listcaptchainstances) | **GET** /api/v1/captchas | List all CAPTCHA instances
[**PartialUpdateCaptchaInstance**](CAPTCHAApi.md#partialupdatecaptchainstance) | **POST** /api/v1/captchas/{captchaId} | Update a CAPTCHA instance
[**UpdateCaptchaInstance**](CAPTCHAApi.md#updatecaptchainstance) | **PUT** /api/v1/captchas/{captchaId} | Replace a CAPTCHA instance


<a name="createcaptchainstance"></a>
# **CreateCaptchaInstance**
> CAPTCHAInstance CreateCaptchaInstance (CAPTCHAInstance instance)

Create a CAPTCHA instance

Adds a new CAPTCHA instance to your organization. In the current release, we only allow one CAPTCHA instance per org.

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

Delete a CAPTCHA instance by `captchaId`. If the CAPTCHA instance is currently being used in the org, the delete will not be allowed.

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
            var captchaId = abcd1234;  // string | id of the CAPTCHA

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
 **captchaId** | **string**| id of the CAPTCHA | 

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

Fetches a CAPTCHA instance by `captchaId`.

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
            var captchaId = abcd1234;  // string | id of the CAPTCHA

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
 **captchaId** | **string**| id of the CAPTCHA | 

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

<a name="listcaptchainstances"></a>
# **ListCaptchaInstances**
> List&lt;CAPTCHAInstance&gt; ListCaptchaInstances ()

List all CAPTCHA instances

Enumerates CAPTCHA instances in your organization with pagination. A subset of CAPTCHA instances can be returned that match a supported filter expression or query.

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
                // List all CAPTCHA instances
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

<a name="partialupdatecaptchainstance"></a>
# **PartialUpdateCaptchaInstance**
> CAPTCHAInstance PartialUpdateCaptchaInstance (string captchaId, CAPTCHAInstance instance)

Update a CAPTCHA instance

Partially update a CAPTCHA instance by `captchaId`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class PartialUpdateCaptchaInstanceExample
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
            var captchaId = abcd1234;  // string | id of the CAPTCHA
            var instance = new CAPTCHAInstance(); // CAPTCHAInstance | 

            try
            {
                // Update a CAPTCHA instance
                CAPTCHAInstance result = apiInstance.PartialUpdateCaptchaInstance(captchaId, instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CAPTCHAApi.PartialUpdateCaptchaInstance: " + e.Message );
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
 **captchaId** | **string**| id of the CAPTCHA | 
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

<a name="updatecaptchainstance"></a>
# **UpdateCaptchaInstance**
> CAPTCHAInstance UpdateCaptchaInstance (string captchaId, CAPTCHAInstance instance)

Replace a CAPTCHA instance

Update a CAPTCHA instance by `captchaId`.

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
            var captchaId = abcd1234;  // string | id of the CAPTCHA
            var instance = new CAPTCHAInstance(); // CAPTCHAInstance | 

            try
            {
                // Replace a CAPTCHA instance
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
 **captchaId** | **string**| id of the CAPTCHA | 
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

