#nullable disable
using Microsoft.EntityFrameworkCore;
using WifleTools.Banking;
using WifleTools.Clients;

namespace WifleTools;

public class AppDbContext : DbContext
{
	public const string SqliteDbName = "wifletools.db";

	public AppDbContext(DbContextOptions options) : base(options) {}

	public DbSet<Account> Accounts { get; set; }
	public DbSet<Client> Clients { get; set; }
}