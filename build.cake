#addin nuget:?package=Cake.Figlet&version=1.3.1
#addin nuget:?package=Cake.GitPackager&version=0.1.3.2
#addin nuget:?package=Cake.Git&version=0.22.0
#addin nuget:?package=Cake.FileHelpers&version=3.3.0
#tool nuget:?package=docfx.console&version=2.51.0

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

Task("IntegrationTest")
.IsDependentOn("Restore")
.IsDependentOn("Build")
.Does(() =>
{
    var testProjects = new[] { "Okta.Sdk.IntegrationTests" };
    // Run integration tests in nightly travis cron job

    foreach (var name in testProjects)
    {
        DotNetCoreTest(string.Format("./src/{0}/{0}.csproj", name));
    }
});

Task("BuildDocs")
.IsDependentOn("Build")
.Does(() =>
{
    StartProcess(Context.Tools.Resolve("docfx") ?? Context.Tools.Resolve("docfx.exe"), 
                 "./docs/docfx.json");
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

Task("DefaultIT")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .IsDependentOn("Build")
    .IsDependentOn("IntegrationTest")
    .IsDependentOn("Pack");

Task("Docs")
    .IsDependentOn("BuildDocs")
    .IsDependentOn("CloneExistingDocs")
    .IsDependentOn("CopyDocsToVersionedDirectories")
    .IsDependentOn("CreateRootRedirector");

// Default task
var target = Argument("target", "Default");
RunTarget(target);
