# Okta.Sdk.Api.AuthenticatorApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateAuthenticator**](AuthenticatorApi.md#activateauthenticator) | **POST** /api/v1/authenticators/{authenticatorId}/lifecycle/activate | Activate an Authenticator
[**ActivateAuthenticatorMethod**](AuthenticatorApi.md#activateauthenticatormethod) | **POST** /api/v1/authenticators/{authenticatorId}/methods/{methodType}/lifecycle/activate | Activate an Authenticator Method
[**CreateAuthenticator**](AuthenticatorApi.md#createauthenticator) | **POST** /api/v1/authenticators | Create an Authenticator
[**DeactivateAuthenticator**](AuthenticatorApi.md#deactivateauthenticator) | **POST** /api/v1/authenticators/{authenticatorId}/lifecycle/deactivate | Deactivate an Authenticator
[**DeactivateAuthenticatorMethod**](AuthenticatorApi.md#deactivateauthenticatormethod) | **POST** /api/v1/authenticators/{authenticatorId}/methods/{methodType}/lifecycle/deactivate | Deactivate an Authenticator Method
[**GetAuthenticator**](AuthenticatorApi.md#getauthenticator) | **GET** /api/v1/authenticators/{authenticatorId} | Retrieve an Authenticator
[**GetAuthenticatorMethod**](AuthenticatorApi.md#getauthenticatormethod) | **GET** /api/v1/authenticators/{authenticatorId}/methods/{methodType} | Retrieve a Method
[**GetWellKnownAppAuthenticatorConfiguration**](AuthenticatorApi.md#getwellknownappauthenticatorconfiguration) | **GET** /.well-known/app-authenticator-configuration | Retrieve the Well-Known App Authenticator Configuration
[**ListAuthenticatorMethods**](AuthenticatorApi.md#listauthenticatormethods) | **GET** /api/v1/authenticators/{authenticatorId}/methods | List all Methods of an Authenticator
[**ListAuthenticators**](AuthenticatorApi.md#listauthenticators) | **GET** /api/v1/authenticators | List all Authenticators
[**ReplaceAuthenticator**](AuthenticatorApi.md#replaceauthenticator) | **PUT** /api/v1/authenticators/{authenticatorId} | Replace an Authenticator
[**ReplaceAuthenticatorMethod**](AuthenticatorApi.md#replaceauthenticatormethod) | **PUT** /api/v1/authenticators/{authenticatorId}/methods/{methodType} | Replace a Method


<a name="activateauthenticator"></a>
# **ActivateAuthenticator**
> void ActivateAuthenticator (string authenticatorId)

Activate an Authenticator

Activates an authenticator by `authenticatorId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateAuthenticatorExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthenticatorApi(config);
            var authenticatorId = aut1nd8PQhGcQtSxB0g4;  // string | `id` of the Authenticator

            try
            {
                // Activate an Authenticator
                apiInstance.ActivateAuthenticator(authenticatorId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthenticatorApi.ActivateAuthenticator: " + e.Message );
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
 **authenticatorId** | **string**| &#x60;id&#x60; of the Authenticator | 

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
| **200** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="activateauthenticatormethod"></a>
# **ActivateAuthenticatorMethod**
> AuthenticatorMethodBase ActivateAuthenticatorMethod (string authenticatorId, AuthenticatorMethodType methodType)

Activate an Authenticator Method

Activates a Method for an Authenticator identified by `authenticatorId` and `methodType`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateAuthenticatorMethodExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthenticatorApi(config);
            var authenticatorId = aut1nd8PQhGcQtSxB0g4;  // string | `id` of the Authenticator
            var methodType = (AuthenticatorMethodType) "cert";  // AuthenticatorMethodType | Type of the authenticator method

            try
            {
                // Activate an Authenticator Method
                AuthenticatorMethodBase result = apiInstance.ActivateAuthenticatorMethod(authenticatorId, methodType);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthenticatorApi.ActivateAuthenticatorMethod: " + e.Message );
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
 **authenticatorId** | **string**| &#x60;id&#x60; of the Authenticator | 
 **methodType** | **AuthenticatorMethodType**| Type of the authenticator method | 

### Return type

[**AuthenticatorMethodBase**](AuthenticatorMethodBase.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createauthenticator"></a>
# **CreateAuthenticator**
> void CreateAuthenticator (Authenticator authenticator, bool? activate = null)

Create an Authenticator

Creates an authenticator

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateAuthenticatorExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthenticatorApi(config);
            var authenticator = new Authenticator(); // Authenticator | 
            var activate = false;  // bool? | Whether to execute the activation lifecycle operation when Okta creates the authenticator (optional)  (default to false)

            try
            {
                // Create an Authenticator
                apiInstance.CreateAuthenticator(authenticator, activate);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthenticatorApi.CreateAuthenticator: " + e.Message );
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
 **authenticator** | [**Authenticator**](Authenticator.md)|  | 
 **activate** | **bool?**| Whether to execute the activation lifecycle operation when Okta creates the authenticator | [optional] [default to false]

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
| **200** |  |  -  |
| **400** |  |  -  |
| **403** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivateauthenticator"></a>
# **DeactivateAuthenticator**
> void DeactivateAuthenticator (string authenticatorId)

Deactivate an Authenticator

Deactivates an authenticator by `authenticatorId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateAuthenticatorExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthenticatorApi(config);
            var authenticatorId = aut1nd8PQhGcQtSxB0g4;  // string | `id` of the Authenticator

            try
            {
                // Deactivate an Authenticator
                apiInstance.DeactivateAuthenticator(authenticatorId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthenticatorApi.DeactivateAuthenticator: " + e.Message );
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
 **authenticatorId** | **string**| &#x60;id&#x60; of the Authenticator | 

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
| **200** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivateauthenticatormethod"></a>
# **DeactivateAuthenticatorMethod**
> AuthenticatorMethodBase DeactivateAuthenticatorMethod (string authenticatorId, AuthenticatorMethodType methodType)

Deactivate an Authenticator Method

Deactivates a Method for an Authenticator identified by `authenticatorId` and `methodType`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateAuthenticatorMethodExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthenticatorApi(config);
            var authenticatorId = aut1nd8PQhGcQtSxB0g4;  // string | `id` of the Authenticator
            var methodType = (AuthenticatorMethodType) "cert";  // AuthenticatorMethodType | Type of the authenticator method

            try
            {
                // Deactivate an Authenticator Method
                AuthenticatorMethodBase result = apiInstance.DeactivateAuthenticatorMethod(authenticatorId, methodType);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthenticatorApi.DeactivateAuthenticatorMethod: " + e.Message );
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
 **authenticatorId** | **string**| &#x60;id&#x60; of the Authenticator | 
 **methodType** | **AuthenticatorMethodType**| Type of the authenticator method | 

### Return type

[**AuthenticatorMethodBase**](AuthenticatorMethodBase.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getauthenticator"></a>
# **GetAuthenticator**
> void GetAuthenticator (string authenticatorId)

Retrieve an Authenticator

Retrieves an authenticator from your Okta organization by `authenticatorId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetAuthenticatorExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthenticatorApi(config);
            var authenticatorId = aut1nd8PQhGcQtSxB0g4;  // string | `id` of the Authenticator

            try
            {
                // Retrieve an Authenticator
                apiInstance.GetAuthenticator(authenticatorId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthenticatorApi.GetAuthenticator: " + e.Message );
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
 **authenticatorId** | **string**| &#x60;id&#x60; of the Authenticator | 

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
| **200** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getauthenticatormethod"></a>
# **GetAuthenticatorMethod**
> AuthenticatorMethodBase GetAuthenticatorMethod (string authenticatorId, AuthenticatorMethodType methodType)

Retrieve a Method

Retrieves a Method identified by `methodType` of an Authenticator identified by `authenticatorId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetAuthenticatorMethodExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthenticatorApi(config);
            var authenticatorId = aut1nd8PQhGcQtSxB0g4;  // string | `id` of the Authenticator
            var methodType = (AuthenticatorMethodType) "cert";  // AuthenticatorMethodType | Type of the authenticator method

            try
            {
                // Retrieve a Method
                AuthenticatorMethodBase result = apiInstance.GetAuthenticatorMethod(authenticatorId, methodType);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthenticatorApi.GetAuthenticatorMethod: " + e.Message );
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
 **authenticatorId** | **string**| &#x60;id&#x60; of the Authenticator | 
 **methodType** | **AuthenticatorMethodType**| Type of the authenticator method | 

### Return type

[**AuthenticatorMethodBase**](AuthenticatorMethodBase.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getwellknownappauthenticatorconfiguration"></a>
# **GetWellKnownAppAuthenticatorConfiguration**
> List&lt;WellKnownAppAuthenticatorConfiguration&gt; GetWellKnownAppAuthenticatorConfiguration (string oauthClientId)

Retrieve the Well-Known App Authenticator Configuration

Retrieves the well-known app authenticator configuration, which includes an app authenticator's settings, supported methods and various other configuration details

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetWellKnownAppAuthenticatorConfigurationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            var apiInstance = new AuthenticatorApi(config);
            var oauthClientId = "oauthClientId_example";  // string | Filters app authenticator configurations by `oauthClientId`

            try
            {
                // Retrieve the Well-Known App Authenticator Configuration
                List<WellKnownAppAuthenticatorConfiguration> result = apiInstance.GetWellKnownAppAuthenticatorConfiguration(oauthClientId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthenticatorApi.GetWellKnownAppAuthenticatorConfiguration: " + e.Message );
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
 **oauthClientId** | **string**| Filters app authenticator configurations by &#x60;oauthClientId&#x60; | 

### Return type

[**List&lt;WellKnownAppAuthenticatorConfiguration&gt;**](WellKnownAppAuthenticatorConfiguration.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | Bad Request |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listauthenticatormethods"></a>
# **ListAuthenticatorMethods**
> List&lt;AuthenticatorMethodBase&gt; ListAuthenticatorMethods (string authenticatorId)

List all Methods of an Authenticator

Lists all Methods of an Authenticator identified by `authenticatorId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListAuthenticatorMethodsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthenticatorApi(config);
            var authenticatorId = aut1nd8PQhGcQtSxB0g4;  // string | `id` of the Authenticator

            try
            {
                // List all Methods of an Authenticator
                List<AuthenticatorMethodBase> result = apiInstance.ListAuthenticatorMethods(authenticatorId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthenticatorApi.ListAuthenticatorMethods: " + e.Message );
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
 **authenticatorId** | **string**| &#x60;id&#x60; of the Authenticator | 

### Return type

[**List&lt;AuthenticatorMethodBase&gt;**](AuthenticatorMethodBase.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listauthenticators"></a>
# **ListAuthenticators**
> List&lt;Authenticator&gt; ListAuthenticators ()

List all Authenticators

Lists all authenticators

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListAuthenticatorsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthenticatorApi(config);

            try
            {
                // List all Authenticators
                List<Authenticator> result = apiInstance.ListAuthenticators().ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthenticatorApi.ListAuthenticators: " + e.Message );
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

[**List&lt;Authenticator&gt;**](Authenticator.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **403** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replaceauthenticator"></a>
# **ReplaceAuthenticator**
> void ReplaceAuthenticator (string authenticatorId, Authenticator authenticator)

Replace an Authenticator

Replaces the properties for an Authenticator identified by `authenticatorId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceAuthenticatorExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthenticatorApi(config);
            var authenticatorId = aut1nd8PQhGcQtSxB0g4;  // string | `id` of the Authenticator
            var authenticator = new Authenticator(); // Authenticator | 

            try
            {
                // Replace an Authenticator
                apiInstance.ReplaceAuthenticator(authenticatorId, authenticator);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthenticatorApi.ReplaceAuthenticator: " + e.Message );
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
 **authenticatorId** | **string**| &#x60;id&#x60; of the Authenticator | 
 **authenticator** | [**Authenticator**](Authenticator.md)|  | 

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
| **200** |  |  -  |
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replaceauthenticatormethod"></a>
# **ReplaceAuthenticatorMethod**
> AuthenticatorMethodBase ReplaceAuthenticatorMethod (string authenticatorId, AuthenticatorMethodType methodType, AuthenticatorMethodBase authenticatorMethodBase = null)

Replace a Method

Replaces a Method of `methodType` for an Authenticator identified by `authenticatorId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceAuthenticatorMethodExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthenticatorApi(config);
            var authenticatorId = aut1nd8PQhGcQtSxB0g4;  // string | `id` of the Authenticator
            var methodType = (AuthenticatorMethodType) "cert";  // AuthenticatorMethodType | Type of the authenticator method
            var authenticatorMethodBase = new AuthenticatorMethodBase(); // AuthenticatorMethodBase |  (optional) 

            try
            {
                // Replace a Method
                AuthenticatorMethodBase result = apiInstance.ReplaceAuthenticatorMethod(authenticatorId, methodType, authenticatorMethodBase);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthenticatorApi.ReplaceAuthenticatorMethod: " + e.Message );
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
 **authenticatorId** | **string**| &#x60;id&#x60; of the Authenticator | 
 **methodType** | **AuthenticatorMethodType**| Type of the authenticator method | 
 **authenticatorMethodBase** | [**AuthenticatorMethodBase**](AuthenticatorMethodBase.md)|  | [optional] 

### Return type

[**AuthenticatorMethodBase**](AuthenticatorMethodBase.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

