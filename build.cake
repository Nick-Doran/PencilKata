#tool "nuget:?package=Microsoft.TestPlatform&version=15.7.0"
#tool "nuget:?package=NUnitTestAdapter&version=2.1.1"

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var slnFile = "./PencilKata/PencilKata.sln";

Task("Restore-NuGet-Packages").Does(() =>
{
    NuGetRestore(slnFile);
});

Task("Build").IsDependentOn("Restore-NuGet-Packages").Does(() =>
{
    MSBuild(slnFile, settings => settings.SetConfiguration(configuration));
});

public string getNUnit2AdapterPath(){
   var nugetPaths = GetDirectories("./tools/NUnitTestAdapter*/tools");
    
   if(nugetPaths.Count == 0){
       throw new Exception("Cannot locate the NUnit2 test adapter. You might need to add '#tool \"nuget:?package=NUnitTestAdapter&version=2.1.1\"' to the top of your build.cake file.");
   }

   return nugetPaths.Last().ToString();
}

Task("Run-Tests").IsDependentOn("Build").Does(() =>
 {
        var projects = GetFiles("./PencilKata/PencilKataTests/PencilKataTests.csproj");
        foreach(var project in projects)
        {
            DotNetCoreTest(
                project.FullPath,
                new DotNetCoreTestSettings()
                {
                    Configuration = configuration,
                    NoBuild = true
                });
        }
    });

Task("Default").IsDependentOn("Run-Tests");

RunTarget(target);