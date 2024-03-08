# Okta.Sdk.Api.CustomizationApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateBrand**](CustomizationApi.md#createbrand) | **POST** /api/v1/brands | Create a Brand
[**CreateEmailCustomization**](CustomizationApi.md#createemailcustomization) | **POST** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations | Create an Email Customization
[**DeleteAllCustomizations**](CustomizationApi.md#deleteallcustomizations) | **DELETE** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations | Delete all Email Customizations
[**DeleteBrand**](CustomizationApi.md#deletebrand) | **DELETE** /api/v1/brands/{brandId} | Delete a brand
[**DeleteBrandThemeBackgroundImage**](CustomizationApi.md#deletebrandthemebackgroundimage) | **DELETE** /api/v1/brands/{brandId}/themes/{themeId}/background-image | Delete the Background Image
[**DeleteBrandThemeFavicon**](CustomizationApi.md#deletebrandthemefavicon) | **DELETE** /api/v1/brands/{brandId}/themes/{themeId}/favicon | Delete the Favicon
[**DeleteBrandThemeLogo**](CustomizationApi.md#deletebrandthemelogo) | **DELETE** /api/v1/brands/{brandId}/themes/{themeId}/logo | Delete the Logo
[**DeleteCustomizedErrorPage**](CustomizationApi.md#deletecustomizederrorpage) | **DELETE** /api/v1/brands/{brandId}/pages/error/customized | Delete the Customized Error Page
[**DeleteCustomizedSignInPage**](CustomizationApi.md#deletecustomizedsigninpage) | **DELETE** /api/v1/brands/{brandId}/pages/sign-in/customized | Delete the Customized Sign-in Page
[**DeleteEmailCustomization**](CustomizationApi.md#deleteemailcustomization) | **DELETE** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId} | Delete an Email Customization
[**DeletePreviewErrorPage**](CustomizationApi.md#deletepreviewerrorpage) | **DELETE** /api/v1/brands/{brandId}/pages/error/preview | Delete the Preview Error Page
[**DeletePreviewSignInPage**](CustomizationApi.md#deletepreviewsigninpage) | **DELETE** /api/v1/brands/{brandId}/pages/sign-in/preview | Delete the Preview Sign-in Page
[**GetBrand**](CustomizationApi.md#getbrand) | **GET** /api/v1/brands/{brandId} | Retrieve a Brand
[**GetBrandTheme**](CustomizationApi.md#getbrandtheme) | **GET** /api/v1/brands/{brandId}/themes/{themeId} | Retrieve a Theme
[**GetCustomizationPreview**](CustomizationApi.md#getcustomizationpreview) | **GET** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId}/preview | Retrieve a Preview of an Email Customization
[**GetCustomizedErrorPage**](CustomizationApi.md#getcustomizederrorpage) | **GET** /api/v1/brands/{brandId}/pages/error/customized | Retrieve the Customized Error Page
[**GetCustomizedSignInPage**](CustomizationApi.md#getcustomizedsigninpage) | **GET** /api/v1/brands/{brandId}/pages/sign-in/customized | Retrieve the Customized Sign-in Page
[**GetDefaultErrorPage**](CustomizationApi.md#getdefaulterrorpage) | **GET** /api/v1/brands/{brandId}/pages/error/default | Retrieve the Default Error Page
[**GetDefaultSignInPage**](CustomizationApi.md#getdefaultsigninpage) | **GET** /api/v1/brands/{brandId}/pages/sign-in/default | Retrieve the Default Sign-in Page
[**GetEmailCustomization**](CustomizationApi.md#getemailcustomization) | **GET** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId} | Retrieve an Email Customization
[**GetEmailDefaultContent**](CustomizationApi.md#getemaildefaultcontent) | **GET** /api/v1/brands/{brandId}/templates/email/{templateName}/default-content | Retrieve an Email Template Default Content
[**GetEmailDefaultPreview**](CustomizationApi.md#getemaildefaultpreview) | **GET** /api/v1/brands/{brandId}/templates/email/{templateName}/default-content/preview | Retrieve a Preview of the Email Template Default Content
[**GetEmailSettings**](CustomizationApi.md#getemailsettings) | **GET** /api/v1/brands/{brandId}/templates/email/{templateName}/settings | Retrieve the Email Template Settings
[**GetEmailTemplate**](CustomizationApi.md#getemailtemplate) | **GET** /api/v1/brands/{brandId}/templates/email/{templateName} | Retrieve an Email Template
[**GetErrorPage**](CustomizationApi.md#geterrorpage) | **GET** /api/v1/brands/{brandId}/pages/error | Retrieve the Error Page Sub-Resources
[**GetPreviewErrorPage**](CustomizationApi.md#getpreviewerrorpage) | **GET** /api/v1/brands/{brandId}/pages/error/preview | Retrieve the Preview Error Page Preview
[**GetPreviewSignInPage**](CustomizationApi.md#getpreviewsigninpage) | **GET** /api/v1/brands/{brandId}/pages/sign-in/preview | Retrieve the Preview Sign-in Page Preview
[**GetSignInPage**](CustomizationApi.md#getsigninpage) | **GET** /api/v1/brands/{brandId}/pages/sign-in | Retrieve the Sign-in Page Sub-Resources
[**GetSignOutPageSettings**](CustomizationApi.md#getsignoutpagesettings) | **GET** /api/v1/brands/{brandId}/pages/sign-out/customized | Retrieve the Sign-out Page Settings
[**ListAllSignInWidgetVersions**](CustomizationApi.md#listallsigninwidgetversions) | **GET** /api/v1/brands/{brandId}/pages/sign-in/widget-versions | List all Sign-in Widget Versions
[**ListBrandDomains**](CustomizationApi.md#listbranddomains) | **GET** /api/v1/brands/{brandId}/domains | List all Domains associated with a Brand
[**ListBrandThemes**](CustomizationApi.md#listbrandthemes) | **GET** /api/v1/brands/{brandId}/themes | List all Themes
[**ListBrands**](CustomizationApi.md#listbrands) | **GET** /api/v1/brands | List all Brands
[**ListEmailCustomizations**](CustomizationApi.md#listemailcustomizations) | **GET** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations | List all Email Customizations
[**ListEmailTemplates**](CustomizationApi.md#listemailtemplates) | **GET** /api/v1/brands/{brandId}/templates/email | List all Email Templates
[**ReplaceBrand**](CustomizationApi.md#replacebrand) | **PUT** /api/v1/brands/{brandId} | Replace a Brand
[**ReplaceBrandTheme**](CustomizationApi.md#replacebrandtheme) | **PUT** /api/v1/brands/{brandId}/themes/{themeId} | Replace a Theme
[**ReplaceCustomizedErrorPage**](CustomizationApi.md#replacecustomizederrorpage) | **PUT** /api/v1/brands/{brandId}/pages/error/customized | Replace the Customized Error Page
[**ReplaceCustomizedSignInPage**](CustomizationApi.md#replacecustomizedsigninpage) | **PUT** /api/v1/brands/{brandId}/pages/sign-in/customized | Replace the Customized Sign-in Page
[**ReplaceEmailCustomization**](CustomizationApi.md#replaceemailcustomization) | **PUT** /api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId} | Replace an Email Customization
[**ReplaceEmailSettings**](CustomizationApi.md#replaceemailsettings) | **PUT** /api/v1/brands/{brandId}/templates/email/{templateName}/settings | Replace the Email Template Settings
[**ReplacePreviewErrorPage**](CustomizationApi.md#replacepreviewerrorpage) | **PUT** /api/v1/brands/{brandId}/pages/error/preview | Replace the Preview Error Page
[**ReplacePreviewSignInPage**](CustomizationApi.md#replacepreviewsigninpage) | **PUT** /api/v1/brands/{brandId}/pages/sign-in/preview | Replace the Preview Sign-in Page
[**ReplaceSignOutPageSettings**](CustomizationApi.md#replacesignoutpagesettings) | **PUT** /api/v1/brands/{brandId}/pages/sign-out/customized | Replace the Sign-out Page Settings
[**SendTestEmail**](CustomizationApi.md#sendtestemail) | **POST** /api/v1/brands/{brandId}/templates/email/{templateName}/test | Send a Test Email
[**UploadBrandThemeBackgroundImage**](CustomizationApi.md#uploadbrandthemebackgroundimage) | **POST** /api/v1/brands/{brandId}/themes/{themeId}/background-image | Upload the Background Image
[**UploadBrandThemeFavicon**](CustomizationApi.md#uploadbrandthemefavicon) | **POST** /api/v1/brands/{brandId}/themes/{themeId}/favicon | Upload the Favicon
[**UploadBrandThemeLogo**](CustomizationApi.md#uploadbrandthemelogo) | **POST** /api/v1/brands/{brandId}/themes/{themeId}/logo | Upload the Logo


<a name="createbrand"></a>
# **CreateBrand**
> Brand CreateBrand (List<string> expand = null, string after = null, int? limit = null, string q = null, CreateBrandRequest createBrandRequest = null)

Create a Brand

Creates a new brand in your org

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateBrandExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var expand = new List<string>(); // List<string> | Specifies additional metadata to be included in the response (optional) 
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](/#pagination) for more information. (optional) 
            var limit = 20;  // int? | A limit on the number of objects to return (optional)  (default to 20)
            var q = "q_example";  // string | Searches the records for matching value (optional) 
            var createBrandRequest = new CreateBrandRequest(); // CreateBrandRequest |  (optional) 

            try
            {
                // Create a Brand
                Brand result = apiInstance.CreateBrand(expand, after, limit, q, createBrandRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.CreateBrand: " + e.Message );
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
 **expand** | [**List&lt;string&gt;**](string.md)| Specifies additional metadata to be included in the response | [optional] 
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](/#pagination) for more information. | [optional] 
 **limit** | **int?**| A limit on the number of objects to return | [optional] [default to 20]
 **q** | **string**| Searches the records for matching value | [optional] 
 **createBrandRequest** | [**CreateBrandRequest**](CreateBrandRequest.md)|  | [optional] 

### Return type

[**Brand**](Brand.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **400** |  |  -  |
| **403** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createemailcustomization"></a>
# **CreateEmailCustomization**
> EmailCustomization CreateEmailCustomization (string brandId, string templateName, EmailCustomization instance = null)

Create an Email Customization

Creates a new email customization

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

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var templateName = "templateName_example";  // string | The name of the email template
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
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **409** | Could not create the email customization because it conflicts with an existing email customization. |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteallcustomizations"></a>
# **DeleteAllCustomizations**
> void DeleteAllCustomizations (string brandId, string templateName)

Delete all Email Customizations

Deletes all customizations for an email template

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

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var templateName = "templateName_example";  // string | The name of the email template

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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletebrand"></a>
# **DeleteBrand**
> void DeleteBrand (string brandId, List<string> expand = null)

Delete a brand

Deletes a brand by `brandId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteBrandExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var expand = new List<string>(); // List<string> | Specifies additional metadata to be included in the response (optional) 

            try
            {
                // Delete a brand
                apiInstance.DeleteBrand(brandId, expand);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.DeleteBrand: " + e.Message );
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
 **expand** | [**List&lt;string&gt;**](string.md)| Specifies additional metadata to be included in the response | [optional] 

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
| **204** | Successfully deleted the brand. |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **409** | Conflict |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletebrandthemebackgroundimage"></a>
# **DeleteBrandThemeBackgroundImage**
> void DeleteBrandThemeBackgroundImage (string brandId, string themeId)

Delete the Background Image

Deletes a Theme background image

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var themeId = "themeId_example";  // string | The ID of the theme

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
 **brandId** | **string**| The ID of the brand | 
 **themeId** | **string**| The ID of the theme | 

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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var themeId = "themeId_example";  // string | The ID of the theme

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
 **brandId** | **string**| The ID of the brand | 
 **themeId** | **string**| The ID of the theme | 

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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var themeId = "themeId_example";  // string | The ID of the theme

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
 **brandId** | **string**| The ID of the brand | 
 **themeId** | **string**| The ID of the theme | 

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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletecustomizederrorpage"></a>
# **DeleteCustomizedErrorPage**
> void DeleteCustomizedErrorPage (string brandId)

Delete the Customized Error Page

Deletes the customized error page. As a result, the default error page appears in your live environment.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteCustomizedErrorPageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

            try
            {
                // Delete the Customized Error Page
                apiInstance.DeleteCustomizedErrorPage(brandId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.DeleteCustomizedErrorPage: " + e.Message );
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
| **204** | Successfully deleted the customized error page. |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletecustomizedsigninpage"></a>
# **DeleteCustomizedSignInPage**
> void DeleteCustomizedSignInPage (string brandId)

Delete the Customized Sign-in Page

Deletes the customized sign-in page. As a result, the default sign-in page appears in your live environment.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteCustomizedSignInPageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

            try
            {
                // Delete the Customized Sign-in Page
                apiInstance.DeleteCustomizedSignInPage(brandId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.DeleteCustomizedSignInPage: " + e.Message );
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
| **204** | Successfully deleted the sign-in page. |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteemailcustomization"></a>
# **DeleteEmailCustomization**
> void DeleteEmailCustomization (string brandId, string templateName, string customizationId)

Delete an Email Customization

Deletes an email customization by its unique identifier

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

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var templateName = "templateName_example";  // string | The name of the email template
            var customizationId = "customizationId_example";  // string | The ID of the email customization

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
| **403** |  |  -  |
| **404** |  |  -  |
| **409** | Could not delete the email customization deleted because it is the default email customization. |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletepreviewerrorpage"></a>
# **DeletePreviewErrorPage**
> void DeletePreviewErrorPage (string brandId)

Delete the Preview Error Page

Deletes the preview error page. The preview error page contains unpublished changes and isn't shown in your live environment. Preview it at `${yourOktaDomain}/error/preview`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeletePreviewErrorPageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

            try
            {
                // Delete the Preview Error Page
                apiInstance.DeletePreviewErrorPage(brandId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.DeletePreviewErrorPage: " + e.Message );
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
| **204** | Successfully deleted the preview error page. |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletepreviewsigninpage"></a>
# **DeletePreviewSignInPage**
> void DeletePreviewSignInPage (string brandId)

Delete the Preview Sign-in Page

Deletes the preview sign-in page. The preview sign-in page contains unpublished changes and isn't shown in your live environment. Preview it at `${yourOktaDomain}/login/preview`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeletePreviewSignInPageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

            try
            {
                // Delete the Preview Sign-in Page
                apiInstance.DeletePreviewSignInPage(brandId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.DeletePreviewSignInPage: " + e.Message );
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
| **204** | Successfully deleted the preview sign-in page. |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getbrand"></a>
# **GetBrand**
> BrandWithEmbedded GetBrand (string brandId, List<string> expand = null)

Retrieve a Brand

Retrieves a brand by `brandId`

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var expand = new List<string>(); // List<string> | Specifies additional metadata to be included in the response (optional) 

            try
            {
                // Retrieve a Brand
                BrandWithEmbedded result = apiInstance.GetBrand(brandId, expand);
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
 **brandId** | **string**| The ID of the brand | 
 **expand** | [**List&lt;string&gt;**](string.md)| Specifies additional metadata to be included in the response | [optional] 

### Return type

[**BrandWithEmbedded**](BrandWithEmbedded.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getbrandtheme"></a>
# **GetBrandTheme**
> ThemeResponse GetBrandTheme (string brandId, string themeId)

Retrieve a Theme

Retrieves a theme for a brand

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var themeId = "themeId_example";  // string | The ID of the theme

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
 **brandId** | **string**| The ID of the brand | 
 **themeId** | **string**| The ID of the theme | 

### Return type

[**ThemeResponse**](ThemeResponse.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getcustomizationpreview"></a>
# **GetCustomizationPreview**
> EmailPreview GetCustomizationPreview (string brandId, string templateName, string customizationId)

Retrieve a Preview of an Email Customization

Retrieves a preview of an email customization. All variable references (e.g., `${user.profile.firstName}`) are populated using the current user's context.

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

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var templateName = "templateName_example";  // string | The name of the email template
            var customizationId = "customizationId_example";  // string | The ID of the email customization

            try
            {
                // Retrieve a Preview of an Email Customization
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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getcustomizederrorpage"></a>
# **GetCustomizedErrorPage**
> ErrorPage GetCustomizedErrorPage (string brandId)

Retrieve the Customized Error Page

Retrieves the customized error page. The customized error page appears in your live environment.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetCustomizedErrorPageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

            try
            {
                // Retrieve the Customized Error Page
                ErrorPage result = apiInstance.GetCustomizedErrorPage(brandId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.GetCustomizedErrorPage: " + e.Message );
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

### Return type

[**ErrorPage**](ErrorPage.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully retrieved the customized error page. |  * Location -  <br>  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getcustomizedsigninpage"></a>
# **GetCustomizedSignInPage**
> SignInPage GetCustomizedSignInPage (string brandId)

Retrieve the Customized Sign-in Page

Retrieves the customized sign-in page. The customized sign-in page appears in your live environment.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetCustomizedSignInPageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

            try
            {
                // Retrieve the Customized Sign-in Page
                SignInPage result = apiInstance.GetCustomizedSignInPage(brandId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.GetCustomizedSignInPage: " + e.Message );
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

### Return type

[**SignInPage**](SignInPage.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully retrieved the customized sign-in page. |  * Location -  <br>  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getdefaulterrorpage"></a>
# **GetDefaultErrorPage**
> ErrorPage GetDefaultErrorPage (string brandId)

Retrieve the Default Error Page

Retrieves the default error page. The default error page appears when no customized error page exists.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetDefaultErrorPageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

            try
            {
                // Retrieve the Default Error Page
                ErrorPage result = apiInstance.GetDefaultErrorPage(brandId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.GetDefaultErrorPage: " + e.Message );
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

### Return type

[**ErrorPage**](ErrorPage.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully retrieved the default error page. |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getdefaultsigninpage"></a>
# **GetDefaultSignInPage**
> SignInPage GetDefaultSignInPage (string brandId)

Retrieve the Default Sign-in Page

Retrieves the default sign-in page. The default sign-in page appears when no customized sign-in page exists.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetDefaultSignInPageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

            try
            {
                // Retrieve the Default Sign-in Page
                SignInPage result = apiInstance.GetDefaultSignInPage(brandId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.GetDefaultSignInPage: " + e.Message );
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

### Return type

[**SignInPage**](SignInPage.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully retrieved the default sign-in page. |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getemailcustomization"></a>
# **GetEmailCustomization**
> EmailCustomization GetEmailCustomization (string brandId, string templateName, string customizationId)

Retrieve an Email Customization

Retrieves an email customization by its unique identifier

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

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var templateName = "templateName_example";  // string | The name of the email template
            var customizationId = "customizationId_example";  // string | The ID of the email customization

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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getemaildefaultcontent"></a>
# **GetEmailDefaultContent**
> EmailDefaultContent GetEmailDefaultContent (string language = null)

Retrieve an Email Template Default Content

Retrieves an email template's default content

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

            var apiInstance = new CustomizationApi(config);
            var language = "language_example";  // string | The language to use for the email. Defaults to the current user's language if unspecified. (optional) 

            try
            {
                // Retrieve an Email Template Default Content
                EmailDefaultContent result = apiInstance.GetEmailDefaultContent(language);
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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getemaildefaultpreview"></a>
# **GetEmailDefaultPreview**
> EmailPreview GetEmailDefaultPreview (string language = null)

Retrieve a Preview of the Email Template Default Content

Retrieves a preview of an email template's default content. All variable references (e.g., `${user.profile.firstName}`) are populated using the current user's context.

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

            var apiInstance = new CustomizationApi(config);
            var language = "language_example";  // string | The language to use for the email. Defaults to the current user's language if unspecified. (optional) 

            try
            {
                // Retrieve a Preview of the Email Template Default Content
                EmailPreview result = apiInstance.GetEmailDefaultPreview(language);
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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getemailsettings"></a>
# **GetEmailSettings**
> EmailSettings GetEmailSettings (string brandId, string templateName)

Retrieve the Email Template Settings

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

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var templateName = "templateName_example";  // string | The name of the email template

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
 **brandId** | **string**| The ID of the brand | 
 **templateName** | **string**| The name of the email template | 

### Return type

[**EmailSettings**](EmailSettings.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully retrieved the email template&#39;s settings. |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getemailtemplate"></a>
# **GetEmailTemplate**
> EmailTemplate GetEmailTemplate (List<string> expand = null)

Retrieve an Email Template

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

            var apiInstance = new CustomizationApi(config);
            var expand = new List<string>(); // List<string> | Specifies additional metadata to be included in the response (optional) 

            try
            {
                // Retrieve an Email Template
                EmailTemplate result = apiInstance.GetEmailTemplate(expand);
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
 **expand** | [**List&lt;string&gt;**](string.md)| Specifies additional metadata to be included in the response | [optional] 

### Return type

[**EmailTemplate**](EmailTemplate.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully retrieved the email template. |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="geterrorpage"></a>
# **GetErrorPage**
> PageRoot GetErrorPage (string brandId, List<string> expand = null)

Retrieve the Error Page Sub-Resources

Retrieves the error page sub-resources. The `expand` query parameter specifies which sub-resources to include in the response.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetErrorPageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var expand = new List<string>(); // List<string> | Specifies additional metadata to be included in the response (optional) 

            try
            {
                // Retrieve the Error Page Sub-Resources
                PageRoot result = apiInstance.GetErrorPage(brandId, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.GetErrorPage: " + e.Message );
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
 **expand** | [**List&lt;string&gt;**](string.md)| Specifies additional metadata to be included in the response | [optional] 

### Return type

[**PageRoot**](PageRoot.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully retrieved the error page. |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getpreviewerrorpage"></a>
# **GetPreviewErrorPage**
> ErrorPage GetPreviewErrorPage (string brandId)

Retrieve the Preview Error Page Preview

Retrieves the preview error page. The preview error page contains unpublished changes and isn't shown in your live environment. Preview it at `${yourOktaDomain}/error/preview`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetPreviewErrorPageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

            try
            {
                // Retrieve the Preview Error Page Preview
                ErrorPage result = apiInstance.GetPreviewErrorPage(brandId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.GetPreviewErrorPage: " + e.Message );
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

### Return type

[**ErrorPage**](ErrorPage.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully retrieved the preview error page. |  * Location -  <br>  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getpreviewsigninpage"></a>
# **GetPreviewSignInPage**
> SignInPage GetPreviewSignInPage (string brandId)

Retrieve the Preview Sign-in Page Preview

Retrieves the preview sign-in page. The preview sign-in page contains unpublished changes and isn't shown in your live environment. Preview it at `${yourOktaDomain}/login/preview`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetPreviewSignInPageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

            try
            {
                // Retrieve the Preview Sign-in Page Preview
                SignInPage result = apiInstance.GetPreviewSignInPage(brandId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.GetPreviewSignInPage: " + e.Message );
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

### Return type

[**SignInPage**](SignInPage.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully retrieved the preview sign-in page. |  * Location -  <br>  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getsigninpage"></a>
# **GetSignInPage**
> PageRoot GetSignInPage (string brandId, List<string> expand = null)

Retrieve the Sign-in Page Sub-Resources

Retrieves the sign-in page sub-resources. The `expand` query parameter specifies which sub-resources to include in the response.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetSignInPageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var expand = new List<string>(); // List<string> | Specifies additional metadata to be included in the response (optional) 

            try
            {
                // Retrieve the Sign-in Page Sub-Resources
                PageRoot result = apiInstance.GetSignInPage(brandId, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.GetSignInPage: " + e.Message );
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
 **expand** | [**List&lt;string&gt;**](string.md)| Specifies additional metadata to be included in the response | [optional] 

### Return type

[**PageRoot**](PageRoot.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully retrieved the sign-in page. |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getsignoutpagesettings"></a>
# **GetSignOutPageSettings**
> HostedPage GetSignOutPageSettings (string brandId)

Retrieve the Sign-out Page Settings

Retrieves the sign-out page settings

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetSignOutPageSettingsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

            try
            {
                // Retrieve the Sign-out Page Settings
                HostedPage result = apiInstance.GetSignOutPageSettings(brandId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.GetSignOutPageSettings: " + e.Message );
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

### Return type

[**HostedPage**](HostedPage.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully retrieved the sign-out page settings. |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listallsigninwidgetversions"></a>
# **ListAllSignInWidgetVersions**
> List&lt;string&gt; ListAllSignInWidgetVersions (string brandId)

List all Sign-in Widget Versions

Lists all sign-in widget versions supported by the current org

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

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
 **brandId** | **string**| The ID of the brand | 

### Return type

**List<string>**

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully listed the sign-in widget versions. |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listbranddomains"></a>
# **ListBrandDomains**
> List&lt;DomainResponse&gt; ListBrandDomains (string brandId)

List all Domains associated with a Brand

Lists all domains associated with a brand by `brandId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListBrandDomainsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

            try
            {
                // List all Domains associated with a Brand
                List<DomainResponse> result = apiInstance.ListBrandDomains(brandId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.ListBrandDomains: " + e.Message );
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

### Return type

[**List&lt;DomainResponse&gt;**](DomainResponse.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listbrandthemes"></a>
# **ListBrandThemes**
> List&lt;ThemeResponse&gt; ListBrandThemes (string brandId)

List all Themes

Lists all the themes in your brand

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

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
 **brandId** | **string**| The ID of the brand | 

### Return type

[**List&lt;ThemeResponse&gt;**](ThemeResponse.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listbrands"></a>
# **ListBrands**
> List&lt;BrandWithEmbedded&gt; ListBrands (List<string> expand = null, string after = null, int? limit = null, string q = null)

List all Brands

Lists all the brands in your org

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var expand = new List<string>(); // List<string> | Specifies additional metadata to be included in the response (optional) 
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](/#pagination) for more information. (optional) 
            var limit = 20;  // int? | A limit on the number of objects to return (optional)  (default to 20)
            var q = "q_example";  // string | Searches the records for matching value (optional) 

            try
            {
                // List all Brands
                List<BrandWithEmbedded> result = apiInstance.ListBrands(expand, after, limit, q).ToListAsync();
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

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **expand** | [**List&lt;string&gt;**](string.md)| Specifies additional metadata to be included in the response | [optional] 
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](/#pagination) for more information. | [optional] 
 **limit** | **int?**| A limit on the number of objects to return | [optional] [default to 20]
 **q** | **string**| Searches the records for matching value | [optional] 

### Return type

[**List&lt;BrandWithEmbedded&gt;**](BrandWithEmbedded.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **403** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listemailcustomizations"></a>
# **ListEmailCustomizations**
> List&lt;EmailCustomization&gt; ListEmailCustomizations (string after = null, int? limit = null)

List all Email Customizations

Lists all customizations of an email template

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

            var apiInstance = new CustomizationApi(config);
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](/#pagination) for more information. (optional) 
            var limit = 20;  // int? | A limit on the number of objects to return (optional)  (default to 20)

            try
            {
                // List all Email Customizations
                List<EmailCustomization> result = apiInstance.ListEmailCustomizations(after, limit).ToListAsync();
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
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](/#pagination) for more information. | [optional] 
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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listemailtemplates"></a>
# **ListEmailTemplates**
> List&lt;EmailTemplate&gt; ListEmailTemplates (string after = null, int? limit = null, List<string> expand = null)

List all Email Templates

Lists all email templates

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

            var apiInstance = new CustomizationApi(config);
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](/#pagination) for more information. (optional) 
            var limit = 20;  // int? | A limit on the number of objects to return (optional)  (default to 20)
            var expand = new List<string>(); // List<string> | Specifies additional metadata to be included in the response (optional) 

            try
            {
                // List all Email Templates
                List<EmailTemplate> result = apiInstance.ListEmailTemplates(after, limit, expand).ToListAsync();
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
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](/#pagination) for more information. | [optional] 
 **limit** | **int?**| A limit on the number of objects to return | [optional] [default to 20]
 **expand** | [**List&lt;string&gt;**](string.md)| Specifies additional metadata to be included in the response | [optional] 

### Return type

[**List&lt;EmailTemplate&gt;**](EmailTemplate.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully returned the list of email templates. |  * Link - The pagination header containing links to the current and next page of results. See [Pagination](/#pagination) for more information. <br>  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacebrand"></a>
# **ReplaceBrand**
> Brand ReplaceBrand (string brandId, BrandRequest brand, List<string> expand = null)

Replace a Brand

Replaces a brand by `brandId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceBrandExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var brand = new BrandRequest(); // BrandRequest | 
            var expand = new List<string>(); // List<string> | Specifies additional metadata to be included in the response (optional) 

            try
            {
                // Replace a Brand
                Brand result = apiInstance.ReplaceBrand(brandId, brand, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.ReplaceBrand: " + e.Message );
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
 **brand** | [**BrandRequest**](BrandRequest.md)|  | 
 **expand** | [**List&lt;string&gt;**](string.md)| Specifies additional metadata to be included in the response | [optional] 

### Return type

[**Brand**](Brand.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacebrandtheme"></a>
# **ReplaceBrandTheme**
> ThemeResponse ReplaceBrandTheme (string brandId, string themeId, Theme theme)

Replace a Theme

Replaces a theme for a brand

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceBrandThemeExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var themeId = "themeId_example";  // string | The ID of the theme
            var theme = new Theme(); // Theme | 

            try
            {
                // Replace a Theme
                ThemeResponse result = apiInstance.ReplaceBrandTheme(brandId, themeId, theme);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.ReplaceBrandTheme: " + e.Message );
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
 **themeId** | **string**| The ID of the theme | 
 **theme** | [**Theme**](Theme.md)|  | 

### Return type

[**ThemeResponse**](ThemeResponse.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacecustomizederrorpage"></a>
# **ReplaceCustomizedErrorPage**
> ErrorPage ReplaceCustomizedErrorPage (string brandId, ErrorPage errorPage)

Replace the Customized Error Page

Replaces the customized error page. The customized error page appears in your live environment.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceCustomizedErrorPageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var errorPage = new ErrorPage(); // ErrorPage | 

            try
            {
                // Replace the Customized Error Page
                ErrorPage result = apiInstance.ReplaceCustomizedErrorPage(brandId, errorPage);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.ReplaceCustomizedErrorPage: " + e.Message );
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
 **errorPage** | [**ErrorPage**](ErrorPage.md)|  | 

### Return type

[**ErrorPage**](ErrorPage.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully replaced the customized error page. |  * Location -  <br>  |
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacecustomizedsigninpage"></a>
# **ReplaceCustomizedSignInPage**
> SignInPage ReplaceCustomizedSignInPage (string brandId, SignInPage signInPage)

Replace the Customized Sign-in Page

Replaces the customized sign-in page. The customized sign-in page appears in your live environment.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceCustomizedSignInPageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var signInPage = new SignInPage(); // SignInPage | 

            try
            {
                // Replace the Customized Sign-in Page
                SignInPage result = apiInstance.ReplaceCustomizedSignInPage(brandId, signInPage);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.ReplaceCustomizedSignInPage: " + e.Message );
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
 **signInPage** | [**SignInPage**](SignInPage.md)|  | 

### Return type

[**SignInPage**](SignInPage.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully replaced the customized sign-in page. |  * Location -  <br>  |
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replaceemailcustomization"></a>
# **ReplaceEmailCustomization**
> EmailCustomization ReplaceEmailCustomization (string brandId, string templateName, string customizationId, EmailCustomization instance = null)

Replace an Email Customization

Replaces an existing email customization using the property values provided

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

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var templateName = "templateName_example";  // string | The name of the email template
            var customizationId = "customizationId_example";  // string | The ID of the email customization
            var instance = new EmailCustomization(); // EmailCustomization | Request (optional) 

            try
            {
                // Replace an Email Customization
                EmailCustomization result = apiInstance.ReplaceEmailCustomization(brandId, templateName, customizationId, instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.ReplaceEmailCustomization: " + e.Message );
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
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **409** | Could not update the email customization because the update would cause a conflict with an existing email customization. |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replaceemailsettings"></a>
# **ReplaceEmailSettings**
> void ReplaceEmailSettings (string brandId, string templateName, EmailSettings emailSettings = null)

Replace the Email Template Settings

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

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var templateName = "templateName_example";  // string | The name of the email template
            var emailSettings = new EmailSettings(); // EmailSettings |  (optional) 

            try
            {
                // Replace the Email Template Settings
                apiInstance.ReplaceEmailSettings(brandId, templateName, emailSettings);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.ReplaceEmailSettings: " + e.Message );
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

void (empty response body)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Successfully updated the email template&#39;s settings. |  -  |
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **422** | Could not update the email template&#39;s settings due to an invalid setting value. |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacepreviewerrorpage"></a>
# **ReplacePreviewErrorPage**
> ErrorPage ReplacePreviewErrorPage (string brandId, ErrorPage errorPage)

Replace the Preview Error Page

Replaces the preview error page. The preview error page contains unpublished changes and isn't shown in your live environment. Preview it at `${yourOktaDomain}/error/preview`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplacePreviewErrorPageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var errorPage = new ErrorPage(); // ErrorPage | 

            try
            {
                // Replace the Preview Error Page
                ErrorPage result = apiInstance.ReplacePreviewErrorPage(brandId, errorPage);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.ReplacePreviewErrorPage: " + e.Message );
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
 **errorPage** | [**ErrorPage**](ErrorPage.md)|  | 

### Return type

[**ErrorPage**](ErrorPage.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully replaced the preview error page. |  * Location -  <br>  |
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacepreviewsigninpage"></a>
# **ReplacePreviewSignInPage**
> SignInPage ReplacePreviewSignInPage (string brandId, SignInPage signInPage)

Replace the Preview Sign-in Page

Replaces the preview sign-in page. The preview sign-in page contains unpublished changes and isn't shown in your live environment. Preview it at `${yourOktaDomain}/login/preview`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplacePreviewSignInPageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var signInPage = new SignInPage(); // SignInPage | 

            try
            {
                // Replace the Preview Sign-in Page
                SignInPage result = apiInstance.ReplacePreviewSignInPage(brandId, signInPage);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomizationApi.ReplacePreviewSignInPage: " + e.Message );
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
 **signInPage** | [**SignInPage**](SignInPage.md)|  | 

### Return type

[**SignInPage**](SignInPage.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully replaced the preview sign-in page. |  * Location -  <br>  |
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacesignoutpagesettings"></a>
# **ReplaceSignOutPageSettings**
> HostedPage ReplaceSignOutPageSettings (string brandId, HostedPage hostedPage)

Replace the Sign-out Page Settings

Replaces the sign-out page settings

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
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
 **brandId** | **string**| The ID of the brand | 
 **hostedPage** | [**HostedPage**](HostedPage.md)|  | 

### Return type

[**HostedPage**](HostedPage.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully replaced the sign-out page settings. |  -  |
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="sendtestemail"></a>
# **SendTestEmail**
> void SendTestEmail (string language = null)

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var language = "language_example";  // string | The language to use for the email. Defaults to the current user's language if unspecified. (optional) 

            try
            {
                // Send a Test Email
                apiInstance.SendTestEmail(language);
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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="uploadbrandthemebackgroundimage"></a>
# **UploadBrandThemeBackgroundImage**
> ImageUploadResponse UploadBrandThemeBackgroundImage (string brandId, string themeId, System.IO.Stream file)

Upload the Background Image

Uploads and replaces the background image for the theme. The file must be in PNG, JPG, or GIF format and less than 2 MB in size.

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var themeId = "themeId_example";  // string | The ID of the theme
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
 **brandId** | **string**| The ID of the brand | 
 **themeId** | **string**| The ID of the theme | 
 **file** | **System.IO.Stream****System.IO.Stream**|  | 

### Return type

[**ImageUploadResponse**](ImageUploadResponse.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="uploadbrandthemefavicon"></a>
# **UploadBrandThemeFavicon**
> ImageUploadResponse UploadBrandThemeFavicon (string brandId, string themeId, System.IO.Stream file)

Upload the Favicon

Uploads and replaces the favicon for the theme

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var themeId = "themeId_example";  // string | The ID of the theme
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
 **brandId** | **string**| The ID of the brand | 
 **themeId** | **string**| The ID of the theme | 
 **file** | **System.IO.Stream****System.IO.Stream**|  | 

### Return type

[**ImageUploadResponse**](ImageUploadResponse.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="uploadbrandthemelogo"></a>
# **UploadBrandThemeLogo**
> ImageUploadResponse UploadBrandThemeLogo (string brandId, string themeId, System.IO.Stream file)

Upload the Logo

Uploads and replaces the logo for the theme. The file must be in PNG, JPG, or GIF format and less than 100kB in size. For best results use landscape orientation, a transparent background, and a minimum size of 300px by 50px to prevent upscaling.

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomizationApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var themeId = "themeId_example";  // string | The ID of the theme
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
 **brandId** | **string**| The ID of the brand | 
 **themeId** | **string**| The ID of the theme | 
 **file** | **System.IO.Stream****System.IO.Stream**|  | 

### Return type

[**ImageUploadResponse**](ImageUploadResponse.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

