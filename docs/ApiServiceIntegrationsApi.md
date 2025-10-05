# Okta.Sdk.Api.ApiServiceIntegrationsApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateApiServiceIntegrationInstanceSecret**](ApiServiceIntegrationsApi.md#activateapiserviceintegrationinstancesecret) | **POST** /integrations/api/v1/api-services/{apiServiceId}/credentials/secrets/{secretId}/lifecycle/activate | Activate an API service integration instance secret
[**CreateApiServiceIntegrationInstance**](ApiServiceIntegrationsApi.md#createapiserviceintegrationinstance) | **POST** /integrations/api/v1/api-services | Create an API service integration instance
[**CreateApiServiceIntegrationInstanceSecret**](ApiServiceIntegrationsApi.md#createapiserviceintegrationinstancesecret) | **POST** /integrations/api/v1/api-services/{apiServiceId}/credentials/secrets | Create an API service integration instance secret
[**DeactivateApiServiceIntegrationInstanceSecret**](ApiServiceIntegrationsApi.md#deactivateapiserviceintegrationinstancesecret) | **POST** /integrations/api/v1/api-services/{apiServiceId}/credentials/secrets/{secretId}/lifecycle/deactivate | Deactivate an API service integration instance secret
[**DeleteApiServiceIntegrationInstance**](ApiServiceIntegrationsApi.md#deleteapiserviceintegrationinstance) | **DELETE** /integrations/api/v1/api-services/{apiServiceId} | Delete an API service integration instance
[**DeleteApiServiceIntegrationInstanceSecret**](ApiServiceIntegrationsApi.md#deleteapiserviceintegrationinstancesecret) | **DELETE** /integrations/api/v1/api-services/{apiServiceId}/credentials/secrets/{secretId} | Delete an API service integration instance secret
[**GetApiServiceIntegrationInstance**](ApiServiceIntegrationsApi.md#getapiserviceintegrationinstance) | **GET** /integrations/api/v1/api-services/{apiServiceId} | Retrieve an API service integration instance
[**ListApiServiceIntegrationInstanceSecrets**](ApiServiceIntegrationsApi.md#listapiserviceintegrationinstancesecrets) | **GET** /integrations/api/v1/api-services/{apiServiceId}/credentials/secrets | List all API service integration instance secrets
[**ListApiServiceIntegrationInstances**](ApiServiceIntegrationsApi.md#listapiserviceintegrationinstances) | **GET** /integrations/api/v1/api-services | List all API service integration instances


<a name="activateapiserviceintegrationinstancesecret"></a>
# **ActivateApiServiceIntegrationInstanceSecret**
> APIServiceIntegrationInstanceSecret ActivateApiServiceIntegrationInstanceSecret (string apiServiceId, string secretId)

Activate an API service integration instance secret

Activates an API Service Integration instance Secret by `secretId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateApiServiceIntegrationInstanceSecretExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApiServiceIntegrationsApi(config);
            var apiServiceId = 000lr2rLjZ6NsGn1P0g3;  // string | `id` of the API Service Integration instance
            var secretId = ocs2f4zrZbs8nUa7p0g4;  // string | `id` of the API Service Integration instance Secret

            try
            {
                // Activate an API service integration instance secret
                APIServiceIntegrationInstanceSecret result = apiInstance.ActivateApiServiceIntegrationInstanceSecret(apiServiceId, secretId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApiServiceIntegrationsApi.ActivateApiServiceIntegrationInstanceSecret: " + e.Message );
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
 **apiServiceId** | **string**| &#x60;id&#x60; of the API Service Integration instance | 
 **secretId** | **string**| &#x60;id&#x60; of the API Service Integration instance Secret | 

### Return type

[**APIServiceIntegrationInstanceSecret**](APIServiceIntegrationInstanceSecret.md)

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

<a name="createapiserviceintegrationinstance"></a>
# **CreateApiServiceIntegrationInstance**
> PostAPIServiceIntegrationInstance CreateApiServiceIntegrationInstance (PostAPIServiceIntegrationInstanceRequest postAPIServiceIntegrationInstanceRequest)

Create an API service integration instance

Creates and authorizes an API Service Integration instance

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateApiServiceIntegrationInstanceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApiServiceIntegrationsApi(config);
            var postAPIServiceIntegrationInstanceRequest = new PostAPIServiceIntegrationInstanceRequest(); // PostAPIServiceIntegrationInstanceRequest | 

            try
            {
                // Create an API service integration instance
                PostAPIServiceIntegrationInstance result = apiInstance.CreateApiServiceIntegrationInstance(postAPIServiceIntegrationInstanceRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApiServiceIntegrationsApi.CreateApiServiceIntegrationInstance: " + e.Message );
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
 **postAPIServiceIntegrationInstanceRequest** | [**PostAPIServiceIntegrationInstanceRequest**](PostAPIServiceIntegrationInstanceRequest.md)|  | 

### Return type

[**PostAPIServiceIntegrationInstance**](PostAPIServiceIntegrationInstance.md)

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

<a name="createapiserviceintegrationinstancesecret"></a>
# **CreateApiServiceIntegrationInstanceSecret**
> APIServiceIntegrationInstanceSecret CreateApiServiceIntegrationInstanceSecret (string apiServiceId)

Create an API service integration instance secret

Creates an API Service Integration instance Secret object with a new active client secret. You can create up to two Secret objects. An error is returned if you attempt to create more than two Secret objects.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateApiServiceIntegrationInstanceSecretExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApiServiceIntegrationsApi(config);
            var apiServiceId = 000lr2rLjZ6NsGn1P0g3;  // string | `id` of the API Service Integration instance

            try
            {
                // Create an API service integration instance secret
                APIServiceIntegrationInstanceSecret result = apiInstance.CreateApiServiceIntegrationInstanceSecret(apiServiceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApiServiceIntegrationsApi.CreateApiServiceIntegrationInstanceSecret: " + e.Message );
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
 **apiServiceId** | **string**| &#x60;id&#x60; of the API Service Integration instance | 

### Return type

[**APIServiceIntegrationInstanceSecret**](APIServiceIntegrationInstanceSecret.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
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

<a name="deactivateapiserviceintegrationinstancesecret"></a>
# **DeactivateApiServiceIntegrationInstanceSecret**
> APIServiceIntegrationInstanceSecret DeactivateApiServiceIntegrationInstanceSecret (string apiServiceId, string secretId)

Deactivate an API service integration instance secret

Deactivates an API Service Integration instance Secret by `secretId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateApiServiceIntegrationInstanceSecretExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApiServiceIntegrationsApi(config);
            var apiServiceId = 000lr2rLjZ6NsGn1P0g3;  // string | `id` of the API Service Integration instance
            var secretId = ocs2f4zrZbs8nUa7p0g4;  // string | `id` of the API Service Integration instance Secret

            try
            {
                // Deactivate an API service integration instance secret
                APIServiceIntegrationInstanceSecret result = apiInstance.DeactivateApiServiceIntegrationInstanceSecret(apiServiceId, secretId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApiServiceIntegrationsApi.DeactivateApiServiceIntegrationInstanceSecret: " + e.Message );
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
 **apiServiceId** | **string**| &#x60;id&#x60; of the API Service Integration instance | 
 **secretId** | **string**| &#x60;id&#x60; of the API Service Integration instance Secret | 

### Return type

[**APIServiceIntegrationInstanceSecret**](APIServiceIntegrationInstanceSecret.md)

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

<a name="deleteapiserviceintegrationinstance"></a>
# **DeleteApiServiceIntegrationInstance**
> void DeleteApiServiceIntegrationInstance (string apiServiceId)

Delete an API service integration instance

Deletes an API Service Integration instance by `id`. This operation also revokes access to scopes that were previously granted to this API Service Integration instance.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteApiServiceIntegrationInstanceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApiServiceIntegrationsApi(config);
            var apiServiceId = 000lr2rLjZ6NsGn1P0g3;  // string | `id` of the API Service Integration instance

            try
            {
                // Delete an API service integration instance
                apiInstance.DeleteApiServiceIntegrationInstance(apiServiceId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApiServiceIntegrationsApi.DeleteApiServiceIntegrationInstance: " + e.Message );
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
 **apiServiceId** | **string**| &#x60;id&#x60; of the API Service Integration instance | 

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

<a name="deleteapiserviceintegrationinstancesecret"></a>
# **DeleteApiServiceIntegrationInstanceSecret**
> void DeleteApiServiceIntegrationInstanceSecret (string apiServiceId, string secretId)

Delete an API service integration instance secret

Deletes an API Service Integration instance Secret by `secretId`. You can only delete an inactive Secret.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteApiServiceIntegrationInstanceSecretExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApiServiceIntegrationsApi(config);
            var apiServiceId = 000lr2rLjZ6NsGn1P0g3;  // string | `id` of the API Service Integration instance
            var secretId = ocs2f4zrZbs8nUa7p0g4;  // string | `id` of the API Service Integration instance Secret

            try
            {
                // Delete an API service integration instance secret
                apiInstance.DeleteApiServiceIntegrationInstanceSecret(apiServiceId, secretId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApiServiceIntegrationsApi.DeleteApiServiceIntegrationInstanceSecret: " + e.Message );
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
 **apiServiceId** | **string**| &#x60;id&#x60; of the API Service Integration instance | 
 **secretId** | **string**| &#x60;id&#x60; of the API Service Integration instance Secret | 

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

<a name="getapiserviceintegrationinstance"></a>
# **GetApiServiceIntegrationInstance**
> APIServiceIntegrationInstance GetApiServiceIntegrationInstance (string apiServiceId)

Retrieve an API service integration instance

Retrieves an API Service Integration instance by `id`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetApiServiceIntegrationInstanceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApiServiceIntegrationsApi(config);
            var apiServiceId = 000lr2rLjZ6NsGn1P0g3;  // string | `id` of the API Service Integration instance

            try
            {
                // Retrieve an API service integration instance
                APIServiceIntegrationInstance result = apiInstance.GetApiServiceIntegrationInstance(apiServiceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApiServiceIntegrationsApi.GetApiServiceIntegrationInstance: " + e.Message );
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
 **apiServiceId** | **string**| &#x60;id&#x60; of the API Service Integration instance | 

### Return type

[**APIServiceIntegrationInstance**](APIServiceIntegrationInstance.md)

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

<a name="listapiserviceintegrationinstancesecrets"></a>
# **ListApiServiceIntegrationInstanceSecrets**
> List&lt;APIServiceIntegrationInstanceSecret&gt; ListApiServiceIntegrationInstanceSecrets (string apiServiceId)

List all API service integration instance secrets

Lists all client secrets for an API Service Integration instance by `apiServiceId`

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListApiServiceIntegrationInstanceSecretsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApiServiceIntegrationsApi(config);
            var apiServiceId = 000lr2rLjZ6NsGn1P0g3;  // string | `id` of the API Service Integration instance

            try
            {
                // List all API service integration instance secrets
                List<APIServiceIntegrationInstanceSecret> result = apiInstance.ListApiServiceIntegrationInstanceSecrets(apiServiceId).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApiServiceIntegrationsApi.ListApiServiceIntegrationInstanceSecrets: " + e.Message );
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
 **apiServiceId** | **string**| &#x60;id&#x60; of the API Service Integration instance | 

### Return type

[**List&lt;APIServiceIntegrationInstanceSecret&gt;**](APIServiceIntegrationInstanceSecret.md)

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

<a name="listapiserviceintegrationinstances"></a>
# **ListApiServiceIntegrationInstances**
> List&lt;APIServiceIntegrationInstance&gt; ListApiServiceIntegrationInstances (string after = null)

List all API service integration instances

Lists all API Service Integration instances with a pagination option

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListApiServiceIntegrationInstancesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApiServiceIntegrationsApi(config);
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 

            try
            {
                // List all API service integration instances
                List<APIServiceIntegrationInstance> result = apiInstance.ListApiServiceIntegrationInstances(after).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApiServiceIntegrationsApi.ListApiServiceIntegrationInstances: " + e.Message );
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
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 

### Return type

[**List&lt;APIServiceIntegrationInstance&gt;**](APIServiceIntegrationInstance.md)

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
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

