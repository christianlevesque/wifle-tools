using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WifleTools.Files;

namespace WifleTools;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
	/// <inheritdoc />
	public AppDbContext CreateDbContext(string[] args)
	{
		var fileWriter = new FileWriter();
		var builder = new DbContextOptionsBuilder<AppDbContext>();
		builder.UseSqlite($"Data Source={fileWriter.BaseDirectory}/{AppDbContext.DbContextName}");
		return new AppDbContext(fileWriter, builder.Options);
	}
}