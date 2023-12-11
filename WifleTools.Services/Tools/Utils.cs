using System;
using System.IO;
using System.Threading.Tasks;
using WifleTools.Data;

namespace WifleTools.Tools;

public static class Utils
{
	public const string BaseAppFolderName = "WifleTools";

	public static string GetBaseDirectory()
	{
		var baseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
		return Path.Combine(baseDirectory, BaseAppFolderName);
	}

	public static string GetDbContextFullPath()
		=> Path.Combine(GetBaseDirectory(), AppDbContext.SqliteDbName);

	public static string GetDbContextBackupFullPath()
		=> $"{GetDbContextFullPath()}.backup";

	public static int GetInvoiceAmount(Invoice invoice) => invoice.Amount * invoice.Client.Rate;

	public static string ToCurrencyString(this int value) => $"{(double)value / 100:C}";
}