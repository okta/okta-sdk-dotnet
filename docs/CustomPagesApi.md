# Okta.Sdk.Api.CustomPagesApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeleteCustomizedErrorPage**](CustomPagesApi.md#deletecustomizederrorpage) | **DELETE** /api/v1/brands/{brandId}/pages/error/customized | Delete the customized error page
[**DeleteCustomizedSignInPage**](CustomPagesApi.md#deletecustomizedsigninpage) | **DELETE** /api/v1/brands/{brandId}/pages/sign-in/customized | Delete the customized sign-in page
[**DeletePreviewErrorPage**](CustomPagesApi.md#deletepreviewerrorpage) | **DELETE** /api/v1/brands/{brandId}/pages/error/preview | Delete the preview error page
[**DeletePreviewSignInPage**](CustomPagesApi.md#deletepreviewsigninpage) | **DELETE** /api/v1/brands/{brandId}/pages/sign-in/preview | Delete the preview sign-in page
[**GetCustomizedErrorPage**](CustomPagesApi.md#getcustomizederrorpage) | **GET** /api/v1/brands/{brandId}/pages/error/customized | Retrieve the customized error page
[**GetCustomizedSignInPage**](CustomPagesApi.md#getcustomizedsigninpage) | **GET** /api/v1/brands/{brandId}/pages/sign-in/customized | Retrieve the customized sign-in page
[**GetDefaultErrorPage**](CustomPagesApi.md#getdefaulterrorpage) | **GET** /api/v1/brands/{brandId}/pages/error/default | Retrieve the default error page
[**GetDefaultSignInPage**](CustomPagesApi.md#getdefaultsigninpage) | **GET** /api/v1/brands/{brandId}/pages/sign-in/default | Retrieve the default sign-in page
[**GetErrorPage**](CustomPagesApi.md#geterrorpage) | **GET** /api/v1/brands/{brandId}/pages/error | Retrieve the error page sub-resources
[**GetPreviewErrorPage**](CustomPagesApi.md#getpreviewerrorpage) | **GET** /api/v1/brands/{brandId}/pages/error/preview | Retrieve the preview error page preview
[**GetPreviewSignInPage**](CustomPagesApi.md#getpreviewsigninpage) | **GET** /api/v1/brands/{brandId}/pages/sign-in/preview | Retrieve the preview sign-in page preview
[**GetSignInPage**](CustomPagesApi.md#getsigninpage) | **GET** /api/v1/brands/{brandId}/pages/sign-in | Retrieve the sign-in page sub-resources
[**GetSignOutPageSettings**](CustomPagesApi.md#getsignoutpagesettings) | **GET** /api/v1/brands/{brandId}/pages/sign-out/customized | Retrieve the sign-out page settings
[**ListAllSignInWidgetVersions**](CustomPagesApi.md#listallsigninwidgetversions) | **GET** /api/v1/brands/{brandId}/pages/sign-in/widget-versions | List all Sign-In Widget versions
[**ReplaceCustomizedErrorPage**](CustomPagesApi.md#replacecustomizederrorpage) | **PUT** /api/v1/brands/{brandId}/pages/error/customized | Replace the customized error page
[**ReplaceCustomizedSignInPage**](CustomPagesApi.md#replacecustomizedsigninpage) | **PUT** /api/v1/brands/{brandId}/pages/sign-in/customized | Replace the customized sign-in page
[**ReplacePreviewErrorPage**](CustomPagesApi.md#replacepreviewerrorpage) | **PUT** /api/v1/brands/{brandId}/pages/error/preview | Replace the preview error page
[**ReplacePreviewSignInPage**](CustomPagesApi.md#replacepreviewsigninpage) | **PUT** /api/v1/brands/{brandId}/pages/sign-in/preview | Replace the preview sign-in page
[**ReplaceSignOutPageSettings**](CustomPagesApi.md#replacesignoutpagesettings) | **PUT** /api/v1/brands/{brandId}/pages/sign-out/customized | Replace the sign-out page settings


<a name="deletecustomizederrorpage"></a>
# **DeleteCustomizedErrorPage**
> void DeleteCustomizedErrorPage (string brandId)

Delete the customized error page

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

            var apiInstance = new CustomPagesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

            try
            {
                // Delete the customized error page
                apiInstance.DeleteCustomizedErrorPage(brandId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomPagesApi.DeleteCustomizedErrorPage: " + e.Message );
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletecustomizedsigninpage"></a>
# **DeleteCustomizedSignInPage**
> void DeleteCustomizedSignInPage (string brandId)

Delete the customized sign-in page

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

            var apiInstance = new CustomPagesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

            try
            {
                // Delete the customized sign-in page
                apiInstance.DeleteCustomizedSignInPage(brandId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomPagesApi.DeleteCustomizedSignInPage: " + e.Message );
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletepreviewerrorpage"></a>
# **DeletePreviewErrorPage**
> void DeletePreviewErrorPage (string brandId)

Delete the preview error page

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

            var apiInstance = new CustomPagesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

            try
            {
                // Delete the preview error page
                apiInstance.DeletePreviewErrorPage(brandId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomPagesApi.DeletePreviewErrorPage: " + e.Message );
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletepreviewsigninpage"></a>
# **DeletePreviewSignInPage**
> void DeletePreviewSignInPage (string brandId)

Delete the preview sign-in page

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

            var apiInstance = new CustomPagesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

            try
            {
                // Delete the preview sign-in page
                apiInstance.DeletePreviewSignInPage(brandId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomPagesApi.DeletePreviewSignInPage: " + e.Message );
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getcustomizederrorpage"></a>
# **GetCustomizedErrorPage**
> ErrorPage GetCustomizedErrorPage (string brandId)

Retrieve the customized error page

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

            var apiInstance = new CustomPagesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

            try
            {
                // Retrieve the customized error page
                ErrorPage result = apiInstance.GetCustomizedErrorPage(brandId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomPagesApi.GetCustomizedErrorPage: " + e.Message );
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getcustomizedsigninpage"></a>
# **GetCustomizedSignInPage**
> SignInPage GetCustomizedSignInPage (string brandId)

Retrieve the customized sign-in page

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

            var apiInstance = new CustomPagesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

            try
            {
                // Retrieve the customized sign-in page
                SignInPage result = apiInstance.GetCustomizedSignInPage(brandId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomPagesApi.GetCustomizedSignInPage: " + e.Message );
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getdefaulterrorpage"></a>
# **GetDefaultErrorPage**
> ErrorPage GetDefaultErrorPage (string brandId)

Retrieve the default error page

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

            var apiInstance = new CustomPagesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

            try
            {
                // Retrieve the default error page
                ErrorPage result = apiInstance.GetDefaultErrorPage(brandId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomPagesApi.GetDefaultErrorPage: " + e.Message );
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getdefaultsigninpage"></a>
# **GetDefaultSignInPage**
> SignInPage GetDefaultSignInPage (string brandId)

Retrieve the default sign-in page

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

            var apiInstance = new CustomPagesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

            try
            {
                // Retrieve the default sign-in page
                SignInPage result = apiInstance.GetDefaultSignInPage(brandId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomPagesApi.GetDefaultSignInPage: " + e.Message );
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="geterrorpage"></a>
# **GetErrorPage**
> PageRoot GetErrorPage (string brandId, List<string> expand = null)

Retrieve the error page sub-resources

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

            var apiInstance = new CustomPagesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var expand = new List<string>(); // List<string> | Specifies additional metadata to be included in the response (optional) 

            try
            {
                // Retrieve the error page sub-resources
                PageRoot result = apiInstance.GetErrorPage(brandId, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomPagesApi.GetErrorPage: " + e.Message );
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getpreviewerrorpage"></a>
# **GetPreviewErrorPage**
> ErrorPage GetPreviewErrorPage (string brandId)

Retrieve the preview error page preview

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

            var apiInstance = new CustomPagesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

            try
            {
                // Retrieve the preview error page preview
                ErrorPage result = apiInstance.GetPreviewErrorPage(brandId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomPagesApi.GetPreviewErrorPage: " + e.Message );
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getpreviewsigninpage"></a>
# **GetPreviewSignInPage**
> SignInPage GetPreviewSignInPage (string brandId)

Retrieve the preview sign-in page preview

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

            var apiInstance = new CustomPagesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

            try
            {
                // Retrieve the preview sign-in page preview
                SignInPage result = apiInstance.GetPreviewSignInPage(brandId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomPagesApi.GetPreviewSignInPage: " + e.Message );
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getsigninpage"></a>
# **GetSignInPage**
> PageRoot GetSignInPage (string brandId, List<string> expand = null)

Retrieve the sign-in page sub-resources

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

            var apiInstance = new CustomPagesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var expand = new List<string>(); // List<string> | Specifies additional metadata to be included in the response (optional) 

            try
            {
                // Retrieve the sign-in page sub-resources
                PageRoot result = apiInstance.GetSignInPage(brandId, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomPagesApi.GetSignInPage: " + e.Message );
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getsignoutpagesettings"></a>
# **GetSignOutPageSettings**
> HostedPage GetSignOutPageSettings (string brandId)

Retrieve the sign-out page settings

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

            var apiInstance = new CustomPagesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

            try
            {
                // Retrieve the sign-out page settings
                HostedPage result = apiInstance.GetSignOutPageSettings(brandId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomPagesApi.GetSignOutPageSettings: " + e.Message );
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listallsigninwidgetversions"></a>
# **ListAllSignInWidgetVersions**
> List&lt;string&gt; ListAllSignInWidgetVersions (string brandId)

List all Sign-In Widget versions

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

            var apiInstance = new CustomPagesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

            try
            {
                // List all Sign-In Widget versions
                List<string> result = apiInstance.ListAllSignInWidgetVersions(brandId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomPagesApi.ListAllSignInWidgetVersions: " + e.Message );
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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacecustomizederrorpage"></a>
# **ReplaceCustomizedErrorPage**
> ErrorPage ReplaceCustomizedErrorPage (string brandId, ErrorPage errorPage)

Replace the customized error page

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

            var apiInstance = new CustomPagesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var errorPage = new ErrorPage(); // ErrorPage | 

            try
            {
                // Replace the customized error page
                ErrorPage result = apiInstance.ReplaceCustomizedErrorPage(brandId, errorPage);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomPagesApi.ReplaceCustomizedErrorPage: " + e.Message );
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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacecustomizedsigninpage"></a>
# **ReplaceCustomizedSignInPage**
> SignInPage ReplaceCustomizedSignInPage (string brandId, SignInPage signInPage)

Replace the customized sign-in page

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

            var apiInstance = new CustomPagesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var signInPage = new SignInPage(); // SignInPage | 

            try
            {
                // Replace the customized sign-in page
                SignInPage result = apiInstance.ReplaceCustomizedSignInPage(brandId, signInPage);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomPagesApi.ReplaceCustomizedSignInPage: " + e.Message );
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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacepreviewerrorpage"></a>
# **ReplacePreviewErrorPage**
> ErrorPage ReplacePreviewErrorPage (string brandId, ErrorPage errorPage)

Replace the preview error page

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

            var apiInstance = new CustomPagesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var errorPage = new ErrorPage(); // ErrorPage | 

            try
            {
                // Replace the preview error page
                ErrorPage result = apiInstance.ReplacePreviewErrorPage(brandId, errorPage);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomPagesApi.ReplacePreviewErrorPage: " + e.Message );
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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacepreviewsigninpage"></a>
# **ReplacePreviewSignInPage**
> SignInPage ReplacePreviewSignInPage (string brandId, SignInPage signInPage)

Replace the preview sign-in page

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

            var apiInstance = new CustomPagesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var signInPage = new SignInPage(); // SignInPage | 

            try
            {
                // Replace the preview sign-in page
                SignInPage result = apiInstance.ReplacePreviewSignInPage(brandId, signInPage);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomPagesApi.ReplacePreviewSignInPage: " + e.Message );
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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacesignoutpagesettings"></a>
# **ReplaceSignOutPageSettings**
> HostedPage ReplaceSignOutPageSettings (string brandId, HostedPage hostedPage)

Replace the sign-out page settings

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

            var apiInstance = new CustomPagesApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var hostedPage = new HostedPage(); // HostedPage | 

            try
            {
                // Replace the sign-out page settings
                HostedPage result = apiInstance.ReplaceSignOutPageSettings(brandId, hostedPage);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomPagesApi.ReplaceSignOutPageSettings: " + e.Message );
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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

