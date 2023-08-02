/*
 * Okta Admin Management
 *
 * Allows customers to easily access the Okta Management APIs
 *
 * The version of the OpenAPI document: 5.1.0
 * Contact: devex-public@okta.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using OpenAPIDateConverter = Okta.Sdk.Client.OpenAPIDateConverter;

namespace Okta.Sdk.Model
{
    /// <summary>
    /// Template: ModelGeneric
    /// UserProfile
    /// </summary>
    [DataContract(Name = "UserProfile")]
    public partial class UserProfile : IEquatable<UserProfile>
    
    {
        
        /// <summary>
        /// Gets or Sets City
        /// </summary>
        [DataMember(Name = "city", EmitDefaultValue = true)]
        public string City { get; set; }

        /// <summary>
        /// Gets or Sets CostCenter
        /// </summary>
        [DataMember(Name = "costCenter", EmitDefaultValue = false)]
        public string CostCenter { get; set; }

        /// <summary>
        /// Gets or Sets CountryCode
        /// </summary>
        [DataMember(Name = "countryCode", EmitDefaultValue = true)]
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or Sets Department
        /// </summary>
        [DataMember(Name = "department", EmitDefaultValue = false)]
        public string Department { get; set; }

        /// <summary>
        /// Gets or Sets DisplayName
        /// </summary>
        [DataMember(Name = "displayName", EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or Sets Division
        /// </summary>
        [DataMember(Name = "division", EmitDefaultValue = false)]
        public string Division { get; set; }

        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        [DataMember(Name = "email", EmitDefaultValue = false)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets EmployeeNumber
        /// </summary>
        [DataMember(Name = "employeeNumber", EmitDefaultValue = false)]
        public string EmployeeNumber { get; set; }

        /// <summary>
        /// Gets or Sets FirstName
        /// </summary>
        [DataMember(Name = "firstName", EmitDefaultValue = true)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or Sets HonorificPrefix
        /// </summary>
        [DataMember(Name = "honorificPrefix", EmitDefaultValue = false)]
        public string HonorificPrefix { get; set; }

        /// <summary>
        /// Gets or Sets HonorificSuffix
        /// </summary>
        [DataMember(Name = "honorificSuffix", EmitDefaultValue = false)]
        public string HonorificSuffix { get; set; }

        /// <summary>
        /// Gets or Sets LastName
        /// </summary>
        [DataMember(Name = "lastName", EmitDefaultValue = true)]
        public string LastName { get; set; }

        /// <summary>
        /// The language specified as an [IETF BCP 47 language tag](https://datatracker.ietf.org/doc/html/rfc5646)
        /// </summary>
        /// <value>The language specified as an [IETF BCP 47 language tag](https://datatracker.ietf.org/doc/html/rfc5646)</value>
        [DataMember(Name = "locale", EmitDefaultValue = false)]
        public string Locale { get; set; }

        /// <summary>
        /// Gets or Sets Login
        /// </summary>
        [DataMember(Name = "login", EmitDefaultValue = false)]
        public string Login { get; set; }

        /// <summary>
        /// Gets or Sets Manager
        /// </summary>
        [DataMember(Name = "manager", EmitDefaultValue = false)]
        public string Manager { get; set; }

        /// <summary>
        /// Gets or Sets ManagerId
        /// </summary>
        [DataMember(Name = "managerId", EmitDefaultValue = false)]
        public string ManagerId { get; set; }

        /// <summary>
        /// Gets or Sets MiddleName
        /// </summary>
        [DataMember(Name = "middleName", EmitDefaultValue = false)]
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or Sets MobilePhone
        /// </summary>
        [DataMember(Name = "mobilePhone", EmitDefaultValue = true)]
        public string MobilePhone { get; set; }

        /// <summary>
        /// Gets or Sets NickName
        /// </summary>
        [DataMember(Name = "nickName", EmitDefaultValue = false)]
        public string NickName { get; set; }

        /// <summary>
        /// Gets or Sets Organization
        /// </summary>
        [DataMember(Name = "organization", EmitDefaultValue = false)]
        public string Organization { get; set; }

        /// <summary>
        /// Gets or Sets PostalAddress
        /// </summary>
        [DataMember(Name = "postalAddress", EmitDefaultValue = true)]
        public string PostalAddress { get; set; }

        /// <summary>
        /// Gets or Sets PreferredLanguage
        /// </summary>
        [DataMember(Name = "preferredLanguage", EmitDefaultValue = false)]
        public string PreferredLanguage { get; set; }

        /// <summary>
        /// Gets or Sets PrimaryPhone
        /// </summary>
        [DataMember(Name = "primaryPhone", EmitDefaultValue = true)]
        public string PrimaryPhone { get; set; }

        /// <summary>
        /// Gets or Sets ProfileUrl
        /// </summary>
        [DataMember(Name = "profileUrl", EmitDefaultValue = false)]
        public string ProfileUrl { get; set; }

        /// <summary>
        /// Gets or Sets SecondEmail
        /// </summary>
        [DataMember(Name = "secondEmail", EmitDefaultValue = true)]
        public string SecondEmail { get; set; }

        /// <summary>
        /// Gets or Sets State
        /// </summary>
        [DataMember(Name = "state", EmitDefaultValue = true)]
        public string State { get; set; }

        /// <summary>
        /// Gets or Sets StreetAddress
        /// </summary>
        [DataMember(Name = "streetAddress", EmitDefaultValue = true)]
        public string StreetAddress { get; set; }

        /// <summary>
        /// Gets or Sets Timezone
        /// </summary>
        [DataMember(Name = "timezone", EmitDefaultValue = false)]
        public string Timezone { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [DataMember(Name = "title", EmitDefaultValue = false)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets UserType
        /// </summary>
        [DataMember(Name = "userType", EmitDefaultValue = false)]
        public string UserType { get; set; }

        /// <summary>
        /// Gets or Sets ZipCode
        /// </summary>
        [DataMember(Name = "zipCode", EmitDefaultValue = true)]
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or Sets additional properties
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UserProfile {\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  CostCenter: ").Append(CostCenter).Append("\n");
            sb.Append("  CountryCode: ").Append(CountryCode).Append("\n");
            sb.Append("  Department: ").Append(Department).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Division: ").Append(Division).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  EmployeeNumber: ").Append(EmployeeNumber).Append("\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  HonorificPrefix: ").Append(HonorificPrefix).Append("\n");
            sb.Append("  HonorificSuffix: ").Append(HonorificSuffix).Append("\n");
            sb.Append("  LastName: ").Append(LastName).Append("\n");
            sb.Append("  Locale: ").Append(Locale).Append("\n");
            sb.Append("  Login: ").Append(Login).Append("\n");
            sb.Append("  Manager: ").Append(Manager).Append("\n");
            sb.Append("  ManagerId: ").Append(ManagerId).Append("\n");
            sb.Append("  MiddleName: ").Append(MiddleName).Append("\n");
            sb.Append("  MobilePhone: ").Append(MobilePhone).Append("\n");
            sb.Append("  NickName: ").Append(NickName).Append("\n");
            sb.Append("  Organization: ").Append(Organization).Append("\n");
            sb.Append("  PostalAddress: ").Append(PostalAddress).Append("\n");
            sb.Append("  PreferredLanguage: ").Append(PreferredLanguage).Append("\n");
            sb.Append("  PrimaryPhone: ").Append(PrimaryPhone).Append("\n");
            sb.Append("  ProfileUrl: ").Append(ProfileUrl).Append("\n");
            sb.Append("  SecondEmail: ").Append(SecondEmail).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  StreetAddress: ").Append(StreetAddress).Append("\n");
            sb.Append("  Timezone: ").Append(Timezone).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  UserType: ").Append(UserType).Append("\n");
            sb.Append("  ZipCode: ").Append(ZipCode).Append("\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as UserProfile);
        }

        /// <summary>
        /// Returns true if UserProfile instances are equal
        /// </summary>
        /// <param name="input">Instance of UserProfile to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserProfile input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.City == input.City ||
                    (this.City != null &&
                    this.City.Equals(input.City))
                ) && 
                (
                    this.CostCenter == input.CostCenter ||
                    (this.CostCenter != null &&
                    this.CostCenter.Equals(input.CostCenter))
                ) && 
                (
                    this.CountryCode == input.CountryCode ||
                    (this.CountryCode != null &&
                    this.CountryCode.Equals(input.CountryCode))
                ) && 
                (
                    this.Department == input.Department ||
                    (this.Department != null &&
                    this.Department.Equals(input.Department))
                ) && 
                (
                    this.DisplayName == input.DisplayName ||
                    (this.DisplayName != null &&
                    this.DisplayName.Equals(input.DisplayName))
                ) && 
                (
                    this.Division == input.Division ||
                    (this.Division != null &&
                    this.Division.Equals(input.Division))
                ) && 
                (
                    this.Email == input.Email ||
                    (this.Email != null &&
                    this.Email.Equals(input.Email))
                ) && 
                (
                    this.EmployeeNumber == input.EmployeeNumber ||
                    (this.EmployeeNumber != null &&
                    this.EmployeeNumber.Equals(input.EmployeeNumber))
                ) && 
                (
                    this.FirstName == input.FirstName ||
                    (this.FirstName != null &&
                    this.FirstName.Equals(input.FirstName))
                ) && 
                (
                    this.HonorificPrefix == input.HonorificPrefix ||
                    (this.HonorificPrefix != null &&
                    this.HonorificPrefix.Equals(input.HonorificPrefix))
                ) && 
                (
                    this.HonorificSuffix == input.HonorificSuffix ||
                    (this.HonorificSuffix != null &&
                    this.HonorificSuffix.Equals(input.HonorificSuffix))
                ) && 
                (
                    this.LastName == input.LastName ||
                    (this.LastName != null &&
                    this.LastName.Equals(input.LastName))
                ) && 
                (
                    this.Locale == input.Locale ||
                    (this.Locale != null &&
                    this.Locale.Equals(input.Locale))
                ) && 
                (
                    this.Login == input.Login ||
                    (this.Login != null &&
                    this.Login.Equals(input.Login))
                ) && 
                (
                    this.Manager == input.Manager ||
                    (this.Manager != null &&
                    this.Manager.Equals(input.Manager))
                ) && 
                (
                    this.ManagerId == input.ManagerId ||
                    (this.ManagerId != null &&
                    this.ManagerId.Equals(input.ManagerId))
                ) && 
                (
                    this.MiddleName == input.MiddleName ||
                    (this.MiddleName != null &&
                    this.MiddleName.Equals(input.MiddleName))
                ) && 
                (
                    this.MobilePhone == input.MobilePhone ||
                    (this.MobilePhone != null &&
                    this.MobilePhone.Equals(input.MobilePhone))
                ) && 
                (
                    this.NickName == input.NickName ||
                    (this.NickName != null &&
                    this.NickName.Equals(input.NickName))
                ) && 
                (
                    this.Organization == input.Organization ||
                    (this.Organization != null &&
                    this.Organization.Equals(input.Organization))
                ) && 
                (
                    this.PostalAddress == input.PostalAddress ||
                    (this.PostalAddress != null &&
                    this.PostalAddress.Equals(input.PostalAddress))
                ) && 
                (
                    this.PreferredLanguage == input.PreferredLanguage ||
                    (this.PreferredLanguage != null &&
                    this.PreferredLanguage.Equals(input.PreferredLanguage))
                ) && 
                (
                    this.PrimaryPhone == input.PrimaryPhone ||
                    (this.PrimaryPhone != null &&
                    this.PrimaryPhone.Equals(input.PrimaryPhone))
                ) && 
                (
                    this.ProfileUrl == input.ProfileUrl ||
                    (this.ProfileUrl != null &&
                    this.ProfileUrl.Equals(input.ProfileUrl))
                ) && 
                (
                    this.SecondEmail == input.SecondEmail ||
                    (this.SecondEmail != null &&
                    this.SecondEmail.Equals(input.SecondEmail))
                ) && 
                (
                    this.State == input.State ||
                    (this.State != null &&
                    this.State.Equals(input.State))
                ) && 
                (
                    this.StreetAddress == input.StreetAddress ||
                    (this.StreetAddress != null &&
                    this.StreetAddress.Equals(input.StreetAddress))
                ) && 
                (
                    this.Timezone == input.Timezone ||
                    (this.Timezone != null &&
                    this.Timezone.Equals(input.Timezone))
                ) && 
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) && 
                (
                    this.UserType == input.UserType ||
                    (this.UserType != null &&
                    this.UserType.Equals(input.UserType))
                ) && 
                (
                    this.ZipCode == input.ZipCode ||
                    (this.ZipCode != null &&
                    this.ZipCode.Equals(input.ZipCode))
                )
                && (this.AdditionalProperties.Count == input.AdditionalProperties.Count && !this.AdditionalProperties.Except(input.AdditionalProperties).Any());
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                
                if (this.City != null)
                {
                    hashCode = (hashCode * 59) + this.City.GetHashCode();
                }
                if (this.CostCenter != null)
                {
                    hashCode = (hashCode * 59) + this.CostCenter.GetHashCode();
                }
                if (this.CountryCode != null)
                {
                    hashCode = (hashCode * 59) + this.CountryCode.GetHashCode();
                }
                if (this.Department != null)
                {
                    hashCode = (hashCode * 59) + this.Department.GetHashCode();
                }
                if (this.DisplayName != null)
                {
                    hashCode = (hashCode * 59) + this.DisplayName.GetHashCode();
                }
                if (this.Division != null)
                {
                    hashCode = (hashCode * 59) + this.Division.GetHashCode();
                }
                if (this.Email != null)
                {
                    hashCode = (hashCode * 59) + this.Email.GetHashCode();
                }
                if (this.EmployeeNumber != null)
                {
                    hashCode = (hashCode * 59) + this.EmployeeNumber.GetHashCode();
                }
                if (this.FirstName != null)
                {
                    hashCode = (hashCode * 59) + this.FirstName.GetHashCode();
                }
                if (this.HonorificPrefix != null)
                {
                    hashCode = (hashCode * 59) + this.HonorificPrefix.GetHashCode();
                }
                if (this.HonorificSuffix != null)
                {
                    hashCode = (hashCode * 59) + this.HonorificSuffix.GetHashCode();
                }
                if (this.LastName != null)
                {
                    hashCode = (hashCode * 59) + this.LastName.GetHashCode();
                }
                if (this.Locale != null)
                {
                    hashCode = (hashCode * 59) + this.Locale.GetHashCode();
                }
                if (this.Login != null)
                {
                    hashCode = (hashCode * 59) + this.Login.GetHashCode();
                }
                if (this.Manager != null)
                {
                    hashCode = (hashCode * 59) + this.Manager.GetHashCode();
                }
                if (this.ManagerId != null)
                {
                    hashCode = (hashCode * 59) + this.ManagerId.GetHashCode();
                }
                if (this.MiddleName != null)
                {
                    hashCode = (hashCode * 59) + this.MiddleName.GetHashCode();
                }
                if (this.MobilePhone != null)
                {
                    hashCode = (hashCode * 59) + this.MobilePhone.GetHashCode();
                }
                if (this.NickName != null)
                {
                    hashCode = (hashCode * 59) + this.NickName.GetHashCode();
                }
                if (this.Organization != null)
                {
                    hashCode = (hashCode * 59) + this.Organization.GetHashCode();
                }
                if (this.PostalAddress != null)
                {
                    hashCode = (hashCode * 59) + this.PostalAddress.GetHashCode();
                }
                if (this.PreferredLanguage != null)
                {
                    hashCode = (hashCode * 59) + this.PreferredLanguage.GetHashCode();
                }
                if (this.PrimaryPhone != null)
                {
                    hashCode = (hashCode * 59) + this.PrimaryPhone.GetHashCode();
                }
                if (this.ProfileUrl != null)
                {
                    hashCode = (hashCode * 59) + this.ProfileUrl.GetHashCode();
                }
                if (this.SecondEmail != null)
                {
                    hashCode = (hashCode * 59) + this.SecondEmail.GetHashCode();
                }
                if (this.State != null)
                {
                    hashCode = (hashCode * 59) + this.State.GetHashCode();
                }
                if (this.StreetAddress != null)
                {
                    hashCode = (hashCode * 59) + this.StreetAddress.GetHashCode();
                }
                if (this.Timezone != null)
                {
                    hashCode = (hashCode * 59) + this.Timezone.GetHashCode();
                }
                if (this.Title != null)
                {
                    hashCode = (hashCode * 59) + this.Title.GetHashCode();
                }
                if (this.UserType != null)
                {
                    hashCode = (hashCode * 59) + this.UserType.GetHashCode();
                }
                if (this.ZipCode != null)
                {
                    hashCode = (hashCode * 59) + this.ZipCode.GetHashCode();
                }
                if (this.AdditionalProperties != null)
                {
                    hashCode = (hashCode * 59) + this.AdditionalProperties.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
