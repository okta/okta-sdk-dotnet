# Okta.Sdk.Api.ApplicationSSOFederatedClaimsApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateFederatedClaim**](ApplicationSSOFederatedClaimsApi.md#createfederatedclaim) | **POST** /api/v1/apps/{appId}/federated-claims | Create a federated claim
[**DeleteFederatedClaim**](ApplicationSSOFederatedClaimsApi.md#deletefederatedclaim) | **DELETE** /api/v1/apps/{appId}/federated-claims/{claimId} | Delete a federated claim
[**GetFederatedClaim**](ApplicationSSOFederatedClaimsApi.md#getfederatedclaim) | **GET** /api/v1/apps/{appId}/federated-claims/{claimId} | Retrieve a federated claim
[**ListFederatedClaims**](ApplicationSSOFederatedClaimsApi.md#listfederatedclaims) | **GET** /api/v1/apps/{appId}/federated-claims | List all configured federated claims
[**ReplaceFederatedClaim**](ApplicationSSOFederatedClaimsApi.md#replacefederatedclaim) | **PUT** /api/v1/apps/{appId}/federated-claims/{claimId} | Replace a federated claim


<a name="createfederatedclaim"></a>
# **CreateFederatedClaim**
> FederatedClaim CreateFederatedClaim (string appId, FederatedClaimRequestBody federatedClaimRequestBody)

Create a federated claim

Creates a claim that will be included in tokens produced by federation protocols (for example: OIDC `id_tokens` or SAML Assertions)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateFederatedClaimExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationSSOFederatedClaimsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var federatedClaimRequestBody = new FederatedClaimRequestBody(); // FederatedClaimRequestBody | 

            try
            {
                // Create a federated claim
                FederatedClaim result = apiInstance.CreateFederatedClaim(appId, federatedClaimRequestBody);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationSSOFederatedClaimsApi.CreateFederatedClaim: " + e.Message );
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
 **federatedClaimRequestBody** | [**FederatedClaimRequestBody**](FederatedClaimRequestBody.md)|  | 

### Return type

[**FederatedClaim**](FederatedClaim.md)

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

<a name="deletefederatedclaim"></a>
# **DeleteFederatedClaim**
> void DeleteFederatedClaim (string appId, string claimId)

Delete a federated claim

Deletes a federated claim by `claimId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteFederatedClaimExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationSSOFederatedClaimsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var claimId = ofc2f4zrZbs8nUa7p0g4;  // string | The unique `id` of the federated claim

            try
            {
                // Delete a federated claim
                apiInstance.DeleteFederatedClaim(appId, claimId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationSSOFederatedClaimsApi.DeleteFederatedClaim: " + e.Message );
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
 **claimId** | **string**| The unique &#x60;id&#x60; of the federated claim | 

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
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getfederatedclaim"></a>
# **GetFederatedClaim**
> FederatedClaimRequestBody GetFederatedClaim (string appId, string claimId)

Retrieve a federated claim

Retrieves a federated claim by `claimId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetFederatedClaimExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationSSOFederatedClaimsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var claimId = ofc2f4zrZbs8nUa7p0g4;  // string | The unique `id` of the federated claim

            try
            {
                // Retrieve a federated claim
                FederatedClaimRequestBody result = apiInstance.GetFederatedClaim(appId, claimId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationSSOFederatedClaimsApi.GetFederatedClaim: " + e.Message );
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
 **claimId** | **string**| The unique &#x60;id&#x60; of the federated claim | 

### Return type

[**FederatedClaimRequestBody**](FederatedClaimRequestBody.md)

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

<a name="listfederatedclaims"></a>
# **ListFederatedClaims**
> List&lt;FederatedClaim&gt; ListFederatedClaims (string appId)

List all configured federated claims

Lists all federated claims for your app

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListFederatedClaimsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationSSOFederatedClaimsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID

            try
            {
                // List all configured federated claims
                List<FederatedClaim> result = apiInstance.ListFederatedClaims(appId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationSSOFederatedClaimsApi.ListFederatedClaims: " + e.Message );
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

[**List&lt;FederatedClaim&gt;**](FederatedClaim.md)

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

<a name="replacefederatedclaim"></a>
# **ReplaceFederatedClaim**
> FederatedClaim ReplaceFederatedClaim (string appId, string claimId, FederatedClaim federatedClaim = null)

Replace a federated claim

Replaces a claim that will be included in tokens produced by federation protocols (for example: OIDC `id_tokens` or SAML Assertions)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceFederatedClaimExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationSSOFederatedClaimsApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var claimId = ofc2f4zrZbs8nUa7p0g4;  // string | The unique `id` of the federated claim
            var federatedClaim = new FederatedClaim(); // FederatedClaim |  (optional) 

            try
            {
                // Replace a federated claim
                FederatedClaim result = apiInstance.ReplaceFederatedClaim(appId, claimId, federatedClaim);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationSSOFederatedClaimsApi.ReplaceFederatedClaim: " + e.Message );
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
 **claimId** | **string**| The unique &#x60;id&#x60; of the federated claim | 
 **federatedClaim** | [**FederatedClaim**](FederatedClaim.md)|  | [optional] 

### Return type

[**FederatedClaim**](FederatedClaim.md)

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

