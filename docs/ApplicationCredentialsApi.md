# Okta.Sdk.Api.ApplicationCredentialsApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CloneApplicationKey**](ApplicationCredentialsApi.md#cloneapplicationkey) | **POST** /api/v1/apps/{appId}/credentials/keys/{keyId}/clone | Clone a Key Credential
[**GenerateApplicationKey**](ApplicationCredentialsApi.md#generateapplicationkey) | **POST** /api/v1/apps/{appId}/credentials/keys/generate | Generate a Key Credential
[**GenerateCsrForApplication**](ApplicationCredentialsApi.md#generatecsrforapplication) | **POST** /api/v1/apps/{appId}/credentials/csrs | Generate a Certificate Signing Request
[**GetApplicationKey**](ApplicationCredentialsApi.md#getapplicationkey) | **GET** /api/v1/apps/{appId}/credentials/keys/{keyId} | Retrieve a Key Credential
[**GetCsrForApplication**](ApplicationCredentialsApi.md#getcsrforapplication) | **GET** /api/v1/apps/{appId}/credentials/csrs/{csrId} | Retrieve a Certificate Signing Request
[**ListApplicationKeys**](ApplicationCredentialsApi.md#listapplicationkeys) | **GET** /api/v1/apps/{appId}/credentials/keys | List all Key Credentials
[**ListCsrsForApplication**](ApplicationCredentialsApi.md#listcsrsforapplication) | **GET** /api/v1/apps/{appId}/credentials/csrs | List all Certificate Signing Requests
[**PublishCsrFromApplication**](ApplicationCredentialsApi.md#publishcsrfromapplication) | **POST** /api/v1/apps/{appId}/credentials/csrs/{csrId}/lifecycle/publish | Publish a Certificate Signing Request
[**RevokeCsrFromApplication**](ApplicationCredentialsApi.md#revokecsrfromapplication) | **DELETE** /api/v1/apps/{appId}/credentials/csrs/{csrId} | Revoke a Certificate Signing Request


<a name="cloneapplicationkey"></a>
# **CloneApplicationKey**
> JsonWebKey CloneApplicationKey (string appId, string keyId, string targetAid)

Clone a Key Credential

Clones a X.509 certificate for an application key credential from a source application to target application.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CloneApplicationKeyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationCredentialsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application
            var keyId = sjP9eiETijYz110VkhHN;  // string | ID of the Key Credential for the application
            var targetAid = "targetAid_example";  // string | Unique key of the target Application

            try
            {
                // Clone a Key Credential
                JsonWebKey result = apiInstance.CloneApplicationKey(appId, keyId, targetAid);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationCredentialsApi.CloneApplicationKey: " + e.Message );
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
 **appId** | **string**| ID of the Application | 
 **keyId** | **string**| ID of the Key Credential for the application | 
 **targetAid** | **string**| Unique key of the target Application | 

### Return type

[**JsonWebKey**](JsonWebKey.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="generateapplicationkey"></a>
# **GenerateApplicationKey**
> JsonWebKey GenerateApplicationKey (string appId, int? validityYears = null)

Generate a Key Credential

Generates a new X.509 certificate for an application key credential

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GenerateApplicationKeyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationCredentialsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application
            var validityYears = 56;  // int? |  (optional) 

            try
            {
                // Generate a Key Credential
                JsonWebKey result = apiInstance.GenerateApplicationKey(appId, validityYears);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationCredentialsApi.GenerateApplicationKey: " + e.Message );
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
 **appId** | **string**| ID of the Application | 
 **validityYears** | **int?**|  | [optional] 

### Return type

[**JsonWebKey**](JsonWebKey.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="generatecsrforapplication"></a>
# **GenerateCsrForApplication**
> Csr GenerateCsrForApplication (string appId, CsrMetadata metadata)

Generate a Certificate Signing Request

Generates a new key pair and returns the Certificate Signing Request for it

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GenerateCsrForApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationCredentialsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application
            var metadata = new CsrMetadata(); // CsrMetadata | 

            try
            {
                // Generate a Certificate Signing Request
                Csr result = apiInstance.GenerateCsrForApplication(appId, metadata);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationCredentialsApi.GenerateCsrForApplication: " + e.Message );
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
 **appId** | **string**| ID of the Application | 
 **metadata** | [**CsrMetadata**](CsrMetadata.md)|  | 

### Return type

[**Csr**](Csr.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
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

<a name="getapplicationkey"></a>
# **GetApplicationKey**
> JsonWebKey GetApplicationKey (string appId, string keyId)

Retrieve a Key Credential

Retrieves a specific application key credential by kid

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetApplicationKeyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationCredentialsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application
            var keyId = sjP9eiETijYz110VkhHN;  // string | ID of the Key Credential for the application

            try
            {
                // Retrieve a Key Credential
                JsonWebKey result = apiInstance.GetApplicationKey(appId, keyId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationCredentialsApi.GetApplicationKey: " + e.Message );
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
 **appId** | **string**| ID of the Application | 
 **keyId** | **string**| ID of the Key Credential for the application | 

### Return type

[**JsonWebKey**](JsonWebKey.md)

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

<a name="getcsrforapplication"></a>
# **GetCsrForApplication**
> Csr GetCsrForApplication (string appId, string csrId)

Retrieve a Certificate Signing Request

Retrieves a certificate signing request for the app by `id`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetCsrForApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationCredentialsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application
            var csrId = fd7x1h7uTcZFx22rU1f7;  // string | `id` of the CSR

            try
            {
                // Retrieve a Certificate Signing Request
                Csr result = apiInstance.GetCsrForApplication(appId, csrId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationCredentialsApi.GetCsrForApplication: " + e.Message );
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
 **appId** | **string**| ID of the Application | 
 **csrId** | **string**| &#x60;id&#x60; of the CSR | 

### Return type

[**Csr**](Csr.md)

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

<a name="listapplicationkeys"></a>
# **ListApplicationKeys**
> List&lt;JsonWebKey&gt; ListApplicationKeys (string appId)

List all Key Credentials

Lists all key credentials for an application

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListApplicationKeysExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationCredentialsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application

            try
            {
                // List all Key Credentials
                List<JsonWebKey> result = apiInstance.ListApplicationKeys(appId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationCredentialsApi.ListApplicationKeys: " + e.Message );
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
 **appId** | **string**| ID of the Application | 

### Return type

[**List&lt;JsonWebKey&gt;**](JsonWebKey.md)

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

<a name="listcsrsforapplication"></a>
# **ListCsrsForApplication**
> List&lt;Csr&gt; ListCsrsForApplication (string appId)

List all Certificate Signing Requests

Lists all Certificate Signing Requests for an application

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListCsrsForApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationCredentialsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application

            try
            {
                // List all Certificate Signing Requests
                List<Csr> result = apiInstance.ListCsrsForApplication(appId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationCredentialsApi.ListCsrsForApplication: " + e.Message );
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
 **appId** | **string**| ID of the Application | 

### Return type

[**List&lt;Csr&gt;**](Csr.md)

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

<a name="publishcsrfromapplication"></a>
# **PublishCsrFromApplication**
> JsonWebKey PublishCsrFromApplication (string appId, string csrId, System.IO.Stream body)

Publish a Certificate Signing Request

Publishes a certificate signing request for the app with a signed X.509 certificate and adds it into the application key credentials

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class PublishCsrFromApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationCredentialsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application
            var csrId = fd7x1h7uTcZFx22rU1f7;  // string | `id` of the CSR
            var body = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream | 

            try
            {
                // Publish a Certificate Signing Request
                JsonWebKey result = apiInstance.PublishCsrFromApplication(appId, csrId, body);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationCredentialsApi.PublishCsrFromApplication: " + e.Message );
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
 **appId** | **string**| ID of the Application | 
 **csrId** | **string**| &#x60;id&#x60; of the CSR | 
 **body** | **System.IO.Stream****System.IO.Stream**|  | 

### Return type

[**JsonWebKey**](JsonWebKey.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/x-x509-ca-cert, application/pkix-cert, application/x-pem-file
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

<a name="revokecsrfromapplication"></a>
# **RevokeCsrFromApplication**
> void RevokeCsrFromApplication (string appId, string csrId)

Revoke a Certificate Signing Request

Revokes a certificate signing request and deletes the key pair from the application

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RevokeCsrFromApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationCredentialsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application
            var csrId = fd7x1h7uTcZFx22rU1f7;  // string | `id` of the CSR

            try
            {
                // Revoke a Certificate Signing Request
                apiInstance.RevokeCsrFromApplication(appId, csrId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationCredentialsApi.RevokeCsrFromApplication: " + e.Message );
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
 **appId** | **string**| ID of the Application | 
 **csrId** | **string**| &#x60;id&#x60; of the CSR | 

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

