using Microsoft.EntityFrameworkCore;
using WifleTools.Tools;

namespace WifleTools.Extensions;

public static class DbcontextOptionsBuilderExtensions
{
	public static void UseWifleDb(this DbContextOptionsBuilder self)
	{
		self.UseSqlite($"Data Source={Utils.GetDbContextFullPath()}");
	}
}