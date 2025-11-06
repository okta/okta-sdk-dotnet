# Okta.Sdk.Api.ThemesApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeleteBrandThemeBackgroundImage**](ThemesApi.md#deletebrandthemebackgroundimage) | **DELETE** /api/v1/brands/{brandId}/themes/{themeId}/background-image | Delete the background image
[**DeleteBrandThemeFavicon**](ThemesApi.md#deletebrandthemefavicon) | **DELETE** /api/v1/brands/{brandId}/themes/{themeId}/favicon | Delete the favicon
[**DeleteBrandThemeLogo**](ThemesApi.md#deletebrandthemelogo) | **DELETE** /api/v1/brands/{brandId}/themes/{themeId}/logo | Delete the logo
[**GetBrandTheme**](ThemesApi.md#getbrandtheme) | **GET** /api/v1/brands/{brandId}/themes/{themeId} | Retrieve a theme
[**ListBrandThemes**](ThemesApi.md#listbrandthemes) | **GET** /api/v1/brands/{brandId}/themes | List all themes
[**ReplaceBrandTheme**](ThemesApi.md#replacebrandtheme) | **PUT** /api/v1/brands/{brandId}/themes/{themeId} | Replace a theme
[**UploadBrandThemeBackgroundImage**](ThemesApi.md#uploadbrandthemebackgroundimage) | **POST** /api/v1/brands/{brandId}/themes/{themeId}/background-image | Upload the background image
[**UploadBrandThemeFavicon**](ThemesApi.md#uploadbrandthemefavicon) | **POST** /api/v1/brands/{brandId}/themes/{themeId}/favicon | Upload the favicon
[**UploadBrandThemeLogo**](ThemesApi.md#uploadbrandthemelogo) | **POST** /api/v1/brands/{brandId}/themes/{themeId}/logo | Upload the logo


<a name="deletebrandthemebackgroundimage"></a>
# **DeleteBrandThemeBackgroundImage**
> void DeleteBrandThemeBackgroundImage (string brandId, string themeId)

Delete the background image

Deletes a theme background image

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

            var apiInstance = new ThemesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var themeId = "themeId_example";  // string | The ID of the theme

            try
            {
                // Delete the background image
                apiInstance.DeleteBrandThemeBackgroundImage(brandId, themeId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ThemesApi.DeleteBrandThemeBackgroundImage: " + e.Message );
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletebrandthemefavicon"></a>
# **DeleteBrandThemeFavicon**
> void DeleteBrandThemeFavicon (string brandId, string themeId)

Delete the favicon

Deletes a theme favicon. The theme will use the default Okta favicon.

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

            var apiInstance = new ThemesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var themeId = "themeId_example";  // string | The ID of the theme

            try
            {
                // Delete the favicon
                apiInstance.DeleteBrandThemeFavicon(brandId, themeId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ThemesApi.DeleteBrandThemeFavicon: " + e.Message );
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletebrandthemelogo"></a>
# **DeleteBrandThemeLogo**
> void DeleteBrandThemeLogo (string brandId, string themeId)

Delete the logo

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

            var apiInstance = new ThemesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var themeId = "themeId_example";  // string | The ID of the theme

            try
            {
                // Delete the logo
                apiInstance.DeleteBrandThemeLogo(brandId, themeId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ThemesApi.DeleteBrandThemeLogo: " + e.Message );
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getbrandtheme"></a>
# **GetBrandTheme**
> ThemeResponse GetBrandTheme (string brandId, string themeId)

Retrieve a theme

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

            var apiInstance = new ThemesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var themeId = "themeId_example";  // string | The ID of the theme

            try
            {
                // Retrieve a theme
                ThemeResponse result = apiInstance.GetBrandTheme(brandId, themeId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ThemesApi.GetBrandTheme: " + e.Message );
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
| **200** | Successfully retrieved the theme |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listbrandthemes"></a>
# **ListBrandThemes**
> List&lt;ThemeResponse&gt; ListBrandThemes (string brandId)

List all themes

Lists all the themes in your brand.  > **Important:** Currently each org supports only one theme, therefore this contains a single object only.

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

            var apiInstance = new ThemesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

            try
            {
                // List all themes
                List<ThemeResponse> result = apiInstance.ListBrandThemes(brandId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ThemesApi.ListBrandThemes: " + e.Message );
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
| **200** | Successfully returned the list of themes |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacebrandtheme"></a>
# **ReplaceBrandTheme**
> ThemeResponse ReplaceBrandTheme (string brandId, string themeId, UpdateThemeRequest theme)

Replace a theme

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

            var apiInstance = new ThemesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var themeId = "themeId_example";  // string | The ID of the theme
            var theme = new UpdateThemeRequest(); // UpdateThemeRequest | 

            try
            {
                // Replace a theme
                ThemeResponse result = apiInstance.ReplaceBrandTheme(brandId, themeId, theme);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ThemesApi.ReplaceBrandTheme: " + e.Message );
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
 **theme** | [**UpdateThemeRequest**](UpdateThemeRequest.md)|  | 

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
| **200** | Successfully replaced the theme |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="uploadbrandthemebackgroundimage"></a>
# **UploadBrandThemeBackgroundImage**
> ImageUploadResponse UploadBrandThemeBackgroundImage (string brandId, string themeId, System.IO.Stream file)

Upload the background image

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

            var apiInstance = new ThemesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var themeId = "themeId_example";  // string | The ID of the theme
            var file = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream | 

            try
            {
                // Upload the background image
                ImageUploadResponse result = apiInstance.UploadBrandThemeBackgroundImage(brandId, themeId, file);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ThemesApi.UploadBrandThemeBackgroundImage: " + e.Message );
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
| **201** | Content Created |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="uploadbrandthemefavicon"></a>
# **UploadBrandThemeFavicon**
> ImageUploadResponse UploadBrandThemeFavicon (string brandId, string themeId, System.IO.Stream file)

Upload the favicon

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

            var apiInstance = new ThemesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var themeId = "themeId_example";  // string | The ID of the theme
            var file = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream | 

            try
            {
                // Upload the favicon
                ImageUploadResponse result = apiInstance.UploadBrandThemeFavicon(brandId, themeId, file);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ThemesApi.UploadBrandThemeFavicon: " + e.Message );
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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="uploadbrandthemelogo"></a>
# **UploadBrandThemeLogo**
> ImageUploadResponse UploadBrandThemeLogo (string brandId, string themeId, System.IO.Stream file)

Upload the logo

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

            var apiInstance = new ThemesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var themeId = "themeId_example";  // string | The ID of the theme
            var file = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream | 

            try
            {
                // Upload the logo
                ImageUploadResponse result = apiInstance.UploadBrandThemeLogo(brandId, themeId, file);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ThemesApi.UploadBrandThemeLogo: " + e.Message );
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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

