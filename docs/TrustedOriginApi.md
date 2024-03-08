# Okta.Sdk.Api.TrustedOriginApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActivateTrustedOrigin**](TrustedOriginApi.md#activatetrustedorigin) | **POST** /api/v1/trustedOrigins/{trustedOriginId}/lifecycle/activate | Activate a Trusted Origin
[**CreateTrustedOrigin**](TrustedOriginApi.md#createtrustedorigin) | **POST** /api/v1/trustedOrigins | Create a Trusted Origin
[**DeactivateTrustedOrigin**](TrustedOriginApi.md#deactivatetrustedorigin) | **POST** /api/v1/trustedOrigins/{trustedOriginId}/lifecycle/deactivate | Deactivate a Trusted Origin
[**DeleteTrustedOrigin**](TrustedOriginApi.md#deletetrustedorigin) | **DELETE** /api/v1/trustedOrigins/{trustedOriginId} | Delete a Trusted Origin
[**GetTrustedOrigin**](TrustedOriginApi.md#gettrustedorigin) | **GET** /api/v1/trustedOrigins/{trustedOriginId} | Retrieve a Trusted Origin
[**ListTrustedOrigins**](TrustedOriginApi.md#listtrustedorigins) | **GET** /api/v1/trustedOrigins | List all Trusted Origins
[**ReplaceTrustedOrigin**](TrustedOriginApi.md#replacetrustedorigin) | **PUT** /api/v1/trustedOrigins/{trustedOriginId} | Replace a Trusted Origin


<a name="activatetrustedorigin"></a>
# **ActivateTrustedOrigin**
> TrustedOrigin ActivateTrustedOrigin (string trustedOriginId)

Activate a Trusted Origin

Activates a trusted origin

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
            var trustedOriginId = 7j2PkU1nyNIDe26ZNufR;  // string | `id` of the Trusted Origin

            try
            {
                // Activate a Trusted Origin
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
 **trustedOriginId** | **string**| &#x60;id&#x60; of the Trusted Origin | 

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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createtrustedorigin"></a>
# **CreateTrustedOrigin**
> TrustedOrigin CreateTrustedOrigin (TrustedOrigin trustedOrigin)

Create a Trusted Origin

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
            var trustedOrigin = new TrustedOrigin(); // TrustedOrigin | 

            try
            {
                // Create a Trusted Origin
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
| **400** |  |  -  |
| **403** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deactivatetrustedorigin"></a>
# **DeactivateTrustedOrigin**
> TrustedOrigin DeactivateTrustedOrigin (string trustedOriginId)

Deactivate a Trusted Origin

Deactivates a trusted origin

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
            var trustedOriginId = 7j2PkU1nyNIDe26ZNufR;  // string | `id` of the Trusted Origin

            try
            {
                // Deactivate a Trusted Origin
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
 **trustedOriginId** | **string**| &#x60;id&#x60; of the Trusted Origin | 

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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletetrustedorigin"></a>
# **DeleteTrustedOrigin**
> void DeleteTrustedOrigin (string trustedOriginId)

Delete a Trusted Origin

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
            var trustedOriginId = 7j2PkU1nyNIDe26ZNufR;  // string | `id` of the Trusted Origin

            try
            {
                // Delete a Trusted Origin
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
 **trustedOriginId** | **string**| &#x60;id&#x60; of the Trusted Origin | 

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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="gettrustedorigin"></a>
# **GetTrustedOrigin**
> TrustedOrigin GetTrustedOrigin (string trustedOriginId)

Retrieve a Trusted Origin

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
            var trustedOriginId = 7j2PkU1nyNIDe26ZNufR;  // string | `id` of the Trusted Origin

            try
            {
                // Retrieve a Trusted Origin
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
 **trustedOriginId** | **string**| &#x60;id&#x60; of the Trusted Origin | 

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
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listtrustedorigins"></a>
# **ListTrustedOrigins**
> List&lt;TrustedOrigin&gt; ListTrustedOrigins (string q = null, string filter = null, string after = null, int? limit = null)

List all Trusted Origins

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
            var q = "q_example";  // string |  (optional) 
            var filter = "filter_example";  // string |  (optional) 
            var after = "after_example";  // string |  (optional) 
            var limit = -1;  // int? |  (optional)  (default to -1)

            try
            {
                // List all Trusted Origins
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
 **q** | **string**|  | [optional] 
 **filter** | **string**|  | [optional] 
 **after** | **string**|  | [optional] 
 **limit** | **int?**|  | [optional] [default to -1]

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
| **403** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacetrustedorigin"></a>
# **ReplaceTrustedOrigin**
> TrustedOrigin ReplaceTrustedOrigin (string trustedOriginId, TrustedOrigin trustedOrigin)

Replace a Trusted Origin

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
            var trustedOriginId = 7j2PkU1nyNIDe26ZNufR;  // string | `id` of the Trusted Origin
            var trustedOrigin = new TrustedOrigin(); // TrustedOrigin | 

            try
            {
                // Replace a Trusted Origin
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
 **trustedOriginId** | **string**| &#x60;id&#x60; of the Trusted Origin | 
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
| **400** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **429** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

