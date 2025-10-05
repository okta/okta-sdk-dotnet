# Okta.Sdk.Api.SSFSecurityEventTokenApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**PublishSecurityEventTokens**](SSFSecurityEventTokenApi.md#publishsecurityeventtokens) | **POST** /security/api/v1/security-events | Publish a security event token


<a name="publishsecurityeventtokens"></a>
# **PublishSecurityEventTokens**
> void PublishSecurityEventTokens (string securityEventToken)

Publish a security event token

Publishes a Security Event Token (SET) sent by a Security Events Provider. After the token is verified, Okta ingests the event and performs any appropriate action.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class PublishSecurityEventTokensExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            var apiInstance = new SSFSecurityEventTokenApi(config);
            var securityEventToken = eyJraWQiOiJzYW1wbGVfa2lkIiwidHlwIjoic2ZXZlbnQra ... mrtmw;  // string | The request body is a signed [SET](https://datatracker.ietf.org/doc/html/rfc8417), which is a type of JSON Web Token (JWT).  For SET JWT header and body descriptions, see [SET JWT header](/openapi/okta-management/management/tag/SSFSecurityEventToken/#tag/SSFSecurityEventToken/schema/SecurityEventTokenRequestJwtHeader) and [SET JWT body payload](/openapi/okta-management/management/tag/SSFSecurityEventToken/#tag/SSFSecurityEventToken/schema/SecurityEventTokenRequestJwtBody). 

            try
            {
                // Publish a security event token
                apiInstance.PublishSecurityEventTokens(securityEventToken);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SSFSecurityEventTokenApi.PublishSecurityEventTokens: " + e.Message );
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
 **securityEventToken** | **string**| The request body is a signed [SET](https://datatracker.ietf.org/doc/html/rfc8417), which is a type of JSON Web Token (JWT).  For SET JWT header and body descriptions, see [SET JWT header](/openapi/okta-management/management/tag/SSFSecurityEventToken/#tag/SSFSecurityEventToken/schema/SecurityEventTokenRequestJwtHeader) and [SET JWT body payload](/openapi/okta-management/management/tag/SSFSecurityEventToken/#tag/SSFSecurityEventToken/schema/SecurityEventTokenRequestJwtBody).  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/secevent+jwt
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | Accepted |  -  |
| **400** | Bad Request |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

