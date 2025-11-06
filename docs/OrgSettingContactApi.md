# Okta.Sdk.Api.OrgSettingContactApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetOrgContactUser**](OrgSettingContactApi.md#getorgcontactuser) | **GET** /api/v1/org/contacts/{contactType} | Retrieve the contact type user
[**ListOrgContactTypes**](OrgSettingContactApi.md#listorgcontacttypes) | **GET** /api/v1/org/contacts | List all org contact types
[**ReplaceOrgContactUser**](OrgSettingContactApi.md#replaceorgcontactuser) | **PUT** /api/v1/org/contacts/{contactType} | Replace the contact type user


<a name="getorgcontactuser"></a>
# **GetOrgContactUser**
> OrgContactUser GetOrgContactUser (ContactTypeParameter contactType)

Retrieve the contact type user

Retrieves the ID and the user resource associated with the specified contact type

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetOrgContactUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrgSettingContactApi(config);
            var contactType = (ContactTypeParameter) "BILLING";  // ContactTypeParameter | 

            try
            {
                // Retrieve the contact type user
                OrgContactUser result = apiInstance.GetOrgContactUser(contactType);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrgSettingContactApi.GetOrgContactUser: " + e.Message );
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
 **contactType** | **ContactTypeParameter**|  | 

### Return type

[**OrgContactUser**](OrgContactUser.md)

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

<a name="listorgcontacttypes"></a>
# **ListOrgContactTypes**
> List&lt;OrgContactTypeObj&gt; ListOrgContactTypes ()

List all org contact types

Lists all org contact types for your Okta org

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ListOrgContactTypesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrgSettingContactApi(config);

            try
            {
                // List all org contact types
                List<OrgContactTypeObj> result = apiInstance.ListOrgContactTypes().ToListAsync();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrgSettingContactApi.ListOrgContactTypes: " + e.Message );
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

[**List&lt;OrgContactTypeObj&gt;**](OrgContactTypeObj.md)

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

<a name="replaceorgcontactuser"></a>
# **ReplaceOrgContactUser**
> OrgContactUser ReplaceOrgContactUser (ContactTypeParameter contactType, OrgContactUser orgContactUser)

Replace the contact type user

Replaces the user associated with the specified contact type

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceOrgContactUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrgSettingContactApi(config);
            var contactType = (ContactTypeParameter) "BILLING";  // ContactTypeParameter | 
            var orgContactUser = new OrgContactUser(); // OrgContactUser | 

            try
            {
                // Replace the contact type user
                OrgContactUser result = apiInstance.ReplaceOrgContactUser(contactType, orgContactUser);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrgSettingContactApi.ReplaceOrgContactUser: " + e.Message );
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
 **contactType** | **ContactTypeParameter**|  | 
 **orgContactUser** | [**OrgContactUser**](OrgContactUser.md)|  | 

### Return type

[**OrgContactUser**](OrgContactUser.md)

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

