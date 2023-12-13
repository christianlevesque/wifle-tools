using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using WifleTools.Data;

namespace WifleTools.Tools;

public static class StartupUtils
{
	public static void MigrateDb(this IServiceProvider self)
	{
		var dbPath = Utils.GetDbContextFullPath();
		var backupPath = Utils.GetDbContextBackupFullPath();
		var enableBackup = File.Exists(dbPath);

		// Make backup of existing database
		if (enableBackup)
		{
			File.Copy(dbPath, backupPath, true);
		}

		// Perform migration
		try
		{
			using var scope = self.CreateScope();
			var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
			var migrator = dbContext.Database.GetService<IMigrator>();
			migrator.Migrate();
		}
		catch (Exception e)
		{
			if (enableBackup)
			{
				File.Copy(backupPath, dbPath, true);
				File.Delete(backupPath);
			}

			throw new Exception("Wifle, the database failed to update. Let hubber know!", e);
		}

		// Migration was successful, so delete backup
		if (enableBackup)
		{
			File.Delete(backupPath);
		}
	}

	public static void EnsureAppdataDirectoryExists()
	{
		var dirname = Utils.GetBaseDirectory();
		if (!Directory.Exists(dirname))
		{
			Directory.CreateDirectory(dirname);
		}
	}
}