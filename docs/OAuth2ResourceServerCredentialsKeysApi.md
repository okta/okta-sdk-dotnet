# Okta.Sdk.Api.OAuth2ResourceServerCredentialsKeysApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateOAuth2ResourceServerJsonWebKey**](OAuth2ResourceServerCredentialsKeysApi.md#activateoauth2resourceserverjsonwebkey) | **POST** /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId}/lifecycle/activate | Activate a Custom Authorization Server Public JSON Web Key
[**AddOAuth2ResourceServerJsonWebKey**](OAuth2ResourceServerCredentialsKeysApi.md#addoauth2resourceserverjsonwebkey) | **POST** /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys | Add a JSON Web Key
[**DeactivateOAuth2ResourceServerJsonWebKey**](OAuth2ResourceServerCredentialsKeysApi.md#deactivateoauth2resourceserverjsonwebkey) | **POST** /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId}/lifecycle/deactivate | Deactivate a Custom Authorization Server Public JSON Web Key
[**DeleteOAuth2ResourceServerJsonWebKey**](OAuth2ResourceServerCredentialsKeysApi.md#deleteoauth2resourceserverjsonwebkey) | **DELETE** /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId} | Delete a Custom Authorization Server Public JSON Web Key
[**GetOAuth2ResourceServerJsonWebKey**](OAuth2ResourceServerCredentialsKeysApi.md#getoauth2resourceserverjsonwebkey) | **GET** /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId} | Retrieve a Custom Authorization Server Public JSON Web Key
[**ListOAuth2ResourceServerJsonWebKeys**](OAuth2ResourceServerCredentialsKeysApi.md#listoauth2resourceserverjsonwebkeys) | **GET** /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys | List all Custom Authorization Server Public JSON Web Keys


<a name="activateoauth2resourceserverjsonwebkey"></a>
# **ActivateOAuth2ResourceServerJsonWebKey**
> OAuth2ResourceServerJsonWebKey ActivateOAuth2ResourceServerJsonWebKey (string authServerId, string keyId)

Activate a Custom Authorization Server Public JSON Web Key

Activates a custom authorization server public JSON web key by key `id`. > **Note:** You can have only one active key at any given time for the authorization server. When you activate an inactive key, Okta automatically deactivates the current active key.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateOAuth2ResourceServerJsonWebKeyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OAuth2ResourceServerCredentialsKeysApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var keyId = apk2f4zrZbs8nUa7p0g4;  // string | Unique `id` of the Custom Authorization Server JSON Web Key

            try
            {
                // Activate a Custom Authorization Server Public JSON Web Key
                OAuth2ResourceServerJsonWebKey result = apiInstance.ActivateOAuth2ResourceServerJsonWebKey(authServerId, keyId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OAuth2ResourceServerCredentialsKeysApi.ActivateOAuth2ResourceServerJsonWebKey: " + e.Message );
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
 **keyId** | **string**| Unique &#x60;id&#x60; of the Custom Authorization Server JSON Web Key | 

### Return type

[**OAuth2ResourceServerJsonWebKey**](OAuth2ResourceServerJsonWebKey.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="addoauth2resourceserverjsonwebkey"></a>
# **AddOAuth2ResourceServerJsonWebKey**
> OAuth2ResourceServerJsonWebKey AddOAuth2ResourceServerJsonWebKey (string authServerId, OAuth2ResourceServerJsonWebKeyRequestBody oAuth2ResourceServerJsonWebKeyRequestBody)

Add a JSON Web Key

Adds a new JSON Web Key to the custom authorization server`s JSON web keys. > **Note:** This API doesn't allow you to add a key if the existing key doesn't have a `kid`. Use the [Replace an Authorization Server](/openapi/okta-management/management/tag/AuthorizationServer/#tag/AuthorizationServer/operation/replaceAuthorizationServer) operation to update the JWKS or [Delete a Custom Authorization Server Public JSON Web Key](/openapi/okta-management/management/tag/OAuth2ResourceServerCredentialsKeys/#tag/OAuth2ResourceServerCredentialsKeys/operation/deleteOAuth2ResourceServerJsonWebKey) and re-add the key with a `kid`. > **Note:** This API doesn't allow you to add a key with an ACTIVE status. You need to add an INACTIVE key first, and then ACTIVATE the key.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AddOAuth2ResourceServerJsonWebKeyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OAuth2ResourceServerCredentialsKeysApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var oAuth2ResourceServerJsonWebKeyRequestBody = new OAuth2ResourceServerJsonWebKeyRequestBody(); // OAuth2ResourceServerJsonWebKeyRequestBody | 

            try
            {
                // Add a JSON Web Key
                OAuth2ResourceServerJsonWebKey result = apiInstance.AddOAuth2ResourceServerJsonWebKey(authServerId, oAuth2ResourceServerJsonWebKeyRequestBody);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OAuth2ResourceServerCredentialsKeysApi.AddOAuth2ResourceServerJsonWebKey: " + e.Message );
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
 **oAuth2ResourceServerJsonWebKeyRequestBody** | [**OAuth2ResourceServerJsonWebKeyRequestBody**](OAuth2ResourceServerJsonWebKeyRequestBody.md)|  | 

### Return type

[**OAuth2ResourceServerJsonWebKey**](OAuth2ResourceServerJsonWebKey.md)

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
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivateoauth2resourceserverjsonwebkey"></a>
# **DeactivateOAuth2ResourceServerJsonWebKey**
> OAuth2ResourceServerJsonWebKey DeactivateOAuth2ResourceServerJsonWebKey (string authServerId, string keyId)

Deactivate a Custom Authorization Server Public JSON Web Key

Deactivates a custom authorization server public JSON web key by key `id`. > **Note:** Deactivating the active key isn't allowed if the authorization server has access token encryption enabled. You can activate another key, which makes the current key inactive.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateOAuth2ResourceServerJsonWebKeyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OAuth2ResourceServerCredentialsKeysApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var keyId = apk2f4zrZbs8nUa7p0g4;  // string | Unique `id` of the Custom Authorization Server JSON Web Key

            try
            {
                // Deactivate a Custom Authorization Server Public JSON Web Key
                OAuth2ResourceServerJsonWebKey result = apiInstance.DeactivateOAuth2ResourceServerJsonWebKey(authServerId, keyId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OAuth2ResourceServerCredentialsKeysApi.DeactivateOAuth2ResourceServerJsonWebKey: " + e.Message );
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
 **keyId** | **string**| Unique &#x60;id&#x60; of the Custom Authorization Server JSON Web Key | 

### Return type

[**OAuth2ResourceServerJsonWebKey**](OAuth2ResourceServerJsonWebKey.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteoauth2resourceserverjsonwebkey"></a>
# **DeleteOAuth2ResourceServerJsonWebKey**
> void DeleteOAuth2ResourceServerJsonWebKey (string authServerId, string keyId)

Delete a Custom Authorization Server Public JSON Web Key

Deletes a custom authorization server public JSON web key by key `id`. You can only delete an inactive key.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteOAuth2ResourceServerJsonWebKeyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OAuth2ResourceServerCredentialsKeysApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var keyId = apk2f4zrZbs8nUa7p0g4;  // string | Unique `id` of the Custom Authorization Server JSON Web Key

            try
            {
                // Delete a Custom Authorization Server Public JSON Web Key
                apiInstance.DeleteOAuth2ResourceServerJsonWebKey(authServerId, keyId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OAuth2ResourceServerCredentialsKeysApi.DeleteOAuth2ResourceServerJsonWebKey: " + e.Message );
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
 **keyId** | **string**| Unique &#x60;id&#x60; of the Custom Authorization Server JSON Web Key | 

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
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getoauth2resourceserverjsonwebkey"></a>
# **GetOAuth2ResourceServerJsonWebKey**
> OAuth2ResourceServerJsonWebKey GetOAuth2ResourceServerJsonWebKey (string authServerId, string keyId)

Retrieve a Custom Authorization Server Public JSON Web Key

Retrieves a custom authorization server public JSON web key by key `id`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetOAuth2ResourceServerJsonWebKeyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OAuth2ResourceServerCredentialsKeysApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var keyId = apk2f4zrZbs8nUa7p0g4;  // string | Unique `id` of the Custom Authorization Server JSON Web Key

            try
            {
                // Retrieve a Custom Authorization Server Public JSON Web Key
                OAuth2ResourceServerJsonWebKey result = apiInstance.GetOAuth2ResourceServerJsonWebKey(authServerId, keyId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OAuth2ResourceServerCredentialsKeysApi.GetOAuth2ResourceServerJsonWebKey: " + e.Message );
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
 **keyId** | **string**| Unique &#x60;id&#x60; of the Custom Authorization Server JSON Web Key | 

### Return type

[**OAuth2ResourceServerJsonWebKey**](OAuth2ResourceServerJsonWebKey.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listoauth2resourceserverjsonwebkeys"></a>
# **ListOAuth2ResourceServerJsonWebKeys**
> List&lt;OAuth2ResourceServerJsonWebKey&gt; ListOAuth2ResourceServerJsonWebKeys (string authServerId)

List all Custom Authorization Server Public JSON Web Keys

Lists all the public keys used by the custom authorization server

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListOAuth2ResourceServerJsonWebKeysExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OAuth2ResourceServerCredentialsKeysApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server

            try
            {
                // List all Custom Authorization Server Public JSON Web Keys
                List<OAuth2ResourceServerJsonWebKey> result = apiInstance.ListOAuth2ResourceServerJsonWebKeys(authServerId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OAuth2ResourceServerCredentialsKeysApi.ListOAuth2ResourceServerJsonWebKeys: " + e.Message );
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

[**List&lt;OAuth2ResourceServerJsonWebKey&gt;**](OAuth2ResourceServerJsonWebKey.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

