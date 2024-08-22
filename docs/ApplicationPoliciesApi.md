# Okta.Sdk.Api.ApplicationPoliciesApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AssignApplicationPolicy**](ApplicationPoliciesApi.md#assignapplicationpolicy) | **PUT** /api/v1/apps/{appId}/policies/{policyId} | Assign an application to a Policy


<a name="assignapplicationpolicy"></a>
# **AssignApplicationPolicy**
> void AssignApplicationPolicy (string appId, string policyId)

Assign an application to a Policy

Assigns an application to an [authentication policy](/openapi/okta-management/management/tag/Policy/), identified by `policyId`. If the application was previously assigned to another policy, this operation replaces that assignment with the updated policy identified by `policyId`.  > **Note:** When you [merge duplicate authentication policies](https://help.okta.com/okta_help.htm?type=oie&id=ext-merge-auth-policies), the policy and mapping CRUD operations may be unavailable during the consolidation. When the consolidation is complete, you receive an email.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class AssignApplicationPolicyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationPoliciesApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var policyId = 00plrilJ7jZ66Gn0X0g3;  // string | `id` of the Policy

            try
            {
                // Assign an application to a Policy
                apiInstance.AssignApplicationPolicy(appId, policyId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationPoliciesApi.AssignApplicationPolicy: " + e.Message );
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
 **policyId** | **string**| &#x60;id&#x60; of the Policy | 

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

