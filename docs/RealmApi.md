# Okta.Sdk.Api.RealmApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateRealm**](RealmApi.md#createrealm) | **POST** /api/v1/realms | Create a Realm
[**DeleteRealm**](RealmApi.md#deleterealm) | **DELETE** /api/v1/realms/{realmId} | Delete a Realm
[**GetRealm**](RealmApi.md#getrealm) | **GET** /api/v1/realms/{realmId} | Retrieve a Realm
[**ListRealms**](RealmApi.md#listrealms) | **GET** /api/v1/realms | List all Realms
[**ReplaceRealm**](RealmApi.md#replacerealm) | **PUT** /api/v1/realms/{realmId} | Replace the realm profile


<a name="createrealm"></a>
# **CreateRealm**
> Realm CreateRealm (CreateRealmRequest body)

Create a Realm

Creates a new Realm

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateRealmExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RealmApi(config);
            var body = new CreateRealmRequest(); // CreateRealmRequest | 

            try
            {
                // Create a Realm
                Realm result = apiInstance.CreateRealm(body);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RealmApi.CreateRealm: " + e.Message );
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
 **body** | [**CreateRealmRequest**](CreateRealmRequest.md)|  | 

### Return type

[**Realm**](Realm.md)

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

<a name="deleterealm"></a>
# **DeleteRealm**
> void DeleteRealm (string realmId)

Delete a Realm

Deletes a Realm permanently. This operation can only be performed after disassociating other entities like Users and Identity Providers from a Realm.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteRealmExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RealmApi(config);
            var realmId = vvrcFogtKCrK9aYq3fgV;  // string | `id` of the Realm

            try
            {
                // Delete a Realm
                apiInstance.DeleteRealm(realmId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RealmApi.DeleteRealm: " + e.Message );
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
 **realmId** | **string**| &#x60;id&#x60; of the Realm | 

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
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getrealm"></a>
# **GetRealm**
> Realm GetRealm (string realmId)

Retrieve a Realm

Retrieves a Realm

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetRealmExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RealmApi(config);
            var realmId = vvrcFogtKCrK9aYq3fgV;  // string | `id` of the Realm

            try
            {
                // Retrieve a Realm
                Realm result = apiInstance.GetRealm(realmId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RealmApi.GetRealm: " + e.Message );
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
 **realmId** | **string**| &#x60;id&#x60; of the Realm | 

### Return type

[**Realm**](Realm.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
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

<a name="listrealms"></a>
# **ListRealms**
> List&lt;Realm&gt; ListRealms (int? limit = null, string after = null, string search = null, string sortBy = null, string sortOrder = null)

List all Realms

Lists all Realms

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListRealmsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RealmApi(config);
            var limit = 200;  // int? | Specifies the number of results returned. Defaults to 10 if `search` is provided. (optional)  (default to 200)
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](/#pagination). (optional) 
            var search = "search_example";  // string | Searches for Realms with a supported filtering expression for most properties (optional) 
            var sortBy = profile.name;  // string | Specifies field to sort by and can be any single property (for search queries only). (optional) 
            var sortOrder = "\"asc\"";  // string | Specifies sort order `asc` or `desc` (for search queries only). This parameter is ignored if `sortBy` isn't present. (optional)  (default to "asc")

            try
            {
                // List all Realms
                List<Realm> result = apiInstance.ListRealms(limit, after, search, sortBy, sortOrder).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RealmApi.ListRealms: " + e.Message );
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
 **limit** | **int?**| Specifies the number of results returned. Defaults to 10 if &#x60;search&#x60; is provided. | [optional] [default to 200]
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](/#pagination). | [optional] 
 **search** | **string**| Searches for Realms with a supported filtering expression for most properties | [optional] 
 **sortBy** | **string**| Specifies field to sort by and can be any single property (for search queries only). | [optional] 
 **sortOrder** | **string**| Specifies sort order &#x60;asc&#x60; or &#x60;desc&#x60; (for search queries only). This parameter is ignored if &#x60;sortBy&#x60; isn&#39;t present. | [optional] [default to &quot;asc&quot;]

### Return type

[**List&lt;Realm&gt;**](Realm.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacerealm"></a>
# **ReplaceRealm**
> Realm ReplaceRealm (string realmId, UpdateRealmRequest body)

Replace the realm profile

Replaces the realm profile

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceRealmExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RealmApi(config);
            var realmId = vvrcFogtKCrK9aYq3fgV;  // string | `id` of the Realm
            var body = new UpdateRealmRequest(); // UpdateRealmRequest | 

            try
            {
                // Replace the realm profile
                Realm result = apiInstance.ReplaceRealm(realmId, body);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RealmApi.ReplaceRealm: " + e.Message );
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
 **realmId** | **string**| &#x60;id&#x60; of the Realm | 
 **body** | [**UpdateRealmRequest**](UpdateRealmRequest.md)|  | 

### Return type

[**Realm**](Realm.md)

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

