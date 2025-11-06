# Okta.Sdk.Api.ApplicationSSOCredentialKeyApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CloneApplicationKey**](ApplicationSSOCredentialKeyApi.md#cloneapplicationkey) | **POST** /api/v1/apps/{appId}/credentials/keys/{keyId}/clone | Clone a key credential
[**GenerateApplicationKey**](ApplicationSSOCredentialKeyApi.md#generateapplicationkey) | **POST** /api/v1/apps/{appId}/credentials/keys/generate | Generate a key credential
[**GenerateCsrForApplication**](ApplicationSSOCredentialKeyApi.md#generatecsrforapplication) | **POST** /api/v1/apps/{appId}/credentials/csrs | Generate a certificate signing request
[**GetApplicationKey**](ApplicationSSOCredentialKeyApi.md#getapplicationkey) | **GET** /api/v1/apps/{appId}/credentials/keys/{keyId} | Retrieve a key credential
[**GetCsrForApplication**](ApplicationSSOCredentialKeyApi.md#getcsrforapplication) | **GET** /api/v1/apps/{appId}/credentials/csrs/{csrId} | Retrieve a certificate signing request
[**ListApplicationKeys**](ApplicationSSOCredentialKeyApi.md#listapplicationkeys) | **GET** /api/v1/apps/{appId}/credentials/keys | List all key credentials
[**ListCsrsForApplication**](ApplicationSSOCredentialKeyApi.md#listcsrsforapplication) | **GET** /api/v1/apps/{appId}/credentials/csrs | List all certificate signing requests
[**PublishCsrFromApplication**](ApplicationSSOCredentialKeyApi.md#publishcsrfromapplication) | **POST** /api/v1/apps/{appId}/credentials/csrs/{csrId}/lifecycle/publish | Publish a certificate signing request
[**RevokeCsrFromApplication**](ApplicationSSOCredentialKeyApi.md#revokecsrfromapplication) | **DELETE** /api/v1/apps/{appId}/credentials/csrs/{csrId} | Revoke a certificate signing request


<a name="cloneapplicationkey"></a>
# **CloneApplicationKey**
> JsonWebKey CloneApplicationKey (string appId, string keyId, string targetAid)

Clone a key credential

Clones an X.509 certificate for an Application Key Credential from a source app to a target app.  For step-by-step instructions to clone a credential, see [Share application key credentials for IdPs across apps](https://developer.okta.com/docs/guides/sharing-cert/main/). > **Note:** Sharing certificates isn't a recommended security practice.

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

            var apiInstance = new ApplicationSSOCredentialKeyApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var keyId = sjP9eiETijYz110VkhHN;  // string | ID of the Key Credential for the application
            var targetAid = 0ouuytCAJSSDELFTUIDS;  // string | Unique key of the target Application

            try
            {
                // Clone a key credential
                JsonWebKey result = apiInstance.CloneApplicationKey(appId, keyId, targetAid);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationSSOCredentialKeyApi.CloneApplicationKey: " + e.Message );
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
 **appId** | **string**| Application ID | 
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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="generateapplicationkey"></a>
# **GenerateApplicationKey**
> JsonWebKey GenerateApplicationKey (string appId, int validityYears)

Generate a key credential

Generates a new X.509 certificate for an app key credential > **Note:** To update an Application with the newly generated key credential, use the [Replace an Application](/openapi/okta-management/management/tag/Application/#tag/Application/operation/replaceApplication) request with the new [credentials.signing.kid](/openapi/okta-management/management/tag/Application/#tag/Application/operation/replaceApplication!path=4/credentials/signing/kid&t=request) value in the request body. You can provide just the [Signing Credential object](/openapi/okta-management/management/tag/Application/#tag/Application/operation/replaceApplication!path=4/credentials/signing&t=request) instead of the entire [Application Credential object](/openapi/okta-management/management/tag/Application/#tag/Application/operation/replaceApplication!path=4/credentials&t=request).

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

            var apiInstance = new ApplicationSSOCredentialKeyApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var validityYears = 5;  // int | Expiry years of the Application Key Credential

            try
            {
                // Generate a key credential
                JsonWebKey result = apiInstance.GenerateApplicationKey(appId, validityYears);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationSSOCredentialKeyApi.GenerateApplicationKey: " + e.Message );
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
 **appId** | **string**| Application ID | 
 **validityYears** | **int**| Expiry years of the Application Key Credential | 

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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="generatecsrforapplication"></a>
# **GenerateCsrForApplication**
> string GenerateCsrForApplication (string appId, CsrMetadata metadata)

Generate a certificate signing request

Generates a new key pair and returns the Certificate Signing Request(CSR) for it. The information in a CSR is used by the Certificate Authority (CA) to verify and create your certificate. It also contains the public key that is included in your certificate.  Returns CSR in `pkcs#10` format if the `Accept` media type is `application/pkcs10` or a CSR object if the `Accept` media type is `application/json`. > **Note:** The key pair isn't listed in the Key Credentials for the app until it's published.

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

            var apiInstance = new ApplicationSSOCredentialKeyApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var metadata = new CsrMetadata(); // CsrMetadata | 

            try
            {
                // Generate a certificate signing request
                string result = apiInstance.GenerateCsrForApplication(appId, metadata);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationSSOCredentialKeyApi.GenerateCsrForApplication: " + e.Message );
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
 **appId** | **string**| Application ID | 
 **metadata** | [**CsrMetadata**](CsrMetadata.md)|  | 

### Return type

**string**

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/pkcs10, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  * Content-Type - The Content-Type of the response <br>  * Content-Transfer-Encoding - Encoding of the response <br>  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getapplicationkey"></a>
# **GetApplicationKey**
> JsonWebKey GetApplicationKey (string appId, string keyId)

Retrieve a key credential

Retrieves a specific Application Key Credential by `kid`

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

            var apiInstance = new ApplicationSSOCredentialKeyApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var keyId = sjP9eiETijYz110VkhHN;  // string | ID of the Key Credential for the application

            try
            {
                // Retrieve a key credential
                JsonWebKey result = apiInstance.GetApplicationKey(appId, keyId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationSSOCredentialKeyApi.GetApplicationKey: " + e.Message );
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
 **appId** | **string**| Application ID | 
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

Retrieve a certificate signing request

Retrieves a Certificate Signing Request (CSR) for the app by `csrId`.  Returns a Base64-encoded CSR in DER format if the `Accept` media type is `application/pkcs10` or a CSR object if the `Accept` media type is `application/json`.

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

            var apiInstance = new ApplicationSSOCredentialKeyApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var csrId = fd7x1h7uTcZFx22rU1f7;  // string | `id` of the CSR

            try
            {
                // Retrieve a certificate signing request
                Csr result = apiInstance.GetCsrForApplication(appId, csrId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationSSOCredentialKeyApi.GetCsrForApplication: " + e.Message );
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
 **appId** | **string**| Application ID | 
 **csrId** | **string**| &#x60;id&#x60; of the CSR | 

### Return type

[**Csr**](Csr.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/pkcs10


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  * Content-Type - The Content-Type of the response <br>  * Content-Transfer-Encoding - Encoding of the response <br>  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listapplicationkeys"></a>
# **ListApplicationKeys**
> List&lt;JsonWebKey&gt; ListApplicationKeys (string appId)

List all key credentials

Lists all key credentials for an app

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

            var apiInstance = new ApplicationSSOCredentialKeyApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID

            try
            {
                // List all key credentials
                List<JsonWebKey> result = apiInstance.ListApplicationKeys(appId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationSSOCredentialKeyApi.ListApplicationKeys: " + e.Message );
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
 **appId** | **string**| Application ID | 

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

List all certificate signing requests

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

            var apiInstance = new ApplicationSSOCredentialKeyApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID

            try
            {
                // List all certificate signing requests
                List<Csr> result = apiInstance.ListCsrsForApplication(appId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationSSOCredentialKeyApi.ListCsrsForApplication: " + e.Message );
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
 **appId** | **string**| Application ID | 

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

Publish a certificate signing request

Publishes a Certificate Signing Request (CSR) for the app with a signed X.509 certificate and adds it into the Application Key Credentials. > **Note:** Publishing a certificate completes the lifecycle of the CSR and it's no longer accessible.

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

            var apiInstance = new ApplicationSSOCredentialKeyApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var csrId = fd7x1h7uTcZFx22rU1f7;  // string | `id` of the CSR
            var body = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream | 

            try
            {
                // Publish a certificate signing request
                JsonWebKey result = apiInstance.PublishCsrFromApplication(appId, csrId, body);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationSSOCredentialKeyApi.PublishCsrFromApplication: " + e.Message );
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
 **appId** | **string**| Application ID | 
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

Revoke a certificate signing request

Revokes a Certificate Signing Request and deletes the key pair from the app

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

            var apiInstance = new ApplicationSSOCredentialKeyApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var csrId = fd7x1h7uTcZFx22rU1f7;  // string | `id` of the CSR

            try
            {
                // Revoke a certificate signing request
                apiInstance.RevokeCsrFromApplication(appId, csrId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationSSOCredentialKeyApi.RevokeCsrFromApplication: " + e.Message );
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
 **appId** | **string**| Application ID | 
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

