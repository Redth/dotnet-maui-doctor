using DotNetCheck.Models;
using DotNetCheck.Solutions;
using NuGet.Versioning;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Android.Tools;

namespace DotNetCheck.Checkups
{
	public class OpenJdkInfo
	{
		public OpenJdkInfo(string javaCFile, NuGetVersion version)
		{
			JavaC = new FileInfo(javaCFile);
			Version = version;
		}

		public FileInfo JavaC { get; set; }

		public DirectoryInfo Directory
			=> new DirectoryInfo(Path.Combine(JavaC.Directory.FullName, ".."));

		public NuGetVersion Version { get; set; }
	}

	public class OpenJdkCheckup : Models.Checkup
	{
		public NuGetVersion Version
			=> Extensions.ParseVersion(Manifest?.Check?.OpenJdk?.CompatVersion, new NuGetVersion("1.8.0-25"));

		public bool RequireExact
			=> Manifest?.Check?.OpenJdk?.RequireExact ?? false;

		public override string Id => "openjdk";

		public override string Title => $"OpenJDK {Version}";

		static string PlatformJavaCExtension => Util.IsWindows ? ".exe" : string.Empty;

		public override bool ShouldExamine(SharedState history)
			=> Manifest?.Check?.OpenJdk != null;

		public override Task<DiagnosticResult> Examine(SharedState history)
		{
			var jdkLocator = new AndroidSdk.JdkLocator();
			var jdks = jdkLocator.LocateJdk();

			var ok = false;

			foreach (var jdk in jdks)
			{
				if ((jdk.JavaC.FullName.Contains("microsoft", StringComparison.OrdinalIgnoreCase) || jdk.JavaC.FullName.Contains("openjdk", StringComparison.OrdinalIgnoreCase))
					&& jdk.Version.IsCompatible(Version, RequireExact ? Version : null))
				{
					ok = true;
					ReportStatus($"{jdk.Version} ({jdk.Directory})", Status.Ok);
					history.SetEnvironmentVariable("JAVA_HOME", jdk.Directory.FullName);

					// Try and set the global env var on windows if it's not set
					if (Util.IsWindows && string.IsNullOrEmpty(Environment.GetEnvironmentVariable("JAVA_HOME")))
					{
						try
						{
							Environment.SetEnvironmentVariable("JAVA_HOME", jdk.Directory.FullName, EnvironmentVariableTarget.Machine);
							ReportStatus($"Set Environment Variable: JAVA_HOME={jdk.Directory.FullName}", Status.Ok);
						} catch { }
					}
				}
				else
					ReportStatus($"{jdk.Version} ({jdk.Directory.FullName})", null);
			}

			if (ok)
				return Task.FromResult(DiagnosticResult.Ok(this));

			return Task.FromResult(new DiagnosticResult(Status.Error, this,
				new Suggestion("Install OpenJDK",
					new BootsSolution(Manifest?.Check?.OpenJdk?.Url, "Download and Install Microsoft OpenJDK"))));
		}

	}
}
