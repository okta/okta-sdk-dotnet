# Okta.Sdk.Api.TemplateApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateSmsTemplate**](TemplateApi.md#createsmstemplate) | **POST** /api/v1/templates/sms | Create an SMS Template
[**DeleteSmsTemplate**](TemplateApi.md#deletesmstemplate) | **DELETE** /api/v1/templates/sms/{templateId} | Delete an SMS Template
[**GetSmsTemplate**](TemplateApi.md#getsmstemplate) | **GET** /api/v1/templates/sms/{templateId} | Retrieve an SMS Template
[**ListSmsTemplates**](TemplateApi.md#listsmstemplates) | **GET** /api/v1/templates/sms | List all SMS Templates
[**ReplaceSmsTemplate**](TemplateApi.md#replacesmstemplate) | **PUT** /api/v1/templates/sms/{templateId} | Replace an SMS Template
[**UpdateSmsTemplate**](TemplateApi.md#updatesmstemplate) | **POST** /api/v1/templates/sms/{templateId} | Update an SMS Template


<a name="createsmstemplate"></a>
# **CreateSmsTemplate**
> SmsTemplate CreateSmsTemplate (SmsTemplate smsTemplate)

Create an SMS Template

Creates a new custom SMS template

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateSmsTemplateExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TemplateApi(config);
            var smsTemplate = new SmsTemplate(); // SmsTemplate | 

            try
            {
                // Create an SMS Template
                SmsTemplate result = apiInstance.CreateSmsTemplate(smsTemplate);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TemplateApi.CreateSmsTemplate: " + e.Message );
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
 **smsTemplate** | [**SmsTemplate**](SmsTemplate.md)|  | 

### Return type

[**SmsTemplate**](SmsTemplate.md)

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

<a name="deletesmstemplate"></a>
# **DeleteSmsTemplate**
> void DeleteSmsTemplate (string templateId)

Delete an SMS Template

Deletes an SMS template

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteSmsTemplateExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TemplateApi(config);
            var templateId = 6NQUJ5yR3bpgEiYmq8IC;  // string | `id` of the Template

            try
            {
                // Delete an SMS Template
                apiInstance.DeleteSmsTemplate(templateId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TemplateApi.DeleteSmsTemplate: " + e.Message );
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
 **templateId** | **string**| &#x60;id&#x60; of the Template | 

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

<a name="getsmstemplate"></a>
# **GetSmsTemplate**
> SmsTemplate GetSmsTemplate (string templateId)

Retrieve an SMS Template

Retrieves a specific template by `id`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetSmsTemplateExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TemplateApi(config);
            var templateId = 6NQUJ5yR3bpgEiYmq8IC;  // string | `id` of the Template

            try
            {
                // Retrieve an SMS Template
                SmsTemplate result = apiInstance.GetSmsTemplate(templateId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TemplateApi.GetSmsTemplate: " + e.Message );
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
 **templateId** | **string**| &#x60;id&#x60; of the Template | 

### Return type

[**SmsTemplate**](SmsTemplate.md)

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
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listsmstemplates"></a>
# **ListSmsTemplates**
> List&lt;SmsTemplate&gt; ListSmsTemplates (SmsTemplateType? templateType = null)

List all SMS Templates

Lists all custom SMS templates. A subset of templates can be returned that match a template type.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListSmsTemplatesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TemplateApi(config);
            var templateType = (SmsTemplateType) "SMS_VERIFY_CODE";  // SmsTemplateType? |  (optional) 

            try
            {
                // List all SMS Templates
                List<SmsTemplate> result = apiInstance.ListSmsTemplates(templateType).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TemplateApi.ListSmsTemplates: " + e.Message );
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
 **templateType** | **SmsTemplateType?**|  | [optional] 

### Return type

[**List&lt;SmsTemplate&gt;**](SmsTemplate.md)

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

<a name="replacesmstemplate"></a>
# **ReplaceSmsTemplate**
> SmsTemplate ReplaceSmsTemplate (string templateId, SmsTemplate smsTemplate)

Replace an SMS Template

Replaces the SMS Template > **Notes:** You can't update the default SMS Template. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceSmsTemplateExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TemplateApi(config);
            var templateId = 6NQUJ5yR3bpgEiYmq8IC;  // string | `id` of the Template
            var smsTemplate = new SmsTemplate(); // SmsTemplate | 

            try
            {
                // Replace an SMS Template
                SmsTemplate result = apiInstance.ReplaceSmsTemplate(templateId, smsTemplate);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TemplateApi.ReplaceSmsTemplate: " + e.Message );
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
 **templateId** | **string**| &#x60;id&#x60; of the Template | 
 **smsTemplate** | [**SmsTemplate**](SmsTemplate.md)|  | 

### Return type

[**SmsTemplate**](SmsTemplate.md)

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
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatesmstemplate"></a>
# **UpdateSmsTemplate**
> SmsTemplate UpdateSmsTemplate (string templateId, SmsTemplate smsTemplate)

Update an SMS Template

Updates only some of the SMS Template properties:   * All properties within the custom SMS Template that have values are updated.   * Any translation that doesn't exist is added.   * Any translation with a null or empty value is removed.   * Any translation with non-empty/null value is updated. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateSmsTemplateExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TemplateApi(config);
            var templateId = 6NQUJ5yR3bpgEiYmq8IC;  // string | `id` of the Template
            var smsTemplate = new SmsTemplate(); // SmsTemplate | 

            try
            {
                // Update an SMS Template
                SmsTemplate result = apiInstance.UpdateSmsTemplate(templateId, smsTemplate);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TemplateApi.UpdateSmsTemplate: " + e.Message );
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
 **templateId** | **string**| &#x60;id&#x60; of the Template | 
 **smsTemplate** | [**SmsTemplate**](SmsTemplate.md)|  | 

### Return type

[**SmsTemplate**](SmsTemplate.md)

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
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

