# Okta.Sdk.Api.BrandsApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateBrand**](BrandsApi.md#createbrand) | **POST** /api/v1/brands | Create a brand
[**DeleteBrand**](BrandsApi.md#deletebrand) | **DELETE** /api/v1/brands/{brandId} | Delete a brand
[**GetBrand**](BrandsApi.md#getbrand) | **GET** /api/v1/brands/{brandId} | Retrieve a brand
[**ListBrandDomains**](BrandsApi.md#listbranddomains) | **GET** /api/v1/brands/{brandId}/domains | List all domains associated with a brand
[**ListBrands**](BrandsApi.md#listbrands) | **GET** /api/v1/brands | List all brands
[**ReplaceBrand**](BrandsApi.md#replacebrand) | **PUT** /api/v1/brands/{brandId} | Replace a brand


<a name="createbrand"></a>
# **CreateBrand**
> Brand CreateBrand (CreateBrandRequest createBrandRequest = null)

Create a brand

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

            var apiInstance = new BrandsApi(config);
            var createBrandRequest = new CreateBrandRequest(); // CreateBrandRequest |  (optional) 

            try
            {
                // Create a brand
                Brand result = apiInstance.CreateBrand(createBrandRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BrandsApi.CreateBrand: " + e.Message );
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
| **201** | Successfully created the brand |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **409** | Could not create the new brand because same name already exist. |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletebrand"></a>
# **DeleteBrand**
> void DeleteBrand (string brandId)

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

            var apiInstance = new BrandsApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

            try
            {
                // Delete a brand
                apiInstance.DeleteBrand(brandId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BrandsApi.DeleteBrand: " + e.Message );
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
| **204** | Successfully deleted the brand. |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **409** | Conflict |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getbrand"></a>
# **GetBrand**
> BrandWithEmbedded GetBrand (string brandId, List<string> expand = null)

Retrieve a brand

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

            var apiInstance = new BrandsApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var expand = new List<string>(); // List<string> | Specifies additional metadata to be included in the response (optional) 

            try
            {
                // Retrieve a brand
                BrandWithEmbedded result = apiInstance.GetBrand(brandId, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BrandsApi.GetBrand: " + e.Message );
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
| **200** | Successfully retrieved the brand |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listbranddomains"></a>
# **ListBrandDomains**
> List&lt;DomainResponse&gt; ListBrandDomains (string brandId)

List all domains associated with a brand

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

            var apiInstance = new BrandsApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand

            try
            {
                // List all domains associated with a brand
                List<DomainResponse> result = apiInstance.ListBrandDomains(brandId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BrandsApi.ListBrandDomains: " + e.Message );
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
| **200** | Successfully returned the list of domains for the brand |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listbrands"></a>
# **ListBrands**
> List&lt;BrandWithEmbedded&gt; ListBrands (List<string> expand = null, string after = null, int? limit = null, string q = null)

List all brands

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

            var apiInstance = new BrandsApi(config);
            var expand = new List<string>(); // List<string> | Specifies additional metadata to be included in the response (optional) 
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 
            var limit = 20;  // int? | A limit on the number of objects to return (optional)  (default to 20)
            var q = "q_example";  // string | Searches the records for matching value (optional) 

            try
            {
                // List all brands
                List<BrandWithEmbedded> result = apiInstance.ListBrands(expand, after, limit, q).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BrandsApi.ListBrands: " + e.Message );
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
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 
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
| **200** | Successfully returned the list of brands |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacebrand"></a>
# **ReplaceBrand**
> Brand ReplaceBrand (string brandId, BrandRequest brand)

Replace a brand

Replaces a brand by `brandId`  Passing an invalid `brandId` returns a `404 Not Found` status code with the error code `E0000007`.  Not providing `agreeToCustomPrivacyPolicy` with `customPrivacyPolicyUrl` returns a `400 Bad Request` status code with the error code `E0000001`.  

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

            var apiInstance = new BrandsApi(config);
            var brandId = "brandId_example";  // string | The ID of the brand
            var brand = new BrandRequest(); // BrandRequest | 

            try
            {
                // Replace a brand
                Brand result = apiInstance.ReplaceBrand(brandId, brand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BrandsApi.ReplaceBrand: " + e.Message );
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
| **200** | Successfully replaced the brand |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

