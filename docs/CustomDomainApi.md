# Okta.Sdk.Api.CustomDomainApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateCustomDomain**](CustomDomainApi.md#createcustomdomain) | **POST** /api/v1/domains | Create a Custom Domain
[**DeleteCustomDomain**](CustomDomainApi.md#deletecustomdomain) | **DELETE** /api/v1/domains/{domainId} | Delete a Custom Domain
[**GetCustomDomain**](CustomDomainApi.md#getcustomdomain) | **GET** /api/v1/domains/{domainId} | Retrieve a Custom Domain
[**ListCustomDomains**](CustomDomainApi.md#listcustomdomains) | **GET** /api/v1/domains | List all Custom Domains
[**ReplaceCustomDomain**](CustomDomainApi.md#replacecustomdomain) | **PUT** /api/v1/domains/{domainId} | Replace a Custom Domain&#39;s Brand
[**UpsertCertificate**](CustomDomainApi.md#upsertcertificate) | **PUT** /api/v1/domains/{domainId}/certificate | Upsert the Custom Domain&#39;s Certificate
[**VerifyDomain**](CustomDomainApi.md#verifydomain) | **POST** /api/v1/domains/{domainId}/verify | Verify a Custom Domain


<a name="createcustomdomain"></a>
# **CreateCustomDomain**
> DomainResponse CreateCustomDomain (DomainRequest domain)

Create a Custom Domain

Creates your custom domain

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateCustomDomainExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomDomainApi(config);
            var domain = new DomainRequest(); // DomainRequest | 

            try
            {
                // Create a Custom Domain
                DomainResponse result = apiInstance.CreateCustomDomain(domain);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomDomainApi.CreateCustomDomain: " + e.Message );
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
 **domain** | [**DomainRequest**](DomainRequest.md)|  | 

### Return type

[**DomainResponse**](DomainResponse.md)

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

<a name="deletecustomdomain"></a>
# **DeleteCustomDomain**
> void DeleteCustomDomain (string domainId)

Delete a Custom Domain

Deletes a custom domain by `domainId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteCustomDomainExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomDomainApi(config);
            var domainId = OmWNeywfTzElSLOBMZsL;  // string | `id` of the Domain

            try
            {
                // Delete a Custom Domain
                apiInstance.DeleteCustomDomain(domainId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomDomainApi.DeleteCustomDomain: " + e.Message );
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
 **domainId** | **string**| &#x60;id&#x60; of the Domain | 

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

<a name="getcustomdomain"></a>
# **GetCustomDomain**
> DomainResponse GetCustomDomain (string domainId)

Retrieve a Custom Domain

Retrieves a custom domain by `domainId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetCustomDomainExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomDomainApi(config);
            var domainId = OmWNeywfTzElSLOBMZsL;  // string | `id` of the Domain

            try
            {
                // Retrieve a Custom Domain
                DomainResponse result = apiInstance.GetCustomDomain(domainId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomDomainApi.GetCustomDomain: " + e.Message );
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
 **domainId** | **string**| &#x60;id&#x60; of the Domain | 

### Return type

[**DomainResponse**](DomainResponse.md)

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

<a name="listcustomdomains"></a>
# **ListCustomDomains**
> DomainListResponse ListCustomDomains ()

List all Custom Domains

Lists all verified custom domains for the org

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListCustomDomainsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomDomainApi(config);

            try
            {
                // List all Custom Domains
                DomainListResponse result = apiInstance.ListCustomDomains();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomDomainApi.ListCustomDomains: " + e.Message );
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

[**DomainListResponse**](DomainListResponse.md)

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

<a name="replacecustomdomain"></a>
# **ReplaceCustomDomain**
> DomainResponse ReplaceCustomDomain (string domainId, UpdateDomain updateDomain)

Replace a Custom Domain's Brand

Replaces a custom domain's brand

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceCustomDomainExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomDomainApi(config);
            var domainId = OmWNeywfTzElSLOBMZsL;  // string | `id` of the Domain
            var updateDomain = new UpdateDomain(); // UpdateDomain | 

            try
            {
                // Replace a Custom Domain's Brand
                DomainResponse result = apiInstance.ReplaceCustomDomain(domainId, updateDomain);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomDomainApi.ReplaceCustomDomain: " + e.Message );
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
 **domainId** | **string**| &#x60;id&#x60; of the Domain | 
 **updateDomain** | [**UpdateDomain**](UpdateDomain.md)|  | 

### Return type

[**DomainResponse**](DomainResponse.md)

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

<a name="upsertcertificate"></a>
# **UpsertCertificate**
> void UpsertCertificate (string domainId, DomainCertificate certificate)

Upsert the Custom Domain's Certificate

Upserts (creates or renews) the `MANUAL` certificate for the custom domain. If the `certificateSourceType` in the domain is `OKTA_MANAGED`, it becomes `MANUAL` and Okta no longer manages and renews certificates for this domain since a user-managed certificate has been provided.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpsertCertificateExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomDomainApi(config);
            var domainId = OmWNeywfTzElSLOBMZsL;  // string | `id` of the Domain
            var certificate = new DomainCertificate(); // DomainCertificate | 

            try
            {
                // Upsert the Custom Domain's Certificate
                apiInstance.UpsertCertificate(domainId, certificate);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomDomainApi.UpsertCertificate: " + e.Message );
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
 **domainId** | **string**| &#x60;id&#x60; of the Domain | 
 **certificate** | [**DomainCertificate**](DomainCertificate.md)|  | 

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
| **204** | No Content |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="verifydomain"></a>
# **VerifyDomain**
> DomainResponse VerifyDomain (string domainId)

Verify a Custom Domain

Verifies the custom domain and validity of DNS records by `domainId`. Furthermore, if the `certificateSourceType` in the domain is `OKTA_MANAGED`, then an attempt is made to obtain and install a certificate. After a certificate is obtained and installed by Okta, Okta manages the certificate including certificate renewal.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class VerifyDomainExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CustomDomainApi(config);
            var domainId = OmWNeywfTzElSLOBMZsL;  // string | `id` of the Domain

            try
            {
                // Verify a Custom Domain
                DomainResponse result = apiInstance.VerifyDomain(domainId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomDomainApi.VerifyDomain: " + e.Message );
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
 **domainId** | **string**| &#x60;id&#x60; of the Domain | 

### Return type

[**DomainResponse**](DomainResponse.md)

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

