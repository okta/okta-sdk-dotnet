# Okta.Sdk.Api.SchemaApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetApplicationUserSchema**](SchemaApi.md#getapplicationuserschema) | **GET** /api/v1/meta/schemas/apps/{appId}/default | Retrieve the default app user schema for an app
[**GetGroupSchema**](SchemaApi.md#getgroupschema) | **GET** /api/v1/meta/schemas/group/default | Retrieve the default group schema
[**GetLogStreamSchema**](SchemaApi.md#getlogstreamschema) | **GET** /api/v1/meta/schemas/logStream/{logStreamType} | Retrieve the log stream schema for the schema type
[**GetUserSchema**](SchemaApi.md#getuserschema) | **GET** /api/v1/meta/schemas/user/{schemaId} | Retrieve a user schema
[**ListLogStreamSchemas**](SchemaApi.md#listlogstreamschemas) | **GET** /api/v1/meta/schemas/logStream | List the log stream schemas
[**UpdateApplicationUserProfile**](SchemaApi.md#updateapplicationuserprofile) | **POST** /api/v1/meta/schemas/apps/{appId}/default | Update the app user profile schema for an app
[**UpdateGroupSchema**](SchemaApi.md#updategroupschema) | **POST** /api/v1/meta/schemas/group/default | Update the group profile schema
[**UpdateUserProfile**](SchemaApi.md#updateuserprofile) | **POST** /api/v1/meta/schemas/user/{schemaId} | Update a user schema


<a name="getapplicationuserschema"></a>
# **GetApplicationUserSchema**
> UserSchema GetApplicationUserSchema (string appId)

Retrieve the default app user schema for an app

Retrieves the default schema for an app user.  The [User Types](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/UserType/) feature does not extend to apps. All users assigned to a given app use the same app user schema. Therefore, unlike the user schema operations, the app user schema operations all specify `default` and don't accept a schema ID.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetApplicationUserSchemaExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SchemaApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID

            try
            {
                // Retrieve the default app user schema for an app
                UserSchema result = apiInstance.GetApplicationUserSchema(appId);
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
 **appId** | **string**| Application ID | 

### Return type

[**UserSchema**](UserSchema.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getgroupschema"></a>
# **GetGroupSchema**
> GroupSchema GetGroupSchema ()

Retrieve the default group schema

Retrieves the group schema  The [User Types](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/UserType/) feature does not extend to groups. All groups use the same group schema. Unlike user schema operations, group schema operations all specify `default` and don't accept a schema ID.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetGroupSchemaExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SchemaApi(config);

            try
            {
                // Retrieve the default group schema
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

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getlogstreamschema"></a>
# **GetLogStreamSchema**
> LogStreamSchema GetLogStreamSchema (LogStreamType logStreamType)

Retrieve the log stream schema for the schema type

Retrieves the schema for a log stream type. The `logStreamType` element in the URL specifies the log stream type, which is either `aws_eventbridge` or `splunk_cloud_logstreaming`. Use the `aws_eventbridge` literal to retrieve the AWS EventBridge type schema, and use the `splunk_cloud_logstreaming` literal retrieve the Splunk Cloud type schema.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetLogStreamSchemaExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SchemaApi(config);
            var logStreamType = (LogStreamType) "aws_eventbridge";  // LogStreamType | 

            try
            {
                // Retrieve the log stream schema for the schema type
                LogStreamSchema result = apiInstance.GetLogStreamSchema(logStreamType);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SchemaApi.GetLogStreamSchema: " + e.Message );
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
 **logStreamType** | **LogStreamType**|  | 

### Return type

[**LogStreamSchema**](LogStreamSchema.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getuserschema"></a>
# **GetUserSchema**
> UserSchema GetUserSchema (string schemaId)

Retrieve a user schema

Retrieves the schema for a user type

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetUserSchemaExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SchemaApi(config);
            var schemaId = "schemaId_example";  // string | Schema ID. You can also use `default` to refer to the default user type schema.

            try
            {
                // Retrieve a user schema
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
 **schemaId** | **string**| Schema ID. You can also use &#x60;default&#x60; to refer to the default user type schema. | 

### Return type

[**UserSchema**](UserSchema.md)

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

<a name="listlogstreamschemas"></a>
# **ListLogStreamSchemas**
> List&lt;LogStreamSchema&gt; ListLogStreamSchemas ()

List the log stream schemas

Lists the schema for all log stream types visible for this org

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListLogStreamSchemasExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SchemaApi(config);

            try
            {
                // List the log stream schemas
                List<LogStreamSchema> result = apiInstance.ListLogStreamSchemas().ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SchemaApi.ListLogStreamSchemas: " + e.Message );
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

[**List&lt;LogStreamSchema&gt;**](LogStreamSchema.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateapplicationuserprofile"></a>
# **UpdateApplicationUserProfile**
> UserSchema UpdateApplicationUserProfile (string appId, UserSchema body = null)

Update the app user profile schema for an app

Updates the app user schema. This updates, adds, or removes one or more custom profile properties or the nullability of a base property in the app user schema for an app. Changing a base property's nullability (for example, the value of its `required` field) is allowed only if it is nullable in the default predefined schema for the app.  > **Note:** You must set properties explicitly to `null` to remove them from the schema; otherwise, `POST` is interpreted as a partial update.  The [User Types](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/UserType/) feature does not extend to apps. All users assigned to a given app use the same app user schema. Therefore, unlike the user schema operations, the app user schema operations all specify `default` and don't accept a schema ID.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateApplicationUserProfileExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SchemaApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var body = new UserSchema(); // UserSchema |  (optional) 

            try
            {
                // Update the app user profile schema for an app
                UserSchema result = apiInstance.UpdateApplicationUserProfile(appId, body);
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
 **appId** | **string**| Application ID | 
 **body** | [**UserSchema**](UserSchema.md)|  | [optional] 

### Return type

[**UserSchema**](UserSchema.md)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updategroupschema"></a>
# **UpdateGroupSchema**
> GroupSchema UpdateGroupSchema (GroupSchema groupSchema = null)

Update the group profile schema

Updates the group profile schema. This updates, adds, or removes one or more custom profile properties in a group schema. Currently Okta does not support changing base group profile properties.  > **Note:** You must set properties explicitly to `null` to remove them from the schema; otherwise, `POST` is interpreted as a partial update.  The [User Types](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/UserType/) feature does not extend to groups. All groups use the same group schema. Unlike user schema operations, group schema operations all specify `default` and don't accept a schema ID.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateGroupSchemaExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SchemaApi(config);
            var groupSchema = new GroupSchema(); // GroupSchema |  (optional) 

            try
            {
                // Update the group profile schema
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

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateuserprofile"></a>
# **UpdateUserProfile**
> UserSchema UpdateUserProfile (string schemaId, UserSchema userSchema)

Update a user schema

Updates a user schema. Use this request to update, add, or remove one or more profile properties in a user schema. If you specify `default` for the `schemaId`, updates will apply to the default user type.  Unlike custom user profile properties, limited changes are allowed to base user profile properties (permissions, nullability of the `firstName` and `lastName` properties, or pattern for `login`). You can't remove a property from the default schema if it's being referenced as a [`matchAttribute`](/openapi/okta-management/management/tag/IdentityProvider/#tag/IdentityProvider/operation/createIdentityProvider!path=policy/subject/matchAttribute&t=request) in `SAML2` IdPs. Currently, all validation of SAML assertions are only performed against the default user type.  > **Note:** You must set properties explicitly to `null` to remove them from the schema; otherwise, `POST` is interpreted as a partial update.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateUserProfileExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SchemaApi(config);
            var schemaId = "schemaId_example";  // string | Schema ID. You can also use `default` to refer to the default user type schema.
            var userSchema = new UserSchema(); // UserSchema | 

            try
            {
                // Update a user schema
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
 **schemaId** | **string**| Schema ID. You can also use &#x60;default&#x60; to refer to the default user type schema. | 
 **userSchema** | [**UserSchema**](UserSchema.md)|  | 

### Return type

[**UserSchema**](UserSchema.md)

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

