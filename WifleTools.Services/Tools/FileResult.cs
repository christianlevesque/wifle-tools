using System.IO;

namespace WifleTools.Tools;

public class FileResult
{
	public Stream? File { get; set; }
	public string Filename { get; set; } = string.Empty;
}