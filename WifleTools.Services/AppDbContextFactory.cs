using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WifleTools.Extensions;
using WifleTools.Files;

namespace WifleTools;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
	/// <inheritdoc />
	public AppDbContext CreateDbContext(string[] args)
	{
		var fileWriter = new FileWriter();
		var builder = new DbContextOptionsBuilder<AppDbContext>();
		builder.UseWifleDb(fileWriter);
		return new AppDbContext(builder.Options);
	}
}