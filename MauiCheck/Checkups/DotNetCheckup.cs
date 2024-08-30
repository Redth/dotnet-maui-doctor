using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using DotNetCheck.DotNet;
using DotNetCheck.Models;
using DotNetCheck.Solutions;
using Microsoft.Deployment.DotNet.Releases;
using Microsoft.NET.Sdk.WorkloadManifestReader;
using Newtonsoft.Json.Linq;
using NuGet.Versioning;

namespace DotNetCheck.Checkups
{
	public class DotNetCheckup : Checkup
	{
		public ProductRelease? AvailableSdk
			=> Manifest?.Check?.DotNet?.Release;

		public override string Id => "dotnet";

		public override string Title => $".NET SDK";

		public override bool ShouldExamine(SharedState history)
			=> AvailableSdk is not null;

		public override async Task<DiagnosticResult> Examine(SharedState history)
		{
			var dn = new DotNetSdksService(history);

			var missingDiagnosis = new DiagnosticResult(Status.Error, this, new Suggestion(".NET SDK not installed"));

			if (!dn.Exists)
				return missingDiagnosis;

			var sdks = await dn.GetSdks();

			if (AvailableSdk is null)
			{
				return new DiagnosticResult(Status.Error, this, "Cannot query available sdks");
			}

			var availableMajor = AvailableSdk.Version.Major;
			
			DotNetSdkInfo bestSdk = null;
			
			foreach (var sdk in sdks)
			{
				// if the sdk's major version is the available one's major
				// we should be ok, but we can maybe warn still if it's an older minor/patch
				if (bestSdk is null || sdk.Version.Major >= AvailableSdk.Version.Major)
				{
					// We'll settle for any SDK with this or newer major version
					bestSdk = sdk;
					
					// Ideally the SDK's minor and patch are >= the available one
					if (sdk.Version.Minor >= AvailableSdk.Version.Minor && sdk.Version.Patch >= AvailableSdk.Version.Patch)
					{
						ReportStatus($"{sdk.Version} - {sdk.Directory}", Status.Ok);
					}
					else // Warn if the minor/patch versions aren't newest
					{
						ReportStatus($"{sdk.Version} - {sdk.Directory}", Status.Warning);
					}
				}
				else
					ReportStatus($"{sdk.Version} - {sdk.Directory}", null);
			}
			
			// Find newest compatible sdk
			if (bestSdk != null)
			{
				history.SetEnvironmentVariable("DOTNET_SDK", bestSdk.Directory.FullName);
				history.SetEnvironmentVariable("DOTNET_SDK_VERSION", bestSdk.Version.ToString());
			}

			if (bestSdk is null)
			{
				var remedies = new List<Solution>();

				var currentRid = RuntimeInformation.RuntimeIdentifier;

				var newestAvailableSdk = AvailableSdk.Sdks.OrderByDescending(
						s => s.Version).First();

				var sdkFilesForRid = newestAvailableSdk
					.Files.Where(f => f.Rid.Equals(currentRid, StringComparison.OrdinalIgnoreCase));
				
				if (Util.CI)
				{
					remedies.Add(new DotNetSdkScriptInstallSolution(newestAvailableSdk.Version.ToString()));
				}
				else
				{
					if (OperatingSystem.IsWindows())
					{
						var windowsInstaller = sdkFilesForRid.FirstOrDefault(f =>
								f.FileName.EndsWith(".exe"));

						if (windowsInstaller is not null)
						{
							remedies.Add(new MsInstallerSolution(windowsInstaller.Address, $".NET SDK {AvailableSdk.Version} ({windowsInstaller.Rid}"));
						}
					}
					else if (OperatingSystem.IsMacOS())
					{
						var macInstaller = sdkFilesForRid.FirstOrDefault(f =>
								f.FileName.EndsWith(".pkg"));

						if (macInstaller is not null)
						{
							remedies.Add(new BootsSolution(macInstaller.Address, $".NET SDK {AvailableSdk.Version} ({macInstaller.Rid}"));
						}
					}
				}

				return new DiagnosticResult(Status.Error, this, $".NET SDK {AvailableSdk.Version} not installed.",
							new Suggestion($"Download .NET SDK {AvailableSdk.Version}",
							remedies.ToArray()));
			}

			return new DiagnosticResult(Status.Ok, this);
		}
	}
}
