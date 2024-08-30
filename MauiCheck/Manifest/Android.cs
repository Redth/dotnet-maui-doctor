using System.Collections.Generic;
using Newtonsoft.Json;
using NuGet.Versioning;

namespace DotNetCheck.Manifest
{
	public partial class Android
	{
		[JsonProperty("packages")]
		public List<AndroidPackage> Packages { get; set; }

		[JsonProperty("emulators")]
		public List<AndroidEmulator> Emulators { get; set; }

		[JsonProperty("sdkPackages")]
		public List<AndroidSdkPackageRequirement> SdkPackages { get; set; } = new();
	}

	public class AndroidSdkPackageRequirement
	{
		[JsonProperty("package")]
		public string Package { get; set; }
		
		[JsonProperty("version")]
		public string Version { get; set; }

		internal VersionRange GetVersionRange()
			=> VersionRange.Parse(Version);
	}
}
