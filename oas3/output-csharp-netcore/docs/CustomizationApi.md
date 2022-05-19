# Org.OpenAPITools.Api.CustomizationApi

All URIs are relative to *https://your-subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateEmailCustomization**](CustomizationApi.md#createemailcustomization) | **POST** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations | Create Email Customization
[**DeleteAllCustomizations**](CustomizationApi.md#deleteallcustomizations) | **DELETE** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations | Delete All Email Customizations
[**DeleteBrandThemeBackgroundImage**](CustomizationApi.md#deletebrandthemebackgroundimage) | **DELETE** /api/v1/brands/{brandId}/themes/{themeId}/background-image | Deletes a Theme background image
[**DeleteBrandThemeFavicon**](CustomizationApi.md#deletebrandthemefavicon) | **DELETE** /api/v1/brands/{brandId}/themes/{themeId}/favicon | Deletes a Theme favicon. The org then uses the Okta default favicon.
[**DeleteBrandThemeLogo**](CustomizationApi.md#deletebrandthemelogo) | **DELETE** /api/v1/brands/{brandId}/themes/{themeId}/logo | Deletes a Theme logo. The org then uses the Okta default logo.
[**DeleteEmailCustomization**](CustomizationApi.md#deleteemailcustomization) | **DELETE** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId} | Delete Email Customization
[**GetBrand**](CustomizationApi.md#getbrand) | **GET** /api/v1/brands/{brandId} | Get Brand
[**GetBrandTheme**](CustomizationApi.md#getbrandtheme) | **GET** /api/v1/brands/{brandId}/themes/{themeId} | Get a theme for a brand
[**GetCustomizationPreview**](CustomizationApi.md#getcustomizationpreview) | **GET** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId}/preview | Preview Email Customization
[**GetEmailCustomization**](CustomizationApi.md#getemailcustomization) | **GET** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId} | Get Email Customization
[**GetEmailDefaultContent**](CustomizationApi.md#getemaildefaultcontent) | **GET** /api/v1/brands/{brandId}/templates/email/{templateName}/default-content | Get Email Template Default Content
[**GetEmailDefaultPreview**](CustomizationApi.md#getemaildefaultpreview) | **GET** /api/v1/brands/{brandId}/templates/email/{templateName}/default-content/preview | Preview Email Template Default Content
[**GetEmailTemplate**](CustomizationApi.md#getemailtemplate) | **GET** /api/v1/brands/{brandId}/templates/email/{templateName} | Get Email Template
[**ListBrandThemes**](CustomizationApi.md#listbrandthemes) | **GET** /api/v1/brands/{brandId}/themes | Get Brand Themes
[**ListBrands**](CustomizationApi.md#listbrands) | **GET** /api/v1/brands | List Brands
[**ListEmailCustomizations**](CustomizationApi.md#listemailcustomizations) | **GET** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations | List Email Customizations
[**ListEmailTemplates**](CustomizationApi.md#listemailtemplates) | **GET** /api/v1/brands/{brandId}/templates/email | List Email Templates
[**SendTestEmail**](CustomizationApi.md#sendtestemail) | **POST** /api/v1/brands/{brandId}/templates/email/{templateName}/test | Send Test Email
[**UpdateBrand**](CustomizationApi.md#updatebrand) | **PUT** /api/v1/brands/{brandId} | Update Brand
[**UpdateBrandTheme**](CustomizationApi.md#updatebrandtheme) | **PUT** /api/v1/brands/{brandId}/themes/{themeId} | Update a theme for a brand
[**UpdateEmailCustomization**](CustomizationApi.md#updateemailcustomization) | **PUT** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId} | Update Email Customization
[**UploadBrandThemeBackgroundImage**](CustomizationApi.md#uploadbrandthemebackgroundimage) | **POST** /api/v1/brands/{brandId}/themes/{themeId}/background-image | Updates the background image for your Theme
[**UploadBrandThemeFavicon**](CustomizationApi.md#uploadbrandthemefavicon) | **POST** /api/v1/brands/{brandId}/themes/{themeId}/favicon | Updates the favicon for your theme
[**UploadBrandThemeLogo**](CustomizationApi.md#uploadbrandthemelogo) | **POST** /api/v1/brands/{brandId}/themes/{themeId}/logo | Update a themes logo


<a name="createemailcustomization"></a>
# **CreateEmailCustomization**
> EmailCustomization CreateEmailCustomization (string brandId, string templateName, EmailCustomization instance = null)

Create Email Customization

Creates a new email customization.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class CreateEmailCustomizationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var templateName = "templateName_example";  // string | The name of the email template.
            var instance = new EmailCustomization(); // EmailCustomization |  (optional) 

            try
            {
                // Create Email Customization
                EmailCustomization result = apiInstance.CreateEmailCustomization(brandId, templateName, instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.CreateEmailCustomization: " + e.Message );
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
 **brandId** | **string**| The ID of the brand. | 
 **templateName** | **string**| The name of the email template. | 
 **instance** | [**EmailCustomization**](EmailCustomization.md)|  | [optional] 

### Return type

[**EmailCustomization**](EmailCustomization.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Successfully created the email customization. |  -  |
| **409** | Could not create the email customization because it conflicts with an existing email customization. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteallcustomizations"></a>
# **DeleteAllCustomizations**
> void DeleteAllCustomizations (string brandId, string templateName)

Delete All Email Customizations

Deletes all customizations for an email template.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class DeleteAllCustomizationsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var templateName = "templateName_example";  // string | The name of the email template.

            try
            {
                // Delete All Email Customizations
                apiInstance.DeleteAllCustomizations(brandId, templateName);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.DeleteAllCustomizations: " + e.Message );
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
 **brandId** | **string**| The ID of the brand. | 
 **templateName** | **string**| The name of the email template. | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Successfully deleted all customizations for the email template. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletebrandthemebackgroundimage"></a>
# **DeleteBrandThemeBackgroundImage**
> void DeleteBrandThemeBackgroundImage (string brandId, string themeId)

Deletes a Theme background image

Deletes a Theme background image

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class DeleteBrandThemeBackgroundImageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | 
            var themeId = "themeId_example";  // string | 

            try
            {
                // Deletes a Theme background image
                apiInstance.DeleteBrandThemeBackgroundImage(brandId, themeId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.DeleteBrandThemeBackgroundImage: " + e.Message );
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
 **brandId** | **string**|  | 
 **themeId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletebrandthemefavicon"></a>
# **DeleteBrandThemeFavicon**
> void DeleteBrandThemeFavicon (string brandId, string themeId)

Deletes a Theme favicon. The org then uses the Okta default favicon.

Deletes a Theme favicon. The org then uses the Okta default favicon.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class DeleteBrandThemeFaviconExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | 
            var themeId = "themeId_example";  // string | 

            try
            {
                // Deletes a Theme favicon. The org then uses the Okta default favicon.
                apiInstance.DeleteBrandThemeFavicon(brandId, themeId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.DeleteBrandThemeFavicon: " + e.Message );
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
 **brandId** | **string**|  | 
 **themeId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletebrandthemelogo"></a>
# **DeleteBrandThemeLogo**
> void DeleteBrandThemeLogo (string brandId, string themeId)

Deletes a Theme logo. The org then uses the Okta default logo.

Deletes a Theme logo. The org then uses the Okta default logo.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class DeleteBrandThemeLogoExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | 
            var themeId = "themeId_example";  // string | 

            try
            {
                // Deletes a Theme logo. The org then uses the Okta default logo.
                apiInstance.DeleteBrandThemeLogo(brandId, themeId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.DeleteBrandThemeLogo: " + e.Message );
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
 **brandId** | **string**|  | 
 **themeId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteemailcustomization"></a>
# **DeleteEmailCustomization**
> void DeleteEmailCustomization (string brandId, string templateName, string customizationId)

Delete Email Customization

Deletes an email customization by its unique identifier.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class DeleteEmailCustomizationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var templateName = "templateName_example";  // string | The name of the email template.
            var customizationId = "customizationId_example";  // string | The ID of the email customization.

            try
            {
                // Delete Email Customization
                apiInstance.DeleteEmailCustomization(brandId, templateName, customizationId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.DeleteEmailCustomization: " + e.Message );
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
 **brandId** | **string**| The ID of the brand. | 
 **templateName** | **string**| The name of the email template. | 
 **customizationId** | **string**| The ID of the email customization. | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Successfully deleted the email customization. |  -  |
| **409** | Could not delete the email customization deleted because it is the default email customization. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getbrand"></a>
# **GetBrand**
> Brand GetBrand (string brandId)

Get Brand

Fetches a brand by `brandId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetBrandExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | 

            try
            {
                // Get Brand
                Brand result = apiInstance.GetBrand(brandId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.GetBrand: " + e.Message );
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
 **brandId** | **string**|  | 

### Return type

[**Brand**](Brand.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getbrandtheme"></a>
# **GetBrandTheme**
> ThemeResponse GetBrandTheme (string brandId, string themeId)

Get a theme for a brand

Fetches a theme for a brand

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetBrandThemeExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | 
            var themeId = "themeId_example";  // string | 

            try
            {
                // Get a theme for a brand
                ThemeResponse result = apiInstance.GetBrandTheme(brandId, themeId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.GetBrandTheme: " + e.Message );
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
 **brandId** | **string**|  | 
 **themeId** | **string**|  | 

### Return type

[**ThemeResponse**](ThemeResponse.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getcustomizationpreview"></a>
# **GetCustomizationPreview**
> EmailPreview GetCustomizationPreview (string brandId, string templateName, string customizationId)

Preview Email Customization

Generates a preview of an email customization. All variable references (e.g., `${user.profile.firstName}`) are populated using the current user's context.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetCustomizationPreviewExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var templateName = "templateName_example";  // string | The name of the email template.
            var customizationId = "customizationId_example";  // string | The ID of the email customization.

            try
            {
                // Preview Email Customization
                EmailPreview result = apiInstance.GetCustomizationPreview(brandId, templateName, customizationId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.GetCustomizationPreview: " + e.Message );
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
 **brandId** | **string**| The ID of the brand. | 
 **templateName** | **string**| The name of the email template. | 
 **customizationId** | **string**| The ID of the email customization. | 

### Return type

[**EmailPreview**](EmailPreview.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully generated a preview of the email customization. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getemailcustomization"></a>
# **GetEmailCustomization**
> EmailCustomization GetEmailCustomization (string brandId, string templateName, string customizationId)

Get Email Customization

Gets an email customization by its unique identifier.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetEmailCustomizationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var templateName = "templateName_example";  // string | The name of the email template.
            var customizationId = "customizationId_example";  // string | The ID of the email customization.

            try
            {
                // Get Email Customization
                EmailCustomization result = apiInstance.GetEmailCustomization(brandId, templateName, customizationId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.GetEmailCustomization: " + e.Message );
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
 **brandId** | **string**| The ID of the brand. | 
 **templateName** | **string**| The name of the email template. | 
 **customizationId** | **string**| The ID of the email customization. | 

### Return type

[**EmailCustomization**](EmailCustomization.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully retrieved the email customization. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getemaildefaultcontent"></a>
# **GetEmailDefaultContent**
> EmailDefaultContent GetEmailDefaultContent (string brandId, string templateName, string language = null)

Get Email Template Default Content

Gets an email template's default content.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetEmailDefaultContentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var templateName = "templateName_example";  // string | The name of the email template.
            var language = "language_example";  // string | The language to use for the email. Defaults to the current user's language if unspecified. (optional) 

            try
            {
                // Get Email Template Default Content
                EmailDefaultContent result = apiInstance.GetEmailDefaultContent(brandId, templateName, language);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.GetEmailDefaultContent: " + e.Message );
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
 **brandId** | **string**| The ID of the brand. | 
 **templateName** | **string**| The name of the email template. | 
 **language** | **string**| The language to use for the email. Defaults to the current user&#39;s language if unspecified. | [optional] 

### Return type

[**EmailDefaultContent**](EmailDefaultContent.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully retrieved the email template&#39;s default content. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getemaildefaultpreview"></a>
# **GetEmailDefaultPreview**
> EmailPreview GetEmailDefaultPreview (string brandId, string templateName, string language = null)

Preview Email Template Default Content

Generates a preview of an email template's default content. All variable references (e.g., `${user.profile.firstName}`) are populated using the current user's context.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetEmailDefaultPreviewExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var templateName = "templateName_example";  // string | The name of the email template.
            var language = "language_example";  // string | The language to use for the email. Defaults to the current user's language if unspecified. (optional) 

            try
            {
                // Preview Email Template Default Content
                EmailPreview result = apiInstance.GetEmailDefaultPreview(brandId, templateName, language);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.GetEmailDefaultPreview: " + e.Message );
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
 **brandId** | **string**| The ID of the brand. | 
 **templateName** | **string**| The name of the email template. | 
 **language** | **string**| The language to use for the email. Defaults to the current user&#39;s language if unspecified. | [optional] 

### Return type

[**EmailPreview**](EmailPreview.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully generated a preview of the email template&#39;s default content. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getemailtemplate"></a>
# **GetEmailTemplate**
> EmailTemplate GetEmailTemplate (string brandId, string templateName)

Get Email Template

Gets the details of an email template by name.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetEmailTemplateExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var templateName = "templateName_example";  // string | The name of the email template.

            try
            {
                // Get Email Template
                EmailTemplate result = apiInstance.GetEmailTemplate(brandId, templateName);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.GetEmailTemplate: " + e.Message );
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
 **brandId** | **string**| The ID of the brand. | 
 **templateName** | **string**| The name of the email template. | 

### Return type

[**EmailTemplate**](EmailTemplate.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully retrieved the email template. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listbrandthemes"></a>
# **ListBrandThemes**
> List&lt;ThemeResponse&gt; ListBrandThemes (string brandId)

Get Brand Themes

List all the themes in your brand

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ListBrandThemesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | 

            try
            {
                // Get Brand Themes
                List<ThemeResponse> result = apiInstance.ListBrandThemes(brandId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.ListBrandThemes: " + e.Message );
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
 **brandId** | **string**|  | 

### Return type

[**List&lt;ThemeResponse&gt;**](ThemeResponse.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listbrands"></a>
# **ListBrands**
> List&lt;Brand&gt; ListBrands ()

List Brands

List all the brands in your org.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ListBrandsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);

            try
            {
                // List Brands
                List<Brand> result = apiInstance.ListBrands();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.ListBrands: " + e.Message );
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

[**List&lt;Brand&gt;**](Brand.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listemailcustomizations"></a>
# **ListEmailCustomizations**
> List&lt;EmailCustomization&gt; ListEmailCustomizations (string brandId, string templateName, string after = null, int? limit = null)

List Email Customizations

Lists all customizations of an email template.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ListEmailCustomizationsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var templateName = "templateName_example";  // string | The name of the email template.
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/reference/core-okta-api/#pagination) for more information. (optional) 
            var limit = 20;  // int? | A limit on the number of objects to return. (optional)  (default to 20)

            try
            {
                // List Email Customizations
                List<EmailCustomization> result = apiInstance.ListEmailCustomizations(brandId, templateName, after, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.ListEmailCustomizations: " + e.Message );
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
 **brandId** | **string**| The ID of the brand. | 
 **templateName** | **string**| The name of the email template. | 
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](https://developer.okta.com/docs/reference/core-okta-api/#pagination) for more information. | [optional] 
 **limit** | **int?**| A limit on the number of objects to return. | [optional] [default to 20]

### Return type

[**List&lt;EmailCustomization&gt;**](EmailCustomization.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully retrieved all email customizations for the specified email template. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listemailtemplates"></a>
# **ListEmailTemplates**
> List&lt;EmailTemplate&gt; ListEmailTemplates (string brandId, string after = null, int? limit = null)

List Email Templates

Lists all email templates.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ListEmailTemplatesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/reference/core-okta-api/#pagination) for more information. (optional) 
            var limit = 20;  // int? | A limit on the number of objects to return. (optional)  (default to 20)

            try
            {
                // List Email Templates
                List<EmailTemplate> result = apiInstance.ListEmailTemplates(brandId, after, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.ListEmailTemplates: " + e.Message );
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
 **brandId** | **string**| The ID of the brand. | 
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](https://developer.okta.com/docs/reference/core-okta-api/#pagination) for more information. | [optional] 
 **limit** | **int?**| A limit on the number of objects to return. | [optional] [default to 20]

### Return type

[**List&lt;EmailTemplate&gt;**](EmailTemplate.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully returned the list of email templates. |  * Link - The pagination header containing links to the current and next page of results. See [Pagination](https://developer.okta.com/docs/reference/core-okta-api/#pagination) for more information. <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="sendtestemail"></a>
# **SendTestEmail**
> void SendTestEmail (string brandId, string templateName, string language = null)

Send Test Email

Sends a test email to the current user’s primary and secondary email addresses. The email content is selected based on the following priority: 1. The email customization for the language specified in the `language` query parameter. 2. The email template's default customization. 3. The email template’s default content, translated to the current user's language.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class SendTestEmailExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var templateName = "templateName_example";  // string | The name of the email template.
            var language = "language_example";  // string | The language to use for the email. Defaults to the current user's language if unspecified. (optional) 

            try
            {
                // Send Test Email
                apiInstance.SendTestEmail(brandId, templateName, language);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.SendTestEmail: " + e.Message );
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
 **brandId** | **string**| The ID of the brand. | 
 **templateName** | **string**| The name of the email template. | 
 **language** | **string**| The language to use for the email. Defaults to the current user&#39;s language if unspecified. | [optional] 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Successfully sent a test email. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatebrand"></a>
# **UpdateBrand**
> Brand UpdateBrand (string brandId, Brand brand)

Update Brand

Updates a brand by `brandId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class UpdateBrandExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | 
            var brand = new Brand(); // Brand | 

            try
            {
                // Update Brand
                Brand result = apiInstance.UpdateBrand(brandId, brand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.UpdateBrand: " + e.Message );
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
 **brandId** | **string**|  | 
 **brand** | [**Brand**](Brand.md)|  | 

### Return type

[**Brand**](Brand.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **400** | Bad Request |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatebrandtheme"></a>
# **UpdateBrandTheme**
> ThemeResponse UpdateBrandTheme (string brandId, string themeId, Theme theme)

Update a theme for a brand

Updates a theme for a brand

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class UpdateBrandThemeExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | 
            var themeId = "themeId_example";  // string | 
            var theme = new Theme(); // Theme | 

            try
            {
                // Update a theme for a brand
                ThemeResponse result = apiInstance.UpdateBrandTheme(brandId, themeId, theme);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.UpdateBrandTheme: " + e.Message );
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
 **brandId** | **string**|  | 
 **themeId** | **string**|  | 
 **theme** | [**Theme**](Theme.md)|  | 

### Return type

[**ThemeResponse**](ThemeResponse.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **400** | Bad Request |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateemailcustomization"></a>
# **UpdateEmailCustomization**
> EmailCustomization UpdateEmailCustomization (string brandId, string templateName, string customizationId, EmailCustomization instance = null)

Update Email Customization

Updates an existing email customization using the property values provided.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class UpdateEmailCustomizationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var templateName = "templateName_example";  // string | The name of the email template.
            var customizationId = "customizationId_example";  // string | The ID of the email customization.
            var instance = new EmailCustomization(); // EmailCustomization | Request (optional) 

            try
            {
                // Update Email Customization
                EmailCustomization result = apiInstance.UpdateEmailCustomization(brandId, templateName, customizationId, instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.UpdateEmailCustomization: " + e.Message );
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
 **brandId** | **string**| The ID of the brand. | 
 **templateName** | **string**| The name of the email template. | 
 **customizationId** | **string**| The ID of the email customization. | 
 **instance** | [**EmailCustomization**](EmailCustomization.md)| Request | [optional] 

### Return type

[**EmailCustomization**](EmailCustomization.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully updated the email customization. |  -  |
| **409** | Could not update the email customization because the update would cause a conflict with an existing email customization. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="uploadbrandthemebackgroundimage"></a>
# **UploadBrandThemeBackgroundImage**
> ImageUploadResponse UploadBrandThemeBackgroundImage (string brandId, string themeId)

Updates the background image for your Theme

Updates the background image for your Theme

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class UploadBrandThemeBackgroundImageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | 
            var themeId = "themeId_example";  // string | 

            try
            {
                // Updates the background image for your Theme
                ImageUploadResponse result = apiInstance.UploadBrandThemeBackgroundImage(brandId, themeId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.UploadBrandThemeBackgroundImage: " + e.Message );
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
 **brandId** | **string**|  | 
 **themeId** | **string**|  | 

### Return type

[**ImageUploadResponse**](ImageUploadResponse.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **400** | Bad Request |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="uploadbrandthemefavicon"></a>
# **UploadBrandThemeFavicon**
> ImageUploadResponse UploadBrandThemeFavicon (string brandId, string themeId)

Updates the favicon for your theme

Updates the favicon for your theme

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class UploadBrandThemeFaviconExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | 
            var themeId = "themeId_example";  // string | 

            try
            {
                // Updates the favicon for your theme
                ImageUploadResponse result = apiInstance.UploadBrandThemeFavicon(brandId, themeId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.UploadBrandThemeFavicon: " + e.Message );
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
 **brandId** | **string**|  | 
 **themeId** | **string**|  | 

### Return type

[**ImageUploadResponse**](ImageUploadResponse.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **400** | Bad Request |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="uploadbrandthemelogo"></a>
# **UploadBrandThemeLogo**
> ImageUploadResponse UploadBrandThemeLogo (string brandId, string themeId)

Update a themes logo

Updates the logo for your Theme

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class UploadBrandThemeLogoExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | 
            var themeId = "themeId_example";  // string | 

            try
            {
                // Update a themes logo
                ImageUploadResponse result = apiInstance.UploadBrandThemeLogo(brandId, themeId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.UploadBrandThemeLogo: " + e.Message );
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
 **brandId** | **string**|  | 
 **themeId** | **string**|  | 

### Return type

[**ImageUploadResponse**](ImageUploadResponse.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | Bad Request |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

