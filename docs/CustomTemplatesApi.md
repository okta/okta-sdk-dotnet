# Okta.Sdk.Api.CustomTemplatesApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateEmailCustomization**](CustomTemplatesApi.md#createemailcustomization) | **POST** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations | Create an email customization
[**DeleteAllCustomizations**](CustomTemplatesApi.md#deleteallcustomizations) | **DELETE** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations | Delete all email customizations
[**DeleteEmailCustomization**](CustomTemplatesApi.md#deleteemailcustomization) | **DELETE** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId} | Delete an email customization
[**GetCustomizationPreview**](CustomTemplatesApi.md#getcustomizationpreview) | **GET** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId}/preview | Retrieve a preview of an email customization
[**GetEmailCustomization**](CustomTemplatesApi.md#getemailcustomization) | **GET** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId} | Retrieve an email customization
[**GetEmailDefaultContent**](CustomTemplatesApi.md#getemaildefaultcontent) | **GET** /api/v1/brands/{brandId}/templates/email/{templateName}/default-content | Retrieve an email template default content
[**GetEmailDefaultPreview**](CustomTemplatesApi.md#getemaildefaultpreview) | **GET** /api/v1/brands/{brandId}/templates/email/{templateName}/default-content/preview | Retrieve a preview of the email template default content
[**GetEmailSettings**](CustomTemplatesApi.md#getemailsettings) | **GET** /api/v1/brands/{brandId}/templates/email/{templateName}/settings | Retrieve the email template settings
[**GetEmailTemplate**](CustomTemplatesApi.md#getemailtemplate) | **GET** /api/v1/brands/{brandId}/templates/email/{templateName} | Retrieve an email template
[**ListEmailCustomizations**](CustomTemplatesApi.md#listemailcustomizations) | **GET** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations | List all email customizations
[**ListEmailTemplates**](CustomTemplatesApi.md#listemailtemplates) | **GET** /api/v1/brands/{brandId}/templates/email | List all email templates
[**ReplaceEmailCustomization**](CustomTemplatesApi.md#replaceemailcustomization) | **PUT** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId} | Replace an email customization
[**ReplaceEmailSettings**](CustomTemplatesApi.md#replaceemailsettings) | **PUT** /api/v1/brands/{brandId}/templates/email/{templateName}/settings | Replace the email template settings
[**SendTestEmail**](CustomTemplatesApi.md#sendtestemail) | **POST** /api/v1/brands/{brandId}/templates/email/{templateName}/test | Send a test email


<a name="createemailcustomization"></a>
# **CreateEmailCustomization**
> EmailCustomization CreateEmailCustomization (string brandId, string templateName, EmailCustomization instance = null)

Create an email customization

Creates a new Email Customization  <x-lifecycle class=\"ea\"></x-lifecycle> If Custom languages for Okta Email Templates is enabled, you can create a customization for any BCP47 language in addition to the Okta-supported languages. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateEmailCustomizationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomTemplatesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var templateName = "templateName_example";  // string | The name of the email template
            var instance = new EmailCustomization(); // EmailCustomization |  (optional) 

            try
            {
                // Create an email customization
                EmailCustomization result = apiInstance.CreateEmailCustomization(brandId, templateName, instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomTemplatesApi.CreateEmailCustomization: " + e.Message );
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
 **brandId** | **string**| The ID of the brand | 
 **templateName** | **string**| The name of the email template | 
 **instance** | [**EmailCustomization**](EmailCustomization.md)|  | [optional] 

### Return type

[**EmailCustomization**](EmailCustomization.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Successfully created the email customization. |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **409** | Could not create the email customization because it conflicts with an existing email customization. |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteallcustomizations"></a>
# **DeleteAllCustomizations**
> void DeleteAllCustomizations (string brandId, string templateName)

Delete all email customizations

Deletes all customizations for an email template  <x-lifecycle class=\"ea\"></x-lifecycle> If Custom languages for Okta Email Templates is enabled, all customizations are deleted, including customizations for additional languages. If disabled, only customizations in Okta-supported languages are deleted. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteAllCustomizationsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomTemplatesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var templateName = "templateName_example";  // string | The name of the email template

            try
            {
                // Delete all email customizations
                apiInstance.DeleteAllCustomizations(brandId, templateName);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomTemplatesApi.DeleteAllCustomizations: " + e.Message );
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
 **brandId** | **string**| The ID of the brand | 
 **templateName** | **string**| The name of the email template | 

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
| **204** | Successfully deleted all customizations for the email template. |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteemailcustomization"></a>
# **DeleteEmailCustomization**
> void DeleteEmailCustomization (string brandId, string templateName, string customizationId)

Delete an email customization

Deletes an Email Customization by its unique identifier  <x-lifecycle class=\"ea\"></x-lifecycle> If Custom languages for Okta Email Templates is disabled, deletion of an existing additional language customization by ID doesn't register. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteEmailCustomizationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomTemplatesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var templateName = "templateName_example";  // string | The name of the email template
            var customizationId = "customizationId_example";  // string | The ID of the email customization

            try
            {
                // Delete an email customization
                apiInstance.DeleteEmailCustomization(brandId, templateName, customizationId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomTemplatesApi.DeleteEmailCustomization: " + e.Message );
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
 **brandId** | **string**| The ID of the brand | 
 **templateName** | **string**| The name of the email template | 
 **customizationId** | **string**| The ID of the email customization | 

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
| **204** | Successfully deleted the email customization. |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **409** | Could not delete the email customization deleted because it is the default email customization. |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getcustomizationpreview"></a>
# **GetCustomizationPreview**
> EmailPreview GetCustomizationPreview (string brandId, string templateName, string customizationId)

Retrieve a preview of an email customization

Retrieves a Preview of an Email Customization. All variable references are populated from the current user's context. For example, `${user.profile.firstName}`.  <x-lifecycle class=\"ea\"></x-lifecycle> If Custom languages for Okta Email Templates is disabled, requests for the preview of an additional language customization by ID return a `404 Not Found` error response. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetCustomizationPreviewExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomTemplatesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var templateName = "templateName_example";  // string | The name of the email template
            var customizationId = "customizationId_example";  // string | The ID of the email customization

            try
            {
                // Retrieve a preview of an email customization
                EmailPreview result = apiInstance.GetCustomizationPreview(brandId, templateName, customizationId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomTemplatesApi.GetCustomizationPreview: " + e.Message );
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
 **brandId** | **string**| The ID of the brand | 
 **templateName** | **string**| The name of the email template | 
 **customizationId** | **string**| The ID of the email customization | 

### Return type

[**EmailPreview**](EmailPreview.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully generated a preview of the email customization. |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getemailcustomization"></a>
# **GetEmailCustomization**
> EmailCustomization GetEmailCustomization (string brandId, string templateName, string customizationId)

Retrieve an email customization

Retrieves an email customization by its unique identifier  <x-lifecycle class=\"ea\"></x-lifecycle> If Custom languages for Okta Email Templates is disabled, requests to retrieve an additional language customization by ID result in a `404 Not Found` error response. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetEmailCustomizationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomTemplatesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var templateName = "templateName_example";  // string | The name of the email template
            var customizationId = "customizationId_example";  // string | The ID of the email customization

            try
            {
                // Retrieve an email customization
                EmailCustomization result = apiInstance.GetEmailCustomization(brandId, templateName, customizationId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomTemplatesApi.GetEmailCustomization: " + e.Message );
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
 **brandId** | **string**| The ID of the brand | 
 **templateName** | **string**| The name of the email template | 
 **customizationId** | **string**| The ID of the email customization | 

### Return type

[**EmailCustomization**](EmailCustomization.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully retrieved the email customization. |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getemaildefaultcontent"></a>
# **GetEmailDefaultContent**
> EmailDefaultContent GetEmailDefaultContent (string brandId, string templateName, string language = null)

Retrieve an email template default content

Retrieves an email template's default content  <x-lifecycle class=\"ea\"></x-lifecycle> Defaults to the current user's language given the following: - Custom languages for Okta Email Templates is enabled - An additional language is specified for the `language` parameter 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetEmailDefaultContentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomTemplatesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var templateName = "templateName_example";  // string | The name of the email template
            var language = "language_example";  // string | The language to use for the email. Defaults to the current user's language if unspecified. (optional) 

            try
            {
                // Retrieve an email template default content
                EmailDefaultContent result = apiInstance.GetEmailDefaultContent(brandId, templateName, language);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomTemplatesApi.GetEmailDefaultContent: " + e.Message );
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
 **brandId** | **string**| The ID of the brand | 
 **templateName** | **string**| The name of the email template | 
 **language** | **string**| The language to use for the email. Defaults to the current user&#39;s language if unspecified. | [optional] 

### Return type

[**EmailDefaultContent**](EmailDefaultContent.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully retrieved the email template&#39;s default content. |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getemaildefaultpreview"></a>
# **GetEmailDefaultPreview**
> EmailPreview GetEmailDefaultPreview (string brandId, string templateName, string language = null)

Retrieve a preview of the email template default content

Retrieves a preview of an Email Template's default content. All variable references are populated using the current user's context. For example, `${user.profile.firstName}`.  <x-lifecycle class=\"ea\"></x-lifecycle> Defaults to the current user's language given the following: - Custom languages for Okta Email Templates is enabled - An additional language is specified for the `language` parameter 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetEmailDefaultPreviewExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomTemplatesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var templateName = "templateName_example";  // string | The name of the email template
            var language = "language_example";  // string | The language to use for the email. Defaults to the current user's language if unspecified. (optional) 

            try
            {
                // Retrieve a preview of the email template default content
                EmailPreview result = apiInstance.GetEmailDefaultPreview(brandId, templateName, language);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomTemplatesApi.GetEmailDefaultPreview: " + e.Message );
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
 **brandId** | **string**| The ID of the brand | 
 **templateName** | **string**| The name of the email template | 
 **language** | **string**| The language to use for the email. Defaults to the current user&#39;s language if unspecified. | [optional] 

### Return type

[**EmailPreview**](EmailPreview.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully generated a preview of the email template&#39;s default content. |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getemailsettings"></a>
# **GetEmailSettings**
> EmailSettingsResponse GetEmailSettings (string brandId, string templateName)

Retrieve the email template settings

Retrieves an email template's settings

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetEmailSettingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomTemplatesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var templateName = "templateName_example";  // string | The name of the email template

            try
            {
                // Retrieve the email template settings
                EmailSettingsResponse result = apiInstance.GetEmailSettings(brandId, templateName);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomTemplatesApi.GetEmailSettings: " + e.Message );
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
 **brandId** | **string**| The ID of the brand | 
 **templateName** | **string**| The name of the email template | 

### Return type

[**EmailSettingsResponse**](EmailSettingsResponse.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully retrieved the email template&#39;s settings. |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getemailtemplate"></a>
# **GetEmailTemplate**
> EmailTemplateResponse GetEmailTemplate (string brandId, string templateName, List<string> expand = null)

Retrieve an email template

Retrieves the details of an email template by name

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetEmailTemplateExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomTemplatesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var templateName = "templateName_example";  // string | The name of the email template
            var expand = new List<string>(); // List<string> | Specifies additional metadata to be included in the response (optional) 

            try
            {
                // Retrieve an email template
                EmailTemplateResponse result = apiInstance.GetEmailTemplate(brandId, templateName, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomTemplatesApi.GetEmailTemplate: " + e.Message );
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
 **brandId** | **string**| The ID of the brand | 
 **templateName** | **string**| The name of the email template | 
 **expand** | [**List&lt;string&gt;**](string.md)| Specifies additional metadata to be included in the response | [optional] 

### Return type

[**EmailTemplateResponse**](EmailTemplateResponse.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully retrieved the email template. |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listemailcustomizations"></a>
# **ListEmailCustomizations**
> List&lt;EmailCustomization&gt; ListEmailCustomizations (string brandId, string templateName, string after = null, int? limit = null)

List all email customizations

Lists all customizations of an email template  <x-lifecycle class=\"ea\"></x-lifecycle> If Custom languages for Okta Email Templates is enabled, all existing customizations are retrieved, including customizations for additional languages. If disabled, only customizations for Okta-supported languages are returned. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListEmailCustomizationsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomTemplatesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var templateName = "templateName_example";  // string | The name of the email template
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 
            var limit = 20;  // int? | A limit on the number of objects to return (optional)  (default to 20)

            try
            {
                // List all email customizations
                List<EmailCustomization> result = apiInstance.ListEmailCustomizations(brandId, templateName, after, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomTemplatesApi.ListEmailCustomizations: " + e.Message );
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
 **brandId** | **string**| The ID of the brand | 
 **templateName** | **string**| The name of the email template | 
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 
 **limit** | **int?**| A limit on the number of objects to return | [optional] [default to 20]

### Return type

[**List&lt;EmailCustomization&gt;**](EmailCustomization.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully retrieved all email customizations for the specified email template. |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listemailtemplates"></a>
# **ListEmailTemplates**
> List&lt;EmailTemplateResponse&gt; ListEmailTemplates (string brandId, string after = null, int? limit = null, List<string> expand = null)

List all email templates

Lists all supported email templates

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListEmailTemplatesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomTemplatesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 
            var limit = 20;  // int? | A limit on the number of objects to return (optional)  (default to 20)
            var expand = new List<string>(); // List<string> | Specifies additional metadata to be included in the response (optional) 

            try
            {
                // List all email templates
                List<EmailTemplateResponse> result = apiInstance.ListEmailTemplates(brandId, after, limit, expand).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomTemplatesApi.ListEmailTemplates: " + e.Message );
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
 **brandId** | **string**| The ID of the brand | 
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 
 **limit** | **int?**| A limit on the number of objects to return | [optional] [default to 20]
 **expand** | [**List&lt;string&gt;**](string.md)| Specifies additional metadata to be included in the response | [optional] 

### Return type

[**List&lt;EmailTemplateResponse&gt;**](EmailTemplateResponse.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully returned the list of email templates. |  * Link - The pagination header containing links to the current and next page of results. See [Pagination](/#pagination) for more information. <br>  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replaceemailcustomization"></a>
# **ReplaceEmailCustomization**
> EmailCustomization ReplaceEmailCustomization (string brandId, string templateName, string customizationId, EmailCustomization instance = null)

Replace an email customization

Replaces an email customization using property values  <x-lifecycle class=\"ea\"></x-lifecycle> If Custom languages for Okta Email Templates is disabled, requests to update a customization for an additional language return a `404 Not Found` error response. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceEmailCustomizationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomTemplatesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var templateName = "templateName_example";  // string | The name of the email template
            var customizationId = "customizationId_example";  // string | The ID of the email customization
            var instance = new EmailCustomization(); // EmailCustomization | Request (optional) 

            try
            {
                // Replace an email customization
                EmailCustomization result = apiInstance.ReplaceEmailCustomization(brandId, templateName, customizationId, instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomTemplatesApi.ReplaceEmailCustomization: " + e.Message );
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
 **brandId** | **string**| The ID of the brand | 
 **templateName** | **string**| The name of the email template | 
 **customizationId** | **string**| The ID of the email customization | 
 **instance** | [**EmailCustomization**](EmailCustomization.md)| Request | [optional] 

### Return type

[**EmailCustomization**](EmailCustomization.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully updated the email customization. |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **409** | Could not update the email customization because the update would cause a conflict with an existing email customization. |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replaceemailsettings"></a>
# **ReplaceEmailSettings**
> EmailSettings ReplaceEmailSettings (string brandId, string templateName, EmailSettings emailSettings = null)

Replace the email template settings

Replaces an email template's settings

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceEmailSettingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomTemplatesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var templateName = "templateName_example";  // string | The name of the email template
            var emailSettings = new EmailSettings(); // EmailSettings |  (optional) 

            try
            {
                // Replace the email template settings
                EmailSettings result = apiInstance.ReplaceEmailSettings(brandId, templateName, emailSettings);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomTemplatesApi.ReplaceEmailSettings: " + e.Message );
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
 **brandId** | **string**| The ID of the brand | 
 **templateName** | **string**| The name of the email template | 
 **emailSettings** | [**EmailSettings**](EmailSettings.md)|  | [optional] 

### Return type

[**EmailSettings**](EmailSettings.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully updated the email template&#39;s settings. |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **409** | Conflict |  -  |
| **422** | Could not update the email template&#39;s settings due to an invalid setting value. |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="sendtestemail"></a>
# **SendTestEmail**
> void SendTestEmail (string brandId, string templateName, string language = null)

Send a test email

Sends a test email to the current user's primary and secondary email addresses. The email content is selected based on the following priority: 1. The email customization for the language specified in the `language` query parameter <x-lifecycle class=\"ea\"></x-lifecycle> If Custom languages for Okta Email Templates is enabled and the `language` parameter is an additional language, the test email uses the customization corresponding to the language. 2. The email template's default customization 3. The email template's default content, translated to the current user's language  > **Note:** Super admins can view customized email templates with the **Send a test email** request. However, when custom email templates are sent to super admins as part of actual email notification flows, the customizations aren't applied. Instead, the default email template is used. This only applies to super admins.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class SendTestEmailExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomTemplatesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var templateName = "templateName_example";  // string | The name of the email template
            var language = "language_example";  // string | The language to use for the email. Defaults to the current user's language if unspecified. (optional) 

            try
            {
                // Send a test email
                apiInstance.SendTestEmail(brandId, templateName, language);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomTemplatesApi.SendTestEmail: " + e.Message );
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
 **brandId** | **string**| The ID of the brand | 
 **templateName** | **string**| The name of the email template | 
 **language** | **string**| The language to use for the email. Defaults to the current user&#39;s language if unspecified. | [optional] 

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
| **204** | Successfully sent a test email. |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

