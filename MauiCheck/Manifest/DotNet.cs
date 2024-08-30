using System.Collections.Generic;
using Microsoft.Deployment.DotNet.Releases;
using Newtonsoft.Json;

namespace DotNetCheck.Manifest
{
	public partial class DotNet
	{
		[JsonProperty("sdks")]
		public List<DotNetSdk> Sdks { get; set; }
		
		public ProductRelease Release { get; set; }
	}
}
