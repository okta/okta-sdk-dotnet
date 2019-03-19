# Okta .NET management SDK migration guide

This library uses semantic versioning and follows Okta's [library version policy](https://developer.okta.com/code/library-versions/). In short, we don't make breaking changes unless the major version changes!

## Migrating from 0.3.3 to 1.x

The previous version of this library, [Okta.Core.Client](https://www.nuget.org/packages/Okta.Core.Client), has been rewritten from the ground up as [Okta.Sdk](https://www.nuget.org/packages/Okta.Sdk) (this project). This was done to improve stability and to add support for .NET Core alongside .NET Framework.

Because this was a breaking change, Okta.Sdk was published with version numbers starting from 1.0. The last published version of Okta.Core.Client is 0.3.3.



### New configuration model

This library now supports a flexible [configuration model](https://github.com/okta/okta-sdk-dotnet#configuration-reference) that allows you to provide configuration in code, via a JSON or YAML file, or via environment variables.

The simplest way to construct a client is via code:

```csharp
var client = new OktaClient(new OktaClientConfiguration
{
    OrgUrl = "https://{{yourOktaDomain}}",
    Token = "{{yourApiToken}}"
});
```

### New method organization

In version 0.3.3, you had to create a `new UsersClient()` or call `client.GetUsersClient()` to get access to methods that operated on a User (for example). This has now been simplified to `client.Users`:

```csharp
var vader = await client.Users.CreateUserAsync(...);
```

The `Users` object acts as a collection, so you can also do:

```csharp
var allUsers = await client.Users.ToArray();
```

The [readme](https://github.com/okta/okta-sdk-dotnet#usage-guide) in this repository contains a number of usage examples.

### Async by default

In version 1.0 and above, every method that makes a network call is Task-returning and awaitable. Use `await` when calling these methods, and avoid using `.Result` or `.Wait()` unless absolutely necessary.

### Authentication API support moved

In version 0.3.3, the `AuthClient` class provided the ability to call the [Authentication API](https://developer.okta.com/docs/api/resources/authn) to log a user in with a username and password, or perform other tasks like enrolling and challenging factors during authentication.  The object and security model of the Authentication API compared the rest of the management APIs (Users, Factors, Groups, etc.) is different enough that it made sense to split it into two libraries.

Starting with version 1.0, Authentication has been broken out into a separate library, the [Okta .NET Authentication SDK](https://github.com/okta/okta-auth-dotnet).

Many applications can use our [ASP.NET and ASP.NET Core middleware](https://github.com/okta/okta-aspnet) to log users in without needing to call the Authentication API directly, and we recommend only using the Authentication SDK in complex scenarios that can't be handled with the middleware or widget.

## Getting help

If you have questions about this library or about the Okta APIs, post a question on our [Developer Forum](https://devforum.okta.com).

If you find a bug or have a feature request for this library specifically, [post an issue](https://github.com/okta/okta-sdk-dotnet/issues) here on GitHub.
