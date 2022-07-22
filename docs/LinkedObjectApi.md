# Okta.Sdk.Api.LinkedObjectApi

All URIs are relative to *https://your-subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AddLinkedObjectDefinition**](LinkedObjectApi.md#addlinkedobjectdefinition) | **POST** /api/v1/meta/schemas/user/linkedObjects | Create a Linked Object Definition
[**DeleteLinkedObjectDefinition**](LinkedObjectApi.md#deletelinkedobjectdefinition) | **DELETE** /api/v1/meta/schemas/user/linkedObjects/{linkedObjectName} | Delete a Linked Object Definition
[**GetLinkedObjectDefinition**](LinkedObjectApi.md#getlinkedobjectdefinition) | **GET** /api/v1/meta/schemas/user/linkedObjects/{linkedObjectName} | Retrieve a Linked Object Definition
[**ListLinkedObjectDefinitions**](LinkedObjectApi.md#listlinkedobjectdefinitions) | **GET** /api/v1/meta/schemas/user/linkedObjects | List all Linked Object Definitions


<a name="addlinkedobjectdefinition"></a>
# **AddLinkedObjectDefinition**
> LinkedObject AddLinkedObjectDefinition (LinkedObject linkedObject)

Create a Linked Object Definition

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AddLinkedObjectDefinitionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new LinkedObjectApi(config);
            var linkedObject = new LinkedObject(); // LinkedObject | 

            try
            {
                // Create a Linked Object Definition
                LinkedObject result = apiInstance.AddLinkedObjectDefinition(linkedObject);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling LinkedObjectApi.AddLinkedObjectDefinition: " + e.Message );
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
 **linkedObject** | [**LinkedObject**](LinkedObject.md)|  | 

### Return type

[**LinkedObject**](LinkedObject.md)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

<a name="deletelinkedobjectdefinition"></a>
# **DeleteLinkedObjectDefinition**
> void DeleteLinkedObjectDefinition (string linkedObjectName)

Delete a Linked Object Definition

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteLinkedObjectDefinitionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new LinkedObjectApi(config);
            var linkedObjectName = "linkedObjectName_example";  // string | 

            try
            {
                // Delete a Linked Object Definition
                apiInstance.DeleteLinkedObjectDefinition(linkedObjectName);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling LinkedObjectApi.DeleteLinkedObjectDefinition: " + e.Message );
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
 **linkedObjectName** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

<a name="getlinkedobjectdefinition"></a>
# **GetLinkedObjectDefinition**
> LinkedObject GetLinkedObjectDefinition (string linkedObjectName)

Retrieve a Linked Object Definition

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetLinkedObjectDefinitionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new LinkedObjectApi(config);
            var linkedObjectName = "linkedObjectName_example";  // string | 

            try
            {
                // Retrieve a Linked Object Definition
                LinkedObject result = apiInstance.GetLinkedObjectDefinition(linkedObjectName);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling LinkedObjectApi.GetLinkedObjectDefinition: " + e.Message );
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
 **linkedObjectName** | **string**|  | 

### Return type

[**LinkedObject**](LinkedObject.md)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

<a name="listlinkedobjectdefinitions"></a>
# **ListLinkedObjectDefinitions**
> List&lt;LinkedObject&gt; ListLinkedObjectDefinitions ()

List all Linked Object Definitions

Success

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListLinkedObjectDefinitionsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: API_Token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: OAuth_2.0
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new LinkedObjectApi(config);

            try
            {
                // List all Linked Object Definitions
                List<LinkedObject> result = apiInstance.ListLinkedObjectDefinitions();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling LinkedObjectApi.ListLinkedObjectDefinitions: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List&lt;LinkedObject&gt;**](LinkedObject.md)

### Authorization

[API_Token](../README.md#API_Token), [OAuth_2.0](../README.md#OAuth_2.0)

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

