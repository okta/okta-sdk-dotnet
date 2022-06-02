# Okta.Sdk.Api.ApplicationApi

All URIs are relative to *https://your-subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateApplication**](ApplicationApi.md#activateapplication) | **POST** /api/v1/apps/{appId}/lifecycle/activate | Activate Application
[**ActivateDefaultProvisioningConnectionForApplication**](ApplicationApi.md#activatedefaultprovisioningconnectionforapplication) | **POST** /api/v1/apps/{appId}/connections/default/lifecycle/activate | Activate default Provisioning Connection for application
[**AssignUserToApplication**](ApplicationApi.md#assignusertoapplication) | **POST** /api/v1/apps/{appId}/users | Assign User to Application for SSO &amp; Provisioning
[**CloneApplicationKey**](ApplicationApi.md#cloneapplicationkey) | **POST** /api/v1/apps/{appId}/credentials/keys/{keyId}/clone | Clone Application Key Credential
[**CreateApplication**](ApplicationApi.md#createapplication) | **POST** /api/v1/apps | Add Application
[**CreateApplicationGroupAssignment**](ApplicationApi.md#createapplicationgroupassignment) | **PUT** /api/v1/apps/{appId}/groups/{groupId} | Assign Group to Application
[**DeactivateApplication**](ApplicationApi.md#deactivateapplication) | **POST** /api/v1/apps/{appId}/lifecycle/deactivate | Deactivate Application
[**DeactivateDefaultProvisioningConnectionForApplication**](ApplicationApi.md#deactivatedefaultprovisioningconnectionforapplication) | **POST** /api/v1/apps/{appId}/connections/default/lifecycle/deactivate | Deactivate default Provisioning Connection for application
[**DeleteApplication**](ApplicationApi.md#deleteapplication) | **DELETE** /api/v1/apps/{appId} | Delete Application
[**DeleteApplicationGroupAssignment**](ApplicationApi.md#deleteapplicationgroupassignment) | **DELETE** /api/v1/apps/{appId}/groups/{groupId} | Remove Group from Application
[**DeleteApplicationUser**](ApplicationApi.md#deleteapplicationuser) | **DELETE** /api/v1/apps/{appId}/users/{userId} | Remove User from Application
[**GenerateApplicationKey**](ApplicationApi.md#generateapplicationkey) | **POST** /api/v1/apps/{appId}/credentials/keys/generate | Generate Key Credential for Application
[**GenerateCsrForApplication**](ApplicationApi.md#generatecsrforapplication) | **POST** /api/v1/apps/{appId}/credentials/csrs | Generate Certificate Signing Request for Application
[**GetApplication**](ApplicationApi.md#getapplication) | **GET** /api/v1/apps/{appId} | Get Application
[**GetApplicationGroupAssignment**](ApplicationApi.md#getapplicationgroupassignment) | **GET** /api/v1/apps/{appId}/groups/{groupId} | Get Assigned Group for Application
[**GetApplicationKey**](ApplicationApi.md#getapplicationkey) | **GET** /api/v1/apps/{appId}/credentials/keys/{keyId} | Get Key Credential for Application
[**GetApplicationUser**](ApplicationApi.md#getapplicationuser) | **GET** /api/v1/apps/{appId}/users/{userId} | Get Assigned User for Application
[**GetCsrForApplication**](ApplicationApi.md#getcsrforapplication) | **GET** /api/v1/apps/{appId}/credentials/csrs/{csrId} | Get Certificate Signing Request
[**GetDefaultProvisioningConnectionForApplication**](ApplicationApi.md#getdefaultprovisioningconnectionforapplication) | **GET** /api/v1/apps/{appId}/connections/default | Fetches the default Provisioning Connection for an application.
[**GetFeatureForApplication**](ApplicationApi.md#getfeatureforapplication) | **GET** /api/v1/apps/{appId}/features/{name} | Fetches a Feature object for an application.
[**GetOAuth2TokenForApplication**](ApplicationApi.md#getoauth2tokenforapplication) | **GET** /api/v1/apps/{appId}/tokens/{tokenId} | Get OAuth 2.0 Token for Application
[**GetScopeConsentGrant**](ApplicationApi.md#getscopeconsentgrant) | **GET** /api/v1/apps/{appId}/grants/{grantId} | Get Scope Consent Grant for Application
[**GrantConsentToScope**](ApplicationApi.md#grantconsenttoscope) | **POST** /api/v1/apps/{appId}/grants | Grant Consent to Scope for Application
[**ListApplicationGroupAssignments**](ApplicationApi.md#listapplicationgroupassignments) | **GET** /api/v1/apps/{appId}/groups | List Groups Assigned to Application
[**ListApplicationKeys**](ApplicationApi.md#listapplicationkeys) | **GET** /api/v1/apps/{appId}/credentials/keys | List Key Credentials for Application
[**ListApplicationUsers**](ApplicationApi.md#listapplicationusers) | **GET** /api/v1/apps/{appId}/users | List Users Assigned to Application
[**ListApplications**](ApplicationApi.md#listapplications) | **GET** /api/v1/apps | List Applications
[**ListCsrsForApplication**](ApplicationApi.md#listcsrsforapplication) | **GET** /api/v1/apps/{appId}/credentials/csrs | List Certificate Signing Requests for Application
[**ListFeaturesForApplication**](ApplicationApi.md#listfeaturesforapplication) | **GET** /api/v1/apps/{appId}/features | Fetches the Feature objects for an application.
[**ListOAuth2TokensForApplication**](ApplicationApi.md#listoauth2tokensforapplication) | **GET** /api/v1/apps/{appId}/tokens | Lists OAuth 2.0 Tokens for Application
[**ListScopeConsentGrants**](ApplicationApi.md#listscopeconsentgrants) | **GET** /api/v1/apps/{appId}/grants | List Scope Consent Grants for Application
[**PublishCsrFromApplication**](ApplicationApi.md#publishcsrfromapplication) | **POST** /api/v1/apps/{appId}/credentials/csrs/{csrId}/lifecycle/publish | Publish Certificate Signing Request
[**RevokeCsrFromApplication**](ApplicationApi.md#revokecsrfromapplication) | **DELETE** /api/v1/apps/{appId}/credentials/csrs/{csrId} | Revoke Certificate Signing Request
[**RevokeOAuth2TokenForApplication**](ApplicationApi.md#revokeoauth2tokenforapplication) | **DELETE** /api/v1/apps/{appId}/tokens/{tokenId} | Revoke an OAuth 2.0 Token for Application
[**RevokeOAuth2TokensForApplication**](ApplicationApi.md#revokeoauth2tokensforapplication) | **DELETE** /api/v1/apps/{appId}/tokens | Revoke All OAuth 2.0 Tokens for Application
[**RevokeScopeConsentGrant**](ApplicationApi.md#revokescopeconsentgrant) | **DELETE** /api/v1/apps/{appId}/grants/{grantId} | Revoke Scope Consent Grant for Application
[**SetDefaultProvisioningConnectionForApplication**](ApplicationApi.md#setdefaultprovisioningconnectionforapplication) | **POST** /api/v1/apps/{appId}/connections/default | Sets the default Provisioning Connection for an application.
[**UpdateApplication**](ApplicationApi.md#updateapplication) | **PUT** /api/v1/apps/{appId} | Update Application
[**UpdateApplicationUser**](ApplicationApi.md#updateapplicationuser) | **POST** /api/v1/apps/{appId}/users/{userId} | Update Application Profile for Assigned User
[**UpdateFeatureForApplication**](ApplicationApi.md#updatefeatureforapplication) | **PUT** /api/v1/apps/{appId}/features/{name} | Updates a Feature object for an application.


<a name="activateapplication"></a>
# **ActivateApplication**
> void ActivateApplication (string appId)

Activate Application

Activates an inactive application.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 

            try
            {
                // Activate Application
                apiInstance.ActivateApplication(appId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.ActivateApplication: " + e.Message );
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
 **appId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="activatedefaultprovisioningconnectionforapplication"></a>
# **ActivateDefaultProvisioningConnectionForApplication**
> void ActivateDefaultProvisioningConnectionForApplication (string appId)

Activate default Provisioning Connection for application

Activates the default Provisioning Connection for an application.

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
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 

            try
            {
                // Activate default Provisioning Connection for application
                apiInstance.ActivateDefaultProvisioningConnectionForApplication(appId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.ActivateDefaultProvisioningConnectionForApplication: " + e.Message );
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
 **appId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="assignusertoapplication"></a>
# **AssignUserToApplication**
> AppUser AssignUserToApplication (string appId, AppUser appUser)

Assign User to Application for SSO & Provisioning

Assigns an user to an application with [credentials](#application-user-credentials-object) and an app-specific [profile](#application-user-profile-object). Profile mappings defined for the application are first applied before applying any profile properties specified in the request.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AssignUserToApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var appUser = new AppUser(); // AppUser | 

            try
            {
                // Assign User to Application for SSO & Provisioning
                AppUser result = apiInstance.AssignUserToApplication(appId, appUser);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.AssignUserToApplication: " + e.Message );
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
 **appId** | **string**|  | 
 **appUser** | [**AppUser**](AppUser.md)|  | 

### Return type

[**AppUser**](AppUser.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="cloneapplicationkey"></a>
# **CloneApplicationKey**
> JsonWebKey CloneApplicationKey (string appId, string keyId, string targetAid)

Clone Application Key Credential

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
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var keyId = "keyId_example";  // string | 
            var targetAid = "targetAid_example";  // string | Unique key of the target Application

            try
            {
                // Clone Application Key Credential
                JsonWebKey result = apiInstance.CloneApplicationKey(appId, keyId, targetAid);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.CloneApplicationKey: " + e.Message );
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
 **appId** | **string**|  | 
 **keyId** | **string**|  | 
 **targetAid** | **string**| Unique key of the target Application | 

### Return type

[**JsonWebKey**](JsonWebKey.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createapplication"></a>
# **CreateApplication**
> Application CreateApplication (Application application, bool? activate = null, string oktaAccessGatewayAgent = null)

Add Application

Adds a new application to your Okta organization.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var application = new Application(); // Application | 
            var activate = true;  // bool? | Executes activation lifecycle operation when creating the app (optional)  (default to true)
            var oktaAccessGatewayAgent = "oktaAccessGatewayAgent_example";  // string |  (optional) 

            try
            {
                // Add Application
                Application result = apiInstance.CreateApplication(application, activate, oktaAccessGatewayAgent);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.CreateApplication: " + e.Message );
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
 **application** | [**Application**](Application.md)|  | 
 **activate** | **bool?**| Executes activation lifecycle operation when creating the app | [optional] [default to true]
 **oktaAccessGatewayAgent** | **string**|  | [optional] 

### Return type

[**Application**](Application.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createapplicationgroupassignment"></a>
# **CreateApplicationGroupAssignment**
> ApplicationGroupAssignment CreateApplicationGroupAssignment (string appId, string groupId, ApplicationGroupAssignment applicationGroupAssignment)

Assign Group to Application

Assigns a group to an application

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateApplicationGroupAssignmentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var groupId = "groupId_example";  // string | 
            var applicationGroupAssignment = new ApplicationGroupAssignment(); // ApplicationGroupAssignment | 

            try
            {
                // Assign Group to Application
                ApplicationGroupAssignment result = apiInstance.CreateApplicationGroupAssignment(appId, groupId, applicationGroupAssignment);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.CreateApplicationGroupAssignment: " + e.Message );
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
 **appId** | **string**|  | 
 **groupId** | **string**|  | 
 **applicationGroupAssignment** | [**ApplicationGroupAssignment**](ApplicationGroupAssignment.md)|  | 

### Return type

[**ApplicationGroupAssignment**](ApplicationGroupAssignment.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivateapplication"></a>
# **DeactivateApplication**
> void DeactivateApplication (string appId)

Deactivate Application

Deactivates an active application.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 

            try
            {
                // Deactivate Application
                apiInstance.DeactivateApplication(appId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.DeactivateApplication: " + e.Message );
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
 **appId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivatedefaultprovisioningconnectionforapplication"></a>
# **DeactivateDefaultProvisioningConnectionForApplication**
> void DeactivateDefaultProvisioningConnectionForApplication (string appId)

Deactivate default Provisioning Connection for application

Deactivates the default Provisioning Connection for an application.

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
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 

            try
            {
                // Deactivate default Provisioning Connection for application
                apiInstance.DeactivateDefaultProvisioningConnectionForApplication(appId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.DeactivateDefaultProvisioningConnectionForApplication: " + e.Message );
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
 **appId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteapplication"></a>
# **DeleteApplication**
> void DeleteApplication (string appId)

Delete Application

Removes an inactive application.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 

            try
            {
                // Delete Application
                apiInstance.DeleteApplication(appId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.DeleteApplication: " + e.Message );
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
 **appId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteapplicationgroupassignment"></a>
# **DeleteApplicationGroupAssignment**
> void DeleteApplicationGroupAssignment (string appId, string groupId)

Remove Group from Application

Removes a group assignment from an application.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteApplicationGroupAssignmentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var groupId = "groupId_example";  // string | 

            try
            {
                // Remove Group from Application
                apiInstance.DeleteApplicationGroupAssignment(appId, groupId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.DeleteApplicationGroupAssignment: " + e.Message );
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
 **appId** | **string**|  | 
 **groupId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteapplicationuser"></a>
# **DeleteApplicationUser**
> void DeleteApplicationUser (string appId, string userId, bool? sendEmail = null)

Remove User from Application

Removes an assignment for a user from an application.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteApplicationUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var userId = "userId_example";  // string | 
            var sendEmail = false;  // bool? |  (optional)  (default to false)

            try
            {
                // Remove User from Application
                apiInstance.DeleteApplicationUser(appId, userId, sendEmail);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.DeleteApplicationUser: " + e.Message );
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
 **appId** | **string**|  | 
 **userId** | **string**|  | 
 **sendEmail** | **bool?**|  | [optional] [default to false]

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="generateapplicationkey"></a>
# **GenerateApplicationKey**
> JsonWebKey GenerateApplicationKey (string appId, int? validityYears = null)

Generate Key Credential for Application

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
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var validityYears = 56;  // int? |  (optional) 

            try
            {
                // Generate Key Credential for Application
                JsonWebKey result = apiInstance.GenerateApplicationKey(appId, validityYears);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.GenerateApplicationKey: " + e.Message );
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
 **appId** | **string**|  | 
 **validityYears** | **int?**|  | [optional] 

### Return type

[**JsonWebKey**](JsonWebKey.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="generatecsrforapplication"></a>
# **GenerateCsrForApplication**
> Csr GenerateCsrForApplication (string appId, CsrMetadata metadata)

Generate Certificate Signing Request for Application

Generates a new key pair and returns the Certificate Signing Request for it.

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
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var metadata = new CsrMetadata(); // CsrMetadata | 

            try
            {
                // Generate Certificate Signing Request for Application
                Csr result = apiInstance.GenerateCsrForApplication(appId, metadata);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.GenerateCsrForApplication: " + e.Message );
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
 **appId** | **string**|  | 
 **metadata** | [**CsrMetadata**](CsrMetadata.md)|  | 

### Return type

[**Csr**](Csr.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getapplication"></a>
# **GetApplication**
> Application GetApplication (string appId, string expand = null)

Get Application

Fetches an application from your Okta organization by `id`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var expand = "expand_example";  // string |  (optional) 

            try
            {
                // Get Application
                Application result = apiInstance.GetApplication(appId, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.GetApplication: " + e.Message );
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
 **appId** | **string**|  | 
 **expand** | **string**|  | [optional] 

### Return type

[**Application**](Application.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getapplicationgroupassignment"></a>
# **GetApplicationGroupAssignment**
> ApplicationGroupAssignment GetApplicationGroupAssignment (string appId, string groupId, string expand = null)

Get Assigned Group for Application

Fetches an application group assignment

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetApplicationGroupAssignmentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var groupId = "groupId_example";  // string | 
            var expand = "expand_example";  // string |  (optional) 

            try
            {
                // Get Assigned Group for Application
                ApplicationGroupAssignment result = apiInstance.GetApplicationGroupAssignment(appId, groupId, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.GetApplicationGroupAssignment: " + e.Message );
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
 **appId** | **string**|  | 
 **groupId** | **string**|  | 
 **expand** | **string**|  | [optional] 

### Return type

[**ApplicationGroupAssignment**](ApplicationGroupAssignment.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getapplicationkey"></a>
# **GetApplicationKey**
> JsonWebKey GetApplicationKey (string appId, string keyId)

Get Key Credential for Application

Gets a specific application key credential by kid

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
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var keyId = "keyId_example";  // string | 

            try
            {
                // Get Key Credential for Application
                JsonWebKey result = apiInstance.GetApplicationKey(appId, keyId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.GetApplicationKey: " + e.Message );
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
 **appId** | **string**|  | 
 **keyId** | **string**|  | 

### Return type

[**JsonWebKey**](JsonWebKey.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getapplicationuser"></a>
# **GetApplicationUser**
> AppUser GetApplicationUser (string appId, string userId, string expand = null)

Get Assigned User for Application

Fetches a specific user assignment for application by `id`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetApplicationUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var userId = "userId_example";  // string | 
            var expand = "expand_example";  // string |  (optional) 

            try
            {
                // Get Assigned User for Application
                AppUser result = apiInstance.GetApplicationUser(appId, userId, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.GetApplicationUser: " + e.Message );
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
 **appId** | **string**|  | 
 **userId** | **string**|  | 
 **expand** | **string**|  | [optional] 

### Return type

[**AppUser**](AppUser.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getcsrforapplication"></a>
# **GetCsrForApplication**
> Csr GetCsrForApplication (string appId, string csrId)

Get Certificate Signing Request

Fetches a certificate signing request for the app by `id`.

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
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var csrId = "csrId_example";  // string | 

            try
            {
                // Get Certificate Signing Request
                Csr result = apiInstance.GetCsrForApplication(appId, csrId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.GetCsrForApplication: " + e.Message );
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
 **appId** | **string**|  | 
 **csrId** | **string**|  | 

### Return type

[**Csr**](Csr.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getdefaultprovisioningconnectionforapplication"></a>
# **GetDefaultProvisioningConnectionForApplication**
> ProvisioningConnection GetDefaultProvisioningConnectionForApplication (string appId)

Fetches the default Provisioning Connection for an application.

Get default Provisioning Connection for application

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
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 

            try
            {
                // Fetches the default Provisioning Connection for an application.
                ProvisioningConnection result = apiInstance.GetDefaultProvisioningConnectionForApplication(appId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.GetDefaultProvisioningConnectionForApplication: " + e.Message );
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
 **appId** | **string**|  | 

### Return type

[**ProvisioningConnection**](ProvisioningConnection.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getfeatureforapplication"></a>
# **GetFeatureForApplication**
> ApplicationFeature GetFeatureForApplication (string appId, string name)

Fetches a Feature object for an application.

Fetches a Feature object for an application.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetFeatureForApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var name = "name_example";  // string | 

            try
            {
                // Fetches a Feature object for an application.
                ApplicationFeature result = apiInstance.GetFeatureForApplication(appId, name);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.GetFeatureForApplication: " + e.Message );
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
 **appId** | **string**|  | 
 **name** | **string**|  | 

### Return type

[**ApplicationFeature**](ApplicationFeature.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getoauth2tokenforapplication"></a>
# **GetOAuth2TokenForApplication**
> OAuth2Token GetOAuth2TokenForApplication (string appId, string tokenId, string expand = null)

Get OAuth 2.0 Token for Application

Gets a token for the specified application

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetOAuth2TokenForApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var tokenId = "tokenId_example";  // string | 
            var expand = "expand_example";  // string |  (optional) 

            try
            {
                // Get OAuth 2.0 Token for Application
                OAuth2Token result = apiInstance.GetOAuth2TokenForApplication(appId, tokenId, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.GetOAuth2TokenForApplication: " + e.Message );
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
 **appId** | **string**|  | 
 **tokenId** | **string**|  | 
 **expand** | **string**|  | [optional] 

### Return type

[**OAuth2Token**](OAuth2Token.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getscopeconsentgrant"></a>
# **GetScopeConsentGrant**
> OAuth2ScopeConsentGrant GetScopeConsentGrant (string appId, string grantId, string expand = null)

Get Scope Consent Grant for Application

Fetches a single scope consent grant for the application

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetScopeConsentGrantExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var grantId = "grantId_example";  // string | 
            var expand = "expand_example";  // string |  (optional) 

            try
            {
                // Get Scope Consent Grant for Application
                OAuth2ScopeConsentGrant result = apiInstance.GetScopeConsentGrant(appId, grantId, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.GetScopeConsentGrant: " + e.Message );
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
 **appId** | **string**|  | 
 **grantId** | **string**|  | 
 **expand** | **string**|  | [optional] 

### Return type

[**OAuth2ScopeConsentGrant**](OAuth2ScopeConsentGrant.md)

### Authorization

[api_token](../README.md#api_token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="grantconsenttoscope"></a>
# **GrantConsentToScope**
> OAuth2ScopeConsentGrant GrantConsentToScope (string appId, OAuth2ScopeConsentGrant oAuth2ScopeConsentGrant)

Grant Consent to Scope for Application

Grants consent for the application to request an OAuth 2.0 Okta scope

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GrantConsentToScopeExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var oAuth2ScopeConsentGrant = new OAuth2ScopeConsentGrant(); // OAuth2ScopeConsentGrant | 

            try
            {
                // Grant Consent to Scope for Application
                OAuth2ScopeConsentGrant result = apiInstance.GrantConsentToScope(appId, oAuth2ScopeConsentGrant);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.GrantConsentToScope: " + e.Message );
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
 **appId** | **string**|  | 
 **oAuth2ScopeConsentGrant** | [**OAuth2ScopeConsentGrant**](OAuth2ScopeConsentGrant.md)|  | 

### Return type

[**OAuth2ScopeConsentGrant**](OAuth2ScopeConsentGrant.md)

### Authorization

[api_token](../README.md#api_token)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listapplicationgroupassignments"></a>
# **ListApplicationGroupAssignments**
> List&lt;ApplicationGroupAssignment&gt; ListApplicationGroupAssignments (string appId, string q = null, string after = null, int? limit = null, string expand = null)

List Groups Assigned to Application

Enumerates group assignments for an application.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListApplicationGroupAssignmentsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var q = "q_example";  // string |  (optional) 
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of assignments (optional) 
            var limit = -1;  // int? | Specifies the number of results for a page (optional)  (default to -1)
            var expand = "expand_example";  // string |  (optional) 

            try
            {
                // List Groups Assigned to Application
                List<ApplicationGroupAssignment> result = apiInstance.ListApplicationGroupAssignments(appId, q, after, limit, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.ListApplicationGroupAssignments: " + e.Message );
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
 **appId** | **string**|  | 
 **q** | **string**|  | [optional] 
 **after** | **string**| Specifies the pagination cursor for the next page of assignments | [optional] 
 **limit** | **int?**| Specifies the number of results for a page | [optional] [default to -1]
 **expand** | **string**|  | [optional] 

### Return type

[**List&lt;ApplicationGroupAssignment&gt;**](ApplicationGroupAssignment.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listapplicationkeys"></a>
# **ListApplicationKeys**
> List&lt;JsonWebKey&gt; ListApplicationKeys (string appId)

List Key Credentials for Application

Enumerates key credentials for an application

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
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 

            try
            {
                // List Key Credentials for Application
                List<JsonWebKey> result = apiInstance.ListApplicationKeys(appId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.ListApplicationKeys: " + e.Message );
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
 **appId** | **string**|  | 

### Return type

[**List&lt;JsonWebKey&gt;**](JsonWebKey.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listapplicationusers"></a>
# **ListApplicationUsers**
> List&lt;AppUser&gt; ListApplicationUsers (string appId, string q = null, string queryScope = null, string after = null, int? limit = null, string filter = null, string expand = null)

List Users Assigned to Application

Enumerates all assigned [application users](#application-user-model) for an application.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListApplicationUsersExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var q = "q_example";  // string |  (optional) 
            var queryScope = "queryScope_example";  // string |  (optional) 
            var after = "after_example";  // string | specifies the pagination cursor for the next page of assignments (optional) 
            var limit = -1;  // int? | specifies the number of results for a page (optional)  (default to -1)
            var filter = "filter_example";  // string |  (optional) 
            var expand = "expand_example";  // string |  (optional) 

            try
            {
                // List Users Assigned to Application
                List<AppUser> result = apiInstance.ListApplicationUsers(appId, q, queryScope, after, limit, filter, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.ListApplicationUsers: " + e.Message );
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
 **appId** | **string**|  | 
 **q** | **string**|  | [optional] 
 **queryScope** | **string**|  | [optional] 
 **after** | **string**| specifies the pagination cursor for the next page of assignments | [optional] 
 **limit** | **int?**| specifies the number of results for a page | [optional] [default to -1]
 **filter** | **string**|  | [optional] 
 **expand** | **string**|  | [optional] 

### Return type

[**List&lt;AppUser&gt;**](AppUser.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listapplications"></a>
# **ListApplications**
> List&lt;Application&gt; ListApplications (string q = null, string after = null, int? limit = null, string filter = null, string expand = null, bool? includeNonDeleted = null)

List Applications

Enumerates apps added to your organization with pagination. A subset of apps can be returned that match a supported filter expression or query.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListApplicationsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var q = "q_example";  // string |  (optional) 
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of apps (optional) 
            var limit = -1;  // int? | Specifies the number of results for a page (optional)  (default to -1)
            var filter = "filter_example";  // string | Filters apps by status, user.id, group.id or credentials.signing.kid expression (optional) 
            var expand = "expand_example";  // string | Traverses users link relationship and optionally embeds Application User resource (optional) 
            var includeNonDeleted = false;  // bool? |  (optional)  (default to false)

            try
            {
                // List Applications
                List<Application> result = apiInstance.ListApplications(q, after, limit, filter, expand, includeNonDeleted);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.ListApplications: " + e.Message );
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
 **q** | **string**|  | [optional] 
 **after** | **string**| Specifies the pagination cursor for the next page of apps | [optional] 
 **limit** | **int?**| Specifies the number of results for a page | [optional] [default to -1]
 **filter** | **string**| Filters apps by status, user.id, group.id or credentials.signing.kid expression | [optional] 
 **expand** | **string**| Traverses users link relationship and optionally embeds Application User resource | [optional] 
 **includeNonDeleted** | **bool?**|  | [optional] [default to false]

### Return type

[**List&lt;Application&gt;**](Application.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listcsrsforapplication"></a>
# **ListCsrsForApplication**
> List&lt;Csr&gt; ListCsrsForApplication (string appId)

List Certificate Signing Requests for Application

Enumerates Certificate Signing Requests for an application

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
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 

            try
            {
                // List Certificate Signing Requests for Application
                List<Csr> result = apiInstance.ListCsrsForApplication(appId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.ListCsrsForApplication: " + e.Message );
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
 **appId** | **string**|  | 

### Return type

[**List&lt;Csr&gt;**](Csr.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listfeaturesforapplication"></a>
# **ListFeaturesForApplication**
> List&lt;ApplicationFeature&gt; ListFeaturesForApplication (string appId)

Fetches the Feature objects for an application.

List Features for application

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListFeaturesForApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 

            try
            {
                // Fetches the Feature objects for an application.
                List<ApplicationFeature> result = apiInstance.ListFeaturesForApplication(appId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.ListFeaturesForApplication: " + e.Message );
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
 **appId** | **string**|  | 

### Return type

[**List&lt;ApplicationFeature&gt;**](ApplicationFeature.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listoauth2tokensforapplication"></a>
# **ListOAuth2TokensForApplication**
> List&lt;OAuth2Token&gt; ListOAuth2TokensForApplication (string appId, string expand = null, string after = null, int? limit = null)

Lists OAuth 2.0 Tokens for Application

Lists all tokens for the application

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListOAuth2TokensForApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var expand = "expand_example";  // string |  (optional) 
            var after = "after_example";  // string |  (optional) 
            var limit = 20;  // int? |  (optional)  (default to 20)

            try
            {
                // Lists OAuth 2.0 Tokens for Application
                List<OAuth2Token> result = apiInstance.ListOAuth2TokensForApplication(appId, expand, after, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.ListOAuth2TokensForApplication: " + e.Message );
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
 **appId** | **string**|  | 
 **expand** | **string**|  | [optional] 
 **after** | **string**|  | [optional] 
 **limit** | **int?**|  | [optional] [default to 20]

### Return type

[**List&lt;OAuth2Token&gt;**](OAuth2Token.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listscopeconsentgrants"></a>
# **ListScopeConsentGrants**
> List&lt;OAuth2ScopeConsentGrant&gt; ListScopeConsentGrants (string appId, string expand = null)

List Scope Consent Grants for Application

Lists all scope consent grants for the application

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListScopeConsentGrantsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var expand = "expand_example";  // string |  (optional) 

            try
            {
                // List Scope Consent Grants for Application
                List<OAuth2ScopeConsentGrant> result = apiInstance.ListScopeConsentGrants(appId, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.ListScopeConsentGrants: " + e.Message );
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
 **appId** | **string**|  | 
 **expand** | **string**|  | [optional] 

### Return type

[**List&lt;OAuth2ScopeConsentGrant&gt;**](OAuth2ScopeConsentGrant.md)

### Authorization

[api_token](../README.md#api_token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="publishcsrfromapplication"></a>
# **PublishCsrFromApplication**
> JsonWebKey PublishCsrFromApplication (string appId, string csrId, System.IO.Stream body)

Publish Certificate Signing Request

Updates a certificate signing request for the app with a signed X.509 certificate and adds it into the application key credentials

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
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var csrId = "csrId_example";  // string | 
            var body = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream | 

            try
            {
                // Publish Certificate Signing Request
                JsonWebKey result = apiInstance.PublishCsrFromApplication(appId, csrId, body);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.PublishCsrFromApplication: " + e.Message );
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
 **appId** | **string**|  | 
 **csrId** | **string**|  | 
 **body** | **System.IO.Stream****System.IO.Stream**|  | 

### Return type

[**JsonWebKey**](JsonWebKey.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/octet-stream, application/x-x509-ca-cert, application/pkix-cert, application/x-pem-file
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="revokecsrfromapplication"></a>
# **RevokeCsrFromApplication**
> void RevokeCsrFromApplication (string appId, string csrId)

Revoke Certificate Signing Request

Revokes a certificate signing request and deletes the key pair from the application.

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
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var csrId = "csrId_example";  // string | 

            try
            {
                // Revoke Certificate Signing Request
                apiInstance.RevokeCsrFromApplication(appId, csrId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.RevokeCsrFromApplication: " + e.Message );
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
 **appId** | **string**|  | 
 **csrId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="revokeoauth2tokenforapplication"></a>
# **RevokeOAuth2TokenForApplication**
> void RevokeOAuth2TokenForApplication (string appId, string tokenId)

Revoke an OAuth 2.0 Token for Application

Revokes the specified token for the specified application

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RevokeOAuth2TokenForApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var tokenId = "tokenId_example";  // string | 

            try
            {
                // Revoke an OAuth 2.0 Token for Application
                apiInstance.RevokeOAuth2TokenForApplication(appId, tokenId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.RevokeOAuth2TokenForApplication: " + e.Message );
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
 **appId** | **string**|  | 
 **tokenId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="revokeoauth2tokensforapplication"></a>
# **RevokeOAuth2TokensForApplication**
> void RevokeOAuth2TokensForApplication (string appId)

Revoke All OAuth 2.0 Tokens for Application

Revokes all tokens for the specified application

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RevokeOAuth2TokensForApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 

            try
            {
                // Revoke All OAuth 2.0 Tokens for Application
                apiInstance.RevokeOAuth2TokensForApplication(appId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.RevokeOAuth2TokensForApplication: " + e.Message );
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
 **appId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="revokescopeconsentgrant"></a>
# **RevokeScopeConsentGrant**
> void RevokeScopeConsentGrant (string appId, string grantId)

Revoke Scope Consent Grant for Application

Revokes permission for the application to request the given scope

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RevokeScopeConsentGrantExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var grantId = "grantId_example";  // string | 

            try
            {
                // Revoke Scope Consent Grant for Application
                apiInstance.RevokeScopeConsentGrant(appId, grantId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.RevokeScopeConsentGrant: " + e.Message );
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
 **appId** | **string**|  | 
 **grantId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_token](../README.md#api_token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | No Content |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="setdefaultprovisioningconnectionforapplication"></a>
# **SetDefaultProvisioningConnectionForApplication**
> ProvisioningConnection SetDefaultProvisioningConnectionForApplication (string appId, ProvisioningConnectionRequest provisioningConnectionRequest, bool? activate = null)

Sets the default Provisioning Connection for an application.

Set default Provisioning Connection for application

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class SetDefaultProvisioningConnectionForApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var provisioningConnectionRequest = new ProvisioningConnectionRequest(); // ProvisioningConnectionRequest | 
            var activate = true;  // bool? |  (optional) 

            try
            {
                // Sets the default Provisioning Connection for an application.
                ProvisioningConnection result = apiInstance.SetDefaultProvisioningConnectionForApplication(appId, provisioningConnectionRequest, activate);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.SetDefaultProvisioningConnectionForApplication: " + e.Message );
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
 **appId** | **string**|  | 
 **provisioningConnectionRequest** | [**ProvisioningConnectionRequest**](ProvisioningConnectionRequest.md)|  | 
 **activate** | **bool?**|  | [optional] 

### Return type

[**ProvisioningConnection**](ProvisioningConnection.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **400** | Bad Request |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateapplication"></a>
# **UpdateApplication**
> Application UpdateApplication (string appId, Application application)

Update Application

Updates an application in your organization.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var application = new Application(); // Application | 

            try
            {
                // Update Application
                Application result = apiInstance.UpdateApplication(appId, application);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.UpdateApplication: " + e.Message );
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
 **appId** | **string**|  | 
 **application** | [**Application**](Application.md)|  | 

### Return type

[**Application**](Application.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateapplicationuser"></a>
# **UpdateApplicationUser**
> AppUser UpdateApplicationUser (string appId, string userId, AppUser appUser)

Update Application Profile for Assigned User

Updates a user's profile for an application

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateApplicationUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var userId = "userId_example";  // string | 
            var appUser = new AppUser(); // AppUser | 

            try
            {
                // Update Application Profile for Assigned User
                AppUser result = apiInstance.UpdateApplicationUser(appId, userId, appUser);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.UpdateApplicationUser: " + e.Message );
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
 **appId** | **string**|  | 
 **userId** | **string**|  | 
 **appUser** | [**AppUser**](AppUser.md)|  | 

### Return type

[**AppUser**](AppUser.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatefeatureforapplication"></a>
# **UpdateFeatureForApplication**
> ApplicationFeature UpdateFeatureForApplication (string appId, string name, CapabilitiesObject capabilitiesObject)

Updates a Feature object for an application.

Updates a Feature object for an application.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateFeatureForApplicationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationApi(config);
            var appId = "appId_example";  // string | 
            var name = "name_example";  // string | 
            var capabilitiesObject = new CapabilitiesObject(); // CapabilitiesObject | 

            try
            {
                // Updates a Feature object for an application.
                ApplicationFeature result = apiInstance.UpdateFeatureForApplication(appId, name, capabilitiesObject);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationApi.UpdateFeatureForApplication: " + e.Message );
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
 **appId** | **string**|  | 
 **name** | **string**|  | 
 **capabilitiesObject** | [**CapabilitiesObject**](CapabilitiesObject.md)|  | 

### Return type

[**ApplicationFeature**](ApplicationFeature.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

