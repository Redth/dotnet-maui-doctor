using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Deployment.DotNet.Releases;
using Newtonsoft.Json;

namespace DotNetCheck.Manifest
{
	public partial class Manifest
	{
		public const string DefaultManifestUrl = "https://aka.ms/dotnet-maui-check-manifest";
		public const string PreviewManifestUrl = "https://aka.ms/dotnet-maui-check-manifest-preview";

		public static Task<Manifest> FromFileOrUrl(string fileOrUrl)
		{
			if (fileOrUrl.StartsWith("http", StringComparison.OrdinalIgnoreCase))
				return FromUrl(fileOrUrl);

			return FromFile(fileOrUrl);
		}

		public static async Task<Manifest> FromFile(string filename)
		{
			var json = await System.IO.File.ReadAllTextAsync(filename);
			return await FromJson(json);
		}

		public static async Task<Manifest> FromUrl(string url)
		{
			var http = new HttpClient();
			var json = await http.GetStringAsync(url);

			return await FromJson(json);
		}

		public static async Task<Manifest> FromJson(string json)
		{
			var m = JsonConvert.DeserializeObject<Manifest>(json, new JsonSerializerSettings {
				TypeNameHandling = TypeNameHandling.Auto
			});

			await m.Check.MapVariables();

			if (m.Check.DotNet is null)
				m.Check.DotNet = new DotNet();
			
			m.Check.DotNet.Release = await GetLatestDotNetRelease();
			
			return m;
		}

		static async Task<ProductRelease> GetLatestDotNetRelease()
		{
			var c = await ProductCollection.GetAsync();

			var interesting = c.Where(p =>
					p.ProductName == ".NET"
					&& p.SupportPhase is SupportPhase.Active or SupportPhase.Maintenance)
				.OrderByDescending(p => p.ProductVersion);

			ProductRelease latestOverall = null;

			foreach (var prod in interesting)
			{
				var prodReleases = await prod.GetReleasesAsync();
				var latestRelease = prodReleases.OrderByDescending(r => r.Version).First();

				if (latestOverall is null || latestRelease.Version > latestOverall.Version)
				{
					latestOverall = latestRelease;
				}
			}

			return latestOverall;
		}

		[JsonProperty("check")]
		public Check Check { get; set; }
	}
}
