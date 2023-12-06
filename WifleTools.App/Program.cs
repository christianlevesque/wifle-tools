using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MudBlazor.Services;
using WifleTools.Clients;
using WifleTools.Extensions;
using WifleTools.Files;
using WifleTools.Infrastructure;
using WifleTools.State;

namespace WifleTools;

public static class Program
{
	public static async Task Main(string[] args)
	{
		var fileWriter = new FileWriter();
		Initialize(fileWriter);

		var builder = WebApplication.CreateBuilder(args);

		builder.WebHost.UseElectron(args);

		// Add services to the container.
		builder.Services.AddRazorPages();
		builder.Services.AddServerSideBlazor();

		builder.Services
			.AddMudServices()
			.AddDbContext<AppDbContext>(
				o => o.UseWifleDb(fileWriter),
				ServiceLifetime.Transient)
			.AddSingleton<NavMenuState>()
			.AddTransient<ICrudService<Client>, ClientService>()
			.AddTransient(typeof(IStatusLogger<>), typeof(StatusLogger<>))
			.AddSingleton<IFileWriter>(fileWriter);

		var app = builder.Build();

		await MigrateDb(app.Services, fileWriter);

		// Configure the HTTP request pipeline.
		if (!app.Environment.IsDevelopment())
		{
			app.UseExceptionHandler("/Error");
		}

		app.UseStaticFiles();

		app.UseRouting();

		app.MapBlazorHub();
		app.MapFallbackToPage("/_Host");

		if (HybridSupport.IsElectronActive)
		{
			CreateElectronWindow();
		}

		await app.RunAsync();
	}

	private static async void CreateElectronWindow()
	{
		var screen = await Electron.Screen.GetPrimaryDisplayAsync();
		var options = new BrowserWindowOptions
		{
			Title = "Wifle Tools",
			Height = screen.Size.Height,
			Width = screen.Size.Width
		};
	
		var window = await Electron.WindowManager.CreateWindowAsync(options);
		window.OnClosed += () => Electron.App.Quit();
	}

	private static void Initialize(IFileWriter fileWriter)
	{
		Debug.WriteLine($"Folder is {fileWriter.BaseDirectory}");
		if (!Directory.Exists(fileWriter.BaseDirectory))
		{
			Directory.CreateDirectory(fileWriter.BaseDirectory);
		}
	}

	private static async Task MigrateDb(
		IServiceProvider serviceProvider,
		IFileWriter fileWriter)
	{
		var backupPath = Path.Combine(fileWriter.BaseDirectory, $"{AppDbContext.SqliteDbName}.backup");
		var enableBackup = File.Exists(fileWriter.DbContextFullPath);

		// Make backup of existing database
		if (enableBackup)
		{
			File.Copy(fileWriter.DbContextFullPath, backupPath);
		}

		// Perform migration
		try
		{
			await using var scope = serviceProvider.CreateAsyncScope();
			var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
			var migrator = dbContext.Database.GetService<IMigrator>();
			await migrator.MigrateAsync();
		}
		catch (Exception)
		{
			if (enableBackup)
			{
				File.Copy(backupPath, fileWriter.DbContextFullPath);
			}

			// TODO: find a way to inform Wifle that there's a problem
			return;
		}

		// Migration was successful, so delete backup
		if (enableBackup)
		{
			File.Delete(backupPath);
		}
	}
}