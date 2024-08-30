using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NuGet.Versioning;

namespace DotNetCheck.Services.Android;

public class AndroidRequirements
{
    public VersionRange BuildTools { get; set; }
    public VersionRange PlatformTools { get; set; }
    public VersionRange PackageTools { get; set; }
    
}

public class AndroidRequirementsService
{
    public const int AbsoluteMinimumAndroidApiLevel = 33;
    readonly NuGetVersion AbsoluteMinimumApiVersion = new (AbsoluteMinimumAndroidApiLevel, 0, 0);
    
    public async Task<XamarinAndroid> GetFeedAsync()
    {
        var url = "https://download.visualstudio.microsoft.com/download/pr/787dbee3-c709-46a2-a1c3-cc1db8a89953/f6c7091fafe330cc96aa6b74d995494e/androidmanifestfeed_d17.12.xml";

        var x = await DeserializeXmlFromUrlAsync<XamarinAndroid>(url);

        var r = new AndroidRequirements();
        
        r.BuildTools = new VersionRange(
            x?.BuildTool?.OrderByDescending(b => b.Version)?.FirstOrDefault(b => b.Version >= AbsoluteMinimumApiVersion)?.Version
                ?? AbsoluteMinimumApiVersion);
        
        r.PlatformTools = new VersionRange(
            x?.PlatformTools?.OrderByDescending(b => b.Version)?.FirstOrDefault(p => p.Version >= AbsoluteMinimumApiVersion)?.Version
                ?? AbsoluteMinimumApiVersion);
        
        return x;
    }
    
    static async Task<T> DeserializeXmlFromUrlAsync<T>(string url)
    {
        using var client = new HttpClient();
        
        HttpResponseMessage response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var xmlContent = await response.Content.ReadAsStringAsync();
            
            var serializer = new XmlSerializer(typeof(T));
            using var reader = new StringReader(xmlContent);
            
            return (T)serializer.Deserialize(reader);
        }
        else
        {
            throw new Exception($"Error fetching data from {url}. Status code: {response.StatusCode}");
        }
    }
}