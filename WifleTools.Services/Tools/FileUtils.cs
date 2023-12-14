using System;
using System.IO;
using System.Threading.Tasks;
using WifleTools.Data;

namespace WifleTools.Tools;

public static class FileUtils
{
	public const string BaseAppFolderName = "WifleTools";

	public static string GetBaseDirectory()
	{
		var baseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
		return Path.Combine(baseDirectory, BaseAppFolderName);
	}

	public static string GetDesktopDirectory()
		=> Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

	public static string GetDbContextFullPath()
		=> Path.Combine(GetBaseDirectory(), AppDbContext.SqliteDbName);

	public static string GetDbContextBackupFullPath()
		=> $"{GetDbContextFullPath()}.backup";

	public static string GetInvoiceFullPath(Invoice invoice)
		=> Path.Combine(
			GetDesktopDirectory(),
			InvoiceUtils.CreateInvoiceFilename(invoice));
}