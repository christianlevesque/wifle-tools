using System;
using System.IO;

namespace WifleTools.Files;

public class FileWriter : IFileWriter
{
	private string _baseDirectory = string.Empty;

	/// <inheritdoc />
	public string BaseAppFolderName => "Siteveyor";

	/// <inheritdoc />
	public string BaseDirectory
	{
		get
		{
			if (!string.IsNullOrEmpty(_baseDirectory))
			{
				return _baseDirectory;
			}

			var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			_baseDirectory = Path.Combine(path, BaseAppFolderName);

			return _baseDirectory;
		}
	}
}

public interface IFileWriter
{
	string BaseDirectory { get; }
	string BaseAppFolderName { get; }
}