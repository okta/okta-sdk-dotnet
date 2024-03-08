# Okta.Sdk.Api.ApplicationConnectionsApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateDefaultProvisioningConnectionForApplication**](ApplicationConnectionsApi.md#activatedefaultprovisioningconnectionforapplication) | **POST** /api/v1/apps/{appId}/connections/default/lifecycle/activate | Activate the default Provisioning Connection
[**DeactivateDefaultProvisioningConnectionForApplication**](ApplicationConnectionsApi.md#deactivatedefaultprovisioningconnectionforapplication) | **POST** /api/v1/apps/{appId}/connections/default/lifecycle/deactivate | Deactivate the default Provisioning Connection
[**GetDefaultProvisioningConnectionForApplication**](ApplicationConnectionsApi.md#getdefaultprovisioningconnectionforapplication) | **GET** /api/v1/apps/{appId}/connections/default | Retrieve the default Provisioning Connection
[**UpdateDefaultProvisioningConnectionForApplication**](ApplicationConnectionsApi.md#updatedefaultprovisioningconnectionforapplication) | **POST** /api/v1/apps/{appId}/connections/default | Update the default Provisioning Connection
[**VerifyProvisioningConnectionForApplication**](ApplicationConnectionsApi.md#verifyprovisioningconnectionforapplication) | **POST** /api/v1/apps/{appName}/{appId}/oauth2/callback | Verify the Provisioning Connection
[**VerifyProvisioningConnectionForGoogleApplication**](ApplicationConnectionsApi.md#verifyprovisioningconnectionforgoogleapplication) | **POST** /api/v1/apps/google/{appId}/oauth2/callback | Verify the Provisioning Connection for Google Workspace
[**VerifyProvisioningConnectionForOfficeApplication**](ApplicationConnectionsApi.md#verifyprovisioningconnectionforofficeapplication) | **POST** /api/v1/apps/office365/{appId}/oauth2/callback | Verify the Provisioning Connection for Microsoft Office 365


<a name="activatedefaultprovisioningconnectionforapplication"></a>
# **ActivateDefaultProvisioningConnectionForApplication**
> void ActivateDefaultProvisioningConnectionForApplication (string appId)

Activate the default Provisioning Connection

Activates the default Provisioning Connection for an app

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateDefaultProvisioningConnectionForApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationConnectionsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application

            try
            {
                // Activate the default Provisioning Connection
                apiInstance.ActivateDefaultProvisioningConnectionForApplication(appId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationConnectionsApi.ActivateDefaultProvisioningConnectionForApplication: " + e.Message );
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

void (empty response body)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivatedefaultprovisioningconnectionforapplication"></a>
# **DeactivateDefaultProvisioningConnectionForApplication**
> void DeactivateDefaultProvisioningConnectionForApplication (string appId)

Deactivate the default Provisioning Connection

Deactivates the default Provisioning Connection for an app

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateDefaultProvisioningConnectionForApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationConnectionsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application

            try
            {
                // Deactivate the default Provisioning Connection
                apiInstance.DeactivateDefaultProvisioningConnectionForApplication(appId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationConnectionsApi.DeactivateDefaultProvisioningConnectionForApplication: " + e.Message );
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

void (empty response body)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getdefaultprovisioningconnectionforapplication"></a>
# **GetDefaultProvisioningConnectionForApplication**
> ProvisioningConnectionResponse GetDefaultProvisioningConnectionForApplication (string appId)

Retrieve the default Provisioning Connection

Retrieves the default Provisioning Connection for an app

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetDefaultProvisioningConnectionForApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationConnectionsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application

            try
            {
                // Retrieve the default Provisioning Connection
                ProvisioningConnectionResponse result = apiInstance.GetDefaultProvisioningConnectionForApplication(appId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationConnectionsApi.GetDefaultProvisioningConnectionForApplication: " + e.Message );
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

[**ProvisioningConnectionResponse**](ProvisioningConnectionResponse.md)

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

<a name="updatedefaultprovisioningconnectionforapplication"></a>
# **UpdateDefaultProvisioningConnectionForApplication**
> ProvisioningConnectionUnknownResponse UpdateDefaultProvisioningConnectionForApplication (string appId, ProvisioningConnectionRequest provisioningConnectionRequest, bool? activate = null)

Update the default Provisioning Connection

Updates the default Provisioning Connection for an app

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateDefaultProvisioningConnectionForApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationConnectionsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application
            var provisioningConnectionRequest = new ProvisioningConnectionRequest(); // ProvisioningConnectionRequest | 
            var activate = true;  // bool? | Activates the Provisioning Connection (optional) 

            try
            {
                // Update the default Provisioning Connection
                ProvisioningConnectionUnknownResponse result = apiInstance.UpdateDefaultProvisioningConnectionForApplication(appId, provisioningConnectionRequest, activate);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationConnectionsApi.UpdateDefaultProvisioningConnectionForApplication: " + e.Message );
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
 **provisioningConnectionRequest** | [**ProvisioningConnectionRequest**](ProvisioningConnectionRequest.md)|  | 
 **activate** | **bool?**| Activates the Provisioning Connection | [optional] 

### Return type

[**ProvisioningConnectionUnknownResponse**](ProvisioningConnectionUnknownResponse.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **201** | Created |  -  |
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="verifyprovisioningconnectionforapplication"></a>
# **VerifyProvisioningConnectionForApplication**
> void VerifyProvisioningConnectionForApplication (OAuthProvisioningEnabledApp appName, string appId, string code = null, string state = null)

Verify the Provisioning Connection

Verifies the OAuth 2.0-based connection as part of the OAuth 2.0 consent flow. The validation of the consent flow is the last step of the provisioning setup for an OAuth 2.0-based connection. Currently, this operation only supports `office365`,`google`, `zoomus`, and `slack` apps. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class VerifyProvisioningConnectionForApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationConnectionsApi(config);
            var appName = (OAuthProvisioningEnabledApp) "google";  // OAuthProvisioningEnabledApp | 
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application
            var code = "code_example";  // string |  (optional) 
            var state = "state_example";  // string |  (optional) 

            try
            {
                // Verify the Provisioning Connection
                apiInstance.VerifyProvisioningConnectionForApplication(appName, appId, code, state);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationConnectionsApi.VerifyProvisioningConnectionForApplication: " + e.Message );
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
 **appName** | **OAuthProvisioningEnabledApp**|  | 
 **appId** | **string**| ID of the Application | 
 **code** | **string**|  | [optional] 
 **state** | **string**|  | [optional] 

### Return type

void (empty response body)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No content |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="verifyprovisioningconnectionforgoogleapplication"></a>
# **VerifyProvisioningConnectionForGoogleApplication**
> void VerifyProvisioningConnectionForGoogleApplication (string appId, string code = null, string state = null)

Verify the Provisioning Connection for Google Workspace

Verifies the OAuth 2.0-based connection as part of the OAuth 2.0 consent flow. The validation of the consent flow is the last step of the provisioning setup for the Google Workspace (`google`) OAuth 2.0-based connection. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class VerifyProvisioningConnectionForGoogleApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationConnectionsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application
            var code = "code_example";  // string |  (optional) 
            var state = "state_example";  // string |  (optional) 

            try
            {
                // Verify the Provisioning Connection for Google Workspace
                apiInstance.VerifyProvisioningConnectionForGoogleApplication(appId, code, state);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationConnectionsApi.VerifyProvisioningConnectionForGoogleApplication: " + e.Message );
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
 **code** | **string**|  | [optional] 
 **state** | **string**|  | [optional] 

### Return type

void (empty response body)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No content |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="verifyprovisioningconnectionforofficeapplication"></a>
# **VerifyProvisioningConnectionForOfficeApplication**
> void VerifyProvisioningConnectionForOfficeApplication (string appId, string code = null, string state = null)

Verify the Provisioning Connection for Microsoft Office 365

Verifies the OAuth 2.0-based connection as part of the OAuth 2.0 consent flow. The validation of the consent flow is the last step of the provisioning setup for the Microsoft Office 365 (`office365`) OAuth 2.0-based connection. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class VerifyProvisioningConnectionForOfficeApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationConnectionsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application
            var code = "code_example";  // string |  (optional) 
            var state = "state_example";  // string |  (optional) 

            try
            {
                // Verify the Provisioning Connection for Microsoft Office 365
                apiInstance.VerifyProvisioningConnectionForOfficeApplication(appId, code, state);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationConnectionsApi.VerifyProvisioningConnectionForOfficeApplication: " + e.Message );
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
 **code** | **string**|  | [optional] 
 **state** | **string**|  | [optional] 

### Return type

void (empty response body)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No content |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

