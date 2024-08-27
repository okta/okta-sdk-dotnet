# Okta.Sdk.Api.DirectoriesIntegrationApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**UpdateADGroupMembership**](DirectoriesIntegrationApi.md#updateadgroupmembership) | **POST** /api/v1/directories/{appInstanceId}/groups/modify | Update an AD Group membership


<a name="updateadgroupmembership"></a>
# **UpdateADGroupMembership**
> void UpdateADGroupMembership (string appInstanceId, AgentAction agentAction)

Update an AD Group membership

Updates an AD Group membership directly in AD

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateADGroupMembershipExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DirectoriesIntegrationApi(config);
            var appInstanceId = "appInstanceId_example";  // string | ID of the AD AppInstance in Okta
            var agentAction = new AgentAction(); // AgentAction | 

            try
            {
                // Update an AD Group membership
                apiInstance.UpdateADGroupMembership(appInstanceId, agentAction);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DirectoriesIntegrationApi.UpdateADGroupMembership: " + e.Message );
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
 **appInstanceId** | **string**| ID of the AD AppInstance in Okta | 
 **agentAction** | [**AgentAction**](AgentAction.md)|  | 

### Return type

void (empty response body)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **502** | There are no connected agents. |  -  |
| **504** | Timed out waiting for agent. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

