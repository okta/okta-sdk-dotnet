# Okta.Sdk.Api.SSFTransmitterApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateSsfStream**](SSFTransmitterApi.md#createssfstream) | **POST** /api/v1/ssf/stream | Create an SSF Stream
[**DeleteSsfStream**](SSFTransmitterApi.md#deletessfstream) | **DELETE** /api/v1/ssf/stream | Delete an SSF Stream
[**GetSsfStreams**](SSFTransmitterApi.md#getssfstreams) | **GET** /api/v1/ssf/stream | Retrieve the SSF Stream configuration(s)
[**GetWellknownSsfMetadata**](SSFTransmitterApi.md#getwellknownssfmetadata) | **GET** /.well-known/ssf-configuration | Retrieve the SSF Transmitter metadata
[**ReplaceSsfStream**](SSFTransmitterApi.md#replacessfstream) | **PUT** /api/v1/ssf/stream | Replace an SSF Stream
[**UpdateSsfStream**](SSFTransmitterApi.md#updatessfstream) | **PATCH** /api/v1/ssf/stream | Update an SSF Stream


<a name="createssfstream"></a>
# **CreateSsfStream**
> StreamConfiguration CreateSsfStream (StreamConfigurationCreateRequest instance)

Create an SSF Stream

Creates an SSF Stream for an event receiver to start receiving security events in the form of Security Event Tokens (SETs) from Okta.  An SSF Stream is associated with the Client ID of the OAuth 2.0 access token used to create the stream. The Client ID is provided by Okta for an [OAuth 2.0 app integration](https://help.okta.com/okta_help.htm?id=ext_Apps_App_Integration_Wizard-oidc). One SSF Stream is allowed for each Client ID, hence, one SSF Stream is allowed for each app integration in Okta.  A maximum of 10 SSF Stream configurations can be created for one org.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class CreateSsfStreamExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SSFTransmitterApi(config);
            var instance = new StreamConfigurationCreateRequest(); // StreamConfigurationCreateRequest | 

            try
            {
                // Create an SSF Stream
                StreamConfiguration result = apiInstance.CreateSsfStream(instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SSFTransmitterApi.CreateSsfStream: " + e.Message );
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
 **instance** | [**StreamConfigurationCreateRequest**](StreamConfigurationCreateRequest.md)|  | 

### Return type

[**StreamConfiguration**](StreamConfiguration.md)

### Authorization

[oauth2](../README.md#oauth2)

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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletessfstream"></a>
# **DeleteSsfStream**
> void DeleteSsfStream (string streamId = null)

Delete an SSF Stream

Deletes the specified SSF Stream.  If the `stream_id` is not provided in the query string, the associated stream with the Client ID (through the request OAuth 2.0 access token) is deleted. Otherwise, the SSF Stream with the `stream_id` is deleted, if found.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class DeleteSsfStreamExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SSFTransmitterApi(config);
            var streamId = esc1k235GIIztAuGK0g5;  // string | The ID of the specified SSF Stream configuration (optional) 

            try
            {
                // Delete an SSF Stream
                apiInstance.DeleteSsfStream(streamId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SSFTransmitterApi.DeleteSsfStream: " + e.Message );
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
 **streamId** | **string**| The ID of the specified SSF Stream configuration | [optional] 

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
| **204** | No Content |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getssfstreams"></a>
# **GetSsfStreams**
> GetSsfStreams200Response GetSsfStreams (string streamId = null)

Retrieve the SSF Stream configuration(s)

Retrieves either a list of all known SSF Stream configurations or the individual configuration if specified by ID.  As Stream configurations are tied to a Client ID, only the Stream associated with the Client ID of the request OAuth 2.0 access token can be viewed.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetSsfStreamsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SSFTransmitterApi(config);
            var streamId = esc1k235GIIztAuGK0g5;  // string | The ID of the specified SSF Stream configuration (optional) 

            try
            {
                // Retrieve the SSF Stream configuration(s)
                GetSsfStreams200Response result = apiInstance.GetSsfStreams(streamId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SSFTransmitterApi.GetSsfStreams: " + e.Message );
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
 **streamId** | **string**| The ID of the specified SSF Stream configuration | [optional] 

### Return type

[**GetSsfStreams200Response**](GetSsfStreams200Response.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getwellknownssfmetadata"></a>
# **GetWellknownSsfMetadata**
> WellKnownSSFMetadata GetWellknownSsfMetadata ()

Retrieve the SSF Transmitter metadata

Retrieves SSF Transmitter configuration metadata. This includes all supported endpoints and key information about certain properties of the Okta org as the transmitter, such as `delivery_methods_supported`, `issuer`, and `jwks_uri`.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class GetWellknownSsfMetadataExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            var apiInstance = new SSFTransmitterApi(config);

            try
            {
                // Retrieve the SSF Transmitter metadata
                WellKnownSSFMetadata result = apiInstance.GetWellknownSsfMetadata();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SSFTransmitterApi.GetWellknownSsfMetadata: " + e.Message );
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

[**WellKnownSSFMetadata**](WellKnownSSFMetadata.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="replacessfstream"></a>
# **ReplaceSsfStream**
> StreamConfiguration ReplaceSsfStream (StreamConfiguration instance)

Replace an SSF Stream

Replaces all properties for an existing SSF Stream configuration.  If the `stream_id` isn't provided in the request body, the associated stream with the Client ID (through the request OAuth 2.0 access token) is replaced.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class ReplaceSsfStreamExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SSFTransmitterApi(config);
            var instance = new StreamConfiguration(); // StreamConfiguration | 

            try
            {
                // Replace an SSF Stream
                StreamConfiguration result = apiInstance.ReplaceSsfStream(instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SSFTransmitterApi.ReplaceSsfStream: " + e.Message );
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
 **instance** | [**StreamConfiguration**](StreamConfiguration.md)|  | 

### Return type

[**StreamConfiguration**](StreamConfiguration.md)

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
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatessfstream"></a>
# **UpdateSsfStream**
> StreamConfiguration UpdateSsfStream (StreamConfiguration instance)

Update an SSF Stream

Updates properties for an existing SSF Stream configuration.  If the `stream_id` isn't provided in the request body, the associated stream with the Client ID (through the request OAuth 2.0 access token) is updated.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UpdateSsfStreamExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SSFTransmitterApi(config);
            var instance = new StreamConfiguration(); // StreamConfiguration | 

            try
            {
                // Update an SSF Stream
                StreamConfiguration result = apiInstance.UpdateSsfStream(instance);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SSFTransmitterApi.UpdateSsfStream: " + e.Message );
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
 **instance** | [**StreamConfiguration**](StreamConfiguration.md)|  | 

### Return type

[**StreamConfiguration**](StreamConfiguration.md)

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
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

