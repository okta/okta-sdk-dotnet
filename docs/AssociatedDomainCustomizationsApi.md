# Okta.Sdk.Api.AssociatedDomainCustomizationsApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetAllWellKnownURIs**](AssociatedDomainCustomizationsApi.md#getallwellknownuris) | **GET** /api/v1/brands/{brandId}/well-known-uris | Retrieve all the well-known URIs
[**GetAppleAppSiteAssociationWellKnownURI**](AssociatedDomainCustomizationsApi.md#getappleappsiteassociationwellknownuri) | **GET** /.well-known/apple-app-site-association | Retrieve the customized apple-app-site-association URI content
[**GetAssetLinksWellKnownURI**](AssociatedDomainCustomizationsApi.md#getassetlinkswellknownuri) | **GET** /.well-known/assetlinks.json | Retrieve the customized assetlinks.json URI content
[**GetBrandWellKnownURI**](AssociatedDomainCustomizationsApi.md#getbrandwellknownuri) | **GET** /api/v1/brands/{brandId}/well-known-uris/{path}/customized | Retrieve the customized content of the specified well-known URI
[**GetRootBrandWellKnownURI**](AssociatedDomainCustomizationsApi.md#getrootbrandwellknownuri) | **GET** /api/v1/brands/{brandId}/well-known-uris/{path} | Retrieve the well-known URI of a specific brand
[**GetWebAuthnWellKnownURI**](AssociatedDomainCustomizationsApi.md#getwebauthnwellknownuri) | **GET** /.well-known/webauthn | Retrieve the customized webauthn URI content
[**ReplaceBrandWellKnownURI**](AssociatedDomainCustomizationsApi.md#replacebrandwellknownuri) | **PUT** /api/v1/brands/{brandId}/well-known-uris/{path}/customized | Replace the customized well-known URI of the specific path


<a name="getallwellknownuris"></a>
# **GetAllWellKnownURIs**
> WellKnownURIsRoot GetAllWellKnownURIs (string brandId, List<string> expand = null)

Retrieve all the well-known URIs

Retrieves the content from each of the well-known URIs for a specified brand

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetAllWellKnownURIsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AssociatedDomainCustomizationsApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var expand = new List<string>(); // List<string> | Specifies additional metadata to include in the response (optional) 

            try
            {
                // Retrieve all the well-known URIs
                WellKnownURIsRoot result = apiInstance.GetAllWellKnownURIs(brandId, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AssociatedDomainCustomizationsApi.GetAllWellKnownURIs: " + e.Message );
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
 **expand** | [**List&lt;string&gt;**](string.md)| Specifies additional metadata to include in the response | [optional] 

### Return type

[**WellKnownURIsRoot**](WellKnownURIsRoot.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully retrieved all the well-known URIs |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getappleappsiteassociationwellknownuri"></a>
# **GetAppleAppSiteAssociationWellKnownURI**
> Object GetAppleAppSiteAssociationWellKnownURI ()

Retrieve the customized apple-app-site-association URI content

Retrieves the content of the `apple-app-site-assocation` well-known URI  > **Note:**  When serving this URI, Okta adds `authsrv` content to provide a seamless experience for Okta Verify. You can't modify the content in the `authsrv` object.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetAppleAppSiteAssociationWellKnownURIExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            var apiInstance = new AssociatedDomainCustomizationsApi(config);

            try
            {
                // Retrieve the customized apple-app-site-association URI content
                Object result = apiInstance.GetAppleAppSiteAssociationWellKnownURI();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AssociatedDomainCustomizationsApi.GetAppleAppSiteAssociationWellKnownURI: " + e.Message );
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

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getassetlinkswellknownuri"></a>
# **GetAssetLinksWellKnownURI**
> Object GetAssetLinksWellKnownURI ()

Retrieve the customized assetlinks.json URI content

Retrieves the content of the `assetlinks.json` well-known URI

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetAssetLinksWellKnownURIExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            var apiInstance = new AssociatedDomainCustomizationsApi(config);

            try
            {
                // Retrieve the customized assetlinks.json URI content
                Object result = apiInstance.GetAssetLinksWellKnownURI();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AssociatedDomainCustomizationsApi.GetAssetLinksWellKnownURI: " + e.Message );
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

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getbrandwellknownuri"></a>
# **GetBrandWellKnownURI**
> WellKnownURIObjectResponse GetBrandWellKnownURI (string brandId, WellKnownUriPath path)

Retrieve the customized content of the specified well-known URI

Retrieves the customized content of a well-known URI for a specific brand and well-known URI path

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetBrandWellKnownURIExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AssociatedDomainCustomizationsApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var path = (WellKnownUriPath) "apple-app-site-association";  // WellKnownUriPath | The path of the well-known URI

            try
            {
                // Retrieve the customized content of the specified well-known URI
                WellKnownURIObjectResponse result = apiInstance.GetBrandWellKnownURI(brandId, path);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AssociatedDomainCustomizationsApi.GetBrandWellKnownURI: " + e.Message );
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
 **path** | **WellKnownUriPath**| The path of the well-known URI | 

### Return type

[**WellKnownURIObjectResponse**](WellKnownURIObjectResponse.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully retrieved the customized well-known URI content |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getrootbrandwellknownuri"></a>
# **GetRootBrandWellKnownURI**
> WellKnownURIObjectResponse GetRootBrandWellKnownURI (string brandId, WellKnownUriPath path, List<string> expand = null)

Retrieve the well-known URI of a specific brand

Retrieves the well-known URI of a specific brand and well-known URI path

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetRootBrandWellKnownURIExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AssociatedDomainCustomizationsApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var path = (WellKnownUriPath) "apple-app-site-association";  // WellKnownUriPath | The path of the well-known URI
            var expand = new List<string>(); // List<string> | Specifies additional metadata to include in the response (optional) 

            try
            {
                // Retrieve the well-known URI of a specific brand
                WellKnownURIObjectResponse result = apiInstance.GetRootBrandWellKnownURI(brandId, path, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AssociatedDomainCustomizationsApi.GetRootBrandWellKnownURI: " + e.Message );
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
 **path** | **WellKnownUriPath**| The path of the well-known URI | 
 **expand** | [**List&lt;string&gt;**](string.md)| Specifies additional metadata to include in the response | [optional] 

### Return type

[**WellKnownURIObjectResponse**](WellKnownURIObjectResponse.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully retrieved the well-known URI |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getwebauthnwellknownuri"></a>
# **GetWebAuthnWellKnownURI**
> Object GetWebAuthnWellKnownURI ()

Retrieve the customized webauthn URI content

Retrieves the content of the `webauthn` well-known URI

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetWebAuthnWellKnownURIExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            var apiInstance = new AssociatedDomainCustomizationsApi(config);

            try
            {
                // Retrieve the customized webauthn URI content
                Object result = apiInstance.GetWebAuthnWellKnownURI();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AssociatedDomainCustomizationsApi.GetWebAuthnWellKnownURI: " + e.Message );
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

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacebrandwellknownuri"></a>
# **ReplaceBrandWellKnownURI**
> WellKnownURIObjectResponse ReplaceBrandWellKnownURI (string brandId, WellKnownUriPath path, WellKnownURIRequest wellKnownURIRequest = null)

Replace the customized well-known URI of the specific path

Replaces the content of a customized well-known URI that you specify.  There are endpoint-specific format requirements when you update the content of a customized well-known URI. See [Customize associated domains](https://developer.okta.com/docs/guides/custom-well-known-uri/main/).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceBrandWellKnownURIExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AssociatedDomainCustomizationsApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var path = (WellKnownUriPath) "apple-app-site-association";  // WellKnownUriPath | The path of the well-known URI
            var wellKnownURIRequest = new WellKnownURIRequest(); // WellKnownURIRequest |  (optional) 

            try
            {
                // Replace the customized well-known URI of the specific path
                WellKnownURIObjectResponse result = apiInstance.ReplaceBrandWellKnownURI(brandId, path, wellKnownURIRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AssociatedDomainCustomizationsApi.ReplaceBrandWellKnownURI: " + e.Message );
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
 **path** | **WellKnownUriPath**| The path of the well-known URI | 
 **wellKnownURIRequest** | [**WellKnownURIRequest**](WellKnownURIRequest.md)|  | [optional] 

### Return type

[**WellKnownURIObjectResponse**](WellKnownURIObjectResponse.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successfully updated the well-known URI of the specified path |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

