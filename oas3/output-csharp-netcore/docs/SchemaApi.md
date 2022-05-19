# Org.OpenAPITools.Api.SchemaApi

All URIs are relative to *https://your-subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetApplicationUserSchema**](SchemaApi.md#getapplicationuserschema) | **GET** /api/v1/meta/schemas/apps/{appInstanceId}/default | Fetches the Schema for an App User
[**GetGroupSchema**](SchemaApi.md#getgroupschema) | **GET** /api/v1/meta/schemas/group/default | Fetches the group schema
[**GetUserSchema**](SchemaApi.md#getuserschema) | **GET** /api/v1/meta/schemas/user/{schemaId} | Fetches the schema for a Schema Id.
[**UpdateApplicationUserProfile**](SchemaApi.md#updateapplicationuserprofile) | **POST** /api/v1/meta/schemas/apps/{appInstanceId}/default | Partial updates on the User Profile properties of the Application User Schema.
[**UpdateGroupSchema**](SchemaApi.md#updategroupschema) | **POST** /api/v1/meta/schemas/group/default | Updates, adds ore removes one or more custom Group Profile properties in the schema
[**UpdateUserProfile**](SchemaApi.md#updateuserprofile) | **POST** /api/v1/meta/schemas/user/{schemaId} | Update User Profile


<a name="getapplicationuserschema"></a>
# **GetApplicationUserSchema**
> UserSchema GetApplicationUserSchema (string appInstanceId)

Fetches the Schema for an App User

Fetches the Schema for an App User

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetApplicationUserSchemaExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SchemaApi(config);
            var appInstanceId = "appInstanceId_example";  // string | 

            try
            {
                // Fetches the Schema for an App User
                UserSchema result = apiInstance.GetApplicationUserSchema(appInstanceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SchemaApi.GetApplicationUserSchema: " + e.Message );
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
 **appInstanceId** | **string**|  | 

### Return type

[**UserSchema**](UserSchema.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getgroupschema"></a>
# **GetGroupSchema**
> GroupSchema GetGroupSchema ()

Fetches the group schema

Fetches the group schema

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetGroupSchemaExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SchemaApi(config);

            try
            {
                // Fetches the group schema
                GroupSchema result = apiInstance.GetGroupSchema();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SchemaApi.GetGroupSchema: " + e.Message );
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

[**GroupSchema**](GroupSchema.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getuserschema"></a>
# **GetUserSchema**
> UserSchema GetUserSchema (string schemaId)

Fetches the schema for a Schema Id.

Fetches the schema for a Schema Id.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetUserSchemaExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SchemaApi(config);
            var schemaId = "schemaId_example";  // string | 

            try
            {
                // Fetches the schema for a Schema Id.
                UserSchema result = apiInstance.GetUserSchema(schemaId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SchemaApi.GetUserSchema: " + e.Message );
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
 **schemaId** | **string**|  | 

### Return type

[**UserSchema**](UserSchema.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateapplicationuserprofile"></a>
# **UpdateApplicationUserProfile**
> UserSchema UpdateApplicationUserProfile (string appInstanceId, UserSchema body = null)

Partial updates on the User Profile properties of the Application User Schema.

Partial updates on the User Profile properties of the Application User Schema.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class UpdateApplicationUserProfileExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SchemaApi(config);
            var appInstanceId = "appInstanceId_example";  // string | 
            var body = new UserSchema(); // UserSchema |  (optional) 

            try
            {
                // Partial updates on the User Profile properties of the Application User Schema.
                UserSchema result = apiInstance.UpdateApplicationUserProfile(appInstanceId, body);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SchemaApi.UpdateApplicationUserProfile: " + e.Message );
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
 **appInstanceId** | **string**|  | 
 **body** | [**UserSchema**](UserSchema.md)|  | [optional] 

### Return type

[**UserSchema**](UserSchema.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updategroupschema"></a>
# **UpdateGroupSchema**
> GroupSchema UpdateGroupSchema (GroupSchema groupSchema = null)

Updates, adds ore removes one or more custom Group Profile properties in the schema

Updates, adds ore removes one or more custom Group Profile properties in the schema

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class UpdateGroupSchemaExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SchemaApi(config);
            var groupSchema = new GroupSchema(); // GroupSchema |  (optional) 

            try
            {
                // Updates, adds ore removes one or more custom Group Profile properties in the schema
                GroupSchema result = apiInstance.UpdateGroupSchema(groupSchema);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SchemaApi.UpdateGroupSchema: " + e.Message );
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
 **groupSchema** | [**GroupSchema**](GroupSchema.md)|  | [optional] 

### Return type

[**GroupSchema**](GroupSchema.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateuserprofile"></a>
# **UpdateUserProfile**
> UserSchema UpdateUserProfile (string schemaId, UserSchema userSchema)

Update User Profile

Partial updates on the User Profile properties of the user schema.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class UpdateUserProfileExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://your-subdomain.okta.com";
            // Configure API key authorization: api_token
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SchemaApi(config);
            var schemaId = "schemaId_example";  // string | 
            var userSchema = new UserSchema(); // UserSchema | 

            try
            {
                // Update User Profile
                UserSchema result = apiInstance.UpdateUserProfile(schemaId, userSchema);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SchemaApi.UpdateUserProfile: " + e.Message );
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
 **schemaId** | **string**|  | 
 **userSchema** | [**UserSchema**](UserSchema.md)|  | 

### Return type

[**UserSchema**](UserSchema.md)

### Authorization

[api_token](../README.md#api_token), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

