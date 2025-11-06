# Okta.Sdk.Api.TrustedOriginApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateTrustedOrigin**](TrustedOriginApi.md#activatetrustedorigin) | **POST** /api/v1/trustedOrigins/{trustedOriginId}/lifecycle/activate | Activate a trusted origin
[**CreateTrustedOrigin**](TrustedOriginApi.md#createtrustedorigin) | **POST** /api/v1/trustedOrigins | Create a trusted origin
[**DeactivateTrustedOrigin**](TrustedOriginApi.md#deactivatetrustedorigin) | **POST** /api/v1/trustedOrigins/{trustedOriginId}/lifecycle/deactivate | Deactivate a trusted origin
[**DeleteTrustedOrigin**](TrustedOriginApi.md#deletetrustedorigin) | **DELETE** /api/v1/trustedOrigins/{trustedOriginId} | Delete a trusted origin
[**GetTrustedOrigin**](TrustedOriginApi.md#gettrustedorigin) | **GET** /api/v1/trustedOrigins/{trustedOriginId} | Retrieve a trusted origin
[**ListTrustedOrigins**](TrustedOriginApi.md#listtrustedorigins) | **GET** /api/v1/trustedOrigins | List all trusted origins
[**ReplaceTrustedOrigin**](TrustedOriginApi.md#replacetrustedorigin) | **PUT** /api/v1/trustedOrigins/{trustedOriginId} | Replace a trusted origin


<a name="activatetrustedorigin"></a>
# **ActivateTrustedOrigin**
> TrustedOrigin ActivateTrustedOrigin (string trustedOriginId)

Activate a trusted origin

Activates a trusted origin. Sets the `status` to `ACTIVE`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ActivateTrustedOriginExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TrustedOriginApi(config);
            var trustedOriginId = 7j2PkU1nyNIDe26ZNufR;  // string | `id` of the trusted origin

            try
            {
                // Activate a trusted origin
                TrustedOrigin result = apiInstance.ActivateTrustedOrigin(trustedOriginId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TrustedOriginApi.ActivateTrustedOrigin: " + e.Message );
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
 **trustedOriginId** | **string**| &#x60;id&#x60; of the trusted origin | 

### Return type

[**TrustedOrigin**](TrustedOrigin.md)

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

<a name="createtrustedorigin"></a>
# **CreateTrustedOrigin**
> TrustedOrigin CreateTrustedOrigin (TrustedOriginWrite trustedOrigin)

Create a trusted origin

Creates a trusted origin

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateTrustedOriginExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TrustedOriginApi(config);
            var trustedOrigin = new TrustedOriginWrite(); // TrustedOriginWrite | 

            try
            {
                // Create a trusted origin
                TrustedOrigin result = apiInstance.CreateTrustedOrigin(trustedOrigin);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TrustedOriginApi.CreateTrustedOrigin: " + e.Message );
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
 **trustedOrigin** | [**TrustedOriginWrite**](TrustedOriginWrite.md)|  | 

### Return type

[**TrustedOrigin**](TrustedOrigin.md)

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
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivatetrustedorigin"></a>
# **DeactivateTrustedOrigin**
> TrustedOrigin DeactivateTrustedOrigin (string trustedOriginId)

Deactivate a trusted origin

Deactivates a trusted origin. Sets the `status` to `INACTIVE`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeactivateTrustedOriginExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TrustedOriginApi(config);
            var trustedOriginId = 7j2PkU1nyNIDe26ZNufR;  // string | `id` of the trusted origin

            try
            {
                // Deactivate a trusted origin
                TrustedOrigin result = apiInstance.DeactivateTrustedOrigin(trustedOriginId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TrustedOriginApi.DeactivateTrustedOrigin: " + e.Message );
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
 **trustedOriginId** | **string**| &#x60;id&#x60; of the trusted origin | 

### Return type

[**TrustedOrigin**](TrustedOrigin.md)

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

<a name="deletetrustedorigin"></a>
# **DeleteTrustedOrigin**
> void DeleteTrustedOrigin (string trustedOriginId)

Delete a trusted origin

Deletes a trusted origin

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteTrustedOriginExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TrustedOriginApi(config);
            var trustedOriginId = 7j2PkU1nyNIDe26ZNufR;  // string | `id` of the trusted origin

            try
            {
                // Delete a trusted origin
                apiInstance.DeleteTrustedOrigin(trustedOriginId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TrustedOriginApi.DeleteTrustedOrigin: " + e.Message );
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
 **trustedOriginId** | **string**| &#x60;id&#x60; of the trusted origin | 

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
| **204** | Success |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="gettrustedorigin"></a>
# **GetTrustedOrigin**
> TrustedOrigin GetTrustedOrigin (string trustedOriginId)

Retrieve a trusted origin

Retrieves a trusted origin

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetTrustedOriginExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TrustedOriginApi(config);
            var trustedOriginId = 7j2PkU1nyNIDe26ZNufR;  // string | `id` of the trusted origin

            try
            {
                // Retrieve a trusted origin
                TrustedOrigin result = apiInstance.GetTrustedOrigin(trustedOriginId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TrustedOriginApi.GetTrustedOrigin: " + e.Message );
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
 **trustedOriginId** | **string**| &#x60;id&#x60; of the trusted origin | 

### Return type

[**TrustedOrigin**](TrustedOrigin.md)

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

<a name="listtrustedorigins"></a>
# **ListTrustedOrigins**
> List&lt;TrustedOrigin&gt; ListTrustedOrigins (string q = null, string filter = null, string after = null, int? limit = null)

List all trusted origins

Lists all trusted origins

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListTrustedOriginsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TrustedOriginApi(config);
            var q = "q_example";  // string | A search string that prefix matches against the `name` and `origin` (optional) 
            var filter = name eq "Example trusted origin";  // string | [Filter](https://developer.okta.com/docs/api/#filter) trusted origins with a supported expression for a subset of properties. You can filter on the following properties: `name`, `origin`, `status`, and `type` (type of scopes).  (optional) 
            var after = "after_example";  // string | After cursor provided by a prior request (optional) 
            var limit = 20;  // int? | Specifies the number of results (optional)  (default to 20)

            try
            {
                // List all trusted origins
                List<TrustedOrigin> result = apiInstance.ListTrustedOrigins(q, filter, after, limit).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TrustedOriginApi.ListTrustedOrigins: " + e.Message );
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
 **q** | **string**| A search string that prefix matches against the &#x60;name&#x60; and &#x60;origin&#x60; | [optional] 
 **filter** | **string**| [Filter](https://developer.okta.com/docs/api/#filter) trusted origins with a supported expression for a subset of properties. You can filter on the following properties: &#x60;name&#x60;, &#x60;origin&#x60;, &#x60;status&#x60;, and &#x60;type&#x60; (type of scopes).  | [optional] 
 **after** | **string**| After cursor provided by a prior request | [optional] 
 **limit** | **int?**| Specifies the number of results | [optional] [default to 20]

### Return type

[**List&lt;TrustedOrigin&gt;**](TrustedOrigin.md)

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

<a name="replacetrustedorigin"></a>
# **ReplaceTrustedOrigin**
> TrustedOrigin ReplaceTrustedOrigin (string trustedOriginId, TrustedOrigin trustedOrigin)

Replace a trusted origin

Replaces a trusted origin

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceTrustedOriginExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TrustedOriginApi(config);
            var trustedOriginId = 7j2PkU1nyNIDe26ZNufR;  // string | `id` of the trusted origin
            var trustedOrigin = new TrustedOrigin(); // TrustedOrigin | 

            try
            {
                // Replace a trusted origin
                TrustedOrigin result = apiInstance.ReplaceTrustedOrigin(trustedOriginId, trustedOrigin);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TrustedOriginApi.ReplaceTrustedOrigin: " + e.Message );
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
 **trustedOriginId** | **string**| &#x60;id&#x60; of the trusted origin | 
 **trustedOrigin** | [**TrustedOrigin**](TrustedOrigin.md)|  | 

### Return type

[**TrustedOrigin**](TrustedOrigin.md)

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

