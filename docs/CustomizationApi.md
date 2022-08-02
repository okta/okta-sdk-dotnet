# Okta.Sdk.Api.CustomizationApi

All URIs are relative to *https://your-subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateEmailCustomization**](CustomizationApi.md#createemailcustomization) | **POST** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations | Create an Email Customization
[**DeleteAllCustomizations**](CustomizationApi.md#deleteallcustomizations) | **DELETE** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations | Delete all Email Customizations
[**DeleteBrandThemeBackgroundImage**](CustomizationApi.md#deletebrandthemebackgroundimage) | **DELETE** /api/v1/brands/{brandId}/themes/{themeId}/background-image | Delete the Background Image
[**DeleteBrandThemeFavicon**](CustomizationApi.md#deletebrandthemefavicon) | **DELETE** /api/v1/brands/{brandId}/themes/{themeId}/favicon | Delete the Favicon
[**DeleteBrandThemeLogo**](CustomizationApi.md#deletebrandthemelogo) | **DELETE** /api/v1/brands/{brandId}/themes/{themeId}/logo | Delete the Logo
[**DeleteEmailCustomization**](CustomizationApi.md#deleteemailcustomization) | **DELETE** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId} | Delete an Email Customization
[**GetBrand**](CustomizationApi.md#getbrand) | **GET** /api/v1/brands/{brandId} | Retrieve a Brand
[**GetBrandTheme**](CustomizationApi.md#getbrandtheme) | **GET** /api/v1/brands/{brandId}/themes/{themeId} | Retrieve a Theme
[**GetCustomizationPreview**](CustomizationApi.md#getcustomizationpreview) | **GET** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId}/preview | Preview an Email Customization
[**GetEmailCustomization**](CustomizationApi.md#getemailcustomization) | **GET** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId} | Retrieve an Email Customization
[**GetEmailDefaultContent**](CustomizationApi.md#getemaildefaultcontent) | **GET** /api/v1/brands/{brandId}/templates/email/{templateName}/default-content | Retrieve an Email Template Default Content
[**GetEmailDefaultPreview**](CustomizationApi.md#getemaildefaultpreview) | **GET** /api/v1/brands/{brandId}/templates/email/{templateName}/default-content/preview | Preview the Email Template Default Content
[**GetEmailSettings**](CustomizationApi.md#getemailsettings) | **GET** /api/v1/brands/{brandId}/templates/email/{templateName}/settings | Retrieve the Email Template Settings
[**GetEmailTemplate**](CustomizationApi.md#getemailtemplate) | **GET** /api/v1/brands/{brandId}/templates/email/{templateName} | Retrieve an Email Template
[**ListAllSignInWidgetVersions**](CustomizationApi.md#listallsigninwidgetversions) | **GET** /api/v1/brands/{brandId}/pages/sign-in/widget-versions | List all Sign-in Widget Versions
[**ListBrandThemes**](CustomizationApi.md#listbrandthemes) | **GET** /api/v1/brands/{brandId}/themes | List all Themes
[**ListBrands**](CustomizationApi.md#listbrands) | **GET** /api/v1/brands | List all Brands
[**ListEmailCustomizations**](CustomizationApi.md#listemailcustomizations) | **GET** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations | List all Email Customizations
[**ListEmailTemplates**](CustomizationApi.md#listemailtemplates) | **GET** /api/v1/brands/{brandId}/templates/email | List all Email Templates
[**PreviewErrorPage**](CustomizationApi.md#previewerrorpage) | **POST** /api/v1/brands/{brandId}/pages/error/preview | Preview the Error Page
[**PreviewSignInPage**](CustomizationApi.md#previewsigninpage) | **POST** /api/v1/brands/{brandId}/pages/sign-in/preview | Preview the Sign-in Page.
[**ReplaceErrorPage**](CustomizationApi.md#replaceerrorpage) | **PUT** /api/v1/brands/{brandId}/pages/error | Replace the Error Page
[**ReplaceSignInPage**](CustomizationApi.md#replacesigninpage) | **PUT** /api/v1/brands/{brandId}/pages/sign-in | Replace the Sign-in Page
[**ReplaceSignOutPageSettings**](CustomizationApi.md#replacesignoutpagesettings) | **PUT** /api/v1/brands/{brandId}/pages/sign-out | Replace the Sign-out Page Settings
[**ResetErrorPage**](CustomizationApi.md#reseterrorpage) | **DELETE** /api/v1/brands/{brandId}/pages/error | Reset the Error Page
[**ResetSignInPage**](CustomizationApi.md#resetsigninpage) | **DELETE** /api/v1/brands/{brandId}/pages/sign-in | Reset the Sign-in Page
[**RetrieveErrorPage**](CustomizationApi.md#retrieveerrorpage) | **GET** /api/v1/brands/{brandId}/pages/error | Retrieve the Error Page
[**RetrieveSignInPage**](CustomizationApi.md#retrievesigninpage) | **GET** /api/v1/brands/{brandId}/pages/sign-in | Retrieve the Sign-in Page
[**RetrieveSignOutPageSettings**](CustomizationApi.md#retrievesignoutpagesettings) | **GET** /api/v1/brands/{brandId}/pages/sign-out | Retrieve the Sign-out Page Settings
[**SendTestEmail**](CustomizationApi.md#sendtestemail) | **POST** /api/v1/brands/{brandId}/templates/email/{templateName}/test | Send a Test Email
[**UpdateBrand**](CustomizationApi.md#updatebrand) | **PUT** /api/v1/brands/{brandId} | Replace a Brand
[**UpdateBrandTheme**](CustomizationApi.md#updatebrandtheme) | **PUT** /api/v1/brands/{brandId}/themes/{themeId} | Replace a Theme
[**UpdateEmailCustomization**](CustomizationApi.md#updateemailcustomization) | **PUT** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId} | Replace an Email Customization
[**UpdateEmailSettings**](CustomizationApi.md#updateemailsettings) | **PUT** /api/v1/brands/{brandId}/templates/email/{templateName}/settings | Replace the Email Template Settings
[**UploadBrandThemeBackgroundImage**](CustomizationApi.md#uploadbrandthemebackgroundimage) | **POST** /api/v1/brands/{brandId}/themes/{themeId}/background-image | Upload the Background Image
[**UploadBrandThemeFavicon**](CustomizationApi.md#uploadbrandthemefavicon) | **POST** /api/v1/brands/{brandId}/themes/{themeId}/favicon | Upload the Favicon
[**UploadBrandThemeLogo**](CustomizationApi.md#uploadbrandthemelogo) | **POST** /api/v1/brands/{brandId}/themes/{themeId}/logo | Upload the Logo


<a name="createemailcustomization"></a>
# **CreateEmailCustomization**
> EmailCustomization CreateEmailCustomization (string brandId, string templateName, EmailCustomization instance = null)

Create an Email Customization

Creates a new email customization.

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
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var templateName = "templateName_example";  // string | The name of the email template.
            var instance = new EmailCustomization(); // EmailCustomization |  (optional) 

            try
            {
                // Create an Email Customization
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

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

Delete all Email Customizations

Deletes all customizations for an email template.

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
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var templateName = "templateName_example";  // string | The name of the email template.

            try
            {
                // Delete all Email Customizations
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

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

<a name="deletebrandthemebackgroundimage"></a>
# **DeleteBrandThemeBackgroundImage**
> void DeleteBrandThemeBackgroundImage (string brandId, string themeId)

Delete the Background Image

Deletes a Theme background image.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteBrandThemeBackgroundImageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | 
            var themeId = "themeId_example";  // string | 

            try
            {
                // Delete the Background Image
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

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

<a name="deletebrandthemefavicon"></a>
# **DeleteBrandThemeFavicon**
> void DeleteBrandThemeFavicon (string brandId, string themeId)

Delete the Favicon

Deletes a Theme favicon. The theme will use the default Okta favicon.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteBrandThemeFaviconExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | 
            var themeId = "themeId_example";  // string | 

            try
            {
                // Delete the Favicon
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

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

<a name="deletebrandthemelogo"></a>
# **DeleteBrandThemeLogo**
> void DeleteBrandThemeLogo (string brandId, string themeId)

Delete the Logo

Deletes a Theme logo. The theme will use the default Okta logo.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteBrandThemeLogoExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | 
            var themeId = "themeId_example";  // string | 

            try
            {
                // Delete the Logo
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

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

<a name="deleteemailcustomization"></a>
# **DeleteEmailCustomization**
> void DeleteEmailCustomization (string brandId, string templateName, string customizationId)

Delete an Email Customization

Deletes an email customization by its unique identifier.

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
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var templateName = "templateName_example";  // string | The name of the email template.
            var customizationId = "customizationId_example";  // string | The ID of the email customization.

            try
            {
                // Delete an Email Customization
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

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

<a name="getbrand"></a>
# **GetBrand**
> Brand GetBrand (string brandId)

Retrieve a Brand

Fetches a brand by `brandId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetBrandExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | 

            try
            {
                // Retrieve a Brand
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

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

<a name="getbrandtheme"></a>
# **GetBrandTheme**
> ThemeResponse GetBrandTheme (string brandId, string themeId)

Retrieve a Theme

Fetches a theme for a brand

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetBrandThemeExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | 
            var themeId = "themeId_example";  // string | 

            try
            {
                // Retrieve a Theme
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

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

<a name="getcustomizationpreview"></a>
# **GetCustomizationPreview**
> EmailPreview GetCustomizationPreview (string brandId, string templateName, string customizationId)

Preview an Email Customization

Generates a preview of an email customization. All variable references (e.g., `${user.profile.firstName}`) are populated using the current user's context.

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
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var templateName = "templateName_example";  // string | The name of the email template.
            var customizationId = "customizationId_example";  // string | The ID of the email customization.

            try
            {
                // Preview an Email Customization
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

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

Retrieve an Email Customization

Gets an email customization by its unique identifier.

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
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var templateName = "templateName_example";  // string | The name of the email template.
            var customizationId = "customizationId_example";  // string | The ID of the email customization.

            try
            {
                // Retrieve an Email Customization
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

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

Retrieve an Email Template Default Content

Gets an email template's default content.

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
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var templateName = "templateName_example";  // string | The name of the email template.
            var language = "language_example";  // string | The language to use for the email. Defaults to the current user's language if unspecified. (optional) 

            try
            {
                // Retrieve an Email Template Default Content
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

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

Preview the Email Template Default Content

Generates a preview of an email template's default content. All variable references (e.g., `${user.profile.firstName}`) are populated using the current user's context.

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
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var templateName = "templateName_example";  // string | The name of the email template.
            var language = "language_example";  // string | The language to use for the email. Defaults to the current user's language if unspecified. (optional) 

            try
            {
                // Preview the Email Template Default Content
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

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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
> EmailSettings GetEmailSettings (string brandId, string templateName)

Retrieve the Email Template Settings

Gets an email template's settings.

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
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var templateName = "templateName_example";  // string | The name of the email template.

            try
            {
                // Retrieve the Email Template Settings
                EmailSettings result = apiInstance.GetEmailSettings(brandId, templateName);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.GetEmailSettings: " + e.Message );
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

[**EmailSettings**](EmailSettings.md)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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
> EmailTemplate GetEmailTemplate (string brandId, string templateName, List<string> expand = null)

Retrieve an Email Template

Gets the details of an email template by name.

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
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var templateName = "templateName_example";  // string | The name of the email template.
            var expand = new List<string>(); // List<string> | Specifies additional metadata to be included in the response. (optional) 

            try
            {
                // Retrieve an Email Template
                EmailTemplate result = apiInstance.GetEmailTemplate(brandId, templateName, expand);
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
 **expand** | [**List&lt;string&gt;**](string.md)| Specifies additional metadata to be included in the response. | [optional] 

### Return type

[**EmailTemplate**](EmailTemplate.md)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

<a name="listallsigninwidgetversions"></a>
# **ListAllSignInWidgetVersions**
> List&lt;string&gt; ListAllSignInWidgetVersions (string brandId)

List all Sign-in Widget Versions

List all sign-in widget versions.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListAllSignInWidgetVersionsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.

            try
            {
                // List all Sign-in Widget Versions
                List<string> result = apiInstance.ListAllSignInWidgetVersions(brandId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.ListAllSignInWidgetVersions: " + e.Message );
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

### Return type

**List<string>**

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully listed the sign-in widget versions. |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listbrandthemes"></a>
# **ListBrandThemes**
> List&lt;ThemeResponse&gt; ListBrandThemes (string brandId)

List all Themes

List all the themes in your brand

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListBrandThemesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | 

            try
            {
                // List all Themes
                List<ThemeResponse> result = apiInstance.ListBrandThemes(brandId).ToListAsync();
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

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

<a name="listbrands"></a>
# **ListBrands**
> List&lt;Brand&gt; ListBrands ()

List all Brands

List all the brands in your org.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListBrandsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);

            try
            {
                // List all Brands
                List<Brand> result = apiInstance.ListBrands().ToListAsync();
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

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

<a name="listemailcustomizations"></a>
# **ListEmailCustomizations**
> List&lt;EmailCustomization&gt; ListEmailCustomizations (string brandId, string templateName, string after = null, int? limit = null)

List all Email Customizations

Lists all customizations of an email template.

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
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var templateName = "templateName_example";  // string | The name of the email template.
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/reference/core-okta-api/#pagination) for more information. (optional) 
            var limit = 20;  // int? | A limit on the number of objects to return. (optional)  (default to 20)

            try
            {
                // List all Email Customizations
                List<EmailCustomization> result = apiInstance.ListEmailCustomizations(brandId, templateName, after, limit).ToListAsync();
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

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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
> List&lt;EmailTemplate&gt; ListEmailTemplates (string brandId, string after = null, int? limit = null, List<string> expand = null)

List all Email Templates

Lists all email templates.

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
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/reference/core-okta-api/#pagination) for more information. (optional) 
            var limit = 20;  // int? | A limit on the number of objects to return. (optional)  (default to 20)
            var expand = new List<string>(); // List<string> | Specifies additional metadata to be included in the response. (optional) 

            try
            {
                // List all Email Templates
                List<EmailTemplate> result = apiInstance.ListEmailTemplates(brandId, after, limit, expand).ToListAsync();
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
 **expand** | [**List&lt;string&gt;**](string.md)| Specifies additional metadata to be included in the response. | [optional] 

### Return type

[**List&lt;EmailTemplate&gt;**](EmailTemplate.md)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully returned the list of email templates. |  * Link - The pagination header containing links to the current and next page of results. See [Pagination](https://developer.okta.com/docs/reference/core-okta-api/#pagination) for more information. <br>  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="previewerrorpage"></a>
# **PreviewErrorPage**
> string PreviewErrorPage (string brandId, CustomizablePage customizablePage)

Preview the Error Page

Previews the error page.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class PreviewErrorPageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var customizablePage = new CustomizablePage(); // CustomizablePage | 

            try
            {
                // Preview the Error Page
                string result = apiInstance.PreviewErrorPage(brandId, customizablePage);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.PreviewErrorPage: " + e.Message );
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
 **customizablePage** | [**CustomizablePage**](CustomizablePage.md)|  | 

### Return type

**string**

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: text/html, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully previewed the error page. |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="previewsigninpage"></a>
# **PreviewSignInPage**
> string PreviewSignInPage (string brandId, SignInPage signInPage)

Preview the Sign-in Page.

Preview the sign-in page.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class PreviewSignInPageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var signInPage = new SignInPage(); // SignInPage | 

            try
            {
                // Preview the Sign-in Page.
                string result = apiInstance.PreviewSignInPage(brandId, signInPage);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.PreviewSignInPage: " + e.Message );
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
 **signInPage** | [**SignInPage**](SignInPage.md)|  | 

### Return type

**string**

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: text/html, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully previewed the sign-in page. |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replaceerrorpage"></a>
# **ReplaceErrorPage**
> CustomizablePage ReplaceErrorPage (string brandId, CustomizablePage customizablePage)

Replace the Error Page

Replaces the error page.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceErrorPageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var customizablePage = new CustomizablePage(); // CustomizablePage | 

            try
            {
                // Replace the Error Page
                CustomizablePage result = apiInstance.ReplaceErrorPage(brandId, customizablePage);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.ReplaceErrorPage: " + e.Message );
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
 **customizablePage** | [**CustomizablePage**](CustomizablePage.md)|  | 

### Return type

[**CustomizablePage**](CustomizablePage.md)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully replaced the error page. |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacesigninpage"></a>
# **ReplaceSignInPage**
> SignInPage ReplaceSignInPage (string brandId, SignInPage signInPage)

Replace the Sign-in Page

Replaces the sign-in page.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceSignInPageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var signInPage = new SignInPage(); // SignInPage | 

            try
            {
                // Replace the Sign-in Page
                SignInPage result = apiInstance.ReplaceSignInPage(brandId, signInPage);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.ReplaceSignInPage: " + e.Message );
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
 **signInPage** | [**SignInPage**](SignInPage.md)|  | 

### Return type

[**SignInPage**](SignInPage.md)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully replaced the sign-in page. |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacesignoutpagesettings"></a>
# **ReplaceSignOutPageSettings**
> HostedPage ReplaceSignOutPageSettings (string brandId, HostedPage hostedPage)

Replace the Sign-out Page Settings

Replaces the sign-out page settings.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceSignOutPageSettingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var hostedPage = new HostedPage(); // HostedPage | 

            try
            {
                // Replace the Sign-out Page Settings
                HostedPage result = apiInstance.ReplaceSignOutPageSettings(brandId, hostedPage);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.ReplaceSignOutPageSettings: " + e.Message );
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
 **hostedPage** | [**HostedPage**](HostedPage.md)|  | 

### Return type

[**HostedPage**](HostedPage.md)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully replaced the sign-out page settings. |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="reseterrorpage"></a>
# **ResetErrorPage**
> void ResetErrorPage (string brandId)

Reset the Error Page

Resets the error page.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ResetErrorPageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.

            try
            {
                // Reset the Error Page
                apiInstance.ResetErrorPage(brandId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.ResetErrorPage: " + e.Message );
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

### Return type

void (empty response body)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Successfully reset the error page. |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="resetsigninpage"></a>
# **ResetSignInPage**
> void ResetSignInPage (string brandId)

Reset the Sign-in Page

Reset the sign-in page.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ResetSignInPageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.

            try
            {
                // Reset the Sign-in Page
                apiInstance.ResetSignInPage(brandId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.ResetSignInPage: " + e.Message );
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

### Return type

void (empty response body)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Successfully reset the sign-in page. |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="retrieveerrorpage"></a>
# **RetrieveErrorPage**
> CustomizablePage RetrieveErrorPage (string brandId)

Retrieve the Error Page

Retrieves the error page.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RetrieveErrorPageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.

            try
            {
                // Retrieve the Error Page
                CustomizablePage result = apiInstance.RetrieveErrorPage(brandId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.RetrieveErrorPage: " + e.Message );
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

### Return type

[**CustomizablePage**](CustomizablePage.md)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully retrieved the error page. |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="retrievesigninpage"></a>
# **RetrieveSignInPage**
> SignInPage RetrieveSignInPage (string brandId)

Retrieve the Sign-in Page

Retrieves the sign-in page.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RetrieveSignInPageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.

            try
            {
                // Retrieve the Sign-in Page
                SignInPage result = apiInstance.RetrieveSignInPage(brandId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.RetrieveSignInPage: " + e.Message );
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

### Return type

[**SignInPage**](SignInPage.md)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully retrieved the sign-in page. |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="retrievesignoutpagesettings"></a>
# **RetrieveSignOutPageSettings**
> HostedPage RetrieveSignOutPageSettings (string brandId)

Retrieve the Sign-out Page Settings

Retrieves the sign-out page settings.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RetrieveSignOutPageSettingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.

            try
            {
                // Retrieve the Sign-out Page Settings
                HostedPage result = apiInstance.RetrieveSignOutPageSettings(brandId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.RetrieveSignOutPageSettings: " + e.Message );
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

### Return type

[**HostedPage**](HostedPage.md)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully retrieved the sign-out page settings. |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="sendtestemail"></a>
# **SendTestEmail**
> void SendTestEmail (string brandId, string templateName, string language = null)

Send a Test Email

Sends a test email to the current user’s primary and secondary email addresses. The email content is selected based on the following priority: 1. The email customization for the language specified in the `language` query parameter. 2. The email template's default customization. 3. The email template’s default content, translated to the current user's language.

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
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var templateName = "templateName_example";  // string | The name of the email template.
            var language = "language_example";  // string | The language to use for the email. Defaults to the current user's language if unspecified. (optional) 

            try
            {
                // Send a Test Email
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

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

<a name="updatebrand"></a>
# **UpdateBrand**
> Brand UpdateBrand (string brandId, Brand brand)

Replace a Brand

Updates a brand by `brandId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateBrandExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | 
            var brand = new Brand(); // Brand | 

            try
            {
                // Replace a Brand
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

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

<a name="updatebrandtheme"></a>
# **UpdateBrandTheme**
> ThemeResponse UpdateBrandTheme (string brandId, string themeId, Theme theme)

Replace a Theme

Updates a theme for a brand

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateBrandThemeExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | 
            var themeId = "themeId_example";  // string | 
            var theme = new Theme(); // Theme | 

            try
            {
                // Replace a Theme
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

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

<a name="updateemailcustomization"></a>
# **UpdateEmailCustomization**
> EmailCustomization UpdateEmailCustomization (string brandId, string templateName, string customizationId, EmailCustomization instance = null)

Replace an Email Customization

Updates an existing email customization using the property values provided.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateEmailCustomizationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var templateName = "templateName_example";  // string | The name of the email template.
            var customizationId = "customizationId_example";  // string | The ID of the email customization.
            var instance = new EmailCustomization(); // EmailCustomization | Request (optional) 

            try
            {
                // Replace an Email Customization
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

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

<a name="updateemailsettings"></a>
# **UpdateEmailSettings**
> void UpdateEmailSettings (string brandId, string templateName, EmailSettings emailSettings = null)

Replace the Email Template Settings

Updates an email template's settings.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateEmailSettingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand.
            var templateName = "templateName_example";  // string | The name of the email template.
            var emailSettings = new EmailSettings(); // EmailSettings |  (optional) 

            try
            {
                // Replace the Email Template Settings
                apiInstance.UpdateEmailSettings(brandId, templateName, emailSettings);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.UpdateEmailSettings: " + e.Message );
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
 **emailSettings** | [**EmailSettings**](EmailSettings.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Successfully updated the email template&#39;s settings. |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **422** | Could not update the email template&#39;s settings due to an invalid setting value. |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="uploadbrandthemebackgroundimage"></a>
# **UploadBrandThemeBackgroundImage**
> ImageUploadResponse UploadBrandThemeBackgroundImage (string brandId, string themeId, System.IO.Stream file)

Upload the Background Image

Updates the background image for your Theme

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UploadBrandThemeBackgroundImageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | 
            var themeId = "themeId_example";  // string | 
            var file = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream | 

            try
            {
                // Upload the Background Image
                ImageUploadResponse result = apiInstance.UploadBrandThemeBackgroundImage(brandId, themeId, file);
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
 **file** | **System.IO.Stream****System.IO.Stream**|  | 

### Return type

[**ImageUploadResponse**](ImageUploadResponse.md)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="uploadbrandthemefavicon"></a>
# **UploadBrandThemeFavicon**
> ImageUploadResponse UploadBrandThemeFavicon (string brandId, string themeId, System.IO.Stream file)

Upload the Favicon

Updates the favicon for your theme

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UploadBrandThemeFaviconExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | 
            var themeId = "themeId_example";  // string | 
            var file = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream | 

            try
            {
                // Upload the Favicon
                ImageUploadResponse result = apiInstance.UploadBrandThemeFavicon(brandId, themeId, file);
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
 **file** | **System.IO.Stream****System.IO.Stream**|  | 

### Return type

[**ImageUploadResponse**](ImageUploadResponse.md)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="uploadbrandthemelogo"></a>
# **UploadBrandThemeLogo**
> ImageUploadResponse UploadBrandThemeLogo (string brandId, string themeId, System.IO.Stream file)

Upload the Logo

Updates the logo for your Theme

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UploadBrandThemeLogoExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | 
            var themeId = "themeId_example";  // string | 
            var file = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream | 

            try
            {
                // Upload the Logo
                ImageUploadResponse result = apiInstance.UploadBrandThemeLogo(brandId, themeId, file);
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
 **file** | **System.IO.Stream****System.IO.Stream**|  | 

### Return type

[**ImageUploadResponse**](ImageUploadResponse.md)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

### HTTP request headers

 - **Content-Type**: multipart/form-data
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

