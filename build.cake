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
.IsDependentOn("Build")
.Does(() =>
{
    MSBuild("./docs/OktaSdkDocumentation.sln", new MSBuildSettings
    {
        Configuration = configuration,
        Verbosity = Verbosity.Minimal
    });
});

Task("CleanDocsOutput")
.IsDependentOn("BuildDocs")
.Does(() =>
{
    // SHFB generates some junk files we want to get rid of
    
    var filesToRemove = new[]
    {
        "SearchHelp.aspx",
        "SearchHelp.inc.php",
        "SearchHelp.php",
        "LastBuild.log",
        "Web.Config",
    };

    filesToRemove
        .ToList()
        .ForEach(filename => DeleteFile(string.Format("./docs/OktaSdkDocumentation/Output/{0}", filename)));
});

Task("CopyDocsToVersionedDirectories")
.IsDependentOn("CleanDocsOutput")
.Does(() =>
{
    Console.WriteLine("Copying docs to docs/built/latest");

    if (DirectoryExists("./docs/built/latest"))
    {
        DeleteDirectory("./docs/built/latest", recursive: true);
    }
    
    EnsureDirectoryExists("./docs/built");
    CopyDirectory("./docs/OktaSdkDocumentation/Output/", "./docs/built/latest/");

    var travisTag = EnvironmentVariable("TRAVIS_TAG");
    if (string.IsNullOrEmpty(travisTag))
    {
        Console.WriteLine("TRAVIS_TAG not set, won't copy docs to a tagged directory");
        return;
    }

    var taggedVersion = travisTag.TrimStart('v');
    var tagDocsDirectory = string.Format("./docs/built/{0}", taggedVersion);
    Console.WriteLine("Copying docs to " + tagDocsDirectory);
    CopyDirectory("./docs/OktaSdkDocumentation/Output", tagDocsDirectory);
});

Task("Docs")
    .IsDependentOn("Build")
    .IsDependentOn("BuildDocs")
    .IsDependentOn("CleanDocsOutput")
    .IsDependentOn("CopyDocsToVersionedDirectories");

Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .IsDependentOn("Build")
    .IsDependentOn("Test")
    .IsDependentOn("Pack");


// Default task
var target = Argument("target", "Default");
RunTarget(target);
