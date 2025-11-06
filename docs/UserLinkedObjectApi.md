# Okta.Sdk.Api.UserLinkedObjectApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AssignLinkedObjectValueForPrimary**](UserLinkedObjectApi.md#assignlinkedobjectvalueforprimary) | **PUT** /api/v1/users/{userIdOrLogin}/linkedObjects/{primaryRelationshipName}/{primaryUserId} | Assign a linked object value for primary
[**DeleteLinkedObjectForUser**](UserLinkedObjectApi.md#deletelinkedobjectforuser) | **DELETE** /api/v1/users/{userIdOrLogin}/linkedObjects/{relationshipName} | Delete a linked object value
[**ListLinkedObjectsForUser**](UserLinkedObjectApi.md#listlinkedobjectsforuser) | **GET** /api/v1/users/{userIdOrLogin}/linkedObjects/{relationshipName} | List the primary or all of the associated linked object values


<a name="assignlinkedobjectvalueforprimary"></a>
# **AssignLinkedObjectValueForPrimary**
> void AssignLinkedObjectValueForPrimary (string userIdOrLogin, string primaryRelationshipName, string primaryUserId)

Assign a linked object value for primary

Assigns the first user as the `associated` and the second user as the `primary` for the specified relationship.  If the first user is already associated with a different `primary` for this relationship, the previous link is removed. A linked object relationship can specify only one primary user for an associated user.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AssignLinkedObjectValueForPrimaryExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserLinkedObjectApi(config);
            var userIdOrLogin = 00u5zex6ztMbOZhF50h7;  // string | If for the `self` link, this is the ID of the user for whom you want to get the primary user ID. If for the `associated` relation, this is the user ID or login value of the user assigned the associated relationship.  This can be `me` to represent the current session user.
            var primaryRelationshipName = manager;  // string | Name of the `primary` relationship being assigned
            var primaryUserId = "primaryUserId_example";  // string | User ID to be assigned to the `primary` relationship for the `associated` user

            try
            {
                // Assign a linked object value for primary
                apiInstance.AssignLinkedObjectValueForPrimary(userIdOrLogin, primaryRelationshipName, primaryUserId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserLinkedObjectApi.AssignLinkedObjectValueForPrimary: " + e.Message );
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
 **userIdOrLogin** | **string**| If for the &#x60;self&#x60; link, this is the ID of the user for whom you want to get the primary user ID. If for the &#x60;associated&#x60; relation, this is the user ID or login value of the user assigned the associated relationship.  This can be &#x60;me&#x60; to represent the current session user. | 
 **primaryRelationshipName** | **string**| Name of the &#x60;primary&#x60; relationship being assigned | 
 **primaryUserId** | **string**| User ID to be assigned to the &#x60;primary&#x60; relationship for the &#x60;associated&#x60; user | 

### Return type

void (empty response body)

### Authorization

[oauth2](../README.md#oauth2)

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

<a name="deletelinkedobjectforuser"></a>
# **DeleteLinkedObjectForUser**
> void DeleteLinkedObjectForUser (string userIdOrLogin, string relationshipName)

Delete a linked object value

Deletes any existing relationship between the `associated` and `primary` user. For the `associated` user, this is specified by the ID. The `primary` name specifies the relationship.  The operation is successful if the relationship is deleted. The operation is also successful if the specified user isn't in the `associated` relationship for any instance of the specified `primary` and thus, no relationship is found.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteLinkedObjectForUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserLinkedObjectApi(config);
            var userIdOrLogin = 00u5zex6ztMbOZhF50h7;  // string | If for the `self` link, this is the ID of the user for whom you want to get the primary user ID. If for the `associated` relation, this is the user ID or login value of the user assigned the associated relationship.  This can be `me` to represent the current session user.
            var relationshipName = manager;  // string | Name of the `primary` or `associated` relationship being queried

            try
            {
                // Delete a linked object value
                apiInstance.DeleteLinkedObjectForUser(userIdOrLogin, relationshipName);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserLinkedObjectApi.DeleteLinkedObjectForUser: " + e.Message );
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
 **userIdOrLogin** | **string**| If for the &#x60;self&#x60; link, this is the ID of the user for whom you want to get the primary user ID. If for the &#x60;associated&#x60; relation, this is the user ID or login value of the user assigned the associated relationship.  This can be &#x60;me&#x60; to represent the current session user. | 
 **relationshipName** | **string**| Name of the &#x60;primary&#x60; or &#x60;associated&#x60; relationship being queried | 

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

<a name="listlinkedobjectsforuser"></a>
# **ListLinkedObjectsForUser**
> List&lt;ResponseLinks&gt; ListLinkedObjectsForUser (string userIdOrLogin, string relationshipName)

List the primary or all of the associated linked object values

Lists either the `self` link for the primary user or all associated users in the relationship specified by `relationshipName`. If the specified user isn't associated in any relationship, an empty array is returned.  Use `me` instead of `id` to specify the current session user.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListLinkedObjectsForUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserLinkedObjectApi(config);
            var userIdOrLogin = 00u5zex6ztMbOZhF50h7;  // string | If for the `self` link, this is the ID of the user for whom you want to get the primary user ID. If for the `associated` relation, this is the user ID or login value of the user assigned the associated relationship.  This can be `me` to represent the current session user.
            var relationshipName = manager;  // string | Name of the `primary` or `associated` relationship being queried

            try
            {
                // List the primary or all of the associated linked object values
                List<ResponseLinks> result = apiInstance.ListLinkedObjectsForUser(userIdOrLogin, relationshipName).ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserLinkedObjectApi.ListLinkedObjectsForUser: " + e.Message );
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
 **userIdOrLogin** | **string**| If for the &#x60;self&#x60; link, this is the ID of the user for whom you want to get the primary user ID. If for the &#x60;associated&#x60; relation, this is the user ID or login value of the user assigned the associated relationship.  This can be &#x60;me&#x60; to represent the current session user. | 
 **relationshipName** | **string**| Name of the &#x60;primary&#x60; or &#x60;associated&#x60; relationship being queried | 

### Return type

[**List&lt;ResponseLinks&gt;**](ResponseLinks.md)

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

