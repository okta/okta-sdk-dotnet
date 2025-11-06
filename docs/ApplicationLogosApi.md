# Okta.Sdk.Api.ApplicationLogosApi

All URIs are relative to *https://subdomain.okta.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**UploadApplicationLogo**](ApplicationLogosApi.md#uploadapplicationlogo) | **POST** /api/v1/apps/{appId}/logo | Upload an application logo


<a name="uploadapplicationlogo"></a>
# **UploadApplicationLogo**
> void UploadApplicationLogo (string appId, System.IO.Stream file)

Upload an application logo

Uploads a logo for the app instance. If the app already has a logo, this operation replaces the previous logo.  The logo is visible in the Admin Console as an icon for your app instance. If you have one `appLink` object configured, this logo also appears in the End-User Dashboard as an icon for your app. > **Note:** If you have multiple `appLink` objects, use the Admin Console to add logos for each app link. > You can't use the API to add logos for multiple app links. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

namespace Example
{
    public class UploadApplicationLogoExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.OktaDomain = "https://subdomain.okta.com";
            // Configure API key authorization: apiToken
            config.Token ="YOUR_API_KEY";
            // Configure OAuth2 access token for authorization: oauth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ApplicationLogosApi(config);
            var appId = 0oafxqCAJWWGELFTYASJ;  // string | Application ID
            var file = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream | The image file containing the logo.  The file must be in PNG, JPG, SVG, or GIF format, and less than one MB in size. For best results, use an image with a transparent background and a square dimension of 200 x 200 pixels to prevent upscaling.  > **Notes:** > * Only SVG files encoded in UTF-8 are supported. For example, `<xml version=\\\"1.0\\\" encoding=\\\"UTF-8\\\">` is a valid SVG file declaration. > * `multipart/form-data` isn't supported for Python. Remove the `\\\"Content-Type\\\": \\\"multipart/form-data\\\"` line if you use the Python request sample code. 

            try
            {
                // Upload an application logo
                apiInstance.UploadApplicationLogo(appId, file);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ApplicationLogosApi.UploadApplicationLogo: " + e.Message );
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
 **file** | **System.IO.Stream****System.IO.Stream**| The image file containing the logo.  The file must be in PNG, JPG, SVG, or GIF format, and less than one MB in size. For best results, use an image with a transparent background and a square dimension of 200 x 200 pixels to prevent upscaling.  &gt; **Notes:** &gt; * Only SVG files encoded in UTF-8 are supported. For example, &#x60;&lt;xml version&#x3D;\\\&quot;1.0\\\&quot; encoding&#x3D;\\\&quot;UTF-8\\\&quot;&gt;&#x60; is a valid SVG file declaration. &gt; * &#x60;multipart/form-data&#x60; isn&#39;t supported for Python. Remove the &#x60;\\\&quot;Content-Type\\\&quot;: \\\&quot;multipart/form-data\\\&quot;&#x60; line if you use the Python request sample code.  | 

### Return type

void (empty response body)

### Authorization

[apiToken](../README.md#apiToken), [oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Content Created |  -  |
| **400** | Bad Request |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **429** | Too Many Requests |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

