# Okta.Sdk.Api.OrgCreatorApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateChildOrg**](OrgCreatorApi.md#createchildorg) | **POST** /api/v1/orgs | Create an org


<a name="createchildorg"></a>
# **CreateChildOrg**
> ChildOrg CreateChildOrg (ChildOrg childOrg = null)

Create an org

Creates an org (child org) that has the same features as the current requesting org (parent org). A child org inherits any new features added to the parent org, but new features added to the child org aren't propagated back to the parent org. > **Notes:** > * Some features associated with products, such as Atspoke, Workflows, and Okta Identity Governance, aren't propagated to the child org. > * Wait at least 30 seconds after a 201-Created response before you make API requests to the new child org. > * For rate limits, see [Org creation rate limits](https://developer.okta.com/docs/reference/rl-additional-limits/#org-creation-rate-limits).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateChildOrgExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrgCreatorApi(config);
            var childOrg = new ChildOrg(); // ChildOrg |  (optional) 

            try
            {
                // Create an org
                ChildOrg result = apiInstance.CreateChildOrg(childOrg);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrgCreatorApi.CreateChildOrg: " + e.Message );
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
 **childOrg** | [**ChildOrg**](ChildOrg.md)|  | [optional] 

### Return type

[**ChildOrg**](ChildOrg.md)

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
| **500** | Internal Server Error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

