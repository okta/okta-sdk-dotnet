# Okta.Sdk.Model.UserSchemaBaseProperties

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**City** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | City or locality component of the user&#39;s address (&#x60;locality&#x60;) | [optional] 
**CostCenter** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | Name of a cost center assigned to the user | [optional] 
**CountryCode** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | Country name component of the user&#39;s address (&#x60;country&#x60;.) This property uses [ISO 3166-1 alpha 2 \&quot;short\&quot; code format](https://tools.ietf.org/html/draft-ietf-scim-core-schema-22#ref-ISO3166). | [optional] 
**Department** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | Name of the user&#39;s department | [optional] 
**DisplayName** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | Name of the user, suitable for display to end users | [optional] 
**Division** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | Name of the user&#39;s division | [optional] 
**Email** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | Primary email address of the user. This property is formatted according to [RFC 5322 Section 3.2.3](https://datatracker.ietf.org/doc/html/rfc5322#section-3.2.3). | [optional] 
**EmployeeNumber** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | Organization or company assigned unique identifier for the user | [optional] 
**FirstName** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | Given name of the user (&#x60;givenName&#x60;) | [optional] 
**HonorificPrefix** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | Honorific prefix(es) of the user or title in most Western languages | [optional] 
**HonorificSuffix** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | Honorific suffix(es) of the user | [optional] 
**LastName** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | Family name of the user (&#x60;familyName&#x60;) | [optional] 
**Locale** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | User&#39;s default location for purposes of localizing items such as currency, date time format, numerical representations, and so on.  A locale value is a concatenation of the ISO 639-1 two-letter language code, an underscore, and the ISO 3166-1 two-letter country code. For example: &#x60;en_US&#x60; specifies the language English and country US. This value is &#x60;en_US&#x60; by default. | [optional] 
**Login** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | Unique identifier for the user (&#x60;userName&#x60;)  The login property is validated according to its pattern attribute, which is a string. By default, the attribute is null. When the attribute is null, the username is required to be formatted as an email address as defined by [RFC 6531 Section 3.3](http://tools.ietf.org/html/rfc6531#section-3.3). The pattern can be set through the API to one of the following forms. (The Admin Console provides access to the same forms.)   * A login pattern of &#x60;\&quot;.+\&quot;&#x60; indicates that there is no restriction on usernames. Any non-empty, unique value is permitted, and the minimum length of five isn&#39;t enforced. In this case, usernames don&#39;t need to include the &#x60;@&#x60; character. If a name does include &#x60;@&#x60;, the portion ahead of the &#x60;@&#x60; can be used for logging in, provided it identifies a unique user within the org.   * A login pattern of the form &#x60;\&quot;[...]+\&quot;&#x60; indicates that usernames must only contain characters from the set given between the brackets. The enclosing brackets and final &#x60;+&#x60; are required for this form. Character ranges can be indicated using hyphens. To include the hyphen itself in the allowed set, the hyphen must appear first. Any characters in the set except the hyphen, a-z, A-Z, and 0-9 must be preceded by a backslash (&#x60;\\&#x60;). For example, &#x60;\&quot;[a-z13579\\.]+\&quot;&#x60; would restrict usernames to lowercase letters, odd digits, and periods, while &#x60;\&quot;[-a-zA-Z0-9]+\&quot;&#x60; would allow basic alphanumeric characters and hyphens. | [optional] 
**Manager** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | The &#x60;displayName&#x60; of the user&#39;s manager | [optional] 
**ManagerId** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | The &#x60;id&#x60; of the user&#39;s manager | [optional] 
**MiddleName** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | Middle name(s) of the user | [optional] 
**MobilePhone** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | Mobile phone number of the user | [optional] 
**NickName** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | Casual way to address the user in real life | [optional] 
**Organization** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | Name of the user&#39;s organization | [optional] 
**PostalAddress** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | Mailing address component of the user&#39;s address | [optional] 
**PreferredLanguage** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | User&#39;s preferred written or spoken languages. This property is formatted according to [RFC 7231 Section 5.3.5](https://tools.ietf.org/html/rfc7231#section-5.3.5). | [optional] 
**PrimaryPhone** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | Primary phone number of the user, such as home number | [optional] 
**ProfileUrl** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | URL of the user&#39;s online profile (for example, a web page.) This property is formatted according to the [Relative Uniform Resource Locators specification](https://tools.ietf.org/html/draft-ietf-scim-core-schema-22#ref-ISO3166). | [optional] 
**SecondEmail** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | Secondary email address of the user typically used for account recovery. This property is formatted according to [RFC 5322 Section 3.2.3](https://datatracker.ietf.org/doc/html/rfc5322#section-3.2.3). | [optional] 
**State** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | State or region component of the user&#39;s address (&#x60;region&#x60;) | [optional] 
**StreetAddress** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | Full street address component of the user&#39;s address | [optional] 
**Timezone** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | User&#39;s time zone. This property is formatted according to the [IANA Time Zone database format](https://tools.ietf.org/html/rfc6557). | [optional] 
**Title** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | User&#39;s title, such as \&quot;Vice President\&quot; | [optional] 
**UserType** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | Used to describe the organization to the user relationship such as \&quot;Employee\&quot; or \&quot;Contractor\&quot;.  **Note:** The &#x60;userType&#x60; field is an arbitrary string value and isn&#39;t related to the newer [User Types](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/UserType/) feature. | [optional] 
**ZipCode** | [**UserSchemaAttribute**](UserSchemaAttribute.md) | ZIP code or postal code component of the user&#39;s address (&#x60;postalCode&#x60;) | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

