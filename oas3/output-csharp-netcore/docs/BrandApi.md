# Org.OpenAPITools.Api.BrandApi

All URIs are relative to *https://your-subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeleteBrandThemeBackgroundImage**](BrandApi.md#deletebrandthemebackgroundimage) | **DELETE** /api/v1/brands/{brandId}/themes/{themeId}/background-image | Deletes a Theme background image
[**DeleteBrandThemeFavicon**](BrandApi.md#deletebrandthemefavicon) | **DELETE** /api/v1/brands/{brandId}/themes/{themeId}/favicon | Deletes a Theme favicon. The org then uses the Okta default favicon.
[**DeleteBrandThemeLogo**](BrandApi.md#deletebrandthemelogo) | **DELETE** /api/v1/brands/{brandId}/themes/{themeId}/logo | Deletes a Theme logo. The org then uses the Okta default logo.
[**GetBrand**](BrandApi.md#getbrand) | **GET** /api/v1/brands/{brandId} | Get Brand
[**GetBrandTheme**](BrandApi.md#getbrandtheme) | **GET** /api/v1/brands/{brandId}/themes/{themeId} | Get a theme for a brand
[**ListBrandThemes**](BrandApi.md#listbrandthemes) | **GET** /api/v1/brands/{brandId}/themes | Get Brand Themes
[**ListBrands**](BrandApi.md#listbrands) | **GET** /api/v1/brands | List Brands
[**UpdateBrand**](BrandApi.md#updatebrand) | **PUT** /api/v1/brands/{brandId} | Update Brand
[**UpdateBrandTheme**](BrandApi.md#updatebrandtheme) | **PUT** /api/v1/brands/{brandId}/themes/{themeId} | Update a theme for a brand
[**UploadBrandThemeBackgroundImage**](BrandApi.md#uploadbrandthemebackgroundimage) | **POST** /api/v1/brands/{brandId}/themes/{themeId}/background-image | Updates the background image for your Theme
[**UploadBrandThemeFavicon**](BrandApi.md#uploadbrandthemefavicon) | **POST** /api/v1/brands/{brandId}/themes/{themeId}/favicon | Updates the favicon for your theme
[**UploadBrandThemeLogo**](BrandApi.md#uploadbrandthemelogo) | **POST** /api/v1/brands/{brandId}/themes/{themeId}/logo | Update a themes logo


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

            var apiInstance = new BrandApi(config);
            var brandId = "brandId_example";  // string | 
            var themeId = "themeId_example";  // string | 

            try
            {
                // Deletes a Theme background image
                apiInstance.DeleteBrandThemeBackgroundImage(brandId, themeId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BrandApi.DeleteBrandThemeBackgroundImage: " + e.Message );
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

            var apiInstance = new BrandApi(config);
            var brandId = "brandId_example";  // string | 
            var themeId = "themeId_example";  // string | 

            try
            {
                // Deletes a Theme favicon. The org then uses the Okta default favicon.
                apiInstance.DeleteBrandThemeFavicon(brandId, themeId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BrandApi.DeleteBrandThemeFavicon: " + e.Message );
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

            var apiInstance = new BrandApi(config);
            var brandId = "brandId_example";  // string | 
            var themeId = "themeId_example";  // string | 

            try
            {
                // Deletes a Theme logo. The org then uses the Okta default logo.
                apiInstance.DeleteBrandThemeLogo(brandId, themeId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BrandApi.DeleteBrandThemeLogo: " + e.Message );
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

            var apiInstance = new BrandApi(config);
            var brandId = "brandId_example";  // string | 

            try
            {
                // Get Brand
                Brand result = apiInstance.GetBrand(brandId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BrandApi.GetBrand: " + e.Message );
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

            var apiInstance = new BrandApi(config);
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
                Debug.Print("Exception when calling BrandApi.GetBrandTheme: " + e.Message );
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

            var apiInstance = new BrandApi(config);
            var brandId = "brandId_example";  // string | 

            try
            {
                // Get Brand Themes
                List<ThemeResponse> result = apiInstance.ListBrandThemes(brandId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BrandApi.ListBrandThemes: " + e.Message );
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

            var apiInstance = new BrandApi(config);

            try
            {
                // List Brands
                List<Brand> result = apiInstance.ListBrands();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BrandApi.ListBrands: " + e.Message );
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

            var apiInstance = new BrandApi(config);
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
                Debug.Print("Exception when calling BrandApi.UpdateBrand: " + e.Message );
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

            var apiInstance = new BrandApi(config);
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
                Debug.Print("Exception when calling BrandApi.UpdateBrandTheme: " + e.Message );
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

            var apiInstance = new BrandApi(config);
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
                Debug.Print("Exception when calling BrandApi.UploadBrandThemeBackgroundImage: " + e.Message );
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

            var apiInstance = new BrandApi(config);
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
                Debug.Print("Exception when calling BrandApi.UploadBrandThemeFavicon: " + e.Message );
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

            var apiInstance = new BrandApi(config);
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
                Debug.Print("Exception when calling BrandApi.UploadBrandThemeLogo: " + e.Message );
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

