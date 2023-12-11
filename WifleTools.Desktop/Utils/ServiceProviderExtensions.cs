using System;
using WifleTools.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace WifleTools.Utils;

public static class ServiceProviderExtensions
{
	public static IServiceProvider UpdateDb(this IServiceProvider self)
	{
		var db = self.GetRequiredService<AppDbContext>();
		var migrator = db.Database.GetService<IMigrator>();
		migrator?.Migrate();
		return self;
	}
}