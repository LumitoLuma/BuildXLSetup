using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace BuildXL.Setup.BuildTasks
{
    public class InstallNuGetPackage : ToolTask
    {
        [Required]
        public ITaskItem OutputDirectory { get; set; }
        [Required]
        public string Feed { get; set; }
        [Required]
        public string PackageName { get; set; }
        [Required]
        public string PackageVersion { get; set; }
        [Required]
        public ITaskItem PackageCacheDirectory { get; set; }

        public override bool Execute()
        {
            string movedAsideFile = Path.Combine(PackageCacheDirectory.ItemSpec, $"{PackageName}.{PackageVersion}.nupkg");
            string packageFile = Path.Combine(OutputDirectory.ItemSpec, $"{PackageName}.{PackageVersion}", $"{PackageName}.{PackageVersion}.nupkg");
            if (File.Exists(movedAsideFile))
            {
                Log.LogMessage(MessageImportance.Normal, "Moving {0} to {1}", movedAsideFile, packageFile);
                File.Move(movedAsideFile, packageFile);
            }

            bool success = base.Execute();

            if (success)
            {
                if (File.Exists(packageFile))
                {
                    Log.LogMessage(MessageImportance.Normal, "Moving {0} to {1}", packageFile, movedAsideFile);
                    File.Move(packageFile, movedAsideFile);
                }
            }
            else
            {
                if (File.Exists(packageFile))
                {
                    Log.LogWarning("Deleting possible corrupted file {0}", packageFile);
                    File.Delete(packageFile);
                }
            }

            return success;
        }

        protected override string ToolName => "NuGet.exe";

        protected override string GenerateFullPathToTool()
        {
            string location = typeof(InstallNuGetPackage).Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(location), "NuGet.exe");
        }

        protected override string GenerateCommandLineCommands()
        {
            List<string> argv = new List<string>();

            argv.Add("install");
            argv.Add("-OutputDirectory");
            argv.Add(OutputDirectory.ItemSpec);
            argv.Add("-Source");
            argv.Add(Feed);
            argv.Add(PackageName);
            argv.Add("-Version");
            argv.Add(PackageVersion);

            return string.Join(" ", argv.Select(arg =>
            {
                if (arg.Contains(" "))
		{ 
		    return $"\"{arg}\"";
		}
		else
		{
		    return arg;
		}
            }));
        }
    }
}
