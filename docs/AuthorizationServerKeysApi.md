# Okta.Sdk.Api.AuthorizationServerKeysApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetAuthorizationServerKey**](AuthorizationServerKeysApi.md#getauthorizationserverkey) | **GET** /api/v1/authorizationServers/{authServerId}/credentials/keys/{keyId} | Retrieve an authorization server key
[**ListAuthorizationServerKeys**](AuthorizationServerKeysApi.md#listauthorizationserverkeys) | **GET** /api/v1/authorizationServers/{authServerId}/credentials/keys | List all credential keys
[**RotateAuthorizationServerKeys**](AuthorizationServerKeysApi.md#rotateauthorizationserverkeys) | **POST** /api/v1/authorizationServers/{authServerId}/credentials/lifecycle/keyRotate | Rotate all credential keys


<a name="getauthorizationserverkey"></a>
# **GetAuthorizationServerKey**
> AuthorizationServerJsonWebKey GetAuthorizationServerKey (string authServerId, string keyId)

Retrieve an authorization server key

Retrieves an Authorization Server Key specified by the `keyId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetAuthorizationServerKeyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerKeysApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var keyId = P7jXpG-LG2ObNgY9C0Mn2uf4InCQTmRZMDCZoVNxdrk;  // string | `id` of the certificate key

            try
            {
                // Retrieve an authorization server key
                AuthorizationServerJsonWebKey result = apiInstance.GetAuthorizationServerKey(authServerId, keyId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerKeysApi.GetAuthorizationServerKey: " + e.Message );
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
 **authServerId** | **string**| &#x60;id&#x60; of the Authorization Server | 
 **keyId** | **string**| &#x60;id&#x60; of the certificate key | 

### Return type

[**AuthorizationServerJsonWebKey**](AuthorizationServerJsonWebKey.md)

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

<a name="listauthorizationserverkeys"></a>
# **ListAuthorizationServerKeys**
> List&lt;AuthorizationServerJsonWebKey&gt; ListAuthorizationServerKeys (string authServerId)

List all credential keys

Lists all of the current, future, and expired Keys used by the Custom Authorization Server

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListAuthorizationServerKeysExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerKeysApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server

            try
            {
                // List all credential keys
                List<AuthorizationServerJsonWebKey> result = apiInstance.ListAuthorizationServerKeys(authServerId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerKeysApi.ListAuthorizationServerKeys: " + e.Message );
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
 **authServerId** | **string**| &#x60;id&#x60; of the Authorization Server | 

### Return type

[**List&lt;AuthorizationServerJsonWebKey&gt;**](AuthorizationServerJsonWebKey.md)

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

<a name="rotateauthorizationserverkeys"></a>
# **RotateAuthorizationServerKeys**
> List&lt;AuthorizationServerJsonWebKey&gt; RotateAuthorizationServerKeys (string authServerId, JwkUse use)

Rotate all credential keys

Rotates the current Keys for a Custom Authorization Server. If you rotate Keys, the `ACTIVE` Key becomes the `EXPIRED` Key, the `NEXT` Key becomes the `ACTIVE` Key, and the Custom Authorization Server immediately begins using the new active Key to sign tokens.  > **Note:** Okta rotates your Keys automatically in `AUTO` mode. You can rotate Keys yourself in either mode. If Keys are rotated manually, you should invalidate any intermediate cache. and fetch the Keys again using the Keys endpoint.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RotateAuthorizationServerKeysExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerKeysApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var use = new JwkUse(); // JwkUse | 

            try
            {
                // Rotate all credential keys
                List<AuthorizationServerJsonWebKey> result = apiInstance.RotateAuthorizationServerKeys(authServerId, use).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerKeysApi.RotateAuthorizationServerKeys: " + e.Message );
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
 **authServerId** | **string**| &#x60;id&#x60; of the Authorization Server | 
 **use** | [**JwkUse**](JwkUse.md)|  | 

### Return type

[**List&lt;AuthorizationServerJsonWebKey&gt;**](AuthorizationServerJsonWebKey.md)

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

