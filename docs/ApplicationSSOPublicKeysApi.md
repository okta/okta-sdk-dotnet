# Okta.Sdk.Api.ApplicationSSOPublicKeysApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateOAuth2ClientJsonWebKey**](ApplicationSSOPublicKeysApi.md#activateoauth2clientjsonwebkey) | **POST** /api/v1/apps/{appId}/credentials/jwks/{keyId}/lifecycle/activate | Activate an OAuth 2.0 client JSON Web Key
[**ActivateOAuth2ClientSecret**](ApplicationSSOPublicKeysApi.md#activateoauth2clientsecret) | **POST** /api/v1/apps/{appId}/credentials/secrets/{secretId}/lifecycle/activate | Activate an OAuth 2.0 client secret
[**AddJwk**](ApplicationSSOPublicKeysApi.md#addjwk) | **POST** /api/v1/apps/{appId}/credentials/jwks | Add a JSON Web Key
[**CreateOAuth2ClientSecret**](ApplicationSSOPublicKeysApi.md#createoauth2clientsecret) | **POST** /api/v1/apps/{appId}/credentials/secrets | Create an OAuth 2.0 client secret
[**DeactivateOAuth2ClientJsonWebKey**](ApplicationSSOPublicKeysApi.md#deactivateoauth2clientjsonwebkey) | **POST** /api/v1/apps/{appId}/credentials/jwks/{keyId}/lifecycle/deactivate | Deactivate an OAuth 2.0 client JSON Web Key
[**DeactivateOAuth2ClientSecret**](ApplicationSSOPublicKeysApi.md#deactivateoauth2clientsecret) | **POST** /api/v1/apps/{appId}/credentials/secrets/{secretId}/lifecycle/deactivate | Deactivate an OAuth 2.0 client secret
[**DeleteOAuth2ClientSecret**](ApplicationSSOPublicKeysApi.md#deleteoauth2clientsecret) | **DELETE** /api/v1/apps/{appId}/credentials/secrets/{secretId} | Delete an OAuth 2.0 client secret
[**Deletejwk**](ApplicationSSOPublicKeysApi.md#deletejwk) | **DELETE** /api/v1/apps/{appId}/credentials/jwks/{keyId} | Delete an OAuth 2.0 client JSON Web Key
[**GetJwk**](ApplicationSSOPublicKeysApi.md#getjwk) | **GET** /api/v1/apps/{appId}/credentials/jwks/{keyId} | Retrieve an OAuth 2.0 client JSON Web Key
[**GetOAuth2ClientSecret**](ApplicationSSOPublicKeysApi.md#getoauth2clientsecret) | **GET** /api/v1/apps/{appId}/credentials/secrets/{secretId} | Retrieve an OAuth 2.0 client secret
[**ListJwk**](ApplicationSSOPublicKeysApi.md#listjwk) | **GET** /api/v1/apps/{appId}/credentials/jwks | List all the OAuth 2.0 client JSON Web Keys
[**ListOAuth2ClientSecrets**](ApplicationSSOPublicKeysApi.md#listoauth2clientsecrets) | **GET** /api/v1/apps/{appId}/credentials/secrets | List all OAuth 2.0 client secrets


<a name="activateoauth2clientjsonwebkey"></a>
# **ActivateOAuth2ClientJsonWebKey**
> AddJwk201Response ActivateOAuth2ClientJsonWebKey (string appId, string keyId)

Activate an OAuth 2.0 client JSON Web Key

Activates an OAuth 2.0 Client JSON Web Key by `keyId` > **Note:** You can have only one active encryption key at any given time for app. When you activate an inactive key, the current active key is automatically deactivated.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateOAuth2ClientJsonWebKeyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationSSOPublicKeysApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var keyId = apk2f4zrZbs8nUa7p0g4;  // string | Unique `id` of the Custom Authorization Server JSON Web Key

            try
            {
                // Activate an OAuth 2.0 client JSON Web Key
                AddJwk201Response result = apiInstance.ActivateOAuth2ClientJsonWebKey(appId, keyId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationSSOPublicKeysApi.ActivateOAuth2ClientJsonWebKey: " + e.Message );
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
 **keyId** | **string**| Unique &#x60;id&#x60; of the Custom Authorization Server JSON Web Key | 

### Return type

[**AddJwk201Response**](AddJwk201Response.md)

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

<a name="activateoauth2clientsecret"></a>
# **ActivateOAuth2ClientSecret**
> OAuth2ClientSecret ActivateOAuth2ClientSecret (string appId, string secretId)

Activate an OAuth 2.0 client secret

Activates an OAuth 2.0 Client Secret by `secretId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateOAuth2ClientSecretExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationSSOPublicKeysApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var secretId = ocs2f4zrZbs8nUa7p0g4;  // string | Unique `id` of the OAuth 2.0 Client Secret

            try
            {
                // Activate an OAuth 2.0 client secret
                OAuth2ClientSecret result = apiInstance.ActivateOAuth2ClientSecret(appId, secretId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationSSOPublicKeysApi.ActivateOAuth2ClientSecret: " + e.Message );
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
 **secretId** | **string**| Unique &#x60;id&#x60; of the OAuth 2.0 Client Secret | 

### Return type

[**OAuth2ClientSecret**](OAuth2ClientSecret.md)

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

<a name="addjwk"></a>
# **AddJwk**
> AddJwk201Response AddJwk (string appId, AddJwkRequest addJwkRequest)

Add a JSON Web Key

Adds a new JSON Web Key to the client`s JSON Web Keys. > **Note:** This API doesn't allow you to add a key if the existing key doesn't have a `kid`. This is also consistent with how the [Dynamic Client Registration](/openapi/okta-oauth/oauth/tag/Client/) or [Applications](/openapi/okta-management/management/tag/Application/) APIs behave, as they don't allow the creation of multiple keys without `kids`. Use the [Replace an Application](/openapi/okta-management/management/tag/Application/#tag/Application/operation/replaceApplication) or the [Replace a Client Application](/openapi/okta-oauth/oauth/tag/Client/#tag/Client/operation/replaceClient) operation to update the JWKS or [Delete an OAuth 2.0 Client JSON Web Key](/openapi/okta-management/management/tag/ApplicationSSOPublicKeys/#tag/ApplicationSSOPublicKeys/operation/deletejwk) and re-add the key with a `kid`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AddJwkExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationSSOPublicKeysApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var addJwkRequest = new AddJwkRequest(); // AddJwkRequest | 

            try
            {
                // Add a JSON Web Key
                AddJwk201Response result = apiInstance.AddJwk(appId, addJwkRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationSSOPublicKeysApi.AddJwk: " + e.Message );
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
 **addJwkRequest** | [**AddJwkRequest**](AddJwkRequest.md)|  | 

### Return type

[**AddJwk201Response**](AddJwk201Response.md)

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

<a name="createoauth2clientsecret"></a>
# **CreateOAuth2ClientSecret**
> OAuth2ClientSecret CreateOAuth2ClientSecret (string appId, OAuth2ClientSecretRequestBody oAuth2ClientSecretRequestBody = null)

Create an OAuth 2.0 client secret

Creates an OAuth 2.0 Client Secret object with a new active client secret. You can create up to two Secret objects. An error is returned if you attempt to create more than two Secret objects. > **Note:** This API lets you bring your own secret. If [token_endpoint_auth_method](/openapi/okta-management/management/tag/Application/#tag/Application/operation/createApplication!path=4/credentials/oauthClient/token_endpoint_auth_method&t=request) of the app is `client_secret_jwt`, then the minimum length of `client_secret` is 32 characters. If no secret is specified in the request, Okta adds a new system-generated secret.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateOAuth2ClientSecretExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationSSOPublicKeysApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var oAuth2ClientSecretRequestBody = new OAuth2ClientSecretRequestBody(); // OAuth2ClientSecretRequestBody |  (optional) 

            try
            {
                // Create an OAuth 2.0 client secret
                OAuth2ClientSecret result = apiInstance.CreateOAuth2ClientSecret(appId, oAuth2ClientSecretRequestBody);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationSSOPublicKeysApi.CreateOAuth2ClientSecret: " + e.Message );
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
 **oAuth2ClientSecretRequestBody** | [**OAuth2ClientSecretRequestBody**](OAuth2ClientSecretRequestBody.md)|  | [optional] 

### Return type

[**OAuth2ClientSecret**](OAuth2ClientSecret.md)

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

<a name="deactivateoauth2clientjsonwebkey"></a>
# **DeactivateOAuth2ClientJsonWebKey**
> OAuth2ClientJsonSigningKeyResponse DeactivateOAuth2ClientJsonWebKey (string appId, string keyId)

Deactivate an OAuth 2.0 client JSON Web Key

Deactivates an OAuth 2.0 Client JSON Web Key by `keyId`. > **Note:** You can only deactivate signing keys. Deactivating the active encryption key isn't allowed if the client has ID token encryption enabled. You can activate another encryption key, which makes the current key inactive.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateOAuth2ClientJsonWebKeyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationSSOPublicKeysApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var keyId = apk2f4zrZbs8nUa7p0g4;  // string | Unique `id` of the Custom Authorization Server JSON Web Key

            try
            {
                // Deactivate an OAuth 2.0 client JSON Web Key
                OAuth2ClientJsonSigningKeyResponse result = apiInstance.DeactivateOAuth2ClientJsonWebKey(appId, keyId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationSSOPublicKeysApi.DeactivateOAuth2ClientJsonWebKey: " + e.Message );
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
 **keyId** | **string**| Unique &#x60;id&#x60; of the Custom Authorization Server JSON Web Key | 

### Return type

[**OAuth2ClientJsonSigningKeyResponse**](OAuth2ClientJsonSigningKeyResponse.md)

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

<a name="deactivateoauth2clientsecret"></a>
# **DeactivateOAuth2ClientSecret**
> OAuth2ClientSecret DeactivateOAuth2ClientSecret (string appId, string secretId)

Deactivate an OAuth 2.0 client secret

Deactivates an OAuth 2.0 Client Secret by `secretId`. You can't deactivate a secret if it's the only secret of the client.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateOAuth2ClientSecretExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationSSOPublicKeysApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var secretId = ocs2f4zrZbs8nUa7p0g4;  // string | Unique `id` of the OAuth 2.0 Client Secret

            try
            {
                // Deactivate an OAuth 2.0 client secret
                OAuth2ClientSecret result = apiInstance.DeactivateOAuth2ClientSecret(appId, secretId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationSSOPublicKeysApi.DeactivateOAuth2ClientSecret: " + e.Message );
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
 **secretId** | **string**| Unique &#x60;id&#x60; of the OAuth 2.0 Client Secret | 

### Return type

[**OAuth2ClientSecret**](OAuth2ClientSecret.md)

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

<a name="deleteoauth2clientsecret"></a>
# **DeleteOAuth2ClientSecret**
> void DeleteOAuth2ClientSecret (string appId, string secretId)

Delete an OAuth 2.0 client secret

Deletes an OAuth 2.0 Client Secret by `secretId`. You can only delete an inactive Secret.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteOAuth2ClientSecretExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationSSOPublicKeysApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var secretId = ocs2f4zrZbs8nUa7p0g4;  // string | Unique `id` of the OAuth 2.0 Client Secret

            try
            {
                // Delete an OAuth 2.0 client secret
                apiInstance.DeleteOAuth2ClientSecret(appId, secretId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationSSOPublicKeysApi.DeleteOAuth2ClientSecret: " + e.Message );
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
 **secretId** | **string**| Unique &#x60;id&#x60; of the OAuth 2.0 Client Secret | 

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

<a name="deletejwk"></a>
# **Deletejwk**
> void Deletejwk (string appId, string keyId)

Delete an OAuth 2.0 client JSON Web Key

Deletes an OAuth 2.0 Client JSON Web Key by `keyId`. You can only delete an inactive key.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeletejwkExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationSSOPublicKeysApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var keyId = apk2f4zrZbs8nUa7p0g4;  // string | Unique `id` of the Custom Authorization Server JSON Web Key

            try
            {
                // Delete an OAuth 2.0 client JSON Web Key
                apiInstance.Deletejwk(appId, keyId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationSSOPublicKeysApi.Deletejwk: " + e.Message );
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

<a name="getjwk"></a>
# **GetJwk**
> GetJwk200Response GetJwk (string appId, string keyId)

Retrieve an OAuth 2.0 client JSON Web Key

Retrieves an OAuth 2.0 Client JSON Web Key by `keyId`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetJwkExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationSSOPublicKeysApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var keyId = apk2f4zrZbs8nUa7p0g4;  // string | Unique `id` of the Custom Authorization Server JSON Web Key

            try
            {
                // Retrieve an OAuth 2.0 client JSON Web Key
                GetJwk200Response result = apiInstance.GetJwk(appId, keyId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationSSOPublicKeysApi.GetJwk: " + e.Message );
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
 **keyId** | **string**| Unique &#x60;id&#x60; of the Custom Authorization Server JSON Web Key | 

### Return type

[**GetJwk200Response**](GetJwk200Response.md)

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

<a name="getoauth2clientsecret"></a>
# **GetOAuth2ClientSecret**
> OAuth2ClientSecret GetOAuth2ClientSecret (string appId, string secretId)

Retrieve an OAuth 2.0 client secret

Retrieves an OAuth 2.0 Client Secret by `secretId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetOAuth2ClientSecretExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationSSOPublicKeysApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var secretId = ocs2f4zrZbs8nUa7p0g4;  // string | Unique `id` of the OAuth 2.0 Client Secret

            try
            {
                // Retrieve an OAuth 2.0 client secret
                OAuth2ClientSecret result = apiInstance.GetOAuth2ClientSecret(appId, secretId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationSSOPublicKeysApi.GetOAuth2ClientSecret: " + e.Message );
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
 **secretId** | **string**| Unique &#x60;id&#x60; of the OAuth 2.0 Client Secret | 

### Return type

[**OAuth2ClientSecret**](OAuth2ClientSecret.md)

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

<a name="listjwk"></a>
# **ListJwk**
> OAuth2ClientJsonWebKeySet ListJwk (string appId)

List all the OAuth 2.0 client JSON Web Keys

Lists all JSON Web Keys for an OAuth 2.0 client app

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListJwkExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationSSOPublicKeysApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID

            try
            {
                // List all the OAuth 2.0 client JSON Web Keys
                OAuth2ClientJsonWebKeySet result = apiInstance.ListJwk(appId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationSSOPublicKeysApi.ListJwk: " + e.Message );
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

[**OAuth2ClientJsonWebKeySet**](OAuth2ClientJsonWebKeySet.md)

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

<a name="listoauth2clientsecrets"></a>
# **ListOAuth2ClientSecrets**
> List&lt;OAuth2ClientSecret&gt; ListOAuth2ClientSecrets (string appId)

List all OAuth 2.0 client secrets

Lists all client secrets for an OAuth 2.0 client app

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListOAuth2ClientSecretsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationSSOPublicKeysApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID

            try
            {
                // List all OAuth 2.0 client secrets
                List<OAuth2ClientSecret> result = apiInstance.ListOAuth2ClientSecrets(appId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationSSOPublicKeysApi.ListOAuth2ClientSecrets: " + e.Message );
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

[**List&lt;OAuth2ClientSecret&gt;**](OAuth2ClientSecret.md)

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

