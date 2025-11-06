# Okta.Sdk.Api.UserGrantApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetUserGrant**](UserGrantApi.md#getusergrant) | **GET** /api/v1/users/{userId}/grants/{grantId} | Retrieve a user grant
[**ListGrantsForUserAndClient**](UserGrantApi.md#listgrantsforuserandclient) | **GET** /api/v1/users/{userId}/clients/{clientId}/grants | List all grants for a client
[**ListUserGrants**](UserGrantApi.md#listusergrants) | **GET** /api/v1/users/{userId}/grants | List all user grants
[**RevokeGrantsForUserAndClient**](UserGrantApi.md#revokegrantsforuserandclient) | **DELETE** /api/v1/users/{userId}/clients/{clientId}/grants | Revoke all grants for a client
[**RevokeUserGrant**](UserGrantApi.md#revokeusergrant) | **DELETE** /api/v1/users/{userId}/grants/{grantId} | Revoke a user grant
[**RevokeUserGrants**](UserGrantApi.md#revokeusergrants) | **DELETE** /api/v1/users/{userId}/grants | Revoke all user grants


<a name="getusergrant"></a>
# **GetUserGrant**
> OAuth2ScopeConsentGrant GetUserGrant (string userId, string grantId, string expand = null)

Retrieve a user grant

Retrieves a grant for the specified user

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetUserGrantExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserGrantApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var grantId = iJoqkwx50mrgX4T9LcaH;  // string | Grant ID
            var expand = scope;  // string | Valid value: `scope`. If specified, scope details are included in the `_embedded` attribute. (optional) 

            try
            {
                // Retrieve a user grant
                OAuth2ScopeConsentGrant result = apiInstance.GetUserGrant(userId, grantId, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserGrantApi.GetUserGrant: " + e.Message );
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
 **userId** | **string**| ID of an existing Okta user | 
 **grantId** | **string**| Grant ID | 
 **expand** | **string**| Valid value: &#x60;scope&#x60;. If specified, scope details are included in the &#x60;_embedded&#x60; attribute. | [optional] 

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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listgrantsforuserandclient"></a>
# **ListGrantsForUserAndClient**
> List&lt;OAuth2ScopeConsentGrant&gt; ListGrantsForUserAndClient (string userId, string clientId, string expand = null, string after = null, int? limit = null)

List all grants for a client

Lists all grants for a specified user and client

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListGrantsForUserAndClientExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserGrantApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | Client app ID
            var expand = "expand_example";  // string | Valid value: `scope`. If specified, scope details are included in the `_embedded` attribute. (optional) 
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 
            var limit = 20;  // int? | Specifies the number of tokens to return (optional)  (default to 20)

            try
            {
                // List all grants for a client
                List<OAuth2ScopeConsentGrant> result = apiInstance.ListGrantsForUserAndClient(userId, clientId, expand, after, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserGrantApi.ListGrantsForUserAndClient: " + e.Message );
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
 **userId** | **string**| ID of an existing Okta user | 
 **clientId** | **string**| Client app ID | 
 **expand** | **string**| Valid value: &#x60;scope&#x60;. If specified, scope details are included in the &#x60;_embedded&#x60; attribute. | [optional] 
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 
 **limit** | **int?**| Specifies the number of tokens to return | [optional] [default to 20]

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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listusergrants"></a>
# **ListUserGrants**
> List&lt;OAuth2ScopeConsentGrant&gt; ListUserGrants (string userId, string scopeId = null, string expand = null, string after = null, int? limit = null)

List all user grants

Lists all grants for the specified user

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListUserGrantsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserGrantApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var scopeId = "scopeId_example";  // string | The scope ID to filter on (optional) 
            var expand = scope;  // string | Valid value: `scope`. If specified, scope details are included in the `_embedded` attribute. (optional) 
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 
            var limit = 20;  // int? | Specifies the number of grants to return (optional)  (default to 20)

            try
            {
                // List all user grants
                List<OAuth2ScopeConsentGrant> result = apiInstance.ListUserGrants(userId, scopeId, expand, after, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserGrantApi.ListUserGrants: " + e.Message );
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
 **userId** | **string**| ID of an existing Okta user | 
 **scopeId** | **string**| The scope ID to filter on | [optional] 
 **expand** | **string**| Valid value: &#x60;scope&#x60;. If specified, scope details are included in the &#x60;_embedded&#x60; attribute. | [optional] 
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 
 **limit** | **int?**| Specifies the number of grants to return | [optional] [default to 20]

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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="revokegrantsforuserandclient"></a>
# **RevokeGrantsForUserAndClient**
> void RevokeGrantsForUserAndClient (string userId, string clientId)

Revoke all grants for a client

Revokes all grants for the specified user and client

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RevokeGrantsForUserAndClientExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserGrantApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | Client app ID

            try
            {
                // Revoke all grants for a client
                apiInstance.RevokeGrantsForUserAndClient(userId, clientId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserGrantApi.RevokeGrantsForUserAndClient: " + e.Message );
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
 **userId** | **string**| ID of an existing Okta user | 
 **clientId** | **string**| Client app ID | 

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

<a name="revokeusergrant"></a>
# **RevokeUserGrant**
> void RevokeUserGrant (string userId, string grantId)

Revoke a user grant

Revokes one grant for a specified user

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RevokeUserGrantExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserGrantApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user
            var grantId = iJoqkwx50mrgX4T9LcaH;  // string | Grant ID

            try
            {
                // Revoke a user grant
                apiInstance.RevokeUserGrant(userId, grantId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserGrantApi.RevokeUserGrant: " + e.Message );
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
 **userId** | **string**| ID of an existing Okta user | 
 **grantId** | **string**| Grant ID | 

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

<a name="revokeusergrants"></a>
# **RevokeUserGrants**
> void RevokeUserGrants (string userId)

Revoke all user grants

Revokes all grants for a specified user

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RevokeUserGrantsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserGrantApi(config);
            var userId = 00ub0oNGTSWTBKOLGLNR;  // string | ID of an existing Okta user

            try
            {
                // Revoke all user grants
                apiInstance.RevokeUserGrants(userId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserGrantApi.RevokeUserGrants: " + e.Message );
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
 **userId** | **string**| ID of an existing Okta user | 

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

