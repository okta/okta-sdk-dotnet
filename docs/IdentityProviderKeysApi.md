# Okta.Sdk.Api.IdentityProviderKeysApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateIdentityProviderKey**](IdentityProviderKeysApi.md#createidentityproviderkey) | **POST** /api/v1/idps/credentials/keys | Create an IdP key credential
[**DeleteIdentityProviderKey**](IdentityProviderKeysApi.md#deleteidentityproviderkey) | **DELETE** /api/v1/idps/credentials/keys/{kid} | Delete an IdP key credential
[**GetIdentityProviderKey**](IdentityProviderKeysApi.md#getidentityproviderkey) | **GET** /api/v1/idps/credentials/keys/{kid} | Retrieve an IdP key credential
[**ListIdentityProviderKeys**](IdentityProviderKeysApi.md#listidentityproviderkeys) | **GET** /api/v1/idps/credentials/keys | List all IdP key credentials
[**ReplaceIdentityProviderKey**](IdentityProviderKeysApi.md#replaceidentityproviderkey) | **PUT** /api/v1/idps/credentials/keys/{kid} | Replace an IdP key credential


<a name="createidentityproviderkey"></a>
# **CreateIdentityProviderKey**
> IdPKeyCredential CreateIdentityProviderKey (IdPCertificateCredential jsonWebKey)

Create an IdP key credential

Creates a new X.509 certificate credential in the identity provider (IdP) key store > **Note:** RSA-based certificates are supported for all IdP types. Okta currently supports EC-based certificates only for the `X509` IdP type. For EC-based certificates we support only P-256, P-384, and P-521 curves.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateIdentityProviderKeyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderKeysApi(config);
            var jsonWebKey = new IdPCertificateCredential(); // IdPCertificateCredential | 

            try
            {
                // Create an IdP key credential
                IdPKeyCredential result = apiInstance.CreateIdentityProviderKey(jsonWebKey);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderKeysApi.CreateIdentityProviderKey: " + e.Message );
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
 **jsonWebKey** | [**IdPCertificateCredential**](IdPCertificateCredential.md)|  | 

### Return type

[**IdPKeyCredential**](IdPKeyCredential.md)

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

<a name="deleteidentityproviderkey"></a>
# **DeleteIdentityProviderKey**
> void DeleteIdentityProviderKey (string kid)

Delete an IdP key credential

Deletes a specific identity provider (IdP) key credential by `kid` if it isn't currently being used by an active or inactive IdP

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteIdentityProviderKeyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderKeysApi(config);
            var kid = KmMo85SSsU7TZzOShcGb;  // string | Unique `id` of the IdP key credential

            try
            {
                // Delete an IdP key credential
                apiInstance.DeleteIdentityProviderKey(kid);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderKeysApi.DeleteIdentityProviderKey: " + e.Message );
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
 **kid** | **string**| Unique &#x60;id&#x60; of the IdP key credential | 

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

<a name="getidentityproviderkey"></a>
# **GetIdentityProviderKey**
> IdPKeyCredential GetIdentityProviderKey (string kid)

Retrieve an IdP key credential

Retrieves a specific identity provider (IdP) key credential by `kid`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetIdentityProviderKeyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderKeysApi(config);
            var kid = KmMo85SSsU7TZzOShcGb;  // string | Unique `id` of the IdP key credential

            try
            {
                // Retrieve an IdP key credential
                IdPKeyCredential result = apiInstance.GetIdentityProviderKey(kid);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderKeysApi.GetIdentityProviderKey: " + e.Message );
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
 **kid** | **string**| Unique &#x60;id&#x60; of the IdP key credential | 

### Return type

[**IdPKeyCredential**](IdPKeyCredential.md)

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

<a name="listidentityproviderkeys"></a>
# **ListIdentityProviderKeys**
> List&lt;IdPKeyCredential&gt; ListIdentityProviderKeys (string after = null, int? limit = null)

List all IdP key credentials

Lists all identity provider (IdP) key credentials

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListIdentityProviderKeysExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderKeysApi(config);
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 
            var limit = 20;  // int? | A limit on the number of objects to return (optional)  (default to 20)

            try
            {
                // List all IdP key credentials
                List<IdPKeyCredential> result = apiInstance.ListIdentityProviderKeys(after, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderKeysApi.ListIdentityProviderKeys: " + e.Message );
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
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 
 **limit** | **int?**| A limit on the number of objects to return | [optional] [default to 20]

### Return type

[**List&lt;IdPKeyCredential&gt;**](IdPKeyCredential.md)

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

<a name="replaceidentityproviderkey"></a>
# **ReplaceIdentityProviderKey**
> IdPKeyCredential ReplaceIdentityProviderKey (string kid, Dictionary<string, Object> requestBody)

Replace an IdP key credential

Replaces an identity provider (IdP) key credential by `kid`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceIdentityProviderKeyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IdentityProviderKeysApi(config);
            var kid = KmMo85SSsU7TZzOShcGb;  // string | Unique `id` of the IdP key credential
            var requestBody = new Dictionary<string, Object>(); // Dictionary<string, Object> | Updated IdP key credential

            try
            {
                // Replace an IdP key credential
                IdPKeyCredential result = apiInstance.ReplaceIdentityProviderKey(kid, requestBody);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IdentityProviderKeysApi.ReplaceIdentityProviderKey: " + e.Message );
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
 **kid** | **string**| Unique &#x60;id&#x60; of the IdP key credential | 
 **requestBody** | [**Dictionary&lt;string, Object&gt;**](Object.md)| Updated IdP key credential | 

### Return type

[**IdPKeyCredential**](IdPKeyCredential.md)

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

