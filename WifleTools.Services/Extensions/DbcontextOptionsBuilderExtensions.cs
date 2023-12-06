using Microsoft.EntityFrameworkCore;
using WifleTools.Files;

namespace WifleTools.Extensions;

public static class DbcontextOptionsBuilderExtensions
{
	public static void UseWifleDb(
		this DbContextOptionsBuilder self,
		IFileWriter fileWriter)
	{
		self.UseSqlite($"Data Source={fileWriter.DbContextFullPath}");
	}
}