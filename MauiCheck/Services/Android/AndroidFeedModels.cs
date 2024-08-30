   /* 
    Licensed under the Apache License, Version 2.0
    
    http://www.apache.org/licenses/LICENSE-2.0
    */
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

namespace DotNetCheck.Services.Android
{
	[XmlRoot(ElementName="url")]
	public class Url {
		[XmlAttribute(AttributeName="host-os")]
		public string HostOs { get; set; }
		[XmlAttribute(AttributeName="host-bits")]
		public string HostBits { get; set; }
		[XmlAttribute(AttributeName="host-arch")]
		public string HostArch { get; set; }
		[XmlAttribute(AttributeName="size")]
		public string Size { get; set; }
		[XmlAttribute(AttributeName="checksum-type")]
		public string ChecksumType { get; set; }
		[XmlAttribute(AttributeName="checksum")]
		public string Checksum { get; set; }
		[XmlAttribute(AttributeName="payloadFileName")]
		public string PayloadFileName { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName="urls")]
	public class Urls {
		[XmlElement(ElementName="url")]
		public List<Url> Url { get; set; }
	}

	[XmlRoot(ElementName="jdk")]
	public class Jdk {
		[XmlElement(ElementName="urls")]
		public Urls Urls { get; set; }
		[XmlAttribute(AttributeName="revision")]
		public string Revision { get; set; }
		[XmlAttribute(AttributeName="description")]
		public string Description { get; set; }
		[XmlAttribute(AttributeName="obsolete")]
		public string Obsolete { get; set; }
		[XmlAttribute(AttributeName="preview")]
		public string Preview { get; set; }
		[XmlAttribute(AttributeName="license")]
		public string License { get; set; }
		[XmlAttribute(AttributeName="vendor-id")]
		public string VendorId { get; set; }
		[XmlAttribute(AttributeName="vendor-display")]
		public string VendorDisplay { get; set; }
		
		[XmlIgnore]
		public NuGetVersion Version 
			=> NuGetVersion.Parse(Revision);
	}

	[XmlRoot(ElementName="platform-tools")]
	public class PlatformTools {
		[XmlElement(ElementName="urls")]
		public Urls Urls { get; set; }
		[XmlAttribute(AttributeName="revision")]
		public string Revision { get; set; }
		[XmlAttribute(AttributeName="path")]
		public string Path { get; set; }
		[XmlAttribute(AttributeName="filesystem-path")]
		public string FileSystemPath { get; set; }
		[XmlAttribute(AttributeName="manifest-url")]
		public string ManifestUrl { get; set; }
		[XmlAttribute(AttributeName="description")]
		public string Description { get; set; }
		[XmlAttribute(AttributeName="obsolete")]
		public string Obsolete { get; set; }
		[XmlAttribute(AttributeName="preview")]
		public string Preview { get; set; }
		[XmlAttribute(AttributeName="license")]
		public string License { get; set; }
		[XmlAttribute(AttributeName="original-type")]
		public string OriginalType { get; set; }
		
		[XmlIgnore]
		public NuGetVersion Version 
			=> NuGetVersion.Parse(Revision);
	}

	[XmlRoot(ElementName="cmdline-tools")]
	public class CmdlineTools {
		[XmlElement(ElementName="urls")]
		public Urls Urls { get; set; }
		[XmlAttribute(AttributeName="revision")]
		public string Revision { get; set; }
		[XmlAttribute(AttributeName="path")]
		public string Path { get; set; }
		[XmlAttribute(AttributeName="filesystem-path")]
		public string FileSystemPath { get; set; }
		[XmlAttribute(AttributeName="manifest-url")]
		public string ManifestUrl { get; set; }
		[XmlAttribute(AttributeName="description")]
		public string Description { get; set; }
		[XmlAttribute(AttributeName="obsolete")]
		public string Obsolete { get; set; }
		[XmlAttribute(AttributeName="preview")]
		public string Preview { get; set; }
		[XmlAttribute(AttributeName="license")]
		public string License { get; set; }
		[XmlAttribute(AttributeName="original-type")]
		public string OriginalType { get; set; }
		
		[XmlIgnore]
		public NuGetVersion Version 
			=> NuGetVersion.Parse(Revision);
	}

	[XmlRoot(ElementName="build-tool")]
	public class BuildTool {
		[XmlElement(ElementName="urls")]
		public Urls Urls { get; set; }
		[XmlAttribute(AttributeName="revision")]
		public string Revision { get; set; }
		[XmlAttribute(AttributeName="path")]
		public string Path { get; set; }
		[XmlAttribute(AttributeName="filesystem-path")]
		public string FileSystemPath { get; set; }
		[XmlAttribute(AttributeName="manifest-url")]
		public string ManifestUrl { get; set; }
		[XmlAttribute(AttributeName="description")]
		public string Description { get; set; }
		[XmlAttribute(AttributeName="obsolete")]
		public string Obsolete { get; set; }
		[XmlAttribute(AttributeName="preview")]
		public string Preview { get; set; }
		[XmlAttribute(AttributeName="license")]
		public string License { get; set; }
		[XmlAttribute(AttributeName="original-type")]
		public string OriginalType { get; set; }
		[XmlElement(ElementName="dependencies")]
		public Dependencies Dependencies { get; set; }
		
		[XmlIgnore]
		public NuGetVersion Version 
			=> NuGetVersion.Parse(Revision);
	}

	[XmlRoot(ElementName="dependency")]
	public class Dependency {
		[XmlAttribute(AttributeName="path")]
		public string Path { get; set; }
		[XmlAttribute(AttributeName="min-revision")]
		public string MinRevision { get; set; }
		[XmlAttribute(AttributeName="host-os")]
		public string HostOs { get; set; }
		
		[XmlIgnore]
		public VersionRange VersionRange 
			=> VersionRange.Parse(MinRevision);
	}

	[XmlRoot(ElementName="dependencies")]
	public class Dependencies {
		[XmlElement(ElementName="dependency")]
		public Dependency Dependency { get; set; }
	}

	[XmlRoot(ElementName="emulator")]
	public class Emulator {
		[XmlElement(ElementName="urls")]
		public Urls Urls { get; set; }
		[XmlAttribute(AttributeName="revision")]
		public string Revision { get; set; }
		[XmlAttribute(AttributeName="path")]
		public string Path { get; set; }
		[XmlAttribute(AttributeName="filesystem-path")]
		public string FileSystemPath { get; set; }
		[XmlAttribute(AttributeName="manifest-url")]
		public string ManifestUrl { get; set; }
		[XmlAttribute(AttributeName="description")]
		public string Description { get; set; }
		[XmlAttribute(AttributeName="obsolete")]
		public string Obsolete { get; set; }
		[XmlAttribute(AttributeName="preview")]
		public string Preview { get; set; }
		[XmlAttribute(AttributeName="license")]
		public string License { get; set; }
		[XmlAttribute(AttributeName="original-type")]
		public string OriginalType { get; set; }
		
		[XmlIgnore]
		public NuGetVersion Version 
			=> NuGetVersion.Parse(Revision);
	}

	[XmlRoot(ElementName="ndk")]
	public class Ndk {
		[XmlElement(ElementName="urls")]
		public Urls Urls { get; set; }
		[XmlAttribute(AttributeName="revision")]
		public string Revision { get; set; }
		[XmlAttribute(AttributeName="path")]
		public string Path { get; set; }
		[XmlAttribute(AttributeName="filesystem-path")]
		public string FileSystemPath { get; set; }
		[XmlAttribute(AttributeName="manifest-url")]
		public string ManifestUrl { get; set; }
		[XmlAttribute(AttributeName="description")]
		public string Description { get; set; }
		[XmlAttribute(AttributeName="obsolete")]
		public string Obsolete { get; set; }
		[XmlAttribute(AttributeName="preview")]
		public string Preview { get; set; }
		[XmlAttribute(AttributeName="license")]
		public string License { get; set; }
		[XmlAttribute(AttributeName="original-type")]
		public string OriginalType { get; set; }
		
		[XmlIgnore]
		public NuGetVersion Version 
			=> NuGetVersion.Parse(Revision);
	}

	[XmlRoot(ElementName="platform")]
	public class Platform {
		[XmlElement(ElementName="urls")]
		public Urls Urls { get; set; }
		[XmlAttribute(AttributeName="revision")]
		public string Revision { get; set; }
		[XmlAttribute(AttributeName="path")]
		public string Path { get; set; }
		[XmlAttribute(AttributeName="filesystem-path")]
		public string FileSystemPath { get; set; }
		[XmlAttribute(AttributeName="manifest-url")]
		public string ManifestUrl { get; set; }
		[XmlAttribute(AttributeName="description")]
		public string Description { get; set; }
		[XmlAttribute(AttributeName="obsolete")]
		public string Obsolete { get; set; }
		[XmlAttribute(AttributeName="preview")]
		public string Preview { get; set; }
		[XmlAttribute(AttributeName="license")]
		public string License { get; set; }
		[XmlAttribute(AttributeName="original-type")]
		public string OriginalType { get; set; }
		[XmlAttribute(AttributeName="api")]
		public string Api { get; set; }
		[XmlAttribute(AttributeName="version")]
		public string Version { get; set; }
		[XmlAttribute(AttributeName="codename")]
		public string Codename { get; set; }
		[XmlAttribute(AttributeName="min-tools-rev")]
		public string MinToolsRev { get; set; }
		[XmlAttribute(AttributeName="layoutlib-api")]
		public string LayoutLibApi { get; set; }
		[XmlAttribute(AttributeName="layoutlib-revision")]
		public string LayoutLibRevision { get; set; }
		
		
	}

	[XmlRoot(ElementName="system-image")]
	public class SystemImage {
		[XmlElement(ElementName="urls")]
		public Urls Urls { get; set; }
		[XmlAttribute(AttributeName="revision")]
		public string Revision { get; set; }
		[XmlAttribute(AttributeName="path")]
		public string Path { get; set; }
		[XmlAttribute(AttributeName="filesystem-path")]
		public string FileSystemPath { get; set; }
		[XmlAttribute(AttributeName="manifest-url")]
		public string ManifestUrl { get; set; }
		[XmlAttribute(AttributeName="description")]
		public string Description { get; set; }
		[XmlAttribute(AttributeName="obsolete")]
		public string Obsolete { get; set; }
		[XmlAttribute(AttributeName="preview")]
		public string Preview { get; set; }
		[XmlAttribute(AttributeName="license")]
		public string License { get; set; }
		[XmlAttribute(AttributeName="original-type")]
		public string OriginalType { get; set; }
		[XmlAttribute(AttributeName="api")]
		public string Api { get; set; }
		[XmlAttribute(AttributeName="abi")]
		public string Abi { get; set; }
		[XmlAttribute(AttributeName="tag-id")]
		public string TagId { get; set; }
		[XmlAttribute(AttributeName="tag-display")]
		public string TagDisplay { get; set; }
		[XmlAttribute(AttributeName="vendor-id")]
		public string VendorId { get; set; }
		[XmlAttribute(AttributeName="vendor-display")]
		public string VendorDisplay { get; set; }
		[XmlAttribute(AttributeName="codename")]
		public string Codename { get; set; }
		[XmlElement(ElementName="dependencies")]
		public Dependencies Dependencies { get; set; }
		
		[XmlIgnore]
		public NuGetVersion Version 
			=> NuGetVersion.Parse(Revision);
	}

	[XmlRoot(ElementName="library")]
	public class Library {
		[XmlAttribute(AttributeName="name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName="local-jar-path")]
		public string LocalJarPath { get; set; }
		[XmlAttribute(AttributeName="description")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName="libraries")]
	public class Libraries {
		[XmlElement(ElementName="library")]
		public List<Library> Library { get; set; }
	}

	[XmlRoot(ElementName="addon")]
	public class Addon {
		[XmlElement(ElementName="urls")]
		public Urls Urls { get; set; }
		[XmlElement(ElementName="libraries")]
		public Libraries Libraries { get; set; }
		[XmlAttribute(AttributeName="revision")]
		public string Revision { get; set; }
		[XmlAttribute(AttributeName="path")]
		public string Path { get; set; }
		[XmlAttribute(AttributeName="filesystem-path")]
		public string FileSystemPath { get; set; }
		[XmlAttribute(AttributeName="manifest-url")]
		public string ManifestUrl { get; set; }
		[XmlAttribute(AttributeName="description")]
		public string Description { get; set; }
		[XmlAttribute(AttributeName="obsolete")]
		public string Obsolete { get; set; }
		[XmlAttribute(AttributeName="preview")]
		public string Preview { get; set; }
		[XmlAttribute(AttributeName="license")]
		public string License { get; set; }
		[XmlAttribute(AttributeName="original-type")]
		public string OriginalType { get; set; }
		[XmlAttribute(AttributeName="api")]
		public string Api { get; set; }
		[XmlAttribute(AttributeName="tag-id")]
		public string TagId { get; set; }
		[XmlAttribute(AttributeName="tag-display")]
		public string TagDisplay { get; set; }
		[XmlAttribute(AttributeName="vendor-id")]
		public string VendorId { get; set; }
		[XmlAttribute(AttributeName="vendor-display")]
		public string VendorDisplay { get; set; }
		[XmlAttribute(AttributeName="codename")]
		public string Codename { get; set; }
		
		[XmlIgnore]
		public NuGetVersion Version 
			=> NuGetVersion.Parse(Revision);
	}

	[XmlRoot(ElementName="extra")]
	public class Extra {
		[XmlElement(ElementName="urls")]
		public Urls Urls { get; set; }
		[XmlAttribute(AttributeName="revision")]
		public string Revision { get; set; }
		[XmlAttribute(AttributeName="path")]
		public string Path { get; set; }
		[XmlAttribute(AttributeName="filesystem-path")]
		public string FileSystemPath { get; set; }
		[XmlAttribute(AttributeName="manifest-url")]
		public string ManifestUrl { get; set; }
		[XmlAttribute(AttributeName="description")]
		public string Description { get; set; }
		[XmlAttribute(AttributeName="obsolete")]
		public string Obsolete { get; set; }
		[XmlAttribute(AttributeName="preview")]
		public string Preview { get; set; }
		[XmlAttribute(AttributeName="license")]
		public string License { get; set; }
		[XmlAttribute(AttributeName="original-type")]
		public string OriginalType { get; set; }
		[XmlAttribute(AttributeName="vendor-id")]
		public string VendorId { get; set; }
		[XmlAttribute(AttributeName="vendor-display")]
		public string VendorDisplay { get; set; }
		
		[XmlIgnore]
		public NuGetVersion Version 
			=> NuGetVersion.Parse(Revision);
	}

	[XmlRoot(ElementName="license")]
	public class License {
		[XmlAttribute(AttributeName="id")]
		public string Id { get; set; }
		[XmlAttribute(AttributeName="type")]
		public string Type { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName="licenses")]
	public class Licenses {
		[XmlElement(ElementName="license")]
		public List<License> License { get; set; }
	}

	[XmlRoot(ElementName="xamarin-android")]
	public class XamarinAndroid {
		[XmlElement(ElementName="jdk")]
		public List<Jdk> Jdk { get; set; }
		[XmlElement(ElementName="platform-tools")]
		public List<PlatformTools> PlatformTools { get; set; }
		[XmlElement(ElementName="cmdline-tools")]
		public List<CmdlineTools> CmdlineTools { get; set; }
		[XmlElement(ElementName="build-tool")]
		public List<BuildTool> BuildTool { get; set; }
		[XmlElement(ElementName="emulator")]
		public Emulator Emulator { get; set; }
		[XmlElement(ElementName="ndk")]
		public List<Ndk> Ndk { get; set; }
		[XmlElement(ElementName="platform")]
		public List<Platform> Platform { get; set; }
		[XmlElement(ElementName="system-image")]
		public List<SystemImage> SystemImage { get; set; }
		[XmlElement(ElementName="addon")]
		public List<Addon> Addon { get; set; }
		[XmlAttribute(AttributeName="addon", Namespace="http://www.w3.org/2000/xmlns/")]
		public string _Addon { get; set; }
		[XmlElement(ElementName="extra")]
		public List<Extra> Extra { get; set; }
		[XmlElement(ElementName="licenses")]
		public Licenses Licenses { get; set; }
		[XmlAttribute(AttributeName="sdk-version")]
		public string SdkVersionStr { get; set; }
		[XmlAttribute(AttributeName="generated-on")]
		public string GeneratedOn { get; set; }
		[XmlAttribute(AttributeName="sdk", Namespace="http://www.w3.org/2000/xmlns/")]
		public string Sdk { get; set; }
		[XmlAttribute(AttributeName="common", Namespace="http://www.w3.org/2000/xmlns/")]
		public string Common { get; set; }
		[XmlAttribute(AttributeName="sdk-common", Namespace="http://www.w3.org/2000/xmlns/")]
		public string SdkCommon { get; set; }
		[XmlAttribute(AttributeName="generic", Namespace="http://www.w3.org/2000/xmlns/")]
		public string Generic { get; set; }
		[XmlAttribute(AttributeName="xsi", Namespace="http://www.w3.org/2000/xmlns/")]
		public string Xsi { get; set; }
		[XmlAttribute(AttributeName="sys-img", Namespace="http://www.w3.org/2000/xmlns/")]
		public string SysImg { get; set; }
		
		[XmlIgnore]
		public NuGetVersion SdkVersion 
			=> NuGetVersion.Parse(SdkVersionStr);
	}

}
