#nullable disable
using Microsoft.EntityFrameworkCore;
using WifleTools.Banking;
using WifleTools.Clients;
using WifleTools.Recipients;

namespace WifleTools;

public class AppDbContext : DbContext
{
	public const string SqliteDbName = "wifletools.db";

	public AppDbContext(DbContextOptions options) : base(options) {}

	public DbSet<Account> Accounts { get; set; }
	public DbSet<Client> Clients { get; set; }
	public DbSet<Recipient> Recipients { get; set; }
}