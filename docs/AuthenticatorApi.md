# Okta.Sdk.Api.AuthenticatorApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateAuthenticator**](AuthenticatorApi.md#activateauthenticator) | **POST** /api/v1/authenticators/{authenticatorId}/lifecycle/activate | Activate an authenticator
[**ActivateAuthenticatorMethod**](AuthenticatorApi.md#activateauthenticatormethod) | **POST** /api/v1/authenticators/{authenticatorId}/methods/{methodType}/lifecycle/activate | Activate an authenticator method
[**CreateAuthenticator**](AuthenticatorApi.md#createauthenticator) | **POST** /api/v1/authenticators | Create an authenticator
[**CreateCustomAAGUID**](AuthenticatorApi.md#createcustomaaguid) | **POST** /api/v1/authenticators/{authenticatorId}/aaguids | Create a custom AAGUID
[**DeactivateAuthenticator**](AuthenticatorApi.md#deactivateauthenticator) | **POST** /api/v1/authenticators/{authenticatorId}/lifecycle/deactivate | Deactivate an authenticator
[**DeactivateAuthenticatorMethod**](AuthenticatorApi.md#deactivateauthenticatormethod) | **POST** /api/v1/authenticators/{authenticatorId}/methods/{methodType}/lifecycle/deactivate | Deactivate an authenticator method
[**DeleteCustomAAGUID**](AuthenticatorApi.md#deletecustomaaguid) | **DELETE** /api/v1/authenticators/{authenticatorId}/aaguids/{aaguid} | Delete a custom AAGUID
[**GetAuthenticator**](AuthenticatorApi.md#getauthenticator) | **GET** /api/v1/authenticators/{authenticatorId} | Retrieve an authenticator
[**GetAuthenticatorMethod**](AuthenticatorApi.md#getauthenticatormethod) | **GET** /api/v1/authenticators/{authenticatorId}/methods/{methodType} | Retrieve an authenticator method
[**GetCustomAAGUID**](AuthenticatorApi.md#getcustomaaguid) | **GET** /api/v1/authenticators/{authenticatorId}/aaguids/{aaguid} | Retrieve a custom AAGUID
[**GetWellKnownAppAuthenticatorConfiguration**](AuthenticatorApi.md#getwellknownappauthenticatorconfiguration) | **GET** /.well-known/app-authenticator-configuration | Retrieve the well-known app authenticator configuration
[**ListAllCustomAAGUIDs**](AuthenticatorApi.md#listallcustomaaguids) | **GET** /api/v1/authenticators/{authenticatorId}/aaguids | List all custom AAGUIDs
[**ListAuthenticatorMethods**](AuthenticatorApi.md#listauthenticatormethods) | **GET** /api/v1/authenticators/{authenticatorId}/methods | List all methods of an authenticator
[**ListAuthenticators**](AuthenticatorApi.md#listauthenticators) | **GET** /api/v1/authenticators | List all authenticators
[**ReplaceAuthenticator**](AuthenticatorApi.md#replaceauthenticator) | **PUT** /api/v1/authenticators/{authenticatorId} | Replace an authenticator
[**ReplaceAuthenticatorMethod**](AuthenticatorApi.md#replaceauthenticatormethod) | **PUT** /api/v1/authenticators/{authenticatorId}/methods/{methodType} | Replace an authenticator method
[**ReplaceCustomAAGUID**](AuthenticatorApi.md#replacecustomaaguid) | **PUT** /api/v1/authenticators/{authenticatorId}/aaguids/{aaguid} | Replace a custom AAGUID
[**UpdateCustomAAGUID**](AuthenticatorApi.md#updatecustomaaguid) | **PATCH** /api/v1/authenticators/{authenticatorId}/aaguids/{aaguid} | Update a custom AAGUID


<a name="activateauthenticator"></a>
# **ActivateAuthenticator**
> AuthenticatorBase ActivateAuthenticator (string authenticatorId)

Activate an authenticator

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
            var authenticatorId = aut1nd8PQhGcQtSxB0g4;  // string | `id` of the authenticator

            try
            {
                // Activate an authenticator
                AuthenticatorBase result = apiInstance.ActivateAuthenticator(authenticatorId);
                Debug.WriteLine(result);
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
 **authenticatorId** | **string**| &#x60;id&#x60; of the authenticator | 

### Return type

[**AuthenticatorBase**](AuthenticatorBase.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="activateauthenticatormethod"></a>
# **ActivateAuthenticatorMethod**
> AuthenticatorMethodBase ActivateAuthenticatorMethod (string authenticatorId, AuthenticatorMethodType methodType)

Activate an authenticator method

Activates a method for an authenticator identified by `authenticatorId` and `methodType`

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
            var authenticatorId = aut1nd8PQhGcQtSxB0g4;  // string | `id` of the authenticator
            var methodType = (AuthenticatorMethodType) "cert";  // AuthenticatorMethodType | Type of authenticator method

            try
            {
                // Activate an authenticator method
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
 **authenticatorId** | **string**| &#x60;id&#x60; of the authenticator | 
 **methodType** | **AuthenticatorMethodType**| Type of authenticator method | 

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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createauthenticator"></a>
# **CreateAuthenticator**
> AuthenticatorBase CreateAuthenticator (AuthenticatorBase authenticator, bool? activate = null)

Create an authenticator

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
            var authenticator = new AuthenticatorBase(); // AuthenticatorBase | 
            var activate = true;  // bool? | Whether to execute the activation lifecycle operation when Okta creates the authenticator (optional)  (default to true)

            try
            {
                // Create an authenticator
                AuthenticatorBase result = apiInstance.CreateAuthenticator(authenticator, activate);
                Debug.WriteLine(result);
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
 **authenticator** | [**AuthenticatorBase**](AuthenticatorBase.md)|  | 
 **activate** | **bool?**| Whether to execute the activation lifecycle operation when Okta creates the authenticator | [optional] [default to true]

### Return type

[**AuthenticatorBase**](AuthenticatorBase.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createcustomaaguid"></a>
# **CreateCustomAAGUID**
> CustomAAGUIDResponseObject CreateCustomAAGUID (string authenticatorId, CustomAAGUIDCreateRequestObject customAAGUIDCreateRequestObject = null)

Create a custom AAGUID

Creates a custom AAGUID for the WebAuthn authenticator

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateCustomAAGUIDExample
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
            var authenticatorId = aut1nd8PQhGcQtSxB0g4;  // string | `id` of the authenticator
            var customAAGUIDCreateRequestObject = new CustomAAGUIDCreateRequestObject(); // CustomAAGUIDCreateRequestObject |  (optional) 

            try
            {
                // Create a custom AAGUID
                CustomAAGUIDResponseObject result = apiInstance.CreateCustomAAGUID(authenticatorId, customAAGUIDCreateRequestObject);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthenticatorApi.CreateCustomAAGUID: " + e.Message );
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
 **authenticatorId** | **string**| &#x60;id&#x60; of the authenticator | 
 **customAAGUIDCreateRequestObject** | [**CustomAAGUIDCreateRequestObject**](CustomAAGUIDCreateRequestObject.md)|  | [optional] 

### Return type

[**CustomAAGUIDResponseObject**](CustomAAGUIDResponseObject.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivateauthenticator"></a>
# **DeactivateAuthenticator**
> AuthenticatorBase DeactivateAuthenticator (string authenticatorId)

Deactivate an authenticator

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
            var authenticatorId = aut1nd8PQhGcQtSxB0g4;  // string | `id` of the authenticator

            try
            {
                // Deactivate an authenticator
                AuthenticatorBase result = apiInstance.DeactivateAuthenticator(authenticatorId);
                Debug.WriteLine(result);
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
 **authenticatorId** | **string**| &#x60;id&#x60; of the authenticator | 

### Return type

[**AuthenticatorBase**](AuthenticatorBase.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivateauthenticatormethod"></a>
# **DeactivateAuthenticatorMethod**
> AuthenticatorMethodBase DeactivateAuthenticatorMethod (string authenticatorId, AuthenticatorMethodType methodType)

Deactivate an authenticator method

Deactivates a method for an authenticator identified by `authenticatorId` and `methodType`

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
            var authenticatorId = aut1nd8PQhGcQtSxB0g4;  // string | `id` of the authenticator
            var methodType = (AuthenticatorMethodType) "cert";  // AuthenticatorMethodType | Type of authenticator method

            try
            {
                // Deactivate an authenticator method
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
 **authenticatorId** | **string**| &#x60;id&#x60; of the authenticator | 
 **methodType** | **AuthenticatorMethodType**| Type of authenticator method | 

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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletecustomaaguid"></a>
# **DeleteCustomAAGUID**
> void DeleteCustomAAGUID (string authenticatorId, string aaguid)

Delete a custom AAGUID

Deletes a custom AAGUID  You can only delete custom AAGUIDs that an admin has created.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteCustomAAGUIDExample
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
            var authenticatorId = aut1nd8PQhGcQtSxB0g4;  // string | `id` of the authenticator
            var aaguid = cb69481e-8ff7-4039-93ec-0a272911111;  // string | Unique ID of a custom AAGUID

            try
            {
                // Delete a custom AAGUID
                apiInstance.DeleteCustomAAGUID(authenticatorId, aaguid);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthenticatorApi.DeleteCustomAAGUID: " + e.Message );
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
 **authenticatorId** | **string**| &#x60;id&#x60; of the authenticator | 
 **aaguid** | **string**| Unique ID of a custom AAGUID | 

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
| **204** | Deleted |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getauthenticator"></a>
# **GetAuthenticator**
> AuthenticatorBase GetAuthenticator (string authenticatorId)

Retrieve an authenticator

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
            var authenticatorId = aut1nd8PQhGcQtSxB0g4;  // string | `id` of the authenticator

            try
            {
                // Retrieve an authenticator
                AuthenticatorBase result = apiInstance.GetAuthenticator(authenticatorId);
                Debug.WriteLine(result);
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
 **authenticatorId** | **string**| &#x60;id&#x60; of the authenticator | 

### Return type

[**AuthenticatorBase**](AuthenticatorBase.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getauthenticatormethod"></a>
# **GetAuthenticatorMethod**
> AuthenticatorMethodBase GetAuthenticatorMethod (string authenticatorId, AuthenticatorMethodType methodType)

Retrieve an authenticator method

Retrieves a method identified by `methodType` of an authenticator identified by `authenticatorId`

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
            var authenticatorId = aut1nd8PQhGcQtSxB0g4;  // string | `id` of the authenticator
            var methodType = (AuthenticatorMethodType) "cert";  // AuthenticatorMethodType | Type of authenticator method

            try
            {
                // Retrieve an authenticator method
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
 **authenticatorId** | **string**| &#x60;id&#x60; of the authenticator | 
 **methodType** | **AuthenticatorMethodType**| Type of authenticator method | 

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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getcustomaaguid"></a>
# **GetCustomAAGUID**
> CustomAAGUIDResponseObject GetCustomAAGUID (string authenticatorId, string aaguid)

Retrieve a custom AAGUID

Retrieves a custom AAGUID

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetCustomAAGUIDExample
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
            var authenticatorId = aut1nd8PQhGcQtSxB0g4;  // string | `id` of the authenticator
            var aaguid = cb69481e-8ff7-4039-93ec-0a272911111;  // string | Unique ID of a custom AAGUID

            try
            {
                // Retrieve a custom AAGUID
                CustomAAGUIDResponseObject result = apiInstance.GetCustomAAGUID(authenticatorId, aaguid);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthenticatorApi.GetCustomAAGUID: " + e.Message );
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
 **authenticatorId** | **string**| &#x60;id&#x60; of the authenticator | 
 **aaguid** | **string**| Unique ID of a custom AAGUID | 

### Return type

[**CustomAAGUIDResponseObject**](CustomAAGUIDResponseObject.md)

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

<a name="getwellknownappauthenticatorconfiguration"></a>
# **GetWellKnownAppAuthenticatorConfiguration**
> List&lt;WellKnownAppAuthenticatorConfiguration&gt; GetWellKnownAppAuthenticatorConfiguration (string oauthClientId)

Retrieve the well-known app authenticator configuration

Retrieves the well-known app authenticator configuration. Includes an app authenticator's settings, supported methods, and other details.

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
                // Retrieve the well-known app authenticator configuration
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

<a name="listallcustomaaguids"></a>
# **ListAllCustomAAGUIDs**
> List&lt;CustomAAGUIDResponseObject&gt; ListAllCustomAAGUIDs (string authenticatorId)

List all custom AAGUIDs

Lists all custom Authenticator Attestation Global Unique Identifiers (AAGUIDs) in the org  Only custom AAGUIDs that an admin has created are returned.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListAllCustomAAGUIDsExample
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
            var authenticatorId = aut1nd8PQhGcQtSxB0g4;  // string | `id` of the authenticator

            try
            {
                // List all custom AAGUIDs
                List<CustomAAGUIDResponseObject> result = apiInstance.ListAllCustomAAGUIDs(authenticatorId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthenticatorApi.ListAllCustomAAGUIDs: " + e.Message );
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
 **authenticatorId** | **string**| &#x60;id&#x60; of the authenticator | 

### Return type

[**List&lt;CustomAAGUIDResponseObject&gt;**](CustomAAGUIDResponseObject.md)

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

<a name="listauthenticatormethods"></a>
# **ListAuthenticatorMethods**
> List&lt;AuthenticatorMethodBase&gt; ListAuthenticatorMethods (string authenticatorId)

List all methods of an authenticator

Lists all methods of an authenticator identified by `authenticatorId`

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
            var authenticatorId = aut1nd8PQhGcQtSxB0g4;  // string | `id` of the authenticator

            try
            {
                // List all methods of an authenticator
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
 **authenticatorId** | **string**| &#x60;id&#x60; of the authenticator | 

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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listauthenticators"></a>
# **ListAuthenticators**
> List&lt;AuthenticatorBase&gt; ListAuthenticators ()

List all authenticators

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
                // List all authenticators
                List<AuthenticatorBase> result = apiInstance.ListAuthenticators().ToListAsync();
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

[**List&lt;AuthenticatorBase&gt;**](AuthenticatorBase.md)

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

<a name="replaceauthenticator"></a>
# **ReplaceAuthenticator**
> AuthenticatorBase ReplaceAuthenticator (string authenticatorId, AuthenticatorBase authenticator)

Replace an authenticator

Replaces the properties for an authenticator identified by `authenticatorId`

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
            var authenticatorId = aut1nd8PQhGcQtSxB0g4;  // string | `id` of the authenticator
            var authenticator = new AuthenticatorBase(); // AuthenticatorBase | 

            try
            {
                // Replace an authenticator
                AuthenticatorBase result = apiInstance.ReplaceAuthenticator(authenticatorId, authenticator);
                Debug.WriteLine(result);
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
 **authenticatorId** | **string**| &#x60;id&#x60; of the authenticator | 
 **authenticator** | [**AuthenticatorBase**](AuthenticatorBase.md)|  | 

### Return type

[**AuthenticatorBase**](AuthenticatorBase.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replaceauthenticatormethod"></a>
# **ReplaceAuthenticatorMethod**
> AuthenticatorMethodBase ReplaceAuthenticatorMethod (string authenticatorId, AuthenticatorMethodType methodType, AuthenticatorMethodBase authenticatorMethodBase = null)

Replace an authenticator method

Replaces a method of `methodType` for an authenticator identified by `authenticatorId`

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
            var authenticatorId = aut1nd8PQhGcQtSxB0g4;  // string | `id` of the authenticator
            var methodType = (AuthenticatorMethodType) "cert";  // AuthenticatorMethodType | Type of authenticator method
            var authenticatorMethodBase = new AuthenticatorMethodBase(); // AuthenticatorMethodBase |  (optional) 

            try
            {
                // Replace an authenticator method
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
 **authenticatorId** | **string**| &#x60;id&#x60; of the authenticator | 
 **methodType** | **AuthenticatorMethodType**| Type of authenticator method | 
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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacecustomaaguid"></a>
# **ReplaceCustomAAGUID**
> CustomAAGUIDResponseObject ReplaceCustomAAGUID (string authenticatorId, string aaguid, CustomAAGUIDUpdateRequestObject customAAGUIDUpdateRequestObject = null)

Replace a custom AAGUID

Replaces a custom AAGUID for the specified WebAuthn authenticator

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceCustomAAGUIDExample
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
            var authenticatorId = aut1nd8PQhGcQtSxB0g4;  // string | `id` of the authenticator
            var aaguid = cb69481e-8ff7-4039-93ec-0a272911111;  // string | Unique ID of a custom AAGUID
            var customAAGUIDUpdateRequestObject = new CustomAAGUIDUpdateRequestObject(); // CustomAAGUIDUpdateRequestObject |  (optional) 

            try
            {
                // Replace a custom AAGUID
                CustomAAGUIDResponseObject result = apiInstance.ReplaceCustomAAGUID(authenticatorId, aaguid, customAAGUIDUpdateRequestObject);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthenticatorApi.ReplaceCustomAAGUID: " + e.Message );
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
 **authenticatorId** | **string**| &#x60;id&#x60; of the authenticator | 
 **aaguid** | **string**| Unique ID of a custom AAGUID | 
 **customAAGUIDUpdateRequestObject** | [**CustomAAGUIDUpdateRequestObject**](CustomAAGUIDUpdateRequestObject.md)|  | [optional] 

### Return type

[**CustomAAGUIDResponseObject**](CustomAAGUIDResponseObject.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatecustomaaguid"></a>
# **UpdateCustomAAGUID**
> CustomAAGUIDResponseObject UpdateCustomAAGUID (string authenticatorId, string aaguid, CustomAAGUIDUpdateRequestObject customAAGUIDUpdateRequestObject = null)

Update a custom AAGUID

Updates the properties of a custom AAGUID by the `authenticatorId` and `aaguid` ID

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateCustomAAGUIDExample
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
            var authenticatorId = aut1nd8PQhGcQtSxB0g4;  // string | `id` of the authenticator
            var aaguid = cb69481e-8ff7-4039-93ec-0a272911111;  // string | Unique ID of a custom AAGUID
            var customAAGUIDUpdateRequestObject = new CustomAAGUIDUpdateRequestObject(); // CustomAAGUIDUpdateRequestObject |  (optional) 

            try
            {
                // Update a custom AAGUID
                CustomAAGUIDResponseObject result = apiInstance.UpdateCustomAAGUID(authenticatorId, aaguid, customAAGUIDUpdateRequestObject);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthenticatorApi.UpdateCustomAAGUID: " + e.Message );
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
 **authenticatorId** | **string**| &#x60;id&#x60; of the authenticator | 
 **aaguid** | **string**| Unique ID of a custom AAGUID | 
 **customAAGUIDUpdateRequestObject** | [**CustomAAGUIDUpdateRequestObject**](CustomAAGUIDUpdateRequestObject.md)|  | [optional] 

### Return type

[**CustomAAGUIDResponseObject**](CustomAAGUIDResponseObject.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/merge-patch+json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

