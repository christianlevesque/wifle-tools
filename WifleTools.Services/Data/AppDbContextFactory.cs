using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WifleTools.Extensions;

namespace WifleTools.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
	/// <inheritdoc />
	public AppDbContext CreateDbContext(string[] args)
	{
		var builder = new DbContextOptionsBuilder<AppDbContext>();
		builder.UseWifleDb();
		return new AppDbContext(builder.Options);
	}
}