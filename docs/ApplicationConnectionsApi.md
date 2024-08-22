# Okta.Sdk.Api.ApplicationConnectionsApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateDefaultProvisioningConnectionForApplication**](ApplicationConnectionsApi.md#activatedefaultprovisioningconnectionforapplication) | **POST** /api/v1/apps/{appId}/connections/default/lifecycle/activate | Activate the default Provisioning Connection
[**DeactivateDefaultProvisioningConnectionForApplication**](ApplicationConnectionsApi.md#deactivatedefaultprovisioningconnectionforapplication) | **POST** /api/v1/apps/{appId}/connections/default/lifecycle/deactivate | Deactivate the default Provisioning Connection
[**GetDefaultProvisioningConnectionForApplication**](ApplicationConnectionsApi.md#getdefaultprovisioningconnectionforapplication) | **GET** /api/v1/apps/{appId}/connections/default | Retrieve the default Provisioning Connection
[**UpdateDefaultProvisioningConnectionForApplication**](ApplicationConnectionsApi.md#updatedefaultprovisioningconnectionforapplication) | **POST** /api/v1/apps/{appId}/connections/default | Update the default Provisioning Connection
[**VerifyProvisioningConnectionForApplication**](ApplicationConnectionsApi.md#verifyprovisioningconnectionforapplication) | **POST** /api/v1/apps/{appName}/{appId}/oauth2/callback | Verify the Provisioning Connection


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
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID

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
 **appId** | **string**| Application ID | 

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
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID

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
 **appId** | **string**| Application ID | 

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
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID

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
 **appId** | **string**| Application ID | 

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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatedefaultprovisioningconnectionforapplication"></a>
# **UpdateDefaultProvisioningConnectionForApplication**
> ProvisioningConnectionResponse UpdateDefaultProvisioningConnectionForApplication (string appId, UpdateDefaultProvisioningConnectionForApplicationRequest updateDefaultProvisioningConnectionForApplicationRequest, bool? activate = null)

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
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var updateDefaultProvisioningConnectionForApplicationRequest = new UpdateDefaultProvisioningConnectionForApplicationRequest(); // UpdateDefaultProvisioningConnectionForApplicationRequest | 
            var activate = true;  // bool? | Activates the Provisioning Connection (optional) 

            try
            {
                // Update the default Provisioning Connection
                ProvisioningConnectionResponse result = apiInstance.UpdateDefaultProvisioningConnectionForApplication(appId, updateDefaultProvisioningConnectionForApplicationRequest, activate);
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
 **appId** | **string**| Application ID | 
 **updateDefaultProvisioningConnectionForApplicationRequest** | [**UpdateDefaultProvisioningConnectionForApplicationRequest**](UpdateDefaultProvisioningConnectionForApplicationRequest.md)|  | 
 **activate** | **bool?**| Activates the Provisioning Connection | [optional] 

### Return type

[**ProvisioningConnectionResponse**](ProvisioningConnectionResponse.md)

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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

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
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
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
 **appId** | **string**| Application ID | 
 **code** | **string**|  | [optional] 
 **state** | **string**|  | [optional] 

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
| **204** | No content |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

