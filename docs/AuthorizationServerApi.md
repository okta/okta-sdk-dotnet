# Okta.Sdk.Api.AuthorizationServerApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateAuthorizationServer**](AuthorizationServerApi.md#activateauthorizationserver) | **POST** /api/v1/authorizationServers/{authServerId}/lifecycle/activate | Activate an Authorization Server
[**ActivateAuthorizationServerPolicy**](AuthorizationServerApi.md#activateauthorizationserverpolicy) | **POST** /api/v1/authorizationServers/{authServerId}/policies/{policyId}/lifecycle/activate | Activate a Policy
[**ActivateAuthorizationServerPolicyRule**](AuthorizationServerApi.md#activateauthorizationserverpolicyrule) | **POST** /api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules/{ruleId}/lifecycle/activate | Activate a Policy Rule
[**CreateAssociatedServers**](AuthorizationServerApi.md#createassociatedservers) | **POST** /api/v1/authorizationServers/{authServerId}/associatedServers | Create the Associated Authorization Servers
[**CreateAuthorizationServer**](AuthorizationServerApi.md#createauthorizationserver) | **POST** /api/v1/authorizationServers | Create an Authorization Server
[**CreateAuthorizationServerPolicy**](AuthorizationServerApi.md#createauthorizationserverpolicy) | **POST** /api/v1/authorizationServers/{authServerId}/policies | Create a Policy
[**CreateAuthorizationServerPolicyRule**](AuthorizationServerApi.md#createauthorizationserverpolicyrule) | **POST** /api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules | Create a Policy Rule
[**CreateOAuth2Claim**](AuthorizationServerApi.md#createoauth2claim) | **POST** /api/v1/authorizationServers/{authServerId}/claims | Create a Custom Token Claim
[**CreateOAuth2Scope**](AuthorizationServerApi.md#createoauth2scope) | **POST** /api/v1/authorizationServers/{authServerId}/scopes | Create a Custom Token Scope
[**DeactivateAuthorizationServer**](AuthorizationServerApi.md#deactivateauthorizationserver) | **POST** /api/v1/authorizationServers/{authServerId}/lifecycle/deactivate | Deactivate an Authorization Server
[**DeactivateAuthorizationServerPolicy**](AuthorizationServerApi.md#deactivateauthorizationserverpolicy) | **POST** /api/v1/authorizationServers/{authServerId}/policies/{policyId}/lifecycle/deactivate | Deactivate a Policy
[**DeactivateAuthorizationServerPolicyRule**](AuthorizationServerApi.md#deactivateauthorizationserverpolicyrule) | **POST** /api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules/{ruleId}/lifecycle/deactivate | Deactivate a Policy Rule
[**DeleteAssociatedServer**](AuthorizationServerApi.md#deleteassociatedserver) | **DELETE** /api/v1/authorizationServers/{authServerId}/associatedServers/{associatedServerId} | Delete an Associated Authorization Server
[**DeleteAuthorizationServer**](AuthorizationServerApi.md#deleteauthorizationserver) | **DELETE** /api/v1/authorizationServers/{authServerId} | Delete an Authorization Server
[**DeleteAuthorizationServerPolicy**](AuthorizationServerApi.md#deleteauthorizationserverpolicy) | **DELETE** /api/v1/authorizationServers/{authServerId}/policies/{policyId} | Delete a Policy
[**DeleteAuthorizationServerPolicyRule**](AuthorizationServerApi.md#deleteauthorizationserverpolicyrule) | **DELETE** /api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules/{ruleId} | Delete a Policy Rule
[**DeleteOAuth2Claim**](AuthorizationServerApi.md#deleteoauth2claim) | **DELETE** /api/v1/authorizationServers/{authServerId}/claims/{claimId} | Delete a Custom Token Claim
[**DeleteOAuth2Scope**](AuthorizationServerApi.md#deleteoauth2scope) | **DELETE** /api/v1/authorizationServers/{authServerId}/scopes/{scopeId} | Delete a Custom Token Scope
[**GetAuthorizationServer**](AuthorizationServerApi.md#getauthorizationserver) | **GET** /api/v1/authorizationServers/{authServerId} | Retrieve an Authorization Server
[**GetAuthorizationServerPolicy**](AuthorizationServerApi.md#getauthorizationserverpolicy) | **GET** /api/v1/authorizationServers/{authServerId}/policies/{policyId} | Retrieve a Policy
[**GetAuthorizationServerPolicyRule**](AuthorizationServerApi.md#getauthorizationserverpolicyrule) | **GET** /api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules/{ruleId} | Retrieve a Policy Rule
[**GetOAuth2Claim**](AuthorizationServerApi.md#getoauth2claim) | **GET** /api/v1/authorizationServers/{authServerId}/claims/{claimId} | Retrieve a Custom Token Claim
[**GetOAuth2Scope**](AuthorizationServerApi.md#getoauth2scope) | **GET** /api/v1/authorizationServers/{authServerId}/scopes/{scopeId} | Retrieve a Custom Token Scope
[**GetRefreshTokenForAuthorizationServerAndClient**](AuthorizationServerApi.md#getrefreshtokenforauthorizationserverandclient) | **GET** /api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens/{tokenId} | Retrieve a Refresh Token for a Client
[**ListAssociatedServersByTrustedType**](AuthorizationServerApi.md#listassociatedserversbytrustedtype) | **GET** /api/v1/authorizationServers/{authServerId}/associatedServers | List all Associated Authorization Servers
[**ListAuthorizationServerKeys**](AuthorizationServerApi.md#listauthorizationserverkeys) | **GET** /api/v1/authorizationServers/{authServerId}/credentials/keys | List all Credential Keys
[**ListAuthorizationServerPolicies**](AuthorizationServerApi.md#listauthorizationserverpolicies) | **GET** /api/v1/authorizationServers/{authServerId}/policies | List all Policies
[**ListAuthorizationServerPolicyRules**](AuthorizationServerApi.md#listauthorizationserverpolicyrules) | **GET** /api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules | List all Policy Rules
[**ListAuthorizationServers**](AuthorizationServerApi.md#listauthorizationservers) | **GET** /api/v1/authorizationServers | List all Authorization Servers
[**ListOAuth2Claims**](AuthorizationServerApi.md#listoauth2claims) | **GET** /api/v1/authorizationServers/{authServerId}/claims | List all Custom Token Claims
[**ListOAuth2ClientsForAuthorizationServer**](AuthorizationServerApi.md#listoauth2clientsforauthorizationserver) | **GET** /api/v1/authorizationServers/{authServerId}/clients | List all Clients
[**ListOAuth2Scopes**](AuthorizationServerApi.md#listoauth2scopes) | **GET** /api/v1/authorizationServers/{authServerId}/scopes | List all Custom Token Scopes
[**ListRefreshTokensForAuthorizationServerAndClient**](AuthorizationServerApi.md#listrefreshtokensforauthorizationserverandclient) | **GET** /api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens | List all Refresh Tokens for a Client
[**ReplaceAuthorizationServer**](AuthorizationServerApi.md#replaceauthorizationserver) | **PUT** /api/v1/authorizationServers/{authServerId} | Replace an Authorization Server
[**ReplaceAuthorizationServerPolicy**](AuthorizationServerApi.md#replaceauthorizationserverpolicy) | **PUT** /api/v1/authorizationServers/{authServerId}/policies/{policyId} | Replace a Policy
[**ReplaceAuthorizationServerPolicyRule**](AuthorizationServerApi.md#replaceauthorizationserverpolicyrule) | **PUT** /api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules/{ruleId} | Replace a Policy Rule
[**ReplaceOAuth2Claim**](AuthorizationServerApi.md#replaceoauth2claim) | **PUT** /api/v1/authorizationServers/{authServerId}/claims/{claimId} | Replace a Custom Token Claim
[**ReplaceOAuth2Scope**](AuthorizationServerApi.md#replaceoauth2scope) | **PUT** /api/v1/authorizationServers/{authServerId}/scopes/{scopeId} | Replace a Custom Token Scope
[**RevokeRefreshTokenForAuthorizationServerAndClient**](AuthorizationServerApi.md#revokerefreshtokenforauthorizationserverandclient) | **DELETE** /api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens/{tokenId} | Revoke a Refresh Token for a Client
[**RevokeRefreshTokensForAuthorizationServerAndClient**](AuthorizationServerApi.md#revokerefreshtokensforauthorizationserverandclient) | **DELETE** /api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens | Revoke all Refresh Tokens for a Client
[**RotateAuthorizationServerKeys**](AuthorizationServerApi.md#rotateauthorizationserverkeys) | **POST** /api/v1/authorizationServers/{authServerId}/credentials/lifecycle/keyRotate | Rotate all Credential Keys


<a name="activateauthorizationserver"></a>
# **ActivateAuthorizationServer**
> void ActivateAuthorizationServer (string authServerId)

Activate an Authorization Server

Activates an authorization server

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateAuthorizationServerExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server

            try
            {
                // Activate an Authorization Server
                apiInstance.ActivateAuthorizationServer(authServerId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.ActivateAuthorizationServer: " + e.Message );
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

<a name="activateauthorizationserverpolicy"></a>
# **ActivateAuthorizationServerPolicy**
> void ActivateAuthorizationServerPolicy (string authServerId, string policyId)

Activate a Policy

Activates an authorization server policy

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateAuthorizationServerPolicyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy

            try
            {
                // Activate a Policy
                apiInstance.ActivateAuthorizationServerPolicy(authServerId, policyId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.ActivateAuthorizationServerPolicy: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 

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

<a name="activateauthorizationserverpolicyrule"></a>
# **ActivateAuthorizationServerPolicyRule**
> void ActivateAuthorizationServerPolicyRule (string authServerId, string policyId, string ruleId)

Activate a Policy Rule

Activates an authorization server policy rule

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateAuthorizationServerPolicyRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy
            var ruleId = ruld3hJ7jZh4fn0st0g3;  // string | `id` of the Policy Rule

            try
            {
                // Activate a Policy Rule
                apiInstance.ActivateAuthorizationServerPolicyRule(authServerId, policyId, ruleId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.ActivateAuthorizationServerPolicyRule: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 
 **ruleId** | **string**| &#x60;id&#x60; of the Policy Rule | 

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

<a name="createassociatedservers"></a>
# **CreateAssociatedServers**
> List&lt;AuthorizationServer&gt; CreateAssociatedServers (string authServerId, AssociatedServerMediated associatedServerMediated)

Create the Associated Authorization Servers

Creates the trusted relationships between the given authorization server and other authorization servers

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateAssociatedServersExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var associatedServerMediated = new AssociatedServerMediated(); // AssociatedServerMediated | 

            try
            {
                // Create the Associated Authorization Servers
                List<AuthorizationServer> result = apiInstance.CreateAssociatedServers(authServerId, associatedServerMediated).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.CreateAssociatedServers: " + e.Message );
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
 **associatedServerMediated** | [**AssociatedServerMediated**](AssociatedServerMediated.md)|  | 

### Return type

[**List&lt;AuthorizationServer&gt;**](AuthorizationServer.md)

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

<a name="createauthorizationserver"></a>
# **CreateAuthorizationServer**
> AuthorizationServer CreateAuthorizationServer (AuthorizationServer authorizationServer)

Create an Authorization Server

Creates an authorization server

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateAuthorizationServerExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authorizationServer = new AuthorizationServer(); // AuthorizationServer | 

            try
            {
                // Create an Authorization Server
                AuthorizationServer result = apiInstance.CreateAuthorizationServer(authorizationServer);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.CreateAuthorizationServer: " + e.Message );
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
 **authorizationServer** | [**AuthorizationServer**](AuthorizationServer.md)|  | 

### Return type

[**AuthorizationServer**](AuthorizationServer.md)

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
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createauthorizationserverpolicy"></a>
# **CreateAuthorizationServerPolicy**
> AuthorizationServerPolicy CreateAuthorizationServerPolicy (string authServerId, AuthorizationServerPolicy policy)

Create a Policy

Creates a policy

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateAuthorizationServerPolicyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var policy = new AuthorizationServerPolicy(); // AuthorizationServerPolicy | 

            try
            {
                // Create a Policy
                AuthorizationServerPolicy result = apiInstance.CreateAuthorizationServerPolicy(authServerId, policy);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.CreateAuthorizationServerPolicy: " + e.Message );
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
 **policy** | [**AuthorizationServerPolicy**](AuthorizationServerPolicy.md)|  | 

### Return type

[**AuthorizationServerPolicy**](AuthorizationServerPolicy.md)

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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createauthorizationserverpolicyrule"></a>
# **CreateAuthorizationServerPolicyRule**
> AuthorizationServerPolicyRule CreateAuthorizationServerPolicyRule (string authServerId, string policyId, AuthorizationServerPolicyRule policyRule)

Create a Policy Rule

Creates a policy rule for the specified Custom Authorization Server and Policy

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateAuthorizationServerPolicyRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy
            var policyRule = new AuthorizationServerPolicyRule(); // AuthorizationServerPolicyRule | 

            try
            {
                // Create a Policy Rule
                AuthorizationServerPolicyRule result = apiInstance.CreateAuthorizationServerPolicyRule(authServerId, policyId, policyRule);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.CreateAuthorizationServerPolicyRule: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 
 **policyRule** | [**AuthorizationServerPolicyRule**](AuthorizationServerPolicyRule.md)|  | 

### Return type

[**AuthorizationServerPolicyRule**](AuthorizationServerPolicyRule.md)

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
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createoauth2claim"></a>
# **CreateOAuth2Claim**
> OAuth2Claim CreateOAuth2Claim (string authServerId, OAuth2Claim oAuth2Claim)

Create a Custom Token Claim

Creates a custom token claim

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateOAuth2ClaimExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var oAuth2Claim = new OAuth2Claim(); // OAuth2Claim | 

            try
            {
                // Create a Custom Token Claim
                OAuth2Claim result = apiInstance.CreateOAuth2Claim(authServerId, oAuth2Claim);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.CreateOAuth2Claim: " + e.Message );
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
 **oAuth2Claim** | [**OAuth2Claim**](OAuth2Claim.md)|  | 

### Return type

[**OAuth2Claim**](OAuth2Claim.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Success |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createoauth2scope"></a>
# **CreateOAuth2Scope**
> OAuth2Scope CreateOAuth2Scope (string authServerId, OAuth2Scope oAuth2Scope)

Create a Custom Token Scope

Creates a custom token scope

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateOAuth2ScopeExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var oAuth2Scope = new OAuth2Scope(); // OAuth2Scope | 

            try
            {
                // Create a Custom Token Scope
                OAuth2Scope result = apiInstance.CreateOAuth2Scope(authServerId, oAuth2Scope);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.CreateOAuth2Scope: " + e.Message );
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
 **oAuth2Scope** | [**OAuth2Scope**](OAuth2Scope.md)|  | 

### Return type

[**OAuth2Scope**](OAuth2Scope.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Success |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivateauthorizationserver"></a>
# **DeactivateAuthorizationServer**
> void DeactivateAuthorizationServer (string authServerId)

Deactivate an Authorization Server

Deactivates an authorization server

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateAuthorizationServerExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server

            try
            {
                // Deactivate an Authorization Server
                apiInstance.DeactivateAuthorizationServer(authServerId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.DeactivateAuthorizationServer: " + e.Message );
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

<a name="deactivateauthorizationserverpolicy"></a>
# **DeactivateAuthorizationServerPolicy**
> void DeactivateAuthorizationServerPolicy (string authServerId, string policyId)

Deactivate a Policy

Deactivates an authorization server policy

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateAuthorizationServerPolicyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy

            try
            {
                // Deactivate a Policy
                apiInstance.DeactivateAuthorizationServerPolicy(authServerId, policyId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.DeactivateAuthorizationServerPolicy: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 

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

<a name="deactivateauthorizationserverpolicyrule"></a>
# **DeactivateAuthorizationServerPolicyRule**
> void DeactivateAuthorizationServerPolicyRule (string authServerId, string policyId, string ruleId)

Deactivate a Policy Rule

Deactivates an authorization server policy rule

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateAuthorizationServerPolicyRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy
            var ruleId = ruld3hJ7jZh4fn0st0g3;  // string | `id` of the Policy Rule

            try
            {
                // Deactivate a Policy Rule
                apiInstance.DeactivateAuthorizationServerPolicyRule(authServerId, policyId, ruleId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.DeactivateAuthorizationServerPolicyRule: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 
 **ruleId** | **string**| &#x60;id&#x60; of the Policy Rule | 

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

<a name="deleteassociatedserver"></a>
# **DeleteAssociatedServer**
> void DeleteAssociatedServer (string authServerId, string associatedServerId)

Delete an Associated Authorization Server

Deletes an associated authorization server

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteAssociatedServerExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var associatedServerId = aus6xt9jKPmCyn6kg0g4;  // string | `id` of the associated Authorization Server

            try
            {
                // Delete an Associated Authorization Server
                apiInstance.DeleteAssociatedServer(authServerId, associatedServerId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.DeleteAssociatedServer: " + e.Message );
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
 **associatedServerId** | **string**| &#x60;id&#x60; of the associated Authorization Server | 

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

<a name="deleteauthorizationserver"></a>
# **DeleteAuthorizationServer**
> void DeleteAuthorizationServer (string authServerId)

Delete an Authorization Server

Deletes an authorization server

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteAuthorizationServerExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server

            try
            {
                // Delete an Authorization Server
                apiInstance.DeleteAuthorizationServer(authServerId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.DeleteAuthorizationServer: " + e.Message );
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

<a name="deleteauthorizationserverpolicy"></a>
# **DeleteAuthorizationServerPolicy**
> void DeleteAuthorizationServerPolicy (string authServerId, string policyId)

Delete a Policy

Deletes a policy

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteAuthorizationServerPolicyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy

            try
            {
                // Delete a Policy
                apiInstance.DeleteAuthorizationServerPolicy(authServerId, policyId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.DeleteAuthorizationServerPolicy: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 

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

<a name="deleteauthorizationserverpolicyrule"></a>
# **DeleteAuthorizationServerPolicyRule**
> void DeleteAuthorizationServerPolicyRule (string authServerId, string policyId, string ruleId)

Delete a Policy Rule

Deletes a Policy Rule defined in the specified Custom Authorization Server and Policy

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteAuthorizationServerPolicyRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy
            var ruleId = ruld3hJ7jZh4fn0st0g3;  // string | `id` of the Policy Rule

            try
            {
                // Delete a Policy Rule
                apiInstance.DeleteAuthorizationServerPolicyRule(authServerId, policyId, ruleId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.DeleteAuthorizationServerPolicyRule: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 
 **ruleId** | **string**| &#x60;id&#x60; of the Policy Rule | 

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

<a name="deleteoauth2claim"></a>
# **DeleteOAuth2Claim**
> void DeleteOAuth2Claim (string authServerId, string claimId)

Delete a Custom Token Claim

Deletes a custom token claim

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteOAuth2ClaimExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var claimId = hNJ3Uk76xLagWkGx5W3N;  // string | `id` of Claim

            try
            {
                // Delete a Custom Token Claim
                apiInstance.DeleteOAuth2Claim(authServerId, claimId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.DeleteOAuth2Claim: " + e.Message );
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
 **claimId** | **string**| &#x60;id&#x60; of Claim | 

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

<a name="deleteoauth2scope"></a>
# **DeleteOAuth2Scope**
> void DeleteOAuth2Scope (string authServerId, string scopeId)

Delete a Custom Token Scope

Deletes a custom token scope

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteOAuth2ScopeExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var scopeId = 0TMRpCWXRKFjP7HiPFNM;  // string | `id` of Scope

            try
            {
                // Delete a Custom Token Scope
                apiInstance.DeleteOAuth2Scope(authServerId, scopeId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.DeleteOAuth2Scope: " + e.Message );
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
 **scopeId** | **string**| &#x60;id&#x60; of Scope | 

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

<a name="getauthorizationserver"></a>
# **GetAuthorizationServer**
> AuthorizationServer GetAuthorizationServer (string authServerId)

Retrieve an Authorization Server

Retrieves an authorization server

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetAuthorizationServerExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server

            try
            {
                // Retrieve an Authorization Server
                AuthorizationServer result = apiInstance.GetAuthorizationServer(authServerId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.GetAuthorizationServer: " + e.Message );
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

[**AuthorizationServer**](AuthorizationServer.md)

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

<a name="getauthorizationserverpolicy"></a>
# **GetAuthorizationServerPolicy**
> AuthorizationServerPolicy GetAuthorizationServerPolicy (string authServerId, string policyId)

Retrieve a Policy

Retrieves a policy

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetAuthorizationServerPolicyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy

            try
            {
                // Retrieve a Policy
                AuthorizationServerPolicy result = apiInstance.GetAuthorizationServerPolicy(authServerId, policyId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.GetAuthorizationServerPolicy: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 

### Return type

[**AuthorizationServerPolicy**](AuthorizationServerPolicy.md)

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

<a name="getauthorizationserverpolicyrule"></a>
# **GetAuthorizationServerPolicyRule**
> AuthorizationServerPolicyRule GetAuthorizationServerPolicyRule (string authServerId, string policyId, string ruleId)

Retrieve a Policy Rule

Retrieves a policy rule by `ruleId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetAuthorizationServerPolicyRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy
            var ruleId = ruld3hJ7jZh4fn0st0g3;  // string | `id` of the Policy Rule

            try
            {
                // Retrieve a Policy Rule
                AuthorizationServerPolicyRule result = apiInstance.GetAuthorizationServerPolicyRule(authServerId, policyId, ruleId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.GetAuthorizationServerPolicyRule: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 
 **ruleId** | **string**| &#x60;id&#x60; of the Policy Rule | 

### Return type

[**AuthorizationServerPolicyRule**](AuthorizationServerPolicyRule.md)

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

<a name="getoauth2claim"></a>
# **GetOAuth2Claim**
> OAuth2Claim GetOAuth2Claim (string authServerId, string claimId)

Retrieve a Custom Token Claim

Retrieves a custom token claim

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetOAuth2ClaimExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var claimId = hNJ3Uk76xLagWkGx5W3N;  // string | `id` of Claim

            try
            {
                // Retrieve a Custom Token Claim
                OAuth2Claim result = apiInstance.GetOAuth2Claim(authServerId, claimId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.GetOAuth2Claim: " + e.Message );
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
 **claimId** | **string**| &#x60;id&#x60; of Claim | 

### Return type

[**OAuth2Claim**](OAuth2Claim.md)

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

<a name="getoauth2scope"></a>
# **GetOAuth2Scope**
> OAuth2Scope GetOAuth2Scope (string authServerId, string scopeId)

Retrieve a Custom Token Scope

Retrieves a custom token scope

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetOAuth2ScopeExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var scopeId = 0TMRpCWXRKFjP7HiPFNM;  // string | `id` of Scope

            try
            {
                // Retrieve a Custom Token Scope
                OAuth2Scope result = apiInstance.GetOAuth2Scope(authServerId, scopeId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.GetOAuth2Scope: " + e.Message );
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
 **scopeId** | **string**| &#x60;id&#x60; of Scope | 

### Return type

[**OAuth2Scope**](OAuth2Scope.md)

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

<a name="getrefreshtokenforauthorizationserverandclient"></a>
# **GetRefreshTokenForAuthorizationServerAndClient**
> OAuth2RefreshToken GetRefreshTokenForAuthorizationServerAndClient (string authServerId, string clientId, string tokenId, string expand = null)

Retrieve a Refresh Token for a Client

Retrieves a refresh token for a client

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetRefreshTokenForAuthorizationServerAndClientExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | `client_id` of the app
            var tokenId = sHHSth53yJAyNSTQKDJZ;  // string | `id` of Token
            var expand = "expand_example";  // string |  (optional) 

            try
            {
                // Retrieve a Refresh Token for a Client
                OAuth2RefreshToken result = apiInstance.GetRefreshTokenForAuthorizationServerAndClient(authServerId, clientId, tokenId, expand);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.GetRefreshTokenForAuthorizationServerAndClient: " + e.Message );
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
 **clientId** | **string**| &#x60;client_id&#x60; of the app | 
 **tokenId** | **string**| &#x60;id&#x60; of Token | 
 **expand** | **string**|  | [optional] 

### Return type

[**OAuth2RefreshToken**](OAuth2RefreshToken.md)

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

<a name="listassociatedserversbytrustedtype"></a>
# **ListAssociatedServersByTrustedType**
> List&lt;AuthorizationServer&gt; ListAssociatedServersByTrustedType (string authServerId, bool? trusted = null, string q = null, int? limit = null, string after = null)

List all Associated Authorization Servers

Lists all associated authorization servers by trusted type for the given `authServerId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListAssociatedServersByTrustedTypeExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var trusted = true;  // bool? | Searches trusted authorization servers when true, or searches untrusted authorization servers when false (optional) 
            var q = "q_example";  // string | Searches the name or audience of the associated authorization servers (optional) 
            var limit = 200;  // int? | Specifies the number of results for a page (optional)  (default to 200)
            var after = "after_example";  // string | Specifies the pagination cursor for the next page of the associated authorization servers (optional) 

            try
            {
                // List all Associated Authorization Servers
                List<AuthorizationServer> result = apiInstance.ListAssociatedServersByTrustedType(authServerId, trusted, q, limit, after).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.ListAssociatedServersByTrustedType: " + e.Message );
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
 **trusted** | **bool?**| Searches trusted authorization servers when true, or searches untrusted authorization servers when false | [optional] 
 **q** | **string**| Searches the name or audience of the associated authorization servers | [optional] 
 **limit** | **int?**| Specifies the number of results for a page | [optional] [default to 200]
 **after** | **string**| Specifies the pagination cursor for the next page of the associated authorization servers | [optional] 

### Return type

[**List&lt;AuthorizationServer&gt;**](AuthorizationServer.md)

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

<a name="listauthorizationserverkeys"></a>
# **ListAuthorizationServerKeys**
> List&lt;JsonWebKey&gt; ListAuthorizationServerKeys (string authServerId)

List all Credential Keys

Lists all credential keys

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListAuthorizationServerKeysExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server

            try
            {
                // List all Credential Keys
                List<JsonWebKey> result = apiInstance.ListAuthorizationServerKeys(authServerId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.ListAuthorizationServerKeys: " + e.Message );
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

[**List&lt;JsonWebKey&gt;**](JsonWebKey.md)

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

<a name="listauthorizationserverpolicies"></a>
# **ListAuthorizationServerPolicies**
> List&lt;AuthorizationServerPolicy&gt; ListAuthorizationServerPolicies (string authServerId)

List all Policies

Lists all policies

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListAuthorizationServerPoliciesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server

            try
            {
                // List all Policies
                List<AuthorizationServerPolicy> result = apiInstance.ListAuthorizationServerPolicies(authServerId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.ListAuthorizationServerPolicies: " + e.Message );
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

[**List&lt;AuthorizationServerPolicy&gt;**](AuthorizationServerPolicy.md)

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

<a name="listauthorizationserverpolicyrules"></a>
# **ListAuthorizationServerPolicyRules**
> List&lt;AuthorizationServerPolicyRule&gt; ListAuthorizationServerPolicyRules (string authServerId, string policyId)

List all Policy Rules

Lists all policy rules for the specified Custom Authorization Server and Policy

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListAuthorizationServerPolicyRulesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy

            try
            {
                // List all Policy Rules
                List<AuthorizationServerPolicyRule> result = apiInstance.ListAuthorizationServerPolicyRules(authServerId, policyId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.ListAuthorizationServerPolicyRules: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 

### Return type

[**List&lt;AuthorizationServerPolicyRule&gt;**](AuthorizationServerPolicyRule.md)

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

<a name="listauthorizationservers"></a>
# **ListAuthorizationServers**
> List&lt;AuthorizationServer&gt; ListAuthorizationServers (string q = null, int? limit = null, string after = null)

List all Authorization Servers

Lists all authorization servers

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListAuthorizationServersExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var q = "q_example";  // string |  (optional) 
            var limit = 200;  // int? |  (optional)  (default to 200)
            var after = "after_example";  // string |  (optional) 

            try
            {
                // List all Authorization Servers
                List<AuthorizationServer> result = apiInstance.ListAuthorizationServers(q, limit, after).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.ListAuthorizationServers: " + e.Message );
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
 **limit** | **int?**|  | [optional] [default to 200]
 **after** | **string**|  | [optional] 

### Return type

[**List&lt;AuthorizationServer&gt;**](AuthorizationServer.md)

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

<a name="listoauth2claims"></a>
# **ListOAuth2Claims**
> List&lt;OAuth2Claim&gt; ListOAuth2Claims (string authServerId)

List all Custom Token Claims

Lists all custom token claims

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListOAuth2ClaimsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server

            try
            {
                // List all Custom Token Claims
                List<OAuth2Claim> result = apiInstance.ListOAuth2Claims(authServerId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.ListOAuth2Claims: " + e.Message );
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

[**List&lt;OAuth2Claim&gt;**](OAuth2Claim.md)

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

<a name="listoauth2clientsforauthorizationserver"></a>
# **ListOAuth2ClientsForAuthorizationServer**
> List&lt;OAuth2Client&gt; ListOAuth2ClientsForAuthorizationServer (string authServerId)

List all Clients

Lists all clients

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListOAuth2ClientsForAuthorizationServerExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server

            try
            {
                // List all Clients
                List<OAuth2Client> result = apiInstance.ListOAuth2ClientsForAuthorizationServer(authServerId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.ListOAuth2ClientsForAuthorizationServer: " + e.Message );
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

[**List&lt;OAuth2Client&gt;**](OAuth2Client.md)

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

<a name="listoauth2scopes"></a>
# **ListOAuth2Scopes**
> List&lt;OAuth2Scope&gt; ListOAuth2Scopes (string authServerId, string q = null, string filter = null, string cursor = null, int? limit = null)

List all Custom Token Scopes

Lists all custom token scopes

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListOAuth2ScopesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var q = "q_example";  // string |  (optional) 
            var filter = "filter_example";  // string |  (optional) 
            var cursor = "cursor_example";  // string |  (optional) 
            var limit = -1;  // int? |  (optional)  (default to -1)

            try
            {
                // List all Custom Token Scopes
                List<OAuth2Scope> result = apiInstance.ListOAuth2Scopes(authServerId, q, filter, cursor, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.ListOAuth2Scopes: " + e.Message );
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
 **q** | **string**|  | [optional] 
 **filter** | **string**|  | [optional] 
 **cursor** | **string**|  | [optional] 
 **limit** | **int?**|  | [optional] [default to -1]

### Return type

[**List&lt;OAuth2Scope&gt;**](OAuth2Scope.md)

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

<a name="listrefreshtokensforauthorizationserverandclient"></a>
# **ListRefreshTokensForAuthorizationServerAndClient**
> List&lt;OAuth2RefreshToken&gt; ListRefreshTokensForAuthorizationServerAndClient (string authServerId, string clientId, string expand = null, string after = null, int? limit = null)

List all Refresh Tokens for a Client

Lists all refresh tokens for a client

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListRefreshTokensForAuthorizationServerAndClientExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | `client_id` of the app
            var expand = "expand_example";  // string |  (optional) 
            var after = "after_example";  // string |  (optional) 
            var limit = -1;  // int? |  (optional)  (default to -1)

            try
            {
                // List all Refresh Tokens for a Client
                List<OAuth2RefreshToken> result = apiInstance.ListRefreshTokensForAuthorizationServerAndClient(authServerId, clientId, expand, after, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.ListRefreshTokensForAuthorizationServerAndClient: " + e.Message );
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
 **clientId** | **string**| &#x60;client_id&#x60; of the app | 
 **expand** | **string**|  | [optional] 
 **after** | **string**|  | [optional] 
 **limit** | **int?**|  | [optional] [default to -1]

### Return type

[**List&lt;OAuth2RefreshToken&gt;**](OAuth2RefreshToken.md)

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

<a name="replaceauthorizationserver"></a>
# **ReplaceAuthorizationServer**
> AuthorizationServer ReplaceAuthorizationServer (string authServerId, AuthorizationServer authorizationServer)

Replace an Authorization Server

Replaces an authorization server

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceAuthorizationServerExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var authorizationServer = new AuthorizationServer(); // AuthorizationServer | 

            try
            {
                // Replace an Authorization Server
                AuthorizationServer result = apiInstance.ReplaceAuthorizationServer(authServerId, authorizationServer);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.ReplaceAuthorizationServer: " + e.Message );
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
 **authorizationServer** | [**AuthorizationServer**](AuthorizationServer.md)|  | 

### Return type

[**AuthorizationServer**](AuthorizationServer.md)

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

<a name="replaceauthorizationserverpolicy"></a>
# **ReplaceAuthorizationServerPolicy**
> AuthorizationServerPolicy ReplaceAuthorizationServerPolicy (string authServerId, string policyId, AuthorizationServerPolicy policy)

Replace a Policy

Replaces a policy

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceAuthorizationServerPolicyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy
            var policy = new AuthorizationServerPolicy(); // AuthorizationServerPolicy | 

            try
            {
                // Replace a Policy
                AuthorizationServerPolicy result = apiInstance.ReplaceAuthorizationServerPolicy(authServerId, policyId, policy);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.ReplaceAuthorizationServerPolicy: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 
 **policy** | [**AuthorizationServerPolicy**](AuthorizationServerPolicy.md)|  | 

### Return type

[**AuthorizationServerPolicy**](AuthorizationServerPolicy.md)

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

<a name="replaceauthorizationserverpolicyrule"></a>
# **ReplaceAuthorizationServerPolicyRule**
> AuthorizationServerPolicyRule ReplaceAuthorizationServerPolicyRule (string authServerId, string policyId, string ruleId, AuthorizationServerPolicyRule policyRule)

Replace a Policy Rule

Replaces the configuration of the Policy Rule defined in the specified Custom Authorization Server and Policy

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceAuthorizationServerPolicyRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy
            var ruleId = ruld3hJ7jZh4fn0st0g3;  // string | `id` of the Policy Rule
            var policyRule = new AuthorizationServerPolicyRule(); // AuthorizationServerPolicyRule | 

            try
            {
                // Replace a Policy Rule
                AuthorizationServerPolicyRule result = apiInstance.ReplaceAuthorizationServerPolicyRule(authServerId, policyId, ruleId, policyRule);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.ReplaceAuthorizationServerPolicyRule: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 
 **ruleId** | **string**| &#x60;id&#x60; of the Policy Rule | 
 **policyRule** | [**AuthorizationServerPolicyRule**](AuthorizationServerPolicyRule.md)|  | 

### Return type

[**AuthorizationServerPolicyRule**](AuthorizationServerPolicyRule.md)

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

<a name="replaceoauth2claim"></a>
# **ReplaceOAuth2Claim**
> OAuth2Claim ReplaceOAuth2Claim (string authServerId, string claimId, OAuth2Claim oAuth2Claim)

Replace a Custom Token Claim

Replaces a custom token claim

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceOAuth2ClaimExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var claimId = hNJ3Uk76xLagWkGx5W3N;  // string | `id` of Claim
            var oAuth2Claim = new OAuth2Claim(); // OAuth2Claim | 

            try
            {
                // Replace a Custom Token Claim
                OAuth2Claim result = apiInstance.ReplaceOAuth2Claim(authServerId, claimId, oAuth2Claim);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.ReplaceOAuth2Claim: " + e.Message );
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
 **claimId** | **string**| &#x60;id&#x60; of Claim | 
 **oAuth2Claim** | [**OAuth2Claim**](OAuth2Claim.md)|  | 

### Return type

[**OAuth2Claim**](OAuth2Claim.md)

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

<a name="replaceoauth2scope"></a>
# **ReplaceOAuth2Scope**
> OAuth2Scope ReplaceOAuth2Scope (string authServerId, string scopeId, OAuth2Scope oAuth2Scope)

Replace a Custom Token Scope

Replaces a custom token scope

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceOAuth2ScopeExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var scopeId = 0TMRpCWXRKFjP7HiPFNM;  // string | `id` of Scope
            var oAuth2Scope = new OAuth2Scope(); // OAuth2Scope | 

            try
            {
                // Replace a Custom Token Scope
                OAuth2Scope result = apiInstance.ReplaceOAuth2Scope(authServerId, scopeId, oAuth2Scope);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.ReplaceOAuth2Scope: " + e.Message );
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
 **scopeId** | **string**| &#x60;id&#x60; of Scope | 
 **oAuth2Scope** | [**OAuth2Scope**](OAuth2Scope.md)|  | 

### Return type

[**OAuth2Scope**](OAuth2Scope.md)

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

<a name="revokerefreshtokenforauthorizationserverandclient"></a>
# **RevokeRefreshTokenForAuthorizationServerAndClient**
> void RevokeRefreshTokenForAuthorizationServerAndClient (string authServerId, string clientId, string tokenId)

Revoke a Refresh Token for a Client

Revokes a refresh token for a client

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RevokeRefreshTokenForAuthorizationServerAndClientExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | `client_id` of the app
            var tokenId = sHHSth53yJAyNSTQKDJZ;  // string | `id` of Token

            try
            {
                // Revoke a Refresh Token for a Client
                apiInstance.RevokeRefreshTokenForAuthorizationServerAndClient(authServerId, clientId, tokenId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.RevokeRefreshTokenForAuthorizationServerAndClient: " + e.Message );
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
 **clientId** | **string**| &#x60;client_id&#x60; of the app | 
 **tokenId** | **string**| &#x60;id&#x60; of Token | 

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

<a name="revokerefreshtokensforauthorizationserverandclient"></a>
# **RevokeRefreshTokensForAuthorizationServerAndClient**
> void RevokeRefreshTokensForAuthorizationServerAndClient (string authServerId, string clientId)

Revoke all Refresh Tokens for a Client

Revokes all refresh tokens for a client

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RevokeRefreshTokensForAuthorizationServerAndClientExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var clientId = 52Uy4BUWVBOjFItcg2jWsmnd83Ad8dD;  // string | `client_id` of the app

            try
            {
                // Revoke all Refresh Tokens for a Client
                apiInstance.RevokeRefreshTokensForAuthorizationServerAndClient(authServerId, clientId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.RevokeRefreshTokensForAuthorizationServerAndClient: " + e.Message );
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
 **clientId** | **string**| &#x60;client_id&#x60; of the app | 

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

<a name="rotateauthorizationserverkeys"></a>
# **RotateAuthorizationServerKeys**
> List&lt;JsonWebKey&gt; RotateAuthorizationServerKeys (string authServerId, JwkUse use)

Rotate all Credential Keys

Rotates all credential keys

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class RotateAuthorizationServerKeysExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AuthorizationServerApi(config);
            var authServerId = GeGRTEr7f3yu2n7grw22;  // string | `id` of the Authorization Server
            var use = new JwkUse(); // JwkUse | 

            try
            {
                // Rotate all Credential Keys
                List<JsonWebKey> result = apiInstance.RotateAuthorizationServerKeys(authServerId, use).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthorizationServerApi.RotateAuthorizationServerKeys: " + e.Message );
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
 **use** | [**JwkUse**](JwkUse.md)|  | 

### Return type

[**List&lt;JsonWebKey&gt;**](JsonWebKey.md)

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

