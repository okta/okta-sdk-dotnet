# Okta.Sdk.Api.RealmApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateRealm**](RealmApi.md#createrealm) | **POST** /api/v1/realms | Create a realm
[**DeleteRealm**](RealmApi.md#deleterealm) | **DELETE** /api/v1/realms/{realmId} | Delete a realm
[**GetRealm**](RealmApi.md#getrealm) | **GET** /api/v1/realms/{realmId} | Retrieve a realm
[**ListRealms**](RealmApi.md#listrealms) | **GET** /api/v1/realms | List all realms
[**ReplaceRealm**](RealmApi.md#replacerealm) | **PUT** /api/v1/realms/{realmId} | Replace the realm profile


<a name="createrealm"></a>
# **CreateRealm**
> Realm CreateRealm (CreateRealmRequest body)

Create a realm

Creates a new realm

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
                // Create a realm
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

Delete a realm

Deletes a realm permanently. This operation can only be performed after disassociating other entities like users and identity providers from a realm.

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
            var realmId = vvrcFogtKCrK9aYq3fgV;  // string | ID of the realm

            try
            {
                // Delete a realm
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
 **realmId** | **string**| ID of the realm | 

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

Retrieve a realm

Retrieves a realm

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
            var realmId = vvrcFogtKCrK9aYq3fgV;  // string | ID of the realm

            try
            {
                // Retrieve a realm
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
 **realmId** | **string**| ID of the realm | 

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

List all realms

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
            var after = "after_example";  // string | The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the `Link` response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). (optional) 
            var search = "search_example";  // string | Searches for realms with a supported filtering expression for most properties.  Searches for realms can be filtered by the contains (`co`) operator. You can only use `co` with the `profile.name` property. See [Operators](https://developer.okta.com/docs/api/#operators). (optional) 
            var sortBy = profile.name;  // string | Specifies the field to sort by and can be any single property (for search queries only) (optional) 
            var sortOrder = "\"asc\"";  // string | Specifies the sort order: `asc` or `desc` (for search queries only). This parameter is ignored if `sortBy` isn't present. (optional)  (default to "asc")

            try
            {
                // List all realms
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
 **after** | **string**| The cursor to use for pagination. It is an opaque string that specifies your current location in the list and is obtained from the &#x60;Link&#x60; response header. See [Pagination](https://developer.okta.com/docs/api/#pagination). | [optional] 
 **search** | **string**| Searches for realms with a supported filtering expression for most properties.  Searches for realms can be filtered by the contains (&#x60;co&#x60;) operator. You can only use &#x60;co&#x60; with the &#x60;profile.name&#x60; property. See [Operators](https://developer.okta.com/docs/api/#operators). | [optional] 
 **sortBy** | **string**| Specifies the field to sort by and can be any single property (for search queries only) | [optional] 
 **sortOrder** | **string**| Specifies the sort order: &#x60;asc&#x60; or &#x60;desc&#x60; (for search queries only). This parameter is ignored if &#x60;sortBy&#x60; isn&#39;t present. | [optional] [default to &quot;asc&quot;]

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
            var realmId = vvrcFogtKCrK9aYq3fgV;  // string | ID of the realm
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
 **realmId** | **string**| ID of the realm | 
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

