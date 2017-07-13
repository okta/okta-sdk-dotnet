#addin "Cake.DocFx"
#tool "docfx.console"

var configuration = Argument("configuration", "Release");

Task("Clean")
.Does(() =>
{
    CleanDirectory("./artifacts/");

    GetDirectories("./src/**/bin")
        .ToList()
        .ForEach(d => CleanDirectory(d));

    GetDirectories("./src/**/obj")
        .ToList()
        .ForEach(d => CleanDirectory(d));
});

Task("Restore")
.Does(() => 
{
    DotNetCoreRestore("./src/Okta.Sdk.sln");
});

Task("Build")
.IsDependentOn("Restore")
.Does(() =>
{
    var projects = GetFiles("./src/**/*.csproj");
    Console.WriteLine("Building {0} projects", projects.Count());

    foreach (var project in projects)
    {
        Console.WriteLine("Building project ", project.GetFilenameWithoutExtension());
        DotNetCoreBuild(project.FullPath, new DotNetCoreBuildSettings
        {
            Configuration = configuration
        });
    }
});

Task("Pack")
.IsDependentOn("Build")
.Does(() =>
{
    DotNetCorePack("./src/Okta.Sdk/Okta.Sdk.csproj", new DotNetCorePackSettings
    {
        Configuration = configuration,
        OutputDirectory = "./artifacts/"
    });
});

Task("Test")
.IsDependentOn("Restore")
.IsDependentOn("Build")
.Does(() =>
{
    var testProjects = new[] { "Okta.Sdk.UnitTests" };
    // For now, we won't run integration tests in CI

    foreach (var name in testProjects)
    {
        DotNetCoreTest(string.Format("./src/{0}/{0}.csproj", name));
    }
});

Task("BuildDocs")
.Does(() => DocFxBuild("./docs/docfx.json"));

Task("CopyDocsToVersionedDirectories")
.IsDependentOn("BuildDocs")
.Does(() =>
{
    Console.WriteLine("Copying docs to docs/temp/latest");

    if (DirectoryExists("./docs/temp/latest"))
    {
        DeleteDirectory("./docs/temp/latest", recursive: true);
    }
    
    EnsureDirectoryExists("./docs/temp");
    CopyDirectory("./docs/_site/", "./docs/temp/latest/");

    var travisTag = "v1.0.0-alpha1";
    //var travisTag = EnvironmentVariable("TRAVIS_TAG");
    if (string.IsNullOrEmpty(travisTag))
    {
        Console.WriteLine("TRAVIS_TAG not set, won't copy docs to a tagged directory");
        return;
    }

    var taggedVersion = travisTag.TrimStart('v');
    var tagDocsDirectory = string.Format("./docs/temp/{0}", taggedVersion);
    Console.WriteLine("Copying docs to " + tagDocsDirectory);
    CopyDirectory("./docs/_site/", tagDocsDirectory);
});


// Define top-level tasks
Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .IsDependentOn("Build")
    .IsDependentOn("Test")
    .IsDependentOn("Pack");

Task("Docs")
    .IsDependentOn("BuildDocs")
    .IsDependentOn("CopyDocsToVersionedDirectories");


// Default task
var target = Argument("target", "Default");
RunTarget(target);
