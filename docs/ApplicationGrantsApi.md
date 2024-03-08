# Okta.Sdk.Api.ApplicationGrantsApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetScopeConsentGrant**](ApplicationGrantsApi.md#getscopeconsentgrant) | **GET** /api/v1/apps/{appId}/grants/{grantId} | Retrieve an app Grant
[**GrantConsentToScope**](ApplicationGrantsApi.md#grantconsenttoscope) | **POST** /api/v1/apps/{appId}/grants | Grant consent to scope
[**ListScopeConsentGrants**](ApplicationGrantsApi.md#listscopeconsentgrants) | **GET** /api/v1/apps/{appId}/grants | List all app Grants
[**RevokeScopeConsentGrant**](ApplicationGrantsApi.md#revokescopeconsentgrant) | **DELETE** /api/v1/apps/{appId}/grants/{grantId} | Revoke an app Grant


<a name="getscopeconsentgrant"></a>
# **GetScopeConsentGrant**
> OAuth2ScopeConsentGrant GetScopeConsentGrant (string expand = null)

Retrieve an app Grant

Retrieves a single scope consent Grant object for the app

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationGrantsApi(config);
            var expand = scope;  // string | An optional parameter to include scope details in the `_embedded` attribute. Valid value: `scope` (optional) 

            try
            {
                // Retrieve an app Grant
                OAuth2ScopeConsentGrant result = apiInstance.GetScopeConsentGrant(expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationGrantsApi.GetScopeConsentGrant: " + e.Message );
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
 **expand** | **string**| An optional parameter to include scope details in the &#x60;_embedded&#x60; attribute. Valid value: &#x60;scope&#x60; | [optional] 

### Return type

[**OAuth2ScopeConsentGrant**](OAuth2ScopeConsentGrant.md)

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

<a name="grantconsenttoscope"></a>
# **GrantConsentToScope**
> OAuth2ScopeConsentGrant GrantConsentToScope (string appId, OAuth2ScopeConsentGrant oAuth2ScopeConsentGrant)

Grant consent to scope

Grants consent for the app to request an OAuth 2.0 Okta scope

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationGrantsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application
            var oAuth2ScopeConsentGrant = new OAuth2ScopeConsentGrant(); // OAuth2ScopeConsentGrant | 

            try
            {
                // Grant consent to scope
                OAuth2ScopeConsentGrant result = apiInstance.GrantConsentToScope(appId, oAuth2ScopeConsentGrant);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationGrantsApi.GrantConsentToScope: " + e.Message );
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
 **oAuth2ScopeConsentGrant** | [**OAuth2ScopeConsentGrant**](OAuth2ScopeConsentGrant.md)|  | 

### Return type

[**OAuth2ScopeConsentGrant**](OAuth2ScopeConsentGrant.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listscopeconsentgrants"></a>
# **ListScopeConsentGrants**
> List&lt;OAuth2ScopeConsentGrant&gt; ListScopeConsentGrants (string expand = null)

List all app Grants

Lists all scope consent Grants for the app

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationGrantsApi(config);
            var expand = scope;  // string | An optional parameter to include scope details in the `_embedded` attribute. Valid value: `scope` (optional) 

            try
            {
                // List all app Grants
                List<OAuth2ScopeConsentGrant> result = apiInstance.ListScopeConsentGrants(expand).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationGrantsApi.ListScopeConsentGrants: " + e.Message );
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
 **expand** | **string**| An optional parameter to include scope details in the &#x60;_embedded&#x60; attribute. Valid value: &#x60;scope&#x60; | [optional] 

### Return type

[**List&lt;OAuth2ScopeConsentGrant&gt;**](OAuth2ScopeConsentGrant.md)

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

<a name="revokescopeconsentgrant"></a>
# **RevokeScopeConsentGrant**
> void RevokeScopeConsentGrant (string appId, string grantId)

Revoke an app Grant

Revokes permission for the app to grant the given scope

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
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationGrantsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | ID of the Application
            var grantId = iJoqkwx50mrgX4T9LcaH;  // string | ID of the Grant

            try
            {
                // Revoke an app Grant
                apiInstance.RevokeScopeConsentGrant(appId, grantId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationGrantsApi.RevokeScopeConsentGrant: " + e.Message );
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
 **grantId** | **string**| ID of the Grant | 

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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

