[<img src="https://aws1.discourse-cdn.com/standard14/uploads/oktadev/original/1X/0c6402653dfb70edc661d4976a43a46f33e5e919.png" align="right" width="256px"/>](https://devforum.okta.com/)

[![Support](https://img.shields.io/badge/support-Developer%20Forum-blue.svg)][devforum]
[![API Reference](https://img.shields.io/badge/docs-reference-lightgrey.svg)][dotnetdocs]

# Swagger v3 CodeGen

* [Getting started](#getting-started)
* [Generator customizations](#generator-customization)
* [Contributing](#contributing)

This folder contains all the files required to generate the Okta management SDK for .NET with the management Open API spec V3. 

We use the [Swagger CLI](https://github.com/swagger-api/swagger-codegen) and our own customization of the [CSharp generators](https://github.com/swagger-api/swagger-codegen-generators) to generate API clients that follow the existing SDK pattern and avoid breaking changes.

## Getting Started

You need to follow the next steps to get the SDK generated with Swagger V3.

* [Create a new build of the Swagger Generators project](https://github.com/swagger-api/swagger-codegen-generators) using our own customization of the CSharp generators.
    1. Clone the Swagger Generators repository, and override the files located in the `dotnet` folder with the files located in `dotnet-generators`
    ![image info](./content/img/swagger-generators-custom.png)
    1. Generate a new Maven package running `c:\source\oas3-migration\swagger-codegen-generators>mvn clean install -DskipTests=true`
* [Make the Swagger CodeGen V3](https://github.com/swagger-api/swagger-codegen/tree/3.0.0) package to pick up the new generators dependency.
    1. Clone the Swagger CodeGen project and make sure you are on the [V3 branch](https://github.com/swagger-api/swagger-codegen/tree/3.0.0)
    1. Once you generated a new Maven package of the Swagger generators, you have to generate a new package of the Swagger CodeGen V3 project so the new dependecy generators dependency is picked up: `c:\source\oas3-migration\swagger-codegen>mvn clean install -DskipTests=true`
* Generate the SDK clients 
    1. Run the following command to generate the V3 clients and models:
    ```sh
    c:\source\oas3-migration\swagger-codegen>java --add-opens=java.base/java.util=ALL-UNNAMED -jar modules/swagger-codegen-cli/target/swagger-codegen-cli.jar generate -l csharp -i c:/source/okta-oas3/dist/management.json -o /tmp/dotnet -t C:/source/oas3-migration/dotnet-swagger-templates -c ./config.json
    ```
    > Note that the language is csharp (`-l csharp`), and the input is the V3 Open API spec (`-i c:/source/okta-oas3/dist/management.json`), and the output is dropped into the folder `/tmp/dotnet` (`-o /tmp/dotnet`), and the templates are grabbed from `C:/source/oas3-migration/dotnet-swagger-templates` (`-t C:/source/oas3-migration/dotnet-swagger-templates`), and additional configuration is grabbed from the config.json file (`-c ./config.json`).
    You must use the templates and configuration located in this folder.
* Put the generated files (clients and models) into the SDK generated folder and make sure the project compiles

## Generator customizations

We strongly suggest and avoid customizing the CodeGen Core project. However, we encourage customizations in the generators project (dotnet folder files) to maintain the current SDK style and avoid breaking changes.

### Templates

We have customized the following templates:

* api.mustache
* IApi.mustache
* model.mustache (includes enums)
* IModel.mustache


### General customizations

* We return `CollectionClient` instead of `List` or `Collection` to be consistent with the existing SDK pattern.
* Unlike the default Swagger generator, we generate interfaces and enums in separate files.
* Operations return interfaces instead of classes when applicable
* Operations receive interfaces instead of classes when applicable
* Files are generated with the `.generated.cs` suffix, or `.DELETE.generated.cs` if the file should be deleted after the generation process.

### Vendor Extensions

We added the following vendor extensions to facilitate the template generation.

* `internalReturnType` - While `operation.ReturnType` contains an interface to be returned by a method, `internalReturnType` contains the corresponding class to be returned by the internal `GetAsync/PostAsync/etc` methods.
* `operationHasParams` - Indicate if an operation has params 
* `hasCancellationToken` - Indicate if an operation should include a cancellation token 
* `isReturnTypeCollection` - Indicate if an operation should return a `CollectionClient`
* `internalHttpOperation` - Indicate what internal method should be called based on the Http method (POST -> PostAsync)

For `enumVars` we added an additional property called `enumMemberName` which has the enum name after being formatted following current SDK patterns. For example, the enum value `SAML_2_0` is renamed to `Saml20`.
 
## Contributing
 
We're happy to accept contributions and PRs! Please see the [contribution guide](CONTRIBUTING.md) to understand how to structure a contribution.

[devforum]: https://devforum.okta.com/
[dotnetdocs]: https://developer.okta.com/okta-sdk-dotnet/latest/
[lang-landing]: https://developer.okta.com/code/dotnet/
[github-issues]: https://github.com/okta/okta-sdk-dotnet/issues
[github-releases]: https://github.com/okta/okta-sdk-dotnet/releases

