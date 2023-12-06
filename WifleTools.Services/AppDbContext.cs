using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WifleTools.Files;

namespace WifleTools;

public class AppDbContext : DbContext
{
	public const string DbContextName = "siteveyor.db";
	private readonly IFileWriter _fileWriter;

	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

	/// <inheritdoc />
	public AppDbContext(IFileWriter fileWriter, DbContextOptions<AppDbContext> options) : base(options)
	{
		_fileWriter = fileWriter;
	}

	[ActivatorUtilitiesConstructor]
	public AppDbContext(IFileWriter fileWriter)
	{
		_fileWriter = fileWriter;
	}

	protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={_fileWriter.BaseDirectory}/{DbContextName}");
}