#nullable disable
using Microsoft.EntityFrameworkCore;

namespace WifleTools.Data;

public class AppDbContext : DbContext
{
	public const string SqliteDbName = "wifletools.db";

	public AppDbContext(DbContextOptions options) : base(options) {}

	public DbSet<Account> Accounts { get; set; }
	public DbSet<Client> Clients { get; set; }
	public DbSet<Invoice> Invoices { get; set; }
	public DbSet<Recipient> Recipients { get; set; }
}