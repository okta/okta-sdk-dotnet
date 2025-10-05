# Okta.Sdk.Model.OpenIdConnectApplicationSettingsClient

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ApplicationType** | **OpenIdConnectApplicationType** |  | [optional] 
**BackchannelAuthenticationRequestSigningAlg** | **string** | The signing algorithm for Client-Initiated Backchannel Authentication (CIBA) signed requests using JWT. If this value isn&#39;t set and a JWT-signed request is sent, the request fails. &gt; **Note:** This property appears for clients with &#x60;urn:openid:params:grant-type:ciba&#x60; defined as one of the &#x60;grant_types&#x60;.  | [optional] 
**BackchannelCustomAuthenticatorId** | **string** | The ID of the custom authenticator that authenticates the user &gt; **Note:** This property appears for clients with &#x60;urn:openid:params:grant-type:ciba&#x60; defined as one of the &#x60;grant_types&#x60;.  | [optional] 
**BackchannelTokenDeliveryMode** | **string** | The delivery mode for Client-Initiated Backchannel Authentication (CIBA).  Currently, only &#x60;poll&#x60; is supported. &gt; **Note:** This property appears for clients with &#x60;urn:openid:params:grant-type:ciba&#x60; defined as one of the &#x60;grant_types&#x60;.  | [optional] 
**ClientUri** | **string** | URL string of a web page providing information about the client | [optional] 
**ConsentMethod** | **OpenIdConnectApplicationConsentMethod** |  | [optional] 
**DpopBoundAccessTokens** | **bool** | Indicates that the client application uses Demonstrating Proof-of-Possession (DPoP) for token requests. If &#x60;true&#x60;, the authorization server rejects token requests from this client that don&#39;t contain the DPoP header. &gt; **Note:** If &#x60;dpop_bound_access_tokens&#x60; is true, then &#x60;client_credentials&#x60; and &#x60;implicit&#x60; aren&#39;t allowed in &#x60;grant_types&#x60;.  | [optional] [default to false]
**FrontchannelLogoutSessionRequired** | **bool** | &lt;x-lifecycle-container&gt;&lt;x-lifecycle class&#x3D;\&quot;ea\&quot;&gt;&lt;/x-lifecycle&gt; &lt;x-lifecycle class&#x3D;\&quot;oie\&quot;&gt;&lt;/x-lifecycle&gt;&lt;/x-lifecycle-container&gt;Determines whether Okta sends &#x60;sid&#x60; and &#x60;iss&#x60; in the logout request | [optional] 
**FrontchannelLogoutUri** | **string** | &lt;x-lifecycle-container&gt;&lt;x-lifecycle class&#x3D;\&quot;ea\&quot;&gt;&lt;/x-lifecycle&gt; &lt;x-lifecycle class&#x3D;\&quot;oie\&quot;&gt;&lt;/x-lifecycle&gt;&lt;/x-lifecycle-container&gt;URL where Okta sends the logout request | [optional] 
**GrantTypes** | [**List&lt;GrantType&gt;**](GrantType.md) |  | 
**IdTokenEncryptedResponseAlg** | **KeyEncryptionAlgorithm** |  | [optional] 
**IdpInitiatedLogin** | [**OpenIdConnectApplicationIdpInitiatedLogin**](OpenIdConnectApplicationIdpInitiatedLogin.md) |  | [optional] 
**InitiateLoginUri** | **string** | URL string that a third party can use to initiate the sign-in flow by the client | [optional] 
**IssuerMode** | **OpenIdConnectApplicationIssuerMode** |  | [optional] 
**Jwks** | [**OpenIdConnectApplicationSettingsClientKeys**](OpenIdConnectApplicationSettingsClientKeys.md) |  | [optional] 
**JwksUri** | **string** | URL string that references a JSON Web Key Set for validating JWTs presented to Okta or for encrypting ID tokens minted by Okta for the client | [optional] 
**LogoUri** | **string** | The URL string that references a logo for the client. This logo appears on the client tile in the End-User Dashboard. It also appears on the client consent dialog during the client consent flow. | [optional] 
**Network** | [**OpenIdConnectApplicationNetwork**](OpenIdConnectApplicationNetwork.md) |  | [optional] 
**ParticipateSlo** | **bool** | &lt;x-lifecycle-container&gt;&lt;x-lifecycle class&#x3D;\&quot;ea\&quot;&gt;&lt;/x-lifecycle&gt; &lt;x-lifecycle class&#x3D;\&quot;oie\&quot;&gt;&lt;/x-lifecycle&gt;&lt;/x-lifecycle-container&gt;Allows the app to participate in front-channel Single Logout  &gt; **Note:** You can only enable &#x60;participate_slo&#x60; for &#x60;web&#x60; and &#x60;browser&#x60; application types (&#x60;application_type&#x60;).  | [optional] 
**PolicyUri** | **string** | URL string of a web page providing the client&#39;s policy document | [optional] 
**PostLogoutRedirectUris** | **List&lt;string&gt;** | Array of redirection URI strings for relying party-initiated logouts | [optional] 
**RedirectUris** | **List&lt;string&gt;** | Array of redirection URI strings for use in redirect-based flows. &gt; **Note:** At least one &#x60;redirect_uris&#x60; and &#x60;response_types&#x60; are required for all client types, with exceptions: if the client uses the [Resource Owner Password ](https://tools.ietf.org/html/rfc6749#section-4.3)flow (&#x60;grant_types&#x60; contains &#x60;password&#x60;) or [Client Credentials](https://tools.ietf.org/html/rfc6749#section-4.4)flow (&#x60;grant_types&#x60; contains &#x60;client_credentials&#x60;), then no &#x60;redirect_uris&#x60; or &#x60;response_types&#x60; is necessary. In these cases, you can pass either null or an empty array for these attributes. | [optional] 
**RefreshToken** | [**OpenIdConnectApplicationSettingsRefreshToken**](OpenIdConnectApplicationSettingsRefreshToken.md) |  | [optional] 
**RequestObjectSigningAlg** | **string** | The type of JSON Web Key Set (JWKS) algorithm that must be used for signing request objects | [optional] 
**ResponseTypes** | [**List&lt;OAuthResponseType&gt;**](OAuthResponseType.md) | Array of OAuth 2.0 response type strings | [optional] 
**SectorIdentifierUri** | **string** | The sector identifier used for pairwise &#x60;subject_type&#x60;. See [OIDC Pairwise Identifier Algorithm](https://openid.net/specs/openid-connect-messages-1_0-20.html#idtype.pairwise.alg) | [optional] 
**SubjectType** | **string** | Type of the subject | [optional] 
**TosUri** | **string** | URL string of a web page providing the client&#39;s terms of service document | [optional] 
**WildcardRedirect** | **string** | Indicates if the client is allowed to use wildcard matching of &#x60;redirect_uris&#x60; | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

