#addin "Cake.Git"
#addin "Cake.GitPackager"
#addin "Cake.DocFx"
#addin "Cake.FileHelpers";
#tool "docfx.console"


// Helper method for setting a lot of file attributes at once
public FilePath[] SetFileAttributes(FilePathCollection files, System.IO.FileAttributes fileAttributes)
{
    var results = new System.Collections.Concurrent.ConcurrentBag<FilePath>();

    Parallel.ForEach(files, f =>
    {
        System.IO.File.SetAttributes(f.FullPath, fileAttributes);
        results.Add(f);
    });

    return results.ToArray();
}


// Default MSBuild configuration arguments

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
    FilePath artifactLocation = File("./src/Okta.Sdk/bin/Release/netstandard1.3/Okta.Sdk.dll");
    DocFxMetadata(new DocFxMetadataSettings
    {
        OutputPath = MakeAbsolute(Directory("./docs/api/")),
        Projects = new[] { artifactLocation }
    });

    DocFxBuild("./docs/docfx.json");
    // Outputs to docs/_site
});

Task("CloneExistingDocs")
.Does(() =>
{
    var tempDir = "./docs/temp";

    if (DirectoryExists(tempDir))
    {
        // Some git files are read-only, so recursively remove any attributes:
        SetFileAttributes(GetFiles(tempDir + "/**/*.*"), System.IO.FileAttributes.Normal);
        
        DeleteDirectory(tempDir, recursive: true);
    }

    GitClone("https://github.com/okta/okta-sdk-dotnet.git",
            tempDir,
            new GitCloneSettings
            {
                BranchName = "gh-pages",
            });
});


Task("CopyDocsToVersionedDirectories")
.IsDependentOn("BuildDocs")
.IsDependentOn("CloneExistingDocs")
.Does(() =>
{
    DeleteDirectory("./docs/temp/latest", recursive: true);
    Information("Copying docs to docs/temp/latest");
    CopyDirectory("./docs/_site/", "./docs/temp/latest/");

    var travisTag = EnvironmentVariable("TRAVIS_TAG");
    if (string.IsNullOrEmpty(travisTag))
    {
        Console.WriteLine("TRAVIS_TAG not set, won't copy docs to a tagged directory");
        return;
    }

    var taggedVersion = travisTag.TrimStart('v');
    var tagDocsDirectory = string.Format("./docs/temp/{0}", taggedVersion);

    Information("Copying docs to " + tagDocsDirectory);
    CopyDirectory("./docs/_site/", tagDocsDirectory);
});

Task("CreateRootRedirector")
.Does(() =>
{
    FileWriteText("./docs/temp/index.html",
        @"<meta http-equiv=""refresh"" content=""0; url=https://developer.okta.com/okta-sdk-dotnet/latest/"">");
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
    .IsDependentOn("CloneExistingDocs")
    .IsDependentOn("CopyDocsToVersionedDirectories")
    .IsDependentOn("CreateRootRedirector");
// Travis Github Pages deployment plugin takes the docs the rest of the way
// (see .travis.yml)


// Default task
var target = Argument("target", "Default");
RunTarget(target);
